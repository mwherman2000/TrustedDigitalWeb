using System;
using System.Collections.Generic;
using System.Text;
using Trinity;
using System.Linq;

namespace TDW.KMAServer
{
    public class TDWKMALocalHelpers
    {
        static public long GetBestKeyPairId(string keyringudid, KMAKeyPairType keypairtype)
        {
            var selected = (from cell in Global.LocalStorage.KMAKeyPair_Selector()
                            where (cell.keyringudid == keyringudid && cell.keypairtype == keypairtype) 
                            select new { id = cell.CellId, keypairtype = cell.keypairtype }).Take(1);
            Console.WriteLine("Count: " + selected.Count());
            var selectedKeypair = selected.FirstOrDefault();
            Console.WriteLine(selectedKeypair.id.ToString() + "\t" + selectedKeypair.keypairtype.ToString()); // + "\t" + selectedKeypair.created.ToString("u"));

            return selectedKeypair.id;
        }

        static public KMAKeyPair GetBestKeyPair(string keyringudid, KMAKeyPairType keypairtype)
        {
            KMAKeyPair keypair = default;

            long keypairid = GetBestKeyPairId(keyringudid, keypairtype);

            keypair = Global.LocalStorage.LoadKMAKeyPair(keypairid);

            return keypair;
        }
        
        static public TrinityErrorCode RevokeKeyPair(long id, List<string> messages)
        {
            //DateTime now = DateTime.Now;
            //if (messages == null)
            //{
            //    messages = new List<string> { "revoked", "Revoked at " + now.ToString("u") };
            //}

            //var keypair = Global.LocalStorage.LoadKMAKeyPair(id);

            //keypair.revocationInfo.isrevoked = true;
            //keypair.revocationInfo.revoked = now;
            //keypair.revocationInfo.messages = messages;

            //Global.LocalStorage.SaveKMAKeyPair(keypair);
 
            //Global.LocalStorage.SaveStorage();

            return TrinityErrorCode.E_SUCCESS;
        }
    }
}
