using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace RESTFulWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductService" in both code and config file together.
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/ProductName/{productID}")]
        string GetProductName(string productID);

        [OperationContract]
        [WebGet(UriTemplate = "/ProductQty/{productID}")]
        string GetProductQty(string productID);

        [OperationContract]
        [WebGet(UriTemplate = "/ProductsCount")]
        string GetProductsCount();
    }
}
