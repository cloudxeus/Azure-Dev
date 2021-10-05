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


            Console.WriteLine($"The customer name is {_customer.customername}");
            Console.WriteLine($"The customer city is {_customer.PartitionKey}");
            Console.WriteLine($"The customer id is {_customer.RowKey}");

            Console.ReadKey();
        }
    }
}
