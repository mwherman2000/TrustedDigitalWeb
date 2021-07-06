using System;
using System.Text;
using Multiformats.Base;
using TDW.TRACommon;
using TDW.VDAStratisHelpers;
using Base58Check;
using System.Numerics;
using Newtonsoft.Json;

namespace TDW.VDATester
{
    class Program
    {
        static void Main(string[] args)
        {
            string serviceEndpoint = "http://localhost:38223";
            string contractAddress = "PXkGf3wzCrYXXtWauDqk8HVZLfQcGvef4v";

            string walletName = "cirrusdev";
            string walletPassword = "password";
            string senderAddress = "PSArhaZGEpG4QCkFzFQswRurzAxRt6dhDA";
            string accountName = "account 0";

            {
                string methodName2 = "HelloWorld";
                string methodParametersJson2 = "{}";

                string resultCall2 = TDWVDAStratisDriver.CallContractMethodOld(serviceEndpoint, contractAddress,
                    walletName, walletPassword, senderAddress,
                    methodName2, methodParametersJson2);
                Console.WriteLine(resultCall2);

                var json2 = JsonConvert.DeserializeObject<dynamic>(resultCall2);
                string txid2 = json2.transactionId;
                Console.WriteLine("txid: " + txid2);

                string resultWait2 = TDWVDAStratisDriver.WaitforCallReceipt(serviceEndpoint, txid2);
                Console.WriteLine(resultWait2);

                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                Console.WriteLine();
            }

            {
                string methodName2 = "HelloWorld";
                Console.WriteLine(methodName2);
                string methodCallParametersJson2 = "{" +
                    " \"walletName\": \"" + walletName + "\"," +
                    " \"contractAddress\": \"" + contractAddress + "\"," +
                    " \"methodName\": \"" + methodName2 + "\"," +
                    " \"amount\": \"0\"," +
                    " \"password\": \"" + walletPassword + "\"," +
                    " \"sender\": \"" + senderAddress + "\"," +
                    " \"accountName\": \"" + accountName + "\"," +
                    " \"outpoints\": null," +
                    " \"feeAmount\": \"0.001\"," +
                    " \"gasPrice\": 100," +
                    " \"gasLimit\": 100000," +
                    " \"parameters\": null" +
                    " }";
                Console.WriteLine("methodCallParametersJson:\r\n" + methodCallParametersJson2);
                string resultCall2 = TDWVDAStratisDriver.BuildAndCallContractMethod(serviceEndpoint, methodCallParametersJson2);
                Console.WriteLine(resultCall2);

                var json2 = JsonConvert.DeserializeObject<dynamic>(resultCall2);
                string txid2 = json2.transactionId;
                Console.WriteLine("txid: " + txid2);

                string resultWait2 = TDWVDAStratisDriver.WaitforCallReceipt(serviceEndpoint, txid2);
                Console.WriteLine(resultWait2);

                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                Console.WriteLine();
            }

            {
                string methodName2 = "SenderAddress";
                Console.WriteLine(methodName2);
                string methodCallParametersJson2 = "{" +
                    " \"contractAddress\": \"" + contractAddress + "\"," +
                    " \"methodName\": \"" + methodName2 + "\"," +
                    " \"amount\": \"0\"," +
                    " \"gasPrice\": 100," +
                    " \"gasLimit\": 100000," +
                    " \"sender\": \"" + senderAddress + "\"," +
                    " \"parameters\": null" +
                    " }";
                Console.WriteLine("methodCallParametersJson:\r\n" + methodCallParametersJson2);
                string resultCall2 = TDWVDAStratisDriver.LocalCallContractMethod(serviceEndpoint, methodCallParametersJson2);
                Console.WriteLine(resultCall2);
                Console.WriteLine();
            }

            {
                string methodName2 = "GetSenderAddress";
                Console.WriteLine(methodName2);
                string methodCallParametersJson2 = "{" +
                    " \"contractAddress\": \"" + contractAddress + "\"," +
                    " \"methodName\": \"" + methodName2 + "\"," +
                    " \"amount\": \"0\"," +
                    " \"gasPrice\": 100," +
                    " \"gasLimit\": 100000," +
                    " \"sender\": \"" + senderAddress + "\"," +
                    " \"parameters\": null" +
                    " }";
                Console.WriteLine("methodCallParametersJson:\r\n" + methodCallParametersJson2);
                string resultCall2 = TDWVDAStratisDriver.LocalCallContractMethod(serviceEndpoint, methodCallParametersJson2);
                Console.WriteLine(resultCall2);
                Console.WriteLine();
            }

            {
                string methodName2 = "NewRevocationEntry";
                Console.WriteLine(methodName2);
                string methodCallParametersJson2 = "{" +
                    " \"contractAddress\": \"" + contractAddress + "\"," +
                    " \"methodName\": \"" + methodName2 + "\"," +
                    " \"amount\": \"0\"," +
                    " \"gasPrice\": 100," +
                    " \"gasLimit\": 100000," +
                    " \"sender\": \"" + senderAddress + "\"," +
                    " \"parameters\": null" +
                    " }";
                Console.WriteLine("methodCallParametersJson:\r\n" + methodCallParametersJson2);
                string resultCall2 = TDWVDAStratisDriver.LocalCallContractMethod(serviceEndpoint, methodCallParametersJson2);
                Console.WriteLine(resultCall2);
                Console.WriteLine();
            }

            {
                string methodName2 = "NewRevocationEntryJson";
                Console.WriteLine(methodName2);
                string methodCallParametersJson2 = "{" +
                    " \"contractAddress\": \"" + contractAddress + "\"," +
                    " \"methodName\": \"" + methodName2 + "\"," +
                    " \"amount\": \"0\"," +
                    " \"gasPrice\": 100," +
                    " \"gasLimit\": 100000," +
                    " \"sender\": \"" + senderAddress + "\"," +
                    " \"parameters\": null" +
                    " }";
                Console.WriteLine("methodCallParametersJson:\r\n" + methodCallParametersJson2);
                string resultCall2 = TDWVDAStratisDriver.LocalCallContractMethod(serviceEndpoint, methodCallParametersJson2);
                Console.WriteLine(resultCall2);
                Console.WriteLine();
            }

            {
                string methodName2 = "NewRevocationEntryBytes";
                Console.WriteLine(methodName2);
                string methodCallParametersJson2 = "{" +
                    " \"contractAddress\": \"" + contractAddress + "\"," +
                    " \"methodName\": \"" + methodName2 + "\"," +
                    " \"amount\": \"0\"," +
                    " \"gasPrice\": 100," +
                    " \"gasLimit\": 100000," +
                    " \"sender\": \"" + senderAddress + "\"," +
                    " \"parameters\": null" +
                    " }";
                Console.WriteLine("methodCallParametersJson:\r\n" + methodCallParametersJson2);
                string resultCall2 = TDWVDAStratisDriver.LocalCallContractMethod(serviceEndpoint, methodCallParametersJson2);
                Console.WriteLine(resultCall2);
                Console.WriteLine();
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();

            string address = senderAddress;
            Console.WriteLine(address);
            string byteshex = "C0D8E0219C68139423AEF62123E91D4998F035C4";
            Console.WriteLine(byteshex);

            int discarded;
            byte[] bytes = TRAByteHelpers.GetBytes(byteshex, out discarded);
            string encoded = Multibase.Encode(MultibaseEncoding.Base58Btc, bytes);
            Console.WriteLine(encoded);

            string base58checkplain = Base58Check.Base58CheckEncoding.EncodePlain(bytes);
            Console.WriteLine(base58checkplain);

            string base58check = Base58Check.Base58CheckEncoding.Encode(bytes);
            Console.WriteLine(base58check);

            BigInteger bi = new BigInteger(bytes);
            Console.WriteLine(bi.ToString());

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();

            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
    }
}
