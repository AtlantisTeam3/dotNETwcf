using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using RESTFulWCFService;

namespace DotnetmentorsClient
{
    class Program
    {
        static void Main(string[] args)
        {
           // GetOrderDetails("10251");
           // GetOrderTotal("1057");
            PlaceOrder(); 
            Console.ReadKey(true);
        }

       // private static void GetOrderDetails(string orderID)
       // {
         //   WebClient proxy = new WebClient();
        //    string serviceURL = string.Format("http://localhost:61090/OrderService.svc/GetOrderDetails/{0}", orderID); 
         //   byte[] data = proxy.DownloadData(serviceURL);
         //   Stream stream = new MemoryStream(data);
         //   DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(OrderContract));
         //   OrderContract order = obj.ReadObject(stream) as OrderContract;
         //   Console.WriteLine("Order ID : " + order.OrderID);
        //    Console.WriteLine("Order Date : " + order.OrderDate);
        //   Console.WriteLine("Order Shipped Date : " + order.ShippedDate);
        //    Console.WriteLine("Order Ship Country : " + order.ShipCountry);
         //   Console.WriteLine("Order Total : " + order.OrderTotal);
         //   Console.WriteLine("metricDate :" + order.metricDate);
       //     Console.WriteLine("deviceType :" + order.deviceType);
       //     Console.WriteLine("metricValue :" + order.metricValue);
      //      Console.WriteLine("deviceID :" + order.deviceID);

       // }

      //  private static void GetOrderTotal(string orderID)
       // {
      //      Console.WriteLine();  
     //       Console.WriteLine("**** Output for GetOrderTotal ************");  
      //      WebClient proxy = new WebClient();
       //     string serviceURL = string.Format("http://localhost:61090/OrderService.svc/GetOrderTotal/{0}", orderID);
      //      byte[] data = proxy.DownloadData(serviceURL);
      //      Stream stream = new MemoryStream(data);
      //      DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(string));
      //      string order = Convert.ToString(obj.ReadObject(stream));
      //      Console.WriteLine(order);
     //   }

        private static void PlaceOrder()
        {            
            OrderContract order = new OrderContract
            {
               // OrderID = "10550",
                //OrderDate = DateTime.Now.ToString(),
                //ShippedDate = DateTime.Now.AddDays(10).ToString(),
               // ShipCountry = "India",
               // OrderTotal = "781",
                metricDate = DateTime.Now.ToString(),
                deviceType = "presenceSensor",
                metricValue = "string",
                deviceID = ""
            };      
      
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(OrderContract));
            MemoryStream mem = new MemoryStream();
            ser.WriteObject(mem, order);
            string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
            WebClient webClient = new WebClient();            
            webClient.Headers["Content-type"] = "application/json";            
            webClient.Encoding = Encoding.UTF8;
            webClient.UploadString("http://localhost:61090/OrderService.svc/PlaceDevice", "POST", data);              
            Console.WriteLine("Order placed successfully...");  
        }
    }
}
