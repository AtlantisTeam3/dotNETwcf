using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml.Linq;
using System.Collections;

namespace RESTFulWCFService
{    
    public class OrderService : IOrderService
    {
        //public string GetOrderTotal(string OrderID)
       // {
         //   string orderTotal = string.Empty;
//
         //   try
           // {
            //    XDocument doc = XDocument.Load("C://Users/Lumix/Desktop/RESTFulWCFService/RESTFulWCFService/Orders.xml");
               
            //         orderTotal =
             //       (from result in doc.Descendants("DocumentElement")
               //     .Descendants("Orders")   
              //       where result.Element("OrderID").Value == OrderID.ToString()
             //        select result.Element("OrderTotal").Value)
             //       .FirstOrDefault<string>();
            //
          //  }
           // catch (Exception ex)
          //  {
          //      throw new FaultException<string>
         //            (ex.Message);
          //  }
         //   return orderTotal;
      //  }

      //  public OrderContract GetOrderDetails(string OrderID)
      //  {
      //      OrderContract order = new OrderContract();

     //       try
     //       {
      //          XDocument doc = XDocument.Load("C://Users/Lumix/Desktop/RESTFulWCFService/RESTFulWCFService/Orders.xml");
                
        //        IEnumerable<XElement> orders =
         //                (from result in doc.Descendants("DocumentElement")
         //                       .Descendants("Orders")
         //                 where result.Element("OrderID").Value == OrderID.ToString()
         //                 select result);
         //
         //       order.OrderID = orders.ElementAt(0).Element("OrderID").Value;
          //      order.OrderDate = orders.ElementAt(0).Element("OrderDate").Value;
         //       order.ShippedDate = orders.ElementAt(0).Element("ShippedDate").Value; 
         //       order.ShipCountry = orders.ElementAt(0).Element("ShipCountry").Value; 
         //       order.OrderTotal = orders.ElementAt(0).Element("OrderTotal").Value;
         //       order.metricDate = orders.ElementAt(0).Element("metricDate").Value;
         //       order.deviceType = orders.ElementAt(0).Element("deviceType").Value;
         //       order.metricValue = orders.ElementAt(0).Element("metricValue").Value;
           
          //  }
        //    catch (Exception ex)
        //    {
        //        throw new FaultException<string>
       //              (ex.Message);
        //    }
        //    return order;
       // }

        public bool PlaceOrder(OrderContract order)
        {
            try
            {
                XDocument doc = XDocument.Load("C://Users/Lumix/Desktop/RESTFulWCFService/RESTFulWCFService/Orders.xml");

                doc.Element("DocumentElement").Add(
                      // new XElement("OrderID", order.OrderID),
                      // new XElement("OrderDate", order.OrderDate),
                      // new XElement("ShippedDate", order.ShippedDate),
                      //  new XElement("ShipCountry", order.ShipCountry),
                      //  new XElement("OrderTotal", order.OrderTotal),
                        new XElement("Devices",
                        new XElement("deviceID", order.deviceID),
                        new XElement("metricDate", order.metricDate),
                        new XElement("deviceType", order.deviceType),
                        new XElement("metricValue", order.metricValue)
                        ));

                doc.Save("C://Users/Lumix/Desktop/RESTFulWCFService/RESTFulWCFService/Orders.xml");
                
            }
            catch (Exception ex)
            {
                throw new FaultException<string>
                     (ex.Message);
            }
            return true;
        }
    }
}
