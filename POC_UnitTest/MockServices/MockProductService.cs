using POC_Presentation_MVC.ProductServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POC_Common;
using System.Collections;

namespace POC_UnitTest.MockServices
{
    public class MockProductService : IProductService
    {

        private IList<ProductDTO> db = new List<ProductDTO>();

        public ProductDTO[] findAll()
        {
            return db.ToArray();
        }

        public Task<ProductDTO[]> findAllAsync()
        {
            throw new NotImplementedException();
        }

        public ContainerDTO<ProductDTO> findAllPaged(int start, int length)
        {
            throw new NotImplementedException();
        }

        public Task<ContainerDTO<ProductDTO>> findAllPagedAsync(int start, int length)
        {
            throw new NotImplementedException();
        }

        public ProductDTO[] findByCreationDate(DateTime creationDate)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO[]> findByCreationDateAsync(DateTime creationDate)
        {
            throw new NotImplementedException();
        }

        public ProductDTO findById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> findByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool create(ProductDTO product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> createAsync(ProductDTO product)
        {
            throw new NotImplementedException();
        }

        public bool delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> deleteAsync(int id)
        {
            throw new NotImplementedException();
        }
        
        public bool update(ProductDTO product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> updateAsync(ProductDTO product)
        {
            throw new NotImplementedException();
        }
    }
}
