using Microsoft.Azure.Cosmos;
using System;
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
            CosmosClient _client = new CosmosClient(_connection_string);

            Course _course = new Course()
            {
                id = "1",
                courseid = "C00010",
                coursename = "AZ-204",
                rating = 4.5m
            };

            Container _container = _client.GetContainer(_database_name, _container_name);

            await _container.CreateItemAsync<Course>(_course, new PartitionKey(_course.courseid));

            Console.WriteLine("Item is created");
            Console.ReadKey();

        }
    }
}
