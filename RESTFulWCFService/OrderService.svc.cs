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

        public bool PlaceOrder(OrderContract order)
        {
            try
            {
                XDocument doc = XDocument.Load("C://Users/Lumix/Desktop/RESTFulWCFService/RESTFulWCFService/Orders.xml");

                doc.Element("DocumentElement").Add(
                      
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
