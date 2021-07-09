#pragma warning disable 162,168,649,660,661,1522
using System;
using System.Text;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Data;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.ExceptionServices;
using System.Security;
using Trinity;
using Trinity.Core.Lib;
using Trinity.Storage;
using Trinity.Utilities;
using Trinity.TSL.Lib;
using Trinity.Network;
using Trinity.Network.Sockets;
using Trinity.Network.Messaging;
using Trinity.TSL;
using System.Runtime.CompilerServices;
using Trinity.Storage.Transaction;
using Microsoft.Extensions.ObjectPool;
namespace TDW.TDACommon
{
    
    /// <summary>
    /// A .NET runtime object representation of TDARootCell defined in TSL.
    /// </summary>
    public partial struct TDARootCell : ICell
    {
        ///<summary>
        ///The id of the cell.
        ///</summary>
        public long CellId;
        ///<summary>
        ///Initializes a new instance of TDARootCell with the specified parameters.
        ///</summary>
        public TDARootCell(long cell_id , TDABasket inbasket = default(TDABasket), TDABasket outbasket = default(TDABasket), TDALedgers ledgers = default(TDALedgers))
        {
            
            this.inbasket = inbasket;
            
            this.outbasket = outbasket;
            
            this.ledgers = ledgers;
            
            CellId = cell_id;
        }
        
        ///<summary>
        ///Initializes a new instance of TDARootCell with the specified parameters.
        ///</summary>
        public TDARootCell( TDABasket inbasket = default(TDABasket), TDABasket outbasket = default(TDABasket), TDALedgers ledgers = default(TDALedgers))
        {
            
            this.inbasket = inbasket;
            
            this.outbasket = outbasket;
            
            this.ledgers = ledgers;
            
            CellId = CellIdFactory.NewCellId();
        }
        
        public TDABasket inbasket;
        
        public TDABasket outbasket;
        
        public TDALedgers ledgers;
        
        public static bool operator ==(TDARootCell a, TDARootCell b)
        {
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }
            
            return
                
                (a.inbasket == b.inbasket)
                &&
                (a.outbasket == b.outbasket)
                &&
                (a.ledgers == b.ledgers)
                
                ;
            
        }
        public static bool operator !=(TDARootCell a, TDARootCell b)
        {
            return !(a == b);
        }
        #region Text processing
        /// <summary>
        /// Converts the string representation of a TDARootCell to its
        /// struct equivalent. A return value indicates whether the 
        /// operation succeeded.
        /// </summary>
        /// <param name="input">A string to convert.</param>
        /// <param name="value">
        /// When this method returns, contains the struct equivalent of the value contained 
        /// in input, if the conversion succeeded, or default(TDARootCell) if the conversion
        /// failed. The conversion fails if the input parameter is null or String.Empty, or is 
        /// not of the correct format. This parameter is passed uninitialized.
        /// </param>
        /// <returns>
        /// True if input was converted successfully; otherwise, false.
        /// </returns>
        public static bool TryParse(string input, out TDARootCell value)
        {
            try
            {
                value = Newtonsoft.Json.JsonConvert.DeserializeObject<TDARootCell>(input);
                return true;
            }
            catch { value = default(TDARootCell); return false; }
        }
        public static TDARootCell Parse(string input)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TDARootCell>(input);
        }
        ///<summary>Converts a TDARootCell to its string representation, in JSON format.</summary>
        ///<returns>A string representation of the TDARootCell.</returns>
        public override string ToString()
        {
            return Serializer.ToString(this);
        }
        #endregion
        #region Lookup tables
        internal static StringLookupTable FieldLookupTable = new StringLookupTable(
            
            "inbasket"
            ,
            "outbasket"
            ,
            "ledgers"
            
            );
        internal static HashSet<string> AppendToFieldRerouteSet = new HashSet<string>()
        {
            
            "inbasket"
            ,
            "outbasket"
            ,
            "ledgers"
            ,
        };
        #endregion
        #region ICell implementation
        /// <summary>
        /// Get the field of the specified name in the cell.
        /// </summary>
        /// <typeparam name="T">
        /// The desired type that the field is supposed 
        /// to be interpreted as. Automatic type casting 
        /// will be attempted if the desired type is not 
        /// implicitly convertible from the type of the field.
        /// </typeparam>
        /// <param name="fieldName">The name of the target field.</param>
        /// <returns>The value of the field.</returns>
        public T GetField<T>(string fieldName)
        {
            switch (FieldLookupTable.Lookup(fieldName))
            {
                case -1:
                Throw.undefined_field();
                break;
                
                case 0:
                return TypeConverter<T>.ConvertFrom_TDABasket(this.inbasket);
                
                case 1:
                return TypeConverter<T>.ConvertFrom_TDABasket(this.outbasket);
                
                case 2:
                return TypeConverter<T>.ConvertFrom_TDALedgers(this.ledgers);
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5005");
        }
        /// <summary>
        /// Set the value of the target field.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the value.
        /// </typeparam>
        /// <param name="fieldName">The name of the target field.</param>
        /// <param name="value">
        /// The value of the field. Automatic type casting 
        /// will be attempted if the desired type is not 
        /// implicitly convertible from the type of the field.
        /// </param>
        public void SetField<T>(string fieldName, T value)
        {
            switch (FieldLookupTable.Lookup(fieldName))
            {
                case -1:
                Throw.undefined_field();
                break;
                
                case 0:
                this.inbasket = TypeConverter<T>.ConvertTo_TDABasket(value);
                break;
                
                case 1:
                this.outbasket = TypeConverter<T>.ConvertTo_TDABasket(value);
                break;
                
                case 2:
                this.ledgers = TypeConverter<T>.ConvertTo_TDALedgers(value);
                break;
                
                default:
                Throw.data_type_incompatible_with_field(typeof(T).ToString());
                break;
            }
        }
        /// <summary>
        /// Tells if a field with the given name exists in the current cell.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <returns>The existence of the field.</returns>
        public bool ContainsField(string fieldName)
        {
            switch (FieldLookupTable.Lookup(fieldName))
            {
                
                case 0:
                
                return true;
                
                case 1:
                
                return true;
                
                case 2:
                
                return true;
                
                default:
                return false;
            }
        }
        /// <summary>
        /// Append <paramref name="value"/> to the target field. Note that if the target field
        /// is not appendable(string or list), calling this method is equivalent to <see cref="TDW.TDACommon.GenericCellAccessor.SetField(string, T)"/>.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the value.
        /// </typeparam>
        /// <param name="fieldName">The name of the target field.</param>
        /// <param name="value">The value to be appended. 
        /// If the value is incompatible with the element 
        /// type of the field, automatic type casting will be attempted.
        /// </param>
        public void AppendToField<T>(string fieldName, T value)
        {
            if (AppendToFieldRerouteSet.Contains(fieldName))
            {
                SetField(fieldName, value);
                return;
            }
            switch (FieldLookupTable.Lookup(fieldName))
            {
                case -1:
                Throw.undefined_field();
                break;
                
                default:
                Throw.target__field_not_list();
                break;
            }
        }
        long ICell.CellId { get { return CellId; } set { CellId = value; } }
        public IEnumerable<KeyValuePair<string, T>> SelectFields<T>(string attributeKey, string attributeValue)
        {
            switch (TypeConverter<T>.type_id)
            {
                
                case 1:
                
                if (StorageSchema.TDARootCell_descriptor.check_attribute(StorageSchema.TDARootCell_descriptor.inbasket, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("inbasket", TypeConverter<T>.ConvertFrom_TDABasket(this.inbasket));
                
                if (StorageSchema.TDARootCell_descriptor.check_attribute(StorageSchema.TDARootCell_descriptor.outbasket, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("outbasket", TypeConverter<T>.ConvertFrom_TDABasket(this.outbasket));
                
                if (StorageSchema.TDARootCell_descriptor.check_attribute(StorageSchema.TDARootCell_descriptor.ledgers, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("ledgers", TypeConverter<T>.ConvertFrom_TDALedgers(this.ledgers));
                
                break;
                
                case 4:
                
                if (StorageSchema.TDARootCell_descriptor.check_attribute(StorageSchema.TDARootCell_descriptor.inbasket, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("inbasket", TypeConverter<T>.ConvertFrom_TDABasket(this.inbasket));
                
                if (StorageSchema.TDARootCell_descriptor.check_attribute(StorageSchema.TDARootCell_descriptor.outbasket, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("outbasket", TypeConverter<T>.ConvertFrom_TDABasket(this.outbasket));
                
                if (StorageSchema.TDARootCell_descriptor.check_attribute(StorageSchema.TDARootCell_descriptor.ledgers, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("ledgers", TypeConverter<T>.ConvertFrom_TDALedgers(this.ledgers));
                
                break;
                
                case 5:
                
                if (StorageSchema.TDARootCell_descriptor.check_attribute(StorageSchema.TDARootCell_descriptor.inbasket, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("inbasket", TypeConverter<T>.ConvertFrom_TDABasket(this.inbasket));
                
                if (StorageSchema.TDARootCell_descriptor.check_attribute(StorageSchema.TDARootCell_descriptor.outbasket, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("outbasket", TypeConverter<T>.ConvertFrom_TDABasket(this.outbasket));
                
                break;
                
                case 6:
                
                if (StorageSchema.TDARootCell_descriptor.check_attribute(StorageSchema.TDARootCell_descriptor.ledgers, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("ledgers", TypeConverter<T>.ConvertFrom_TDALedgers(this.ledgers));
                
                break;
                
                default:
                Throw.incompatible_with_cell();
                break;
            }
            yield break;
        }
        #region enumerate value constructs
        
        private IEnumerable<T> _enumerate_from_inbasket<T>()
        {
            
            switch (TypeConverter<T>.type_id)
            {
                
                case 1:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_TDABasket(this.inbasket);
                        
                    }
                    break;
                
                case 4:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_TDABasket(this.inbasket);
                        
                    }
                    break;
                
                case 5:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_TDABasket(this.inbasket);
                        
                    }
                    break;
                
                default:
                    Throw.incompatible_with_cell();
                    break;
            }
            yield break;
            
        }
        
        private IEnumerable<T> _enumerate_from_outbasket<T>()
        {
            
            switch (TypeConverter<T>.type_id)
            {
                
                case 1:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_TDABasket(this.outbasket);
                        
                    }
                    break;
                
                case 4:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_TDABasket(this.outbasket);
                        
                    }
                    break;
                
                case 5:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_TDABasket(this.outbasket);
                        
                    }
                    break;
                
                default:
                    Throw.incompatible_with_cell();
                    break;
            }
            yield break;
            
        }
        
        private IEnumerable<T> _enumerate_from_ledgers<T>()
        {
            
            switch (TypeConverter<T>.type_id)
            {
                
                case 1:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_TDALedgers(this.ledgers);
                        
                    }
                    break;
                
                case 4:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_TDALedgers(this.ledgers);
                        
                    }
                    break;
                
                case 6:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_TDALedgers(this.ledgers);
                        
                    }
                    break;
                
                default:
                    Throw.incompatible_with_cell();
                    break;
            }
            yield break;
            
        }
        
        private static StringLookupTable s_field_attribute_id_table = new StringLookupTable(
            
            );
        #endregion
        public IEnumerable<T> EnumerateField<T>(string fieldName)
        {
            switch (FieldLookupTable.Lookup(fieldName))
            {
                
                case 0:
                return _enumerate_from_inbasket<T>();
                
                case 1:
                return _enumerate_from_outbasket<T>();
                
                case 2:
                return _enumerate_from_ledgers<T>();
                
                default:
                Throw.undefined_field();
                return null;
            }
        }
        public IEnumerable<T> EnumerateValues<T>(string attributeKey, string attributeValue)
        {
            int attr_id;
            if (attributeKey == null)
            {
                
                foreach (var val in _enumerate_from_inbasket<T>())
                    yield return val;
                
                foreach (var val in _enumerate_from_outbasket<T>())
                    yield return val;
                
                foreach (var val in _enumerate_from_ledgers<T>())
                    yield return val;
                
            }
            else if (-1 != (attr_id = s_field_attribute_id_table.Lookup(attributeKey)))
            {
                switch (attr_id)
                {
                    
                }
            }
            yield break;
        }
        public ICellAccessor Serialize()
        {
            return (TDARootCell_Accessor)this;
        }
        #endregion
        #region Other interfaces
        string ITypeDescriptor.TypeName
        {
            get { return StorageSchema.s_cellTypeName_TDARootCell; }
        }
        Type ITypeDescriptor.Type
        {
            get { return StorageSchema.s_cellType_TDARootCell; }
        }
        bool ITypeDescriptor.IsOfType<T>()
        {
            return typeof(T) == StorageSchema.s_cellType_TDARootCell;
        }
        bool ITypeDescriptor.IsList()
        {
            return false;
        }
        IEnumerable<IFieldDescriptor> ICellDescriptor.GetFieldDescriptors()
        {
            return StorageSchema.TDARootCell.GetFieldDescriptors();
        }
        IAttributeCollection ICellDescriptor.GetFieldAttributes(string fieldName)
        {
            return StorageSchema.TDARootCell.GetFieldAttributes(fieldName);
        }
        string IAttributeCollection.GetAttributeValue(string attributeKey)
        {
            return StorageSchema.TDARootCell.GetAttributeValue(attributeKey);
        }
        IReadOnlyDictionary<string, string> IAttributeCollection.Attributes
        {
            get { return StorageSchema.TDARootCell.Attributes; }
        }
        IEnumerable<string> ICellDescriptor.GetFieldNames()
        {
            
            {
                yield return "inbasket";
            }
            
            {
                yield return "outbasket";
            }
            
            {
                yield return "ledgers";
            }
            
        }
        ushort ICellDescriptor.CellType
        {
            get
            {
                return (ushort)CellType.TDARootCell;
            }
        }
        #endregion
    }
    /// <summary>
    /// Provides in-place operations of TDARootCell defined in TSL.
    /// </summary>
    public unsafe class TDARootCell_Accessor : ICellAccessor
    {
        #region Fields
        internal   long                    m_cellId;
        /// <summary>
        /// A pointer to the underlying raw binary blob. Take caution when accessing data with
        /// the raw pointer, as no boundary checks are employed, and improper operations will cause data corruption and/or system crash.
        /// </summary>
        internal byte*                   m_ptr;
        internal LocalTransactionContext m_tx;
        internal int                     m_cellEntryIndex;
        internal CellAccessOptions       m_options;
        internal bool                    m_IsIterator;
        private  const CellAccessOptions c_WALFlags = CellAccessOptions.StrongLogAhead | CellAccessOptions.WeakLogAhead;
        #endregion
        #region Constructors
        private unsafe TDARootCell_Accessor()
        {
                    inbasket_Accessor_Field = new TDABasket_Accessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        outbasket_Accessor_Field = new TDABasket_Accessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        ledgers_Accessor_Field = new TDALedgers_Accessor(null);
        }
        #endregion
        
        internal static string[] optional_field_names = null;
        ///<summary>
        ///Get an array of the names of all optional fields for object type t_struct_name.
        ///</summary>
        public static string[] GetOptionalFieldNames()
        {
            if (optional_field_names == null)
                optional_field_names = new string[]
                {
                    
                };
            return optional_field_names;
        }
        ///<summary>
        ///Get a list of the names of available optional fields in the object being operated by this accessor.
        ///</summary>
        internal List<string> GetNotNullOptionalFields()
        {
            List<string> list = new List<string>();
            BitArray ba = new BitArray(GetOptionalFieldMap());
            string[] optional_fields = GetOptionalFieldNames();
            for (int i = 0; i < ba.Count; i++)
            {
                if (ba[i])
                    list.Add(optional_fields[i]);
            }
            return list;
        }
        internal unsafe byte[] GetOptionalFieldMap()
        {
            
            return new byte[0];
            
        }
        
        #region IAccessor Implementation
        public byte[] ToByteArray()
        {
            byte* targetPtr = m_ptr;
            {{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 32;
}
            int size = (int)(targetPtr - m_ptr);
            byte[] ret = new byte[size];
            Memory.Copy(m_ptr, 0, ret, 0, size);
            return ret;
        }
        public unsafe byte* GetUnderlyingBufferPointer()
        {
            return m_ptr;
        }
        public unsafe int GetBufferLength()
        {
            byte* targetPtr = m_ptr;
            {{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 32;
}
            int size = (int)(targetPtr - m_ptr);
            return size;
        }
        public ResizeFunctionDelegate ResizeFunction { get; set; }
        #endregion
        private static byte[] s_default_content = null;
        private static unsafe byte[] construct( TDABasket inbasket = default(TDABasket) , TDABasket outbasket = default(TDABasket) , TDALedgers ledgers = default(TDALedgers) )
        {
            if (s_default_content != null) return s_default_content;
            
            byte* targetPtr;
            
            targetPtr = null;
            
            {

            {

if(inbasket.itemids!= null)
{
    targetPtr += inbasket.itemids.Count*8+sizeof(int);
}else
{
    targetPtr += sizeof(int);
}

            }
            {

if(outbasket.itemids!= null)
{
    targetPtr += outbasket.itemids.Count*8+sizeof(int);
}else
{
    targetPtr += sizeof(int);
}

            }targetPtr += 32;

            }
            byte[] tmpcell = new byte[(int)(targetPtr)];
            fixed (byte* _tmpcellptr = tmpcell)
            {
                targetPtr = _tmpcellptr;
                
            {

            {

if(inbasket.itemids!= null)
{
    *(int*)targetPtr = inbasket.itemids.Count*8;
    targetPtr += sizeof(int);
    for(int iterator_3 = 0;iterator_3<inbasket.itemids.Count;++iterator_3)
    {
            *(long*)targetPtr = inbasket.itemids[iterator_3];
            targetPtr += 8;

    }

}else
{
    *(int*)targetPtr = 0;
    targetPtr += sizeof(int);
}

            }
            {

if(outbasket.itemids!= null)
{
    *(int*)targetPtr = outbasket.itemids.Count*8;
    targetPtr += sizeof(int);
    for(int iterator_3 = 0;iterator_3<outbasket.itemids.Count;++iterator_3)
    {
            *(long*)targetPtr = outbasket.itemids[iterator_3];
            targetPtr += 8;

    }

}else
{
    *(int*)targetPtr = 0;
    targetPtr += sizeof(int);
}

            }
            {
            if(ledgers.ledgerids!= null){
                if(ledgers.ledgerids.Rank != 1) throw new IndexOutOfRangeException("The assigned array'storage Rank mismatch.");
                if(ledgers.ledgerids.GetLength(0) != 4) throw new IndexOutOfRangeException("The assigned array'storage dimension mismatch.");
               fixed(long* storedPtr_3 = ledgers.ledgerids)
                   Memory.memcpy(targetPtr, storedPtr_3, (ulong)(32));
            } else {
                Memory.memset(targetPtr, 0, (ulong)(32));
            }
            targetPtr += 32;

            }
            }
            }
            
            s_default_content = tmpcell;
            return tmpcell;
        }
        TDABasket_Accessor inbasket_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field inbasket.
        ///</summary>
        public unsafe TDABasket_Accessor inbasket
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {}inbasket_Accessor_Field.m_ptr = targetPtr;
                inbasket_Accessor_Field.m_cellId = this.m_cellId;
                return inbasket_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                inbasket_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {}
                int offset = (int)(targetPtr - m_ptr);
                byte* oldtargetPtr = targetPtr;
                int oldlength = (int)(targetPtr - oldtargetPtr);
                targetPtr = value.m_ptr;
                int newlength = (int)(targetPtr - value.m_ptr);
                if (newlength != oldlength)
                {
                    if (value.m_cellId != this.m_cellId)
                    {
                        this.m_ptr = this.ResizeFunction(this.m_ptr, offset, newlength - oldlength);
                        Memory.Copy(value.m_ptr, this.m_ptr + offset, newlength);
                    }
                    else
                    {
                        byte[] tmpcell = new byte[newlength];
                        fixed(byte* tmpcellptr = tmpcell)
                        {
                            Memory.Copy(value.m_ptr, tmpcellptr, newlength);
                            this.m_ptr = this.ResizeFunction(this.m_ptr, offset, newlength - oldlength);
                            Memory.Copy(tmpcellptr, this.m_ptr + offset, newlength);
                        }
                    }
                }
                else
                {
                    Memory.Copy(value.m_ptr, oldtargetPtr, oldlength);
                }
            }
        }
        TDABasket_Accessor outbasket_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field outbasket.
        ///</summary>
        public unsafe TDABasket_Accessor outbasket
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {{targetPtr += *(int*)targetPtr + sizeof(int);}}outbasket_Accessor_Field.m_ptr = targetPtr;
                outbasket_Accessor_Field.m_cellId = this.m_cellId;
                return outbasket_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                outbasket_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {{targetPtr += *(int*)targetPtr + sizeof(int);}}
                int offset = (int)(targetPtr - m_ptr);
                byte* oldtargetPtr = targetPtr;
                int oldlength = (int)(targetPtr - oldtargetPtr);
                targetPtr = value.m_ptr;
                int newlength = (int)(targetPtr - value.m_ptr);
                if (newlength != oldlength)
                {
                    if (value.m_cellId != this.m_cellId)
                    {
                        this.m_ptr = this.ResizeFunction(this.m_ptr, offset, newlength - oldlength);
                        Memory.Copy(value.m_ptr, this.m_ptr + offset, newlength);
                    }
                    else
                    {
                        byte[] tmpcell = new byte[newlength];
                        fixed(byte* tmpcellptr = tmpcell)
                        {
                            Memory.Copy(value.m_ptr, tmpcellptr, newlength);
                            this.m_ptr = this.ResizeFunction(this.m_ptr, offset, newlength - oldlength);
                            Memory.Copy(tmpcellptr, this.m_ptr + offset, newlength);
                        }
                    }
                }
                else
                {
                    Memory.Copy(value.m_ptr, oldtargetPtr, oldlength);
                }
            }
        }
        TDALedgers_Accessor ledgers_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field ledgers.
        ///</summary>
        public unsafe TDALedgers_Accessor ledgers
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}}ledgers_Accessor_Field.m_ptr = targetPtr;
                ledgers_Accessor_Field.m_cellId = this.m_cellId;
                return ledgers_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                ledgers_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}}                Memory.Copy(value.m_ptr, targetPtr, 32); 
            }
        }
        
        public static unsafe implicit operator TDARootCell(TDARootCell_Accessor accessor)
        {
            
            return new TDARootCell(accessor.CellId
            
            ,
            
                    accessor.inbasket
            ,
            
                    accessor.outbasket
            ,
            
                    accessor.ledgers
            );
        }
        
        public unsafe static implicit operator TDARootCell_Accessor(TDARootCell field)
        {
            byte* targetPtr = null;
            
            {

            {

if(field.inbasket.itemids!= null)
{
    targetPtr += field.inbasket.itemids.Count*8+sizeof(int);
}else
{
    targetPtr += sizeof(int);
}

            }
            {

if(field.outbasket.itemids!= null)
{
    targetPtr += field.outbasket.itemids.Count*8+sizeof(int);
}else
{
    targetPtr += sizeof(int);
}

            }targetPtr += 32;

            }
            byte* tmpcellptr = BufferAllocator.AllocBuffer((int)targetPtr);
            Memory.memset(tmpcellptr, 0, (ulong)targetPtr);
            targetPtr = tmpcellptr;
            
            {

            {

if(field.inbasket.itemids!= null)
{
    *(int*)targetPtr = field.inbasket.itemids.Count*8;
    targetPtr += sizeof(int);
    for(int iterator_3 = 0;iterator_3<field.inbasket.itemids.Count;++iterator_3)
    {
            *(long*)targetPtr = field.inbasket.itemids[iterator_3];
            targetPtr += 8;

    }

}else
{
    *(int*)targetPtr = 0;
    targetPtr += sizeof(int);
}

            }
            {

if(field.outbasket.itemids!= null)
{
    *(int*)targetPtr = field.outbasket.itemids.Count*8;
    targetPtr += sizeof(int);
    for(int iterator_3 = 0;iterator_3<field.outbasket.itemids.Count;++iterator_3)
    {
            *(long*)targetPtr = field.outbasket.itemids[iterator_3];
            targetPtr += 8;

    }

}else
{
    *(int*)targetPtr = 0;
    targetPtr += sizeof(int);
}

            }
            {
            if(field.ledgers.ledgerids!= null){
                if(field.ledgers.ledgerids.Rank != 1) throw new IndexOutOfRangeException("The assigned array'storage Rank mismatch.");
                if(field.ledgers.ledgerids.GetLength(0) != 4) throw new IndexOutOfRangeException("The assigned array'storage dimension mismatch.");
               fixed(long* storedPtr_3 = field.ledgers.ledgerids)
                   Memory.memcpy(targetPtr, storedPtr_3, (ulong)(32));
            } else {
                Memory.memset(targetPtr, 0, (ulong)(32));
            }
            targetPtr += 32;

            }
            }TDARootCell_Accessor ret;
            
            ret = TDARootCell_Accessor._get()._Setup(field.CellId, tmpcellptr, -1, 0, null);
            ret.m_cellId = field.CellId;
            
            return ret;
        }
        
        public static bool operator ==(TDARootCell_Accessor a, TDARootCell_Accessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            byte* targetPtr = a.m_ptr;
            {{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 32;
}
            int lengthA = (int)(targetPtr - a.m_ptr);
            targetPtr = b.m_ptr;
            {{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 32;
}
            int lengthB = (int)(targetPtr - b.m_ptr);
            if(lengthA != lengthB) return false;
            return Memory.Compare(a.m_ptr,b.m_ptr,lengthA);
        }
        public static bool operator != (TDARootCell_Accessor a, TDARootCell_Accessor b)
        {
            return !(a == b);
        }
        
        public static bool operator ==(TDARootCell_Accessor a, TDARootCell b)
        {
            TDARootCell_Accessor bb = b;
            return (a == bb);
        }
        public static bool operator !=(TDARootCell_Accessor a, TDARootCell b)
        {
            return !(a == b);
        }
        /// <summary>
        /// Get the size of the cell content, in bytes.
        /// </summary>
        public int CellSize { get { int size; Global.LocalStorage.LockedGetCellSize(this.CellId, this.m_cellEntryIndex, out size); return size; } }
        #region Internal
        private unsafe byte* _Resize_NonTx(byte* ptr, int ptr_offset, int delta)
        {
            int offset = (int)(ptr - m_ptr) + ptr_offset;
            m_ptr = Global.LocalStorage.ResizeCell((long)CellId, m_cellEntryIndex, offset, delta);
            return m_ptr + (offset - ptr_offset);
        }
        private unsafe byte* _Resize_Tx(byte* ptr, int ptr_offset, int delta)
        {
            int offset = (int)(ptr - m_ptr) + ptr_offset;
            m_ptr = Global.LocalStorage.ResizeCell(m_tx, (long)CellId, m_cellEntryIndex, offset, delta);
            return m_ptr + (offset - ptr_offset);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal unsafe TDARootCell_Accessor _Lock(long cellId, CellAccessOptions options)
        {
            ushort cellType;
            this.CellId = cellId;
            this.m_options = options;
            this.ResizeFunction = _Resize_NonTx;
            TrinityErrorCode eResult = Global.LocalStorage.GetLockedCellInfo(cellId, out _, out cellType, out this.m_ptr, out this.m_cellEntryIndex);
            switch (eResult)
            {
                case TrinityErrorCode.E_SUCCESS:
                {
                    if (cellType != (ushort)CellType.TDARootCell)
                    {
                        Global.LocalStorage.ReleaseCellLock(cellId, this.m_cellEntryIndex);
                        _put(this);
                        Throw.wrong_cell_type();
                    }
                    break;
                }
                case TrinityErrorCode.E_CELL_NOT_FOUND:
                {
                    if ((options & CellAccessOptions.ThrowExceptionOnCellNotFound) != 0)
                    {
                        _put(this);
                        Throw.cell_not_found(cellId);
                    }
                    else if ((options & CellAccessOptions.CreateNewOnCellNotFound) != 0)
                    {
                        byte[]  defaultContent = construct();
                        int     size           = defaultContent.Length;
                        eResult                = Global.LocalStorage.AddOrUse(cellId, defaultContent, ref size, (ushort)CellType.TDARootCell, out this.m_ptr, out this.m_cellEntryIndex);
                        if (eResult == TrinityErrorCode.E_WRONG_CELL_TYPE)
                        {
                            _put(this);
                            Throw.wrong_cell_type();
                        }
                    }
                    else if ((options & CellAccessOptions.ReturnNullOnCellNotFound) != 0)
                    {
                        _put(this);
                        return null;
                    }
                    else
                    {
                        _put(this);
                        Throw.cell_not_found(cellId);
                    }
                    break;
                }
                default:
                _put(this);
                throw new NotImplementedException();
            }
            return this;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal unsafe TDARootCell_Accessor _Lock(long cellId, CellAccessOptions options, LocalTransactionContext tx)
        {
            ushort cellType;
            this.CellId = cellId;
            this.m_options = options;
            this.m_tx = tx;
            this.ResizeFunction = _Resize_Tx;
            TrinityErrorCode eResult = Global.LocalStorage.GetLockedCellInfo(tx, cellId, out _, out cellType, out this.m_ptr, out this.m_cellEntryIndex);
            switch (eResult)
            {
                case TrinityErrorCode.E_SUCCESS:
                {
                    if (cellType != (ushort)CellType.TDARootCell)
                    {
                        Global.LocalStorage.ReleaseCellLock(tx, cellId, this.m_cellEntryIndex);
                        _put(this);
                        Throw.wrong_cell_type();
                    }
                    break;
                }
                case TrinityErrorCode.E_CELL_NOT_FOUND:
                {
                    if ((options & CellAccessOptions.ThrowExceptionOnCellNotFound) != 0)
                    {
                        _put(this);
                        Throw.cell_not_found(cellId);
                    }
                    else if ((options & CellAccessOptions.CreateNewOnCellNotFound) != 0)
                    {
                        byte[]  defaultContent = construct();
                        int     size           = defaultContent.Length;
                        eResult                = Global.LocalStorage.AddOrUse(tx, cellId, defaultContent, ref size, (ushort)CellType.TDARootCell, out this.m_ptr, out this.m_cellEntryIndex);
                        if (eResult == TrinityErrorCode.E_WRONG_CELL_TYPE)
                        {
                            _put(this);
                            Throw.wrong_cell_type();
                        }
                    }
                    else if ((options & CellAccessOptions.ReturnNullOnCellNotFound) != 0)
                    {
                        _put(this);
                        return null;
                    }
                    else
                    {
                        _put(this);
                        Throw.cell_not_found(cellId);
                    }
                    break;
                }
                default:
                _put(this);
                throw new NotImplementedException();
            }
            return this;
        }
        private class PoolPolicy : IPooledObjectPolicy<TDARootCell_Accessor>
        {
            public TDARootCell_Accessor Create()
            {
                return new TDARootCell_Accessor();
            }
            public bool Return(TDARootCell_Accessor obj)
            {
                return !obj.m_IsIterator;
            }
        }
        private static DefaultObjectPool<TDARootCell_Accessor> s_accessor_pool = new DefaultObjectPool<TDARootCell_Accessor>(new PoolPolicy());
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static TDARootCell_Accessor _get() => s_accessor_pool.Get();
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void _put(TDARootCell_Accessor item) => s_accessor_pool.Return(item);
        /// <summary>
        /// For internal use only.
        /// Caller guarantees that entry lock is obtained.
        /// Does not handle CellAccessOptions. Only copy to the accessor.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal TDARootCell_Accessor _Setup(long CellId, byte* cellPtr, int entryIndex, CellAccessOptions options)
        {
            this.CellId      = CellId;
            m_cellEntryIndex = entryIndex;
            m_options        = options;
            m_ptr            = cellPtr;
            m_tx             = null;
            this.ResizeFunction = _Resize_NonTx;
            return this;
        }
        /// <summary>
        /// For internal use only.
        /// Caller guarantees that entry lock is obtained.
        /// Does not handle CellAccessOptions. Only copy to the accessor.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal TDARootCell_Accessor _Setup(long CellId, byte* cellPtr, int entryIndex, CellAccessOptions options, LocalTransactionContext tx)
        {
            this.CellId      = CellId;
            m_cellEntryIndex = entryIndex;
            m_options        = options;
            m_ptr            = cellPtr;
            m_tx             = tx;
            this.ResizeFunction = _Resize_Tx;
            return this;
        }
        /// <summary>
        /// For internal use only.
        /// </summary>
        internal static TDARootCell_Accessor AllocIterativeAccessor(CellInfo info, LocalTransactionContext tx)
        {
            TDARootCell_Accessor accessor = new TDARootCell_Accessor();
            accessor.m_IsIterator = true;
            if (tx != null) accessor._Setup(info.CellId, info.CellPtr, info.CellEntryIndex, 0, tx);
            else accessor._Setup(info.CellId, info.CellPtr, info.CellEntryIndex, 0);
            return accessor;
        }
        #endregion
        #region Public
        /// <summary>
        /// Dispose the accessor.
        /// If <c><see cref="Trinity.TrinityConfig.ReadOnly"/> == false</c>,
        /// the cell lock will be released.
        /// If write-ahead-log behavior is specified on <see cref="TDW.TDACommon.StorageExtension_TDARootCell.UseTDARootCell"/>,
        /// the changes will be committed to the write-ahead log.
        /// </summary>
        public void Dispose()
        {
            if (m_cellEntryIndex >= 0)
            {
                if ((m_options & c_WALFlags) != 0)
                {
                    LocalMemoryStorage.CWriteAheadLog(this.CellId, this.m_ptr, this.CellSize, (ushort)CellType.TDARootCell, m_options);
                }
                if (!m_IsIterator)
                {
                    if (m_tx == null) Global.LocalStorage.ReleaseCellLock(CellId, m_cellEntryIndex);
                    else Global.LocalStorage.ReleaseCellLock(m_tx, CellId, m_cellEntryIndex);
                }
            }
            _put(this);
        }
        /// <summary>
        /// Get the cell type id.
        /// </summary>
        /// <returns>A 16-bit unsigned integer representing the cell type id.</returns>
        public ushort GetCellType()
        {
            ushort cellType;
            if (Global.LocalStorage.GetCellType(CellId, out cellType) == TrinityErrorCode.E_CELL_NOT_FOUND)
            {
                Throw.cell_not_found();
            }
            return cellType;
        }
        /// <summary>Converts a TDARootCell_Accessor to its string representation, in JSON format.</summary>
        /// <returns>A string representation of the TDARootCell.</returns>
        public override string ToString()
        {
            return Serializer.ToString(this);
        }
        #endregion
        #region Lookup tables
        internal static StringLookupTable FieldLookupTable = new StringLookupTable(
            
            "inbasket"
            ,
            "outbasket"
            ,
            "ledgers"
            
            );
        static HashSet<string> AppendToFieldRerouteSet = new HashSet<string>()
        {
            
            "inbasket"
            ,
            "outbasket"
            ,
            "ledgers"
            ,
        };
        #endregion
        #region ICell implementation
        public T GetField<T>(string fieldName)
        {
            int field_divider_idx = fieldName.IndexOf('.');
            if (-1 != field_divider_idx)
            {
                string field_name_string = fieldName.Substring(0, field_divider_idx);
                switch (FieldLookupTable.Lookup(field_name_string))
                {
                    case -1:
                    Throw.undefined_field();
                    break;
                    
                    case 0:
                    return GenericFieldAccessor.GetField<T>(this.inbasket, fieldName, field_divider_idx + 1);
                    
                    case 1:
                    return GenericFieldAccessor.GetField<T>(this.outbasket, fieldName, field_divider_idx + 1);
                    
                    case 2:
                    return GenericFieldAccessor.GetField<T>(this.ledgers, fieldName, field_divider_idx + 1);
                    
                    default:
                    Throw.member_access_on_non_struct__field(field_name_string);
                    break;
                }
            }
            switch (FieldLookupTable.Lookup(fieldName))
            {
                case -1:
                Throw.undefined_field();
                break;
                
                case 0:
                return TypeConverter<T>.ConvertFrom_TDABasket(this.inbasket);
                
                case 1:
                return TypeConverter<T>.ConvertFrom_TDABasket(this.outbasket);
                
                case 2:
                return TypeConverter<T>.ConvertFrom_TDALedgers(this.ledgers);
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5005");
        }
        public void SetField<T>(string fieldName, T value)
        {
            int field_divider_idx = fieldName.IndexOf('.');
            if (-1 != field_divider_idx)
            {
                string field_name_string = fieldName.Substring(0, field_divider_idx);
                switch (FieldLookupTable.Lookup(field_name_string))
                {
                    case -1:
                    Throw.undefined_field();
                    break;
                    
                    case 0:
                    GenericFieldAccessor.SetField(this.inbasket, fieldName, field_divider_idx + 1, value);
                    break;
                    
                    case 1:
                    GenericFieldAccessor.SetField(this.outbasket, fieldName, field_divider_idx + 1, value);
                    break;
                    
                    case 2:
                    GenericFieldAccessor.SetField(this.ledgers, fieldName, field_divider_idx + 1, value);
                    break;
                    
                    default:
                    Throw.member_access_on_non_struct__field(field_name_string);
                    break;
                }
                return;
            }
            switch (FieldLookupTable.Lookup(fieldName))
            {
                case -1:
                Throw.undefined_field();
                break;
                
                case 0:
                {
                    TDABasket conversion_result = TypeConverter<T>.ConvertTo_TDABasket(value);
                    
            {
                this.inbasket = conversion_result;
            }
            
                }
                break;
                
                case 1:
                {
                    TDABasket conversion_result = TypeConverter<T>.ConvertTo_TDABasket(value);
                    
            {
                this.outbasket = conversion_result;
            }
            
                }
                break;
                
                case 2:
                {
                    TDALedgers conversion_result = TypeConverter<T>.ConvertTo_TDALedgers(value);
                    
            {
                this.ledgers = conversion_result;
            }
            
                }
                break;
                
            }
        }
        /// <summary>
        /// Tells if a field with the given name exists in the current cell.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <returns>The existence of the field.</returns>
        public bool ContainsField(string fieldName)
        {
            switch (FieldLookupTable.Lookup(fieldName))
            {
                
                case 0:
                
                return true;
                
                case 1:
                
                return true;
                
                case 2:
                
                return true;
                
                default:
                return false;
            }
        }
        public void AppendToField<T>(string fieldName, T value)
        {
            if (AppendToFieldRerouteSet.Contains(fieldName))
            {
                SetField(fieldName, value);
                return;
            }
            switch (FieldLookupTable.Lookup(fieldName))
            {
                case -1:
                Throw.undefined_field();
                break;
                
                default:
                Throw.target__field_not_list();
                break;
            }
        }
        public long CellId { get { return m_cellId; } set { m_cellId = value; } }
        IEnumerable<KeyValuePair<string, T>> ICell.SelectFields<T>(string attributeKey, string attributeValue)
        {
            switch (TypeConverter<T>.type_id)
            {
                
                case 1:
                
                if (StorageSchema.TDARootCell_descriptor.check_attribute(StorageSchema.TDARootCell_descriptor.inbasket, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("inbasket", TypeConverter<T>.ConvertFrom_TDABasket(this.inbasket));
                
                if (StorageSchema.TDARootCell_descriptor.check_attribute(StorageSchema.TDARootCell_descriptor.outbasket, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("outbasket", TypeConverter<T>.ConvertFrom_TDABasket(this.outbasket));
                
                if (StorageSchema.TDARootCell_descriptor.check_attribute(StorageSchema.TDARootCell_descriptor.ledgers, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("ledgers", TypeConverter<T>.ConvertFrom_TDALedgers(this.ledgers));
                
                break;
                
                case 4:
                
                if (StorageSchema.TDARootCell_descriptor.check_attribute(StorageSchema.TDARootCell_descriptor.inbasket, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("inbasket", TypeConverter<T>.ConvertFrom_TDABasket(this.inbasket));
                
                if (StorageSchema.TDARootCell_descriptor.check_attribute(StorageSchema.TDARootCell_descriptor.outbasket, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("outbasket", TypeConverter<T>.ConvertFrom_TDABasket(this.outbasket));
                
                if (StorageSchema.TDARootCell_descriptor.check_attribute(StorageSchema.TDARootCell_descriptor.ledgers, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("ledgers", TypeConverter<T>.ConvertFrom_TDALedgers(this.ledgers));
                
                break;
                
                case 5:
                
                if (StorageSchema.TDARootCell_descriptor.check_attribute(StorageSchema.TDARootCell_descriptor.inbasket, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("inbasket", TypeConverter<T>.ConvertFrom_TDABasket(this.inbasket));
                
                if (StorageSchema.TDARootCell_descriptor.check_attribute(StorageSchema.TDARootCell_descriptor.outbasket, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("outbasket", TypeConverter<T>.ConvertFrom_TDABasket(this.outbasket));
                
                break;
                
                case 6:
                
                if (StorageSchema.TDARootCell_descriptor.check_attribute(StorageSchema.TDARootCell_descriptor.ledgers, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("ledgers", TypeConverter<T>.ConvertFrom_TDALedgers(this.ledgers));
                
                break;
                
                default:
                Throw.incompatible_with_cell();
                break;
            }
            yield break;
        }
        #region enumerate value methods
        
        private IEnumerable<T> _enumerate_from_inbasket<T>()
        {
            
            switch (TypeConverter<T>.type_id)
            {
                
                case 1:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_TDABasket(this.inbasket);
                        
                    }
                    break;
                
                case 4:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_TDABasket(this.inbasket);
                        
                    }
                    break;
                
                case 5:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_TDABasket(this.inbasket);
                        
                    }
                    break;
                
                default:
                    Throw.incompatible_with_cell();
                    break;
            }
            yield break;
            
        }
        
        private IEnumerable<T> _enumerate_from_outbasket<T>()
        {
            
            switch (TypeConverter<T>.type_id)
            {
                
                case 1:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_TDABasket(this.outbasket);
                        
                    }
                    break;
                
                case 4:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_TDABasket(this.outbasket);
                        
                    }
                    break;
                
                case 5:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_TDABasket(this.outbasket);
                        
                    }
                    break;
                
                default:
                    Throw.incompatible_with_cell();
                    break;
            }
            yield break;
            
        }
        
        private IEnumerable<T> _enumerate_from_ledgers<T>()
        {
            
            switch (TypeConverter<T>.type_id)
            {
                
                case 1:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_TDALedgers(this.ledgers);
                        
                    }
                    break;
                
                case 4:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_TDALedgers(this.ledgers);
                        
                    }
                    break;
                
                case 6:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_TDALedgers(this.ledgers);
                        
                    }
                    break;
                
                default:
                    Throw.incompatible_with_cell();
                    break;
            }
            yield break;
            
        }
        
        private static StringLookupTable s_field_attribute_id_table = new StringLookupTable(
            
            );
        #endregion
        public IEnumerable<T> EnumerateField<T>(string fieldName)
        {
            switch (FieldLookupTable.Lookup(fieldName))
            {
                
                case 0:
                return _enumerate_from_inbasket<T>();
                
                case 1:
                return _enumerate_from_outbasket<T>();
                
                case 2:
                return _enumerate_from_ledgers<T>();
                
                default:
                Throw.undefined_field();
                return null;
            }
        }
        IEnumerable<T> ICell.EnumerateValues<T>(string attributeKey, string attributeValue)
        {
            int attr_id;
            if (attributeKey == null)
            {
                
                foreach (var val in _enumerate_from_inbasket<T>())
                    yield return val;
                
                foreach (var val in _enumerate_from_outbasket<T>())
                    yield return val;
                
                foreach (var val in _enumerate_from_ledgers<T>())
                    yield return val;
                
            }
            else if (-1 != (attr_id = s_field_attribute_id_table.Lookup(attributeKey)))
            {
                switch (attr_id)
                {
                    
                }
            }
            yield break;
        }
        IEnumerable<string> ICellDescriptor.GetFieldNames()
        {
            
            {
                yield return "inbasket";
            }
            
            {
                yield return "outbasket";
            }
            
            {
                yield return "ledgers";
            }
            
        }
        IAttributeCollection ICellDescriptor.GetFieldAttributes(string fieldName)
        {
            return StorageSchema.TDARootCell.GetFieldAttributes(fieldName);
        }
        IEnumerable<IFieldDescriptor> ICellDescriptor.GetFieldDescriptors()
        {
            return StorageSchema.TDARootCell.GetFieldDescriptors();
        }
        string ITypeDescriptor.TypeName
        {
            get { return StorageSchema.s_cellTypeName_TDARootCell; }
        }
        Type ITypeDescriptor.Type
        {
            get { return StorageSchema.s_cellType_TDARootCell; }
        }
        bool ITypeDescriptor.IsOfType<T>()
        {
            return typeof(T) == StorageSchema.s_cellType_TDARootCell;
        }
        bool ITypeDescriptor.IsList()
        {
            return false;
        }
        IReadOnlyDictionary<string, string> IAttributeCollection.Attributes
        {
            get { return StorageSchema.TDARootCell.Attributes; }
        }
        string IAttributeCollection.GetAttributeValue(string attributeKey)
        {
            return StorageSchema.TDARootCell.GetAttributeValue(attributeKey);
        }
        ushort ICellDescriptor.CellType
        {
            get
            {
                return (ushort)CellType.TDARootCell;
            }
        }
        public ICellAccessor Serialize()
        {
            return this;
        }
        #endregion
        public ICell Deserialize()
        {
            return (TDARootCell)this;
        }
    }
    ///<summary>
    ///Provides interfaces for accessing TDARootCell cells
    ///on <see cref="Trinity.Storage.LocalMemorySotrage"/>.
    static public class StorageExtension_TDARootCell
    {
        #region IKeyValueStore non logging
        /// <summary>
        /// Adds a new cell of type TDARootCell to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. The value of the cell is specified in the method parameters.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.IKeyValueStore"/> instance.</param>
        /// <param name="cellId">A 64-bit cell Id.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveTDARootCell(this IKeyValueStore storage, long cellId, TDABasket inbasket = default(TDABasket), TDABasket outbasket = default(TDABasket), TDALedgers ledgers = default(TDALedgers))
        {
            
            byte* targetPtr;
            
            targetPtr = null;
            
            {

            {

if(inbasket.itemids!= null)
{
    targetPtr += inbasket.itemids.Count*8+sizeof(int);
}else
{
    targetPtr += sizeof(int);
}

            }
            {

if(outbasket.itemids!= null)
{
    targetPtr += outbasket.itemids.Count*8+sizeof(int);
}else
{
    targetPtr += sizeof(int);
}

            }targetPtr += 32;

            }
            byte[] tmpcell = new byte[(int)(targetPtr)];
            fixed (byte* _tmpcellptr = tmpcell)
            {
                targetPtr = _tmpcellptr;
                
            {

            {

if(inbasket.itemids!= null)
{
    *(int*)targetPtr = inbasket.itemids.Count*8;
    targetPtr += sizeof(int);
    for(int iterator_3 = 0;iterator_3<inbasket.itemids.Count;++iterator_3)
    {
            *(long*)targetPtr = inbasket.itemids[iterator_3];
            targetPtr += 8;

    }

}else
{
    *(int*)targetPtr = 0;
    targetPtr += sizeof(int);
}

            }
            {

if(outbasket.itemids!= null)
{
    *(int*)targetPtr = outbasket.itemids.Count*8;
    targetPtr += sizeof(int);
    for(int iterator_3 = 0;iterator_3<outbasket.itemids.Count;++iterator_3)
    {
            *(long*)targetPtr = outbasket.itemids[iterator_3];
            targetPtr += 8;

    }

}else
{
    *(int*)targetPtr = 0;
    targetPtr += sizeof(int);
}

            }
            {
            if(ledgers.ledgerids!= null){
                if(ledgers.ledgerids.Rank != 1) throw new IndexOutOfRangeException("The assigned array'storage Rank mismatch.");
                if(ledgers.ledgerids.GetLength(0) != 4) throw new IndexOutOfRangeException("The assigned array'storage dimension mismatch.");
               fixed(long* storedPtr_3 = ledgers.ledgerids)
                   Memory.memcpy(targetPtr, storedPtr_3, (ulong)(32));
            } else {
                Memory.memset(targetPtr, 0, (ulong)(32));
            }
            targetPtr += 32;

            }
            }
            }
            
            return storage.SaveCell(cellId, tmpcell, (ushort)CellType.TDARootCell) == TrinityErrorCode.E_SUCCESS;
        }
        /// <summary>
        /// Adds a new cell of type TDARootCell to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. The parameter <paramref name="cellId"/> overrides the cell id in the content object.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.IKeyValueStore"/> instance.</param>
        /// <param name="cellId">A 64-bit cell Id.</param>
        /// <param name="cellContent">The content of the cell.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveTDARootCell(this IKeyValueStore storage, long cellId, TDARootCell cellContent)
        {
            return SaveTDARootCell(storage, cellId  , cellContent.inbasket  , cellContent.outbasket  , cellContent.ledgers );
        }
        /// <summary>
        /// Adds a new cell of type TDARootCell to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. Cell Id is specified by the CellId field in the content object.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.IKeyValueStore"/> instance.</param>
        /// <param name="cellContent">The content of the cell.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveTDARootCell(this IKeyValueStore storage, TDARootCell cellContent)
        {
            return SaveTDARootCell(storage, cellContent.CellId  , cellContent.inbasket  , cellContent.outbasket  , cellContent.ledgers );
        }
        /// <summary>
        /// Loads the content of the specified cell. Any changes done to this object are not written to the store, unless
        /// the content object is saved back into the storage.
        /// <param name="storage"/>A <see cref="Trinity.Storage.IKeyValueStore"/> instance.</param>
        /// </summary>
        public unsafe static TDARootCell LoadTDARootCell(this IKeyValueStore storage, long cellId)
        {
            if (TrinityErrorCode.E_SUCCESS == storage.LoadCell(cellId, out var buff))
            {
                fixed (byte* p = buff)
                {
                    return TDARootCell_Accessor._get()._Setup(cellId, p, -1, 0);
                }
            }
            else
            {
                Throw.cell_not_found();
                throw new Exception();
            }
        }
        #endregion
        #region LocalMemoryStorage Non-Tx accessors
        /// <summary>
        /// Allocate a cell accessor on the specified cell, which interprets
        /// the cell as a TDARootCell. Any changes done to the accessor
        /// are written to the storage immediately.
        /// If <c><see cref="Trinity.TrinityConfig.ReadOnly"/> == false</c>,
        /// on calling this method, it attempts to acquire the lock of the cell,
        /// and blocks until it gets the lock. Otherwise this method is wait-free.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">The id of the specified cell.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <returns>A <see cref="TDW.TDACommon.TDARootCell"/> instance.</returns>
        public unsafe static TDARootCell_Accessor UseTDARootCell(this Trinity.Storage.LocalMemoryStorage storage, long cellId, CellAccessOptions options)
        {
            return TDARootCell_Accessor._get()._Lock(cellId, options);
        }
        /// <summary>
        /// Allocate a cell accessor on the specified cell, which interprets
        /// the cell as a TDARootCell. Any changes done to the accessor
        /// are written to the storage immediately.
        /// If <c><see cref="Trinity.TrinityConfig.ReadOnly"/> == false</c>,
        /// on calling this method, it attempts to acquire the lock of the cell,
        /// and blocks until it gets the lock.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">The id of the specified cell.</param>
        /// <returns>A <see cref="" + script.RootNamespace + ".TDARootCell"/> instance.</returns>
        public unsafe static TDARootCell_Accessor UseTDARootCell(this Trinity.Storage.LocalMemoryStorage storage, long cellId)
        {
            return TDARootCell_Accessor._get()._Lock(cellId, CellAccessOptions.ThrowExceptionOnCellNotFound);
        }
        #endregion
        #region LocalStorage Non-Tx logging
        /// <summary>
        /// Adds a new cell of type TDARootCell to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. The value of the cell is specified in the method parameters.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">A 64-bit cell Id.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveTDARootCell(this Trinity.Storage.LocalMemoryStorage storage, CellAccessOptions options, long cellId, TDABasket inbasket = default(TDABasket), TDABasket outbasket = default(TDABasket), TDALedgers ledgers = default(TDALedgers))
        {
            
            byte* targetPtr;
            
            targetPtr = null;
            
            {

            {

if(inbasket.itemids!= null)
{
    targetPtr += inbasket.itemids.Count*8+sizeof(int);
}else
{
    targetPtr += sizeof(int);
}

            }
            {

if(outbasket.itemids!= null)
{
    targetPtr += outbasket.itemids.Count*8+sizeof(int);
}else
{
    targetPtr += sizeof(int);
}

            }targetPtr += 32;

            }
            byte[] tmpcell = new byte[(int)(targetPtr)];
            fixed (byte* _tmpcellptr = tmpcell)
            {
                targetPtr = _tmpcellptr;
                
            {

            {

if(inbasket.itemids!= null)
{
    *(int*)targetPtr = inbasket.itemids.Count*8;
    targetPtr += sizeof(int);
    for(int iterator_3 = 0;iterator_3<inbasket.itemids.Count;++iterator_3)
    {
            *(long*)targetPtr = inbasket.itemids[iterator_3];
            targetPtr += 8;

    }

}else
{
    *(int*)targetPtr = 0;
    targetPtr += sizeof(int);
}

            }
            {

if(outbasket.itemids!= null)
{
    *(int*)targetPtr = outbasket.itemids.Count*8;
    targetPtr += sizeof(int);
    for(int iterator_3 = 0;iterator_3<outbasket.itemids.Count;++iterator_3)
    {
            *(long*)targetPtr = outbasket.itemids[iterator_3];
            targetPtr += 8;

    }

}else
{
    *(int*)targetPtr = 0;
    targetPtr += sizeof(int);
}

            }
            {
            if(ledgers.ledgerids!= null){
                if(ledgers.ledgerids.Rank != 1) throw new IndexOutOfRangeException("The assigned array'storage Rank mismatch.");
                if(ledgers.ledgerids.GetLength(0) != 4) throw new IndexOutOfRangeException("The assigned array'storage dimension mismatch.");
               fixed(long* storedPtr_3 = ledgers.ledgerids)
                   Memory.memcpy(targetPtr, storedPtr_3, (ulong)(32));
            } else {
                Memory.memset(targetPtr, 0, (ulong)(32));
            }
            targetPtr += 32;

            }
            }
            }
            
            return storage.SaveCell(options, cellId, tmpcell, 0, tmpcell.Length, (ushort)CellType.TDARootCell) == TrinityErrorCode.E_SUCCESS;
        }
        /// <summary>
        /// Adds a new cell of type TDARootCell to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. The parameter <paramref name="cellId"/> overrides the cell id in the content object.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">A 64-bit cell Id.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <param name="cellContent">The content of the cell.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveTDARootCell(this Trinity.Storage.LocalMemoryStorage storage, CellAccessOptions options, long cellId, TDARootCell cellContent)
        {
            return SaveTDARootCell(storage, options, cellId  , cellContent.inbasket  , cellContent.outbasket  , cellContent.ledgers );
        }
        /// <summary>
        /// Adds a new cell of type TDARootCell to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. Cell Id is specified by the CellId field in the content object.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <param name="cellContent">The content of the cell.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveTDARootCell(this Trinity.Storage.LocalMemoryStorage storage, CellAccessOptions options, TDARootCell cellContent)
        {
            return SaveTDARootCell(storage, options, cellContent.CellId  , cellContent.inbasket  , cellContent.outbasket  , cellContent.ledgers );
        }
        /// <summary>
        /// Loads the content of the specified cell. Any changes done to this object are not written to the store, unless
        /// the content object is saved back into the storage.
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// </summary>
        public unsafe static TDARootCell LoadTDARootCell(this Trinity.Storage.LocalMemoryStorage storage, long cellId)
        {
            using (var cell = TDARootCell_Accessor._get()._Lock(cellId, CellAccessOptions.ThrowExceptionOnCellNotFound))
            {
                return cell;
            }
        }
        #endregion
        #region LocalMemoryStorage Tx accessors
        /// <summary>
        /// Allocate a cell accessor on the specified cell, which interprets
        /// the cell as a TDARootCell. Any changes done to the accessor
        /// are written to the storage immediately.
        /// If <c><see cref="Trinity.TrinityConfig.ReadOnly"/> == false</c>,
        /// on calling this method, it attempts to acquire the lock of the cell,
        /// and blocks until it gets the lock. Otherwise this method is wait-free.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">The id of the specified cell.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <returns>A <see cref="TDW.TDACommon.TDARootCell"/> instance.</returns>
        public unsafe static TDARootCell_Accessor UseTDARootCell(this Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx, long cellId, CellAccessOptions options)
        {
            return TDARootCell_Accessor._get()._Lock(cellId, options, tx);
        }
        /// <summary>
        /// Allocate a cell accessor on the specified cell, which interprets
        /// the cell as a TDARootCell. Any changes done to the accessor
        /// are written to the storage immediately.
        /// If <c><see cref="Trinity.TrinityConfig.ReadOnly"/> == false</c>,
        /// on calling this method, it attempts to acquire the lock of the cell,
        /// and blocks until it gets the lock.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">The id of the specified cell.</param>
        /// <returns>A <see cref="" + script.RootNamespace + ".TDARootCell"/> instance.</returns>
        public unsafe static TDARootCell_Accessor UseTDARootCell(this Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx, long cellId)
        {
            return TDARootCell_Accessor._get()._Lock(cellId, CellAccessOptions.ThrowExceptionOnCellNotFound, tx);
        }
        #endregion
        #region LocalStorage Tx logging
        /// <summary>
        /// Adds a new cell of type TDARootCell to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. The value of the cell is specified in the method parameters.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">A 64-bit cell Id.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveTDARootCell(this Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx, CellAccessOptions options, long cellId, TDABasket inbasket = default(TDABasket), TDABasket outbasket = default(TDABasket), TDALedgers ledgers = default(TDALedgers))
        {
            
            byte* targetPtr;
            
            targetPtr = null;
            
            {

            {

if(inbasket.itemids!= null)
{
    targetPtr += inbasket.itemids.Count*8+sizeof(int);
}else
{
    targetPtr += sizeof(int);
}

            }
            {

if(outbasket.itemids!= null)
{
    targetPtr += outbasket.itemids.Count*8+sizeof(int);
}else
{
    targetPtr += sizeof(int);
}

            }targetPtr += 32;

            }
            byte[] tmpcell = new byte[(int)(targetPtr)];
            fixed (byte* _tmpcellptr = tmpcell)
            {
                targetPtr = _tmpcellptr;
                
            {

            {

if(inbasket.itemids!= null)
{
    *(int*)targetPtr = inbasket.itemids.Count*8;
    targetPtr += sizeof(int);
    for(int iterator_3 = 0;iterator_3<inbasket.itemids.Count;++iterator_3)
    {
            *(long*)targetPtr = inbasket.itemids[iterator_3];
            targetPtr += 8;

    }

}else
{
    *(int*)targetPtr = 0;
    targetPtr += sizeof(int);
}

            }
            {

if(outbasket.itemids!= null)
{
    *(int*)targetPtr = outbasket.itemids.Count*8;
    targetPtr += sizeof(int);
    for(int iterator_3 = 0;iterator_3<outbasket.itemids.Count;++iterator_3)
    {
            *(long*)targetPtr = outbasket.itemids[iterator_3];
            targetPtr += 8;

    }

}else
{
    *(int*)targetPtr = 0;
    targetPtr += sizeof(int);
}

            }
            {
            if(ledgers.ledgerids!= null){
                if(ledgers.ledgerids.Rank != 1) throw new IndexOutOfRangeException("The assigned array'storage Rank mismatch.");
                if(ledgers.ledgerids.GetLength(0) != 4) throw new IndexOutOfRangeException("The assigned array'storage dimension mismatch.");
               fixed(long* storedPtr_3 = ledgers.ledgerids)
                   Memory.memcpy(targetPtr, storedPtr_3, (ulong)(32));
            } else {
                Memory.memset(targetPtr, 0, (ulong)(32));
            }
            targetPtr += 32;

            }
            }
            }
            
            return storage.SaveCell(tx, options, cellId, tmpcell, 0, tmpcell.Length, (ushort)CellType.TDARootCell) == TrinityErrorCode.E_SUCCESS;
        }
        /// <summary>
        /// Adds a new cell of type TDARootCell to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. The parameter <paramref name="cellId"/> overrides the cell id in the content object.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">A 64-bit cell Id.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <param name="cellContent">The content of the cell.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveTDARootCell(this Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx, CellAccessOptions options, long cellId, TDARootCell cellContent)
        {
            return SaveTDARootCell(storage, tx, options, cellId  , cellContent.inbasket  , cellContent.outbasket  , cellContent.ledgers );
        }
        /// <summary>
        /// Adds a new cell of type TDARootCell to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. Cell Id is specified by the CellId field in the content object.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <param name="cellContent">The content of the cell.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveTDARootCell(this Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx, CellAccessOptions options, TDARootCell cellContent)
        {
            return SaveTDARootCell(storage, tx, options, cellContent.CellId  , cellContent.inbasket  , cellContent.outbasket  , cellContent.ledgers );
        }
        /// <summary>
        /// Loads the content of the specified cell. Any changes done to this object are not written to the store, unless
        /// the content object is saved back into the storage.
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// </summary>
        public unsafe static TDARootCell LoadTDARootCell(this Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx, long cellId)
        {
            using (var cell = TDARootCell_Accessor._get()._Lock(cellId, CellAccessOptions.ThrowExceptionOnCellNotFound, tx))
            {
                return cell;
            }
        }
        #endregion
    }
}

#pragma warning restore 162,168,649,660,661,1522
