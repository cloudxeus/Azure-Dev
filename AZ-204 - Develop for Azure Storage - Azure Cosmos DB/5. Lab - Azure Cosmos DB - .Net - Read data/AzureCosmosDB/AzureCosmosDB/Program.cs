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

            Container _container = _client.GetContainer(_database_name, _container_name);

            string _query = "SELECT * FROM c WHERE c.courseid='Course0002'";

            QueryDefinition _definition = new QueryDefinition(_query);

            FeedIterator<Course> _iterator = _container.GetItemQueryIterator<Course>(_definition);

            while (_iterator.HasMoreResults)
            {
                FeedResponse<Course> _response = await _iterator.ReadNextAsync();
                foreach (Course _course in _response)
                {
                    Console.WriteLine($"Id is {_course.id}");
                    Console.WriteLine($"Course id is {_course.courseid}");
                    Console.WriteLine($"Course name is {_course.coursename}");
                    Console.WriteLine($"Course rating is {_course.rating}");
                }
            }

            Console.ReadKey();
        }


    }
}
