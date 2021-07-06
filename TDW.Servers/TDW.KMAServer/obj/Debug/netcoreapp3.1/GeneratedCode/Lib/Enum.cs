#pragma warning disable 162,168,649,660,661,1522
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trinity;
using Trinity.TSL;
namespace TDW.KMAServer
{
    
    /// <summary>
    /// Represents the enum type KMAKeyPairType defined in the TSL.
    /// </summary>
    public enum KMAKeyPairType : byte
    {
        Hybrid = 0,Authentication = 1,Encryption = 2
    }
    
}

#pragma warning restore 162,168,649,660,661,1522
