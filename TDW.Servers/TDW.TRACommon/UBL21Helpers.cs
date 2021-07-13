using System;
using System.Collections.Generic;
using System.Text;

namespace TDW.TRACommon
{
    public static class UBL21Helpers
    {
        public static readonly List<string> UBLDefaultContext = new List<string>
        { 
            "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2",
            "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2",
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2" 
        };

        public const string UBLVersionID = "2.1";
    }
}
