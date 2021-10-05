using System;
using System.Collections.Generic;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Changefeed
{
    public static class DetectChange
    {
        [FunctionName("ReadChange")]
        public static void Run([CosmosDBTrigger(
            databaseName: "appdb",
            collectionName: "course",
            ConnectionStringSetting = "cosmosdbstring",
            LeaseCollectionName = "leases",CreateLeaseCollectionIfNotExists = true)]IReadOnlyList<Document> input, ILogger log)
        {
            if (input != null && input.Count > 0)
            {
                foreach (var _course in input)
                {
                    log.LogInformation($"Course id {_course.Id}");
                    log.LogInformation($"Course id {_course.GetPropertyValue<string>("couseid")}");
                    log.LogInformation($"Course name {_course.GetPropertyValue<string>("coursename")}");
                    log.LogInformation($"Course name {_course.GetPropertyValue<decimal>("rating")}");
                }
            }
        }
    }
}
