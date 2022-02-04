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
    static public class TRACryptoHashHelpers
    {
        static private SHA256Managed HashProvider = new SHA256Managed();

        // https://docs.microsoft.com/en-us/dotnet/standard/security/ensuring-data-integrity-with-hash-codes
        public static byte[] ComputeHash(byte[] bytes)
        {
            byte[] hashedValue;

            // SHA256Managed hashProvider = new SHA256Managed();

            hashedValue = HashProvider.ComputeHash(bytes);

            return hashedValue;
        }

        public static byte[] ComputeFileHash(string inFile)
        {
            byte[] hashedValue;

            byte[] fileBytes = File.ReadAllBytes(inFile);

            hashedValue = ComputeHash(fileBytes);

            return hashedValue;
        }
    }
}
