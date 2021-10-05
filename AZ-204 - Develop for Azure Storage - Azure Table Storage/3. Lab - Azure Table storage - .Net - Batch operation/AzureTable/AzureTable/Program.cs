using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;

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

            CloudTable _table = _table_client.GetTableReference(table_name);

            List<Customer> _customers = new List<Customer>()
            {
            new Customer("UserB", "Chicago", "C2"),
            new Customer("UserC", "Chicago", "C3"),
            new Customer("UserD", "Chicago", "C4"),
            };

            TableBatchOperation _operation = new TableBatchOperation();
            foreach (Customer _customer in _customers)
                _operation.Insert(_customer);


            TableBatchResult _result = _table.ExecuteBatch(_operation);

            Console.WriteLine("Entities are added");

            Console.ReadKey();
        }
    }
}
