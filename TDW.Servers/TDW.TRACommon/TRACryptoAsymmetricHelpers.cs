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
    static public class TRACryptoAsymmetricHelpers
    {
        const string KeyContainerName = "KeyContainer";

        private static RSACryptoServiceProvider GetAsymmetricCryptoProvider()
        {
            // Declare CspParmeters and RsaCryptoServiceProvider objects
            CspParameters cspParameters = new CspParameters();
            RSACryptoServiceProvider rsaProvider;

            // Stores a key pair in the key container.
            cspParameters = new CspParameters();
            cspParameters.KeyContainerName = KeyContainerName + " " + Guid.NewGuid().ToString();

            rsaProvider = new RSACryptoServiceProvider(2048, cspParameters);
            rsaProvider.PersistKeyInCsp = false;

            return rsaProvider;
        }

        private static RSACryptoServiceProvider GetAsymmetricCryptoProvider(string xmlKeyPair)
        {
            RSACryptoServiceProvider rsaProvider = GetAsymmetricCryptoProvider();

            rsaProvider.FromXmlString(xmlKeyPair);

            return rsaProvider;
        }

        public static long CreateKeyPair(byte[] salt, out byte[] encrytedXmlKeyPair, out string xmlPublicKey, out string alg, out long keysize)
        {
            string xmlKeypair;

            RSACryptoServiceProvider rsaProvider = GetAsymmetricCryptoProvider();

            xmlKeypair = rsaProvider.ToXmlString(true);
            xmlPublicKey = rsaProvider.ToXmlString(false);
            alg = rsaProvider.KeyExchangeAlgorithm;
            keysize = rsaProvider.KeySize;

            encrytedXmlKeyPair = TRACryptoSymmetricHelpers.EncryptWithMasterKey(Encoding.UTF8.GetBytes(xmlKeypair), salt);

            return 1;
        }

        // https://docs.microsoft.com/en-us/dotnet/standard/security/ensuring-data-integrity-with-hash-codes
        public static byte[] ComputeHashKeyPairSignature(byte[] hash, byte[] encrytedXmlKeyPair, byte[] salt)
        {
            byte[] signedHashValue;
            string xmlKeyPair;

            xmlKeyPair = Encoding.UTF8.GetString(TRACryptoSymmetricHelpers.DecryptWithMasterKey(encrytedXmlKeyPair, salt));

            RSACryptoServiceProvider rsaProvider = GetAsymmetricCryptoProvider(xmlKeyPair);
            RSAPKCS1SignatureFormatter rsaFormatter = new RSAPKCS1SignatureFormatter(rsaProvider);

            rsaFormatter.SetHashAlgorithm("SHA256");

            //Create a signature for hashedValue and assign it to signedHashValue.
            signedHashValue = rsaFormatter.CreateSignature(hash);

            return signedHashValue;
        }

        // https://docs.microsoft.com/en-us/dotnet/standard/security/ensuring-data-integrity-with-hash-codes
        public static bool ValidateDigitalSignature(byte[] hashedValue, byte[] signedHashValue, byte[] encrytedXmlKeyPair, byte[] salt)
        {
            string xmlKeyPair;

            xmlKeyPair = Encoding.UTF8.GetString(TRACryptoSymmetricHelpers.DecryptWithMasterKey(encrytedXmlKeyPair, salt));

            RSACryptoServiceProvider rsaProvider = GetAsymmetricCryptoProvider(xmlKeyPair);
            RSAPKCS1SignatureDeformatter rsaDeformatter = new RSAPKCS1SignatureDeformatter(rsaProvider);

            rsaDeformatter.SetHashAlgorithm("SHA256");

            return rsaDeformatter.VerifySignature(hashedValue, signedHashValue);

        }

        // https://docs.microsoft.com/en-us/dotnet/api/system.convert.tobase64string?view=net-5.0#System_Convert_ToBase64String_System_Byte___
        public static string ToBase64String(byte[] bytes)
        {
            string s = Convert.ToBase64String(bytes);
            return s;
        }
        public static byte[] FromBase64String(string s)
        {
            byte[] bytes = Convert.FromBase64String(s);
            return bytes;
        }
    }
}
