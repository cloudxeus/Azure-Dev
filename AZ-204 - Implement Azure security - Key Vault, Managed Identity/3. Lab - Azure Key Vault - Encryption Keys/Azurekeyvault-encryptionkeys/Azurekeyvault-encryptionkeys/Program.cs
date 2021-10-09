using Azure.Identity;
using Azure.Security.KeyVault.Keys;
using Azure.Security.KeyVault.Keys.Cryptography;
using System;
using System.Text;

namespace Azurekeyvault_encryptionkeys
{
    class Program
    {
        private static string tenantid = "5f5f1c90-abac-4ebe-88d7-0f3d121f967e";
        private static string clientid = "d8cf0b94-2d37-4902-8c79-60d426566d8e";
        private static string clientsecret = "bZ-u6__-aAr~2gz.4jasbs9v2a0ahv5PSo";

        private static string keyvault_url = "https://appvault1000123.vault.azure.net/";
        private static string key_name = "newkey";
        private static string text_to_encrypt = "This text needs to be encrypted";

        static void Main(string[] args)
        {
            ClientSecretCredential _client_secret = new ClientSecretCredential(tenantid, clientid, clientsecret);

            KeyClient _key_client=new KeyClient(new Uri(keyvault_url), _client_secret);

            var _key = _key_client.GetKey(key_name);

            // The CryptographyClient class is part of the Azure Key vault package
            // This is used to perform cryptographic operations with Azure Key Vault keys
            var crypto_client = new CryptographyClient(_key.Value.Id, _client_secret);

            // We first need to take the bytes of the string that needs to be converted

            byte[] text_to_bytes = Encoding.UTF8.GetBytes(text_to_encrypt);

            EncryptResult _result = crypto_client.Encrypt(EncryptionAlgorithm.RsaOaep, text_to_bytes);

            Console.WriteLine("The encrypted text");
            Console.WriteLine(Convert.ToBase64String(_result.Ciphertext));

            // Now lets decrypt the text
            // We first need to convert our Base 64 string of the Cipertext to bytes

            byte[] ciper_to_bytes = _result.Ciphertext;

            DecryptResult _text_decrypted = crypto_client.Decrypt(EncryptionAlgorithm.RsaOaep, ciper_to_bytes);

            Console.WriteLine(Encoding.UTF8.GetString(_text_decrypted.Plaintext));

            Console.ReadKey();
        }
    }
}
