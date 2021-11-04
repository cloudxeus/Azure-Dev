using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureCosmosDB
{
    class Program
    {
        private static readonly string _connection_string = "AccountEndpoint=https://appaccount20030.documents.azure.com:443/;AccountKey=ZCFP0FkFCsrBQZdjXDVUPcUcg2MysLj0Mb1Hh1N8RrFDlFI118YrMdip5M9ZlZQFJR2DtGArO0D7mLeR0dBJkg==;";
        private static readonly string _database_name = "appdb";
        private static readonly string _container_name = "course";

        static async Task Main(string[] args)
        {
            CosmosClient _client = new CosmosClient(_connection_string, new CosmosClientOptions() { AllowBulkExecution = true });

            List<Course> _lst = new List<Course>()
            {
            new Course() { id="1",courseid="Course0001", coursename = "AZ-204 Developing Azure solutions", rating = 4.5m },
            new Course() { id="2",courseid="Course0002", coursename = "AZ-303 Architecting Azure solutions", rating = 4.6m },
            new Course() { id="3", courseid="Course0003", coursename = "DP-203 Azure Data Engineer", rating = 4.7m },
            new Course() { id="4",courseid="Course0004", coursename = "AZ-900 Azure Fundamentals", rating = 4.6m },
            new Course() { id="5",courseid="Course0005", coursename = "AZ-104 Azure Administrator", rating = 4.5m }};

            Container _container = _client.GetContainer(_database_name, _container_name);

            List<Task> _tasks = new List<Task>();

            foreach (Course _course in _lst)
                _tasks.Add(_container.CreateItemAsync<Course>(_course, new PartitionKey(_course.courseid)));

            await Task.WhenAll(_tasks);

            Console.WriteLine("Bulk insert completed");
            Console.ReadKey();

        }
    }
}
