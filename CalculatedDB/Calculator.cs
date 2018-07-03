using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CalculatedDB
{
    public class Calculator
    {
        public static void DocumentCreation(string id, string dateTime, string dataType, double value, string deviceType)
        {
            BsonDocument device = new BsonDocument {
                  {"ID", id},
                  {"DateTime", dateTime},
                  {"DataType", dataType},
                  {"Value", value},
                  {"DeviceType", deviceType}
            };

            var newDevices = new List<BsonDocument>();
            newDevices.Add(device);

            var client = new MongoClient();
            IMongoDatabase db = client.GetDatabase("DeviceDB");
            var collection = db.GetCollection<BsonDocument>("CalculatedData");
            
            collection.InsertOne(device);
        }
        

    }
}
