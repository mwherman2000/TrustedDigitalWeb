using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace TDW.TRACommon
{
    static public class TRACryptoSymmetricHelpers
    {
        static private string PathMasterKey = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Trusted Digital Web\\Keys";

        static private IKeyManager GetMasterKeyManager()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDataProtection()
                .PersistKeysToFileSystem(new DirectoryInfo(PathMasterKey))
                .ProtectKeysWithDpapi();

            var services = serviceCollection.BuildServiceProvider();
            var keyManager = services.GetService<IKeyManager>();

            return keyManager;
        }

        // https://docs.microsoft.com/en-us/aspnet/core/security/data-protection/implementation/key-management?view=aspnetcore-5.0#key-storage
        public static Guid AddNewMasterKey(bool revokeAll)
        {
            var keyManager = GetMasterKeyManager();

            if (revokeAll) keyManager.RevokeAllKeys(DateTimeOffset.Now, "AddNewMasterKey");
            var newkey = keyManager.CreateNewKey(activationDate: DateTimeOffset.Now, expirationDate: DateTimeOffset.MaxValue);

            var allKeys = keyManager.GetAllKeys();
            Console.WriteLine($"Key Count {allKeys.Count}");
            foreach (var key in allKeys)
            {
                if (key == newkey) Console.Write(">>> ");
                Console.WriteLine($"Key {key.KeyId:B}: Created = {key.CreationDate:u}, IsRevoked = {key.IsRevoked}");
            }

            return newkey.KeyId;
        }

        public static byte[] EncryptWithMasterKey(byte[] plaintext, byte[] salt)
        {
            byte[] ciphertext = default;
            byte[] keyciphertext = default;

            IKey currentKey = null;
            var keyManager = GetMasterKeyManager();
            foreach (var key in keyManager.GetAllKeys())
            {
                if (!key.IsRevoked)
                {
                    if (currentKey == null) currentKey = key;
                    else if (key.CreationDate > currentKey.CreationDate) currentKey = key;
                }
            }

            if (currentKey != null)
            {
                Console.WriteLine($"Key {currentKey.KeyId:B}: Created = {currentKey.CreationDate:u}, IsRevoked = {currentKey.IsRevoked}");
                ciphertext = currentKey.CreateEncryptor().Encrypt(plaintext, salt);
                byte[] slash = new byte[] { (byte)'/' };
                keyciphertext = TRAByteHelpers.Combine(currentKey.KeyId.ToByteArray(), slash, ciphertext);
            }

            return keyciphertext;
        }

        public static byte[] DecryptWithMasterKey(byte[] ciphertext, byte[] salt)
        {
            byte[] plaintext = default;

            byte[] keyIdbytes = new byte[16];
            Array.Copy(ciphertext, keyIdbytes, 16);
            Guid keyId = new Guid(keyIdbytes);

            byte[] ciphertext2 = new byte[ciphertext.Length - 16 - 1];
            Array.Copy(ciphertext, 16 + 1, ciphertext2, 0, ciphertext.Length - 16 - 1);

            IKey currentKey = null;
            var keyManager = GetMasterKeyManager();
            foreach (var key in keyManager.GetAllKeys())
            {
                if (key.KeyId == keyId)
                {
                    currentKey = key;
                    break;
                }
            }

            if (currentKey != null)
            {
                Console.WriteLine($"Key {currentKey.KeyId:B}: Created = {currentKey.CreationDate:u}, IsRevoked = {currentKey.IsRevoked}");
                plaintext = currentKey.CreateEncryptor().Decrypt(ciphertext2, salt);
            }

            return plaintext;
        }
    }
}
