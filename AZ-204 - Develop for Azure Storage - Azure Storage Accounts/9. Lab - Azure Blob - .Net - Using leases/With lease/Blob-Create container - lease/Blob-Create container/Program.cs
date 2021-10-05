using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using Azure.Storage.Blobs.Specialized;
using System.IO;

namespace Blob_Create_container
{
    class Program
    {
        private static string blob_connection_string = "DefaultEndpointsProtocol=https;AccountName=appstore100011;AccountKey=/4X2MRoELqbi7vSjRouzu6rvA/kvmWMMiwxkgolLZGKuyZbTYYB3Mh/8RMWF7THwNw3sMvJtexEr6DwLn81wHQ==;EndpointSuffix=core.windows.net";
        private static string container_name = "demo";
        private static string local_blob = "C:\\tmp\\Program.cs";
        private static string blob_name = "Program.cs";
        static void Main(string[] args)
        {
            GetLease();
        }

        public static void GetLease()
        {
            BlobServiceClient _client = new BlobServiceClient(blob_connection_string);

            BlobContainerClient _container_client = _client.GetBlobContainerClient(container_name);


            BlobClient _blob_client = _container_client.GetBlobClient(blob_name);


            MemoryStream _stream = new MemoryStream();

            _blob_client.DownloadTo(_stream);            

            BlobLeaseClient _blob_lease_client = _blob_client.GetBlobLeaseClient();
            BlobLease _lease = _blob_lease_client.Acquire(TimeSpan.FromSeconds(30));

            Console.WriteLine($"The lease is {_lease.LeaseId}");

            StreamWriter _writer = new StreamWriter(_stream);
            _writer.Write("This is a change");
            _writer.Flush();

            _stream.Position = 0;

            BlobUploadOptions _blobUploadOptions = new BlobUploadOptions()
            {
                Conditions = new BlobRequestConditions()
                {
                    LeaseId = _lease.LeaseId
                }
            };

            _blob_client.Upload(_stream,_blobUploadOptions);
            _blob_lease_client.Release();


            Console.WriteLine("Change made");

            Console.ReadKey();
        }
        
    }
}
