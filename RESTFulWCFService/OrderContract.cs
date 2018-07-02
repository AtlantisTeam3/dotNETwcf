using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace RESTFulWCFService
{
    [DataContract]
    public class OrderContract
    {
     
        [DataMember]
        public string deviceID { get; set; }

        [DataMember]
        public string metricDate { get; set; }

        [DataMember]
        public string deviceType { get; set; }

        [DataMember]
        public string metricValue { get; set; }
    }
}