using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Processor;
using Azure.Storage.Blobs;
using System;
using System.Text;
using System.Threading.Tasks;

namespace AzureEventHub_Processor
{
    class Program
    {
        private static string connection_string = "Endpoint=sb://appnamespace1000.servicebus.windows.net/;SharedAccessKeyName=Listen;SharedAccessKey=7Ud19ItrlKvE0t7vgJemUv/lfpLzXtdwqRkt2VWcTc0=;EntityPath=apphub";
        private static string consumer_group = "$Default";
        private static string storage_account_connection = "DefaultEndpointsProtocol=https;AccountName=appstore2000;AccountKey=8pBdEmCXm/Gv8iZ1LoC0+SZVkzWSq81C3/Quzr9rYk+xigMs4t5mBYC08cptZnR4UyLCHYLlamVfo8IV99GvbA==;EndpointSuffix=core.windows.net";
        private static string container_name = "eventhub";
        static async Task Main(string[] args)
        {
            
            BlobContainerClient _container_client = new BlobContainerClient(storage_account_connection, container_name);

            EventProcessorClient _processor = new EventProcessorClient(_container_client, consumer_group, connection_string);

            _processor.ProcessErrorAsync += OurErrorHandler;
            _processor.ProcessEventAsync+= OurEventsHandler;

            await _processor.StartProcessingAsync();

            // Wait for 30 seconds for the events to be processed
            await Task.Delay(TimeSpan.FromSeconds(30));


            Console.ReadKey();
        }

        static async Task OurEventsHandler(ProcessEventArgs eventArgs)
        {
            Console.WriteLine($"Sequence number {eventArgs.Data.SequenceNumber}");
            Console.WriteLine(Encoding.UTF8.GetString(eventArgs.Data.EventBody));
            await eventArgs.UpdateCheckpointAsync(eventArgs.CancellationToken);
        }

        static Task OurErrorHandler(ProcessErrorEventArgs eventArgs)
        {
            Console.WriteLine(eventArgs.Exception.Message);
            return Task.CompletedTask;
        }
    }
}
