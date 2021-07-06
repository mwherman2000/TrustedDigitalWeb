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
using Trinity.Configuration;
using TDW.TRACommon;

namespace TDW.KMAServer
{
    class KMAServer
    {
        public unsafe static void Main(string[] args)
        {
            TrinityConfig.HttpPort = 8080 + 1;
#pragma warning disable CS0612 // Type or member is obsolete
            TrinityConfig.ServerPort = 5304 + 1;
#pragma warning restore CS0612 // Type or member is obsolete

            TDWKMAServer kmsServer = new TDWKMAServer();
            kmsServer.Start();

            //Global.LocalStorage.ResetStorage();
            //Global.LocalStorage.SaveStorage();
            
            var rc = Global.LocalStorage.LoadStorage();
            Console.WriteLine("CellCount:\t" + Global.LocalStorage.CellCount);
            Console.WriteLine("ServerCount:\t" + Global.ServerCount);

            var cells = from cell in Global.LocalStorage.GenericCell_Selector()
                        where (cell.TypeName == "KMAKeyPair")
                        select new { id = cell.CellId, celltype = cell.CellType, type = cell.Type, typeName = cell.TypeName };
            Console.WriteLine("Count: " + cells.Count());
            foreach (var cell in cells)
            {
                Console.WriteLine(cell.id.ToString() + "\t" + cell.GetType().ToString() + "\t" + cell.celltype.ToString()
                    + "\t" + cell.type.ToString() + "\t" + cell.typeName);
            }

            long keyringid = 1001;
            string keyringudid = TRAUDIDHelpers.TRAUDIDFormat(TRAMethodNames.TRAKeyRingMethodName, keyringid);
            var selected = (from cell in Global.LocalStorage.KMAKeyPair_Selector()
                            where (cell.keyringudid == keyringudid && cell.keypairtype == KMAKeyPairType.Hybrid)
                            select new { id = cell.CellId, keypairtype = cell.keypairtype }).Take(1); 
            Console.WriteLine("Count: " + selected.Count());
            var selectedKeypair = selected.FirstOrDefault();
            Console.WriteLine(selectedKeypair.id.ToString() + "\t" + selectedKeypair.keypairtype.ToString()); 

            if (Global.LocalStorage.CellCount == 0)
            {
                for (int i = 0; i < Global.ServerCount; i++)
                {
                    Global.CloudStorage.InitializeMasterKeyVaultToTDWKMAService(i, new KMAInitializeMasterKeyVaultRequestWriter(null));
                }
            }

            Console.WriteLine("Press any key to exit TDWKMAServer...");
            Console.ReadLine();
        }
    }
}

