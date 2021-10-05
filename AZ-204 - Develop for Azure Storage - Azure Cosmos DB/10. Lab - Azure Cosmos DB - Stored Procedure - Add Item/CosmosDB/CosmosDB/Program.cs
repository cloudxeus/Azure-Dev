using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CosmosDB
{
    class Program
    {
        private static readonly string _connection_string = "AccountEndpoint=https://appaccount100.documents.azure.com:443/;AccountKey=VvzlQECZtYzfEFvvEnHcqQkrcE39FgxXwM5TuGfxFx2VCxgovcPZwBVSxsgyJbsTaEVVzQvNWgq9wPJszzZyVg==;";
        private static readonly string _database_name = "appdb";
        private static readonly string _container_name = "course";
        
        static void Main(string[] args)
        {

            CosmosClient _client = new CosmosClient(_connection_string,new CosmosClientOptions() { AllowBulkExecution=true});

            Container _container=_client.GetContainer(_database_name, _container_name);

            dynamic[] _items = new dynamic[]
            {
                new {id="5",courseid="Course0007",coursename="AZ-500 Azure Security",rating=4.4m}
            };

            string _output=_container.Scripts.ExecuteStoredProcedureAsync<string>("Additem", new PartitionKey("Course0007"), new[] { _items }).GetAwaiter().GetResult();

            Console.WriteLine(_output);
            Console.ReadKey();
        }
    }
}
