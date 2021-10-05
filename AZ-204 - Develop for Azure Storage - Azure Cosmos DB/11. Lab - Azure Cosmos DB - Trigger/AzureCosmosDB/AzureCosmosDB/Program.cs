using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureCosmosDB
{
    class Program
    {
        
        private static readonly string _connection_string = "AccountEndpoint=https://demoaccount1000.documents.azure.com:443/;AccountKey=bXV8G72jYdI4HDwalifWkRuVRUsV45rtTEX0iwIsstaQu8kR7RhKDp5ibD1o8VX4UYCQARLwAfFqi5gPYnvPDg==;";
        private static readonly string _database_name = "appdb";
        private static readonly string _container_name = "course";
        
        static void Main(string[] args)
        {
            CosmosClient _cosmosclient = new CosmosClient(_connection_string, new CosmosClientOptions());

            Container _container = _cosmosclient.GetContainer(_database_name, _container_name);


            Course _course = new Course() { id = "Course0010", coursename = "AZ-204 Developing Azure solutions", rating = 4.5m };

            _container.CreateItemAsync(_course, null,new ItemRequestOptions { PreTriggers = new List<string> { "AddTimestamp" } }).GetAwaiter().GetResult();

            Console.WriteLine("Item created");
            Console.ReadKey();
        }
    }
}
