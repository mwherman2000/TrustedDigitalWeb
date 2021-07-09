using System;
using System.Collections.Generic;
using System.Diagnostics;
using Trinity;

namespace TDW.TDACommon
{
    public static class TDAHelpers
    {
        public static void NewDTA()
        {
            Global.LocalStorage.ResetStorage();
            Global.LocalStorage.SaveStorage();
            Global.LocalStorage.LoadStorage();

            TDARootCell root = new TDARootCell(default, default, default);

            root.inbasket = new TDABasket();
            root.outbasket = new TDABasket();
            root.ledgers = new TDALedgers();

            TDABasketItemCell credential1 = new TDABasketItemCell(default);
            credential1.credentialudid = TDAUDIDHelpers.TRAUDIDFormat(TRAMethodNames.TRACredentialMethodName, credential1.CellId); // contrived test data
            root.inbasket.itemids = new List<long>();
            root.inbasket.itemids.Add(credential1.CellId);

            TDABasketItemCell credential2 = new TDABasketItemCell(default);
            credential2.credentialudid = TDAUDIDHelpers.TRAUDIDFormat(TRAMethodNames.TRACredentialMethodName, credential2.CellId); // contrived test data
            root.outbasket.itemids = new List<long>();
            root.outbasket.itemids.Add(credential2.CellId);

            TDAMasterKeyLedgerCell mkl1 = new TDAMasterKeyLedgerCell(default);
            mkl1.masterkeyids = new List<string>();
            mkl1.masterkeyids.Add(Guid.NewGuid().ToString()); // contrived test data
            mkl1.masterkeyids.Add(Guid.NewGuid().ToString()); // contrived test data

            TDAKeyRingLedgerCell krl1 = new TDAKeyRingLedgerCell(default);

            TDASubledgerCell krlsl1 = new TDASubledgerCell(default, default, default);
            krlsl1.name = "krlsl1";
            krlsl1.itemudids = new List<string>();
            krlsl1.itemudids.Add(TDAUDIDHelpers.TRAUDIDFormat(TRAMethodNames.TRAKeyPairMethodName, credential1.CellId));

            TDASubledgerCell krlsl2 = new TDASubledgerCell(default, default, default);
            krlsl2.name = "krlsl2";
            krlsl2.itemudids = new List<string>();
            krlsl2.itemudids.Add(TDAUDIDHelpers.TRAUDIDFormat(TRAMethodNames.TRAKeyPairMethodName, credential2.CellId));

            krl1.subledgerids = new List<long>();
            krl1.subledgerids.Add(krlsl1.CellId);
            krl1.subledgerids.Add(krlsl2.CellId);

            TDAWalletLedgerCell wl1 = new TDAWalletLedgerCell(default);

            TDASubledgerCell wlsl1 = new TDASubledgerCell(default, default, default);
            wlsl1.name = "wlsl1";
            wlsl1.itemudids = new List<string>();
            wlsl1.itemudids.Add(TDAUDIDHelpers.TRAUDIDFormat(TRAMethodNames.TRACredentialMethodName, credential1.CellId));

            TDASubledgerCell wlsl2 = new TDASubledgerCell(default, default, default);
            wlsl2.name = "wlsl2";
            wlsl2.itemudids = new List<string>();
            wlsl2.itemudids.Add(TDAUDIDHelpers.TRAUDIDFormat(TRAMethodNames.TRACredentialMethodName, credential2.CellId));

            wl1.subledgerids = new List<long>();
            wl1.subledgerids.Add(wlsl1.CellId);
            wl1.subledgerids.Add(wlsl2.CellId);

            TDAVDAddressLedgerCell al1 = new TDAVDAddressLedgerCell(default);

            TDASubledgerCell alsl1 = new TDASubledgerCell(default, default, default);
            alsl1.name = "alsl1";
            alsl1.itemudids = new List<string>();
            alsl1.itemudids.Add(TDAUDIDHelpers.TRAUDIDFormat(TRAMethodNames.TRACredentialMethodName, credential1.CellId));

            TDASubledgerCell alsl2 = new TDASubledgerCell(default, default, default);
            alsl2.name = "alsl2";
            alsl2.itemudids = new List<string>();
            alsl2.itemudids.Add(TDAUDIDHelpers.TRAUDIDFormat(TRAMethodNames.TRACredentialMethodName, credential2.CellId));

            al1.subledgerids = new List<long>();
            al1.subledgerids.Add(alsl1.CellId);
            al1.subledgerids.Add(alsl2.CellId);

            root.ledgers.ledgerids = new long[4];
            root.ledgers.ledgerids[(int)TDALedgerNames.MASTERKEYS] = mkl1.CellId;
            root.ledgers.ledgerids[(int)TDALedgerNames.KEYRINGS] = krl1.CellId;
            root.ledgers.ledgerids[(int)TDALedgerNames.WALLETS] = wl1.CellId;
            root.ledgers.ledgerids[(int)TDALedgerNames.VDAADDRESSES] = al1.CellId;

            Global.LocalStorage.SaveTDABasketItemCell(credential1);
            Global.LocalStorage.SaveTDABasketItemCell(credential2);

            Global.LocalStorage.SaveTDAMasterKeyLedgerCell(mkl1);
            Global.LocalStorage.SaveTDAKeyRingLedgerCell(krl1);
            Global.LocalStorage.SaveTDAWalletLedgerCell(wl1);
            Global.LocalStorage.SaveTDAVDAddressLedgerCell(al1);

            Global.LocalStorage.SaveTDARootCell(root);
            Global.LocalStorage.SaveStorage();

            ulong cellcount = Global.LocalStorage.CellCount;
            Debug.WriteLine("Cell count:\t" + cellcount.ToString());
            ulong totalcellsize = Global.LocalStorage.TotalCellSize;
            Debug.WriteLine("Total cell size:\t" + totalcellsize.ToString());
            ulong totalcommittedmemory = Global.LocalStorage.TotalCommittedMemory;
            Debug.WriteLine("Total committed memory:\t" + totalcommittedmemory.ToString());
        }
    }
}
