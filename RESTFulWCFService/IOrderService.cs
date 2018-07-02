using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace RESTFulWCFService
{   
    [ServiceContract]
    public interface IOrderService 
    {
    
        [OperationContract]
        [WebInvoke(UriTemplate = "/device", 
            RequestFormat= WebMessageFormat.Json,   
            ResponseFormat = WebMessageFormat.Json, Method = "POST")] 
        bool PlaceOrder(OrderContract order);
    }
}
