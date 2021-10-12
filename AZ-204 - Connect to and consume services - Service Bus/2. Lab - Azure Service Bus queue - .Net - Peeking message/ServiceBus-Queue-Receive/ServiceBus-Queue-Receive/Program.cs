using Azure.Messaging.ServiceBus;
using System;

namespace ServiceBus_Queue_Receive
{
    class Program
    {
        private static string connection_string = "Endpoint=sb://appnamespace10001.servicebus.windows.net/;SharedAccessKeyName=Listen;SharedAccessKey=eGaTvTJ5qq3pR1x2vdZzhPDrFXKbpDoLOr5R3YxfNn4=;EntityPath=appqueue";
        private static string queue_name = "appqueue";
        static void Main(string[] args)
        {
            ServiceBusClient _client = new ServiceBusClient(connection_string);

            ServiceBusReceiver _receiver = _client.CreateReceiver(queue_name,new ServiceBusReceiverOptions() {ReceiveMode= ServiceBusReceiveMode.PeekLock });

            ServiceBusReceivedMessage _message= _receiver.ReceiveMessageAsync().GetAwaiter().GetResult();

            Console.WriteLine(_message.Body);
            Console.WriteLine($"The Sequence number is {_message.SequenceNumber}");

        }
    }
}
