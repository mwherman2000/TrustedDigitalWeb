#pragma warning disable 162,168,649,660,661,1522
using Trinity.TSL;
namespace TDW.TRAServer
{
    public enum CellType: ushort
    {
        Undefined = 0,
        TRACredential_Cell = 1,
        TRATimestampCell = 2,
        TDWGeoLocationCell = 3,
        TRAPostalAddressCell = 4,
        Cac_Item_Cell = 5,
        Cac_ExternalReference_Cell = 6,
        Cac_Address_Cell = 7,
        Cac_PostalAddress_Cell = 8,
        Cac_PartyLegalEntity_Cell = 9,
        Cac_Contact_Cell = 10,
        Cac_Person_Cell = 11,
        Cac_PaymentMeans_Cell = 12,
        Cac_PayeeFinancialAccount_Cell = 13,
        Cac_Party_Cell = 14,
        UBL21_Invoice2_Cell = 15,
        
    }
}

#pragma warning restore 162,168,649,660,661,1522
