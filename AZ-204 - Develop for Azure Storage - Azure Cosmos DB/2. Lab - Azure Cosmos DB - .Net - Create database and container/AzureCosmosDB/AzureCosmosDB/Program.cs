using Microsoft.Azure.Cosmos;
using System;

namespace AzureCosmosDB
{
    class Program
    {
        private static readonly string _connection_string = "AccountEndpoint=https://demoaccount1000.documents.azure.com:443/;AccountKey=bXV8G72jYdI4HDwalifWkRuVRUsV45rtTEX0iwIsstaQu8kR7RhKDp5ibD1o8VX4UYCQARLwAfFqi5gPYnvPDg==;";
        private static readonly string _database_name = "appdb";
        private static readonly string _container_name = "course";
        private static readonly string _partition_key = "/coursename";
        static void Main(string[] args)
        {
            CosmosClient _cosmosclient=new CosmosClient(_connection_string);
            // Creating a database
            
            _cosmosclient.CreateDatabaseAsync(_database_name).GetAwaiter().GetResult();
            Console.WriteLine("Database created");
            // Creating a container in the database
            
            Database _cosmos_db=_cosmosclient.GetDatabase(_database_name);
            _cosmos_db.CreateContainerAsync(_container_name, _partition_key).GetAwaiter().GetResult();
            Console.WriteLine("Container created");
            Console.ReadKey();
        }
    }
}
