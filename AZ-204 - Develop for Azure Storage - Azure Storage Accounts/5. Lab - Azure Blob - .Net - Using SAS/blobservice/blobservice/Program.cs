using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Sas;
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
        private static string _location = "C:\\tmp\\Program.cs";

        static void Main(string[] args)
        {
            
            ReadBlob();
            
            Console.ReadKey();
        }

        public static void ReadBlob()
        {
            Uri _blob_uri = GenerateSAS();

            BlobClient _client = new BlobClient(_blob_uri);

            _client.DownloadTo(_location);
        }
        public static Uri GenerateSAS()
        {
            BlobServiceClient _service_client = new BlobServiceClient(_connection_string);

            BlobContainerClient _container_client = _service_client.GetBlobContainerClient(_container_name);

            BlobClient _blob_client = _container_client.GetBlobClient(_blob_name);

            BlobSasBuilder _builder = new BlobSasBuilder()
            {
                BlobContainerName = _container_name,
                BlobName = _blob_name,
                Resource = "b"
            };

            _builder.SetPermissions(BlobSasPermissions.Read | BlobSasPermissions.List);

            _builder.ExpiresOn = DateTimeOffset.UtcNow.AddHours(1);

            return _blob_client.GenerateSasUri(_builder);


        }


    }
}
