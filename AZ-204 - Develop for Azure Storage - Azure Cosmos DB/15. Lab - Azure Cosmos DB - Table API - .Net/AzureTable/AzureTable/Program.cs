using Microsoft.Azure.Cosmos.Table;
using System;

namespace AzureTable
{
    class Program
    {
        private static string connection_string = "DefaultEndpointsProtocol=https;AccountName=apptable100;AccountKey=j4Rnbv92mayF7kHtTzvdl3CKO5Tk0Vodjw65ejrSp4a84KLWpn4rELvRxBjRg7aWDJprYYHbaJWRLb7xmkEkWw==;TableEndpoint=https://apptable100.table.cosmos.azure.com:443/;";
        private static string table_name = "customer";
        static void Main(string[] args)
        {
            CloudStorageAccount _account = CloudStorageAccount.Parse(connection_string);

            CloudTableClient _client = _account.CreateCloudTableClient();

            CloudTable _table = _client.GetTableReference(table_name);

            Customer _customer = new Customer("UserA", "Chicago");
            _customer.customerid = "C1";

            TableOperation _operation = TableOperation.Insert(_customer);

            TableResult _result = _table.Execute(_operation);

            Console.WriteLine("Customer Entity Added");
            Console.ReadKey();
        }
    }
}
