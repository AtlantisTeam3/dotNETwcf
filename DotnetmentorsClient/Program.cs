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
           
            PlaceOrder(); 
            Console.ReadKey(true);
        }

       

        private static void PlaceOrder()
        {            
            OrderContract order = new OrderContract
            {
               
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
            webClient.UploadString("http://localhost:61090/OrderService.svc/device", "POST", data);              
            Console.WriteLine("Order placed successfully...");  
        }
    }
}
