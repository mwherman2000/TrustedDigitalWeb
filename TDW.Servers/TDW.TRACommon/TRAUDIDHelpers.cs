using System;
using System.Collections.Generic;
using System.Text;

namespace TDW.TRACommon
{
    public static class TRAMethodNames
    {
        public const string TRACredentialMethodName = "svrn:credential";

        public const string TRAKeyPairMethodName = "svrn:keypair";
        public const string TRAKeyRingMethodName = "svrn:keyring";

        public const string TRAVDAAccountMethodName = "svrn:vdaaccount";
        public const string TRAUniversalIdentityRegistryEntryMethodName = "svrn:uir";
        public const string TRAServerEndpointRegistryEntryMethodName = "svrn:sepr";
        public const string TRARevocationListEntryMethodName = "svrn:rl";
        public const string TRAVDASmartContractEntryMethodName = "svrn:vdasmartcontract";

        public const string TRATestMethodName = "svrn:test";
        public const string TRATempMethodName = "svrn:temp";
    }

    static public class TRAUDIDHelpers
    {
        public static string TRAUDIDFormat(string methodName, long id)
        {
            string hex = BitConverter.ToString(BitConverter.GetBytes(id)).Replace("-", "");
            string udid = "did:" + methodName + ":" + 
                hex.Substring(0, 4) + "/" + hex.Substring(4, 4) + "/" + hex.Substring(8, 4) + "/" + hex.Substring(12);
            return udid;
        }
    }
}
