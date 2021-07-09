#pragma warning disable 162,168,649,660,661,1522
using Trinity;
using Trinity.TSL;
namespace TDW.TDACommon
{
    public static class Storage_CellType_Extension
    {
        
        /// <summary>
        /// Tells whether the cell with the given id is a TDARootCell.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">The id of the cell.</param>
        /// <returns>True if the cell is found and is of the correct type. Otherwise false.</returns>
        public unsafe static bool IsTDARootCell(this Trinity.Storage.LocalMemoryStorage storage, long cellId)
        {
            ushort cellType;
            if (storage.GetCellType(cellId, out cellType) == TrinityErrorCode.E_SUCCESS)
            {
                return cellType == (ushort)CellType.TDARootCell;
            }
            return false;
        }
        
        /// <summary>
        /// Tells whether the cell with the given id is a TDABasketItemCell.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">The id of the cell.</param>
        /// <returns>True if the cell is found and is of the correct type. Otherwise false.</returns>
        public unsafe static bool IsTDABasketItemCell(this Trinity.Storage.LocalMemoryStorage storage, long cellId)
        {
            ushort cellType;
            if (storage.GetCellType(cellId, out cellType) == TrinityErrorCode.E_SUCCESS)
            {
                return cellType == (ushort)CellType.TDABasketItemCell;
            }
            return false;
        }
        
        /// <summary>
        /// Tells whether the cell with the given id is a TDASubledgerCell.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">The id of the cell.</param>
        /// <returns>True if the cell is found and is of the correct type. Otherwise false.</returns>
        public unsafe static bool IsTDASubledgerCell(this Trinity.Storage.LocalMemoryStorage storage, long cellId)
        {
            ushort cellType;
            if (storage.GetCellType(cellId, out cellType) == TrinityErrorCode.E_SUCCESS)
            {
                return cellType == (ushort)CellType.TDASubledgerCell;
            }
            return false;
        }
        
        /// <summary>
        /// Tells whether the cell with the given id is a TDAMasterKeyLedgerCell.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">The id of the cell.</param>
        /// <returns>True if the cell is found and is of the correct type. Otherwise false.</returns>
        public unsafe static bool IsTDAMasterKeyLedgerCell(this Trinity.Storage.LocalMemoryStorage storage, long cellId)
        {
            ushort cellType;
            if (storage.GetCellType(cellId, out cellType) == TrinityErrorCode.E_SUCCESS)
            {
                return cellType == (ushort)CellType.TDAMasterKeyLedgerCell;
            }
            return false;
        }
        
        /// <summary>
        /// Tells whether the cell with the given id is a TDAKeyRingLedgerCell.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">The id of the cell.</param>
        /// <returns>True if the cell is found and is of the correct type. Otherwise false.</returns>
        public unsafe static bool IsTDAKeyRingLedgerCell(this Trinity.Storage.LocalMemoryStorage storage, long cellId)
        {
            ushort cellType;
            if (storage.GetCellType(cellId, out cellType) == TrinityErrorCode.E_SUCCESS)
            {
                return cellType == (ushort)CellType.TDAKeyRingLedgerCell;
            }
            return false;
        }
        
        /// <summary>
        /// Tells whether the cell with the given id is a TDAWalletLedgerCell.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">The id of the cell.</param>
        /// <returns>True if the cell is found and is of the correct type. Otherwise false.</returns>
        public unsafe static bool IsTDAWalletLedgerCell(this Trinity.Storage.LocalMemoryStorage storage, long cellId)
        {
            ushort cellType;
            if (storage.GetCellType(cellId, out cellType) == TrinityErrorCode.E_SUCCESS)
            {
                return cellType == (ushort)CellType.TDAWalletLedgerCell;
            }
            return false;
        }
        
        /// <summary>
        /// Tells whether the cell with the given id is a TDAVDAddressLedgerCell.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">The id of the cell.</param>
        /// <returns>True if the cell is found and is of the correct type. Otherwise false.</returns>
        public unsafe static bool IsTDAVDAddressLedgerCell(this Trinity.Storage.LocalMemoryStorage storage, long cellId)
        {
            ushort cellType;
            if (storage.GetCellType(cellId, out cellType) == TrinityErrorCode.E_SUCCESS)
            {
                return cellType == (ushort)CellType.TDAVDAddressLedgerCell;
            }
            return false;
        }
        
        /// <summary>
        /// Get the type of the cell.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">The id of the cell.</param>
        /// <returns>If the cell is found, returns the type of the cell. Otherwise, returns CellType.Undefined.</returns>
        public unsafe static CellType GetCellType(this Trinity.Storage.LocalMemoryStorage storage, long cellId)
        {
            ushort cellType;
            if (storage.GetCellType(cellId, out cellType) == TrinityErrorCode.E_SUCCESS)
            {
                return (CellType)cellType;
            }
            else
            {
                return CellType.Undefined;
            }
        }
    }
}

#pragma warning restore 162,168,649,660,661,1522
