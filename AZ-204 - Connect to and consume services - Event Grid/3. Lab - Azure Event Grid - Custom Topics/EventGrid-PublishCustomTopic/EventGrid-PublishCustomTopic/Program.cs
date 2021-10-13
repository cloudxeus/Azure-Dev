using Azure.Messaging.EventGrid;
using System;
using Azure;
using System.Collections.Generic;
using System.Text.Json;

namespace EventGrid_PublishCustomTopic
{
    class Program
    {
        private static Uri topic_endpoint;
        private static AzureKeyCredential topic_accesskey;
        
        static void Main(string[] args)
        {
            topic_endpoint = new Uri("https://apptopic.northeurope-1.eventgrid.azure.net/api/events");
            topic_accesskey = new AzureKeyCredential("zGKpuwQ0pmoiwZGE+x/qHFdbgqu/oGN89Tuk7to09RI=");

            EventGridPublisherClient _client = new EventGridPublisherClient(topic_endpoint, topic_accesskey);

            Order _order = new Order()
            {
                OrderID = "O1",
                UnitPrice=9.99m,
                Quantity=100
            };

            List<EventGridEvent> _eventsList = new List<EventGridEvent>()
            {
                new EventGridEvent("Placing new order","app.neworder","1.0",JsonSerializer.Serialize(_order))
            };

            _client.SendEvents(_eventsList);
            Console.WriteLine("Sending Event");
            Console.ReadKey();
        }
    }
}
