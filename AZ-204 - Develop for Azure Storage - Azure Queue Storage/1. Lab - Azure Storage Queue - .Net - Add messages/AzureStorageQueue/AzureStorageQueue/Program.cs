using Azure.Storage.Queues;
using System;

namespace AzureStorageQueue
{
    class Program
    {

        private static string storage_connection_string = "DefaultEndpointsProtocol=https;AccountName=newstore100000;AccountKey=sLc9uOkHloYRuuW3SBI8sFP4f1IzBLbZsrYH/XgDE6EBooz3bHG5CtO0MCga/goWN9yhBhUS5OfZeqOyM/CZNQ==;EndpointSuffix=core.windows.net";
        private static string queue_name = "appqueue";
        static void Main(string[] args)
        {
            QueueClient _client = new QueueClient(storage_connection_string,queue_name);

            string _message;
            if (_client.Exists())
            {
                for (int i = 0; i < 5; i++)
                {
                    _message = $"This is test message {i}";
                    _client.SendMessage(_message);
                }
            }

            Console.WriteLine("All the messages have been sent");
            Console.ReadKey();
        }
    }
}
