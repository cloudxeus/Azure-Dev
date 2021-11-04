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
            CosmosClient _client = new CosmosClient(_connection_string, new CosmosClientOptions() { AllowBulkExecution = true });

            Container _container = _client.GetContainer(_database_name, _container_name);

            string _id = "2";
            string _partition_key = "Course0002";

            await _container.DeleteItemAsync<Course>(_id, new PartitionKey(_partition_key));

            Console.WriteLine("Item has been deleted");

            Console.ReadKey();

        }


    }
}
