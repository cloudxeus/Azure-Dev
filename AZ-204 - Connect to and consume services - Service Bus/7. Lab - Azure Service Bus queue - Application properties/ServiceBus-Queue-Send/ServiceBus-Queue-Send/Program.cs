using Azure.Messaging.ServiceBus;
using System;
using System.Collections.Generic;

namespace ServiceBus_Queue_Send
{
    class Program
    {
        private static string connection_string = "Endpoint=sb://appnamespace10001.servicebus.windows.net/;SharedAccessKeyName=Send;SharedAccessKey=AEpN9CVPserwS6EhDoJb/6ITQjb+Dx9txN29zOhLtP8=;EntityPath=newqueue";
        private static string queue_name= "newqueue";
        static void Main(string[] args)
        {

            Order _order = new Order() { OrderID = "O1", Quantity = 10, UnitPrice = 9.99m };
                            
            ServiceBusClient _client = new ServiceBusClient(connection_string);
            ServiceBusSender _sender = _client.CreateSender(queue_name);

            ServiceBusMessage _message = new ServiceBusMessage(_order.ToString());
            _message.ApplicationProperties.Add("Department", "HR");
            _sender.SendMessageAsync(_message).GetAwaiter().GetResult();
                           
            Console.WriteLine("Message sent");
            Console.ReadKey();
        }
    }
}
