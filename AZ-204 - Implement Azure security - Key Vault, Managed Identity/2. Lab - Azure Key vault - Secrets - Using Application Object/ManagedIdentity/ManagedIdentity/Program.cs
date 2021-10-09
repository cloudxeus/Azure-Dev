using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;

namespace ManagedIdentity
{
    class Program
    {

        private static string tenantid = "5f5f1c90-abac-4ebe-88d7-0f3d121f967e";
        private static string clientid = "d8cf0b94-2d37-4902-8c79-60d426566d8e";
        private static string clientsecret = "bZ-u6__-aAr~2gz.4jasbs9v2a0ahv5PSo";
        
        private static string keyvault_url = "https://appvault1000123.vault.azure.net/";
        private static string secret_name = "dbpassword";
        static void Main(string[] args)
        {

            ClientSecretCredential _client_secret = new ClientSecretCredential(tenantid,clientid,clientsecret);

            SecretClient _secret_client = new SecretClient(new Uri(keyvault_url), _client_secret);

            var secret= _secret_client.GetSecret(secret_name);

            Console.WriteLine($"The value of the secret is {secret.Value.Value}");

            Console.ReadKey();

        }
    }
}
