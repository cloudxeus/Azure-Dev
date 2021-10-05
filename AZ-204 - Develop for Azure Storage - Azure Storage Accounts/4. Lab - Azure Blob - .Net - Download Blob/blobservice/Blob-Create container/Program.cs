using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;

namespace Blob_Create_container
{
    class Program
    {
        // Ensure to change the connection string and other properties accordingly
        private static string blob_connection_string = "DefaultEndpointsProtocol=https;AccountName=appstore100011;AccountKey=/4X2MRoELqbi7vSjRouzu6rvA/kvmWMMiwxkgolLZGKuyZbTYYB3Mh/8RMWF7THwNw3sMvJtexEr6DwLn81wHQ==;EndpointSuffix=core.windows.net";
        private static string container_name = "demo";
        private static string local_blob = "C:\\tmp\\Program.cs";
        private static string blob_name = "Program.cs";
        static void Main(string[] args)
        {

            BlobServiceClient _client = new BlobServiceClient(blob_connection_string);

            BlobContainerClient _container_client = _client.GetBlobContainerClient(container_name);

            
            BlobClient _blob_client = _container_client.GetBlobClient(blob_name);

            _blob_client.DownloadTo(local_blob);          


            Console.WriteLine("Blob downloaded");
            Console.ReadKey();
        }
    }
}
