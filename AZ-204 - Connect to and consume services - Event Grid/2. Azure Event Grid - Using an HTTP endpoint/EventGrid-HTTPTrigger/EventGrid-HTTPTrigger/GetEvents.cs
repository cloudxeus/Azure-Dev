using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.EventGrid;
using Microsoft.Azure.EventGrid.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EventGrid_HTTPTrigger
{
    public static class GetEvents
    {
        [FunctionName("GetEvent")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            // First we need to get the request body
            string _request = new StreamReader(req.Body).ReadToEnd();

            log.LogInformation($"Received request body {_request}");

            EventGridSubscriber _subscriber = new EventGridSubscriber();

            EventGridEvent[] _events = _subscriber.DeserializeEventGridEvents(_request);

            foreach(EventGridEvent _event in _events)
            {
                if (_event.Data is SubscriptionValidationEventData)
                {
                    SubscriptionValidationEventData _data = (SubscriptionValidationEventData)_event.Data;
                    log.LogInformation($"Validation code {_data.ValidationCode}");
                    log.LogInformation($"Validation URL {_data.ValidationUrl}");

                    SubscriptionValidationResponse _response = new SubscriptionValidationResponse()
                    {
                        ValidationResponse = _data.ValidationCode
                    };
                    return new OkObjectResult(_response);

                }
            }

            return new OkObjectResult(string.Empty);
        }
    }
}

