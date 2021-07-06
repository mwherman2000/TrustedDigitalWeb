using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using TDW.TRACommon;
using Trinity;
using Trinity.Core.Lib;
using Trinity.Storage;

namespace TDW.KMAServer
{
    public class TDWKMAServer : TDWKMAServiceBase
    {
        public TDWKMAServer()
        {
        }

        public override void InitializeMasterKeyVaultHandler(KMAInitializeMasterKeyVaultRequestReader request)
        {

            Global.LocalStorage.LoadStorage();
            if (Global.LocalStorage.CellCount == 0)
            {
                Console.WriteLine("Adding new Master Key...");
                TRACryptoSymmetricHelpers.AddNewMasterKey(false);
            }
            else
            {
                Console.WriteLine("Skipping add new Master Key...");
            }

            // No need to save/propogate newKey because we always pick the newest, unrevoked key to use.
        }

        public override void CreateKeyPairHandler(KMACreateKeyPairRequest request, out KMAKeyPairResponse response) // in the KMA store 
        {
            string udid;
            string keypairsalt;
            string keyringudid;
            KMAKeyPairType keypairtype;

            keypairsalt = request.keypairsalt;
            keyringudid = request.keyringudid;
            keypairtype = request.keypairtype;


            long id = CellIdFactory.NewCellId();
            KMAKeyPair cellKeyPair = new KMAKeyPair(id, (udid = TRAUDIDHelpers.TRAUDIDFormat(TRAMethodNames.TRAKeyPairMethodName, id)),
                keyringudid, keypairtype, "", 0, "", ""); // info);
            byte[] encrytedXmlKeyPair;
            string xmlPublicKey;
            string alg;
            long keysize;
            long rc = TRACryptoAsymmetricHelpers.CreateKeyPair(Encoding.UTF8.GetBytes(keypairsalt), out encrytedXmlKeyPair, out xmlPublicKey, out alg, out keysize );
            cellKeyPair.encryptedkeypair64 = TRAByteHelpers.ToBase64String(encrytedXmlKeyPair);
            cellKeyPair.publickey = xmlPublicKey;
            cellKeyPair.algorithm = alg;
            cellKeyPair.keysize = keysize;

            Global.LocalStorage.SaveKMAKeyPair(cellKeyPair);
            Global.LocalStorage.SaveStorage();

            response.id = id;
            response.udid = udid;
            response.rc = (long)TrinityErrorCode.E_SUCCESS;
            response.messages = new List<string> { "success", "CreateKeyPairHandler" };

            Console.WriteLine("id out:\t" + response.id.ToString());
        }

        public override void ComputePayloadHashHandler(KMAComputePayloadHashRequest request, out KMAPayloadHashResponse response)
        {
            string payload64;

            byte[] hash = default;

            payload64 = request.payload64;
            Console.WriteLine("payload64 in:\t" + payload64);

            byte[] payload = Convert.FromBase64String(payload64);
            Console.WriteLine("payload in:\t" + BitConverter.ToString(payload));
            hash = TRACryptoHashHelpers.ComputeHash(payload);
            Console.WriteLine("hash out:\t" + BitConverter.ToString(hash));

            response.rc = (long)TrinityErrorCode.E_SUCCESS;
            response.messages = new List<string> { "success", "ComputePayloadHashHandler" };
            response.hash64 = TRAByteHelpers.ToBase64String(hash);
            Console.WriteLine("hash64 out:\t" + response.hash64);
        }

        public override void ComputeHashKeyPairSignatureHandler(KMAComputeHashKeyPairSignatureRequest request, out KMAHashKeyPairSignatureResponse response)
        {
            long keypairid;
            string keypairsalt;
            string hash64;

            byte[] signature = default;

            keypairid = request.keypairid;
            keypairsalt = request.keypairsalt;
            hash64 = request.hash64;

            Console.WriteLine("keypairid in:\t" + keypairid.ToString());
            KMAKeyPair cellKeyPair = Global.LocalStorage.LoadKMAKeyPair(keypairid);

            // Compute digital signature and return it
            byte[] hash = Convert.FromBase64String(hash64);
            byte[] encrytedXmlKeyPair = TRAByteHelpers.FromBase64String(cellKeyPair.encryptedkeypair64);
            signature = TRACryptoAsymmetricHelpers.ComputeHashKeyPairSignature(hash, encrytedXmlKeyPair, Encoding.UTF8.GetBytes(keypairsalt));
            string signature64 = TRAByteHelpers.ToBase64String(signature);

            response.rc = (long)TrinityErrorCode.E_SUCCESS;
            response.messages = new List<string> { "success", "ComputeHashKeyPairSignatureHandler" };
            response.signature64 = signature64;
        }

        public override void ValidateHashKeyPairSignatureHandler(KMAValidateHashKeyPairSignatureRequest request, out KMAValidateHashKeyPairSignatureResponse response)
        {
            long keypairid;
            string keypairsalt;
            string hash64;
            string signature64;

            bool valid = false;

            keypairid = request.keypairid;
            keypairsalt = request.keypairsalt;
            hash64 = request.hash64;
            signature64 = request.signature64;

            Console.WriteLine("keypairid in:\t" + keypairid.ToString());
            KMAKeyPair cellKeyPair = Global.LocalStorage.LoadKMAKeyPair(keypairid);

            // Compute digital signature and return it
            try
            {
                byte[] hash = Convert.FromBase64String(hash64);
                byte[] signature = Convert.FromBase64String(signature64);
                byte[] encrytedXmlKeyPair = TRAByteHelpers.FromBase64String(cellKeyPair.encryptedkeypair64);
                valid = TRACryptoAsymmetricHelpers.ValidateDigitalSignature(hash, signature, encrytedXmlKeyPair, Encoding.UTF8.GetBytes(keypairsalt));

                response.rc = (long)TrinityErrorCode.E_SUCCESS;
                response.messages = new List<string> { "success", "ValidateHashKeyPairSignatureHandler" };
                response.valid = valid;
            }
            catch (FormatException ex)
            {
                response.rc = (long)TrinityErrorCode.E_INVALID_ARGUMENTS;
                response.messages = new List<string> { "failure", "ValidateHashKeyPairSignatureHandler", ex.Message };
                response.valid = false;
            }
            catch (Exception ex)
            {
                response.rc = (long)TrinityErrorCode.E_FAILURE;
                response.messages = new List<string> { "failure", "ValidateHashKeyPairSignatureHandler", ex.Message };
                response.valid = false;
            }
        }

        public override void GetBestKeyPairHandler(KMAGetBestKeyPairRequest request, out KMAKeyPairResponse response)
        {
            string keyringid = request.keyringudid;
            KMAKeyPairType keypairtype = request.keypairtype;

            KMAKeyPair keypair = TDWKMALocalHelpers.GetBestKeyPair(keyringid, keypairtype);

            response.id = keypair.CellId;
            response.udid = keypair.udid;
            response.rc = (long)TrinityErrorCode.E_SUCCESS;
            response.messages = new List<string> { "success", "GetBestKeyPairHandler" };

            Console.WriteLine("id out:\t" + response.id.ToString());
        }
    }
}
