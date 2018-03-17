using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POC_Common
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
    }
}