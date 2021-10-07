using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.IO;

namespace Blob_Create_container
{
    class Program
    {
        // Ensure to change the connection string and other properties accordingly
        private static string blob_connection_string = "DefaultEndpointsProtocol=https;AccountName=appstore445577;AccountKey=5jk/QJO99okHBa0M/uZCjX0JNMTrbl2HG9kFfmAFp1ce15wSife+o0iXROEkSu9C17AqnawUchFKAq9a8nqyeg==;EndpointSuffix=core.windows.net";
        private static string container_name = "data";
        private static string local_blob = "/app/data/Courses.json";
        private static string blob_name = "Courses.json";
        static void Main(string[] args)
        {

            BlobServiceClient _client = new BlobServiceClient(blob_connection_string);

            BlobContainerClient _container_client = _client.GetBlobContainerClient(container_name);
            
            BlobClient _blob_client = _container_client.GetBlobClient(blob_name);

            Console.WriteLine("Initiating download");

            _blob_client.DownloadTo(local_blob);          

             Console.WriteLine("Blob downloaded");
            
        }
    }
}
