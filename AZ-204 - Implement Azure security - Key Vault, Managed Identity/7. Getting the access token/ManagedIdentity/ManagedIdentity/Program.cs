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

        static void Main(string[] args)
        {
            HttpWebRequest _request = (HttpWebRequest)WebRequest.Create("http://169.254.169.254/metadata/identity/oauth2/token?api-version=2018-02-01&resource=https://storage.azure.com/");
            _request.Headers["Metadata"] = "true";
            _request.Method = "GET";

            HttpWebResponse _response = (HttpWebResponse)_request.GetResponse();

            
            StreamReader _streamResponse = new StreamReader(_response.GetResponseStream());
            string _fullresponse = _streamResponse.ReadToEnd();

            Console.WriteLine("This is the response");
            Console.WriteLine(_fullresponse);

            Dictionary<string, string> _list = (Dictionary<string, string>)(JsonSerializer.Deserialize<Dictionary<string, string>>(_fullresponse));

            string _accessToken = _list["access_token"];

            Console.WriteLine("Just the access token");
            Console.WriteLine(_accessToken);

                      

        }
    }
}
