using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.IO;

namespace Blob_Create_container
{
    class Program
    {
        // Ensure to change the connection string and other properties accordingly
        //private static string blob_connection_string = "DefaultEndpointsProtocol=https;AccountName=newstore100033323;AccountKey=Ar4/2iY8L0rEMeQaijINnfaMJr7vqjfbPgmJayw6Pu5l9ZI+GrFDm1uIWOqXk5RQLrTiXfBwWY6hAbPEIQqy1g==;EndpointSuffix=core.windows.net";
        private static string container_name = "data";
        private static string local_blob = "/app/data/commands.txt";
        private static string blob_name = "commands.txt";
        private static string secretname = "/app/secrets/storage-connection";
        static void Main(string[] args)
        {
            string blob_connection_string = File.ReadAllText(secretname);

            BlobServiceClient _client = new BlobServiceClient(blob_connection_string);

            BlobContainerClient _container_client = _client.GetBlobContainerClient(container_name);
                        
            
            BlobClient _blob_client = _container_client.GetBlobClient(blob_name);

            _blob_client.DownloadTo(local_blob);          

            Console.WriteLine("Blob downloaded");
            
        }
    }
}
