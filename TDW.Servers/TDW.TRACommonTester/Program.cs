using System;
using System.Text;
using TDW.TRACommon;

namespace TDW.TRACommonTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Guid masterKey = TRACryptoSymmetricHelpers.AddNewMasterKey(false);
            Console.WriteLine("masterKey: " + masterKey.ToString());

            string plaintext = "Trusted Digital Web Project, Hyperonomy Digital Identity Lab, Parallelspace Corporation";
            string salt = "Hello world!";
            Console.WriteLine("plaintext: " + plaintext.Length + " " + plaintext);
            Console.WriteLine("salt: " + salt.Length + " " + salt.Length);

            byte[] ciphertext = TRACryptoSymmetricHelpers.EncryptWithMasterKey(Encoding.UTF8.GetBytes(plaintext), Encoding.UTF8.GetBytes(salt));
            Console.WriteLine("ciphertext: " + ciphertext.Length + " " + BitConverter.ToString(ciphertext));

            byte[] newtext = TRACryptoSymmetricHelpers.DecryptWithMasterKey(ciphertext, Encoding.UTF8.GetBytes(salt));
            Console.WriteLine("newtext: " + newtext.Length + " " + Encoding.UTF8.GetString(newtext));

            byte[] hash = TRACryptoHashHelpers.ComputeHash(Encoding.UTF8.GetBytes(plaintext));
            Console.WriteLine("hash:\t" + hash.Length + " " + BitConverter.ToString(hash));
            string plaintext2 = "trusted Digital Web Project, Hyperonomy Digital Identity Lab, Parallelspace Corporation";
            byte[] hash2 = TRACryptoHashHelpers.ComputeHash(Encoding.UTF8.GetBytes(plaintext2));
            Console.WriteLine("hash2:\t" + hash2.Length + " " + BitConverter.ToString(hash2));

            byte[] encryptedXmlKeyPair;
            string xmlPublicKey;
            string alg;
            long keysize;
            long rc = TRACryptoAsymmetricHelpers.CreateKeyPair(Encoding.UTF8.GetBytes(salt), out encryptedXmlKeyPair, out xmlPublicKey, out alg, out keysize);
            Console.WriteLine("encryptedXmlKeyPair:\t" + encryptedXmlKeyPair.Length + " " + BitConverter.ToString(encryptedXmlKeyPair));
            Console.WriteLine("xmlPublicKey:\t" + xmlPublicKey);
            Console.WriteLine("alg:\t" + alg);
            Console.WriteLine("keysize:\t" + keysize);

            byte[] signedHash = TRACryptoAsymmetricHelpers.ComputeHashKeyPairSignature(hash, encryptedXmlKeyPair, Encoding.UTF8.GetBytes(salt));
            Console.WriteLine("signedHash:\t" + signedHash.Length + " " + BitConverter.ToString(signedHash));

            bool valid = TRACryptoAsymmetricHelpers.ValidateDigitalSignature(hash, signedHash, encryptedXmlKeyPair, Encoding.UTF8.GetBytes(salt));
            Console.WriteLine("valid: " + valid);

            // https://docs.microsoft.com/en-us/dotnet/api/system.convert.tobase64string?view=net-5.0#System_Convert_ToBase64String_System_Byte___
            // Define a byte array.
            byte[] bytes = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };
            Console.WriteLine("bytes:    {0} {1}", bytes.Length, BitConverter.ToString(bytes));
            // Convert the array to a base 64 string.
            string s = TRAByteHelpers.ToBase64String(bytes);
            Console.WriteLine("base 64:  {0} {1}", s.Length, s);
            // Restore the byte array.
            byte[] newBytes = TRAByteHelpers.FromBase64String(s);
            Console.WriteLine("newBytes: {0} {1}\n", bytes.Length, BitConverter.ToString(newBytes));

            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
    }
}
