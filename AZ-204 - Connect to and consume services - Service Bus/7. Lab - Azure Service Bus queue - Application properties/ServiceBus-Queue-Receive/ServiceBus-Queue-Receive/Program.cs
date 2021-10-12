using Azure.Messaging.ServiceBus;
using System;

namespace ServiceBus_Queue_Receive
{
    class Program
    {
        private static string connection_string = "Endpoint=sb://appnamespace10001.servicebus.windows.net/;SharedAccessKeyName=Listen;SharedAccessKey=e+iLjSD2oaurr2HEhq7kBzyWBj3qqVNc6w3XdWCglY0=;EntityPath=newqueue";
        private static string queue_name = "newqueue";
        static void Main(string[] args)
        {
            ServiceBusClient _client = new ServiceBusClient(connection_string);

            ServiceBusReceiver _receiver = _client.CreateReceiver(queue_name,new ServiceBusReceiverOptions() {ReceiveMode= ServiceBusReceiveMode.PeekLock });

            ServiceBusReceivedMessage _message= _receiver.ReceiveMessageAsync().GetAwaiter().GetResult();

            Console.WriteLine(_message.Body);
            foreach (var _key in _message.ApplicationProperties.Keys)
            {
                Console.WriteLine(_key.ToString());
                Console.WriteLine(_message.ApplicationProperties[_key].ToString());
            }

        }
    }
}
