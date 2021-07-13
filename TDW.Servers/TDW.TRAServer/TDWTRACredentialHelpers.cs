using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TDW.KMAServer;
using TDW.TRACommon;
using Trinity;

namespace TDW.TRAServer
{
    public static class TDWTRACredentialHelpers
    {
        public static TrinityErrorCode HashAndSignTDWCredential(ref TRACredential_Cell credential, TRATrustLevel trustLevel, string keypairsalt)
        {
            string hash64 = "";
            string signature64 = "";
            bool valid = false;

            Console.WriteLine("trustLevel: " + trustLevel.ToString());

            long keypairid = 0;
            long keyringid = 1001;
            string keyringudid = TRAUDIDHelpers.TRAUDIDFormat(TRAMethodNames.TRAKeyRingMethodName, keyringid);

            string jsonenvelope = JsonConvert.SerializeObject(credential.envelope);
            Console.WriteLine("jsonenvelope: " + jsonenvelope);

            using (var httpClient = new HttpClient())
            {
                Console.WriteLine(">>> http://localhost:8081/CreateKeyPair/");
                using (var requestMessage = new HttpRequestMessage(new HttpMethod("POST"), "http://localhost:8081/CreateKeyPair/"))
                {
                    requestMessage.Headers.TryAddWithoutValidation("Accept", "application/json");
                    KMACreateKeyPairRequest request = new KMACreateKeyPairRequest(keypairsalt, keyringudid);
                    string jsonRequest = JsonConvert.SerializeObject(request);
                    requestMessage.Content = new StringContent(jsonRequest);
                    var task = httpClient.SendAsync(requestMessage);
                    task.Wait();
                    var result = task.Result;
                    string jsonResponse = result.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(jsonResponse);
                    KMAKeyPairResponse response = JsonConvert.DeserializeObject<KMAKeyPairResponse>(jsonResponse);
                    keypairid = response.id;
                    Console.WriteLine("keypairid:\t" + keypairid.ToString());
                    Console.WriteLine("Press Enter to continue...");
                    //Console.ReadLine();
                }

                if (trustLevel == TRATrustLevel.HashedThumbprint ||
                    trustLevel == TRATrustLevel.SignedHashSignature ||
                    trustLevel == TRATrustLevel.Verifiable)
                {
                    Console.WriteLine(">>> http://localhost:8081/ComputePayloadHash/");
                    using (var requestMessage = new HttpRequestMessage(new HttpMethod("POST"), "http://localhost:8081/ComputePayloadHash/"))
                    {
                        requestMessage.Headers.TryAddWithoutValidation("Accept", "application/json");
                        string payload64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(jsonenvelope));
                        KMAComputePayloadHashRequest request = new KMAComputePayloadHashRequest(payload64);
                        string jsonRequest = JsonConvert.SerializeObject(request);
                        requestMessage.Content = new StringContent(jsonRequest);
                        var task = httpClient.SendAsync(requestMessage);
                        task.Wait();
                        var result = task.Result;
                        string jsonResponse = result.Content.ReadAsStringAsync().Result;
                        Console.WriteLine(jsonResponse);
                        KMAPayloadHashResponse response = JsonConvert.DeserializeObject<KMAPayloadHashResponse>(jsonResponse);
                        hash64 = response.hash64;
                        credential.envelopeseal.hashedThumbprint64 = hash64;
                        Console.WriteLine("hash64:\t" + hash64);
                        Console.WriteLine("Press Enter to continue...");
                        //Console.ReadLine();
                    }
                }

                if (trustLevel == TRATrustLevel.SignedHashSignature ||
                    trustLevel == TRATrustLevel.Verifiable)
                {
                    Console.WriteLine(">>> http://localhost:8081/ComputeHashKeyPairSignature/");
                    using (var requestMessage = new HttpRequestMessage(new HttpMethod("POST"), "http://localhost:8081/ComputeHashKeyPairSignature/"))
                    {
                        requestMessage.Headers.TryAddWithoutValidation("Accept", "application/json");
                        KMAComputeHashKeyPairSignatureRequest request = new KMAComputeHashKeyPairSignatureRequest(keypairid, keypairsalt, credential.envelopeseal.hashedThumbprint64);
                        string jsonRequest = JsonConvert.SerializeObject(request);
                        requestMessage.Content = new StringContent(jsonRequest);
                        var task = httpClient.SendAsync(requestMessage);
                        task.Wait();
                        var result = task.Result;
                        string jsonResponse = result.Content.ReadAsStringAsync().Result;
                        Console.WriteLine(jsonResponse);
                        KMAHashKeyPairSignatureResponse response = JsonConvert.DeserializeObject<KMAHashKeyPairSignatureResponse>(jsonResponse);
                        signature64 = response.signature64;
                        credential.envelopeseal.signedHashSignature64 = signature64;
                        Console.WriteLine("signature64: " + signature64);
                        Console.WriteLine("Press Enter to continue...");
                        //Console.ReadLine();
                    }
                }

                if (trustLevel == TRATrustLevel.SignedHashSignature ||
                    trustLevel == TRATrustLevel.Verifiable)
                {
                    // TODO
                }

                Console.WriteLine(">>> http://localhost:8081/ValidateHashKeyPairSignature/");
                using (var requestMessage = new HttpRequestMessage(new HttpMethod("POST"), "http://localhost:8081/ValidateHashKeyPairSignature/"))
                {
                    requestMessage.Headers.TryAddWithoutValidation("Accept", "application/json");
                    KMAValidateHashKeyPairSignatureRequest request = new KMAValidateHashKeyPairSignatureRequest(keypairid, keypairsalt,
                        credential.envelopeseal.hashedThumbprint64, credential.envelopeseal.signedHashSignature64);
                    string jsonRequest = JsonConvert.SerializeObject(request);
                    requestMessage.Content = new StringContent(jsonRequest);
                    var task = httpClient.SendAsync(requestMessage);
                    task.Wait();
                    var result = task.Result;
                    string jsonResponse = result.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(jsonResponse);
                    KMAValidateHashKeyPairSignatureResponse response = JsonConvert.DeserializeObject<KMAValidateHashKeyPairSignatureResponse>(jsonResponse);
                    valid = response.valid;
                    Console.WriteLine("valid: " + valid.ToString());
                    Console.WriteLine("Press Enter to continue...");
                    //Console.ReadLine();
                }
            }

            return TrinityErrorCode.E_SUCCESS;
        }
    }
}
