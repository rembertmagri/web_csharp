using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POC_Presentation_MVC.Utils.DataTables
{
    public class jQueryDataTableData<T>
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public IList<T> data { get; set; }

        public jQueryDataTableData(int draw, int total, IList<T> data)
        {
            this.draw = draw;
            recordsTotal = total;
            recordsFiltered = total;
            this.data = data;
        }
    }
}