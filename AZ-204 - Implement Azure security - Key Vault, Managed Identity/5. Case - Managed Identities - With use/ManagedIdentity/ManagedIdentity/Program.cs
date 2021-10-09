using Azure.Core;
using Azure.Identity;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;

namespace ManagedIdentity
{
    class Program
    {

        private static string blob_url = "https://appstore100011.blob.core.windows.net/data/sample.txt";
        private static string download_path = "C:\\tmp\\sample.txt";
        static void Main(string[] args)
        {
            
            TokenCredential __credential = new DefaultAzureCredential();
            Uri blob_uri = new Uri(blob_url);

            BlobClient _client = new BlobClient(blob_uri, __credential);

            BlobDownloadInfo _download = _client.Download();

            using (FileStream _downloadFileStream = File.OpenWrite(download_path))
            {
                _download.Content.CopyTo(_downloadFileStream);
                _downloadFileStream.Close();
            }
            Console.WriteLine("File download complete");
            Console.ReadKey();

        }
    }
}
