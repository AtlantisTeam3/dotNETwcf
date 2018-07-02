using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatedDB
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }

        static async Task MainAsync()
        {

             /* var client = new MongoClient();

               IMongoDatabase db = client.GetDatabase("DeviceDB");

               var collection = db.GetCollection<BsonDocument>("CalculatedData");
               var newDevices = CreateNewDevices();

               await collection.InsertManyAsync(newDevices);  */
            

                var client = new MongoClient();

                IMongoDatabase db = client.GetDatabase("DeviceDB");

                var collection = db.GetCollection<BsonDocument>("CalculatedData");


            //récuperer un élément
            var filter = new BsonDocument("ID", "1");
            await collection.Find(filter)
                     .ForEachAsync(document => Console.WriteLine(document)); 
           
        }
        

        private static IEnumerable<BsonDocument> CreateNewDevices()
        {
            var device1 = new BsonDocument
    {
      {"ID", "1"},
      {"DateTime", "10/12/2015"},
      {"DataType", "Temperature"},
      {"Value", 37},
      {"DeviceType", "TemperatureSensor"}
    };

            var device2 = new BsonDocument
    {
      {"ID", "2"},
      {"DateTime", "29/06/2018"},
      {"DataType", "Brightness"},
      {"Value", 15},
      {"DeviceType", "BrightnessSensor"}
    };

            var device3 = new BsonDocument
    {
      {"ID", "3"},
      {"DateTime", "12/02/2002"},
      {"DataType", "Humidity"},
      {"Value",  20},
      {"DeviceType", "HumiditySensor"}
    };

            var newDevices = new List<BsonDocument>();
            newDevices.Add(device1);
            newDevices.Add(device2);
            newDevices.Add(device3);

            return newDevices;
        }
    }
}


