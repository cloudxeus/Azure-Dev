using Azure.Storage.Queues;
using System;

namespace StorageQueue
{
    class Program
    {
        private static string storage_connection_string = "DefaultEndpointsProtocol=https;AccountName=appstore2000;AccountKey=8pBdEmCXm/Gv8iZ1LoC0+SZVkzWSq81C3/Quzr9rYk+xigMs4t5mBYC08cptZnR4UyLCHYLlamVfo8IV99GvbA==;EndpointSuffix=core.windows.net";
        private static string queue_name = "appqueue";
        static void Main(string[] args)
        {
            QueueClient _queueclient = new QueueClient(storage_connection_string, queue_name);

            string _message,_tmp_message;
            if (_queueclient.Exists())
            {
                for (int i = 0; i <= 5; i++)
                {

                    _tmp_message = $"This is test message {i}";
                    var txtbytes = System.Text.Encoding.UTF8.GetBytes(_tmp_message);
                    _message = System.Convert.ToBase64String(txtbytes);
                    _queueclient.SendMessage(_message);
                }
                Console.WriteLine("Messages added");
            }

            Console.ReadKey();
        }
    }
}
