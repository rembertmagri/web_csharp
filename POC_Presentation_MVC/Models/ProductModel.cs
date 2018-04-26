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

        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [Range(0, 9999.99)]
        [DataType(DataType.Currency)]
        [DisplayName("Price")]
        public decimal? Price { get; set; }

        [Required]
        [DisplayName("Quantity")]
        [Range(0, 9999)]
        public int? Quantity { get; set; }

        [DisplayName("Creation Date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime? CreationDate { get; set; }

    }
}