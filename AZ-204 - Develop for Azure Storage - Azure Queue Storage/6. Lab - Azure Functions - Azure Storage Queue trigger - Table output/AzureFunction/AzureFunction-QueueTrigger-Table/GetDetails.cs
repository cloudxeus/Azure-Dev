using System;
using System.Text.Json;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json.Linq;

namespace AzureFunction_QueueTrigger_Table
{
    public static class GetDetails
    {
        [FunctionName("QueueTable")]
        [return: Table("Orders", Connection = "stoarge-connection")]
        public static Order Run([QueueTrigger("appqueue", Connection = "stoarge-connection")] JObject myQueueItem,           
            ILogger log)
        {

            Order _order = new Order()
            {
                PartitionKey = myQueueItem["Category"].ToString(),
                RowKey= myQueueItem["OrderID"].ToString(),
                Quantity= Convert.ToInt32(myQueueItem["Quantity"]),
                UnitPrice= Convert.ToDecimal(myQueueItem["UnitPrice"])
            };

            log.LogInformation("Order written to table");

            return _order;

        }
    }
}
