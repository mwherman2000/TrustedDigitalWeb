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

            DateTime now = DateTime.Now;
            string notaryudid = TRAUDIDHelpers.TRAUDIDFormat(TRAMethodNames.TRACredentialMethodName, 1234);

            {
                long id = CellIdFactory.NewCellId();
                string udid = TRAUDIDHelpers.TRAUDIDFormat(TRAMethodNames.TRACredentialMethodName, id);

                TRATimestamp_Cell tsCell = new TRATimestamp_Cell(id, new TRATimestamp_Envelope(), new TRACredential_EnvelopeSeal());
                TRATimestamp_Claims tsclaims = new TRATimestamp_Claims(now.Ticks, now, now.ToString("u"));
                tsCell.envelope.content = new TRATimestamp_EnvelopeContent(udid, TRAContexts.DefaultContext, claims: tsclaims);
                tsCell.envelope.label = new TRACredential_EnvelopeLabel(TRACredentialType.NotarizedCredential, 1, TRATrustLevel.SignedHashSignature,
                                                                     TRAEncryptionFlag.NotEncrypted, notaryudid, "Timestamp1", "My timestamp");
                Global.LocalStorage.SaveTRATimestamp_Cell(tsCell);

                // TODO Process Trust Level
            }

            {
                long Doc1_cac_ExternalReferenceId = CellIdFactory.NewCellId();
                string Doc1_cac_ExternalReferenceUdid = TRAUDIDHelpers.TRAUDIDFormat(TRAMethodNames.TRACredentialMethodName, Doc1_cac_ExternalReferenceId);
                long Doc2_cac_ExternalReferenceId = CellIdFactory.NewCellId();
                string Doc2_cac_ExternalReferenceUdid = TRAUDIDHelpers.TRAUDIDFormat(TRAMethodNames.TRACredentialMethodName, Doc2_cac_ExternalReferenceId);
                long cac_AccountingSupplierPartyId = CellIdFactory.NewCellId();
                string cac_AccountingSupplierPartyUdid = TRAUDIDHelpers.TRAUDIDFormat(TRAMethodNames.TRACredentialMethodName, cac_AccountingSupplierPartyId);
                long cac_AccountingCustomerPartyId = CellIdFactory.NewCellId();
                string cac_AccountingCustomerPartyUdid = TRAUDIDHelpers.TRAUDIDFormat(TRAMethodNames.TRACredentialMethodName, cac_AccountingCustomerPartyId);
                long cac_PartyPartyId = CellIdFactory.NewCellId();
                string cac_PartyPartyUdid = TRAUDIDHelpers.TRAUDIDFormat(TRAMethodNames.TRACredentialMethodName, cac_PartyPartyId);
                long cac_AddressId = CellIdFactory.NewCellId();
                string cac_AddressUdid = TRAUDIDHelpers.TRAUDIDFormat(TRAMethodNames.TRACredentialMethodName, cac_AddressId);
                long cac_PaymentMeansId = CellIdFactory.NewCellId();
                string cac_PaymentMeansUdid = TRAUDIDHelpers.TRAUDIDFormat(TRAMethodNames.TRACredentialMethodName, cac_PaymentMeansId);

                long invoiceLineItem1Id = CellIdFactory.NewCellId();
                string invoiceLineItem1Udid = TRAUDIDHelpers.TRAUDIDFormat(TRAMethodNames.TRACredentialMethodName, invoiceLineItem1Id);
                long invoiceLineItem2Id = CellIdFactory.NewCellId();
                string invoiceLineItem2Udid = TRAUDIDHelpers.TRAUDIDFormat(TRAMethodNames.TRACredentialMethodName, invoiceLineItem2Id);
                long invoiceLineItem3Id = CellIdFactory.NewCellId();
                string invoiceLineItem3Udid = TRAUDIDHelpers.TRAUDIDFormat(TRAMethodNames.TRACredentialMethodName, invoiceLineItem3Id);
                long invoiceLineItem4Id = CellIdFactory.NewCellId();
                string invoiceLineItem4Udid = TRAUDIDHelpers.TRAUDIDFormat(TRAMethodNames.TRACredentialMethodName, invoiceLineItem4Id);
                long invoiceLineItem5Id = CellIdFactory.NewCellId();
                string invoiceLineItem5Udid = TRAUDIDHelpers.TRAUDIDFormat(TRAMethodNames.TRACredentialMethodName, invoiceLineItem5Id);

                UBL21_Invoice2_Claims invoiceClaims = new UBL21_Invoice2_Claims(
                    UBL21Helpers.UBLVersionID, 
                    cbc_ID: "TOSL108", 
                    cbc_IssueDate: new DateTime(2009, 12, 15),
                    new Cbc_ListCode("Un/ECE 100 Subset", "6", "308"), 
                    new Cbc_Note(ISO639_1_LanguageCodes.en, "Ordered in our booth at the convention."), 
                    cbc_TaxPointDate: new DateTime(2009, 11, 30), 
                    cbc_DocumentCurrencyCode: new Cbc_ListCode("ISO 4217 Alpha", "6", "EUR"), 
                    "Project cost code 123",
                    cbc_InvoicePeriod: new Cbc_TimePeriod(new DateTime(2009, 11, 1), new DateTime(2009, 11, 30)), 
                    new Cbc_OrderReference("123"),
                    cac_ContractDocumentReference: new Cac_DocumentReference("321", "Framework Agreement"),
                    cac_AdditionalDocumentReferences: new List<Cac_DocumentReference>
                    {
                        new Cac_DocumentReference("Doc1", "Timesheet", new Cac_Attachment(Doc1_cac_ExternalReferenceUdid)),
                        new Cac_DocumentReference("Doc2", "Drawing", new Cac_Attachment(Doc2_cac_ExternalReferenceUdid))
                    },
                    new Cac_AccountingSupplierParty(cac_AccountingSupplierPartyUdid),
                    new Cac_AccountingCustomerParty(cac_AccountingCustomerPartyUdid),
                    new Cac_PayeeParty(cac_PartyPartyUdid),
                    new Cac_Delivery(new DateTime(2009, 12, 15),
                        new Cac_DeliveryLocation(
                            new Cbc_SchemeCode("GLN", "9", "6754238987648"),
                            cac_AddressUdid)
                        ),
                    cac_PaymentMeansUdid,
                    new Cac_PaymentTerms(new Cbc_Note(ISO639_1_LanguageCodes.en, "Penalty percentage 10% from due date")),
                    new List<Cac_AllowanceCharge>
                    {
                        new Cac_AllowanceCharge(true, "Packing cost", new Cbc_Amount("EUR", 100)),
                        new Cac_AllowanceCharge(false, "Promotion discount", new Cbc_Amount("EUR", 100))
                    },
                    new Cac_TaxTotal(new Cbc_Amount("EUR", 292.20),
                    new List<Cac_TaxSubtotal>
                    {

                    }),
                    new Cac_LegalMonetaryTotal(
                        cbc_LineExtensionAmount: new Cbc_Amount("EUR", 1436.5),
                        cbc_TaxExclusiveAmount: new Cbc_Amount("EUR", 1436.5),
                        cbc_TaxInclusiveAmount: new Cbc_Amount("EUR", 1729),
                        cbc_AllowanceTotalAmount: new Cbc_Amount("EUR", 100),
                        cbc_ChargeTotalAmount: new Cbc_Amount("EUR", 100),
                        cbc_PrepaidAmount: new Cbc_Amount("EUR", 1000),
                        cbc_PayableRoundingAmount: new Cbc_Amount("EUR", 0.30),
                        cbc_PayableAmount: new Cbc_Amount("EUR", 729)
                    ),
                    new List<Cac_InvoiceLine>
                    {
                        new Cac_InvoiceLine(
                            cbc_ID: "1", 
                            new Cbc_Note(ISO639_1_LanguageCodes.en, "Scratch on box"),
                            cbc_InvoicedQuantity: new Cbc_Quantity("C62", 1),
                            cbc_LineExtensionAmount: new Cbc_Amount("EUR", 1273),
                            cbc_AccountingCost: "BookingCode",
                            new Cac_OrderLineReference("1"),
                            new List<Cac_AllowanceCharge>
                            {
                                new Cac_AllowanceCharge(false, "Damage", new Cbc_Amount("EUR", 12)),
                                new Cac_AllowanceCharge(true, "Testing", new Cbc_Amount("EUR", 10))
                            },
                            new Cac_TaxTotal(new Cbc_Amount("EUR", 254.6)), 
                            invoiceLineItem1Udid,
                            new Cac_Price(cbc_PriceAmount: new Cbc_Amount("EUR", 3.96), cbc_BaseQuantity: new Cbc_Quantity("C62", 1))
                        ),
                        new Cac_InvoiceLine(
                            cbc_ID: "2",
                            new Cbc_Note(ISO639_1_LanguageCodes.en, "Scratch on box"),
                            cbc_InvoicedQuantity: new Cbc_Quantity("C62", 1),
                            cbc_LineExtensionAmount: new Cbc_Amount("EUR", 1273),
                            cbc_AccountingCost: "BookingCode",
                            new Cac_OrderLineReference("2"),
                            new List<Cac_AllowanceCharge>
                            {
                                new Cac_AllowanceCharge(false, "Damage", new Cbc_Amount("EUR", 12)),
                                new Cac_AllowanceCharge(true, "Testing", new Cbc_Amount("EUR", 10))
                            },
                            new Cac_TaxTotal(new Cbc_Amount("EUR", 254.6)),
                            invoiceLineItem2Udid,
                            new Cac_Price(cbc_PriceAmount: new Cbc_Amount("EUR", 3.96), cbc_BaseQuantity: new Cbc_Quantity("C62", 1))
                        ),
                        new Cac_InvoiceLine(
                            cbc_ID: "3",
                            new Cbc_Note(ISO639_1_LanguageCodes.en, "Scratch on box"),
                            cbc_InvoicedQuantity: new Cbc_Quantity("C62", 1),
                            cbc_LineExtensionAmount: new Cbc_Amount("EUR", 1273),
                            cbc_AccountingCost: "BookingCode",
                            new Cac_OrderLineReference("3"),
                            new List<Cac_AllowanceCharge>
                            {
                                new Cac_AllowanceCharge(false, "Damage", new Cbc_Amount("EUR", 12)),
                                new Cac_AllowanceCharge(true, "Testing", new Cbc_Amount("EUR", 10))
                            },
                            new Cac_TaxTotal(new Cbc_Amount("EUR", 254.6)),
                            invoiceLineItem3Udid,
                            new Cac_Price(cbc_PriceAmount: new Cbc_Amount("EUR", 3.96), cbc_BaseQuantity: new Cbc_Quantity("C62", 1))
                        ),
                        new Cac_InvoiceLine(
                            cbc_ID: "4",
                            new Cbc_Note(ISO639_1_LanguageCodes.en, "Scratch on box"),
                            cbc_InvoicedQuantity: new Cbc_Quantity("C62", 1),
                            cbc_LineExtensionAmount: new Cbc_Amount("EUR", 1273),
                            cbc_AccountingCost: "BookingCode",
                            new Cac_OrderLineReference("4"),
                            new List<Cac_AllowanceCharge>
                            {
                                new Cac_AllowanceCharge(false, "Damage", new Cbc_Amount("EUR", 12)),
                                new Cac_AllowanceCharge(true, "Testing", new Cbc_Amount("EUR", 10))
                            },
                            new Cac_TaxTotal(new Cbc_Amount("EUR", 254.6)),
                            invoiceLineItem4Udid,
                            new Cac_Price(cbc_PriceAmount: new Cbc_Amount("EUR", 3.96), cbc_BaseQuantity: new Cbc_Quantity("C62", 1))
                        ),
                                                new Cac_InvoiceLine(
                            cbc_ID: "5",
                            new Cbc_Note(ISO639_1_LanguageCodes.en, "Scratch on box"),
                            cbc_InvoicedQuantity: new Cbc_Quantity("C62", 1),
                            cbc_LineExtensionAmount: new Cbc_Amount("EUR", 1273),
                            cbc_AccountingCost: "BookingCode",
                            new Cac_OrderLineReference("5"),
                            new List<Cac_AllowanceCharge>
                            {
                                new Cac_AllowanceCharge(false, "Damage", new Cbc_Amount("EUR", 12)),
                                new Cac_AllowanceCharge(true, "Testing", new Cbc_Amount("EUR", 10))
                            },
                            new Cac_TaxTotal(new Cbc_Amount("EUR", 254.6)),
                            invoiceLineItem5Udid,
                            new Cac_Price(cbc_PriceAmount: new Cbc_Amount("EUR", 3.96), cbc_BaseQuantity: new Cbc_Quantity("C62", 1))
                        ),
                    }   
                );

                long invoiceId = CellIdFactory.NewCellId();
                string invoiceUdid = TRAUDIDHelpers.TRAUDIDFormat(TRAMethodNames.TRACredentialMethodName, invoiceId);
                UBL21_Invoice2_Cell invoiceCell = new UBL21_Invoice2_Cell(invoiceId, new UBL21_Invoice2_Envelope(), new TRACredential_EnvelopeSeal());
                invoiceCell.envelope.content = new UBL21_Invoice2_EnvelopeContent(invoiceUdid, UBL21Helpers.UBLDefaultContext, claims: invoiceClaims);
                invoiceCell.envelope.label = new TRACredential_EnvelopeLabel(
                        TRACredentialType.NotarizedCredential, 1, 
                        TRATrustLevel.SignedHashSignature,
                        TRAEncryptionFlag.NotEncrypted, notaryudid, "Timestamp1", "My timestamp");
                invoiceCell.envelopeseal = new TRACredential_EnvelopeSeal("<hash64>", "<signature>", "<notarystamp>");
                invoiceCell.envelopeseal.comments = new List<string> { "Sample UBL 2.1 Invoice Verifiable Credential",
                    "It works!",
                    "Created by TDW.TRAServer at " + DateTime.Now.ToString("u") };

                Global.LocalStorage.SaveUBL21_Invoice2_Cell(invoiceCell);
                // TODO Process Trust Level
            }

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
                    TDWCreateTDWCredentialRequest request = new TDWCreateTDWCredentialRequest(
                                                                TRACredentialType.UDIDDocument, context, null, 
                                                                claims: claims,
                                                                TRATrustLevel.SignedHashSignature, TRAEncryptionFlag.NotEncrypted, comments,                                    keypairsalt);
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
