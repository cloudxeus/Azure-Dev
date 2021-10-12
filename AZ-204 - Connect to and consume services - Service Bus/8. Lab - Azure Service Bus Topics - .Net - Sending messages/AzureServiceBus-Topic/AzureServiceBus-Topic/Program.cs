using Azure.Messaging.ServiceBus;
using System;
using System.Collections.Generic;

namespace AzureServiceBus_Topic
{
    class Program
    {
        private static string connection_string = "Endpoint=sb://appnamespace10001.servicebus.windows.net/;SharedAccessKeyName=Send;SharedAccessKey=uwdqKaGZBPXa7ekx4GuEhcNzrb56YM2vR5YzxwJj/E0=;EntityPath=apptopic";
        private static string topic_name = "apptopic";

        static void Main(string[] args)
        {
            List<Order> _orders = new List<Order>()
            {
                new Order() {OrderID="O1",Quantity=10,UnitPrice=9.99m},
                new Order() {OrderID="O2",Quantity=15,UnitPrice=10.99m },
                new Order() {OrderID="O3",Quantity=20,UnitPrice=11.99m},
                new Order() {OrderID="O4",Quantity=25,UnitPrice=12.99m},
                new Order() {OrderID="O5",Quantity=30,UnitPrice=13.99m }
            };

            ServiceBusClient _client = new ServiceBusClient(connection_string);
            ServiceBusSender _sender = _client.CreateSender(topic_name);

            foreach (Order _order in _orders)
            {
                ServiceBusMessage _message = new ServiceBusMessage(_order.ToString());
                _sender.SendMessageAsync(_message).GetAwaiter().GetResult();
            }

            Console.WriteLine("Messages sent");
            Console.ReadKey();
        }
    }
}
