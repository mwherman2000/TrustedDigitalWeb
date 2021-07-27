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
namespace TDW.TRAServer
{
    
    /// <summary>
    /// A .NET runtime object representation of Cac_PaymentMeans_Cell defined in TSL.
    /// </summary>
    public partial struct Cac_PaymentMeans_Cell : ICell
    {
        ///<summary>
        ///The id of the cell.
        ///</summary>
        public long CellId;
        ///<summary>
        ///Initializes a new instance of Cac_PaymentMeans_Cell with the specified parameters.
        ///</summary>
        public Cac_PaymentMeans_Cell(long cell_id , Cac_PaymentMeans_Envelope envelope = default(Cac_PaymentMeans_Envelope), TRACredential_EnvelopeSeal envelopeseal = default(TRACredential_EnvelopeSeal))
        {
            
            this.envelope = envelope;
            
            this.envelopeseal = envelopeseal;
            
            CellId = cell_id;
        }
        
        ///<summary>
        ///Initializes a new instance of Cac_PaymentMeans_Cell with the specified parameters.
        ///</summary>
        public Cac_PaymentMeans_Cell( Cac_PaymentMeans_Envelope envelope = default(Cac_PaymentMeans_Envelope), TRACredential_EnvelopeSeal envelopeseal = default(TRACredential_EnvelopeSeal))
        {
            
            this.envelope = envelope;
            
            this.envelopeseal = envelopeseal;
            
            CellId = CellIdFactory.NewCellId();
        }
        
        public Cac_PaymentMeans_Envelope envelope;
        
        public TRACredential_EnvelopeSeal envelopeseal;
        
        public static bool operator ==(Cac_PaymentMeans_Cell a, Cac_PaymentMeans_Cell b)
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
                
                (a.envelope == b.envelope)
                &&
                (a.envelopeseal == b.envelopeseal)
                
                ;
            
        }
        public static bool operator !=(Cac_PaymentMeans_Cell a, Cac_PaymentMeans_Cell b)
        {
            return !(a == b);
        }
        #region Text processing
        /// <summary>
        /// Converts the string representation of a Cac_PaymentMeans_Cell to its
        /// struct equivalent. A return value indicates whether the 
        /// operation succeeded.
        /// </summary>
        /// <param name="input">A string to convert.</param>
        /// <param name="value">
        /// When this method returns, contains the struct equivalent of the value contained 
        /// in input, if the conversion succeeded, or default(Cac_PaymentMeans_Cell) if the conversion
        /// failed. The conversion fails if the input parameter is null or String.Empty, or is 
        /// not of the correct format. This parameter is passed uninitialized.
        /// </param>
        /// <returns>
        /// True if input was converted successfully; otherwise, false.
        /// </returns>
        public static bool TryParse(string input, out Cac_PaymentMeans_Cell value)
        {
            try
            {
                value = Newtonsoft.Json.JsonConvert.DeserializeObject<Cac_PaymentMeans_Cell>(input);
                return true;
            }
            catch { value = default(Cac_PaymentMeans_Cell); return false; }
        }
        public static Cac_PaymentMeans_Cell Parse(string input)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Cac_PaymentMeans_Cell>(input);
        }
        ///<summary>Converts a Cac_PaymentMeans_Cell to its string representation, in JSON format.</summary>
        ///<returns>A string representation of the Cac_PaymentMeans_Cell.</returns>
        public override string ToString()
        {
            return Serializer.ToString(this);
        }
        #endregion
        #region Lookup tables
        internal static StringLookupTable FieldLookupTable = new StringLookupTable(
            
            "envelope"
            ,
            "envelopeseal"
            
            );
        internal static HashSet<string> AppendToFieldRerouteSet = new HashSet<string>()
        {
            
            "envelope"
            ,
            "envelopeseal"
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
                return TypeConverter<T>.ConvertFrom_Cac_PaymentMeans_Envelope(this.envelope);
                
                case 1:
                return TypeConverter<T>.ConvertFrom_TRACredential_EnvelopeSeal(this.envelopeseal);
                
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
                this.envelope = TypeConverter<T>.ConvertTo_Cac_PaymentMeans_Envelope(value);
                break;
                
                case 1:
                this.envelopeseal = TypeConverter<T>.ConvertTo_TRACredential_EnvelopeSeal(value);
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
                
                default:
                return false;
            }
        }
        /// <summary>
        /// Append <paramref name="value"/> to the target field. Note that if the target field
        /// is not appendable(string or list), calling this method is equivalent to <see cref="TDW.TRAServer.GenericCellAccessor.SetField(string, T)"/>.
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
                
                case 4:
                
                if (StorageSchema.Cac_PaymentMeans_Cell_descriptor.check_attribute(StorageSchema.Cac_PaymentMeans_Cell_descriptor.envelope, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("envelope", TypeConverter<T>.ConvertFrom_Cac_PaymentMeans_Envelope(this.envelope));
                
                if (StorageSchema.Cac_PaymentMeans_Cell_descriptor.check_attribute(StorageSchema.Cac_PaymentMeans_Cell_descriptor.envelopeseal, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("envelopeseal", TypeConverter<T>.ConvertFrom_TRACredential_EnvelopeSeal(this.envelopeseal));
                
                break;
                
                case 5:
                
                if (StorageSchema.Cac_PaymentMeans_Cell_descriptor.check_attribute(StorageSchema.Cac_PaymentMeans_Cell_descriptor.envelope, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("envelope", TypeConverter<T>.ConvertFrom_Cac_PaymentMeans_Envelope(this.envelope));
                
                if (StorageSchema.Cac_PaymentMeans_Cell_descriptor.check_attribute(StorageSchema.Cac_PaymentMeans_Cell_descriptor.envelopeseal, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("envelopeseal", TypeConverter<T>.ConvertFrom_TRACredential_EnvelopeSeal(this.envelopeseal));
                
                break;
                
                case 53:
                
                if (StorageSchema.Cac_PaymentMeans_Cell_descriptor.check_attribute(StorageSchema.Cac_PaymentMeans_Cell_descriptor.envelope, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("envelope", TypeConverter<T>.ConvertFrom_Cac_PaymentMeans_Envelope(this.envelope));
                
                break;
                
                case 77:
                
                if (StorageSchema.Cac_PaymentMeans_Cell_descriptor.check_attribute(StorageSchema.Cac_PaymentMeans_Cell_descriptor.envelopeseal, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("envelopeseal", TypeConverter<T>.ConvertFrom_TRACredential_EnvelopeSeal(this.envelopeseal));
                
                break;
                
                case 96:
                
                if (StorageSchema.Cac_PaymentMeans_Cell_descriptor.check_attribute(StorageSchema.Cac_PaymentMeans_Cell_descriptor.envelope, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("envelope", TypeConverter<T>.ConvertFrom_Cac_PaymentMeans_Envelope(this.envelope));
                
                if (StorageSchema.Cac_PaymentMeans_Cell_descriptor.check_attribute(StorageSchema.Cac_PaymentMeans_Cell_descriptor.envelopeseal, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("envelopeseal", TypeConverter<T>.ConvertFrom_TRACredential_EnvelopeSeal(this.envelopeseal));
                
                break;
                
                default:
                Throw.incompatible_with_cell();
                break;
            }
            yield break;
        }
        #region enumerate value constructs
        
        private IEnumerable<T> _enumerate_from_envelope<T>()
        {
            
            switch (TypeConverter<T>.type_id)
            {
                
                case 4:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_Cac_PaymentMeans_Envelope(this.envelope);
                        
                    }
                    break;
                
                case 5:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_Cac_PaymentMeans_Envelope(this.envelope);
                        
                    }
                    break;
                
                case 53:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_Cac_PaymentMeans_Envelope(this.envelope);
                        
                    }
                    break;
                
                case 96:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_Cac_PaymentMeans_Envelope(this.envelope);
                        
                    }
                    break;
                
                default:
                    Throw.incompatible_with_cell();
                    break;
            }
            yield break;
            
        }
        
        private IEnumerable<T> _enumerate_from_envelopeseal<T>()
        {
            
            switch (TypeConverter<T>.type_id)
            {
                
                case 4:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_TRACredential_EnvelopeSeal(this.envelopeseal);
                        
                    }
                    break;
                
                case 5:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_TRACredential_EnvelopeSeal(this.envelopeseal);
                        
                    }
                    break;
                
                case 77:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_TRACredential_EnvelopeSeal(this.envelopeseal);
                        
                    }
                    break;
                
                case 96:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_TRACredential_EnvelopeSeal(this.envelopeseal);
                        
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
                return _enumerate_from_envelope<T>();
                
                case 1:
                return _enumerate_from_envelopeseal<T>();
                
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
                
                foreach (var val in _enumerate_from_envelope<T>())
                    yield return val;
                
                foreach (var val in _enumerate_from_envelopeseal<T>())
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
            return (Cac_PaymentMeans_Cell_Accessor)this;
        }
        #endregion
        #region Other interfaces
        string ITypeDescriptor.TypeName
        {
            get { return StorageSchema.s_cellTypeName_Cac_PaymentMeans_Cell; }
        }
        Type ITypeDescriptor.Type
        {
            get { return StorageSchema.s_cellType_Cac_PaymentMeans_Cell; }
        }
        bool ITypeDescriptor.IsOfType<T>()
        {
            return typeof(T) == StorageSchema.s_cellType_Cac_PaymentMeans_Cell;
        }
        bool ITypeDescriptor.IsList()
        {
            return false;
        }
        IEnumerable<IFieldDescriptor> ICellDescriptor.GetFieldDescriptors()
        {
            return StorageSchema.Cac_PaymentMeans_Cell.GetFieldDescriptors();
        }
        IAttributeCollection ICellDescriptor.GetFieldAttributes(string fieldName)
        {
            return StorageSchema.Cac_PaymentMeans_Cell.GetFieldAttributes(fieldName);
        }
        string IAttributeCollection.GetAttributeValue(string attributeKey)
        {
            return StorageSchema.Cac_PaymentMeans_Cell.GetAttributeValue(attributeKey);
        }
        IReadOnlyDictionary<string, string> IAttributeCollection.Attributes
        {
            get { return StorageSchema.Cac_PaymentMeans_Cell.Attributes; }
        }
        IEnumerable<string> ICellDescriptor.GetFieldNames()
        {
            
            {
                yield return "envelope";
            }
            
            {
                yield return "envelopeseal";
            }
            
        }
        ushort ICellDescriptor.CellType
        {
            get
            {
                return (ushort)CellType.Cac_PaymentMeans_Cell;
            }
        }
        #endregion
    }
    /// <summary>
    /// Provides in-place operations of Cac_PaymentMeans_Cell defined in TSL.
    /// </summary>
    public unsafe class Cac_PaymentMeans_Cell_Accessor : ICellAccessor
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
        private unsafe Cac_PaymentMeans_Cell_Accessor()
        {
                    envelope_Accessor_Field = new Cac_PaymentMeans_Envelope_Accessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        envelopeseal_Accessor_Field = new TRACredential_EnvelopeSeal_Accessor(null,
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
            {{{            byte* optheader_4 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_4 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_4 + 0) & 0x02)))
                {
{{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                }

                if ((0 != (*(optheader_4 + 0) & 0x04)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}{            byte* optheader_4 = targetPtr;
            targetPtr += 1;
            targetPtr += 11;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_4 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_4 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}}{            byte* optheader_2 = targetPtr;
            targetPtr += 1;

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
}}
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
            {{{            byte* optheader_4 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_4 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_4 + 0) & 0x02)))
                {
{{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                }

                if ((0 != (*(optheader_4 + 0) & 0x04)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}{            byte* optheader_4 = targetPtr;
            targetPtr += 1;
            targetPtr += 11;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_4 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_4 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}}{            byte* optheader_2 = targetPtr;
            targetPtr += 1;

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
}}
            int size = (int)(targetPtr - m_ptr);
            return size;
        }
        public ResizeFunctionDelegate ResizeFunction { get; set; }
        #endregion
        private static byte[] s_default_content = null;
        private static unsafe byte[] construct( Cac_PaymentMeans_Envelope envelope = default(Cac_PaymentMeans_Envelope) , TRACredential_EnvelopeSeal envelopeseal = default(TRACredential_EnvelopeSeal) )
        {
            if (s_default_content != null) return s_default_content;
            
            byte* targetPtr;
            
            targetPtr = null;
            
            {

            {

            {
            targetPtr += 1;

        if(envelope.content.udid!= null)
        {
            int strlen_4 = envelope.content.udid.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

{

    targetPtr += sizeof(int);
    if(envelope.content.context!= null)
    {
        for(int iterator_4 = 0;iterator_4<envelope.content.context.Count;++iterator_4)
        {

        if(envelope.content.context[iterator_4]!= null)
        {
            int strlen_5 = envelope.content.context[iterator_4].Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        }
    }

}
            if( envelope.content.credentialsubjectudid!= null)
            {

        if(envelope.content.credentialsubjectudid!= null)
        {
            int strlen_4 = envelope.content.credentialsubjectudid.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( envelope.content.claims!= null)
            {

            {

            {

        if(envelope.content.claims.Value.cbc_PaymentMeansCode._listID!= null)
        {
            int strlen_6 = envelope.content.claims.Value.cbc_PaymentMeansCode._listID.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(envelope.content.claims.Value.cbc_PaymentMeansCode._listAgencyID!= null)
        {
            int strlen_6 = envelope.content.claims.Value.cbc_PaymentMeansCode._listAgencyID.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(envelope.content.claims.Value.cbc_PaymentMeansCode.code!= null)
        {
            int strlen_6 = envelope.content.claims.Value.cbc_PaymentMeansCode.code.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }targetPtr += 8;
        if(envelope.content.claims.Value.cbc_PaymentChannel!= null)
        {
            int strlen_5 = envelope.content.claims.Value.cbc_PaymentChannel.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(envelope.content.claims.Value.cbc_PaymentID!= null)
        {
            int strlen_5 = envelope.content.claims.Value.cbc_PaymentID.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(envelope.content.claims.Value.cac_PayeeFinancialAccountUdid!= null)
        {
            int strlen_5 = envelope.content.claims.Value.cac_PayeeFinancialAccountUdid.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
            if( envelope.content.encryptedclaims!= null)
            {

            {

        if(envelope.content.encryptedclaims.Value.ciphertext16!= null)
        {
            int strlen_5 = envelope.content.encryptedclaims.Value.ciphertext16.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(envelope.content.encryptedclaims.Value.alg!= null)
        {
            int strlen_5 = envelope.content.encryptedclaims.Value.alg.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(envelope.content.encryptedclaims.Value.key!= null)
        {
            int strlen_5 = envelope.content.encryptedclaims.Value.key.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }

            }
            {
            targetPtr += 1;
            targetPtr += 1;
            targetPtr += 8;
            targetPtr += 1;
            targetPtr += 1;

        if(envelope.label.notaryudid!= null)
        {
            int strlen_4 = envelope.label.notaryudid.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( envelope.label.name!= null)
            {

        if(envelope.label.name!= null)
        {
            int strlen_4 = envelope.label.name.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( envelope.label.comment!= null)
            {

        if(envelope.label.comment!= null)
        {
            int strlen_4 = envelope.label.comment.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

            }
            }
            {
            targetPtr += 1;
            if( envelopeseal.hashedThumbprint64!= null)
            {

        if(envelopeseal.hashedThumbprint64!= null)
        {
            int strlen_3 = envelopeseal.hashedThumbprint64.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( envelopeseal.signedHashSignature64!= null)
            {

        if(envelopeseal.signedHashSignature64!= null)
        {
            int strlen_3 = envelopeseal.signedHashSignature64.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( envelopeseal.notaryStamp!= null)
            {

        if(envelopeseal.notaryStamp!= null)
        {
            int strlen_3 = envelopeseal.notaryStamp.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( envelopeseal.comments!= null)
            {

{

    targetPtr += sizeof(int);
    if(envelopeseal.comments!= null)
    {
        for(int iterator_3 = 0;iterator_3<envelopeseal.comments.Count;++iterator_3)
        {

        if(envelopeseal.comments[iterator_3]!= null)
        {
            int strlen_4 = envelopeseal.comments[iterator_3].Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        }
    }

}

            }

            }
            }
            byte[] tmpcell = new byte[(int)(targetPtr)];
            fixed (byte* _tmpcellptr = tmpcell)
            {
                targetPtr = _tmpcellptr;
                
            {

            {

            {
            byte* optheader_3 = targetPtr;
            *(optheader_3 + 0) = 0x00;            targetPtr += 1;

        if(envelope.content.udid!= null)
        {
            int strlen_4 = envelope.content.udid.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = envelope.content.udid)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

{
byte *storedPtr_4 = targetPtr;

    targetPtr += sizeof(int);
    if(envelope.content.context!= null)
    {
        for(int iterator_4 = 0;iterator_4<envelope.content.context.Count;++iterator_4)
        {

        if(envelope.content.context[iterator_4]!= null)
        {
            int strlen_5 = envelope.content.context[iterator_4].Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = envelope.content.context[iterator_4])
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        }
    }
*(int*)storedPtr_4 = (int)(targetPtr - storedPtr_4 - 4);

}
            if( envelope.content.credentialsubjectudid!= null)
            {

        if(envelope.content.credentialsubjectudid!= null)
        {
            int strlen_4 = envelope.content.credentialsubjectudid.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = envelope.content.credentialsubjectudid)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_3 + 0) |= 0x01;
            }
            if( envelope.content.claims!= null)
            {

            {

            {

        if(envelope.content.claims.Value.cbc_PaymentMeansCode._listID!= null)
        {
            int strlen_6 = envelope.content.claims.Value.cbc_PaymentMeansCode._listID.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = envelope.content.claims.Value.cbc_PaymentMeansCode._listID)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(envelope.content.claims.Value.cbc_PaymentMeansCode._listAgencyID!= null)
        {
            int strlen_6 = envelope.content.claims.Value.cbc_PaymentMeansCode._listAgencyID.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = envelope.content.claims.Value.cbc_PaymentMeansCode._listAgencyID)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(envelope.content.claims.Value.cbc_PaymentMeansCode.code!= null)
        {
            int strlen_6 = envelope.content.claims.Value.cbc_PaymentMeansCode.code.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = envelope.content.claims.Value.cbc_PaymentMeansCode.code)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
        {
            *(long*)targetPtr = envelope.content.claims.Value.cbc_PaymentDueDate.ToBinary();
            targetPtr += 8;
        }

        if(envelope.content.claims.Value.cbc_PaymentChannel!= null)
        {
            int strlen_5 = envelope.content.claims.Value.cbc_PaymentChannel.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = envelope.content.claims.Value.cbc_PaymentChannel)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(envelope.content.claims.Value.cbc_PaymentID!= null)
        {
            int strlen_5 = envelope.content.claims.Value.cbc_PaymentID.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = envelope.content.claims.Value.cbc_PaymentID)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(envelope.content.claims.Value.cac_PayeeFinancialAccountUdid!= null)
        {
            int strlen_5 = envelope.content.claims.Value.cac_PayeeFinancialAccountUdid.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = envelope.content.claims.Value.cac_PayeeFinancialAccountUdid)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }*(optheader_3 + 0) |= 0x02;
            }
            if( envelope.content.encryptedclaims!= null)
            {

            {

        if(envelope.content.encryptedclaims.Value.ciphertext16!= null)
        {
            int strlen_5 = envelope.content.encryptedclaims.Value.ciphertext16.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = envelope.content.encryptedclaims.Value.ciphertext16)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(envelope.content.encryptedclaims.Value.alg!= null)
        {
            int strlen_5 = envelope.content.encryptedclaims.Value.alg.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = envelope.content.encryptedclaims.Value.alg)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(envelope.content.encryptedclaims.Value.key!= null)
        {
            int strlen_5 = envelope.content.encryptedclaims.Value.key.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = envelope.content.encryptedclaims.Value.key)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }*(optheader_3 + 0) |= 0x04;
            }

            }
            {
            byte* optheader_3 = targetPtr;
            *(optheader_3 + 0) = 0x00;            targetPtr += 1;
            *(TRACredentialType*)targetPtr = envelope.label.credtype;
            targetPtr += 1;
            *(long*)targetPtr = envelope.label.version;
            targetPtr += 8;
            *(TRATrustLevel*)targetPtr = envelope.label.trustLevel;
            targetPtr += 1;
            *(TRAEncryptionFlag*)targetPtr = envelope.label.encryptionFlag;
            targetPtr += 1;

        if(envelope.label.notaryudid!= null)
        {
            int strlen_4 = envelope.label.notaryudid.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = envelope.label.notaryudid)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( envelope.label.name!= null)
            {

        if(envelope.label.name!= null)
        {
            int strlen_4 = envelope.label.name.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = envelope.label.name)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_3 + 0) |= 0x01;
            }
            if( envelope.label.comment!= null)
            {

        if(envelope.label.comment!= null)
        {
            int strlen_4 = envelope.label.comment.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = envelope.label.comment)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_3 + 0) |= 0x02;
            }

            }
            }
            {
            byte* optheader_2 = targetPtr;
            *(optheader_2 + 0) = 0x00;            targetPtr += 1;
            if( envelopeseal.hashedThumbprint64!= null)
            {

        if(envelopeseal.hashedThumbprint64!= null)
        {
            int strlen_3 = envelopeseal.hashedThumbprint64.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = envelopeseal.hashedThumbprint64)
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
            if( envelopeseal.signedHashSignature64!= null)
            {

        if(envelopeseal.signedHashSignature64!= null)
        {
            int strlen_3 = envelopeseal.signedHashSignature64.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = envelopeseal.signedHashSignature64)
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
            if( envelopeseal.notaryStamp!= null)
            {

        if(envelopeseal.notaryStamp!= null)
        {
            int strlen_3 = envelopeseal.notaryStamp.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = envelopeseal.notaryStamp)
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
            if( envelopeseal.comments!= null)
            {

{
byte *storedPtr_3 = targetPtr;

    targetPtr += sizeof(int);
    if(envelopeseal.comments!= null)
    {
        for(int iterator_3 = 0;iterator_3<envelopeseal.comments.Count;++iterator_3)
        {

        if(envelopeseal.comments[iterator_3]!= null)
        {
            int strlen_4 = envelopeseal.comments[iterator_3].Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = envelopeseal.comments[iterator_3])
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

            }
            }
            }
            
            s_default_content = tmpcell;
            return tmpcell;
        }
        Cac_PaymentMeans_Envelope_Accessor envelope_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field envelope.
        ///</summary>
        public unsafe Cac_PaymentMeans_Envelope_Accessor envelope
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {}envelope_Accessor_Field.m_ptr = targetPtr;
                envelope_Accessor_Field.m_cellId = this.m_cellId;
                return envelope_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                envelope_Accessor_Field.m_cellId = this.m_cellId;
                
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
        TRACredential_EnvelopeSeal_Accessor envelopeseal_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field envelopeseal.
        ///</summary>
        public unsafe TRACredential_EnvelopeSeal_Accessor envelopeseal
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {{{            byte* optheader_5 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_5 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_5 + 0) & 0x02)))
                {
{{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                }

                if ((0 != (*(optheader_5 + 0) & 0x04)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}{            byte* optheader_5 = targetPtr;
            targetPtr += 1;
            targetPtr += 11;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_5 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_5 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}}}envelopeseal_Accessor_Field.m_ptr = targetPtr;
                envelopeseal_Accessor_Field.m_cellId = this.m_cellId;
                return envelopeseal_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                envelopeseal_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {{{            byte* optheader_5 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_5 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_5 + 0) & 0x02)))
                {
{{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                }

                if ((0 != (*(optheader_5 + 0) & 0x04)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}{            byte* optheader_5 = targetPtr;
            targetPtr += 1;
            targetPtr += 11;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_5 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_5 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}}}
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
        
        public static unsafe implicit operator Cac_PaymentMeans_Cell(Cac_PaymentMeans_Cell_Accessor accessor)
        {
            
            return new Cac_PaymentMeans_Cell(accessor.CellId
            
            ,
            
                    accessor.envelope
            ,
            
                    accessor.envelopeseal
            );
        }
        
        public unsafe static implicit operator Cac_PaymentMeans_Cell_Accessor(Cac_PaymentMeans_Cell field)
        {
            byte* targetPtr = null;
            
            {

            {

            {
            targetPtr += 1;

        if(field.envelope.content.udid!= null)
        {
            int strlen_4 = field.envelope.content.udid.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

{

    targetPtr += sizeof(int);
    if(field.envelope.content.context!= null)
    {
        for(int iterator_4 = 0;iterator_4<field.envelope.content.context.Count;++iterator_4)
        {

        if(field.envelope.content.context[iterator_4]!= null)
        {
            int strlen_5 = field.envelope.content.context[iterator_4].Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        }
    }

}
            if( field.envelope.content.credentialsubjectudid!= null)
            {

        if(field.envelope.content.credentialsubjectudid!= null)
        {
            int strlen_4 = field.envelope.content.credentialsubjectudid.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( field.envelope.content.claims!= null)
            {

            {

            {

        if(field.envelope.content.claims.Value.cbc_PaymentMeansCode._listID!= null)
        {
            int strlen_6 = field.envelope.content.claims.Value.cbc_PaymentMeansCode._listID.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.envelope.content.claims.Value.cbc_PaymentMeansCode._listAgencyID!= null)
        {
            int strlen_6 = field.envelope.content.claims.Value.cbc_PaymentMeansCode._listAgencyID.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.envelope.content.claims.Value.cbc_PaymentMeansCode.code!= null)
        {
            int strlen_6 = field.envelope.content.claims.Value.cbc_PaymentMeansCode.code.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }targetPtr += 8;
        if(field.envelope.content.claims.Value.cbc_PaymentChannel!= null)
        {
            int strlen_5 = field.envelope.content.claims.Value.cbc_PaymentChannel.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.envelope.content.claims.Value.cbc_PaymentID!= null)
        {
            int strlen_5 = field.envelope.content.claims.Value.cbc_PaymentID.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.envelope.content.claims.Value.cac_PayeeFinancialAccountUdid!= null)
        {
            int strlen_5 = field.envelope.content.claims.Value.cac_PayeeFinancialAccountUdid.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
            if( field.envelope.content.encryptedclaims!= null)
            {

            {

        if(field.envelope.content.encryptedclaims.Value.ciphertext16!= null)
        {
            int strlen_5 = field.envelope.content.encryptedclaims.Value.ciphertext16.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.envelope.content.encryptedclaims.Value.alg!= null)
        {
            int strlen_5 = field.envelope.content.encryptedclaims.Value.alg.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.envelope.content.encryptedclaims.Value.key!= null)
        {
            int strlen_5 = field.envelope.content.encryptedclaims.Value.key.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }

            }
            {
            targetPtr += 1;
            targetPtr += 1;
            targetPtr += 8;
            targetPtr += 1;
            targetPtr += 1;

        if(field.envelope.label.notaryudid!= null)
        {
            int strlen_4 = field.envelope.label.notaryudid.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( field.envelope.label.name!= null)
            {

        if(field.envelope.label.name!= null)
        {
            int strlen_4 = field.envelope.label.name.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( field.envelope.label.comment!= null)
            {

        if(field.envelope.label.comment!= null)
        {
            int strlen_4 = field.envelope.label.comment.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

            }
            }
            {
            targetPtr += 1;
            if( field.envelopeseal.hashedThumbprint64!= null)
            {

        if(field.envelopeseal.hashedThumbprint64!= null)
        {
            int strlen_3 = field.envelopeseal.hashedThumbprint64.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( field.envelopeseal.signedHashSignature64!= null)
            {

        if(field.envelopeseal.signedHashSignature64!= null)
        {
            int strlen_3 = field.envelopeseal.signedHashSignature64.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( field.envelopeseal.notaryStamp!= null)
            {

        if(field.envelopeseal.notaryStamp!= null)
        {
            int strlen_3 = field.envelopeseal.notaryStamp.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( field.envelopeseal.comments!= null)
            {

{

    targetPtr += sizeof(int);
    if(field.envelopeseal.comments!= null)
    {
        for(int iterator_3 = 0;iterator_3<field.envelopeseal.comments.Count;++iterator_3)
        {

        if(field.envelopeseal.comments[iterator_3]!= null)
        {
            int strlen_4 = field.envelopeseal.comments[iterator_3].Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        }
    }

}

            }

            }
            }
            byte* tmpcellptr = BufferAllocator.AllocBuffer((int)targetPtr);
            Memory.memset(tmpcellptr, 0, (ulong)targetPtr);
            targetPtr = tmpcellptr;
            
            {

            {

            {
            byte* optheader_3 = targetPtr;
            *(optheader_3 + 0) = 0x00;            targetPtr += 1;

        if(field.envelope.content.udid!= null)
        {
            int strlen_4 = field.envelope.content.udid.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.envelope.content.udid)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

{
byte *storedPtr_4 = targetPtr;

    targetPtr += sizeof(int);
    if(field.envelope.content.context!= null)
    {
        for(int iterator_4 = 0;iterator_4<field.envelope.content.context.Count;++iterator_4)
        {

        if(field.envelope.content.context[iterator_4]!= null)
        {
            int strlen_5 = field.envelope.content.context[iterator_4].Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.envelope.content.context[iterator_4])
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        }
    }
*(int*)storedPtr_4 = (int)(targetPtr - storedPtr_4 - 4);

}
            if( field.envelope.content.credentialsubjectudid!= null)
            {

        if(field.envelope.content.credentialsubjectudid!= null)
        {
            int strlen_4 = field.envelope.content.credentialsubjectudid.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.envelope.content.credentialsubjectudid)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_3 + 0) |= 0x01;
            }
            if( field.envelope.content.claims!= null)
            {

            {

            {

        if(field.envelope.content.claims.Value.cbc_PaymentMeansCode._listID!= null)
        {
            int strlen_6 = field.envelope.content.claims.Value.cbc_PaymentMeansCode._listID.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = field.envelope.content.claims.Value.cbc_PaymentMeansCode._listID)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.envelope.content.claims.Value.cbc_PaymentMeansCode._listAgencyID!= null)
        {
            int strlen_6 = field.envelope.content.claims.Value.cbc_PaymentMeansCode._listAgencyID.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = field.envelope.content.claims.Value.cbc_PaymentMeansCode._listAgencyID)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.envelope.content.claims.Value.cbc_PaymentMeansCode.code!= null)
        {
            int strlen_6 = field.envelope.content.claims.Value.cbc_PaymentMeansCode.code.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = field.envelope.content.claims.Value.cbc_PaymentMeansCode.code)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
        {
            *(long*)targetPtr = field.envelope.content.claims.Value.cbc_PaymentDueDate.ToBinary();
            targetPtr += 8;
        }

        if(field.envelope.content.claims.Value.cbc_PaymentChannel!= null)
        {
            int strlen_5 = field.envelope.content.claims.Value.cbc_PaymentChannel.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.envelope.content.claims.Value.cbc_PaymentChannel)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.envelope.content.claims.Value.cbc_PaymentID!= null)
        {
            int strlen_5 = field.envelope.content.claims.Value.cbc_PaymentID.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.envelope.content.claims.Value.cbc_PaymentID)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.envelope.content.claims.Value.cac_PayeeFinancialAccountUdid!= null)
        {
            int strlen_5 = field.envelope.content.claims.Value.cac_PayeeFinancialAccountUdid.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.envelope.content.claims.Value.cac_PayeeFinancialAccountUdid)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }*(optheader_3 + 0) |= 0x02;
            }
            if( field.envelope.content.encryptedclaims!= null)
            {

            {

        if(field.envelope.content.encryptedclaims.Value.ciphertext16!= null)
        {
            int strlen_5 = field.envelope.content.encryptedclaims.Value.ciphertext16.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.envelope.content.encryptedclaims.Value.ciphertext16)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.envelope.content.encryptedclaims.Value.alg!= null)
        {
            int strlen_5 = field.envelope.content.encryptedclaims.Value.alg.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.envelope.content.encryptedclaims.Value.alg)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.envelope.content.encryptedclaims.Value.key!= null)
        {
            int strlen_5 = field.envelope.content.encryptedclaims.Value.key.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.envelope.content.encryptedclaims.Value.key)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }*(optheader_3 + 0) |= 0x04;
            }

            }
            {
            byte* optheader_3 = targetPtr;
            *(optheader_3 + 0) = 0x00;            targetPtr += 1;
            *(TRACredentialType*)targetPtr = field.envelope.label.credtype;
            targetPtr += 1;
            *(long*)targetPtr = field.envelope.label.version;
            targetPtr += 8;
            *(TRATrustLevel*)targetPtr = field.envelope.label.trustLevel;
            targetPtr += 1;
            *(TRAEncryptionFlag*)targetPtr = field.envelope.label.encryptionFlag;
            targetPtr += 1;

        if(field.envelope.label.notaryudid!= null)
        {
            int strlen_4 = field.envelope.label.notaryudid.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.envelope.label.notaryudid)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( field.envelope.label.name!= null)
            {

        if(field.envelope.label.name!= null)
        {
            int strlen_4 = field.envelope.label.name.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.envelope.label.name)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_3 + 0) |= 0x01;
            }
            if( field.envelope.label.comment!= null)
            {

        if(field.envelope.label.comment!= null)
        {
            int strlen_4 = field.envelope.label.comment.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.envelope.label.comment)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_3 + 0) |= 0x02;
            }

            }
            }
            {
            byte* optheader_2 = targetPtr;
            *(optheader_2 + 0) = 0x00;            targetPtr += 1;
            if( field.envelopeseal.hashedThumbprint64!= null)
            {

        if(field.envelopeseal.hashedThumbprint64!= null)
        {
            int strlen_3 = field.envelopeseal.hashedThumbprint64.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.envelopeseal.hashedThumbprint64)
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
            if( field.envelopeseal.signedHashSignature64!= null)
            {

        if(field.envelopeseal.signedHashSignature64!= null)
        {
            int strlen_3 = field.envelopeseal.signedHashSignature64.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.envelopeseal.signedHashSignature64)
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
            if( field.envelopeseal.notaryStamp!= null)
            {

        if(field.envelopeseal.notaryStamp!= null)
        {
            int strlen_3 = field.envelopeseal.notaryStamp.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.envelopeseal.notaryStamp)
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
            if( field.envelopeseal.comments!= null)
            {

{
byte *storedPtr_3 = targetPtr;

    targetPtr += sizeof(int);
    if(field.envelopeseal.comments!= null)
    {
        for(int iterator_3 = 0;iterator_3<field.envelopeseal.comments.Count;++iterator_3)
        {

        if(field.envelopeseal.comments[iterator_3]!= null)
        {
            int strlen_4 = field.envelopeseal.comments[iterator_3].Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.envelopeseal.comments[iterator_3])
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

            }
            }Cac_PaymentMeans_Cell_Accessor ret;
            
            ret = Cac_PaymentMeans_Cell_Accessor._get()._Setup(field.CellId, tmpcellptr, -1, 0, null);
            ret.m_cellId = field.CellId;
            
            return ret;
        }
        
        public static bool operator ==(Cac_PaymentMeans_Cell_Accessor a, Cac_PaymentMeans_Cell_Accessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            byte* targetPtr = a.m_ptr;
            {{{            byte* optheader_5 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_5 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_5 + 0) & 0x02)))
                {
{{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                }

                if ((0 != (*(optheader_5 + 0) & 0x04)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}{            byte* optheader_5 = targetPtr;
            targetPtr += 1;
            targetPtr += 11;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_5 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_5 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}}{            byte* optheader_3 = targetPtr;
            targetPtr += 1;

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
            int lengthA = (int)(targetPtr - a.m_ptr);
            targetPtr = b.m_ptr;
            {{{            byte* optheader_5 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_5 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_5 + 0) & 0x02)))
                {
{{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                }

                if ((0 != (*(optheader_5 + 0) & 0x04)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}{            byte* optheader_5 = targetPtr;
            targetPtr += 1;
            targetPtr += 11;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_5 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_5 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}}{            byte* optheader_3 = targetPtr;
            targetPtr += 1;

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
            int lengthB = (int)(targetPtr - b.m_ptr);
            if(lengthA != lengthB) return false;
            return Memory.Compare(a.m_ptr,b.m_ptr,lengthA);
        }
        public static bool operator != (Cac_PaymentMeans_Cell_Accessor a, Cac_PaymentMeans_Cell_Accessor b)
        {
            return !(a == b);
        }
        
        public static bool operator ==(Cac_PaymentMeans_Cell_Accessor a, Cac_PaymentMeans_Cell b)
        {
            Cac_PaymentMeans_Cell_Accessor bb = b;
            return (a == bb);
        }
        public static bool operator !=(Cac_PaymentMeans_Cell_Accessor a, Cac_PaymentMeans_Cell b)
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
        internal unsafe Cac_PaymentMeans_Cell_Accessor _Lock(long cellId, CellAccessOptions options)
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
                    if (cellType != (ushort)CellType.Cac_PaymentMeans_Cell)
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
                        eResult                = Global.LocalStorage.AddOrUse(cellId, defaultContent, ref size, (ushort)CellType.Cac_PaymentMeans_Cell, out this.m_ptr, out this.m_cellEntryIndex);
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
        internal unsafe Cac_PaymentMeans_Cell_Accessor _Lock(long cellId, CellAccessOptions options, LocalTransactionContext tx)
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
                    if (cellType != (ushort)CellType.Cac_PaymentMeans_Cell)
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
                        eResult                = Global.LocalStorage.AddOrUse(tx, cellId, defaultContent, ref size, (ushort)CellType.Cac_PaymentMeans_Cell, out this.m_ptr, out this.m_cellEntryIndex);
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
        private class PoolPolicy : IPooledObjectPolicy<Cac_PaymentMeans_Cell_Accessor>
        {
            public Cac_PaymentMeans_Cell_Accessor Create()
            {
                return new Cac_PaymentMeans_Cell_Accessor();
            }
            public bool Return(Cac_PaymentMeans_Cell_Accessor obj)
            {
                return !obj.m_IsIterator;
            }
        }
        private static DefaultObjectPool<Cac_PaymentMeans_Cell_Accessor> s_accessor_pool = new DefaultObjectPool<Cac_PaymentMeans_Cell_Accessor>(new PoolPolicy());
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Cac_PaymentMeans_Cell_Accessor _get() => s_accessor_pool.Get();
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void _put(Cac_PaymentMeans_Cell_Accessor item) => s_accessor_pool.Return(item);
        /// <summary>
        /// For internal use only.
        /// Caller guarantees that entry lock is obtained.
        /// Does not handle CellAccessOptions. Only copy to the accessor.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal Cac_PaymentMeans_Cell_Accessor _Setup(long CellId, byte* cellPtr, int entryIndex, CellAccessOptions options)
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
        internal Cac_PaymentMeans_Cell_Accessor _Setup(long CellId, byte* cellPtr, int entryIndex, CellAccessOptions options, LocalTransactionContext tx)
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
        internal static Cac_PaymentMeans_Cell_Accessor AllocIterativeAccessor(CellInfo info, LocalTransactionContext tx)
        {
            Cac_PaymentMeans_Cell_Accessor accessor = new Cac_PaymentMeans_Cell_Accessor();
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
        /// If write-ahead-log behavior is specified on <see cref="TDW.TRAServer.StorageExtension_Cac_PaymentMeans_Cell.UseCac_PaymentMeans_Cell"/>,
        /// the changes will be committed to the write-ahead log.
        /// </summary>
        public void Dispose()
        {
            if (m_cellEntryIndex >= 0)
            {
                if ((m_options & c_WALFlags) != 0)
                {
                    LocalMemoryStorage.CWriteAheadLog(this.CellId, this.m_ptr, this.CellSize, (ushort)CellType.Cac_PaymentMeans_Cell, m_options);
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
        /// <summary>Converts a Cac_PaymentMeans_Cell_Accessor to its string representation, in JSON format.</summary>
        /// <returns>A string representation of the Cac_PaymentMeans_Cell.</returns>
        public override string ToString()
        {
            return Serializer.ToString(this);
        }
        #endregion
        #region Lookup tables
        internal static StringLookupTable FieldLookupTable = new StringLookupTable(
            
            "envelope"
            ,
            "envelopeseal"
            
            );
        static HashSet<string> AppendToFieldRerouteSet = new HashSet<string>()
        {
            
            "envelope"
            ,
            "envelopeseal"
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
                    return GenericFieldAccessor.GetField<T>(this.envelope, fieldName, field_divider_idx + 1);
                    
                    case 1:
                    return GenericFieldAccessor.GetField<T>(this.envelopeseal, fieldName, field_divider_idx + 1);
                    
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
                return TypeConverter<T>.ConvertFrom_Cac_PaymentMeans_Envelope(this.envelope);
                
                case 1:
                return TypeConverter<T>.ConvertFrom_TRACredential_EnvelopeSeal(this.envelopeseal);
                
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
                    GenericFieldAccessor.SetField(this.envelope, fieldName, field_divider_idx + 1, value);
                    break;
                    
                    case 1:
                    GenericFieldAccessor.SetField(this.envelopeseal, fieldName, field_divider_idx + 1, value);
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
                    Cac_PaymentMeans_Envelope conversion_result = TypeConverter<T>.ConvertTo_Cac_PaymentMeans_Envelope(value);
                    
            {
                this.envelope = conversion_result;
            }
            
                }
                break;
                
                case 1:
                {
                    TRACredential_EnvelopeSeal conversion_result = TypeConverter<T>.ConvertTo_TRACredential_EnvelopeSeal(value);
                    
            {
                this.envelopeseal = conversion_result;
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
                
                case 4:
                
                if (StorageSchema.Cac_PaymentMeans_Cell_descriptor.check_attribute(StorageSchema.Cac_PaymentMeans_Cell_descriptor.envelope, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("envelope", TypeConverter<T>.ConvertFrom_Cac_PaymentMeans_Envelope(this.envelope));
                
                if (StorageSchema.Cac_PaymentMeans_Cell_descriptor.check_attribute(StorageSchema.Cac_PaymentMeans_Cell_descriptor.envelopeseal, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("envelopeseal", TypeConverter<T>.ConvertFrom_TRACredential_EnvelopeSeal(this.envelopeseal));
                
                break;
                
                case 5:
                
                if (StorageSchema.Cac_PaymentMeans_Cell_descriptor.check_attribute(StorageSchema.Cac_PaymentMeans_Cell_descriptor.envelope, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("envelope", TypeConverter<T>.ConvertFrom_Cac_PaymentMeans_Envelope(this.envelope));
                
                if (StorageSchema.Cac_PaymentMeans_Cell_descriptor.check_attribute(StorageSchema.Cac_PaymentMeans_Cell_descriptor.envelopeseal, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("envelopeseal", TypeConverter<T>.ConvertFrom_TRACredential_EnvelopeSeal(this.envelopeseal));
                
                break;
                
                case 53:
                
                if (StorageSchema.Cac_PaymentMeans_Cell_descriptor.check_attribute(StorageSchema.Cac_PaymentMeans_Cell_descriptor.envelope, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("envelope", TypeConverter<T>.ConvertFrom_Cac_PaymentMeans_Envelope(this.envelope));
                
                break;
                
                case 77:
                
                if (StorageSchema.Cac_PaymentMeans_Cell_descriptor.check_attribute(StorageSchema.Cac_PaymentMeans_Cell_descriptor.envelopeseal, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("envelopeseal", TypeConverter<T>.ConvertFrom_TRACredential_EnvelopeSeal(this.envelopeseal));
                
                break;
                
                case 96:
                
                if (StorageSchema.Cac_PaymentMeans_Cell_descriptor.check_attribute(StorageSchema.Cac_PaymentMeans_Cell_descriptor.envelope, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("envelope", TypeConverter<T>.ConvertFrom_Cac_PaymentMeans_Envelope(this.envelope));
                
                if (StorageSchema.Cac_PaymentMeans_Cell_descriptor.check_attribute(StorageSchema.Cac_PaymentMeans_Cell_descriptor.envelopeseal, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("envelopeseal", TypeConverter<T>.ConvertFrom_TRACredential_EnvelopeSeal(this.envelopeseal));
                
                break;
                
                default:
                Throw.incompatible_with_cell();
                break;
            }
            yield break;
        }
        #region enumerate value methods
        
        private IEnumerable<T> _enumerate_from_envelope<T>()
        {
            
            switch (TypeConverter<T>.type_id)
            {
                
                case 4:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_Cac_PaymentMeans_Envelope(this.envelope);
                        
                    }
                    break;
                
                case 5:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_Cac_PaymentMeans_Envelope(this.envelope);
                        
                    }
                    break;
                
                case 53:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_Cac_PaymentMeans_Envelope(this.envelope);
                        
                    }
                    break;
                
                case 96:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_Cac_PaymentMeans_Envelope(this.envelope);
                        
                    }
                    break;
                
                default:
                    Throw.incompatible_with_cell();
                    break;
            }
            yield break;
            
        }
        
        private IEnumerable<T> _enumerate_from_envelopeseal<T>()
        {
            
            switch (TypeConverter<T>.type_id)
            {
                
                case 4:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_TRACredential_EnvelopeSeal(this.envelopeseal);
                        
                    }
                    break;
                
                case 5:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_TRACredential_EnvelopeSeal(this.envelopeseal);
                        
                    }
                    break;
                
                case 77:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_TRACredential_EnvelopeSeal(this.envelopeseal);
                        
                    }
                    break;
                
                case 96:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_TRACredential_EnvelopeSeal(this.envelopeseal);
                        
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
                return _enumerate_from_envelope<T>();
                
                case 1:
                return _enumerate_from_envelopeseal<T>();
                
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
                
                foreach (var val in _enumerate_from_envelope<T>())
                    yield return val;
                
                foreach (var val in _enumerate_from_envelopeseal<T>())
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
                yield return "envelope";
            }
            
            {
                yield return "envelopeseal";
            }
            
        }
        IAttributeCollection ICellDescriptor.GetFieldAttributes(string fieldName)
        {
            return StorageSchema.Cac_PaymentMeans_Cell.GetFieldAttributes(fieldName);
        }
        IEnumerable<IFieldDescriptor> ICellDescriptor.GetFieldDescriptors()
        {
            return StorageSchema.Cac_PaymentMeans_Cell.GetFieldDescriptors();
        }
        string ITypeDescriptor.TypeName
        {
            get { return StorageSchema.s_cellTypeName_Cac_PaymentMeans_Cell; }
        }
        Type ITypeDescriptor.Type
        {
            get { return StorageSchema.s_cellType_Cac_PaymentMeans_Cell; }
        }
        bool ITypeDescriptor.IsOfType<T>()
        {
            return typeof(T) == StorageSchema.s_cellType_Cac_PaymentMeans_Cell;
        }
        bool ITypeDescriptor.IsList()
        {
            return false;
        }
        IReadOnlyDictionary<string, string> IAttributeCollection.Attributes
        {
            get { return StorageSchema.Cac_PaymentMeans_Cell.Attributes; }
        }
        string IAttributeCollection.GetAttributeValue(string attributeKey)
        {
            return StorageSchema.Cac_PaymentMeans_Cell.GetAttributeValue(attributeKey);
        }
        ushort ICellDescriptor.CellType
        {
            get
            {
                return (ushort)CellType.Cac_PaymentMeans_Cell;
            }
        }
        public ICellAccessor Serialize()
        {
            return this;
        }
        #endregion
        public ICell Deserialize()
        {
            return (Cac_PaymentMeans_Cell)this;
        }
    }
    ///<summary>
    ///Provides interfaces for accessing Cac_PaymentMeans_Cell cells
    ///on <see cref="Trinity.Storage.LocalMemorySotrage"/>.
    static public class StorageExtension_Cac_PaymentMeans_Cell
    {
        #region IKeyValueStore non logging
        /// <summary>
        /// Adds a new cell of type Cac_PaymentMeans_Cell to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. The value of the cell is specified in the method parameters.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.IKeyValueStore"/> instance.</param>
        /// <param name="cellId">A 64-bit cell Id.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveCac_PaymentMeans_Cell(this IKeyValueStore storage, long cellId, Cac_PaymentMeans_Envelope envelope = default(Cac_PaymentMeans_Envelope), TRACredential_EnvelopeSeal envelopeseal = default(TRACredential_EnvelopeSeal))
        {
            
            byte* targetPtr;
            
            targetPtr = null;
            
            {

            {

            {
            targetPtr += 1;

        if(envelope.content.udid!= null)
        {
            int strlen_4 = envelope.content.udid.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

{

    targetPtr += sizeof(int);
    if(envelope.content.context!= null)
    {
        for(int iterator_4 = 0;iterator_4<envelope.content.context.Count;++iterator_4)
        {

        if(envelope.content.context[iterator_4]!= null)
        {
            int strlen_5 = envelope.content.context[iterator_4].Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        }
    }

}
            if( envelope.content.credentialsubjectudid!= null)
            {

        if(envelope.content.credentialsubjectudid!= null)
        {
            int strlen_4 = envelope.content.credentialsubjectudid.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( envelope.content.claims!= null)
            {

            {

            {

        if(envelope.content.claims.Value.cbc_PaymentMeansCode._listID!= null)
        {
            int strlen_6 = envelope.content.claims.Value.cbc_PaymentMeansCode._listID.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(envelope.content.claims.Value.cbc_PaymentMeansCode._listAgencyID!= null)
        {
            int strlen_6 = envelope.content.claims.Value.cbc_PaymentMeansCode._listAgencyID.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(envelope.content.claims.Value.cbc_PaymentMeansCode.code!= null)
        {
            int strlen_6 = envelope.content.claims.Value.cbc_PaymentMeansCode.code.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }targetPtr += 8;
        if(envelope.content.claims.Value.cbc_PaymentChannel!= null)
        {
            int strlen_5 = envelope.content.claims.Value.cbc_PaymentChannel.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(envelope.content.claims.Value.cbc_PaymentID!= null)
        {
            int strlen_5 = envelope.content.claims.Value.cbc_PaymentID.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(envelope.content.claims.Value.cac_PayeeFinancialAccountUdid!= null)
        {
            int strlen_5 = envelope.content.claims.Value.cac_PayeeFinancialAccountUdid.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
            if( envelope.content.encryptedclaims!= null)
            {

            {

        if(envelope.content.encryptedclaims.Value.ciphertext16!= null)
        {
            int strlen_5 = envelope.content.encryptedclaims.Value.ciphertext16.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(envelope.content.encryptedclaims.Value.alg!= null)
        {
            int strlen_5 = envelope.content.encryptedclaims.Value.alg.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(envelope.content.encryptedclaims.Value.key!= null)
        {
            int strlen_5 = envelope.content.encryptedclaims.Value.key.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }

            }
            {
            targetPtr += 1;
            targetPtr += 1;
            targetPtr += 8;
            targetPtr += 1;
            targetPtr += 1;

        if(envelope.label.notaryudid!= null)
        {
            int strlen_4 = envelope.label.notaryudid.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( envelope.label.name!= null)
            {

        if(envelope.label.name!= null)
        {
            int strlen_4 = envelope.label.name.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( envelope.label.comment!= null)
            {

        if(envelope.label.comment!= null)
        {
            int strlen_4 = envelope.label.comment.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

            }
            }
            {
            targetPtr += 1;
            if( envelopeseal.hashedThumbprint64!= null)
            {

        if(envelopeseal.hashedThumbprint64!= null)
        {
            int strlen_3 = envelopeseal.hashedThumbprint64.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( envelopeseal.signedHashSignature64!= null)
            {

        if(envelopeseal.signedHashSignature64!= null)
        {
            int strlen_3 = envelopeseal.signedHashSignature64.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( envelopeseal.notaryStamp!= null)
            {

        if(envelopeseal.notaryStamp!= null)
        {
            int strlen_3 = envelopeseal.notaryStamp.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( envelopeseal.comments!= null)
            {

{

    targetPtr += sizeof(int);
    if(envelopeseal.comments!= null)
    {
        for(int iterator_3 = 0;iterator_3<envelopeseal.comments.Count;++iterator_3)
        {

        if(envelopeseal.comments[iterator_3]!= null)
        {
            int strlen_4 = envelopeseal.comments[iterator_3].Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        }
    }

}

            }

            }
            }
            byte[] tmpcell = new byte[(int)(targetPtr)];
            fixed (byte* _tmpcellptr = tmpcell)
            {
                targetPtr = _tmpcellptr;
                
            {

            {

            {
            byte* optheader_3 = targetPtr;
            *(optheader_3 + 0) = 0x00;            targetPtr += 1;

        if(envelope.content.udid!= null)
        {
            int strlen_4 = envelope.content.udid.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = envelope.content.udid)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

{
byte *storedPtr_4 = targetPtr;

    targetPtr += sizeof(int);
    if(envelope.content.context!= null)
    {
        for(int iterator_4 = 0;iterator_4<envelope.content.context.Count;++iterator_4)
        {

        if(envelope.content.context[iterator_4]!= null)
        {
            int strlen_5 = envelope.content.context[iterator_4].Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = envelope.content.context[iterator_4])
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        }
    }
*(int*)storedPtr_4 = (int)(targetPtr - storedPtr_4 - 4);

}
            if( envelope.content.credentialsubjectudid!= null)
            {

        if(envelope.content.credentialsubjectudid!= null)
        {
            int strlen_4 = envelope.content.credentialsubjectudid.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = envelope.content.credentialsubjectudid)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_3 + 0) |= 0x01;
            }
            if( envelope.content.claims!= null)
            {

            {

            {

        if(envelope.content.claims.Value.cbc_PaymentMeansCode._listID!= null)
        {
            int strlen_6 = envelope.content.claims.Value.cbc_PaymentMeansCode._listID.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = envelope.content.claims.Value.cbc_PaymentMeansCode._listID)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(envelope.content.claims.Value.cbc_PaymentMeansCode._listAgencyID!= null)
        {
            int strlen_6 = envelope.content.claims.Value.cbc_PaymentMeansCode._listAgencyID.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = envelope.content.claims.Value.cbc_PaymentMeansCode._listAgencyID)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(envelope.content.claims.Value.cbc_PaymentMeansCode.code!= null)
        {
            int strlen_6 = envelope.content.claims.Value.cbc_PaymentMeansCode.code.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = envelope.content.claims.Value.cbc_PaymentMeansCode.code)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
        {
            *(long*)targetPtr = envelope.content.claims.Value.cbc_PaymentDueDate.ToBinary();
            targetPtr += 8;
        }

        if(envelope.content.claims.Value.cbc_PaymentChannel!= null)
        {
            int strlen_5 = envelope.content.claims.Value.cbc_PaymentChannel.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = envelope.content.claims.Value.cbc_PaymentChannel)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(envelope.content.claims.Value.cbc_PaymentID!= null)
        {
            int strlen_5 = envelope.content.claims.Value.cbc_PaymentID.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = envelope.content.claims.Value.cbc_PaymentID)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(envelope.content.claims.Value.cac_PayeeFinancialAccountUdid!= null)
        {
            int strlen_5 = envelope.content.claims.Value.cac_PayeeFinancialAccountUdid.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = envelope.content.claims.Value.cac_PayeeFinancialAccountUdid)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }*(optheader_3 + 0) |= 0x02;
            }
            if( envelope.content.encryptedclaims!= null)
            {

            {

        if(envelope.content.encryptedclaims.Value.ciphertext16!= null)
        {
            int strlen_5 = envelope.content.encryptedclaims.Value.ciphertext16.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = envelope.content.encryptedclaims.Value.ciphertext16)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(envelope.content.encryptedclaims.Value.alg!= null)
        {
            int strlen_5 = envelope.content.encryptedclaims.Value.alg.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = envelope.content.encryptedclaims.Value.alg)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(envelope.content.encryptedclaims.Value.key!= null)
        {
            int strlen_5 = envelope.content.encryptedclaims.Value.key.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = envelope.content.encryptedclaims.Value.key)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }*(optheader_3 + 0) |= 0x04;
            }

            }
            {
            byte* optheader_3 = targetPtr;
            *(optheader_3 + 0) = 0x00;            targetPtr += 1;
            *(TRACredentialType*)targetPtr = envelope.label.credtype;
            targetPtr += 1;
            *(long*)targetPtr = envelope.label.version;
            targetPtr += 8;
            *(TRATrustLevel*)targetPtr = envelope.label.trustLevel;
            targetPtr += 1;
            *(TRAEncryptionFlag*)targetPtr = envelope.label.encryptionFlag;
            targetPtr += 1;

        if(envelope.label.notaryudid!= null)
        {
            int strlen_4 = envelope.label.notaryudid.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = envelope.label.notaryudid)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( envelope.label.name!= null)
            {

        if(envelope.label.name!= null)
        {
            int strlen_4 = envelope.label.name.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = envelope.label.name)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_3 + 0) |= 0x01;
            }
            if( envelope.label.comment!= null)
            {

        if(envelope.label.comment!= null)
        {
            int strlen_4 = envelope.label.comment.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = envelope.label.comment)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_3 + 0) |= 0x02;
            }

            }
            }
            {
            byte* optheader_2 = targetPtr;
            *(optheader_2 + 0) = 0x00;            targetPtr += 1;
            if( envelopeseal.hashedThumbprint64!= null)
            {

        if(envelopeseal.hashedThumbprint64!= null)
        {
            int strlen_3 = envelopeseal.hashedThumbprint64.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = envelopeseal.hashedThumbprint64)
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
            if( envelopeseal.signedHashSignature64!= null)
            {

        if(envelopeseal.signedHashSignature64!= null)
        {
            int strlen_3 = envelopeseal.signedHashSignature64.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = envelopeseal.signedHashSignature64)
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
            if( envelopeseal.notaryStamp!= null)
            {

        if(envelopeseal.notaryStamp!= null)
        {
            int strlen_3 = envelopeseal.notaryStamp.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = envelopeseal.notaryStamp)
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
            if( envelopeseal.comments!= null)
            {

{
byte *storedPtr_3 = targetPtr;

    targetPtr += sizeof(int);
    if(envelopeseal.comments!= null)
    {
        for(int iterator_3 = 0;iterator_3<envelopeseal.comments.Count;++iterator_3)
        {

        if(envelopeseal.comments[iterator_3]!= null)
        {
            int strlen_4 = envelopeseal.comments[iterator_3].Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = envelopeseal.comments[iterator_3])
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

            }
            }
            }
            
            return storage.SaveCell(cellId, tmpcell, (ushort)CellType.Cac_PaymentMeans_Cell) == TrinityErrorCode.E_SUCCESS;
        }
        /// <summary>
        /// Adds a new cell of type Cac_PaymentMeans_Cell to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. The parameter <paramref name="cellId"/> overrides the cell id in the content object.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.IKeyValueStore"/> instance.</param>
        /// <param name="cellId">A 64-bit cell Id.</param>
        /// <param name="cellContent">The content of the cell.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveCac_PaymentMeans_Cell(this IKeyValueStore storage, long cellId, Cac_PaymentMeans_Cell cellContent)
        {
            return SaveCac_PaymentMeans_Cell(storage, cellId  , cellContent.envelope  , cellContent.envelopeseal );
        }
        /// <summary>
        /// Adds a new cell of type Cac_PaymentMeans_Cell to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. Cell Id is specified by the CellId field in the content object.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.IKeyValueStore"/> instance.</param>
        /// <param name="cellContent">The content of the cell.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveCac_PaymentMeans_Cell(this IKeyValueStore storage, Cac_PaymentMeans_Cell cellContent)
        {
            return SaveCac_PaymentMeans_Cell(storage, cellContent.CellId  , cellContent.envelope  , cellContent.envelopeseal );
        }
        /// <summary>
        /// Loads the content of the specified cell. Any changes done to this object are not written to the store, unless
        /// the content object is saved back into the storage.
        /// <param name="storage"/>A <see cref="Trinity.Storage.IKeyValueStore"/> instance.</param>
        /// </summary>
        public unsafe static Cac_PaymentMeans_Cell LoadCac_PaymentMeans_Cell(this IKeyValueStore storage, long cellId)
        {
            if (TrinityErrorCode.E_SUCCESS == storage.LoadCell(cellId, out var buff))
            {
                fixed (byte* p = buff)
                {
                    return Cac_PaymentMeans_Cell_Accessor._get()._Setup(cellId, p, -1, 0);
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
        /// the cell as a Cac_PaymentMeans_Cell. Any changes done to the accessor
        /// are written to the storage immediately.
        /// If <c><see cref="Trinity.TrinityConfig.ReadOnly"/> == false</c>,
        /// on calling this method, it attempts to acquire the lock of the cell,
        /// and blocks until it gets the lock. Otherwise this method is wait-free.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">The id of the specified cell.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <returns>A <see cref="TDW.TRAServer.Cac_PaymentMeans_Cell"/> instance.</returns>
        public unsafe static Cac_PaymentMeans_Cell_Accessor UseCac_PaymentMeans_Cell(this Trinity.Storage.LocalMemoryStorage storage, long cellId, CellAccessOptions options)
        {
            return Cac_PaymentMeans_Cell_Accessor._get()._Lock(cellId, options);
        }
        /// <summary>
        /// Allocate a cell accessor on the specified cell, which interprets
        /// the cell as a Cac_PaymentMeans_Cell. Any changes done to the accessor
        /// are written to the storage immediately.
        /// If <c><see cref="Trinity.TrinityConfig.ReadOnly"/> == false</c>,
        /// on calling this method, it attempts to acquire the lock of the cell,
        /// and blocks until it gets the lock.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">The id of the specified cell.</param>
        /// <returns>A <see cref="" + script.RootNamespace + ".Cac_PaymentMeans_Cell"/> instance.</returns>
        public unsafe static Cac_PaymentMeans_Cell_Accessor UseCac_PaymentMeans_Cell(this Trinity.Storage.LocalMemoryStorage storage, long cellId)
        {
            return Cac_PaymentMeans_Cell_Accessor._get()._Lock(cellId, CellAccessOptions.ThrowExceptionOnCellNotFound);
        }
        #endregion
        #region LocalStorage Non-Tx logging
        /// <summary>
        /// Adds a new cell of type Cac_PaymentMeans_Cell to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. The value of the cell is specified in the method parameters.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">A 64-bit cell Id.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveCac_PaymentMeans_Cell(this Trinity.Storage.LocalMemoryStorage storage, CellAccessOptions options, long cellId, Cac_PaymentMeans_Envelope envelope = default(Cac_PaymentMeans_Envelope), TRACredential_EnvelopeSeal envelopeseal = default(TRACredential_EnvelopeSeal))
        {
            
            byte* targetPtr;
            
            targetPtr = null;
            
            {

            {

            {
            targetPtr += 1;

        if(envelope.content.udid!= null)
        {
            int strlen_4 = envelope.content.udid.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

{

    targetPtr += sizeof(int);
    if(envelope.content.context!= null)
    {
        for(int iterator_4 = 0;iterator_4<envelope.content.context.Count;++iterator_4)
        {

        if(envelope.content.context[iterator_4]!= null)
        {
            int strlen_5 = envelope.content.context[iterator_4].Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        }
    }

}
            if( envelope.content.credentialsubjectudid!= null)
            {

        if(envelope.content.credentialsubjectudid!= null)
        {
            int strlen_4 = envelope.content.credentialsubjectudid.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( envelope.content.claims!= null)
            {

            {

            {

        if(envelope.content.claims.Value.cbc_PaymentMeansCode._listID!= null)
        {
            int strlen_6 = envelope.content.claims.Value.cbc_PaymentMeansCode._listID.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(envelope.content.claims.Value.cbc_PaymentMeansCode._listAgencyID!= null)
        {
            int strlen_6 = envelope.content.claims.Value.cbc_PaymentMeansCode._listAgencyID.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(envelope.content.claims.Value.cbc_PaymentMeansCode.code!= null)
        {
            int strlen_6 = envelope.content.claims.Value.cbc_PaymentMeansCode.code.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }targetPtr += 8;
        if(envelope.content.claims.Value.cbc_PaymentChannel!= null)
        {
            int strlen_5 = envelope.content.claims.Value.cbc_PaymentChannel.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(envelope.content.claims.Value.cbc_PaymentID!= null)
        {
            int strlen_5 = envelope.content.claims.Value.cbc_PaymentID.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(envelope.content.claims.Value.cac_PayeeFinancialAccountUdid!= null)
        {
            int strlen_5 = envelope.content.claims.Value.cac_PayeeFinancialAccountUdid.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
            if( envelope.content.encryptedclaims!= null)
            {

            {

        if(envelope.content.encryptedclaims.Value.ciphertext16!= null)
        {
            int strlen_5 = envelope.content.encryptedclaims.Value.ciphertext16.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(envelope.content.encryptedclaims.Value.alg!= null)
        {
            int strlen_5 = envelope.content.encryptedclaims.Value.alg.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(envelope.content.encryptedclaims.Value.key!= null)
        {
            int strlen_5 = envelope.content.encryptedclaims.Value.key.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }

            }
            {
            targetPtr += 1;
            targetPtr += 1;
            targetPtr += 8;
            targetPtr += 1;
            targetPtr += 1;

        if(envelope.label.notaryudid!= null)
        {
            int strlen_4 = envelope.label.notaryudid.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( envelope.label.name!= null)
            {

        if(envelope.label.name!= null)
        {
            int strlen_4 = envelope.label.name.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( envelope.label.comment!= null)
            {

        if(envelope.label.comment!= null)
        {
            int strlen_4 = envelope.label.comment.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

            }
            }
            {
            targetPtr += 1;
            if( envelopeseal.hashedThumbprint64!= null)
            {

        if(envelopeseal.hashedThumbprint64!= null)
        {
            int strlen_3 = envelopeseal.hashedThumbprint64.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( envelopeseal.signedHashSignature64!= null)
            {

        if(envelopeseal.signedHashSignature64!= null)
        {
            int strlen_3 = envelopeseal.signedHashSignature64.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( envelopeseal.notaryStamp!= null)
            {

        if(envelopeseal.notaryStamp!= null)
        {
            int strlen_3 = envelopeseal.notaryStamp.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( envelopeseal.comments!= null)
            {

{

    targetPtr += sizeof(int);
    if(envelopeseal.comments!= null)
    {
        for(int iterator_3 = 0;iterator_3<envelopeseal.comments.Count;++iterator_3)
        {

        if(envelopeseal.comments[iterator_3]!= null)
        {
            int strlen_4 = envelopeseal.comments[iterator_3].Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        }
    }

}

            }

            }
            }
            byte[] tmpcell = new byte[(int)(targetPtr)];
            fixed (byte* _tmpcellptr = tmpcell)
            {
                targetPtr = _tmpcellptr;
                
            {

            {

            {
            byte* optheader_3 = targetPtr;
            *(optheader_3 + 0) = 0x00;            targetPtr += 1;

        if(envelope.content.udid!= null)
        {
            int strlen_4 = envelope.content.udid.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = envelope.content.udid)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

{
byte *storedPtr_4 = targetPtr;

    targetPtr += sizeof(int);
    if(envelope.content.context!= null)
    {
        for(int iterator_4 = 0;iterator_4<envelope.content.context.Count;++iterator_4)
        {

        if(envelope.content.context[iterator_4]!= null)
        {
            int strlen_5 = envelope.content.context[iterator_4].Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = envelope.content.context[iterator_4])
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        }
    }
*(int*)storedPtr_4 = (int)(targetPtr - storedPtr_4 - 4);

}
            if( envelope.content.credentialsubjectudid!= null)
            {

        if(envelope.content.credentialsubjectudid!= null)
        {
            int strlen_4 = envelope.content.credentialsubjectudid.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = envelope.content.credentialsubjectudid)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_3 + 0) |= 0x01;
            }
            if( envelope.content.claims!= null)
            {

            {

            {

        if(envelope.content.claims.Value.cbc_PaymentMeansCode._listID!= null)
        {
            int strlen_6 = envelope.content.claims.Value.cbc_PaymentMeansCode._listID.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = envelope.content.claims.Value.cbc_PaymentMeansCode._listID)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(envelope.content.claims.Value.cbc_PaymentMeansCode._listAgencyID!= null)
        {
            int strlen_6 = envelope.content.claims.Value.cbc_PaymentMeansCode._listAgencyID.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = envelope.content.claims.Value.cbc_PaymentMeansCode._listAgencyID)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(envelope.content.claims.Value.cbc_PaymentMeansCode.code!= null)
        {
            int strlen_6 = envelope.content.claims.Value.cbc_PaymentMeansCode.code.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = envelope.content.claims.Value.cbc_PaymentMeansCode.code)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
        {
            *(long*)targetPtr = envelope.content.claims.Value.cbc_PaymentDueDate.ToBinary();
            targetPtr += 8;
        }

        if(envelope.content.claims.Value.cbc_PaymentChannel!= null)
        {
            int strlen_5 = envelope.content.claims.Value.cbc_PaymentChannel.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = envelope.content.claims.Value.cbc_PaymentChannel)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(envelope.content.claims.Value.cbc_PaymentID!= null)
        {
            int strlen_5 = envelope.content.claims.Value.cbc_PaymentID.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = envelope.content.claims.Value.cbc_PaymentID)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(envelope.content.claims.Value.cac_PayeeFinancialAccountUdid!= null)
        {
            int strlen_5 = envelope.content.claims.Value.cac_PayeeFinancialAccountUdid.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = envelope.content.claims.Value.cac_PayeeFinancialAccountUdid)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }*(optheader_3 + 0) |= 0x02;
            }
            if( envelope.content.encryptedclaims!= null)
            {

            {

        if(envelope.content.encryptedclaims.Value.ciphertext16!= null)
        {
            int strlen_5 = envelope.content.encryptedclaims.Value.ciphertext16.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = envelope.content.encryptedclaims.Value.ciphertext16)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(envelope.content.encryptedclaims.Value.alg!= null)
        {
            int strlen_5 = envelope.content.encryptedclaims.Value.alg.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = envelope.content.encryptedclaims.Value.alg)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(envelope.content.encryptedclaims.Value.key!= null)
        {
            int strlen_5 = envelope.content.encryptedclaims.Value.key.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = envelope.content.encryptedclaims.Value.key)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }*(optheader_3 + 0) |= 0x04;
            }

            }
            {
            byte* optheader_3 = targetPtr;
            *(optheader_3 + 0) = 0x00;            targetPtr += 1;
            *(TRACredentialType*)targetPtr = envelope.label.credtype;
            targetPtr += 1;
            *(long*)targetPtr = envelope.label.version;
            targetPtr += 8;
            *(TRATrustLevel*)targetPtr = envelope.label.trustLevel;
            targetPtr += 1;
            *(TRAEncryptionFlag*)targetPtr = envelope.label.encryptionFlag;
            targetPtr += 1;

        if(envelope.label.notaryudid!= null)
        {
            int strlen_4 = envelope.label.notaryudid.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = envelope.label.notaryudid)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( envelope.label.name!= null)
            {

        if(envelope.label.name!= null)
        {
            int strlen_4 = envelope.label.name.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = envelope.label.name)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_3 + 0) |= 0x01;
            }
            if( envelope.label.comment!= null)
            {

        if(envelope.label.comment!= null)
        {
            int strlen_4 = envelope.label.comment.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = envelope.label.comment)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_3 + 0) |= 0x02;
            }

            }
            }
            {
            byte* optheader_2 = targetPtr;
            *(optheader_2 + 0) = 0x00;            targetPtr += 1;
            if( envelopeseal.hashedThumbprint64!= null)
            {

        if(envelopeseal.hashedThumbprint64!= null)
        {
            int strlen_3 = envelopeseal.hashedThumbprint64.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = envelopeseal.hashedThumbprint64)
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
            if( envelopeseal.signedHashSignature64!= null)
            {

        if(envelopeseal.signedHashSignature64!= null)
        {
            int strlen_3 = envelopeseal.signedHashSignature64.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = envelopeseal.signedHashSignature64)
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
            if( envelopeseal.notaryStamp!= null)
            {

        if(envelopeseal.notaryStamp!= null)
        {
            int strlen_3 = envelopeseal.notaryStamp.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = envelopeseal.notaryStamp)
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
            if( envelopeseal.comments!= null)
            {

{
byte *storedPtr_3 = targetPtr;

    targetPtr += sizeof(int);
    if(envelopeseal.comments!= null)
    {
        for(int iterator_3 = 0;iterator_3<envelopeseal.comments.Count;++iterator_3)
        {

        if(envelopeseal.comments[iterator_3]!= null)
        {
            int strlen_4 = envelopeseal.comments[iterator_3].Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = envelopeseal.comments[iterator_3])
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

            }
            }
            }
            
            return storage.SaveCell(options, cellId, tmpcell, 0, tmpcell.Length, (ushort)CellType.Cac_PaymentMeans_Cell) == TrinityErrorCode.E_SUCCESS;
        }
        /// <summary>
        /// Adds a new cell of type Cac_PaymentMeans_Cell to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. The parameter <paramref name="cellId"/> overrides the cell id in the content object.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">A 64-bit cell Id.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <param name="cellContent">The content of the cell.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveCac_PaymentMeans_Cell(this Trinity.Storage.LocalMemoryStorage storage, CellAccessOptions options, long cellId, Cac_PaymentMeans_Cell cellContent)
        {
            return SaveCac_PaymentMeans_Cell(storage, options, cellId  , cellContent.envelope  , cellContent.envelopeseal );
        }
        /// <summary>
        /// Adds a new cell of type Cac_PaymentMeans_Cell to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. Cell Id is specified by the CellId field in the content object.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <param name="cellContent">The content of the cell.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveCac_PaymentMeans_Cell(this Trinity.Storage.LocalMemoryStorage storage, CellAccessOptions options, Cac_PaymentMeans_Cell cellContent)
        {
            return SaveCac_PaymentMeans_Cell(storage, options, cellContent.CellId  , cellContent.envelope  , cellContent.envelopeseal );
        }
        /// <summary>
        /// Loads the content of the specified cell. Any changes done to this object are not written to the store, unless
        /// the content object is saved back into the storage.
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// </summary>
        public unsafe static Cac_PaymentMeans_Cell LoadCac_PaymentMeans_Cell(this Trinity.Storage.LocalMemoryStorage storage, long cellId)
        {
            using (var cell = Cac_PaymentMeans_Cell_Accessor._get()._Lock(cellId, CellAccessOptions.ThrowExceptionOnCellNotFound))
            {
                return cell;
            }
        }
        #endregion
        #region LocalMemoryStorage Tx accessors
        /// <summary>
        /// Allocate a cell accessor on the specified cell, which interprets
        /// the cell as a Cac_PaymentMeans_Cell. Any changes done to the accessor
        /// are written to the storage immediately.
        /// If <c><see cref="Trinity.TrinityConfig.ReadOnly"/> == false</c>,
        /// on calling this method, it attempts to acquire the lock of the cell,
        /// and blocks until it gets the lock. Otherwise this method is wait-free.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">The id of the specified cell.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <returns>A <see cref="TDW.TRAServer.Cac_PaymentMeans_Cell"/> instance.</returns>
        public unsafe static Cac_PaymentMeans_Cell_Accessor UseCac_PaymentMeans_Cell(this Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx, long cellId, CellAccessOptions options)
        {
            return Cac_PaymentMeans_Cell_Accessor._get()._Lock(cellId, options, tx);
        }
        /// <summary>
        /// Allocate a cell accessor on the specified cell, which interprets
        /// the cell as a Cac_PaymentMeans_Cell. Any changes done to the accessor
        /// are written to the storage immediately.
        /// If <c><see cref="Trinity.TrinityConfig.ReadOnly"/> == false</c>,
        /// on calling this method, it attempts to acquire the lock of the cell,
        /// and blocks until it gets the lock.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">The id of the specified cell.</param>
        /// <returns>A <see cref="" + script.RootNamespace + ".Cac_PaymentMeans_Cell"/> instance.</returns>
        public unsafe static Cac_PaymentMeans_Cell_Accessor UseCac_PaymentMeans_Cell(this Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx, long cellId)
        {
            return Cac_PaymentMeans_Cell_Accessor._get()._Lock(cellId, CellAccessOptions.ThrowExceptionOnCellNotFound, tx);
        }
        #endregion
        #region LocalStorage Tx logging
        /// <summary>
        /// Adds a new cell of type Cac_PaymentMeans_Cell to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. The value of the cell is specified in the method parameters.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">A 64-bit cell Id.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveCac_PaymentMeans_Cell(this Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx, CellAccessOptions options, long cellId, Cac_PaymentMeans_Envelope envelope = default(Cac_PaymentMeans_Envelope), TRACredential_EnvelopeSeal envelopeseal = default(TRACredential_EnvelopeSeal))
        {
            
            byte* targetPtr;
            
            targetPtr = null;
            
            {

            {

            {
            targetPtr += 1;

        if(envelope.content.udid!= null)
        {
            int strlen_4 = envelope.content.udid.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

{

    targetPtr += sizeof(int);
    if(envelope.content.context!= null)
    {
        for(int iterator_4 = 0;iterator_4<envelope.content.context.Count;++iterator_4)
        {

        if(envelope.content.context[iterator_4]!= null)
        {
            int strlen_5 = envelope.content.context[iterator_4].Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        }
    }

}
            if( envelope.content.credentialsubjectudid!= null)
            {

        if(envelope.content.credentialsubjectudid!= null)
        {
            int strlen_4 = envelope.content.credentialsubjectudid.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( envelope.content.claims!= null)
            {

            {

            {

        if(envelope.content.claims.Value.cbc_PaymentMeansCode._listID!= null)
        {
            int strlen_6 = envelope.content.claims.Value.cbc_PaymentMeansCode._listID.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(envelope.content.claims.Value.cbc_PaymentMeansCode._listAgencyID!= null)
        {
            int strlen_6 = envelope.content.claims.Value.cbc_PaymentMeansCode._listAgencyID.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(envelope.content.claims.Value.cbc_PaymentMeansCode.code!= null)
        {
            int strlen_6 = envelope.content.claims.Value.cbc_PaymentMeansCode.code.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }targetPtr += 8;
        if(envelope.content.claims.Value.cbc_PaymentChannel!= null)
        {
            int strlen_5 = envelope.content.claims.Value.cbc_PaymentChannel.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(envelope.content.claims.Value.cbc_PaymentID!= null)
        {
            int strlen_5 = envelope.content.claims.Value.cbc_PaymentID.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(envelope.content.claims.Value.cac_PayeeFinancialAccountUdid!= null)
        {
            int strlen_5 = envelope.content.claims.Value.cac_PayeeFinancialAccountUdid.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
            if( envelope.content.encryptedclaims!= null)
            {

            {

        if(envelope.content.encryptedclaims.Value.ciphertext16!= null)
        {
            int strlen_5 = envelope.content.encryptedclaims.Value.ciphertext16.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(envelope.content.encryptedclaims.Value.alg!= null)
        {
            int strlen_5 = envelope.content.encryptedclaims.Value.alg.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(envelope.content.encryptedclaims.Value.key!= null)
        {
            int strlen_5 = envelope.content.encryptedclaims.Value.key.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }

            }
            {
            targetPtr += 1;
            targetPtr += 1;
            targetPtr += 8;
            targetPtr += 1;
            targetPtr += 1;

        if(envelope.label.notaryudid!= null)
        {
            int strlen_4 = envelope.label.notaryudid.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( envelope.label.name!= null)
            {

        if(envelope.label.name!= null)
        {
            int strlen_4 = envelope.label.name.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( envelope.label.comment!= null)
            {

        if(envelope.label.comment!= null)
        {
            int strlen_4 = envelope.label.comment.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

            }
            }
            {
            targetPtr += 1;
            if( envelopeseal.hashedThumbprint64!= null)
            {

        if(envelopeseal.hashedThumbprint64!= null)
        {
            int strlen_3 = envelopeseal.hashedThumbprint64.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( envelopeseal.signedHashSignature64!= null)
            {

        if(envelopeseal.signedHashSignature64!= null)
        {
            int strlen_3 = envelopeseal.signedHashSignature64.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( envelopeseal.notaryStamp!= null)
            {

        if(envelopeseal.notaryStamp!= null)
        {
            int strlen_3 = envelopeseal.notaryStamp.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( envelopeseal.comments!= null)
            {

{

    targetPtr += sizeof(int);
    if(envelopeseal.comments!= null)
    {
        for(int iterator_3 = 0;iterator_3<envelopeseal.comments.Count;++iterator_3)
        {

        if(envelopeseal.comments[iterator_3]!= null)
        {
            int strlen_4 = envelopeseal.comments[iterator_3].Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        }
    }

}

            }

            }
            }
            byte[] tmpcell = new byte[(int)(targetPtr)];
            fixed (byte* _tmpcellptr = tmpcell)
            {
                targetPtr = _tmpcellptr;
                
            {

            {

            {
            byte* optheader_3 = targetPtr;
            *(optheader_3 + 0) = 0x00;            targetPtr += 1;

        if(envelope.content.udid!= null)
        {
            int strlen_4 = envelope.content.udid.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = envelope.content.udid)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

{
byte *storedPtr_4 = targetPtr;

    targetPtr += sizeof(int);
    if(envelope.content.context!= null)
    {
        for(int iterator_4 = 0;iterator_4<envelope.content.context.Count;++iterator_4)
        {

        if(envelope.content.context[iterator_4]!= null)
        {
            int strlen_5 = envelope.content.context[iterator_4].Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = envelope.content.context[iterator_4])
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        }
    }
*(int*)storedPtr_4 = (int)(targetPtr - storedPtr_4 - 4);

}
            if( envelope.content.credentialsubjectudid!= null)
            {

        if(envelope.content.credentialsubjectudid!= null)
        {
            int strlen_4 = envelope.content.credentialsubjectudid.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = envelope.content.credentialsubjectudid)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_3 + 0) |= 0x01;
            }
            if( envelope.content.claims!= null)
            {

            {

            {

        if(envelope.content.claims.Value.cbc_PaymentMeansCode._listID!= null)
        {
            int strlen_6 = envelope.content.claims.Value.cbc_PaymentMeansCode._listID.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = envelope.content.claims.Value.cbc_PaymentMeansCode._listID)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(envelope.content.claims.Value.cbc_PaymentMeansCode._listAgencyID!= null)
        {
            int strlen_6 = envelope.content.claims.Value.cbc_PaymentMeansCode._listAgencyID.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = envelope.content.claims.Value.cbc_PaymentMeansCode._listAgencyID)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(envelope.content.claims.Value.cbc_PaymentMeansCode.code!= null)
        {
            int strlen_6 = envelope.content.claims.Value.cbc_PaymentMeansCode.code.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = envelope.content.claims.Value.cbc_PaymentMeansCode.code)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
        {
            *(long*)targetPtr = envelope.content.claims.Value.cbc_PaymentDueDate.ToBinary();
            targetPtr += 8;
        }

        if(envelope.content.claims.Value.cbc_PaymentChannel!= null)
        {
            int strlen_5 = envelope.content.claims.Value.cbc_PaymentChannel.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = envelope.content.claims.Value.cbc_PaymentChannel)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(envelope.content.claims.Value.cbc_PaymentID!= null)
        {
            int strlen_5 = envelope.content.claims.Value.cbc_PaymentID.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = envelope.content.claims.Value.cbc_PaymentID)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(envelope.content.claims.Value.cac_PayeeFinancialAccountUdid!= null)
        {
            int strlen_5 = envelope.content.claims.Value.cac_PayeeFinancialAccountUdid.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = envelope.content.claims.Value.cac_PayeeFinancialAccountUdid)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }*(optheader_3 + 0) |= 0x02;
            }
            if( envelope.content.encryptedclaims!= null)
            {

            {

        if(envelope.content.encryptedclaims.Value.ciphertext16!= null)
        {
            int strlen_5 = envelope.content.encryptedclaims.Value.ciphertext16.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = envelope.content.encryptedclaims.Value.ciphertext16)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(envelope.content.encryptedclaims.Value.alg!= null)
        {
            int strlen_5 = envelope.content.encryptedclaims.Value.alg.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = envelope.content.encryptedclaims.Value.alg)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(envelope.content.encryptedclaims.Value.key!= null)
        {
            int strlen_5 = envelope.content.encryptedclaims.Value.key.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = envelope.content.encryptedclaims.Value.key)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }*(optheader_3 + 0) |= 0x04;
            }

            }
            {
            byte* optheader_3 = targetPtr;
            *(optheader_3 + 0) = 0x00;            targetPtr += 1;
            *(TRACredentialType*)targetPtr = envelope.label.credtype;
            targetPtr += 1;
            *(long*)targetPtr = envelope.label.version;
            targetPtr += 8;
            *(TRATrustLevel*)targetPtr = envelope.label.trustLevel;
            targetPtr += 1;
            *(TRAEncryptionFlag*)targetPtr = envelope.label.encryptionFlag;
            targetPtr += 1;

        if(envelope.label.notaryudid!= null)
        {
            int strlen_4 = envelope.label.notaryudid.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = envelope.label.notaryudid)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( envelope.label.name!= null)
            {

        if(envelope.label.name!= null)
        {
            int strlen_4 = envelope.label.name.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = envelope.label.name)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_3 + 0) |= 0x01;
            }
            if( envelope.label.comment!= null)
            {

        if(envelope.label.comment!= null)
        {
            int strlen_4 = envelope.label.comment.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = envelope.label.comment)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_3 + 0) |= 0x02;
            }

            }
            }
            {
            byte* optheader_2 = targetPtr;
            *(optheader_2 + 0) = 0x00;            targetPtr += 1;
            if( envelopeseal.hashedThumbprint64!= null)
            {

        if(envelopeseal.hashedThumbprint64!= null)
        {
            int strlen_3 = envelopeseal.hashedThumbprint64.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = envelopeseal.hashedThumbprint64)
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
            if( envelopeseal.signedHashSignature64!= null)
            {

        if(envelopeseal.signedHashSignature64!= null)
        {
            int strlen_3 = envelopeseal.signedHashSignature64.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = envelopeseal.signedHashSignature64)
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
            if( envelopeseal.notaryStamp!= null)
            {

        if(envelopeseal.notaryStamp!= null)
        {
            int strlen_3 = envelopeseal.notaryStamp.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = envelopeseal.notaryStamp)
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
            if( envelopeseal.comments!= null)
            {

{
byte *storedPtr_3 = targetPtr;

    targetPtr += sizeof(int);
    if(envelopeseal.comments!= null)
    {
        for(int iterator_3 = 0;iterator_3<envelopeseal.comments.Count;++iterator_3)
        {

        if(envelopeseal.comments[iterator_3]!= null)
        {
            int strlen_4 = envelopeseal.comments[iterator_3].Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = envelopeseal.comments[iterator_3])
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

            }
            }
            }
            
            return storage.SaveCell(tx, options, cellId, tmpcell, 0, tmpcell.Length, (ushort)CellType.Cac_PaymentMeans_Cell) == TrinityErrorCode.E_SUCCESS;
        }
        /// <summary>
        /// Adds a new cell of type Cac_PaymentMeans_Cell to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. The parameter <paramref name="cellId"/> overrides the cell id in the content object.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">A 64-bit cell Id.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <param name="cellContent">The content of the cell.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveCac_PaymentMeans_Cell(this Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx, CellAccessOptions options, long cellId, Cac_PaymentMeans_Cell cellContent)
        {
            return SaveCac_PaymentMeans_Cell(storage, tx, options, cellId  , cellContent.envelope  , cellContent.envelopeseal );
        }
        /// <summary>
        /// Adds a new cell of type Cac_PaymentMeans_Cell to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. Cell Id is specified by the CellId field in the content object.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <param name="cellContent">The content of the cell.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveCac_PaymentMeans_Cell(this Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx, CellAccessOptions options, Cac_PaymentMeans_Cell cellContent)
        {
            return SaveCac_PaymentMeans_Cell(storage, tx, options, cellContent.CellId  , cellContent.envelope  , cellContent.envelopeseal );
        }
        /// <summary>
        /// Loads the content of the specified cell. Any changes done to this object are not written to the store, unless
        /// the content object is saved back into the storage.
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// </summary>
        public unsafe static Cac_PaymentMeans_Cell LoadCac_PaymentMeans_Cell(this Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx, long cellId)
        {
            using (var cell = Cac_PaymentMeans_Cell_Accessor._get()._Lock(cellId, CellAccessOptions.ThrowExceptionOnCellNotFound, tx))
            {
                return cell;
            }
        }
        #endregion
    }
}

#pragma warning restore 162,168,649,660,661,1522
