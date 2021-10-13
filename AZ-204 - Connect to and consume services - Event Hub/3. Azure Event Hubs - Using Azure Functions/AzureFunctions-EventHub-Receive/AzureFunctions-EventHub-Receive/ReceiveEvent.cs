using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.EventHubs;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AzureFunctions_EventHub_Receive
{
    public static class ReceiveEvent
    {
        [FunctionName("GetEvents")]
        public static async Task Run([EventHubTrigger("apphub", Connection = "eventhub-connection-string")] EventData[] events, ILogger log)
        {
            var exceptions = new List<Exception>();

            foreach (EventData eventData in events)
            {
                try
                {
                    log.LogInformation(Encoding.UTF8.GetString(eventData.Body));
                    log.LogInformation($"Sequence number {eventData.SystemProperties.SequenceNumber}");
                    log.LogInformation($"Offset {eventData.SystemProperties.Offset}");
                    await Task.Yield();
                }
                catch (Exception e)
                {
                    // We need to keep processing the rest of the batch - capture this exception and continue.
                    // Also, consider capturing details of the message that failed processing so it can be processed again later.
                    exceptions.Add(e);
                }
            }

            // Once processing of the batch is complete, if any messages in the batch failed processing throw an exception so that there is a record of the failure.

            if (exceptions.Count > 1)
                throw new AggregateException(exceptions);

            if (exceptions.Count == 1)
                throw exceptions.Single();
        }
    }
}
