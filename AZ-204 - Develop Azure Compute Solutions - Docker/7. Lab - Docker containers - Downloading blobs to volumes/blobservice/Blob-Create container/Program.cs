using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;

namespace Blob_Create_container
{
    class Program
    {
        // Ensure to change the connection string and other properties accordingly
        private static string blob_connection_string = "DefaultEndpointsProtocol=https;AccountName=appstore10001123;AccountKey=Hz794qhjMfXXk50YNppXoQdtpBEwHhHqZ5SGhh5oSuMmkqZbSJNHZPtHW/DNbIFup+JOvKGR3z9QvLtjg6BIOg==;EndpointSuffix=core.windows.net";
        private static string container_name = "data";
        private static string local_blob = "\\app\\Courses.json";
        private static string blob_name = "Courses.json";
        static void Main(string[] args)
        {

            BlobServiceClient _client = new BlobServiceClient(blob_connection_string);

            BlobContainerClient _container_client = _client.GetBlobContainerClient(container_name);

            
            BlobClient _blob_client = _container_client.GetBlobClient(blob_name);

            _blob_client.DownloadTo(local_blob);          

            Console.WriteLine("Blob downloaded");
            
        }
    }
}
