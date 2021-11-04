using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureCosmosDB
{
    class Program
    {
        
        private static readonly string _connection_string = "AccountEndpoint=https://appaccount20030.documents.azure.com:443/;AccountKey=ZCFP0FkFCsrBQZdjXDVUPcUcg2MysLj0Mb1Hh1N8RrFDlFI118YrMdip5M9ZlZQFJR2DtGArO0D7mLeR0dBJkg==;";
        private static readonly string _database_name = "appdb";
        private static readonly string _container_name = "course";
        
        static async Task Main(string[] args)
        {
            CosmosClient _cosmosclient = new CosmosClient(_connection_string, new CosmosClientOptions());

            Container _container = _cosmosclient.GetContainer(_database_name, _container_name);


            Course _course = new Course() { id = "Course0010", coursename = "AZ-204 Developing Azure solutions", rating = 4.5m };

            await _container.CreateItemAsync(_course, null,new ItemRequestOptions { PreTriggers = new List<string> { "AddTimestamp" } });

            Console.WriteLine("Item created");
            Console.ReadKey();
        }
    }
}
