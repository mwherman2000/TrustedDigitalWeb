#pragma warning disable 162,168,649,660,661,1522

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using Trinity;
using Trinity.Storage;
using Trinity.TSL;
using Trinity.TSL.Lib;
namespace TDW.TRAServer
{
    /// <summary>
    /// Exposes Load/Save/New operations of <see cref="Trinity.Storage.ICell"/> and Use operation on <see cref="Trinity.Storage.ICellAccessor"/> on <see cref="Trinity.Storage.LocalMemoryStorage"/> and <see cref="Trinity.Storage.MemoryCloud"/>.
    /// </summary>
    internal class GenericCellOperations : IGenericCellOperations
    {
        #region LocalMemoryStorage operations
        /// <inheritdoc/>
        public void SaveGenericCell(Trinity.Storage.LocalMemoryStorage storage, CellAccessOptions writeAheadLogOptions, ICell cell)
        {
            switch ((CellType)cell.CellType)
            {
                
                case CellType.TRACredential_Cell:
                storage.SaveTRACredential_Cell(writeAheadLogOptions, (TRACredential_Cell)cell);
                break;
                
                case CellType.TRATimestamp_Cell:
                storage.SaveTRATimestamp_Cell(writeAheadLogOptions, (TRATimestamp_Cell)cell);
                break;
                
                case CellType.TDWGeoLocation_Cell:
                storage.SaveTDWGeoLocation_Cell(writeAheadLogOptions, (TDWGeoLocation_Cell)cell);
                break;
                
                case CellType.TRAPostalAddress_Cell:
                storage.SaveTRAPostalAddress_Cell(writeAheadLogOptions, (TRAPostalAddress_Cell)cell);
                break;
                
                case CellType.Cac_Item_Cell:
                storage.SaveCac_Item_Cell(writeAheadLogOptions, (Cac_Item_Cell)cell);
                break;
                
                case CellType.Cac_ExternalReference_Cell:
                storage.SaveCac_ExternalReference_Cell(writeAheadLogOptions, (Cac_ExternalReference_Cell)cell);
                break;
                
                case CellType.Cac_Address_Cell:
                storage.SaveCac_Address_Cell(writeAheadLogOptions, (Cac_Address_Cell)cell);
                break;
                
                case CellType.Cac_PostalAddress_Cell:
                storage.SaveCac_PostalAddress_Cell(writeAheadLogOptions, (Cac_PostalAddress_Cell)cell);
                break;
                
                case CellType.Cac_PartyLegalEntity_Cell:
                storage.SaveCac_PartyLegalEntity_Cell(writeAheadLogOptions, (Cac_PartyLegalEntity_Cell)cell);
                break;
                
                case CellType.Cac_Contact_Cell:
                storage.SaveCac_Contact_Cell(writeAheadLogOptions, (Cac_Contact_Cell)cell);
                break;
                
                case CellType.Cac_Person_Cell:
                storage.SaveCac_Person_Cell(writeAheadLogOptions, (Cac_Person_Cell)cell);
                break;
                
                case CellType.Cac_PaymentMeans_Cell:
                storage.SaveCac_PaymentMeans_Cell(writeAheadLogOptions, (Cac_PaymentMeans_Cell)cell);
                break;
                
                case CellType.Cac_PayeeFinancialAccount_Cell:
                storage.SaveCac_PayeeFinancialAccount_Cell(writeAheadLogOptions, (Cac_PayeeFinancialAccount_Cell)cell);
                break;
                
                case CellType.Cac_Party_Cell:
                storage.SaveCac_Party_Cell(writeAheadLogOptions, (Cac_Party_Cell)cell);
                break;
                
                case CellType.UBL21_Invoice2_Cell:
                storage.SaveUBL21_Invoice2_Cell(writeAheadLogOptions, (UBL21_Invoice2_Cell)cell);
                break;
                
            }
        }
        /// <inheritdoc/>
        public void SaveGenericCell(Trinity.Storage.LocalMemoryStorage storage, CellAccessOptions writeAheadLogOptions, long cellId, ICell cell)
        {
            switch ((CellType)cell.CellType)
            {
                
                case CellType.TRACredential_Cell:
                storage.SaveTRACredential_Cell(writeAheadLogOptions, cellId, (TRACredential_Cell)cell);
                break;
                
                case CellType.TRATimestamp_Cell:
                storage.SaveTRATimestamp_Cell(writeAheadLogOptions, cellId, (TRATimestamp_Cell)cell);
                break;
                
                case CellType.TDWGeoLocation_Cell:
                storage.SaveTDWGeoLocation_Cell(writeAheadLogOptions, cellId, (TDWGeoLocation_Cell)cell);
                break;
                
                case CellType.TRAPostalAddress_Cell:
                storage.SaveTRAPostalAddress_Cell(writeAheadLogOptions, cellId, (TRAPostalAddress_Cell)cell);
                break;
                
                case CellType.Cac_Item_Cell:
                storage.SaveCac_Item_Cell(writeAheadLogOptions, cellId, (Cac_Item_Cell)cell);
                break;
                
                case CellType.Cac_ExternalReference_Cell:
                storage.SaveCac_ExternalReference_Cell(writeAheadLogOptions, cellId, (Cac_ExternalReference_Cell)cell);
                break;
                
                case CellType.Cac_Address_Cell:
                storage.SaveCac_Address_Cell(writeAheadLogOptions, cellId, (Cac_Address_Cell)cell);
                break;
                
                case CellType.Cac_PostalAddress_Cell:
                storage.SaveCac_PostalAddress_Cell(writeAheadLogOptions, cellId, (Cac_PostalAddress_Cell)cell);
                break;
                
                case CellType.Cac_PartyLegalEntity_Cell:
                storage.SaveCac_PartyLegalEntity_Cell(writeAheadLogOptions, cellId, (Cac_PartyLegalEntity_Cell)cell);
                break;
                
                case CellType.Cac_Contact_Cell:
                storage.SaveCac_Contact_Cell(writeAheadLogOptions, cellId, (Cac_Contact_Cell)cell);
                break;
                
                case CellType.Cac_Person_Cell:
                storage.SaveCac_Person_Cell(writeAheadLogOptions, cellId, (Cac_Person_Cell)cell);
                break;
                
                case CellType.Cac_PaymentMeans_Cell:
                storage.SaveCac_PaymentMeans_Cell(writeAheadLogOptions, cellId, (Cac_PaymentMeans_Cell)cell);
                break;
                
                case CellType.Cac_PayeeFinancialAccount_Cell:
                storage.SaveCac_PayeeFinancialAccount_Cell(writeAheadLogOptions, cellId, (Cac_PayeeFinancialAccount_Cell)cell);
                break;
                
                case CellType.Cac_Party_Cell:
                storage.SaveCac_Party_Cell(writeAheadLogOptions, cellId, (Cac_Party_Cell)cell);
                break;
                
                case CellType.UBL21_Invoice2_Cell:
                storage.SaveUBL21_Invoice2_Cell(writeAheadLogOptions, cellId, (UBL21_Invoice2_Cell)cell);
                break;
                
            }
        }
        /// <inheritdoc/>
        public unsafe ICell LoadGenericCell(Trinity.Storage.LocalMemoryStorage storage, long cellId)
        {
            ushort type;
            int    size;
            byte*  cellPtr;
            int    entryIndex;
            var err = storage.GetLockedCellInfo(cellId, out size, out type, out cellPtr, out entryIndex);
            if (err != TrinityErrorCode.E_SUCCESS)
            {
                throw new CellNotFoundException("Cannot access the cell.");
            }
            try
            {
                var accessor = UseGenericCell(cellId, cellPtr, entryIndex, type);
                var cell = accessor.Deserialize();
                accessor.Dispose();
                return cell;
            }
            catch (Exception ex)
            {
                storage.ReleaseCellLock(cellId, entryIndex);
                ExceptionDispatchInfo.Capture(ex).Throw();
                throw;
            }
        }
        #endregion
        #region New operations
        /// <inheritdoc/>
        public ICell NewGenericCell(string cellType)
        {
            CellType type;
            if (!StorageSchema.cellTypeLookupTable.TryGetValue(cellType, out type))
                Throw.invalid_cell_type();
            switch (type)
            {
                
                case global::TDW.TRAServer.CellType.TRACredential_Cell:
                return new TRACredential_Cell();
                break;
                
                case global::TDW.TRAServer.CellType.TRATimestamp_Cell:
                return new TRATimestamp_Cell();
                break;
                
                case global::TDW.TRAServer.CellType.TDWGeoLocation_Cell:
                return new TDWGeoLocation_Cell();
                break;
                
                case global::TDW.TRAServer.CellType.TRAPostalAddress_Cell:
                return new TRAPostalAddress_Cell();
                break;
                
                case global::TDW.TRAServer.CellType.Cac_Item_Cell:
                return new Cac_Item_Cell();
                break;
                
                case global::TDW.TRAServer.CellType.Cac_ExternalReference_Cell:
                return new Cac_ExternalReference_Cell();
                break;
                
                case global::TDW.TRAServer.CellType.Cac_Address_Cell:
                return new Cac_Address_Cell();
                break;
                
                case global::TDW.TRAServer.CellType.Cac_PostalAddress_Cell:
                return new Cac_PostalAddress_Cell();
                break;
                
                case global::TDW.TRAServer.CellType.Cac_PartyLegalEntity_Cell:
                return new Cac_PartyLegalEntity_Cell();
                break;
                
                case global::TDW.TRAServer.CellType.Cac_Contact_Cell:
                return new Cac_Contact_Cell();
                break;
                
                case global::TDW.TRAServer.CellType.Cac_Person_Cell:
                return new Cac_Person_Cell();
                break;
                
                case global::TDW.TRAServer.CellType.Cac_PaymentMeans_Cell:
                return new Cac_PaymentMeans_Cell();
                break;
                
                case global::TDW.TRAServer.CellType.Cac_PayeeFinancialAccount_Cell:
                return new Cac_PayeeFinancialAccount_Cell();
                break;
                
                case global::TDW.TRAServer.CellType.Cac_Party_Cell:
                return new Cac_Party_Cell();
                break;
                
                case global::TDW.TRAServer.CellType.UBL21_Invoice2_Cell:
                return new UBL21_Invoice2_Cell();
                break;
                
            }
            /* Should not reach here */
            return null;
        }
        public ICell NewGenericCell(long cellId, string cellType)
        {
            CellType type;
            if (!StorageSchema.cellTypeLookupTable.TryGetValue(cellType, out type))
                Throw.invalid_cell_type();
            switch (type)
            {
                
                case global::TDW.TRAServer.CellType.TRACredential_Cell:
                return new TRACredential_Cell(cell_id: cellId);
                
                case global::TDW.TRAServer.CellType.TRATimestamp_Cell:
                return new TRATimestamp_Cell(cell_id: cellId);
                
                case global::TDW.TRAServer.CellType.TDWGeoLocation_Cell:
                return new TDWGeoLocation_Cell(cell_id: cellId);
                
                case global::TDW.TRAServer.CellType.TRAPostalAddress_Cell:
                return new TRAPostalAddress_Cell(cell_id: cellId);
                
                case global::TDW.TRAServer.CellType.Cac_Item_Cell:
                return new Cac_Item_Cell(cell_id: cellId);
                
                case global::TDW.TRAServer.CellType.Cac_ExternalReference_Cell:
                return new Cac_ExternalReference_Cell(cell_id: cellId);
                
                case global::TDW.TRAServer.CellType.Cac_Address_Cell:
                return new Cac_Address_Cell(cell_id: cellId);
                
                case global::TDW.TRAServer.CellType.Cac_PostalAddress_Cell:
                return new Cac_PostalAddress_Cell(cell_id: cellId);
                
                case global::TDW.TRAServer.CellType.Cac_PartyLegalEntity_Cell:
                return new Cac_PartyLegalEntity_Cell(cell_id: cellId);
                
                case global::TDW.TRAServer.CellType.Cac_Contact_Cell:
                return new Cac_Contact_Cell(cell_id: cellId);
                
                case global::TDW.TRAServer.CellType.Cac_Person_Cell:
                return new Cac_Person_Cell(cell_id: cellId);
                
                case global::TDW.TRAServer.CellType.Cac_PaymentMeans_Cell:
                return new Cac_PaymentMeans_Cell(cell_id: cellId);
                
                case global::TDW.TRAServer.CellType.Cac_PayeeFinancialAccount_Cell:
                return new Cac_PayeeFinancialAccount_Cell(cell_id: cellId);
                
                case global::TDW.TRAServer.CellType.Cac_Party_Cell:
                return new Cac_Party_Cell(cell_id: cellId);
                
                case global::TDW.TRAServer.CellType.UBL21_Invoice2_Cell:
                return new UBL21_Invoice2_Cell(cell_id: cellId);
                
            }
            /* Should not reach here */
            return null;
        }
        /// <inheritdoc/>
        public ICell NewGenericCell(string cellType, string content)
        {
            CellType type;
            if (!StorageSchema.cellTypeLookupTable.TryGetValue(cellType, out type))
                Throw.invalid_cell_type();
            switch (type)
            {
                
                case global::TDW.TRAServer.CellType.TRACredential_Cell:
                return TRACredential_Cell.Parse(content);
                
                case global::TDW.TRAServer.CellType.TRATimestamp_Cell:
                return TRATimestamp_Cell.Parse(content);
                
                case global::TDW.TRAServer.CellType.TDWGeoLocation_Cell:
                return TDWGeoLocation_Cell.Parse(content);
                
                case global::TDW.TRAServer.CellType.TRAPostalAddress_Cell:
                return TRAPostalAddress_Cell.Parse(content);
                
                case global::TDW.TRAServer.CellType.Cac_Item_Cell:
                return Cac_Item_Cell.Parse(content);
                
                case global::TDW.TRAServer.CellType.Cac_ExternalReference_Cell:
                return Cac_ExternalReference_Cell.Parse(content);
                
                case global::TDW.TRAServer.CellType.Cac_Address_Cell:
                return Cac_Address_Cell.Parse(content);
                
                case global::TDW.TRAServer.CellType.Cac_PostalAddress_Cell:
                return Cac_PostalAddress_Cell.Parse(content);
                
                case global::TDW.TRAServer.CellType.Cac_PartyLegalEntity_Cell:
                return Cac_PartyLegalEntity_Cell.Parse(content);
                
                case global::TDW.TRAServer.CellType.Cac_Contact_Cell:
                return Cac_Contact_Cell.Parse(content);
                
                case global::TDW.TRAServer.CellType.Cac_Person_Cell:
                return Cac_Person_Cell.Parse(content);
                
                case global::TDW.TRAServer.CellType.Cac_PaymentMeans_Cell:
                return Cac_PaymentMeans_Cell.Parse(content);
                
                case global::TDW.TRAServer.CellType.Cac_PayeeFinancialAccount_Cell:
                return Cac_PayeeFinancialAccount_Cell.Parse(content);
                
                case global::TDW.TRAServer.CellType.Cac_Party_Cell:
                return Cac_Party_Cell.Parse(content);
                
                case global::TDW.TRAServer.CellType.UBL21_Invoice2_Cell:
                return UBL21_Invoice2_Cell.Parse(content);
                
            }
            /* Should not reach here */
            return null;
        }
        #endregion
        #region LocalMemoryStorage Use operations
        /// <inheritdoc/>
        public unsafe ICellAccessor UseGenericCell(Trinity.Storage.LocalMemoryStorage storage, long cellId)
        {
            ushort type;
            int    size;
            byte*  cellPtr;
            int    entryIndex;
            var err = storage.GetLockedCellInfo(cellId, out size, out type, out cellPtr, out entryIndex);
            if (err != TrinityErrorCode.E_SUCCESS)
            {
                throw new CellNotFoundException("Cannot access the cell.");
            }
            switch ((CellType)type)
            {
                
                case CellType.TRACredential_Cell:
                return TRACredential_Cell_Accessor._get()._Setup(cellId, cellPtr, entryIndex, CellAccessOptions.ThrowExceptionOnCellNotFound);
                
                case CellType.TRATimestamp_Cell:
                return TRATimestamp_Cell_Accessor._get()._Setup(cellId, cellPtr, entryIndex, CellAccessOptions.ThrowExceptionOnCellNotFound);
                
                case CellType.TDWGeoLocation_Cell:
                return TDWGeoLocation_Cell_Accessor._get()._Setup(cellId, cellPtr, entryIndex, CellAccessOptions.ThrowExceptionOnCellNotFound);
                
                case CellType.TRAPostalAddress_Cell:
                return TRAPostalAddress_Cell_Accessor._get()._Setup(cellId, cellPtr, entryIndex, CellAccessOptions.ThrowExceptionOnCellNotFound);
                
                case CellType.Cac_Item_Cell:
                return Cac_Item_Cell_Accessor._get()._Setup(cellId, cellPtr, entryIndex, CellAccessOptions.ThrowExceptionOnCellNotFound);
                
                case CellType.Cac_ExternalReference_Cell:
                return Cac_ExternalReference_Cell_Accessor._get()._Setup(cellId, cellPtr, entryIndex, CellAccessOptions.ThrowExceptionOnCellNotFound);
                
                case CellType.Cac_Address_Cell:
                return Cac_Address_Cell_Accessor._get()._Setup(cellId, cellPtr, entryIndex, CellAccessOptions.ThrowExceptionOnCellNotFound);
                
                case CellType.Cac_PostalAddress_Cell:
                return Cac_PostalAddress_Cell_Accessor._get()._Setup(cellId, cellPtr, entryIndex, CellAccessOptions.ThrowExceptionOnCellNotFound);
                
                case CellType.Cac_PartyLegalEntity_Cell:
                return Cac_PartyLegalEntity_Cell_Accessor._get()._Setup(cellId, cellPtr, entryIndex, CellAccessOptions.ThrowExceptionOnCellNotFound);
                
                case CellType.Cac_Contact_Cell:
                return Cac_Contact_Cell_Accessor._get()._Setup(cellId, cellPtr, entryIndex, CellAccessOptions.ThrowExceptionOnCellNotFound);
                
                case CellType.Cac_Person_Cell:
                return Cac_Person_Cell_Accessor._get()._Setup(cellId, cellPtr, entryIndex, CellAccessOptions.ThrowExceptionOnCellNotFound);
                
                case CellType.Cac_PaymentMeans_Cell:
                return Cac_PaymentMeans_Cell_Accessor._get()._Setup(cellId, cellPtr, entryIndex, CellAccessOptions.ThrowExceptionOnCellNotFound);
                
                case CellType.Cac_PayeeFinancialAccount_Cell:
                return Cac_PayeeFinancialAccount_Cell_Accessor._get()._Setup(cellId, cellPtr, entryIndex, CellAccessOptions.ThrowExceptionOnCellNotFound);
                
                case CellType.Cac_Party_Cell:
                return Cac_Party_Cell_Accessor._get()._Setup(cellId, cellPtr, entryIndex, CellAccessOptions.ThrowExceptionOnCellNotFound);
                
                case CellType.UBL21_Invoice2_Cell:
                return UBL21_Invoice2_Cell_Accessor._get()._Setup(cellId, cellPtr, entryIndex, CellAccessOptions.ThrowExceptionOnCellNotFound);
                
                default:
                storage.ReleaseCellLock(cellId, entryIndex);
                throw new CellTypeNotMatchException("Cannot determine cell type.");
            }
        }
        /// <inheritdoc/>
        public unsafe ICellAccessor UseGenericCell(Trinity.Storage.LocalMemoryStorage storage, long cellId, CellAccessOptions options)
        {
            ushort type;
            int    size;
            byte*  cellPtr;
            int    entryIndex;
            var err = storage.GetLockedCellInfo(cellId, out size, out type, out cellPtr, out entryIndex);
            switch (err)
            {
                case TrinityErrorCode.E_SUCCESS:
                break;
                case TrinityErrorCode.E_CELL_NOT_FOUND:
                    {
                        if ((options & CellAccessOptions.ThrowExceptionOnCellNotFound) != 0)
                        {
                            Throw.cell_not_found(cellId);
                        }
                        else if ((options & CellAccessOptions.CreateNewOnCellNotFound) != 0)
                        {
                            throw new ArgumentException("CellAccessOptions.CreateNewOnCellNotFound is not valid for this method. Cannot determine new cell type.", "options");
                        }
                        else if ((options & CellAccessOptions.ReturnNullOnCellNotFound) != 0)
                        {
                            return null;
                        }
                        else
                        {
                            Throw.cell_not_found(cellId);
                        }
                        break;
                    }
                default:
                throw new CellNotFoundException("Cannot access the cell.");
            }
            try
            {
                return UseGenericCell(cellId, cellPtr, entryIndex, type, options);
            }
            catch (Exception ex)
            {
                storage.ReleaseCellLock(cellId, entryIndex);
                ExceptionDispatchInfo.Capture(ex).Throw();
                throw;
            }
        }
        /// <inheritdoc/>
        public unsafe ICellAccessor UseGenericCell(Trinity.Storage.LocalMemoryStorage storage, long cellId, CellAccessOptions options, string cellType)
        {
            switch (cellType)
            {
                
                case "TRACredential_Cell": return TRACredential_Cell_Accessor._get()._Lock(cellId, options);
                
                case "TRATimestamp_Cell": return TRATimestamp_Cell_Accessor._get()._Lock(cellId, options);
                
                case "TDWGeoLocation_Cell": return TDWGeoLocation_Cell_Accessor._get()._Lock(cellId, options);
                
                case "TRAPostalAddress_Cell": return TRAPostalAddress_Cell_Accessor._get()._Lock(cellId, options);
                
                case "Cac_Item_Cell": return Cac_Item_Cell_Accessor._get()._Lock(cellId, options);
                
                case "Cac_ExternalReference_Cell": return Cac_ExternalReference_Cell_Accessor._get()._Lock(cellId, options);
                
                case "Cac_Address_Cell": return Cac_Address_Cell_Accessor._get()._Lock(cellId, options);
                
                case "Cac_PostalAddress_Cell": return Cac_PostalAddress_Cell_Accessor._get()._Lock(cellId, options);
                
                case "Cac_PartyLegalEntity_Cell": return Cac_PartyLegalEntity_Cell_Accessor._get()._Lock(cellId, options);
                
                case "Cac_Contact_Cell": return Cac_Contact_Cell_Accessor._get()._Lock(cellId, options);
                
                case "Cac_Person_Cell": return Cac_Person_Cell_Accessor._get()._Lock(cellId, options);
                
                case "Cac_PaymentMeans_Cell": return Cac_PaymentMeans_Cell_Accessor._get()._Lock(cellId, options);
                
                case "Cac_PayeeFinancialAccount_Cell": return Cac_PayeeFinancialAccount_Cell_Accessor._get()._Lock(cellId, options);
                
                case "Cac_Party_Cell": return Cac_Party_Cell_Accessor._get()._Lock(cellId, options);
                
                case "UBL21_Invoice2_Cell": return UBL21_Invoice2_Cell_Accessor._get()._Lock(cellId, options);
                
                default:
                Throw.invalid_cell_type();
                return null;
            }
        }
        #endregion
        #region LocalMemoryStorage Enumerate operations
        /// <inheritdoc/>
        public IEnumerable<ICell> EnumerateGenericCells(LocalMemoryStorage storage)
        {
            foreach (var cellInfo in Global.LocalStorage)
            {
                switch ((CellType)cellInfo.CellType)
                {
                    
                    case CellType.TRACredential_Cell:
                        {
                            var TRACredential_Cell_accessor = TRACredential_Cell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            var TRACredential_Cell_cell     = (TRACredential_Cell)TRACredential_Cell_accessor;
                            TRACredential_Cell_accessor.Dispose();
                            yield return TRACredential_Cell_cell;
                            break;
                        }
                    
                    case CellType.TRATimestamp_Cell:
                        {
                            var TRATimestamp_Cell_accessor = TRATimestamp_Cell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            var TRATimestamp_Cell_cell     = (TRATimestamp_Cell)TRATimestamp_Cell_accessor;
                            TRATimestamp_Cell_accessor.Dispose();
                            yield return TRATimestamp_Cell_cell;
                            break;
                        }
                    
                    case CellType.TDWGeoLocation_Cell:
                        {
                            var TDWGeoLocation_Cell_accessor = TDWGeoLocation_Cell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            var TDWGeoLocation_Cell_cell     = (TDWGeoLocation_Cell)TDWGeoLocation_Cell_accessor;
                            TDWGeoLocation_Cell_accessor.Dispose();
                            yield return TDWGeoLocation_Cell_cell;
                            break;
                        }
                    
                    case CellType.TRAPostalAddress_Cell:
                        {
                            var TRAPostalAddress_Cell_accessor = TRAPostalAddress_Cell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            var TRAPostalAddress_Cell_cell     = (TRAPostalAddress_Cell)TRAPostalAddress_Cell_accessor;
                            TRAPostalAddress_Cell_accessor.Dispose();
                            yield return TRAPostalAddress_Cell_cell;
                            break;
                        }
                    
                    case CellType.Cac_Item_Cell:
                        {
                            var Cac_Item_Cell_accessor = Cac_Item_Cell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            var Cac_Item_Cell_cell     = (Cac_Item_Cell)Cac_Item_Cell_accessor;
                            Cac_Item_Cell_accessor.Dispose();
                            yield return Cac_Item_Cell_cell;
                            break;
                        }
                    
                    case CellType.Cac_ExternalReference_Cell:
                        {
                            var Cac_ExternalReference_Cell_accessor = Cac_ExternalReference_Cell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            var Cac_ExternalReference_Cell_cell     = (Cac_ExternalReference_Cell)Cac_ExternalReference_Cell_accessor;
                            Cac_ExternalReference_Cell_accessor.Dispose();
                            yield return Cac_ExternalReference_Cell_cell;
                            break;
                        }
                    
                    case CellType.Cac_Address_Cell:
                        {
                            var Cac_Address_Cell_accessor = Cac_Address_Cell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            var Cac_Address_Cell_cell     = (Cac_Address_Cell)Cac_Address_Cell_accessor;
                            Cac_Address_Cell_accessor.Dispose();
                            yield return Cac_Address_Cell_cell;
                            break;
                        }
                    
                    case CellType.Cac_PostalAddress_Cell:
                        {
                            var Cac_PostalAddress_Cell_accessor = Cac_PostalAddress_Cell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            var Cac_PostalAddress_Cell_cell     = (Cac_PostalAddress_Cell)Cac_PostalAddress_Cell_accessor;
                            Cac_PostalAddress_Cell_accessor.Dispose();
                            yield return Cac_PostalAddress_Cell_cell;
                            break;
                        }
                    
                    case CellType.Cac_PartyLegalEntity_Cell:
                        {
                            var Cac_PartyLegalEntity_Cell_accessor = Cac_PartyLegalEntity_Cell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            var Cac_PartyLegalEntity_Cell_cell     = (Cac_PartyLegalEntity_Cell)Cac_PartyLegalEntity_Cell_accessor;
                            Cac_PartyLegalEntity_Cell_accessor.Dispose();
                            yield return Cac_PartyLegalEntity_Cell_cell;
                            break;
                        }
                    
                    case CellType.Cac_Contact_Cell:
                        {
                            var Cac_Contact_Cell_accessor = Cac_Contact_Cell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            var Cac_Contact_Cell_cell     = (Cac_Contact_Cell)Cac_Contact_Cell_accessor;
                            Cac_Contact_Cell_accessor.Dispose();
                            yield return Cac_Contact_Cell_cell;
                            break;
                        }
                    
                    case CellType.Cac_Person_Cell:
                        {
                            var Cac_Person_Cell_accessor = Cac_Person_Cell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            var Cac_Person_Cell_cell     = (Cac_Person_Cell)Cac_Person_Cell_accessor;
                            Cac_Person_Cell_accessor.Dispose();
                            yield return Cac_Person_Cell_cell;
                            break;
                        }
                    
                    case CellType.Cac_PaymentMeans_Cell:
                        {
                            var Cac_PaymentMeans_Cell_accessor = Cac_PaymentMeans_Cell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            var Cac_PaymentMeans_Cell_cell     = (Cac_PaymentMeans_Cell)Cac_PaymentMeans_Cell_accessor;
                            Cac_PaymentMeans_Cell_accessor.Dispose();
                            yield return Cac_PaymentMeans_Cell_cell;
                            break;
                        }
                    
                    case CellType.Cac_PayeeFinancialAccount_Cell:
                        {
                            var Cac_PayeeFinancialAccount_Cell_accessor = Cac_PayeeFinancialAccount_Cell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            var Cac_PayeeFinancialAccount_Cell_cell     = (Cac_PayeeFinancialAccount_Cell)Cac_PayeeFinancialAccount_Cell_accessor;
                            Cac_PayeeFinancialAccount_Cell_accessor.Dispose();
                            yield return Cac_PayeeFinancialAccount_Cell_cell;
                            break;
                        }
                    
                    case CellType.Cac_Party_Cell:
                        {
                            var Cac_Party_Cell_accessor = Cac_Party_Cell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            var Cac_Party_Cell_cell     = (Cac_Party_Cell)Cac_Party_Cell_accessor;
                            Cac_Party_Cell_accessor.Dispose();
                            yield return Cac_Party_Cell_cell;
                            break;
                        }
                    
                    case CellType.UBL21_Invoice2_Cell:
                        {
                            var UBL21_Invoice2_Cell_accessor = UBL21_Invoice2_Cell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            var UBL21_Invoice2_Cell_cell     = (UBL21_Invoice2_Cell)UBL21_Invoice2_Cell_accessor;
                            UBL21_Invoice2_Cell_accessor.Dispose();
                            yield return UBL21_Invoice2_Cell_cell;
                            break;
                        }
                    
                    default:
                    continue;
                }
            }
            yield break;
        }
        /// <inheritdoc/>
        public IEnumerable<ICellAccessor> EnumerateGenericCellAccessors(LocalMemoryStorage storage)
        {
            foreach (var cellInfo in Global.LocalStorage)
            {
                switch ((CellType)cellInfo.CellType)
                {
                    
                    case CellType.TRACredential_Cell:
                        {
                            var TRACredential_Cell_accessor = TRACredential_Cell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            yield return TRACredential_Cell_accessor;
                            TRACredential_Cell_accessor.Dispose();
                            break;
                        }
                    
                    case CellType.TRATimestamp_Cell:
                        {
                            var TRATimestamp_Cell_accessor = TRATimestamp_Cell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            yield return TRATimestamp_Cell_accessor;
                            TRATimestamp_Cell_accessor.Dispose();
                            break;
                        }
                    
                    case CellType.TDWGeoLocation_Cell:
                        {
                            var TDWGeoLocation_Cell_accessor = TDWGeoLocation_Cell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            yield return TDWGeoLocation_Cell_accessor;
                            TDWGeoLocation_Cell_accessor.Dispose();
                            break;
                        }
                    
                    case CellType.TRAPostalAddress_Cell:
                        {
                            var TRAPostalAddress_Cell_accessor = TRAPostalAddress_Cell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            yield return TRAPostalAddress_Cell_accessor;
                            TRAPostalAddress_Cell_accessor.Dispose();
                            break;
                        }
                    
                    case CellType.Cac_Item_Cell:
                        {
                            var Cac_Item_Cell_accessor = Cac_Item_Cell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            yield return Cac_Item_Cell_accessor;
                            Cac_Item_Cell_accessor.Dispose();
                            break;
                        }
                    
                    case CellType.Cac_ExternalReference_Cell:
                        {
                            var Cac_ExternalReference_Cell_accessor = Cac_ExternalReference_Cell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            yield return Cac_ExternalReference_Cell_accessor;
                            Cac_ExternalReference_Cell_accessor.Dispose();
                            break;
                        }
                    
                    case CellType.Cac_Address_Cell:
                        {
                            var Cac_Address_Cell_accessor = Cac_Address_Cell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            yield return Cac_Address_Cell_accessor;
                            Cac_Address_Cell_accessor.Dispose();
                            break;
                        }
                    
                    case CellType.Cac_PostalAddress_Cell:
                        {
                            var Cac_PostalAddress_Cell_accessor = Cac_PostalAddress_Cell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            yield return Cac_PostalAddress_Cell_accessor;
                            Cac_PostalAddress_Cell_accessor.Dispose();
                            break;
                        }
                    
                    case CellType.Cac_PartyLegalEntity_Cell:
                        {
                            var Cac_PartyLegalEntity_Cell_accessor = Cac_PartyLegalEntity_Cell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            yield return Cac_PartyLegalEntity_Cell_accessor;
                            Cac_PartyLegalEntity_Cell_accessor.Dispose();
                            break;
                        }
                    
                    case CellType.Cac_Contact_Cell:
                        {
                            var Cac_Contact_Cell_accessor = Cac_Contact_Cell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            yield return Cac_Contact_Cell_accessor;
                            Cac_Contact_Cell_accessor.Dispose();
                            break;
                        }
                    
                    case CellType.Cac_Person_Cell:
                        {
                            var Cac_Person_Cell_accessor = Cac_Person_Cell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            yield return Cac_Person_Cell_accessor;
                            Cac_Person_Cell_accessor.Dispose();
                            break;
                        }
                    
                    case CellType.Cac_PaymentMeans_Cell:
                        {
                            var Cac_PaymentMeans_Cell_accessor = Cac_PaymentMeans_Cell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            yield return Cac_PaymentMeans_Cell_accessor;
                            Cac_PaymentMeans_Cell_accessor.Dispose();
                            break;
                        }
                    
                    case CellType.Cac_PayeeFinancialAccount_Cell:
                        {
                            var Cac_PayeeFinancialAccount_Cell_accessor = Cac_PayeeFinancialAccount_Cell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            yield return Cac_PayeeFinancialAccount_Cell_accessor;
                            Cac_PayeeFinancialAccount_Cell_accessor.Dispose();
                            break;
                        }
                    
                    case CellType.Cac_Party_Cell:
                        {
                            var Cac_Party_Cell_accessor = Cac_Party_Cell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            yield return Cac_Party_Cell_accessor;
                            Cac_Party_Cell_accessor.Dispose();
                            break;
                        }
                    
                    case CellType.UBL21_Invoice2_Cell:
                        {
                            var UBL21_Invoice2_Cell_accessor = UBL21_Invoice2_Cell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            yield return UBL21_Invoice2_Cell_accessor;
                            UBL21_Invoice2_Cell_accessor.Dispose();
                            break;
                        }
                    
                    default:
                    continue;
                }
            }
            yield break;
        }
        #endregion
        #region IKeyValueStore operations
        /// <inheritdoc/>
        public void SaveGenericCell(IKeyValueStore storage, ICell cell)
        {
            switch ((CellType)cell.CellType)
            {
                
                case CellType.TRACredential_Cell:
                storage.SaveTRACredential_Cell((TRACredential_Cell)cell);
                break;
                
                case CellType.TRATimestamp_Cell:
                storage.SaveTRATimestamp_Cell((TRATimestamp_Cell)cell);
                break;
                
                case CellType.TDWGeoLocation_Cell:
                storage.SaveTDWGeoLocation_Cell((TDWGeoLocation_Cell)cell);
                break;
                
                case CellType.TRAPostalAddress_Cell:
                storage.SaveTRAPostalAddress_Cell((TRAPostalAddress_Cell)cell);
                break;
                
                case CellType.Cac_Item_Cell:
                storage.SaveCac_Item_Cell((Cac_Item_Cell)cell);
                break;
                
                case CellType.Cac_ExternalReference_Cell:
                storage.SaveCac_ExternalReference_Cell((Cac_ExternalReference_Cell)cell);
                break;
                
                case CellType.Cac_Address_Cell:
                storage.SaveCac_Address_Cell((Cac_Address_Cell)cell);
                break;
                
                case CellType.Cac_PostalAddress_Cell:
                storage.SaveCac_PostalAddress_Cell((Cac_PostalAddress_Cell)cell);
                break;
                
                case CellType.Cac_PartyLegalEntity_Cell:
                storage.SaveCac_PartyLegalEntity_Cell((Cac_PartyLegalEntity_Cell)cell);
                break;
                
                case CellType.Cac_Contact_Cell:
                storage.SaveCac_Contact_Cell((Cac_Contact_Cell)cell);
                break;
                
                case CellType.Cac_Person_Cell:
                storage.SaveCac_Person_Cell((Cac_Person_Cell)cell);
                break;
                
                case CellType.Cac_PaymentMeans_Cell:
                storage.SaveCac_PaymentMeans_Cell((Cac_PaymentMeans_Cell)cell);
                break;
                
                case CellType.Cac_PayeeFinancialAccount_Cell:
                storage.SaveCac_PayeeFinancialAccount_Cell((Cac_PayeeFinancialAccount_Cell)cell);
                break;
                
                case CellType.Cac_Party_Cell:
                storage.SaveCac_Party_Cell((Cac_Party_Cell)cell);
                break;
                
                case CellType.UBL21_Invoice2_Cell:
                storage.SaveUBL21_Invoice2_Cell((UBL21_Invoice2_Cell)cell);
                break;
                
            }
        }
        /// <inheritdoc/>
        public void SaveGenericCell(IKeyValueStore storage, long cellId, ICell cell)
        {
            switch ((CellType)cell.CellType)
            {
                
                case CellType.TRACredential_Cell:
                storage.SaveTRACredential_Cell(cellId, (TRACredential_Cell)cell);
                break;
                
                case CellType.TRATimestamp_Cell:
                storage.SaveTRATimestamp_Cell(cellId, (TRATimestamp_Cell)cell);
                break;
                
                case CellType.TDWGeoLocation_Cell:
                storage.SaveTDWGeoLocation_Cell(cellId, (TDWGeoLocation_Cell)cell);
                break;
                
                case CellType.TRAPostalAddress_Cell:
                storage.SaveTRAPostalAddress_Cell(cellId, (TRAPostalAddress_Cell)cell);
                break;
                
                case CellType.Cac_Item_Cell:
                storage.SaveCac_Item_Cell(cellId, (Cac_Item_Cell)cell);
                break;
                
                case CellType.Cac_ExternalReference_Cell:
                storage.SaveCac_ExternalReference_Cell(cellId, (Cac_ExternalReference_Cell)cell);
                break;
                
                case CellType.Cac_Address_Cell:
                storage.SaveCac_Address_Cell(cellId, (Cac_Address_Cell)cell);
                break;
                
                case CellType.Cac_PostalAddress_Cell:
                storage.SaveCac_PostalAddress_Cell(cellId, (Cac_PostalAddress_Cell)cell);
                break;
                
                case CellType.Cac_PartyLegalEntity_Cell:
                storage.SaveCac_PartyLegalEntity_Cell(cellId, (Cac_PartyLegalEntity_Cell)cell);
                break;
                
                case CellType.Cac_Contact_Cell:
                storage.SaveCac_Contact_Cell(cellId, (Cac_Contact_Cell)cell);
                break;
                
                case CellType.Cac_Person_Cell:
                storage.SaveCac_Person_Cell(cellId, (Cac_Person_Cell)cell);
                break;
                
                case CellType.Cac_PaymentMeans_Cell:
                storage.SaveCac_PaymentMeans_Cell(cellId, (Cac_PaymentMeans_Cell)cell);
                break;
                
                case CellType.Cac_PayeeFinancialAccount_Cell:
                storage.SaveCac_PayeeFinancialAccount_Cell(cellId, (Cac_PayeeFinancialAccount_Cell)cell);
                break;
                
                case CellType.Cac_Party_Cell:
                storage.SaveCac_Party_Cell(cellId, (Cac_Party_Cell)cell);
                break;
                
                case CellType.UBL21_Invoice2_Cell:
                storage.SaveUBL21_Invoice2_Cell(cellId, (UBL21_Invoice2_Cell)cell);
                break;
                
            }
        }
        /// <inheritdoc/>
        public unsafe ICell LoadGenericCell(IKeyValueStore storage, long cellId)
        {
            ushort type;
            byte[] buff;
            var err = storage.LoadCell(cellId, out buff, out type);
            if (err != TrinityErrorCode.E_SUCCESS)
            {
                switch (err)
                {
                    case TrinityErrorCode.E_CELL_NOT_FOUND:
                    throw new CellNotFoundException("Cannot access the cell.");
                    case TrinityErrorCode.E_NETWORK_SEND_FAILURE:
                    throw new System.IO.IOException("Network error while accessing the cell.");
                    default:
                    throw new Exception("Cannot access the cell. Error code: " + err.ToString());
                }
            }
            fixed (byte* p = buff)
            {
                var accessor = UseGenericCell(cellId, p, -1, type);
                return accessor.Deserialize();
            }
        }
        /// <inheritdoc/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe ICellAccessor UseGenericCell(long cellId, byte* cellPtr, int entryIndex, ushort cellType)
         => UseGenericCell(cellId, cellPtr, entryIndex, cellType, CellAccessOptions.ThrowExceptionOnCellNotFound);
        /// <inheritdoc/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe ICellAccessor UseGenericCell(long cellId, byte* cellBuffer, int entryIndex, ushort cellType, CellAccessOptions options)
        {
            switch ((CellType)cellType)
            {
                
                case CellType.TRACredential_Cell:
                return TRACredential_Cell_Accessor._get()._Setup(cellId, cellBuffer, entryIndex, options);
                
                case CellType.TRATimestamp_Cell:
                return TRATimestamp_Cell_Accessor._get()._Setup(cellId, cellBuffer, entryIndex, options);
                
                case CellType.TDWGeoLocation_Cell:
                return TDWGeoLocation_Cell_Accessor._get()._Setup(cellId, cellBuffer, entryIndex, options);
                
                case CellType.TRAPostalAddress_Cell:
                return TRAPostalAddress_Cell_Accessor._get()._Setup(cellId, cellBuffer, entryIndex, options);
                
                case CellType.Cac_Item_Cell:
                return Cac_Item_Cell_Accessor._get()._Setup(cellId, cellBuffer, entryIndex, options);
                
                case CellType.Cac_ExternalReference_Cell:
                return Cac_ExternalReference_Cell_Accessor._get()._Setup(cellId, cellBuffer, entryIndex, options);
                
                case CellType.Cac_Address_Cell:
                return Cac_Address_Cell_Accessor._get()._Setup(cellId, cellBuffer, entryIndex, options);
                
                case CellType.Cac_PostalAddress_Cell:
                return Cac_PostalAddress_Cell_Accessor._get()._Setup(cellId, cellBuffer, entryIndex, options);
                
                case CellType.Cac_PartyLegalEntity_Cell:
                return Cac_PartyLegalEntity_Cell_Accessor._get()._Setup(cellId, cellBuffer, entryIndex, options);
                
                case CellType.Cac_Contact_Cell:
                return Cac_Contact_Cell_Accessor._get()._Setup(cellId, cellBuffer, entryIndex, options);
                
                case CellType.Cac_Person_Cell:
                return Cac_Person_Cell_Accessor._get()._Setup(cellId, cellBuffer, entryIndex, options);
                
                case CellType.Cac_PaymentMeans_Cell:
                return Cac_PaymentMeans_Cell_Accessor._get()._Setup(cellId, cellBuffer, entryIndex, options);
                
                case CellType.Cac_PayeeFinancialAccount_Cell:
                return Cac_PayeeFinancialAccount_Cell_Accessor._get()._Setup(cellId, cellBuffer, entryIndex, options);
                
                case CellType.Cac_Party_Cell:
                return Cac_Party_Cell_Accessor._get()._Setup(cellId, cellBuffer, entryIndex, options);
                
                case CellType.UBL21_Invoice2_Cell:
                return UBL21_Invoice2_Cell_Accessor._get()._Setup(cellId, cellBuffer, entryIndex, options);
                
                default:
                throw new CellTypeNotMatchException("Cannot determine cell type.");
            }
        }
        #endregion
    }
}

#pragma warning restore 162,168,649,660,661,1522
