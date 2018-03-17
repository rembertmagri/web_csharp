using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using POC_Common;
using POC_Business;

namespace POC_Service_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProductService.svc or ProductService.svc.cs at the Solution Explorer and start debugging.
    public class ProductService : IProductService
    {
        private IProductBusiness productBusiness = new ProductBusiness();

        public IList<ProductDTO> findAll()
        {
            return productBusiness.findAll();
        }

        public ContainerDTO<ProductDTO> findAllPaged(int start, int length)
        {
            return productBusiness.findAll(start, length);
        }

        public ProductDTO findById(int id)
        {
            return productBusiness.findById(id);
        }

        public IList<ProductDTO> findByCreationDate(DateTime creationDate)
        {
            return productBusiness.findByCreationDate(creationDate);
        }

        public Boolean create(ProductDTO product)
        {
            return productBusiness.create(product);
        }

        public Boolean update(ProductDTO product)
        {
            return productBusiness.update(product);
        }

        public Boolean delete(int id)
        {
            return productBusiness.delete(id);
        }

    }
}
