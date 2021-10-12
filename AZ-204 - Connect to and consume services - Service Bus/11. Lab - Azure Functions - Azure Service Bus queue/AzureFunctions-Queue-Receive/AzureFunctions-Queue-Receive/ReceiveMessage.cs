using System;
using System.Text;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzureFunctions_Queue_Receive
{
    public static class ReceiveMessage
    {
        [FunctionName("GetMessages")]
        public static void Run([ServiceBusTrigger("appqueue", Connection = "servicebus-connection")]Message myQueueItem, ILogger log)
        {
            log.LogInformation(Encoding.UTF8.GetString(myQueueItem.Body));

        }
    }
}
