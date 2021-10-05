using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;

namespace blobservice
{
    class Program
    {
        private static string _container_name = "data";
        private static string _connection_string = "DefaultEndpointsProtocol=https;AccountName=appstore2000;AccountKey=viTfT8x3Zd3KPyY4NNaKHWH1J5j0ROxMn+gqh+j93SHfSDWx7ultVdqVzHCHLvz/p0NfMvyYlfqlG4YuOqP72w==;EndpointSuffix=core.windows.net";
        private static string _blob_name = "Program.cs";
        private static string _location = "C:\\tmp\\Program.cs";
        static void Main(string[] args)
        {
            BlobServiceClient _service_client = new BlobServiceClient(_connection_string);

            BlobContainerClient _container_client = _service_client.GetBlobContainerClient(_container_name);

            BlobClient _blob_client = _container_client.GetBlobClient(_blob_name);

            BlobProperties _properties = _blob_client.GetProperties();
            Console.WriteLine($"The access tier of the blob is {_properties.AccessTier}");
            Console.WriteLine($"The size of the blob is {_properties.ContentLength}");
            Console.ReadKey();
        }
    }
}
