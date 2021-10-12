using Azure.Messaging.ServiceBus;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceBus_Queue_Receive
{
    class Program
    {
        private static string connection_string = "Endpoint=sb://appnamespace10001.servicebus.windows.net/;SharedAccessKeyName=Listen;SharedAccessKey=eGaTvTJ5qq3pR1x2vdZzhPDrFXKbpDoLOr5R3YxfNn4=;EntityPath=appqueue/$DeadLetterQueue";
        private static string dead_letter_queue_name = "appqueue/$DeadLetterQueue";

        static async Task Main(string[] args)
        {
            ServiceBusClient _client = new ServiceBusClient(connection_string);

            ServiceBusReceiver _receiver = _client.CreateReceiver(dead_letter_queue_name, new ServiceBusReceiverOptions() {ReceiveMode= ServiceBusReceiveMode.PeekLock});

            ServiceBusReceivedMessage _message = _receiver.ReceiveMessageAsync().GetAwaiter().GetResult();

            Console.WriteLine($"Dead Letter Reason {_message.DeadLetterReason}");
            Console.WriteLine($"Dead Letter Description {_message.DeadLetterErrorDescription}");
            Console.WriteLine(_message.Body);
                
            

        }
    }
}
