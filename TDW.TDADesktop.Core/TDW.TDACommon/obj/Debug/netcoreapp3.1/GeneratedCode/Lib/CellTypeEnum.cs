#pragma warning disable 162,168,649,660,661,1522
using Trinity.TSL;
namespace TDW.TDACommon
{
    public enum CellType: ushort
    {
        Undefined = 0,
        TDARootCell = 1,
        TDABasketItemCell = 2,
        TDASubledgerCell = 3,
        TDAMasterKeyLedgerCell = 4,
        TDAKeyRingLedgerCell = 5,
        TDAWalletLedgerCell = 6,
        TDAVDAddressLedgerCell = 7,
        
    }
}

#pragma warning restore 162,168,649,660,661,1522
