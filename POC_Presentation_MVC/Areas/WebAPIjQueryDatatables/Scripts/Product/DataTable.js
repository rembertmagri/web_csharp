var productsDataTable;
$(document).ready(function () {
    productsDataTable = $('#productDataTable').DataTable({
        serverSide: true,
        processing: true,
        searching: false,
        ordering:  false,
        ajax: {
            url: 'http://localhost:53372/api/product/GetDataTable',
            type: 'GET'
        },
        "columns": [
                { "data": "id", "orderable": true },
                { "data": "name", "orderable": false },
                { "data": "price", "orderable": true },
                { "data": "quantity", "orderable": true },
                { "data": "creationDate", "orderable": true },
                { "data": "id", "render": function (data) {
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
        $.get("/webAPIjQueryDatatables/Product/Create", function (data) {
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
                $.ajax({
                    method: "POST",
                    url: 'http://localhost:53372/api/product/',
                    data: form.serialize(),
                    dataType: "application/json",
                    statusCode: {
                        201: function () {
                            dialog.dialog("close");
                            productsDataTable.draw(false);
                        },
                        400: function () { alert("bad request"); },
                        500: function () { alert("internal server error"); }
                    }
                });
            });
        });
    });

});

function ShowReadModal(id) {
    $.get("/webAPIjQueryDatatables/Product/Read/" + id, function (data) {
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
    $.get("/webAPIjQueryDatatables/Product/Update/" + id, function (data) {
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
            $.ajax({
                method: "PUT",
                url: 'http://localhost:53372/api/product/'+id,
                data: form.serialize(),
                dataType: "application/json",
                statusCode: {
                    204: function () {
                        dialog.dialog("close");
                        productsDataTable.draw(false);
                    },
                    400: function () { alert("bad request"); },
                    500: function () { alert("internal server error"); }
                }
            });
        });
    });
};

function ShowDeleteModal(id) {
    $.get("/webAPIjQueryDatatables/Product/Delete/" + id, function (data) {
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
            $.ajax({
                method: "DELETE",
                url: 'http://localhost:53372/api/product/'+id,
                data: form.serialize(),
                dataType: "application/json",
                statusCode: {
                    204: function () {
                        dialog.dialog("close");
                        productsDataTable.draw(false);
                    },
                    400: function () { alert("bad request"); },
                    500: function () { alert("internal server error"); }
                }
            });
        });
    });
};