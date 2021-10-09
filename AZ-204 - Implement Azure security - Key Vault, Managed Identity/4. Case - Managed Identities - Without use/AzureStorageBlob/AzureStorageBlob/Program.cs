using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.IO;

namespace AzureStorageBlob
{
    class Program
    {
        private static string storage_connection_string = "DefaultEndpointsProtocol=https;AccountName=appstore100011;AccountKey=fxB+dpL7gvWNQQsKMtlzuSvN2WyyUeREwi+hewplI8ViG2AOFrB4r6x/w00F+Ym20AfExFxICWFzxBgt7LRvrA==;EndpointSuffix=core.windows.net";
        private static string container_name = "data";
        private static string download_path = "C:\\tmp\\sample.txt";
        private static string blob_name = "sample.txt";
        static void Main(string[] args)
        {
            BlobServiceClient _blobServiceClient = new BlobServiceClient(storage_connection_string);

            BlobContainerClient _containerClient = _blobServiceClient.GetBlobContainerClient(container_name);

            BlobClient _blobclient = _containerClient.GetBlobClient(blob_name);

            _blobclient.DownloadTo(download_path);
            
            Console.WriteLine("File download complete");
            Console.ReadKey();
        }
    }
}
