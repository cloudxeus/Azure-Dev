using Microsoft.Azure.Cosmos.Table;
using System;

namespace AzureTable
{
    class Program
    {
        private static string connection_string = "DefaultEndpointsProtocol=https;AccountName=newstore100000;AccountKey=sLc9uOkHloYRuuW3SBI8sFP4f1IzBLbZsrYH/XgDE6EBooz3bHG5CtO0MCga/goWN9yhBhUS5OfZeqOyM/CZNQ==;EndpointSuffix=core.windows.net";
        private static string table_name = "Customer";

        static void Main(string[] args)
        {
            CloudStorageAccount _account = CloudStorageAccount.Parse(connection_string);

            CloudTableClient _table_client = _account.CreateCloudTableClient();

            CloudTable _table=_table_client.GetTableReference(table_name);

            Customer _customer = new Customer("UserA", "Chicago", "C1");

            TableOperation _operation = TableOperation.Insert(_customer);

            TableResult _result=_table.Execute(_operation);

            Console.WriteLine("Entity is added");

            Console.ReadKey();
        }
    }
}
