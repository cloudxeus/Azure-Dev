using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzureFunction_StorageQueue
{
    public static class QueueMessage
    {
        [FunctionName("GetMessages")]
        public static void Run([QueueTrigger("appqueue", Connection = "storage-connectionstring")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
