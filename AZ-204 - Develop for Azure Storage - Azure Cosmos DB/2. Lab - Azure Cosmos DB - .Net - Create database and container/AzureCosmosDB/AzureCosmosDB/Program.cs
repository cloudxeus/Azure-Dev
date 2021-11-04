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
        private static readonly string _partition_key = "/courseid";

        static async Task Main(string[] args)
        {
            CosmosClient _cosmosclient = new CosmosClient(_connection_string);
            // Creating a database

            await _cosmosclient.CreateDatabaseAsync(_database_name);
            Console.WriteLine("Database created");
            // Creating a container in the database

            Database _cosmos_db = _cosmosclient.GetDatabase(_database_name);
            await _cosmos_db.CreateContainerAsync(_container_name, _partition_key);
            Console.WriteLine("Container created");
            Console.ReadKey();

        }
    }
}
