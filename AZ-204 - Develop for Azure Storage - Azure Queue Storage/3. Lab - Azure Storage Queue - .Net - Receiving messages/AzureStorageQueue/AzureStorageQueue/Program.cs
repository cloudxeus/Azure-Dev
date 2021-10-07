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
                QueueMessage _queue_message = _client.ReceiveMessage();

                Console.WriteLine(_queue_message.Body.ToString());

                _client.DeleteMessage(_queue_message.MessageId, _queue_message.PopReceipt);

                Console.WriteLine("Message deleted");
            }

            
            Console.ReadKey();
        }
    }
}
