using System;
using System.Net.Http;
using TDW.KMAServer;
using TDW.TRACommon;
using Newtonsoft.Json;
using System.Text;
using TDW.TRAServer;
using System.Collections.Generic;
using Trinity.Core.Lib;
using Trinity;

// requestMessage.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

namespace TDW.TRATester
{
    class Program
    {
        static void Main(string[] args)
        {
            const string plaintext = "Trust Digital Web Project, Hyperonomy Digital Identity Lab, Parallelpace Corporation";
            const string keypairsalt = "Hello World!";
            string hash64 = "";
            string signature64 = "";
            bool valid = false;

            string notaryudid = TRAUDIDHelpers.TRAUDIDFormat(TRAMethodNames.TRACredentialMethodName, 1234);

            TRATimestampCell tsCell = new TRATimestampCell(new TRATimestampEnvelope(), new TRACredentialEnvelopeSeal());
            string udid = TRAUDIDHelpers.TRAUDIDFormat(TRAMethodNames.TRACredentialMethodName, tsCell.CellId);
            DateTime now = DateTime.Now;
            TRATimestampClaims tsclaims = new TRATimestampClaims(now.Ticks, now, now.ToString("u"));
            tsCell.envelope.content = new TRATimestampContent(udid, TRAContexts.DefaultContext, tsclaims);
            tsCell.envelope.metadata = new TRACredentialMetadata(TRACredentialType.VerifiableCredential, 1, TRATrustLevel.SignedHashSignature,
                                                                 TRAEncryptionFlag.NotEncrypted, notaryudid, "Timestamp1", "My timestamp");
            // TODO Process Trust Level
            Global.LocalStorage.SaveTRATimestampCell(tsCell);

            long keypairid = 0;
            long keyringid = 1001;
            string keyringudid = TRAUDIDHelpers.TRAUDIDFormat(TRAMethodNames.TRAKeyRingMethodName, keyringid);

            bool kmstests = false;

            if (kmstests) using (var httpClient = new HttpClient())
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
                    Console.ReadLine();
                }

                Console.WriteLine(">>> http://localhost:8081/ComputePayloadHash/");
                using (var requestMessage = new HttpRequestMessage(new HttpMethod("POST"), "http://localhost:8081/ComputePayloadHash/"))
                {
                    requestMessage.Headers.TryAddWithoutValidation("Accept", "application/json");
                    string payload64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(plaintext));
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
                    Console.WriteLine("hash64:\t" + hash64);
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                }

                Console.WriteLine(">>> http://localhost:8081/ComputeHashKeyPairSignature/");
                using (var requestMessage = new HttpRequestMessage(new HttpMethod("POST"), "http://localhost:8081/ComputeHashKeyPairSignature/"))
                {
                    requestMessage.Headers.TryAddWithoutValidation("Accept", "application/json");
                    KMAComputeHashKeyPairSignatureRequest request = new KMAComputeHashKeyPairSignatureRequest(keypairid, keypairsalt, hash64);
                    string jsonRequest = JsonConvert.SerializeObject(request);
                    requestMessage.Content = new StringContent(jsonRequest);
                    var task = httpClient.SendAsync(requestMessage);
                    task.Wait();
                    var result = task.Result;
                    string jsonResponse = result.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(jsonResponse);
                    KMAHashKeyPairSignatureResponse response = JsonConvert.DeserializeObject<KMAHashKeyPairSignatureResponse>(jsonResponse);
                    signature64 = response.signature64;
                    Console.WriteLine("signature64: " + signature64);
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                }

                Console.WriteLine(">>> http://localhost:8081/ValidateHashKeyPairSignature/");
                using (var requestMessage = new HttpRequestMessage(new HttpMethod("POST"), "http://localhost:8081/ValidateHashKeyPairSignature/"))
                {
                    requestMessage.Headers.TryAddWithoutValidation("Accept", "application/json");
                    KMAValidateHashKeyPairSignatureRequest request = new KMAValidateHashKeyPairSignatureRequest(keypairid, keypairsalt, hash64, signature64);
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
                    Console.ReadLine();
                }

                using (var requestMessage = new HttpRequestMessage(new HttpMethod("POST"), "http://localhost:8081/ValidateHashKeyPairSignature/"))
                {
                    string hash64bad = hash64;
                    hash64bad = "xxx" + hash64.Substring(3);
                    requestMessage.Headers.TryAddWithoutValidation("Accept", "application/json");
                    KMAValidateHashKeyPairSignatureRequest request = new KMAValidateHashKeyPairSignatureRequest(keypairid, keypairsalt, hash64bad, signature64);
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
                    Console.ReadLine();
                }

                using (var requestMessage = new HttpRequestMessage(new HttpMethod("POST"), "http://localhost:8081/ValidateHashKeyPairSignature/"))
                {
                    string hash64short = hash64.Substring(1); // shorten by 1 byte
                    requestMessage.Headers.TryAddWithoutValidation("Accept", "application/json");
                    KMAValidateHashKeyPairSignatureRequest request = new KMAValidateHashKeyPairSignatureRequest(keypairid, keypairsalt, hash64short, signature64);
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
                    Console.ReadLine();
                }
            }

            using (var httpClient = new HttpClient())
            {
                Console.WriteLine(">>> http://localhost:8080/CreateTDWCredential/");
                using (var requestMessage = new HttpRequestMessage(new HttpMethod("POST"), "http://localhost:8080/CreateTDWCredential/"))
                {
                    List<string> context = new List<string> { "https://www.sovrona.com/ns/svrn/v1" };

                    List<TRAClaim> claims = new List<TRAClaim>();
                    claims.Add(new TRAClaim("authentication", null,
                        new List<TRAKeyValuePair> {
                            new TRAKeyValuePair( "publicKey", "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ"),
                            new TRAKeyValuePair( "id", "#pubkey1"),
                            new TRAKeyValuePair( "type", "AUTHN-KEY")
                            }));

                    claims.Add(new TRAClaim("service", null,
                        new List<TRAKeyValuePair> {
                            new TRAKeyValuePair( "serviceEndPoint", "http://localhost:5304/"),
                            new TRAKeyValuePair( "id", "#tda1"),
                            new TRAKeyValuePair( "type", "TrustedDigitalAgent")
                            }));

                    claims.Add(new TRAClaim("testkey1", "testvalue1"));

                    List<TRAKeyValuePair> attr2 = new List<TRAKeyValuePair> {
                        new TRAKeyValuePair( "publicKey", "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ"),
                        new TRAKeyValuePair( "id", "#pubkey2"),
                        new TRAKeyValuePair( "type", "AUTHN-KEY")
                    };
                    List<TRAKeyValuePair> attr3 = new List<TRAKeyValuePair> {
                        new TRAKeyValuePair( "publicKey", "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ"),
                        new TRAKeyValuePair( "id", "#pubkey3"),
                        new TRAKeyValuePair( "type", "AUTHN-KEY")
                    };
                    List<List<TRAKeyValuePair>> attrslist = new List<List<TRAKeyValuePair>> { attr2, attr2 };
                    TRAClaim testclaim2 = new TRAClaim("testkey2", null, null, attrslist);
                    claims.Add(testclaim2);

                    var comments = new List<string> { "Bob's UDID Document", "It works!", "Created by TDW.TRAServer at " + DateTime.Now.ToString("u") };

                    requestMessage.Headers.TryAddWithoutValidation("Accept", "application/json");
                    TDWCreateTDWCredentialRequest request = new TDWCreateTDWCredentialRequest(TRACredentialType.UDIDDocument, context, claims,
                                                                TRATrustLevel.SignedHashSignature, TRAEncryptionFlag.NotEncrypted, comments, keypairsalt);
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
                    Console.ReadLine();
                }
            }

            // TODO

            Console.WriteLine("Press Enter to exit TRATester...");
            Console.ReadLine();
        }
    }
}
