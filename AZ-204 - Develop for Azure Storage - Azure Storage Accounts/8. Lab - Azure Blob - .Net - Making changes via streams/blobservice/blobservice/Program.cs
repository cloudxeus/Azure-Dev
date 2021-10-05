using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace blobservice
{
    class Program
    {
        private static string _container_name = "data";
        private static string _connection_string = "DefaultEndpointsProtocol=https;AccountName=appstore2000;AccountKey=viTfT8x3Zd3KPyY4NNaKHWH1J5j0ROxMn+gqh+j93SHfSDWx7ultVdqVzHCHLvz/p0NfMvyYlfqlG4YuOqP72w==;EndpointSuffix=core.windows.net";
        private static string _blob_name = "Program.cs";
        
        static void Main(string[] args)
        {
            BlobServiceClient _service_client = new BlobServiceClient(_connection_string);

            BlobContainerClient _container_client = _service_client.GetBlobContainerClient(_container_name);

            BlobClient _blob_client = _container_client.GetBlobClient(_blob_name);

            MemoryStream _memory = new MemoryStream();

            _blob_client.DownloadTo(_memory);
            _memory.Position = 0;
            StreamReader _reader = new StreamReader(_memory);
            Console.WriteLine(_reader.ReadToEnd());

            StreamWriter _writer = new StreamWriter(_memory);
            _writer.Write("This is a change");
            _writer.Flush();

            _memory.Position = 0;
            _blob_client.Upload(_memory, true);

            Console.WriteLine("Change made");
            Console.ReadKey();
        }

       
    }
}
