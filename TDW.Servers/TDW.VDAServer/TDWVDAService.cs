using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using TDW.KMAServer;
using TDW.TRACommon;
using Trinity;
using Trinity.Storage;

namespace TDW.VDAServer
{
    public class TDWVerifiableDataRegistryServer : TDWVerifiableDataRegistryAgentBase
    {
        public override void GetAccountRegistryEntryHandler(TDWGetAccountRegistryEntryRequest request, out TDWGetAccountRegistryEntryResponse response)
        {
            throw new NotImplementedException();
        }

        public override void GetSmartContractRegistryEntryHandler(TDWGetSmartContractRegistryEntryRequest request, out TDWGetSmartContractRegistryEntryResponse response)
        {
            throw new NotImplementedException();
        }

        public override void GetVDAPostResultHandler(TDWGetVDAPostResultRequest request, out TDWGetVDAPostResultResponse response)
        {
            throw new NotImplementedException();
        }

        public override void IsCredentialRevokedHandler(TDWIsCredentialRevokedRequest request, out TDWIsCredentialRevokedResponse response)
        {
            throw new NotImplementedException();
        }

        public override void IsCredentialValidHandler(TDWIsCredentialValidRequest request, out TDWIsCredentialValidResponse response)
        {
            throw new NotImplementedException();
        }

        public override void IsCredentialVerifiedHandler(TDWIsCredentialVerifiedRequest request, out TDWIsCredentialVerifiedResponse response)
        {
            throw new NotImplementedException();
        }

        public override void SaveAccountRegistryEntryHandler(TDWSaveAccountRegistryEntryRequest request, out TDWSaveAccountRegistryEntryResponse response)
        {
            throw new NotImplementedException();
        }

        public override void SaveSmartContractRegistryEntryHandler(TDWSaveSmartContractRegistryEntryRequest request, out TDWSaveSmartContractRegistryEntryResponse response)
        {
            throw new NotImplementedException();
        }

        public override void PostVDAIdentityRegistryEntryHandler(TDWPostVDAIdentityRegistryEntryRequest request, out TDWPostResponse response)
        {
            throw new NotImplementedException();
        }

        public override void PostVDARevocationListEntryHandler(TDWPostVDARevocationListEntryRequest request, out TDWPostResponse response)
        {
            throw new NotImplementedException();
        }

        public override void PostVDAServiceEndpointEntryHandler(TDWPostVDAIdentityRegistryEntryRequest request, out TDWPostResponse response)
        {
            throw new NotImplementedException();
        }
    }
}
