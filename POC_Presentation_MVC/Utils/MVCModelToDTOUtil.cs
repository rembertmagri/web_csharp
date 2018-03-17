using POC_Common;
using POC_Presentation_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POC_Presentation_MVC.Utils
{
    public class MVCModelToDTOUtil
    {
        public static ProductDTO ToProductDTOMap(ProductModel product)
        {
            return new ProductDTO()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                CreationDate = product.CreationDate
            };
        }

        public static ProductModel ToProductModelMap(ProductDTO product)
        {
            return new ProductModel()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                CreationDate = product.CreationDate
            };
        }
    }
}