using System;
using System.Collections.Generic;
using System.Text;
using Stratis.SmartContracts; // Address

namespace TDW.VDAStratisHelpers
{
    public class TDWVDAStratisHelpers
    {
        //////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Common structures for VDA Smart Contract and Stratis VDAHelpers library:
        /// TDW.VDASmartContract/TDWVDASmartContract.cs and TDW.VDAServer/TDWVDAStratisHelpers.cs
        /// </summary>

        public struct UIREntry // Universal Identifier Registry (UIR) Entry
        {
            public string identifierudid;
            public string credserviceendpointudid;
            public string credsignaturehash16;
            public Address requesteraddress;
            public string requesterudid;
            public long registeredticks;
            public string message;
        }

        public struct SEPREntry // Service Endpoint Registry (SEPR) Entry
        {
            public string serviceendpointudid;
            public string serviceendpointurl;
            public long serviceendpointport;
            public Address requesteraddress;
            public string requesterudid;
            public long registeredticks;
            public string message;
        }

        public struct RevocationListEntry // Revocation List Entry
        {
            public string credudid;
            public string serviceendpointudid;
            public Address revokeraddress;
            public string revokerudid;
            public long revokedticks;
            public string message;
        }

        //////////////////////////////////////////////////////////////////////////////

    }
}
