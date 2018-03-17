using POC_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace POC_Service_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductService" in both code and config file together.
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        IList<ProductDTO> findAll();

        [OperationContract]
        ContainerDTO<ProductDTO> findAllPaged(int start, int length);

        [OperationContract]
        ProductDTO findById(int id);

        [OperationContract]
        IList<ProductDTO> findByCreationDate(DateTime creationDate);

        [OperationContract]
        Boolean create(ProductDTO product);

        [OperationContract]
        Boolean update(ProductDTO product);

        [OperationContract]
        Boolean delete(int id);
    }
}
