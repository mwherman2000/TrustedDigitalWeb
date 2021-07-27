// Graph Engine
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Trinity;
using Trinity.Storage;

using TDW.TRACommon;
using TDW.KMAServer;
using Trinity.Core.Lib;

namespace TDW.TRAServer
{
    class TRAServer
    {
        public unsafe static void Main(string[] args)
        {
            TRACredential_Cell udiddoc;

            //Global.LocalStorage.ResetStorage();
            //Global.LocalStorage.SaveStorage();
            var rc = Global.LocalStorage.LoadStorage();

            Console.WriteLine("CellCount: " + Global.LocalStorage.CellCount);
            if (Global.LocalStorage.CellCount == 0)
            {
                List<string> context = new List<string> { "https://www.sovrona.com/ns/svrn/v1" };
                List<TRAClaim> claims = new List<TRAClaim>();
                claims.Add(new TRAClaim("testkey1", "testvalue1"));
                claims.Add(new TRAClaim("authentication", null,
                    new List<TRAKeyValuePair> {
                    new TRAKeyValuePair( "publicKey", "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ"),
                    new TRAKeyValuePair( "id", "#pubkey1"),
                    new TRAKeyValuePair( "type", "AUTHN-KEY")
                }));
                claims.Add(new TRAClaim("service", null,
                    new List<TRAKeyValuePair> {
                    new TRAKeyValuePair( "serviceEndPoint", "http://localhost:5304/"),
                    new TRAKeyValuePair( "id", "#sep1"),
                    new TRAKeyValuePair( "type", "SEP-TRA")
                }));

                List<TRAKeyValuePair> value1 = new List<TRAKeyValuePair> {
                        new TRAKeyValuePair( "publicKey", "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ"),
                        new TRAKeyValuePair( "id", "#pubkey1"),
                        new TRAKeyValuePair( "type", "AUTHN-KEY")
                };
                List<TRAKeyValuePair> value2 = new List<TRAKeyValuePair> {
                        new TRAKeyValuePair( "publicKey", "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ"),
                        new TRAKeyValuePair( "id", "#pubkey2"),
                        new TRAKeyValuePair( "type", "AUTHN-KEY")
                };
                List<List<TRAKeyValuePair>> pairslist = new List<List<TRAKeyValuePair>>{value1, value2};
                TRAClaim testclaim3 = new TRAClaim("testkey3", null, null, pairslist);
                claims.Add(testclaim3);

                long id = CellIdFactory.NewCellId();
                string udid = TRAUDIDHelpers.TRAUDIDFormat(TRAMethodNames.TRACredentialMethodName, id);

                TRACredential_Cell Alice = new TRACredential_Cell(id, default, default);

                Alice.envelope.content = new TRACredential_EnvelopeContent(udid, context, claims: claims);
                Alice.envelope.label = new TRACredential_EnvelopeLabel(TRACredentialType.UDIDDocument, 1, TRATrustLevel.SignedHashSignature, TRAEncryptionFlag.Encrypted, default);
                Alice.envelopeseal = new TRACredential_EnvelopeSeal( "<hash64>", "<signature>", "<notarystamp>" );
                Alice.envelopeseal.comments = new List<string> { "Alice's UDID Document", 
                    "It works!", 
                    "Created by TDW.TRAServer at " + DateTime.Now.ToString("u") };

                Global.LocalStorage.SaveTRACredential_Cell(Alice);
                
                udiddoc = Alice;

                Console.WriteLine(Alice.CellId.ToString() + "\t" + BitConverter.GetBytes(Alice.CellId).Length
                        + "\t" + TRAUDIDHelpers.TRAUDIDFormat(TRAMethodNames.TRACredentialMethodName, Alice.CellId));

                Global.LocalStorage.SaveStorage();
            }
            Console.WriteLine("CellCount: " + Global.LocalStorage.CellCount);

            TrinityConfig.HttpPort = 8080;
            TRAResourceServer resourceServer = new TRAResourceServer();
            resourceServer.Start();

            Console.WriteLine("Press any key to exit TRAResourceServer...");
            Console.ReadLine();
        }
    }
}

