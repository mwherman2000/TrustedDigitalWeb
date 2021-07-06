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
namespace TDW.VDAServer
{
    
    /// <summary>
    /// A .NET runtime object representation of TDWVDAAccount defined in TSL.
    /// </summary>
    public partial struct TDWVDAAccount : ICell
    {
        ///<summary>
        ///The id of the cell.
        ///</summary>
        public long CellId;
        ///<summary>
        ///Initializes a new instance of TDWVDAAccount with the specified parameters.
        ///</summary>
        public TDWVDAAccount(long cell_id , TDWVDAAccountEntryCore AccountCore = default(TDWVDAAccountEntryCore), TRAEnvelope Envelope = default(TRAEnvelope), string EncryptedAccountCore = default(string))
        {
            
            this.AccountCore = AccountCore;
            
            this.Envelope = Envelope;
            
            this.EncryptedAccountCore = EncryptedAccountCore;
            
            CellId = cell_id;
        }
        
        ///<summary>
        ///Initializes a new instance of TDWVDAAccount with the specified parameters.
        ///</summary>
        public TDWVDAAccount( TDWVDAAccountEntryCore AccountCore = default(TDWVDAAccountEntryCore), TRAEnvelope Envelope = default(TRAEnvelope), string EncryptedAccountCore = default(string))
        {
            
            this.AccountCore = AccountCore;
            
            this.Envelope = Envelope;
            
            this.EncryptedAccountCore = EncryptedAccountCore;
            
            CellId = CellIdFactory.NewCellId();
        }
        
        public TDWVDAAccountEntryCore AccountCore;
        
        public TRAEnvelope Envelope;
        
        public string EncryptedAccountCore;
        
        public static bool operator ==(TDWVDAAccount a, TDWVDAAccount b)
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
                
                (a.AccountCore == b.AccountCore)
                &&
                (a.Envelope == b.Envelope)
                &&
                (a.EncryptedAccountCore == b.EncryptedAccountCore)
                
                ;
            
        }
        public static bool operator !=(TDWVDAAccount a, TDWVDAAccount b)
        {
            return !(a == b);
        }
        #region Text processing
        /// <summary>
        /// Converts the string representation of a TDWVDAAccount to its
        /// struct equivalent. A return value indicates whether the 
        /// operation succeeded.
        /// </summary>
        /// <param name="input">A string to convert.</param>
        /// <param name="value">
        /// When this method returns, contains the struct equivalent of the value contained 
        /// in input, if the conversion succeeded, or default(TDWVDAAccount) if the conversion
        /// failed. The conversion fails if the input parameter is null or String.Empty, or is 
        /// not of the correct format. This parameter is passed uninitialized.
        /// </param>
        /// <returns>
        /// True if input was converted successfully; otherwise, false.
        /// </returns>
        public static bool TryParse(string input, out TDWVDAAccount value)
        {
            try
            {
                value = Newtonsoft.Json.JsonConvert.DeserializeObject<TDWVDAAccount>(input);
                return true;
            }
            catch { value = default(TDWVDAAccount); return false; }
        }
        public static TDWVDAAccount Parse(string input)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TDWVDAAccount>(input);
        }
        ///<summary>Converts a TDWVDAAccount to its string representation, in JSON format.</summary>
        ///<returns>A string representation of the TDWVDAAccount.</returns>
        public override string ToString()
        {
            return Serializer.ToString(this);
        }
        #endregion
        #region Lookup tables
        internal static StringLookupTable FieldLookupTable = new StringLookupTable(
            
            "AccountCore"
            ,
            "Envelope"
            ,
            "EncryptedAccountCore"
            
            );
        internal static HashSet<string> AppendToFieldRerouteSet = new HashSet<string>()
        {
            
            "AccountCore"
            ,
            "Envelope"
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
                return TypeConverter<T>.ConvertFrom_TDWVDAAccountEntryCore(this.AccountCore);
                
                case 1:
                return TypeConverter<T>.ConvertFrom_TRAEnvelope(this.Envelope);
                
                case 2:
                return TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore);
                
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
                this.AccountCore = TypeConverter<T>.ConvertTo_TDWVDAAccountEntryCore(value);
                break;
                
                case 1:
                this.Envelope = TypeConverter<T>.ConvertTo_TRAEnvelope(value);
                break;
                
                case 2:
                this.EncryptedAccountCore = TypeConverter<T>.ConvertTo_string(value);
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
                
                return this.EncryptedAccountCore != null;
                
                default:
                return false;
            }
        }
        /// <summary>
        /// Append <paramref name="value"/> to the target field. Note that if the target field
        /// is not appendable(string or list), calling this method is equivalent to <see cref="TDW.VDAServer.GenericCellAccessor.SetField(string, T)"/>.
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
                
                case 2:
                
                {
                    if (this.EncryptedAccountCore == null)
                        this.EncryptedAccountCore = TypeConverter<T>.ConvertTo_string(value);
                    else
                        this.EncryptedAccountCore += TypeConverter<T>.ConvertTo_string(value);
                }
                
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
                
                case 0:
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.EncryptedAccountCore, attributeKey, attributeValue))
                    
                    if (this.EncryptedAccountCore != null)
                        
                        yield return new KeyValuePair<string, T>("EncryptedAccountCore", TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore));
                
                break;
                
                case 1:
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.EncryptedAccountCore, attributeKey, attributeValue))
                    
                    if (this.EncryptedAccountCore != null)
                        
                        yield return new KeyValuePair<string, T>("EncryptedAccountCore", TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore));
                
                break;
                
                case 2:
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.AccountCore, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("AccountCore", TypeConverter<T>.ConvertFrom_TDWVDAAccountEntryCore(this.AccountCore));
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.Envelope, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("Envelope", TypeConverter<T>.ConvertFrom_TRAEnvelope(this.Envelope));
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.EncryptedAccountCore, attributeKey, attributeValue))
                    
                    if (this.EncryptedAccountCore != null)
                        
                        yield return new KeyValuePair<string, T>("EncryptedAccountCore", TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore));
                
                break;
                
                case 3:
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.AccountCore, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("AccountCore", TypeConverter<T>.ConvertFrom_TDWVDAAccountEntryCore(this.AccountCore));
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.Envelope, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("Envelope", TypeConverter<T>.ConvertFrom_TRAEnvelope(this.Envelope));
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.EncryptedAccountCore, attributeKey, attributeValue))
                    
                    if (this.EncryptedAccountCore != null)
                        
                        yield return new KeyValuePair<string, T>("EncryptedAccountCore", TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore));
                
                break;
                
                case 4:
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.AccountCore, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("AccountCore", TypeConverter<T>.ConvertFrom_TDWVDAAccountEntryCore(this.AccountCore));
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.EncryptedAccountCore, attributeKey, attributeValue))
                    
                    if (this.EncryptedAccountCore != null)
                        
                        yield return new KeyValuePair<string, T>("EncryptedAccountCore", TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore));
                
                break;
                
                case 5:
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.EncryptedAccountCore, attributeKey, attributeValue))
                    
                    if (this.EncryptedAccountCore != null)
                        
                        yield return new KeyValuePair<string, T>("EncryptedAccountCore", TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore));
                
                break;
                
                case 6:
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.EncryptedAccountCore, attributeKey, attributeValue))
                    
                    if (this.EncryptedAccountCore != null)
                        
                        yield return new KeyValuePair<string, T>("EncryptedAccountCore", TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore));
                
                break;
                
                case 7:
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.EncryptedAccountCore, attributeKey, attributeValue))
                    
                    if (this.EncryptedAccountCore != null)
                        
                        yield return new KeyValuePair<string, T>("EncryptedAccountCore", TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore));
                
                break;
                
                case 8:
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.EncryptedAccountCore, attributeKey, attributeValue))
                    
                    if (this.EncryptedAccountCore != null)
                        
                        yield return new KeyValuePair<string, T>("EncryptedAccountCore", TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore));
                
                break;
                
                case 9:
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.EncryptedAccountCore, attributeKey, attributeValue))
                    
                    if (this.EncryptedAccountCore != null)
                        
                        yield return new KeyValuePair<string, T>("EncryptedAccountCore", TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore));
                
                break;
                
                case 10:
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.Envelope, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("Envelope", TypeConverter<T>.ConvertFrom_TRAEnvelope(this.Envelope));
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.EncryptedAccountCore, attributeKey, attributeValue))
                    
                    if (this.EncryptedAccountCore != null)
                        
                        yield return new KeyValuePair<string, T>("EncryptedAccountCore", TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore));
                
                break;
                
                case 11:
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.EncryptedAccountCore, attributeKey, attributeValue))
                    
                    if (this.EncryptedAccountCore != null)
                        
                        yield return new KeyValuePair<string, T>("EncryptedAccountCore", TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore));
                
                break;
                
                case 12:
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.EncryptedAccountCore, attributeKey, attributeValue))
                    
                    if (this.EncryptedAccountCore != null)
                        
                        yield return new KeyValuePair<string, T>("EncryptedAccountCore", TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore));
                
                break;
                
                case 13:
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.EncryptedAccountCore, attributeKey, attributeValue))
                    
                    if (this.EncryptedAccountCore != null)
                        
                        yield return new KeyValuePair<string, T>("EncryptedAccountCore", TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore));
                
                break;
                
                case 14:
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.EncryptedAccountCore, attributeKey, attributeValue))
                    
                    if (this.EncryptedAccountCore != null)
                        
                        yield return new KeyValuePair<string, T>("EncryptedAccountCore", TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore));
                
                break;
                
                case 15:
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.AccountCore, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("AccountCore", TypeConverter<T>.ConvertFrom_TDWVDAAccountEntryCore(this.AccountCore));
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.Envelope, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("Envelope", TypeConverter<T>.ConvertFrom_TRAEnvelope(this.Envelope));
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.EncryptedAccountCore, attributeKey, attributeValue))
                    
                    if (this.EncryptedAccountCore != null)
                        
                        yield return new KeyValuePair<string, T>("EncryptedAccountCore", TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore));
                
                break;
                
                default:
                Throw.incompatible_with_cell();
                break;
            }
            yield break;
        }
        #region enumerate value constructs
        
        private IEnumerable<T> _enumerate_from_AccountCore<T>()
        {
            
            switch (TypeConverter<T>.type_id)
            {
                
                case 2:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_TDWVDAAccountEntryCore(this.AccountCore);
                        
                    }
                    break;
                
                case 3:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_TDWVDAAccountEntryCore(this.AccountCore);
                        
                    }
                    break;
                
                case 4:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_TDWVDAAccountEntryCore(this.AccountCore);
                        
                    }
                    break;
                
                case 15:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_TDWVDAAccountEntryCore(this.AccountCore);
                        
                    }
                    break;
                
                default:
                    Throw.incompatible_with_cell();
                    break;
            }
            yield break;
            
        }
        
        private IEnumerable<T> _enumerate_from_Envelope<T>()
        {
            
            switch (TypeConverter<T>.type_id)
            {
                
                case 2:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_TRAEnvelope(this.Envelope);
                        
                    }
                    break;
                
                case 3:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_TRAEnvelope(this.Envelope);
                        
                    }
                    break;
                
                case 10:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_TRAEnvelope(this.Envelope);
                        
                    }
                    break;
                
                case 15:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_TRAEnvelope(this.Envelope);
                        
                    }
                    break;
                
                default:
                    Throw.incompatible_with_cell();
                    break;
            }
            yield break;
            
        }
        
        private IEnumerable<T> _enumerate_from_EncryptedAccountCore<T>()
        {
            
            if (this.EncryptedAccountCore != null)
                
            switch (TypeConverter<T>.type_id)
            {
                
                case 0:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore);
                        
                    }
                    break;
                
                case 1:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore);
                        
                    }
                    break;
                
                case 2:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore);
                        
                    }
                    break;
                
                case 3:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore);
                        
                    }
                    break;
                
                case 4:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore);
                        
                    }
                    break;
                
                case 5:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore);
                        
                    }
                    break;
                
                case 6:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore);
                        
                    }
                    break;
                
                case 7:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore);
                        
                    }
                    break;
                
                case 8:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore);
                        
                    }
                    break;
                
                case 9:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore);
                        
                    }
                    break;
                
                case 10:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore);
                        
                    }
                    break;
                
                case 11:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore);
                        
                    }
                    break;
                
                case 12:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore);
                        
                    }
                    break;
                
                case 13:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore);
                        
                    }
                    break;
                
                case 14:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore);
                        
                    }
                    break;
                
                case 15:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore);
                        
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
                return _enumerate_from_AccountCore<T>();
                
                case 1:
                return _enumerate_from_Envelope<T>();
                
                case 2:
                return _enumerate_from_EncryptedAccountCore<T>();
                
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
                
                foreach (var val in _enumerate_from_AccountCore<T>())
                    yield return val;
                
                foreach (var val in _enumerate_from_Envelope<T>())
                    yield return val;
                
                foreach (var val in _enumerate_from_EncryptedAccountCore<T>())
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
            return (TDWVDAAccount_Accessor)this;
        }
        #endregion
        #region Other interfaces
        string ITypeDescriptor.TypeName
        {
            get { return StorageSchema.s_cellTypeName_TDWVDAAccount; }
        }
        Type ITypeDescriptor.Type
        {
            get { return StorageSchema.s_cellType_TDWVDAAccount; }
        }
        bool ITypeDescriptor.IsOfType<T>()
        {
            return typeof(T) == StorageSchema.s_cellType_TDWVDAAccount;
        }
        bool ITypeDescriptor.IsList()
        {
            return false;
        }
        IEnumerable<IFieldDescriptor> ICellDescriptor.GetFieldDescriptors()
        {
            return StorageSchema.TDWVDAAccount.GetFieldDescriptors();
        }
        IAttributeCollection ICellDescriptor.GetFieldAttributes(string fieldName)
        {
            return StorageSchema.TDWVDAAccount.GetFieldAttributes(fieldName);
        }
        string IAttributeCollection.GetAttributeValue(string attributeKey)
        {
            return StorageSchema.TDWVDAAccount.GetAttributeValue(attributeKey);
        }
        IReadOnlyDictionary<string, string> IAttributeCollection.Attributes
        {
            get { return StorageSchema.TDWVDAAccount.Attributes; }
        }
        IEnumerable<string> ICellDescriptor.GetFieldNames()
        {
            
            {
                yield return "AccountCore";
            }
            
            {
                yield return "Envelope";
            }
            
            {
                if (this.EncryptedAccountCore != null)
                    yield return "EncryptedAccountCore";
            }
            
        }
        ushort ICellDescriptor.CellType
        {
            get
            {
                return (ushort)CellType.TDWVDAAccount;
            }
        }
        #endregion
    }
    /// <summary>
    /// Provides in-place operations of TDWVDAAccount defined in TSL.
    /// </summary>
    public unsafe class TDWVDAAccount_Accessor : ICellAccessor
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
        private unsafe TDWVDAAccount_Accessor()
        {
                    AccountCore_Accessor_Field = new TDWVDAAccountEntryCore_Accessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        Envelope_Accessor_Field = new TRAEnvelope_Accessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        EncryptedAccountCore_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });
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
                    
                    "EncryptedAccountCore"
                    
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
            
            byte [] bytes = new byte[1];
            Memory.Copy(m_ptr, 0, bytes, 0, 1);
            return bytes;
            
        }
        
        #region IAccessor Implementation
        public byte[] ToByteArray()
        {
            byte* targetPtr = m_ptr;
            {            byte* optheader_0 = targetPtr;
            targetPtr += 1;
{            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            byte* optheader_2 = targetPtr;
            targetPtr += 1;
            targetPtr += 2;

                if ((0 != (*(optheader_2 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_2 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_2 + 0) & 0x04)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_2 + 0) & 0x08)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
                if ((0 != (*(optheader_0 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
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
            {            byte* optheader_0 = targetPtr;
            targetPtr += 1;
{            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            byte* optheader_2 = targetPtr;
            targetPtr += 1;
            targetPtr += 2;

                if ((0 != (*(optheader_2 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_2 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_2 + 0) & 0x04)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_2 + 0) & 0x08)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
                if ((0 != (*(optheader_0 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
            int size = (int)(targetPtr - m_ptr);
            return size;
        }
        public ResizeFunctionDelegate ResizeFunction { get; set; }
        #endregion
        private static byte[] s_default_content = null;
        private static unsafe byte[] construct( TDWVDAAccountEntryCore AccountCore = default(TDWVDAAccountEntryCore) , TRAEnvelope Envelope = default(TRAEnvelope) , string EncryptedAccountCore = default(string) )
        {
            if (s_default_content != null) return s_default_content;
            
            byte* targetPtr;
            
            targetPtr = null;
            
            {
            targetPtr += 1;

            {
            targetPtr += 8;

        if(AccountCore.udid!= null)
        {
            int strlen_3 = AccountCore.udid.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(AccountCore.walletname!= null)
        {
            int strlen_3 = AccountCore.walletname.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(AccountCore.walletpassword!= null)
        {
            int strlen_3 = AccountCore.walletpassword.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(AccountCore.walletaccountname!= null)
        {
            int strlen_3 = AccountCore.walletaccountname.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(AccountCore.ledgeraddress!= null)
        {
            int strlen_3 = AccountCore.ledgeraddress.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            {
            targetPtr += 1;
            targetPtr += 1;
            targetPtr += 1;
            if( Envelope.hashedThumbprint64!= null)
            {

        if(Envelope.hashedThumbprint64!= null)
        {
            int strlen_3 = Envelope.hashedThumbprint64.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( Envelope.signedHashSignature64!= null)
            {

        if(Envelope.signedHashSignature64!= null)
        {
            int strlen_3 = Envelope.signedHashSignature64.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( Envelope.notaryStamp!= null)
            {

        if(Envelope.notaryStamp!= null)
        {
            int strlen_3 = Envelope.notaryStamp.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( Envelope.comments!= null)
            {

{

    targetPtr += sizeof(int);
    if(Envelope.comments!= null)
    {
        for(int iterator_3 = 0;iterator_3<Envelope.comments.Count;++iterator_3)
        {

        if(Envelope.comments[iterator_3]!= null)
        {
            int strlen_4 = Envelope.comments[iterator_3].Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        }
    }

}

            }

            }            if( EncryptedAccountCore!= null)
            {

        if(EncryptedAccountCore!= null)
        {
            int strlen_2 = EncryptedAccountCore.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

            }
            byte[] tmpcell = new byte[(int)(targetPtr)];
            fixed (byte* _tmpcellptr = tmpcell)
            {
                targetPtr = _tmpcellptr;
                
            {
            byte* optheader_1 = targetPtr;
            *(optheader_1 + 0) = 0x00;            targetPtr += 1;

            {
            *(long*)targetPtr = AccountCore.id;
            targetPtr += 8;

        if(AccountCore.udid!= null)
        {
            int strlen_3 = AccountCore.udid.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = AccountCore.udid)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(AccountCore.walletname!= null)
        {
            int strlen_3 = AccountCore.walletname.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = AccountCore.walletname)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(AccountCore.walletpassword!= null)
        {
            int strlen_3 = AccountCore.walletpassword.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = AccountCore.walletpassword)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(AccountCore.walletaccountname!= null)
        {
            int strlen_3 = AccountCore.walletaccountname.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = AccountCore.walletaccountname)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(AccountCore.ledgeraddress!= null)
        {
            int strlen_3 = AccountCore.ledgeraddress.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = AccountCore.ledgeraddress)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
            {
            byte* optheader_2 = targetPtr;
            *(optheader_2 + 0) = 0x00;            targetPtr += 1;
            *(TRACredentialType*)targetPtr = Envelope.credtype;
            targetPtr += 1;
            *(TRAEncryptionFlag*)targetPtr = Envelope.encryptionFlag;
            targetPtr += 1;
            if( Envelope.hashedThumbprint64!= null)
            {

        if(Envelope.hashedThumbprint64!= null)
        {
            int strlen_3 = Envelope.hashedThumbprint64.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = Envelope.hashedThumbprint64)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_2 + 0) |= 0x01;
            }
            if( Envelope.signedHashSignature64!= null)
            {

        if(Envelope.signedHashSignature64!= null)
        {
            int strlen_3 = Envelope.signedHashSignature64.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = Envelope.signedHashSignature64)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_2 + 0) |= 0x02;
            }
            if( Envelope.notaryStamp!= null)
            {

        if(Envelope.notaryStamp!= null)
        {
            int strlen_3 = Envelope.notaryStamp.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = Envelope.notaryStamp)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_2 + 0) |= 0x04;
            }
            if( Envelope.comments!= null)
            {

{
byte *storedPtr_3 = targetPtr;

    targetPtr += sizeof(int);
    if(Envelope.comments!= null)
    {
        for(int iterator_3 = 0;iterator_3<Envelope.comments.Count;++iterator_3)
        {

        if(Envelope.comments[iterator_3]!= null)
        {
            int strlen_4 = Envelope.comments[iterator_3].Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = Envelope.comments[iterator_3])
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        }
    }
*(int*)storedPtr_3 = (int)(targetPtr - storedPtr_3 - 4);

}
*(optheader_2 + 0) |= 0x08;
            }

            }            if( EncryptedAccountCore!= null)
            {

        if(EncryptedAccountCore!= null)
        {
            int strlen_2 = EncryptedAccountCore.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = EncryptedAccountCore)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_1 + 0) |= 0x01;
            }

            }
            }
            
            s_default_content = tmpcell;
            return tmpcell;
        }
        TDWVDAAccountEntryCore_Accessor AccountCore_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field AccountCore.
        ///</summary>
        public unsafe TDWVDAAccountEntryCore_Accessor AccountCore
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
}AccountCore_Accessor_Field.m_ptr = targetPtr;
                AccountCore_Accessor_Field.m_cellId = this.m_cellId;
                return AccountCore_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                AccountCore_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
}
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
        TRAEnvelope_Accessor Envelope_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field Envelope.
        ///</summary>
        public unsafe TRAEnvelope_Accessor Envelope
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
{            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}}Envelope_Accessor_Field.m_ptr = targetPtr;
                Envelope_Accessor_Field.m_cellId = this.m_cellId;
                return Envelope_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                Envelope_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
{            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}}
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
        StringAccessor EncryptedAccountCore_Accessor_Field;
        
        ///<summary>
        ///Represents the presence of the optional field EncryptedAccountCore.
        ///</summary>
        public bool Contains_EncryptedAccountCore
        {
            get
            {
                unchecked
                {
                    return (0 != (*(this.m_ptr + 0) & 0x01)) ;
                }
            }
            internal set
            {
                unchecked
                {
                    if (value)
                    {
                        *(this.m_ptr + 0) |= 0x01;
                    }
                    else
                    {
                        *(this.m_ptr + 0) &= 0xFE;
                    }
                }
            }
        }
        ///<summary>
        ///Removes the optional field EncryptedAccountCore from the object being operated.
        ///</summary>
        public unsafe void Remove_EncryptedAccountCore()
        {
            if (!this.Contains_EncryptedAccountCore)
            {
                throw new Exception("Optional field EncryptedAccountCore doesn't exist for current cell.");
            }
            this.Contains_EncryptedAccountCore = false;
            byte* targetPtr = m_ptr;
            {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
{            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            byte* optheader_3 = targetPtr;
            targetPtr += 1;
            targetPtr += 2;

                if ((0 != (*(optheader_3 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_3 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_3 + 0) & 0x04)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_3 + 0) & 0x08)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}}
            byte* startPtr = targetPtr;
            targetPtr += *(int*)targetPtr + sizeof(int);
            this.ResizeFunction(startPtr, 0, (int)(startPtr - targetPtr));
        }
        
        ///<summary>
        ///Provides in-place access to the object field EncryptedAccountCore.
        ///</summary>
        public unsafe StringAccessor EncryptedAccountCore
        {
            get
            {
                
                if (!this.Contains_EncryptedAccountCore)
                {
                    throw new Exception("Optional field EncryptedAccountCore doesn't exist for current cell.");
                }
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
{            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            byte* optheader_3 = targetPtr;
            targetPtr += 1;
            targetPtr += 2;

                if ((0 != (*(optheader_3 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_3 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_3 + 0) & 0x04)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_3 + 0) & 0x08)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}}EncryptedAccountCore_Accessor_Field.m_ptr = targetPtr + 4;
                EncryptedAccountCore_Accessor_Field.m_cellId = this.m_cellId;
                return EncryptedAccountCore_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                EncryptedAccountCore_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
{            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            byte* optheader_3 = targetPtr;
            targetPtr += 1;
            targetPtr += 2;

                if ((0 != (*(optheader_3 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_3 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_3 + 0) & 0x04)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_3 + 0) & 0x08)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}}
                bool creatingOptionalField = (!this.Contains_EncryptedAccountCore);
                if (creatingOptionalField)
                {
                    this.Contains_EncryptedAccountCore = true;
                    
                int length = *(int*)(value.m_ptr - 4);
                if (value.m_cellId != EncryptedAccountCore_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    EncryptedAccountCore_Accessor_Field.m_ptr = EncryptedAccountCore_Accessor_Field.ResizeFunction(targetPtr, 0, length + sizeof(int));
                    Memory.Copy(value.m_ptr - 4, EncryptedAccountCore_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        EncryptedAccountCore_Accessor_Field.m_ptr = EncryptedAccountCore_Accessor_Field.ResizeFunction(targetPtr, 0, length + sizeof(int));
                        Memory.Copy(tmpcellptr, EncryptedAccountCore_Accessor_Field.m_ptr, length + 4);
                    }
                }

                }
                else
                {
                    
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != EncryptedAccountCore_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    EncryptedAccountCore_Accessor_Field.m_ptr = EncryptedAccountCore_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, EncryptedAccountCore_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        EncryptedAccountCore_Accessor_Field.m_ptr = EncryptedAccountCore_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, EncryptedAccountCore_Accessor_Field.m_ptr, length + 4);
                    }
                }

                }
                
            }
        }
        
        public static unsafe implicit operator TDWVDAAccount(TDWVDAAccount_Accessor accessor)
        {
            string _EncryptedAccountCore = default(string);
            if (accessor.Contains_EncryptedAccountCore)
            {
                
                _EncryptedAccountCore = accessor.EncryptedAccountCore;
                
            }
            
            return new TDWVDAAccount(accessor.CellId
            
            ,
            
                    accessor.AccountCore
            ,
            
                    accessor.Envelope
            ,
            
            _EncryptedAccountCore 
            );
        }
        
        public unsafe static implicit operator TDWVDAAccount_Accessor(TDWVDAAccount field)
        {
            byte* targetPtr = null;
            
            {
            targetPtr += 1;

            {
            targetPtr += 8;

        if(field.AccountCore.udid!= null)
        {
            int strlen_3 = field.AccountCore.udid.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.AccountCore.walletname!= null)
        {
            int strlen_3 = field.AccountCore.walletname.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.AccountCore.walletpassword!= null)
        {
            int strlen_3 = field.AccountCore.walletpassword.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.AccountCore.walletaccountname!= null)
        {
            int strlen_3 = field.AccountCore.walletaccountname.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.AccountCore.ledgeraddress!= null)
        {
            int strlen_3 = field.AccountCore.ledgeraddress.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            {
            targetPtr += 1;
            targetPtr += 1;
            targetPtr += 1;
            if( field.Envelope.hashedThumbprint64!= null)
            {

        if(field.Envelope.hashedThumbprint64!= null)
        {
            int strlen_3 = field.Envelope.hashedThumbprint64.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( field.Envelope.signedHashSignature64!= null)
            {

        if(field.Envelope.signedHashSignature64!= null)
        {
            int strlen_3 = field.Envelope.signedHashSignature64.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( field.Envelope.notaryStamp!= null)
            {

        if(field.Envelope.notaryStamp!= null)
        {
            int strlen_3 = field.Envelope.notaryStamp.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( field.Envelope.comments!= null)
            {

{

    targetPtr += sizeof(int);
    if(field.Envelope.comments!= null)
    {
        for(int iterator_3 = 0;iterator_3<field.Envelope.comments.Count;++iterator_3)
        {

        if(field.Envelope.comments[iterator_3]!= null)
        {
            int strlen_4 = field.Envelope.comments[iterator_3].Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        }
    }

}

            }

            }            if( field.EncryptedAccountCore!= null)
            {

        if(field.EncryptedAccountCore!= null)
        {
            int strlen_2 = field.EncryptedAccountCore.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

            }
            byte* tmpcellptr = BufferAllocator.AllocBuffer((int)targetPtr);
            Memory.memset(tmpcellptr, 0, (ulong)targetPtr);
            targetPtr = tmpcellptr;
            
            {
            byte* optheader_1 = targetPtr;
            *(optheader_1 + 0) = 0x00;            targetPtr += 1;

            {
            *(long*)targetPtr = field.AccountCore.id;
            targetPtr += 8;

        if(field.AccountCore.udid!= null)
        {
            int strlen_3 = field.AccountCore.udid.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.AccountCore.udid)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.AccountCore.walletname!= null)
        {
            int strlen_3 = field.AccountCore.walletname.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.AccountCore.walletname)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.AccountCore.walletpassword!= null)
        {
            int strlen_3 = field.AccountCore.walletpassword.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.AccountCore.walletpassword)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.AccountCore.walletaccountname!= null)
        {
            int strlen_3 = field.AccountCore.walletaccountname.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.AccountCore.walletaccountname)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.AccountCore.ledgeraddress!= null)
        {
            int strlen_3 = field.AccountCore.ledgeraddress.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.AccountCore.ledgeraddress)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
            {
            byte* optheader_2 = targetPtr;
            *(optheader_2 + 0) = 0x00;            targetPtr += 1;
            *(TRACredentialType*)targetPtr = field.Envelope.credtype;
            targetPtr += 1;
            *(TRAEncryptionFlag*)targetPtr = field.Envelope.encryptionFlag;
            targetPtr += 1;
            if( field.Envelope.hashedThumbprint64!= null)
            {

        if(field.Envelope.hashedThumbprint64!= null)
        {
            int strlen_3 = field.Envelope.hashedThumbprint64.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.Envelope.hashedThumbprint64)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_2 + 0) |= 0x01;
            }
            if( field.Envelope.signedHashSignature64!= null)
            {

        if(field.Envelope.signedHashSignature64!= null)
        {
            int strlen_3 = field.Envelope.signedHashSignature64.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.Envelope.signedHashSignature64)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_2 + 0) |= 0x02;
            }
            if( field.Envelope.notaryStamp!= null)
            {

        if(field.Envelope.notaryStamp!= null)
        {
            int strlen_3 = field.Envelope.notaryStamp.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.Envelope.notaryStamp)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_2 + 0) |= 0x04;
            }
            if( field.Envelope.comments!= null)
            {

{
byte *storedPtr_3 = targetPtr;

    targetPtr += sizeof(int);
    if(field.Envelope.comments!= null)
    {
        for(int iterator_3 = 0;iterator_3<field.Envelope.comments.Count;++iterator_3)
        {

        if(field.Envelope.comments[iterator_3]!= null)
        {
            int strlen_4 = field.Envelope.comments[iterator_3].Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.Envelope.comments[iterator_3])
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        }
    }
*(int*)storedPtr_3 = (int)(targetPtr - storedPtr_3 - 4);

}
*(optheader_2 + 0) |= 0x08;
            }

            }            if( field.EncryptedAccountCore!= null)
            {

        if(field.EncryptedAccountCore!= null)
        {
            int strlen_2 = field.EncryptedAccountCore.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.EncryptedAccountCore)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_1 + 0) |= 0x01;
            }

            }TDWVDAAccount_Accessor ret;
            
            ret = TDWVDAAccount_Accessor._get()._Setup(field.CellId, tmpcellptr, -1, 0, null);
            ret.m_cellId = field.CellId;
            
            return ret;
        }
        
        public static bool operator ==(TDWVDAAccount_Accessor a, TDWVDAAccount_Accessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            byte* targetPtr = a.m_ptr;
            {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
{            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            byte* optheader_3 = targetPtr;
            targetPtr += 1;
            targetPtr += 2;

                if ((0 != (*(optheader_3 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_3 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_3 + 0) & 0x04)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_3 + 0) & 0x08)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
            int lengthA = (int)(targetPtr - a.m_ptr);
            targetPtr = b.m_ptr;
            {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
{            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            byte* optheader_3 = targetPtr;
            targetPtr += 1;
            targetPtr += 2;

                if ((0 != (*(optheader_3 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_3 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_3 + 0) & 0x04)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_3 + 0) & 0x08)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
            int lengthB = (int)(targetPtr - b.m_ptr);
            if(lengthA != lengthB) return false;
            return Memory.Compare(a.m_ptr,b.m_ptr,lengthA);
        }
        public static bool operator != (TDWVDAAccount_Accessor a, TDWVDAAccount_Accessor b)
        {
            return !(a == b);
        }
        
        public static bool operator ==(TDWVDAAccount_Accessor a, TDWVDAAccount b)
        {
            TDWVDAAccount_Accessor bb = b;
            return (a == bb);
        }
        public static bool operator !=(TDWVDAAccount_Accessor a, TDWVDAAccount b)
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
        internal unsafe TDWVDAAccount_Accessor _Lock(long cellId, CellAccessOptions options)
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
                    if (cellType != (ushort)CellType.TDWVDAAccount)
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
                        eResult                = Global.LocalStorage.AddOrUse(cellId, defaultContent, ref size, (ushort)CellType.TDWVDAAccount, out this.m_ptr, out this.m_cellEntryIndex);
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
        internal unsafe TDWVDAAccount_Accessor _Lock(long cellId, CellAccessOptions options, LocalTransactionContext tx)
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
                    if (cellType != (ushort)CellType.TDWVDAAccount)
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
                        eResult                = Global.LocalStorage.AddOrUse(tx, cellId, defaultContent, ref size, (ushort)CellType.TDWVDAAccount, out this.m_ptr, out this.m_cellEntryIndex);
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
        private class PoolPolicy : IPooledObjectPolicy<TDWVDAAccount_Accessor>
        {
            public TDWVDAAccount_Accessor Create()
            {
                return new TDWVDAAccount_Accessor();
            }
            public bool Return(TDWVDAAccount_Accessor obj)
            {
                return !obj.m_IsIterator;
            }
        }
        private static DefaultObjectPool<TDWVDAAccount_Accessor> s_accessor_pool = new DefaultObjectPool<TDWVDAAccount_Accessor>(new PoolPolicy());
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static TDWVDAAccount_Accessor _get() => s_accessor_pool.Get();
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void _put(TDWVDAAccount_Accessor item) => s_accessor_pool.Return(item);
        /// <summary>
        /// For internal use only.
        /// Caller guarantees that entry lock is obtained.
        /// Does not handle CellAccessOptions. Only copy to the accessor.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal TDWVDAAccount_Accessor _Setup(long CellId, byte* cellPtr, int entryIndex, CellAccessOptions options)
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
        internal TDWVDAAccount_Accessor _Setup(long CellId, byte* cellPtr, int entryIndex, CellAccessOptions options, LocalTransactionContext tx)
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
        internal static TDWVDAAccount_Accessor AllocIterativeAccessor(CellInfo info, LocalTransactionContext tx)
        {
            TDWVDAAccount_Accessor accessor = new TDWVDAAccount_Accessor();
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
        /// If write-ahead-log behavior is specified on <see cref="TDW.VDAServer.StorageExtension_TDWVDAAccount.UseTDWVDAAccount"/>,
        /// the changes will be committed to the write-ahead log.
        /// </summary>
        public void Dispose()
        {
            if (m_cellEntryIndex >= 0)
            {
                if ((m_options & c_WALFlags) != 0)
                {
                    LocalMemoryStorage.CWriteAheadLog(this.CellId, this.m_ptr, this.CellSize, (ushort)CellType.TDWVDAAccount, m_options);
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
        /// <summary>Converts a TDWVDAAccount_Accessor to its string representation, in JSON format.</summary>
        /// <returns>A string representation of the TDWVDAAccount.</returns>
        public override string ToString()
        {
            return Serializer.ToString(this);
        }
        #endregion
        #region Lookup tables
        internal static StringLookupTable FieldLookupTable = new StringLookupTable(
            
            "AccountCore"
            ,
            "Envelope"
            ,
            "EncryptedAccountCore"
            
            );
        static HashSet<string> AppendToFieldRerouteSet = new HashSet<string>()
        {
            
            "AccountCore"
            ,
            "Envelope"
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
                    return GenericFieldAccessor.GetField<T>(this.AccountCore, fieldName, field_divider_idx + 1);
                    
                    case 1:
                    return GenericFieldAccessor.GetField<T>(this.Envelope, fieldName, field_divider_idx + 1);
                    
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
                return TypeConverter<T>.ConvertFrom_TDWVDAAccountEntryCore(this.AccountCore);
                
                case 1:
                return TypeConverter<T>.ConvertFrom_TRAEnvelope(this.Envelope);
                
                case 2:
                return TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore);
                
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
                    GenericFieldAccessor.SetField(this.AccountCore, fieldName, field_divider_idx + 1, value);
                    break;
                    
                    case 1:
                    GenericFieldAccessor.SetField(this.Envelope, fieldName, field_divider_idx + 1, value);
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
                    TDWVDAAccountEntryCore conversion_result = TypeConverter<T>.ConvertTo_TDWVDAAccountEntryCore(value);
                    
            {
                this.AccountCore = conversion_result;
            }
            
                }
                break;
                
                case 1:
                {
                    TRAEnvelope conversion_result = TypeConverter<T>.ConvertTo_TRAEnvelope(value);
                    
            {
                this.Envelope = conversion_result;
            }
            
                }
                break;
                
                case 2:
                {
                    string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                    
            {
                if (conversion_result != default(string))
                    this.EncryptedAccountCore = conversion_result;
                else
                    this.Remove_EncryptedAccountCore();
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
                
                return this.Contains_EncryptedAccountCore;
                
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
                
                case 2:
                
                {
                    
                    if (!this.Contains_EncryptedAccountCore)
                        this.EncryptedAccountCore = "";
                    
                    this.EncryptedAccountCore += TypeConverter<T>.ConvertTo_string(value);
                }
                
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
                
                case 0:
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.EncryptedAccountCore, attributeKey, attributeValue))
                    
                    if (Contains_EncryptedAccountCore)
                        
                        yield return new KeyValuePair<string, T>("EncryptedAccountCore", TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore));
                
                break;
                
                case 1:
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.EncryptedAccountCore, attributeKey, attributeValue))
                    
                    if (Contains_EncryptedAccountCore)
                        
                        yield return new KeyValuePair<string, T>("EncryptedAccountCore", TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore));
                
                break;
                
                case 2:
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.AccountCore, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("AccountCore", TypeConverter<T>.ConvertFrom_TDWVDAAccountEntryCore(this.AccountCore));
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.Envelope, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("Envelope", TypeConverter<T>.ConvertFrom_TRAEnvelope(this.Envelope));
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.EncryptedAccountCore, attributeKey, attributeValue))
                    
                    if (Contains_EncryptedAccountCore)
                        
                        yield return new KeyValuePair<string, T>("EncryptedAccountCore", TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore));
                
                break;
                
                case 3:
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.AccountCore, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("AccountCore", TypeConverter<T>.ConvertFrom_TDWVDAAccountEntryCore(this.AccountCore));
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.Envelope, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("Envelope", TypeConverter<T>.ConvertFrom_TRAEnvelope(this.Envelope));
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.EncryptedAccountCore, attributeKey, attributeValue))
                    
                    if (Contains_EncryptedAccountCore)
                        
                        yield return new KeyValuePair<string, T>("EncryptedAccountCore", TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore));
                
                break;
                
                case 4:
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.AccountCore, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("AccountCore", TypeConverter<T>.ConvertFrom_TDWVDAAccountEntryCore(this.AccountCore));
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.EncryptedAccountCore, attributeKey, attributeValue))
                    
                    if (Contains_EncryptedAccountCore)
                        
                        yield return new KeyValuePair<string, T>("EncryptedAccountCore", TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore));
                
                break;
                
                case 5:
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.EncryptedAccountCore, attributeKey, attributeValue))
                    
                    if (Contains_EncryptedAccountCore)
                        
                        yield return new KeyValuePair<string, T>("EncryptedAccountCore", TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore));
                
                break;
                
                case 6:
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.EncryptedAccountCore, attributeKey, attributeValue))
                    
                    if (Contains_EncryptedAccountCore)
                        
                        yield return new KeyValuePair<string, T>("EncryptedAccountCore", TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore));
                
                break;
                
                case 7:
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.EncryptedAccountCore, attributeKey, attributeValue))
                    
                    if (Contains_EncryptedAccountCore)
                        
                        yield return new KeyValuePair<string, T>("EncryptedAccountCore", TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore));
                
                break;
                
                case 8:
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.EncryptedAccountCore, attributeKey, attributeValue))
                    
                    if (Contains_EncryptedAccountCore)
                        
                        yield return new KeyValuePair<string, T>("EncryptedAccountCore", TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore));
                
                break;
                
                case 9:
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.EncryptedAccountCore, attributeKey, attributeValue))
                    
                    if (Contains_EncryptedAccountCore)
                        
                        yield return new KeyValuePair<string, T>("EncryptedAccountCore", TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore));
                
                break;
                
                case 10:
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.Envelope, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("Envelope", TypeConverter<T>.ConvertFrom_TRAEnvelope(this.Envelope));
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.EncryptedAccountCore, attributeKey, attributeValue))
                    
                    if (Contains_EncryptedAccountCore)
                        
                        yield return new KeyValuePair<string, T>("EncryptedAccountCore", TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore));
                
                break;
                
                case 11:
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.EncryptedAccountCore, attributeKey, attributeValue))
                    
                    if (Contains_EncryptedAccountCore)
                        
                        yield return new KeyValuePair<string, T>("EncryptedAccountCore", TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore));
                
                break;
                
                case 12:
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.EncryptedAccountCore, attributeKey, attributeValue))
                    
                    if (Contains_EncryptedAccountCore)
                        
                        yield return new KeyValuePair<string, T>("EncryptedAccountCore", TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore));
                
                break;
                
                case 13:
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.EncryptedAccountCore, attributeKey, attributeValue))
                    
                    if (Contains_EncryptedAccountCore)
                        
                        yield return new KeyValuePair<string, T>("EncryptedAccountCore", TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore));
                
                break;
                
                case 14:
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.EncryptedAccountCore, attributeKey, attributeValue))
                    
                    if (Contains_EncryptedAccountCore)
                        
                        yield return new KeyValuePair<string, T>("EncryptedAccountCore", TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore));
                
                break;
                
                case 15:
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.AccountCore, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("AccountCore", TypeConverter<T>.ConvertFrom_TDWVDAAccountEntryCore(this.AccountCore));
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.Envelope, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("Envelope", TypeConverter<T>.ConvertFrom_TRAEnvelope(this.Envelope));
                
                if (StorageSchema.TDWVDAAccount_descriptor.check_attribute(StorageSchema.TDWVDAAccount_descriptor.EncryptedAccountCore, attributeKey, attributeValue))
                    
                    if (Contains_EncryptedAccountCore)
                        
                        yield return new KeyValuePair<string, T>("EncryptedAccountCore", TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore));
                
                break;
                
                default:
                Throw.incompatible_with_cell();
                break;
            }
            yield break;
        }
        #region enumerate value methods
        
        private IEnumerable<T> _enumerate_from_AccountCore<T>()
        {
            
            switch (TypeConverter<T>.type_id)
            {
                
                case 2:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_TDWVDAAccountEntryCore(this.AccountCore);
                        
                    }
                    break;
                
                case 3:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_TDWVDAAccountEntryCore(this.AccountCore);
                        
                    }
                    break;
                
                case 4:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_TDWVDAAccountEntryCore(this.AccountCore);
                        
                    }
                    break;
                
                case 15:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_TDWVDAAccountEntryCore(this.AccountCore);
                        
                    }
                    break;
                
                default:
                    Throw.incompatible_with_cell();
                    break;
            }
            yield break;
            
        }
        
        private IEnumerable<T> _enumerate_from_Envelope<T>()
        {
            
            switch (TypeConverter<T>.type_id)
            {
                
                case 2:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_TRAEnvelope(this.Envelope);
                        
                    }
                    break;
                
                case 3:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_TRAEnvelope(this.Envelope);
                        
                    }
                    break;
                
                case 10:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_TRAEnvelope(this.Envelope);
                        
                    }
                    break;
                
                case 15:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_TRAEnvelope(this.Envelope);
                        
                    }
                    break;
                
                default:
                    Throw.incompatible_with_cell();
                    break;
            }
            yield break;
            
        }
        
        private IEnumerable<T> _enumerate_from_EncryptedAccountCore<T>()
        {
            
            if (this.Contains_EncryptedAccountCore)
                
            switch (TypeConverter<T>.type_id)
            {
                
                case 0:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore);
                        
                    }
                    break;
                
                case 1:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore);
                        
                    }
                    break;
                
                case 2:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore);
                        
                    }
                    break;
                
                case 3:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore);
                        
                    }
                    break;
                
                case 4:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore);
                        
                    }
                    break;
                
                case 5:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore);
                        
                    }
                    break;
                
                case 6:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore);
                        
                    }
                    break;
                
                case 7:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore);
                        
                    }
                    break;
                
                case 8:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore);
                        
                    }
                    break;
                
                case 9:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore);
                        
                    }
                    break;
                
                case 10:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore);
                        
                    }
                    break;
                
                case 11:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore);
                        
                    }
                    break;
                
                case 12:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore);
                        
                    }
                    break;
                
                case 13:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore);
                        
                    }
                    break;
                
                case 14:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore);
                        
                    }
                    break;
                
                case 15:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.EncryptedAccountCore);
                        
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
                return _enumerate_from_AccountCore<T>();
                
                case 1:
                return _enumerate_from_Envelope<T>();
                
                case 2:
                return _enumerate_from_EncryptedAccountCore<T>();
                
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
                
                foreach (var val in _enumerate_from_AccountCore<T>())
                    yield return val;
                
                foreach (var val in _enumerate_from_Envelope<T>())
                    yield return val;
                
                foreach (var val in _enumerate_from_EncryptedAccountCore<T>())
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
                yield return "AccountCore";
            }
            
            {
                yield return "Envelope";
            }
            
            {
                if (Contains_EncryptedAccountCore)
                    yield return "EncryptedAccountCore";
            }
            
        }
        IAttributeCollection ICellDescriptor.GetFieldAttributes(string fieldName)
        {
            return StorageSchema.TDWVDAAccount.GetFieldAttributes(fieldName);
        }
        IEnumerable<IFieldDescriptor> ICellDescriptor.GetFieldDescriptors()
        {
            return StorageSchema.TDWVDAAccount.GetFieldDescriptors();
        }
        string ITypeDescriptor.TypeName
        {
            get { return StorageSchema.s_cellTypeName_TDWVDAAccount; }
        }
        Type ITypeDescriptor.Type
        {
            get { return StorageSchema.s_cellType_TDWVDAAccount; }
        }
        bool ITypeDescriptor.IsOfType<T>()
        {
            return typeof(T) == StorageSchema.s_cellType_TDWVDAAccount;
        }
        bool ITypeDescriptor.IsList()
        {
            return false;
        }
        IReadOnlyDictionary<string, string> IAttributeCollection.Attributes
        {
            get { return StorageSchema.TDWVDAAccount.Attributes; }
        }
        string IAttributeCollection.GetAttributeValue(string attributeKey)
        {
            return StorageSchema.TDWVDAAccount.GetAttributeValue(attributeKey);
        }
        ushort ICellDescriptor.CellType
        {
            get
            {
                return (ushort)CellType.TDWVDAAccount;
            }
        }
        public ICellAccessor Serialize()
        {
            return this;
        }
        #endregion
        public ICell Deserialize()
        {
            return (TDWVDAAccount)this;
        }
    }
    ///<summary>
    ///Provides interfaces for accessing TDWVDAAccount cells
    ///on <see cref="Trinity.Storage.LocalMemorySotrage"/>.
    static public class StorageExtension_TDWVDAAccount
    {
        #region IKeyValueStore non logging
        /// <summary>
        /// Adds a new cell of type TDWVDAAccount to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. The value of the cell is specified in the method parameters.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.IKeyValueStore"/> instance.</param>
        /// <param name="cellId">A 64-bit cell Id.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveTDWVDAAccount(this IKeyValueStore storage, long cellId, TDWVDAAccountEntryCore AccountCore = default(TDWVDAAccountEntryCore), TRAEnvelope Envelope = default(TRAEnvelope), string EncryptedAccountCore = default(string))
        {
            
            byte* targetPtr;
            
            targetPtr = null;
            
            {
            targetPtr += 1;

            {
            targetPtr += 8;

        if(AccountCore.udid!= null)
        {
            int strlen_3 = AccountCore.udid.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(AccountCore.walletname!= null)
        {
            int strlen_3 = AccountCore.walletname.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(AccountCore.walletpassword!= null)
        {
            int strlen_3 = AccountCore.walletpassword.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(AccountCore.walletaccountname!= null)
        {
            int strlen_3 = AccountCore.walletaccountname.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(AccountCore.ledgeraddress!= null)
        {
            int strlen_3 = AccountCore.ledgeraddress.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            {
            targetPtr += 1;
            targetPtr += 1;
            targetPtr += 1;
            if( Envelope.hashedThumbprint64!= null)
            {

        if(Envelope.hashedThumbprint64!= null)
        {
            int strlen_3 = Envelope.hashedThumbprint64.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( Envelope.signedHashSignature64!= null)
            {

        if(Envelope.signedHashSignature64!= null)
        {
            int strlen_3 = Envelope.signedHashSignature64.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( Envelope.notaryStamp!= null)
            {

        if(Envelope.notaryStamp!= null)
        {
            int strlen_3 = Envelope.notaryStamp.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( Envelope.comments!= null)
            {

{

    targetPtr += sizeof(int);
    if(Envelope.comments!= null)
    {
        for(int iterator_3 = 0;iterator_3<Envelope.comments.Count;++iterator_3)
        {

        if(Envelope.comments[iterator_3]!= null)
        {
            int strlen_4 = Envelope.comments[iterator_3].Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        }
    }

}

            }

            }            if( EncryptedAccountCore!= null)
            {

        if(EncryptedAccountCore!= null)
        {
            int strlen_2 = EncryptedAccountCore.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

            }
            byte[] tmpcell = new byte[(int)(targetPtr)];
            fixed (byte* _tmpcellptr = tmpcell)
            {
                targetPtr = _tmpcellptr;
                
            {
            byte* optheader_1 = targetPtr;
            *(optheader_1 + 0) = 0x00;            targetPtr += 1;

            {
            *(long*)targetPtr = AccountCore.id;
            targetPtr += 8;

        if(AccountCore.udid!= null)
        {
            int strlen_3 = AccountCore.udid.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = AccountCore.udid)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(AccountCore.walletname!= null)
        {
            int strlen_3 = AccountCore.walletname.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = AccountCore.walletname)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(AccountCore.walletpassword!= null)
        {
            int strlen_3 = AccountCore.walletpassword.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = AccountCore.walletpassword)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(AccountCore.walletaccountname!= null)
        {
            int strlen_3 = AccountCore.walletaccountname.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = AccountCore.walletaccountname)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(AccountCore.ledgeraddress!= null)
        {
            int strlen_3 = AccountCore.ledgeraddress.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = AccountCore.ledgeraddress)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
            {
            byte* optheader_2 = targetPtr;
            *(optheader_2 + 0) = 0x00;            targetPtr += 1;
            *(TRACredentialType*)targetPtr = Envelope.credtype;
            targetPtr += 1;
            *(TRAEncryptionFlag*)targetPtr = Envelope.encryptionFlag;
            targetPtr += 1;
            if( Envelope.hashedThumbprint64!= null)
            {

        if(Envelope.hashedThumbprint64!= null)
        {
            int strlen_3 = Envelope.hashedThumbprint64.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = Envelope.hashedThumbprint64)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_2 + 0) |= 0x01;
            }
            if( Envelope.signedHashSignature64!= null)
            {

        if(Envelope.signedHashSignature64!= null)
        {
            int strlen_3 = Envelope.signedHashSignature64.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = Envelope.signedHashSignature64)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_2 + 0) |= 0x02;
            }
            if( Envelope.notaryStamp!= null)
            {

        if(Envelope.notaryStamp!= null)
        {
            int strlen_3 = Envelope.notaryStamp.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = Envelope.notaryStamp)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_2 + 0) |= 0x04;
            }
            if( Envelope.comments!= null)
            {

{
byte *storedPtr_3 = targetPtr;

    targetPtr += sizeof(int);
    if(Envelope.comments!= null)
    {
        for(int iterator_3 = 0;iterator_3<Envelope.comments.Count;++iterator_3)
        {

        if(Envelope.comments[iterator_3]!= null)
        {
            int strlen_4 = Envelope.comments[iterator_3].Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = Envelope.comments[iterator_3])
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        }
    }
*(int*)storedPtr_3 = (int)(targetPtr - storedPtr_3 - 4);

}
*(optheader_2 + 0) |= 0x08;
            }

            }            if( EncryptedAccountCore!= null)
            {

        if(EncryptedAccountCore!= null)
        {
            int strlen_2 = EncryptedAccountCore.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = EncryptedAccountCore)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_1 + 0) |= 0x01;
            }

            }
            }
            
            return storage.SaveCell(cellId, tmpcell, (ushort)CellType.TDWVDAAccount) == TrinityErrorCode.E_SUCCESS;
        }
        /// <summary>
        /// Adds a new cell of type TDWVDAAccount to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. The parameter <paramref name="cellId"/> overrides the cell id in the content object.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.IKeyValueStore"/> instance.</param>
        /// <param name="cellId">A 64-bit cell Id.</param>
        /// <param name="cellContent">The content of the cell.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveTDWVDAAccount(this IKeyValueStore storage, long cellId, TDWVDAAccount cellContent)
        {
            return SaveTDWVDAAccount(storage, cellId  , cellContent.AccountCore  , cellContent.Envelope  , cellContent.EncryptedAccountCore );
        }
        /// <summary>
        /// Adds a new cell of type TDWVDAAccount to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. Cell Id is specified by the CellId field in the content object.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.IKeyValueStore"/> instance.</param>
        /// <param name="cellContent">The content of the cell.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveTDWVDAAccount(this IKeyValueStore storage, TDWVDAAccount cellContent)
        {
            return SaveTDWVDAAccount(storage, cellContent.CellId  , cellContent.AccountCore  , cellContent.Envelope  , cellContent.EncryptedAccountCore );
        }
        /// <summary>
        /// Loads the content of the specified cell. Any changes done to this object are not written to the store, unless
        /// the content object is saved back into the storage.
        /// <param name="storage"/>A <see cref="Trinity.Storage.IKeyValueStore"/> instance.</param>
        /// </summary>
        public unsafe static TDWVDAAccount LoadTDWVDAAccount(this IKeyValueStore storage, long cellId)
        {
            if (TrinityErrorCode.E_SUCCESS == storage.LoadCell(cellId, out var buff))
            {
                fixed (byte* p = buff)
                {
                    return TDWVDAAccount_Accessor._get()._Setup(cellId, p, -1, 0);
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
        /// the cell as a TDWVDAAccount. Any changes done to the accessor
        /// are written to the storage immediately.
        /// If <c><see cref="Trinity.TrinityConfig.ReadOnly"/> == false</c>,
        /// on calling this method, it attempts to acquire the lock of the cell,
        /// and blocks until it gets the lock. Otherwise this method is wait-free.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">The id of the specified cell.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <returns>A <see cref="TDW.VDAServer.TDWVDAAccount"/> instance.</returns>
        public unsafe static TDWVDAAccount_Accessor UseTDWVDAAccount(this Trinity.Storage.LocalMemoryStorage storage, long cellId, CellAccessOptions options)
        {
            return TDWVDAAccount_Accessor._get()._Lock(cellId, options);
        }
        /// <summary>
        /// Allocate a cell accessor on the specified cell, which interprets
        /// the cell as a TDWVDAAccount. Any changes done to the accessor
        /// are written to the storage immediately.
        /// If <c><see cref="Trinity.TrinityConfig.ReadOnly"/> == false</c>,
        /// on calling this method, it attempts to acquire the lock of the cell,
        /// and blocks until it gets the lock.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">The id of the specified cell.</param>
        /// <returns>A <see cref="" + script.RootNamespace + ".TDWVDAAccount"/> instance.</returns>
        public unsafe static TDWVDAAccount_Accessor UseTDWVDAAccount(this Trinity.Storage.LocalMemoryStorage storage, long cellId)
        {
            return TDWVDAAccount_Accessor._get()._Lock(cellId, CellAccessOptions.ThrowExceptionOnCellNotFound);
        }
        #endregion
        #region LocalStorage Non-Tx logging
        /// <summary>
        /// Adds a new cell of type TDWVDAAccount to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. The value of the cell is specified in the method parameters.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">A 64-bit cell Id.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveTDWVDAAccount(this Trinity.Storage.LocalMemoryStorage storage, CellAccessOptions options, long cellId, TDWVDAAccountEntryCore AccountCore = default(TDWVDAAccountEntryCore), TRAEnvelope Envelope = default(TRAEnvelope), string EncryptedAccountCore = default(string))
        {
            
            byte* targetPtr;
            
            targetPtr = null;
            
            {
            targetPtr += 1;

            {
            targetPtr += 8;

        if(AccountCore.udid!= null)
        {
            int strlen_3 = AccountCore.udid.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(AccountCore.walletname!= null)
        {
            int strlen_3 = AccountCore.walletname.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(AccountCore.walletpassword!= null)
        {
            int strlen_3 = AccountCore.walletpassword.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(AccountCore.walletaccountname!= null)
        {
            int strlen_3 = AccountCore.walletaccountname.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(AccountCore.ledgeraddress!= null)
        {
            int strlen_3 = AccountCore.ledgeraddress.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            {
            targetPtr += 1;
            targetPtr += 1;
            targetPtr += 1;
            if( Envelope.hashedThumbprint64!= null)
            {

        if(Envelope.hashedThumbprint64!= null)
        {
            int strlen_3 = Envelope.hashedThumbprint64.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( Envelope.signedHashSignature64!= null)
            {

        if(Envelope.signedHashSignature64!= null)
        {
            int strlen_3 = Envelope.signedHashSignature64.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( Envelope.notaryStamp!= null)
            {

        if(Envelope.notaryStamp!= null)
        {
            int strlen_3 = Envelope.notaryStamp.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( Envelope.comments!= null)
            {

{

    targetPtr += sizeof(int);
    if(Envelope.comments!= null)
    {
        for(int iterator_3 = 0;iterator_3<Envelope.comments.Count;++iterator_3)
        {

        if(Envelope.comments[iterator_3]!= null)
        {
            int strlen_4 = Envelope.comments[iterator_3].Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        }
    }

}

            }

            }            if( EncryptedAccountCore!= null)
            {

        if(EncryptedAccountCore!= null)
        {
            int strlen_2 = EncryptedAccountCore.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

            }
            byte[] tmpcell = new byte[(int)(targetPtr)];
            fixed (byte* _tmpcellptr = tmpcell)
            {
                targetPtr = _tmpcellptr;
                
            {
            byte* optheader_1 = targetPtr;
            *(optheader_1 + 0) = 0x00;            targetPtr += 1;

            {
            *(long*)targetPtr = AccountCore.id;
            targetPtr += 8;

        if(AccountCore.udid!= null)
        {
            int strlen_3 = AccountCore.udid.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = AccountCore.udid)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(AccountCore.walletname!= null)
        {
            int strlen_3 = AccountCore.walletname.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = AccountCore.walletname)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(AccountCore.walletpassword!= null)
        {
            int strlen_3 = AccountCore.walletpassword.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = AccountCore.walletpassword)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(AccountCore.walletaccountname!= null)
        {
            int strlen_3 = AccountCore.walletaccountname.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = AccountCore.walletaccountname)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(AccountCore.ledgeraddress!= null)
        {
            int strlen_3 = AccountCore.ledgeraddress.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = AccountCore.ledgeraddress)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
            {
            byte* optheader_2 = targetPtr;
            *(optheader_2 + 0) = 0x00;            targetPtr += 1;
            *(TRACredentialType*)targetPtr = Envelope.credtype;
            targetPtr += 1;
            *(TRAEncryptionFlag*)targetPtr = Envelope.encryptionFlag;
            targetPtr += 1;
            if( Envelope.hashedThumbprint64!= null)
            {

        if(Envelope.hashedThumbprint64!= null)
        {
            int strlen_3 = Envelope.hashedThumbprint64.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = Envelope.hashedThumbprint64)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_2 + 0) |= 0x01;
            }
            if( Envelope.signedHashSignature64!= null)
            {

        if(Envelope.signedHashSignature64!= null)
        {
            int strlen_3 = Envelope.signedHashSignature64.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = Envelope.signedHashSignature64)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_2 + 0) |= 0x02;
            }
            if( Envelope.notaryStamp!= null)
            {

        if(Envelope.notaryStamp!= null)
        {
            int strlen_3 = Envelope.notaryStamp.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = Envelope.notaryStamp)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_2 + 0) |= 0x04;
            }
            if( Envelope.comments!= null)
            {

{
byte *storedPtr_3 = targetPtr;

    targetPtr += sizeof(int);
    if(Envelope.comments!= null)
    {
        for(int iterator_3 = 0;iterator_3<Envelope.comments.Count;++iterator_3)
        {

        if(Envelope.comments[iterator_3]!= null)
        {
            int strlen_4 = Envelope.comments[iterator_3].Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = Envelope.comments[iterator_3])
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        }
    }
*(int*)storedPtr_3 = (int)(targetPtr - storedPtr_3 - 4);

}
*(optheader_2 + 0) |= 0x08;
            }

            }            if( EncryptedAccountCore!= null)
            {

        if(EncryptedAccountCore!= null)
        {
            int strlen_2 = EncryptedAccountCore.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = EncryptedAccountCore)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_1 + 0) |= 0x01;
            }

            }
            }
            
            return storage.SaveCell(options, cellId, tmpcell, 0, tmpcell.Length, (ushort)CellType.TDWVDAAccount) == TrinityErrorCode.E_SUCCESS;
        }
        /// <summary>
        /// Adds a new cell of type TDWVDAAccount to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. The parameter <paramref name="cellId"/> overrides the cell id in the content object.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">A 64-bit cell Id.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <param name="cellContent">The content of the cell.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveTDWVDAAccount(this Trinity.Storage.LocalMemoryStorage storage, CellAccessOptions options, long cellId, TDWVDAAccount cellContent)
        {
            return SaveTDWVDAAccount(storage, options, cellId  , cellContent.AccountCore  , cellContent.Envelope  , cellContent.EncryptedAccountCore );
        }
        /// <summary>
        /// Adds a new cell of type TDWVDAAccount to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. Cell Id is specified by the CellId field in the content object.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <param name="cellContent">The content of the cell.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveTDWVDAAccount(this Trinity.Storage.LocalMemoryStorage storage, CellAccessOptions options, TDWVDAAccount cellContent)
        {
            return SaveTDWVDAAccount(storage, options, cellContent.CellId  , cellContent.AccountCore  , cellContent.Envelope  , cellContent.EncryptedAccountCore );
        }
        /// <summary>
        /// Loads the content of the specified cell. Any changes done to this object are not written to the store, unless
        /// the content object is saved back into the storage.
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// </summary>
        public unsafe static TDWVDAAccount LoadTDWVDAAccount(this Trinity.Storage.LocalMemoryStorage storage, long cellId)
        {
            using (var cell = TDWVDAAccount_Accessor._get()._Lock(cellId, CellAccessOptions.ThrowExceptionOnCellNotFound))
            {
                return cell;
            }
        }
        #endregion
        #region LocalMemoryStorage Tx accessors
        /// <summary>
        /// Allocate a cell accessor on the specified cell, which interprets
        /// the cell as a TDWVDAAccount. Any changes done to the accessor
        /// are written to the storage immediately.
        /// If <c><see cref="Trinity.TrinityConfig.ReadOnly"/> == false</c>,
        /// on calling this method, it attempts to acquire the lock of the cell,
        /// and blocks until it gets the lock. Otherwise this method is wait-free.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">The id of the specified cell.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <returns>A <see cref="TDW.VDAServer.TDWVDAAccount"/> instance.</returns>
        public unsafe static TDWVDAAccount_Accessor UseTDWVDAAccount(this Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx, long cellId, CellAccessOptions options)
        {
            return TDWVDAAccount_Accessor._get()._Lock(cellId, options, tx);
        }
        /// <summary>
        /// Allocate a cell accessor on the specified cell, which interprets
        /// the cell as a TDWVDAAccount. Any changes done to the accessor
        /// are written to the storage immediately.
        /// If <c><see cref="Trinity.TrinityConfig.ReadOnly"/> == false</c>,
        /// on calling this method, it attempts to acquire the lock of the cell,
        /// and blocks until it gets the lock.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">The id of the specified cell.</param>
        /// <returns>A <see cref="" + script.RootNamespace + ".TDWVDAAccount"/> instance.</returns>
        public unsafe static TDWVDAAccount_Accessor UseTDWVDAAccount(this Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx, long cellId)
        {
            return TDWVDAAccount_Accessor._get()._Lock(cellId, CellAccessOptions.ThrowExceptionOnCellNotFound, tx);
        }
        #endregion
        #region LocalStorage Tx logging
        /// <summary>
        /// Adds a new cell of type TDWVDAAccount to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. The value of the cell is specified in the method parameters.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">A 64-bit cell Id.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveTDWVDAAccount(this Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx, CellAccessOptions options, long cellId, TDWVDAAccountEntryCore AccountCore = default(TDWVDAAccountEntryCore), TRAEnvelope Envelope = default(TRAEnvelope), string EncryptedAccountCore = default(string))
        {
            
            byte* targetPtr;
            
            targetPtr = null;
            
            {
            targetPtr += 1;

            {
            targetPtr += 8;

        if(AccountCore.udid!= null)
        {
            int strlen_3 = AccountCore.udid.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(AccountCore.walletname!= null)
        {
            int strlen_3 = AccountCore.walletname.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(AccountCore.walletpassword!= null)
        {
            int strlen_3 = AccountCore.walletpassword.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(AccountCore.walletaccountname!= null)
        {
            int strlen_3 = AccountCore.walletaccountname.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(AccountCore.ledgeraddress!= null)
        {
            int strlen_3 = AccountCore.ledgeraddress.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            {
            targetPtr += 1;
            targetPtr += 1;
            targetPtr += 1;
            if( Envelope.hashedThumbprint64!= null)
            {

        if(Envelope.hashedThumbprint64!= null)
        {
            int strlen_3 = Envelope.hashedThumbprint64.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( Envelope.signedHashSignature64!= null)
            {

        if(Envelope.signedHashSignature64!= null)
        {
            int strlen_3 = Envelope.signedHashSignature64.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( Envelope.notaryStamp!= null)
            {

        if(Envelope.notaryStamp!= null)
        {
            int strlen_3 = Envelope.notaryStamp.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( Envelope.comments!= null)
            {

{

    targetPtr += sizeof(int);
    if(Envelope.comments!= null)
    {
        for(int iterator_3 = 0;iterator_3<Envelope.comments.Count;++iterator_3)
        {

        if(Envelope.comments[iterator_3]!= null)
        {
            int strlen_4 = Envelope.comments[iterator_3].Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        }
    }

}

            }

            }            if( EncryptedAccountCore!= null)
            {

        if(EncryptedAccountCore!= null)
        {
            int strlen_2 = EncryptedAccountCore.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

            }
            byte[] tmpcell = new byte[(int)(targetPtr)];
            fixed (byte* _tmpcellptr = tmpcell)
            {
                targetPtr = _tmpcellptr;
                
            {
            byte* optheader_1 = targetPtr;
            *(optheader_1 + 0) = 0x00;            targetPtr += 1;

            {
            *(long*)targetPtr = AccountCore.id;
            targetPtr += 8;

        if(AccountCore.udid!= null)
        {
            int strlen_3 = AccountCore.udid.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = AccountCore.udid)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(AccountCore.walletname!= null)
        {
            int strlen_3 = AccountCore.walletname.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = AccountCore.walletname)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(AccountCore.walletpassword!= null)
        {
            int strlen_3 = AccountCore.walletpassword.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = AccountCore.walletpassword)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(AccountCore.walletaccountname!= null)
        {
            int strlen_3 = AccountCore.walletaccountname.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = AccountCore.walletaccountname)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(AccountCore.ledgeraddress!= null)
        {
            int strlen_3 = AccountCore.ledgeraddress.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = AccountCore.ledgeraddress)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
            {
            byte* optheader_2 = targetPtr;
            *(optheader_2 + 0) = 0x00;            targetPtr += 1;
            *(TRACredentialType*)targetPtr = Envelope.credtype;
            targetPtr += 1;
            *(TRAEncryptionFlag*)targetPtr = Envelope.encryptionFlag;
            targetPtr += 1;
            if( Envelope.hashedThumbprint64!= null)
            {

        if(Envelope.hashedThumbprint64!= null)
        {
            int strlen_3 = Envelope.hashedThumbprint64.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = Envelope.hashedThumbprint64)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_2 + 0) |= 0x01;
            }
            if( Envelope.signedHashSignature64!= null)
            {

        if(Envelope.signedHashSignature64!= null)
        {
            int strlen_3 = Envelope.signedHashSignature64.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = Envelope.signedHashSignature64)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_2 + 0) |= 0x02;
            }
            if( Envelope.notaryStamp!= null)
            {

        if(Envelope.notaryStamp!= null)
        {
            int strlen_3 = Envelope.notaryStamp.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = Envelope.notaryStamp)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_2 + 0) |= 0x04;
            }
            if( Envelope.comments!= null)
            {

{
byte *storedPtr_3 = targetPtr;

    targetPtr += sizeof(int);
    if(Envelope.comments!= null)
    {
        for(int iterator_3 = 0;iterator_3<Envelope.comments.Count;++iterator_3)
        {

        if(Envelope.comments[iterator_3]!= null)
        {
            int strlen_4 = Envelope.comments[iterator_3].Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = Envelope.comments[iterator_3])
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        }
    }
*(int*)storedPtr_3 = (int)(targetPtr - storedPtr_3 - 4);

}
*(optheader_2 + 0) |= 0x08;
            }

            }            if( EncryptedAccountCore!= null)
            {

        if(EncryptedAccountCore!= null)
        {
            int strlen_2 = EncryptedAccountCore.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = EncryptedAccountCore)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_1 + 0) |= 0x01;
            }

            }
            }
            
            return storage.SaveCell(tx, options, cellId, tmpcell, 0, tmpcell.Length, (ushort)CellType.TDWVDAAccount) == TrinityErrorCode.E_SUCCESS;
        }
        /// <summary>
        /// Adds a new cell of type TDWVDAAccount to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. The parameter <paramref name="cellId"/> overrides the cell id in the content object.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">A 64-bit cell Id.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <param name="cellContent">The content of the cell.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveTDWVDAAccount(this Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx, CellAccessOptions options, long cellId, TDWVDAAccount cellContent)
        {
            return SaveTDWVDAAccount(storage, tx, options, cellId  , cellContent.AccountCore  , cellContent.Envelope  , cellContent.EncryptedAccountCore );
        }
        /// <summary>
        /// Adds a new cell of type TDWVDAAccount to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. Cell Id is specified by the CellId field in the content object.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <param name="cellContent">The content of the cell.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveTDWVDAAccount(this Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx, CellAccessOptions options, TDWVDAAccount cellContent)
        {
            return SaveTDWVDAAccount(storage, tx, options, cellContent.CellId  , cellContent.AccountCore  , cellContent.Envelope  , cellContent.EncryptedAccountCore );
        }
        /// <summary>
        /// Loads the content of the specified cell. Any changes done to this object are not written to the store, unless
        /// the content object is saved back into the storage.
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// </summary>
        public unsafe static TDWVDAAccount LoadTDWVDAAccount(this Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx, long cellId)
        {
            using (var cell = TDWVDAAccount_Accessor._get()._Lock(cellId, CellAccessOptions.ThrowExceptionOnCellNotFound, tx))
            {
                return cell;
            }
        }
        #endregion
    }
}

#pragma warning restore 162,168,649,660,661,1522
