using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
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

            
            if (_client.Exists())
            {
                PeekedMessage[] _messages=_client.PeekMessages(2);    
                foreach(PeekedMessage _message in _messages)
                {
                    Console.WriteLine($"Message ID is {_message.MessageId}");
                    Console.WriteLine($"Message was inserted on {_message.InsertedOn}");
                    Console.WriteLine($"Message body is {_message.Body.ToString()}");
                }
            }

            
            Console.ReadKey();
        }
    }
}
