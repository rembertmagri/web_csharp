var productsDataTable;
$(document).ready(function () {
    productsDataTable = $('#productDataTable').DataTable({
        serverSide: true,
        processing: true,
        searching: false,
        ordering:  false,
        ajax: {
            url: '/jQueryDatatables/Product/GetDataTable',
            type: 'GET'
        },
        "columns": [
                { "data": "Id", "orderable": true },
                { "data": "Name", "orderable": false },
                { "data": "Price", "orderable": true },
                { "data": "Quantity", "orderable": true },
                { "data": "CreationDate", "orderable": true },
                { "data": "Id", "render": function (data) {
                    return '<a href=javascript:ShowReadModal(' + data + '); class="btn btn-info">Details</a>&nbsp;' +
                            '<a href=javascript:ShowUpdateModal(' + data + '); class="btn btn-warning">Edit</a>&nbsp;' +
                            '<a href=javascript:ShowDeleteModal(' + data + '); class="btn btn-danger">Delete</a>';
                    }
                }
        ],
        "order": [[0, "asc"]]
    });

    $('#createNewjQuery').click(function (event) {
        var form, dialog;
        event.preventDefault();
        $.get("/jQueryDatatables/Product/Create", function (data) {
            $('#renderModal').html(data);
            dialog = $("#renderModal").dialog({
                width: 400,
                modal: true,
                buttons: {
                    Cancel: function () {
                        dialog.dialog("close");
                    }
                }
            });
            form = dialog.find("form").on("submit", function (event) {
                event.preventDefault();
                $.post('/jQueryDatatables/Product/Create', form.serialize(), function (data) {
                        dialog.dialog("close");
                        productsDataTable.draw(false);
                    },
                    'json');
            });
        });
    });

});

function ShowReadModal(id) {
    $.get("/jQueryDatatables/Product/Read/" + id, function (data) {
        $('#renderModal').html(data);
        dialog = $("#renderModal").dialog({
            width: 400,
            modal: true,
            buttons: {
                Cancel: function () {
                    dialog.dialog("close");
                }
            }
        });
    });
};

function ShowUpdateModal(id) {
    $.get("/jQueryDatatables/Product/Update/" + id, function (data) {
        $('#renderModal').html(data);
        dialog = $("#renderModal").dialog({
            width: 400,
            modal: true,
            buttons: {
                Cancel: function () {
                    dialog.dialog("close");
                }
            }
        });
        form = dialog.find("form").on("submit", function (event) {
            event.preventDefault();
            $.post('/jQueryDatatables/Product/Update', form.serialize(), function (data) {
                    dialog.dialog("close");
                    productsDataTable.draw(false);
                },
                'json');
        });
    });
};

function ShowDeleteModal(id) {
    $.get("/jQueryDatatables/Product/Delete/" + id, function (data) {
        $('#renderModal').html(data);
        dialog = $("#renderModal").dialog({
            width: 400,
            modal: true,
            buttons: {
                Cancel: function () {
                    dialog.dialog("close");
                }
            }
        });
        form = dialog.find("form").on("submit", function (event) {
            event.preventDefault();
            $.post('/jQueryDatatables/Product/Delete/' + id, form.serialize(), function (data) {
                dialog.dialog("close");
                productsDataTable.draw(false);
            },
                'json');
        });
    });
};