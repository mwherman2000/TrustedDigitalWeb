#pragma warning disable 162,168,649,660,661,1522

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using Trinity;
using Trinity.Storage;
using Trinity.TSL;
using Trinity.TSL.Lib;
namespace TDW.VDAServer
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
                
                case CellType.TDWVDAAccountEntry_Cell:
                storage.SaveTDWVDAAccountEntry_Cell(writeAheadLogOptions, (TDWVDAAccountEntry_Cell)cell);
                break;
                
                case CellType.TDWVDASmartContractEntry_Cell:
                storage.SaveTDWVDASmartContractEntry_Cell(writeAheadLogOptions, (TDWVDASmartContractEntry_Cell)cell);
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
                
                case CellType.TDWVDAAccountEntry_Cell:
                storage.SaveTDWVDAAccountEntry_Cell(writeAheadLogOptions, cellId, (TDWVDAAccountEntry_Cell)cell);
                break;
                
                case CellType.TDWVDASmartContractEntry_Cell:
                storage.SaveTDWVDASmartContractEntry_Cell(writeAheadLogOptions, cellId, (TDWVDASmartContractEntry_Cell)cell);
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
                
                case global::TDW.VDAServer.CellType.TRACredential_Cell:
                return new TRACredential_Cell();
                break;
                
                case global::TDW.VDAServer.CellType.TDWVDAAccountEntry_Cell:
                return new TDWVDAAccountEntry_Cell();
                break;
                
                case global::TDW.VDAServer.CellType.TDWVDASmartContractEntry_Cell:
                return new TDWVDASmartContractEntry_Cell();
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
                
                case global::TDW.VDAServer.CellType.TRACredential_Cell:
                return new TRACredential_Cell(cell_id: cellId);
                
                case global::TDW.VDAServer.CellType.TDWVDAAccountEntry_Cell:
                return new TDWVDAAccountEntry_Cell(cell_id: cellId);
                
                case global::TDW.VDAServer.CellType.TDWVDASmartContractEntry_Cell:
                return new TDWVDASmartContractEntry_Cell(cell_id: cellId);
                
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
                
                case global::TDW.VDAServer.CellType.TRACredential_Cell:
                return TRACredential_Cell.Parse(content);
                
                case global::TDW.VDAServer.CellType.TDWVDAAccountEntry_Cell:
                return TDWVDAAccountEntry_Cell.Parse(content);
                
                case global::TDW.VDAServer.CellType.TDWVDASmartContractEntry_Cell:
                return TDWVDASmartContractEntry_Cell.Parse(content);
                
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
                
                case CellType.TDWVDAAccountEntry_Cell:
                return TDWVDAAccountEntry_Cell_Accessor._get()._Setup(cellId, cellPtr, entryIndex, CellAccessOptions.ThrowExceptionOnCellNotFound);
                
                case CellType.TDWVDASmartContractEntry_Cell:
                return TDWVDASmartContractEntry_Cell_Accessor._get()._Setup(cellId, cellPtr, entryIndex, CellAccessOptions.ThrowExceptionOnCellNotFound);
                
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
                
                case "TDWVDAAccountEntry_Cell": return TDWVDAAccountEntry_Cell_Accessor._get()._Lock(cellId, options);
                
                case "TDWVDASmartContractEntry_Cell": return TDWVDASmartContractEntry_Cell_Accessor._get()._Lock(cellId, options);
                
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
                    
                    case CellType.TDWVDAAccountEntry_Cell:
                        {
                            var TDWVDAAccountEntry_Cell_accessor = TDWVDAAccountEntry_Cell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            var TDWVDAAccountEntry_Cell_cell     = (TDWVDAAccountEntry_Cell)TDWVDAAccountEntry_Cell_accessor;
                            TDWVDAAccountEntry_Cell_accessor.Dispose();
                            yield return TDWVDAAccountEntry_Cell_cell;
                            break;
                        }
                    
                    case CellType.TDWVDASmartContractEntry_Cell:
                        {
                            var TDWVDASmartContractEntry_Cell_accessor = TDWVDASmartContractEntry_Cell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            var TDWVDASmartContractEntry_Cell_cell     = (TDWVDASmartContractEntry_Cell)TDWVDASmartContractEntry_Cell_accessor;
                            TDWVDASmartContractEntry_Cell_accessor.Dispose();
                            yield return TDWVDASmartContractEntry_Cell_cell;
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
                    
                    case CellType.TDWVDAAccountEntry_Cell:
                        {
                            var TDWVDAAccountEntry_Cell_accessor = TDWVDAAccountEntry_Cell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            yield return TDWVDAAccountEntry_Cell_accessor;
                            TDWVDAAccountEntry_Cell_accessor.Dispose();
                            break;
                        }
                    
                    case CellType.TDWVDASmartContractEntry_Cell:
                        {
                            var TDWVDASmartContractEntry_Cell_accessor = TDWVDASmartContractEntry_Cell_Accessor.AllocIterativeAccessor(cellInfo, null);
                            yield return TDWVDASmartContractEntry_Cell_accessor;
                            TDWVDASmartContractEntry_Cell_accessor.Dispose();
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
                
                case CellType.TDWVDAAccountEntry_Cell:
                storage.SaveTDWVDAAccountEntry_Cell((TDWVDAAccountEntry_Cell)cell);
                break;
                
                case CellType.TDWVDASmartContractEntry_Cell:
                storage.SaveTDWVDASmartContractEntry_Cell((TDWVDASmartContractEntry_Cell)cell);
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
                
                case CellType.TDWVDAAccountEntry_Cell:
                storage.SaveTDWVDAAccountEntry_Cell(cellId, (TDWVDAAccountEntry_Cell)cell);
                break;
                
                case CellType.TDWVDASmartContractEntry_Cell:
                storage.SaveTDWVDASmartContractEntry_Cell(cellId, (TDWVDASmartContractEntry_Cell)cell);
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
                
                case CellType.TDWVDAAccountEntry_Cell:
                return TDWVDAAccountEntry_Cell_Accessor._get()._Setup(cellId, cellBuffer, entryIndex, options);
                
                case CellType.TDWVDASmartContractEntry_Cell:
                return TDWVDASmartContractEntry_Cell_Accessor._get()._Setup(cellId, cellBuffer, entryIndex, options);
                
                default:
                throw new CellTypeNotMatchException("Cannot determine cell type.");
            }
        }
        #endregion
    }
}

#pragma warning restore 162,168,649,660,661,1522
