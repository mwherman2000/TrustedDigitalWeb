#pragma warning disable 162,168,649,660,661,1522

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using Trinity;
using Trinity.Storage;
using Trinity.TSL;
using Trinity.TSL.Lib;
namespace TDW.TDACommon
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
                
                case CellType.TDARootCell:
                storage.SaveTDARootCell(writeAheadLogOptions, (TDARootCell)cell);
                break;
                
                case CellType.TDABasketItemCell:
                storage.SaveTDABasketItemCell(writeAheadLogOptions, (TDABasketItemCell)cell);
                break;
                
                case CellType.TDASubledgerCell:
                storage.SaveTDASubledgerCell(writeAheadLogOptions, (TDASubledgerCell)cell);
                break;
                
                case CellType.TDAMasterKeyLedgerCell:
                storage.SaveTDAMasterKeyLedgerCell(writeAheadLogOptions, (TDAMasterKeyLedgerCell)cell);
                break;
                
                case CellType.TDAKeyRingLedgerCell:
                storage.SaveTDAKeyRingLedgerCell(writeAheadLogOptions, (TDAKeyRingLedgerCell)cell);
                break;
                
                case CellType.TDAWalletLedgerCell:
                storage.SaveTDAWalletLedgerCell(writeAheadLogOptions, (TDAWalletLedgerCell)cell);
                break;
                
                case CellType.TDAVDAddressLedgerCell:
                storage.SaveTDAVDAddressLedgerCell(writeAheadLogOptions, (TDAVDAddressLedgerCell)cell);
                break;
                
            }
        }
        /// <inheritdoc/>
        public void SaveGenericCell(Trinity.Storage.LocalMemoryStorage storage, CellAccessOptions writeAheadLogOptions, long cellId, ICell cell)
        {
            switch ((CellType)cell.CellType)
            {
                
                case CellType.TDARootCell:
                storage.SaveTDARootCell(writeAheadLogOptions, cellId, (TDARootCell)cell);
                break;
                
                case CellType.TDABasketItemCell:
                storage.SaveTDABasketItemCell(writeAheadLogOptions, cellId, (TDABasketItemCell)cell);
                break;
                
                case CellType.TDASubledgerCell:
                storage.SaveTDASubledgerCell(writeAheadLogOptions, cellId, (TDASubledgerCell)cell);
                break;
                
                case CellType.TDAMasterKeyLedgerCell:
                storage.SaveTDAMasterKeyLedgerCell(writeAheadLogOptions, cellId, (TDAMasterKeyLedgerCell)cell);
                break;
                
                case CellType.TDAKeyRingLedgerCell:
                storage.SaveTDAKeyRingLedgerCell(writeAheadLogOptions, cellId, (TDAKeyRingLedgerCell)cell);
                break;
                
                case CellType.TDAWalletLedgerCell:
                storage.SaveTDAWalletLedgerCell(writeAheadLogOptions, cellId, (TDAWalletLedgerCell)cell);
                break;
                
                case CellType.TDAVDAddressLedgerCell:
                storage.SaveTDAVDAddressLedgerCell(writeAheadLogOptions, cellId, (TDAVDAddressLedgerCell)cell);
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
                
                case global::TDW.TDACommon.CellType.TDARootCell:
                return new TDARootCell();
                break;
                
                case global::TDW.TDACommon.CellType.TDABasketItemCell:
                return new TDABasketItemCell();
                break;
                
                case global::TDW.TDACommon.CellType.TDASubledgerCell:
                return new TDASubledgerCell();
                break;
                
                case global::TDW.TDACommon.CellType.TDAMasterKeyLedgerCell:
                return new TDAMasterKeyLedgerCell();
                break;
                
                case global::TDW.TDACommon.CellType.TDAKeyRingLedgerCell:
                return new TDAKeyRingLedgerCell();
                break;
                
                case global::TDW.TDACommon.CellType.TDAWalletLedgerCell:
                return new TDAWalletLedgerCell();
                break;
                
                case global::TDW.TDACommon.CellType.TDAVDAddressLedgerCell:
                return new TDAVDAddressLedgerCell();
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
                
                case global::TDW.TDACommon.CellType.TDARootCell:
                return new TDARootCell(cell_id: cellId);
                
                case global::TDW.TDACommon.CellType.TDABasketItemCell:
                return new TDABasketItemCell(cell_id: cellId);
                
                case global::TDW.TDACommon.CellType.TDASubledgerCell:
                return new TDASubledgerCell(cell_id: cellId);
                
                case global::TDW.TDACommon.CellType.TDAMasterKeyLedgerCell:
                return new TDAMasterKeyLedgerCell(cell_id: cellId);
                
                case global::TDW.TDACommon.CellType.TDAKeyRingLedgerCell:
                return new TDAKeyRingLedgerCell(cell_id: cellId);
                
                case global::TDW.TDACommon.CellType.TDAWalletLedgerCell:
                return new TDAWalletLedgerCell(cell_id: cellId);
                
                case global::TDW.TDACommon.CellType.TDAVDAddressLedgerCell:
                return new TDAVDAddressLedgerCell(cell_id: cellId);
                
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
                
                case global::TDW.TDACommon.CellType.TDARootCell:
                return TDARootCell.Parse(content);
                
                case global::TDW.TDACommon.CellType.TDABasketItemCell:
                return TDABasketItemCell.Parse(content);
                
                case global::TDW.TDACommon.CellType.TDASubledgerCell:
                return TDASubledgerCell.Parse(content);
                
                case global::TDW.TDACommon.CellType.TDAMasterKeyLedgerCell:
                return TDAMasterKeyLedgerCell.Parse(content);
                
                case global::TDW.TDACommon.CellType.TDAKeyRingLedgerCell:
                return TDAKeyRingLedgerCell.Parse(content);
                
                case global::TDW.TDACommon.CellType.TDAWalletLedgerCell:
                return TDAWalletLedgerCell.Parse(content);
                
                case global::TDW.TDACommon.CellType.TDAVDAddressLedgerCell:
                return TDAVDAddressLedgerCell.Parse(content);
                
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
                
                case CellType.TDARootCell:
                return TDARootCell_Accessor._get()._Setup(cellId, cellPtr, entryIndex, CellAccessOptions.ThrowExceptionOnCellNotFound);
                
                case CellType.TDABasketItemCell:
                return TDABasketItemCell_Accessor._get()._Setup(cellId, cellPtr, entryIndex, CellAccessOptions.ThrowExceptionOnCellNotFound);
                
                case CellType.TDASubledgerCell:
                return TDASubledgerCell_Accessor._get()._Setup(cellId, cellPtr, entryIndex, CellAccessOptions.ThrowExceptionOnCellNotFound);
                
                case CellType.TDAMasterKeyLedgerCell:
                return TDAMasterKeyLedgerCell_Accessor._get()._Setup(cellId, cellPtr, entryIndex, CellAccessOptions.ThrowExceptionOnCellNotFound);
                
                case CellType.TDAKeyRingLedgerCell:
                return TDAKeyRingLedgerCell_Accessor._get()._Setup(cellId, cellPtr, entryIndex, CellAccessOptions.ThrowExceptionOnCellNotFound);
                
                case CellType.TDAWalletLedgerCell:
                return TDAWalletLedgerCell_Accessor._get()._Setup(cellId, cellPtr, entryIndex, CellAccessOptions.ThrowExceptionOnCellNotFound);
                
                case CellType.TDAVDAddressLedgerCell:
                return TDAVDAddressLedgerCell_Accessor._get()._Setup(cellId, cellPtr, entryIndex, CellAccessOptions.ThrowExceptionOnCellNotFound);
                
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
                
                case "TDARootCell": return TDARootCell_Accessor._get()._Lock(cellId, options);
                
                case "TDABasketItemCell": return TDABasketItemCell_Accessor._get()._Lock(cellId, options);
                
                case "TDASubledgerCell": return TDASubledgerCell_Accessor._get()._Lock(cellId, options);
                
                case "TDAMasterKeyLedgerCell": return TDAMasterKeyLedgerCell_Accessor._get()._Lock(cellId, options);
                
                case "TDAKeyRingLedgerCell": return TDAKeyRingLedgerCell_Accessor._get()._Lock(cellId, options);
                
                case "TDAWalletLedgerCell": return TDAWalletLedgerCell_Accessor._get()._Lock(cellId, options);
                
                case "TDAVDAddressLedgerCell": return TDAVDAddressLedgerCell_Accessor._get()._Lock(cellId, options);
                
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
                    
                    case CellType.TDARootCell:
                        {
                            var TDARootCell_accessor = TDARootCell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            var TDARootCell_cell     = (TDARootCell)TDARootCell_accessor;
                            TDARootCell_accessor.Dispose();
                            yield return TDARootCell_cell;
                            break;
                        }
                    
                    case CellType.TDABasketItemCell:
                        {
                            var TDABasketItemCell_accessor = TDABasketItemCell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            var TDABasketItemCell_cell     = (TDABasketItemCell)TDABasketItemCell_accessor;
                            TDABasketItemCell_accessor.Dispose();
                            yield return TDABasketItemCell_cell;
                            break;
                        }
                    
                    case CellType.TDASubledgerCell:
                        {
                            var TDASubledgerCell_accessor = TDASubledgerCell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            var TDASubledgerCell_cell     = (TDASubledgerCell)TDASubledgerCell_accessor;
                            TDASubledgerCell_accessor.Dispose();
                            yield return TDASubledgerCell_cell;
                            break;
                        }
                    
                    case CellType.TDAMasterKeyLedgerCell:
                        {
                            var TDAMasterKeyLedgerCell_accessor = TDAMasterKeyLedgerCell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            var TDAMasterKeyLedgerCell_cell     = (TDAMasterKeyLedgerCell)TDAMasterKeyLedgerCell_accessor;
                            TDAMasterKeyLedgerCell_accessor.Dispose();
                            yield return TDAMasterKeyLedgerCell_cell;
                            break;
                        }
                    
                    case CellType.TDAKeyRingLedgerCell:
                        {
                            var TDAKeyRingLedgerCell_accessor = TDAKeyRingLedgerCell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            var TDAKeyRingLedgerCell_cell     = (TDAKeyRingLedgerCell)TDAKeyRingLedgerCell_accessor;
                            TDAKeyRingLedgerCell_accessor.Dispose();
                            yield return TDAKeyRingLedgerCell_cell;
                            break;
                        }
                    
                    case CellType.TDAWalletLedgerCell:
                        {
                            var TDAWalletLedgerCell_accessor = TDAWalletLedgerCell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            var TDAWalletLedgerCell_cell     = (TDAWalletLedgerCell)TDAWalletLedgerCell_accessor;
                            TDAWalletLedgerCell_accessor.Dispose();
                            yield return TDAWalletLedgerCell_cell;
                            break;
                        }
                    
                    case CellType.TDAVDAddressLedgerCell:
                        {
                            var TDAVDAddressLedgerCell_accessor = TDAVDAddressLedgerCell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            var TDAVDAddressLedgerCell_cell     = (TDAVDAddressLedgerCell)TDAVDAddressLedgerCell_accessor;
                            TDAVDAddressLedgerCell_accessor.Dispose();
                            yield return TDAVDAddressLedgerCell_cell;
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
                    
                    case CellType.TDARootCell:
                        {
                            var TDARootCell_accessor = TDARootCell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            yield return TDARootCell_accessor;
                            TDARootCell_accessor.Dispose();
                            break;
                        }
                    
                    case CellType.TDABasketItemCell:
                        {
                            var TDABasketItemCell_accessor = TDABasketItemCell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            yield return TDABasketItemCell_accessor;
                            TDABasketItemCell_accessor.Dispose();
                            break;
                        }
                    
                    case CellType.TDASubledgerCell:
                        {
                            var TDASubledgerCell_accessor = TDASubledgerCell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            yield return TDASubledgerCell_accessor;
                            TDASubledgerCell_accessor.Dispose();
                            break;
                        }
                    
                    case CellType.TDAMasterKeyLedgerCell:
                        {
                            var TDAMasterKeyLedgerCell_accessor = TDAMasterKeyLedgerCell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            yield return TDAMasterKeyLedgerCell_accessor;
                            TDAMasterKeyLedgerCell_accessor.Dispose();
                            break;
                        }
                    
                    case CellType.TDAKeyRingLedgerCell:
                        {
                            var TDAKeyRingLedgerCell_accessor = TDAKeyRingLedgerCell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            yield return TDAKeyRingLedgerCell_accessor;
                            TDAKeyRingLedgerCell_accessor.Dispose();
                            break;
                        }
                    
                    case CellType.TDAWalletLedgerCell:
                        {
                            var TDAWalletLedgerCell_accessor = TDAWalletLedgerCell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            yield return TDAWalletLedgerCell_accessor;
                            TDAWalletLedgerCell_accessor.Dispose();
                            break;
                        }
                    
                    case CellType.TDAVDAddressLedgerCell:
                        {
                            var TDAVDAddressLedgerCell_accessor = TDAVDAddressLedgerCell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            yield return TDAVDAddressLedgerCell_accessor;
                            TDAVDAddressLedgerCell_accessor.Dispose();
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
                
                case CellType.TDARootCell:
                storage.SaveTDARootCell((TDARootCell)cell);
                break;
                
                case CellType.TDABasketItemCell:
                storage.SaveTDABasketItemCell((TDABasketItemCell)cell);
                break;
                
                case CellType.TDASubledgerCell:
                storage.SaveTDASubledgerCell((TDASubledgerCell)cell);
                break;
                
                case CellType.TDAMasterKeyLedgerCell:
                storage.SaveTDAMasterKeyLedgerCell((TDAMasterKeyLedgerCell)cell);
                break;
                
                case CellType.TDAKeyRingLedgerCell:
                storage.SaveTDAKeyRingLedgerCell((TDAKeyRingLedgerCell)cell);
                break;
                
                case CellType.TDAWalletLedgerCell:
                storage.SaveTDAWalletLedgerCell((TDAWalletLedgerCell)cell);
                break;
                
                case CellType.TDAVDAddressLedgerCell:
                storage.SaveTDAVDAddressLedgerCell((TDAVDAddressLedgerCell)cell);
                break;
                
            }
        }
        /// <inheritdoc/>
        public void SaveGenericCell(IKeyValueStore storage, long cellId, ICell cell)
        {
            switch ((CellType)cell.CellType)
            {
                
                case CellType.TDARootCell:
                storage.SaveTDARootCell(cellId, (TDARootCell)cell);
                break;
                
                case CellType.TDABasketItemCell:
                storage.SaveTDABasketItemCell(cellId, (TDABasketItemCell)cell);
                break;
                
                case CellType.TDASubledgerCell:
                storage.SaveTDASubledgerCell(cellId, (TDASubledgerCell)cell);
                break;
                
                case CellType.TDAMasterKeyLedgerCell:
                storage.SaveTDAMasterKeyLedgerCell(cellId, (TDAMasterKeyLedgerCell)cell);
                break;
                
                case CellType.TDAKeyRingLedgerCell:
                storage.SaveTDAKeyRingLedgerCell(cellId, (TDAKeyRingLedgerCell)cell);
                break;
                
                case CellType.TDAWalletLedgerCell:
                storage.SaveTDAWalletLedgerCell(cellId, (TDAWalletLedgerCell)cell);
                break;
                
                case CellType.TDAVDAddressLedgerCell:
                storage.SaveTDAVDAddressLedgerCell(cellId, (TDAVDAddressLedgerCell)cell);
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
                
                case CellType.TDARootCell:
                return TDARootCell_Accessor._get()._Setup(cellId, cellBuffer, entryIndex, options);
                
                case CellType.TDABasketItemCell:
                return TDABasketItemCell_Accessor._get()._Setup(cellId, cellBuffer, entryIndex, options);
                
                case CellType.TDASubledgerCell:
                return TDASubledgerCell_Accessor._get()._Setup(cellId, cellBuffer, entryIndex, options);
                
                case CellType.TDAMasterKeyLedgerCell:
                return TDAMasterKeyLedgerCell_Accessor._get()._Setup(cellId, cellBuffer, entryIndex, options);
                
                case CellType.TDAKeyRingLedgerCell:
                return TDAKeyRingLedgerCell_Accessor._get()._Setup(cellId, cellBuffer, entryIndex, options);
                
                case CellType.TDAWalletLedgerCell:
                return TDAWalletLedgerCell_Accessor._get()._Setup(cellId, cellBuffer, entryIndex, options);
                
                case CellType.TDAVDAddressLedgerCell:
                return TDAVDAddressLedgerCell_Accessor._get()._Setup(cellId, cellBuffer, entryIndex, options);
                
                default:
                throw new CellTypeNotMatchException("Cannot determine cell type.");
            }
        }
        #endregion
    }
}

#pragma warning restore 162,168,649,660,661,1522
