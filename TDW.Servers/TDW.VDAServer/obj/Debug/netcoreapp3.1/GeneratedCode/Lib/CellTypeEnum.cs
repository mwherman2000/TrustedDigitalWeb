#pragma warning disable 162,168,649,660,661,1522
using Trinity.TSL;
namespace TDW.VDAServer
{
    public enum CellType: ushort
    {
        Undefined = 0,
        TRACredentialCell = 1,
        TDWVDAAccountEntryCell = 2,
        TDWVDASmartContractEntryCell = 3,
        
    }
}

#pragma warning restore 162,168,649,660,661,1522
