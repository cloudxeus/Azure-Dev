using System;
using System.Text;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzureFunction_ServiceBus_Topic
{
    public static class GetMessages
    {
        [FunctionName("GetMessages")]
        public static void Run([ServiceBusTrigger("apptopic", "SubscriptionA", Connection = "servicebus-connection")]Message mySbMsg, ILogger log)
        {
            log.LogInformation(Encoding.UTF8.GetString(mySbMsg.Body));
        }
    }
}
