using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;

namespace AzureTable
{
    class Program
    {
        private static string connection_string = "DefaultEndpointsProtocol=https;AccountName=newstore100000;AccountKey=sLc9uOkHloYRuuW3SBI8sFP4f1IzBLbZsrYH/XgDE6EBooz3bHG5CtO0MCga/goWN9yhBhUS5OfZeqOyM/CZNQ==;EndpointSuffix=core.windows.net";
        private static string table_name = "Customer";
        private static string partition_key = "Chicago";
        private static string row_key = "C2";

        static void Main(string[] args)
        {
            CloudStorageAccount _account = CloudStorageAccount.Parse(connection_string);

            CloudTableClient _table_client = _account.CreateCloudTableClient();

            CloudTable _table = _table_client.GetTableReference(table_name);

            TableOperation _operation = TableOperation.Retrieve<Customer>(partition_key, row_key);

            TableResult _result = _table.Execute(_operation);
            Customer _customer = _result.Result as Customer;

            TableOperation _delete_operation = TableOperation.Delete(_customer);

            TableResult _delete_result = _table.Execute(_delete_operation);

            Console.WriteLine("Customer information is deleted");
            
            Console.ReadKey();
        }
    }
}
