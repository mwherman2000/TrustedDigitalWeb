using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using TDW.KMAServer;
using TDW.TRACommon;
using Trinity;
using Trinity.Storage;

namespace TDW.TRAServer
{
    public class TRAResourceServer : TRAResourceAgentBase
    {
        public TRAResourceServer()
        {
        }

        public override void SignHashThumbprintTDWCredentialHandler(TDWProcessCredentialRequestReader request, TDWCredentialResponseWriter response)
        {
            long id = request.id;
            using (var credential = Global.LocalStorage.UseTDWCredential(id))
            {
                byte[] credbytes = credential.ToByteArray();
                byte[] hashedValue = TRACryptoHashHelpers.ComputeHash(credbytes);
                credential.CredentialEnvelope.hashedThumbprint64 = BitConverter.ToString(hashedValue);
            }

            response.rc = (long)TrinityErrorCode.E_SUCCESS;
            response.id = id;
            response.messages = new List<string> { "success", "SignHashThumbprintTDWCredentialHandler" };
        }

        public override void SignSignatureTDWCredentialHandler(TDWProcessCredentialRequestReader request, TDWCredentialResponseWriter response)
        {
            long id = request.id;
            using (var udiddoc = Global.LocalStorage.UseTDWCredential(id))
            {
                byte[] credbytes = udiddoc.ToByteArray();
                byte[] hashedValue = TRACryptoHashHelpers.ComputeHash(credbytes);
                udiddoc.CredentialEnvelope.hashedThumbprint64 = BitConverter.ToString(hashedValue);
            }

            response.rc = (long)TrinityErrorCode.E_SUCCESS;
            response.id = id;
            response.messages = new List<string> { "success", "SignSignatureTDWCredentialHandler" };
        }

        public override void NotarizeTDWCredentialHandler(TDWProcessCredentialRequestReader request, TDWCredentialResponseWriter response)
        {
            long id = request.id;
            using (var udiddoc = Global.LocalStorage.UseTDWCredential(id))
            {
                udiddoc.CredentialEnvelope.notaryStamp = "<NotaryStamp>NOTARIZED</NotaryStamp>";
            }

            response.rc = (long)TrinityErrorCode.E_SUCCESS;
            response.id = id;
            response.messages = new List<string> { "success", "NotarizeTDWCredentialHandler" };
        }

        public override void CreateTDWCredentialHandler(TDWCreateTDWCredentialRequest request, out TDWCredentialResponse response)
        {
            var credtype = request.credtype;
            var context = request.context;
            var claims = request.claims;
            var trustLevel = request.trustlevel;
            var encyptionFlag = request.encryptionFlag;
            var comments = request.comments;
            var keypairsalt = request.keypairsalt;

            var credential = new TDWCredential(default, default, default);

            string udid = TRAUDIDHelpers.TRAUDIDFormat(TRAMethodNames.TRACredentialMethodName, credential.CellId);
            TRACredentialCore core = new TRACredentialCore(udid, context, claims);
            credential.CredentialContent.core = core;
            credential.CredentialContent.wrapper = new TRACredentialWrapper(default, default, default, 1, default);
            credential.CredentialEnvelope = new TRACredentialEnvelope(null, null, null, comments);
            Console.WriteLine(JsonConvert.SerializeObject(credential));

            var rc = TDWTRACredentialHelpers.HashAndSignTDWCredential(ref credential, trustLevel, keypairsalt);

            Global.LocalStorage.SaveTDWCredential(credential);
            Console.WriteLine(JsonConvert.SerializeObject(credential));

            response.id = credential.CellId;
            response.udid = udid;
            response.rc = (long)TrinityErrorCode.E_SUCCESS;
            response.messages = new List<string> { "success", "CreateTDWCredentialHandler" };
        }
    }
}
