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
      //  [OperationContract]
      //  [WebGet(UriTemplate = "/GetOrderTotal/{OrderID}",
      //      ResponseFormat= WebMessageFormat.Json)]
      //  string GetOrderTotal(string OrderID);

      //  [OperationContract]
      //  [WebGet(UriTemplate = "/GetOrderDetails/{OrderID}", 
      //      RequestFormat=WebMessageFormat.Json,            
      //      ResponseFormat = WebMessageFormat.Json)]
      //  OrderContract GetOrderDetails(string OrderID);

        [OperationContract]
        [WebInvoke(UriTemplate = "/PlaceDevice", 
            RequestFormat= WebMessageFormat.Json,   
            ResponseFormat = WebMessageFormat.Json, Method = "POST")] 
        bool PlaceOrder(OrderContract order);
    }
}
