using POC_Common;
using POC_Data_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POC_Business
{
    public static class EFModelToDTOUtil
    {
        public static ProductDTO ToProductDTOMap(Product product)
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

        public static Product ToProductMap(ProductDTO product)
        {
            return new Product()
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