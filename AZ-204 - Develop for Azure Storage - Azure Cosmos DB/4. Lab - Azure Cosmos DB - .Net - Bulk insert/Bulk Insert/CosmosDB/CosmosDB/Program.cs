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

            List<Course> _lst = new List<Course>()
            {
            new Course() { id="1",courseid="Course0001", coursename = "AZ-204 Developing Azure solutions", rating = 4.5m },
            new Course() { id="2",courseid="Course0002", coursename = "AZ-303 Architecting Azure solutions", rating = 4.6m },
            new Course() { id="3", courseid="Course0003", coursename = "DP-203 Azure Data Engineer", rating = 4.7m },
            new Course() { id="4",courseid="Course0004", coursename = "AZ-900 Azure Fundamentals", rating = 4.6m },
            new Course() { id="5",courseid="Course0005", coursename = "AZ-104 Azure Administrator", rating = 4.5m }};

            Container _container=_client.GetContainer(_database_name, _container_name);

            List<Task> _tasks = new List<Task>();

            foreach (Course _course in _lst)
                _tasks.Add(_container.CreateItemAsync<Course>(_course, new PartitionKey(_course.courseid)));

            Task.WhenAll(_tasks).GetAwaiter().GetResult();

            Console.WriteLine("Bulk insert completed");
            Console.ReadKey();
        }
    }
}
