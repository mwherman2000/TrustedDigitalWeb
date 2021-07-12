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
                
                case CellType.TRACredentialCell:
                storage.SaveTRACredentialCell(writeAheadLogOptions, (TRACredentialCell)cell);
                break;
                
                case CellType.TRATimestampCell:
                storage.SaveTRATimestampCell(writeAheadLogOptions, (TRATimestampCell)cell);
                break;
                
                case CellType.TDWGeoLocationCell:
                storage.SaveTDWGeoLocationCell(writeAheadLogOptions, (TDWGeoLocationCell)cell);
                break;
                
                case CellType.TRAPostalAddressCell:
                storage.SaveTRAPostalAddressCell(writeAheadLogOptions, (TRAPostalAddressCell)cell);
                break;
                
            }
        }
        /// <inheritdoc/>
        public void SaveGenericCell(Trinity.Storage.LocalMemoryStorage storage, CellAccessOptions writeAheadLogOptions, long cellId, ICell cell)
        {
            switch ((CellType)cell.CellType)
            {
                
                case CellType.TRACredentialCell:
                storage.SaveTRACredentialCell(writeAheadLogOptions, cellId, (TRACredentialCell)cell);
                break;
                
                case CellType.TRATimestampCell:
                storage.SaveTRATimestampCell(writeAheadLogOptions, cellId, (TRATimestampCell)cell);
                break;
                
                case CellType.TDWGeoLocationCell:
                storage.SaveTDWGeoLocationCell(writeAheadLogOptions, cellId, (TDWGeoLocationCell)cell);
                break;
                
                case CellType.TRAPostalAddressCell:
                storage.SaveTRAPostalAddressCell(writeAheadLogOptions, cellId, (TRAPostalAddressCell)cell);
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
                
                case global::TDW.TRAServer.CellType.TRACredentialCell:
                return new TRACredentialCell();
                break;
                
                case global::TDW.TRAServer.CellType.TRATimestampCell:
                return new TRATimestampCell();
                break;
                
                case global::TDW.TRAServer.CellType.TDWGeoLocationCell:
                return new TDWGeoLocationCell();
                break;
                
                case global::TDW.TRAServer.CellType.TRAPostalAddressCell:
                return new TRAPostalAddressCell();
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
                
                case global::TDW.TRAServer.CellType.TRACredentialCell:
                return new TRACredentialCell(cell_id: cellId);
                
                case global::TDW.TRAServer.CellType.TRATimestampCell:
                return new TRATimestampCell(cell_id: cellId);
                
                case global::TDW.TRAServer.CellType.TDWGeoLocationCell:
                return new TDWGeoLocationCell(cell_id: cellId);
                
                case global::TDW.TRAServer.CellType.TRAPostalAddressCell:
                return new TRAPostalAddressCell(cell_id: cellId);
                
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
                
                case global::TDW.TRAServer.CellType.TRACredentialCell:
                return TRACredentialCell.Parse(content);
                
                case global::TDW.TRAServer.CellType.TRATimestampCell:
                return TRATimestampCell.Parse(content);
                
                case global::TDW.TRAServer.CellType.TDWGeoLocationCell:
                return TDWGeoLocationCell.Parse(content);
                
                case global::TDW.TRAServer.CellType.TRAPostalAddressCell:
                return TRAPostalAddressCell.Parse(content);
                
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
                
                case CellType.TRACredentialCell:
                return TRACredentialCell_Accessor._get()._Setup(cellId, cellPtr, entryIndex, CellAccessOptions.ThrowExceptionOnCellNotFound);
                
                case CellType.TRATimestampCell:
                return TRATimestampCell_Accessor._get()._Setup(cellId, cellPtr, entryIndex, CellAccessOptions.ThrowExceptionOnCellNotFound);
                
                case CellType.TDWGeoLocationCell:
                return TDWGeoLocationCell_Accessor._get()._Setup(cellId, cellPtr, entryIndex, CellAccessOptions.ThrowExceptionOnCellNotFound);
                
                case CellType.TRAPostalAddressCell:
                return TRAPostalAddressCell_Accessor._get()._Setup(cellId, cellPtr, entryIndex, CellAccessOptions.ThrowExceptionOnCellNotFound);
                
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
                
                case "TRACredentialCell": return TRACredentialCell_Accessor._get()._Lock(cellId, options);
                
                case "TRATimestampCell": return TRATimestampCell_Accessor._get()._Lock(cellId, options);
                
                case "TDWGeoLocationCell": return TDWGeoLocationCell_Accessor._get()._Lock(cellId, options);
                
                case "TRAPostalAddressCell": return TRAPostalAddressCell_Accessor._get()._Lock(cellId, options);
                
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
                    
                    case CellType.TRACredentialCell:
                        {
                            var TRACredentialCell_accessor = TRACredentialCell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            var TRACredentialCell_cell     = (TRACredentialCell)TRACredentialCell_accessor;
                            TRACredentialCell_accessor.Dispose();
                            yield return TRACredentialCell_cell;
                            break;
                        }
                    
                    case CellType.TRATimestampCell:
                        {
                            var TRATimestampCell_accessor = TRATimestampCell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            var TRATimestampCell_cell     = (TRATimestampCell)TRATimestampCell_accessor;
                            TRATimestampCell_accessor.Dispose();
                            yield return TRATimestampCell_cell;
                            break;
                        }
                    
                    case CellType.TDWGeoLocationCell:
                        {
                            var TDWGeoLocationCell_accessor = TDWGeoLocationCell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            var TDWGeoLocationCell_cell     = (TDWGeoLocationCell)TDWGeoLocationCell_accessor;
                            TDWGeoLocationCell_accessor.Dispose();
                            yield return TDWGeoLocationCell_cell;
                            break;
                        }
                    
                    case CellType.TRAPostalAddressCell:
                        {
                            var TRAPostalAddressCell_accessor = TRAPostalAddressCell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            var TRAPostalAddressCell_cell     = (TRAPostalAddressCell)TRAPostalAddressCell_accessor;
                            TRAPostalAddressCell_accessor.Dispose();
                            yield return TRAPostalAddressCell_cell;
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
                    
                    case CellType.TRACredentialCell:
                        {
                            var TRACredentialCell_accessor = TRACredentialCell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            yield return TRACredentialCell_accessor;
                            TRACredentialCell_accessor.Dispose();
                            break;
                        }
                    
                    case CellType.TRATimestampCell:
                        {
                            var TRATimestampCell_accessor = TRATimestampCell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            yield return TRATimestampCell_accessor;
                            TRATimestampCell_accessor.Dispose();
                            break;
                        }
                    
                    case CellType.TDWGeoLocationCell:
                        {
                            var TDWGeoLocationCell_accessor = TDWGeoLocationCell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            yield return TDWGeoLocationCell_accessor;
                            TDWGeoLocationCell_accessor.Dispose();
                            break;
                        }
                    
                    case CellType.TRAPostalAddressCell:
                        {
                            var TRAPostalAddressCell_accessor = TRAPostalAddressCell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            yield return TRAPostalAddressCell_accessor;
                            TRAPostalAddressCell_accessor.Dispose();
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
                
                case CellType.TRACredentialCell:
                storage.SaveTRACredentialCell((TRACredentialCell)cell);
                break;
                
                case CellType.TRATimestampCell:
                storage.SaveTRATimestampCell((TRATimestampCell)cell);
                break;
                
                case CellType.TDWGeoLocationCell:
                storage.SaveTDWGeoLocationCell((TDWGeoLocationCell)cell);
                break;
                
                case CellType.TRAPostalAddressCell:
                storage.SaveTRAPostalAddressCell((TRAPostalAddressCell)cell);
                break;
                
            }
        }
        /// <inheritdoc/>
        public void SaveGenericCell(IKeyValueStore storage, long cellId, ICell cell)
        {
            switch ((CellType)cell.CellType)
            {
                
                case CellType.TRACredentialCell:
                storage.SaveTRACredentialCell(cellId, (TRACredentialCell)cell);
                break;
                
                case CellType.TRATimestampCell:
                storage.SaveTRATimestampCell(cellId, (TRATimestampCell)cell);
                break;
                
                case CellType.TDWGeoLocationCell:
                storage.SaveTDWGeoLocationCell(cellId, (TDWGeoLocationCell)cell);
                break;
                
                case CellType.TRAPostalAddressCell:
                storage.SaveTRAPostalAddressCell(cellId, (TRAPostalAddressCell)cell);
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
                
                case CellType.TRACredentialCell:
                return TRACredentialCell_Accessor._get()._Setup(cellId, cellBuffer, entryIndex, options);
                
                case CellType.TRATimestampCell:
                return TRATimestampCell_Accessor._get()._Setup(cellId, cellBuffer, entryIndex, options);
                
                case CellType.TDWGeoLocationCell:
                return TDWGeoLocationCell_Accessor._get()._Setup(cellId, cellBuffer, entryIndex, options);
                
                case CellType.TRAPostalAddressCell:
                return TRAPostalAddressCell_Accessor._get()._Setup(cellId, cellBuffer, entryIndex, options);
                
                default:
                throw new CellTypeNotMatchException("Cannot determine cell type.");
            }
        }
        #endregion
    }
}

#pragma warning restore 162,168,649,660,661,1522
