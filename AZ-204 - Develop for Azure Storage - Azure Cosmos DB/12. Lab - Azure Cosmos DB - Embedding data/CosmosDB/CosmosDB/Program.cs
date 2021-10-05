using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;

namespace CosmosDB
{
    class Program
    {
        private static readonly string _connection_string = "AccountEndpoint=https://appaccount100.documents.azure.com:443/;AccountKey=VvzlQECZtYzfEFvvEnHcqQkrcE39FgxXwM5TuGfxFx2VCxgovcPZwBVSxsgyJbsTaEVVzQvNWgq9wPJszzZyVg==;";
        private static readonly string _database_name = "appdb";
        private static readonly string _container_name = "course";
        
        static void Main(string[] args)
        {

            CosmosClient _client = new CosmosClient(_connection_string);

            Course _course = new Course()
            {
                id = "1",
                courseid = "C00010",
                coursename = "AZ-204",
                rating = 4.5m,
                orders=new List<Order>() { new Order() { orderid="O2",price=50},
                new Order() { orderid="O3",price=80}}
            };

            Container _container=_client.GetContainer(_database_name, _container_name);

            _container.CreateItemAsync<Course>(_course, new PartitionKey(_course.courseid)).GetAwaiter().GetResult();

            Console.WriteLine("Item is created");
            Console.ReadKey();
        }
    }
}
