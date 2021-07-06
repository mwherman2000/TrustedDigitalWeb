using System;
using System.Net.Http;
using TDW.KMAServer;
using TDW.TRACommon;
using Newtonsoft.Json;
using System.Text;

// requestMessage.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

namespace TDW.KMATester
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

            long keypairid = 0;
            long keyringid = 1001;
            string keyringudid = TRAUDIDHelpers.TRAUDIDFormat(TRAMethodNames.TRAKeyRingMethodName, keyringid);

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
                    Console.ReadLine();
                }

                Console.WriteLine(">>> http://localhost:8081/GetBestKeyPair/");
                using (var requestMessage = new HttpRequestMessage(new HttpMethod("POST"), "http://localhost:8081/GetBestKeyPair/"))
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
            Console.WriteLine("Press Enter to exit KMATester...");
            Console.ReadLine();
        }
    }
}
