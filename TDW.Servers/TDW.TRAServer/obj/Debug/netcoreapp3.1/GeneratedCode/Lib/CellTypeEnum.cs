#pragma warning disable 162,168,649,660,661,1522
using Trinity.TSL;
namespace TDW.TRAServer
{
    public enum CellType: ushort
    {
        Undefined = 0,
        TRACredentialCell = 1,
        TRATimestampCell = 2,
        TDWGeoLocationCell = 3,
        TRAPostalAddressCell = 4,
        
    }
}

#pragma warning restore 162,168,649,660,661,1522
