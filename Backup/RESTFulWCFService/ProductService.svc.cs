using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml.Linq;

namespace RESTFulWCFService
{   
    public class ProductService : IProductService
    {
        public string GetProductName(string productID)
        {
            string productName = string.Empty;

            try
            {
                XDocument doc = XDocument.Load("C:\\products.xml");

                productName =
                    (from result in doc.Descendants("DocumentElement")
                    .Descendants("Products")
                     where result.Element("productID").Value == productID.ToString()
                     select result.Element("productname").Value)
                    .FirstOrDefault<string>();
                
            }
            catch (Exception ex)
            {
                throw new FaultException<string>
                     (ex.Message);
            }

            return productName;
        }

        public string GetProductQty(string productID)
        {
            string strProductQty = string.Empty; 

            try
            {
                XDocument doc = XDocument.Load("C:\\products.xml");
                 
                strProductQty =
                    (from result in doc.Descendants("DocumentElement")
                    .Descendants("Products")
                     where result.Element("productID").Value == productID.ToString()
                     select result.Element("UnitsInStock").Value)
                    .FirstOrDefault<string>();
            }
            catch (Exception ex)
            {
                throw new FaultException<string>
                   (ex.Message);
            }
            return strProductQty;
        }

        public string GetProductsCount()
        {
            XDocument doc = XDocument.Load("C:\\products.xml");

            return doc.Descendants("Products").Count().ToString();
        }
    }
}
