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
                
                case CellType.TDWVDAAccount:
                storage.SaveTDWVDAAccount(writeAheadLogOptions, (TDWVDAAccount)cell);
                break;
                
                case CellType.TDWVDASmartContract:
                storage.SaveTDWVDASmartContract(writeAheadLogOptions, (TDWVDASmartContract)cell);
                break;
                
            }
        }
        /// <inheritdoc/>
        public void SaveGenericCell(Trinity.Storage.LocalMemoryStorage storage, CellAccessOptions writeAheadLogOptions, long cellId, ICell cell)
        {
            switch ((CellType)cell.CellType)
            {
                
                case CellType.TDWVDAAccount:
                storage.SaveTDWVDAAccount(writeAheadLogOptions, cellId, (TDWVDAAccount)cell);
                break;
                
                case CellType.TDWVDASmartContract:
                storage.SaveTDWVDASmartContract(writeAheadLogOptions, cellId, (TDWVDASmartContract)cell);
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
                
                case global::TDW.VDAServer.CellType.TDWVDAAccount:
                return new TDWVDAAccount();
                break;
                
                case global::TDW.VDAServer.CellType.TDWVDASmartContract:
                return new TDWVDASmartContract();
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
                
                case global::TDW.VDAServer.CellType.TDWVDAAccount:
                return new TDWVDAAccount(cell_id: cellId);
                
                case global::TDW.VDAServer.CellType.TDWVDASmartContract:
                return new TDWVDASmartContract(cell_id: cellId);
                
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
                
                case global::TDW.VDAServer.CellType.TDWVDAAccount:
                return TDWVDAAccount.Parse(content);
                
                case global::TDW.VDAServer.CellType.TDWVDASmartContract:
                return TDWVDASmartContract.Parse(content);
                
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
                
                case CellType.TDWVDAAccount:
                return TDWVDAAccount_Accessor._get()._Setup(cellId, cellPtr, entryIndex, CellAccessOptions.ThrowExceptionOnCellNotFound);
                
                case CellType.TDWVDASmartContract:
                return TDWVDASmartContract_Accessor._get()._Setup(cellId, cellPtr, entryIndex, CellAccessOptions.ThrowExceptionOnCellNotFound);
                
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
                
                case "TDWVDAAccount": return TDWVDAAccount_Accessor._get()._Lock(cellId, options);
                
                case "TDWVDASmartContract": return TDWVDASmartContract_Accessor._get()._Lock(cellId, options);
                
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
                    
                    case CellType.TDWVDAAccount:
                        {
                            var TDWVDAAccount_accessor = TDWVDAAccount_Accessor.AllocIterativeAccessor(cellInfo, null);
                            var TDWVDAAccount_cell     = (TDWVDAAccount)TDWVDAAccount_accessor;
                            TDWVDAAccount_accessor.Dispose();
                            yield return TDWVDAAccount_cell;
                            break;
                        }
                    
                    case CellType.TDWVDASmartContract:
                        {
                            var TDWVDASmartContract_accessor = TDWVDASmartContract_Accessor.AllocIterativeAccessor(cellInfo, null);
                            var TDWVDASmartContract_cell     = (TDWVDASmartContract)TDWVDASmartContract_accessor;
                            TDWVDASmartContract_accessor.Dispose();
                            yield return TDWVDASmartContract_cell;
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
                    
                    case CellType.TDWVDAAccount:
                        {
                            var TDWVDAAccount_accessor = TDWVDAAccount_Accessor.AllocIterativeAccessor(cellInfo, null);
                            yield return TDWVDAAccount_accessor;
                            TDWVDAAccount_accessor.Dispose();
                            break;
                        }
                    
                    case CellType.TDWVDASmartContract:
                        {
                            var TDWVDASmartContract_accessor = TDWVDASmartContract_Accessor.AllocIterativeAccessor(cellInfo, null);
                            yield return TDWVDASmartContract_accessor;
                            TDWVDASmartContract_accessor.Dispose();
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
                
                case CellType.TDWVDAAccount:
                storage.SaveTDWVDAAccount((TDWVDAAccount)cell);
                break;
                
                case CellType.TDWVDASmartContract:
                storage.SaveTDWVDASmartContract((TDWVDASmartContract)cell);
                break;
                
            }
        }
        /// <inheritdoc/>
        public void SaveGenericCell(IKeyValueStore storage, long cellId, ICell cell)
        {
            switch ((CellType)cell.CellType)
            {
                
                case CellType.TDWVDAAccount:
                storage.SaveTDWVDAAccount(cellId, (TDWVDAAccount)cell);
                break;
                
                case CellType.TDWVDASmartContract:
                storage.SaveTDWVDASmartContract(cellId, (TDWVDASmartContract)cell);
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
                
                case CellType.TDWVDAAccount:
                return TDWVDAAccount_Accessor._get()._Setup(cellId, cellBuffer, entryIndex, options);
                
                case CellType.TDWVDASmartContract:
                return TDWVDASmartContract_Accessor._get()._Setup(cellId, cellBuffer, entryIndex, options);
                
                default:
                throw new CellTypeNotMatchException("Cannot determine cell type.");
            }
        }
        #endregion
    }
}

#pragma warning restore 162,168,649,660,661,1522
