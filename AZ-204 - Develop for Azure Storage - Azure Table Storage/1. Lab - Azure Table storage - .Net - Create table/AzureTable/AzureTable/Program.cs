using Microsoft.Azure.Cosmos.Table;
using System;

namespace AzureTable
{
    class Program
    {
        private static string connection_string = "DefaultEndpointsProtocol=https;AccountName=appstore2000;AccountKey=8pBdEmCXm/Gv8iZ1LoC0+SZVkzWSq81C3/Quzr9rYk+xigMs4t5mBYC08cptZnR4UyLCHYLlamVfo8IV99GvbA==;EndpointSuffix=core.windows.net";
        private static string table_name = "customer";
        static void Main(string[] args)
        {
            CloudStorageAccount _account = CloudStorageAccount.Parse(connection_string);

            CloudTableClient _client = _account.CreateCloudTableClient();

            CloudTable _table = _client.GetTableReference(table_name);
            _table.CreateIfNotExists();

            Console.WriteLine("Table created");
            Console.ReadKey();
        }
    }
}
