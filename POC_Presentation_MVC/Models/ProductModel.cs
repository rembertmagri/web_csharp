using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POC_Presentation_MVC.Models
{
    public class ProductModel
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Price")]
        public decimal? Price { get; set; }

        [DisplayName("Quantity")]
        public int? Quantity { get; set; }

        [DisplayName("Creation Date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? CreationDate { get; set; }
    }
}