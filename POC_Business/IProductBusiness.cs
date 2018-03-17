using POC_Common;
using POC_Data_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC_Business
{
    public interface IProductBusiness
    {
        IList<ProductDTO> findAll();

        ContainerDTO<ProductDTO> findAll(int start, int length);

        ProductDTO findById(int id);

        IList<ProductDTO> findByCreationDate(DateTime creationDate);

        Boolean create(ProductDTO productDTO);

        Boolean update(ProductDTO productDTO);

        Boolean delete(int id);
    }
}
