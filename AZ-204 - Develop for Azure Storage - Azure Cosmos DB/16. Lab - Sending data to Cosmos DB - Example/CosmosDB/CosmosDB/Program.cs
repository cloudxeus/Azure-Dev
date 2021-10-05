using Microsoft.Azure.Cosmos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace CosmosDB
{
    class Program
    {
        private static readonly string _connection_string = "AccountEndpoint=https://appaccount100.documents.azure.com:443/;AccountKey=VvzlQECZtYzfEFvvEnHcqQkrcE39FgxXwM5TuGfxFx2VCxgovcPZwBVSxsgyJbsTaEVVzQvNWgq9wPJszzZyVg==;";
        private static readonly string _database_name = "appdb";
        private static readonly string _container_name = "activity";
        
        static void Main(string[] args)
        {

            FileStream _fs = new FileStream(System.Environment.CurrentDirectory +  @"\data\QueryResult.json", FileMode.Open, FileAccess.Read);
            StreamReader _reader = new StreamReader(_fs);
            JsonTextReader _json_reader = new JsonTextReader(_reader);
            
            CosmosClient _client = new CosmosClient(_connection_string);
            Container _container = _client.GetContainer(_database_name, _container_name);

            while (_json_reader.Read())
            {
                if (_json_reader.TokenType==JsonToken.StartObject)
                {
                    JObject _object = JObject.Load(_json_reader);
                    Activity _activity = _object.ToObject<Activity>();
                    _activity.id = Guid.NewGuid().ToString();
                    _container.CreateItemAsync<Activity>(_activity, new PartitionKey(_activity.Operationname)).GetAwaiter().GetResult();
                    Console.WriteLine($"Adding item {_activity.Correlationid}");
                }
            }

            Console.WriteLine("Written data to Azure Cosmos DB");
            Console.ReadKey();
        }
    }
}
