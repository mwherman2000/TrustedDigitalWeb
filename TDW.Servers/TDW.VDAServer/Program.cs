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

namespace TDW.VDAServer
{
    class VDAServer
    {
        public unsafe static void Main(string[] args)
        {
            TrinityConfig.HttpPort = 8082;
#pragma warning disable CS0612 // Type or member is obsolete
            TrinityConfig.ServerPort = 5304 + 2;
#pragma warning restore CS0612 // Type or member is obsolete
            ;
            TDWVerifiableDataRegistryServer registryServer = new TDWVerifiableDataRegistryServer();
            registryServer.Start();

            Console.WriteLine("Press any key to exit TDWVerifableRegistryServer...");
            Console.ReadLine();
        }
    }
}

