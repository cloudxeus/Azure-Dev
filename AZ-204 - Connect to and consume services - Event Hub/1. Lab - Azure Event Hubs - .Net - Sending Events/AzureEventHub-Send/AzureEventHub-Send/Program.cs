using Azure.Messaging.EventHubs.Producer;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureEventHub_Send
{
    class Program
    {
        private static string connection_string = "Endpoint=sb://appnamespace1000.servicebus.windows.net/;SharedAccessKeyName=Send;SharedAccessKey=zzzSagu08gp1Oo5mOYC8vKkupROROqpnafyIBoWkyZQ=;EntityPath=apphub";
        static void Main(string[] args)
        {

            EventHubProducerClient _client = new EventHubProducerClient(connection_string);

            EventDataBatch _batch = _client.CreateBatchAsync().GetAwaiter().GetResult();

            List<Order> _orders = new List<Order>()
            {
                new Order() {OrderID="O1",Quantity=10,UnitPrice=9.99m,DiscountCategory="Tier 1" },
                new Order() {OrderID="O2",Quantity=15,UnitPrice=10.99m,DiscountCategory="Tier 2" },
                new Order() {OrderID="O3",Quantity=20,UnitPrice=11.99m,DiscountCategory="Tier 3" },
                new Order() {OrderID="O4",Quantity=25,UnitPrice=12.99m,DiscountCategory="Tier 1" },
                new Order() {OrderID="O5",Quantity=30,UnitPrice=13.99m,DiscountCategory="Tier 2" }
            };

            foreach (Order _order in _orders)
                _batch.TryAdd(new Azure.Messaging.EventHubs.EventData(Encoding.UTF8.GetBytes(_order.ToString())));

            _client.SendAsync(_batch).GetAwaiter().GetResult();
            Console.WriteLine("Batch of events sent");
        }
    }
}
