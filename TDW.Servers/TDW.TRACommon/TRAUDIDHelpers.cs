using System;
using System.Collections.Generic;
using System.Text;

namespace TDW.TRACommon
{
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
