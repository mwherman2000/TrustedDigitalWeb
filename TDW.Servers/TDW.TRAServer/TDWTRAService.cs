using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using TDW.KMAServer;
using TDW.TRACommon;
using Trinity;
using Trinity.Core.Lib;
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
            using (var credential = Global.LocalStorage.UseTRACredential_Cell(id))
            {
                byte[] credbytes = credential.ToByteArray();
                byte[] hashedValue = TRACryptoHashHelpers.ComputeHash(credbytes);
                credential.envelopeseal.hashedThumbprint64 = BitConverter.ToString(hashedValue);
            }

            response.rc = (long)TrinityErrorCode.E_SUCCESS;
            response.id = id;
            response.messages = new List<string> { "success", "SignHashThumbprintTDWCredentialHandler" };
        }

        public override void SignSignatureTDWCredentialHandler(TDWProcessCredentialRequestReader request, TDWCredentialResponseWriter response)
        {
            long id = request.id;
            using (var udiddoc = Global.LocalStorage.UseTRACredential_Cell(id))
            {
                byte[] credbytes = udiddoc.ToByteArray();
                byte[] hashedValue = TRACryptoHashHelpers.ComputeHash(credbytes);
                udiddoc.envelopeseal.hashedThumbprint64 = BitConverter.ToString(hashedValue);
            }

            response.rc = (long)TrinityErrorCode.E_SUCCESS;
            response.id = id;
            response.messages = new List<string> { "success", "SignSignatureTDWCredentialHandler" };
        }

        public override void NotarizeTDWCredentialHandler(TDWProcessCredentialRequestReader request, TDWCredentialResponseWriter response)
        {
            long id = request.id;
            using (var udiddoc = Global.LocalStorage.UseTRACredential_Cell(id))
            {
                udiddoc.envelopeseal.notaryStamp = "<NotaryStamp>NOTARIZED</NotaryStamp>";
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

            long id = CellIdFactory.NewCellId();
            string udid = TRAUDIDHelpers.TRAUDIDFormat(TRAMethodNames.TRACredentialMethodName, id);

            TRACredential_EnvelopeContent content = new TRACredential_EnvelopeContent(udid, context, claims: claims);

            var credential = new TRACredential_Cell(id, default, default);
            credential.envelope.content = content;
            credential.envelope.label = new TRACredential_PackingLabel(default, 1, default, default, default);
            credential.envelopeseal = new TRACredential_EnvelopeSeal(null, null, null, comments);

            Console.WriteLine(JsonConvert.SerializeObject(credential));

            var rc = TDWTRACredentialHelpers.HashAndSignTDWCredential(ref credential, trustLevel, keypairsalt);

            Global.LocalStorage.SaveTRACredential_Cell(credential);
            Console.WriteLine(JsonConvert.SerializeObject(credential));

            response.id = credential.CellId;
            response.udid = udid;
            response.rc = (long)TrinityErrorCode.E_SUCCESS;
            response.messages = new List<string> { "success", "CreateTDWCredentialHandler" };
        }
    }
}
