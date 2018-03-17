using POC_Common;
using POC_Data_EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace POC_Business
{
    public class ProductBusiness : IProductBusiness
    {
        private POCEntities pocEntities = new POCEntities();

        public IList<ProductDTO> findAll()
        {
            var productList = pocEntities.Products.ToList();
            return productList.Select(p => EFModelToDTOUtil.ToProductDTOMap(p)).ToList();
        }

        public ContainerDTO<ProductDTO> findAll(int start, int length)
        {
            int total = pocEntities.Products.Count();
            var productList = pocEntities.Products.OrderBy(p=>p.Id).Skip(start).Take(length).ToList();
            var productDTOList = productList.Select(p => EFModelToDTOUtil.ToProductDTOMap(p)).ToList();
            return new ContainerDTO<ProductDTO>() { list = productDTOList, total = total };
        }

        public ProductDTO findById(int id)
        {
            var product = pocEntities.Products.Single(p => p.Id == id);
            return EFModelToDTOUtil.ToProductDTOMap(product);
        }

        public IList<ProductDTO> findByCreationDate(DateTime creationDate)
        {
            var productList = pocEntities.Products.Where(p => p.CreationDate.Value == creationDate).ToList();
            return productList.Select(p => EFModelToDTOUtil.ToProductDTOMap(p)).ToList();
        }

        public Boolean create(ProductDTO productDTO)
        {
            var product = EFModelToDTOUtil.ToProductMap(productDTO);
            product.CreationDate = DateTime.Now;
            Product insertedProduct = pocEntities.Products.Add(product);
            int savedObjects = pocEntities.SaveChanges();
            return savedObjects>0 && insertedProduct.Id!=0;
        }

        public Boolean update(ProductDTO productDTO)
        {
            var productOldValues = pocEntities.Products.Single(p => p.Id == productDTO.Id);
            var productNewValues = EFModelToDTOUtil.ToProductMap(productDTO);
            productNewValues.CreationDate = productOldValues.CreationDate; // We don't want the user to change the CreationDate

            pocEntities.Entry(productOldValues).CurrentValues.SetValues(productNewValues);
            
            int savedObjects = pocEntities.SaveChanges();
            return savedObjects > 0;
        }

        public Boolean delete(int id)
        {
            var product = pocEntities.Products.Single(p => p.Id == id);
            pocEntities.Products.Remove(product);
            int deletedObjects = pocEntities.SaveChanges();
            return deletedObjects > 0;
        }
    }
}