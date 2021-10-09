using Azure.Identity;
using Azure.Storage.Blobs;
using System;

namespace blobapplication
{
    class Program
    {


        private static string blob_url = "https://functionstore1000.blob.core.windows.net/data/sample.txt";
        private static string local_blob = "C:\\data\\sample.txt";
        private static string blob_name = "sample.txt";

        private static string tenantid = "5f5f1c90-abac-4ebe-88d7-0f3d121f967e";
        private static string clientid = "d8cf0b94-2d37-4902-8c79-60d426566d8e";
        private static string clientsecret = "bZ-u6__-aAr~2gz.4jasbs9v2a0ahv5PSo";
        static void Main(string[] args)
        {
            ClientSecretCredential _client_credential = new ClientSecretCredential(tenantid, clientid, clientsecret);

            Uri blob_uri = new Uri(blob_url);

            BlobClient _blob_client = new BlobClient(blob_uri, _client_credential);

            _blob_client.DownloadTo(local_blob);            

            Console.WriteLine("Blob downloaded");
            Console.ReadKey();
        }

    }
}
