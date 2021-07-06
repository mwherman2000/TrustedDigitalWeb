using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;

namespace TDW.VDAStratisHelpers
{
    public static class TDWVDAStratisDriver
    {
        // https://stackoverflow.com/questions/22627296/how-to-call-rest-api-from-a-console-application/22627481
        // https://stackoverflow.com/questions/9145667/how-to-post-json-to-a-server-using-c

        // curl -X POST "http://localhost:37223/api/contract/CQj4fpfWbTYDbFRRkn8fzAqUEH2J8eDpYp/method/AcceptNotorization5" -H "accept: application/json" -H "GasPrice: 100" -H "GasLimit: 100000" -H "Amount: 0" -H "FeeAmount: 0.01" -H ": Hackathon_1" -H "WalletPassword: stratis" -H "Sender: CUtNvY1Jxpn4V4RD1tgphsUKpQdo4q5i54" -H "Content-Type: application/json" -d "{ \"bytes\": \"12233445566778\"}"

        // {"fee":11000000,
        // "hex":"0100000002e4bd5e6e0bcfebd6b6ba35b543e5e7cbc3c3b063ec03bf828a1eb7371262339e010000006b48304502210087498af25a41289e3c61f32e9768ba4eaa9bda3d810c69bb79790f6d018fc00a02203b291c5bf1ca74a914cc21777ada071675e1f5bb50a86d9bc8d9134efead133f01210263c40613eb0fd8d5c0a0ef30febba947d688213bfc6255ddaca145afa5dd65b6ffffffff298e0c006ac914f8228b31cf2fb983d27bc24bae206cf4670578ae0eb559c8c5010000006a47304402201aa7df37a112a63155cd91343ec8b99313b21bb834564285e19034c6715c65d6022038356b74c484622b88e28ccd07c4c89344f78671fdc657e116a803895be0888b01210263c40613eb0fd8d5c0a0ef30febba947d688213bfc6255ddaca145afa5dd65b6ffffffff02a86f6a00000000001976a91488432921b2b07617a42342597558cfa0ba42996388ac000000000000000049c1010000006400000000000000a0860100000000005a9fad2e0dd9f3ce009907c5515ba780cebfa248df934163636570744e6f746f72697a6174696f6e358ac9880a1223344556677800000000",
        // "message":"Your CALL method AcceptNotorization5 transaction was sent. Check the receipt using the transaction ID once it has been included in a new block.",
        // "success":true,
        // "transactionId":"f2d80869781fb164fb3605b0f5c83a24b711057b0b824ce8cb0c92cb1643bfb4"

        public static string CallContractMethodOld(string serviceEndpoint, string contractAddress, 
                                                string walletName, string walletPassword, string senderAddress,
                                                string methodName, string methodParametersJson)
        {
            string url = string.Format("{0}/api/contract/{1}/method/{2}", serviceEndpoint, contractAddress, methodName);
            Console.WriteLine("Request: " + url);

            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
            webrequest.Method = "POST";

            webrequest.ContentType = "application/json; charset=utf-8";
            webrequest.Headers.Add("accept", "application/json");

            webrequest.Headers.Add("GasPrice", "100");
            webrequest.Headers.Add("GasLimit", "100000");
            webrequest.Headers.Add("Amount", "0");
            webrequest.Headers.Add("FeeAmount", "0.01");

            webrequest.Headers.Add("WalletName", walletName);
            webrequest.Headers.Add("WalletPassword", walletPassword);

            webrequest.Headers.Add("Sender", senderAddress);

            byte[] postBytes = Encoding.UTF8.GetBytes(methodParametersJson);
            webrequest.ContentLength = postBytes.Length;
            Stream requestStream = webrequest.GetRequestStream();
            requestStream.Write(postBytes, 0, postBytes.Length);
            requestStream.Close();

            HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();

            Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader responseStream = new StreamReader(webresponse.GetResponseStream(), enc);
            string result = string.Empty;
            result = responseStream.ReadToEnd();
            responseStream.Close();

            webresponse.Close();

            return result;
        }

        const int MAX_SECONDS = 20;

        public static string WaitforCallReceipt(string serviceEndpoint, string txId)
        {
            string url = string.Format("{0}/api/SmartContracts/receipt?txHash={1}", serviceEndpoint, txId);

            string result = string.Empty;
            int nSeconds = 0;
            do
            {
                try
                {
                    HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
                    webrequest.Method = "GET";

                    webrequest.ContentType = "application/json; charset=utf-8";
                    webrequest.Headers.Add("accept", "application/json");

                    HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();

                    Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
                    StreamReader responseStream = new StreamReader(webresponse.GetResponseStream(), enc);
                    result = responseStream.ReadToEnd();
                    responseStream.Close();

                    webresponse.Close();
                }
                catch (Exception ex)
                {
                    if (nSeconds > MAX_SECONDS)
                    {
                        result = "{ \"message\": \"timeout\" }";
                        return result;
                    }

                    Console.Write(".");
                    Thread.Sleep(1000);
                    nSeconds++;
                }
            }
            while (result.Length == 0);
            Console.WriteLine(" " + nSeconds.ToString() + " seconds");

            return result;
        }

        public static string LocalCallContractMethod(string serviceEndpoint, string methodCallParametersJson)
        {
            string url = string.Format("{0}/api/SmartContracts/local-call", serviceEndpoint);
            Console.WriteLine("Request: " + url);

            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
            webrequest.Method = "POST";

            webrequest.ContentType = "application/json; charset=utf-8";
            webrequest.Headers.Add("accept", "application/json");

            byte[] postBytes = Encoding.UTF8.GetBytes(methodCallParametersJson);
            Console.WriteLine(methodCallParametersJson);
            webrequest.ContentLength = postBytes.Length;
            Stream requestStream = webrequest.GetRequestStream();
            requestStream.Write(postBytes, 0, postBytes.Length);
            requestStream.Close();

            HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();

            Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader responseStream = new StreamReader(webresponse.GetResponseStream(), enc);
            string result = string.Empty;
            result = responseStream.ReadToEnd();
            responseStream.Close();

            webresponse.Close();

            return result;
        }

        public static string BuildAndCallContractMethod(string serviceEndpoint, string methodCallParametersJson)
        {
            string url = string.Format("{0}/api/SmartContracts/build-and-send-call", serviceEndpoint);
            Console.WriteLine("Request: " + url);

            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
            webrequest.Method = "POST";

            webrequest.ContentType = "application/json; charset=utf-8";
            webrequest.Headers.Add("accept", "application/json");

            byte[] postBytes = Encoding.UTF8.GetBytes(methodCallParametersJson);
            Console.WriteLine(methodCallParametersJson);
            webrequest.ContentLength = postBytes.Length;
            Stream requestStream = webrequest.GetRequestStream();
            requestStream.Write(postBytes, 0, postBytes.Length);
            requestStream.Close();

            HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();

            Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader responseStream = new StreamReader(webresponse.GetResponseStream(), enc);
            string result = string.Empty;
            result = responseStream.ReadToEnd();
            responseStream.Close();

            webresponse.Close();

            return result;
        }
    }
}
