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
namespace TDW.KMAServer
{
    
    /// <summary>
    /// A .NET runtime object representation of KMAKeyPair defined in TSL.
    /// </summary>
    public partial struct KMAKeyPair : ICell
    {
        ///<summary>
        ///The id of the cell.
        ///</summary>
        public long CellId;
        ///<summary>
        ///Initializes a new instance of KMAKeyPair with the specified parameters.
        ///</summary>
        public KMAKeyPair(long cell_id , string udid = default(string), string keyringudid = default(string), KMAKeyPairType keypairtype = default(KMAKeyPairType), string algorithm = default(string), long keysize = default(long), string encryptedkeypair64 = default(string), string publickey = default(string))
        {
            
            this.udid = udid;
            
            this.keyringudid = keyringudid;
            
            this.keypairtype = keypairtype;
            
            this.algorithm = algorithm;
            
            this.keysize = keysize;
            
            this.encryptedkeypair64 = encryptedkeypair64;
            
            this.publickey = publickey;
            
            CellId = cell_id;
        }
        
        ///<summary>
        ///Initializes a new instance of KMAKeyPair with the specified parameters.
        ///</summary>
        public KMAKeyPair( string udid = default(string), string keyringudid = default(string), KMAKeyPairType keypairtype = default(KMAKeyPairType), string algorithm = default(string), long keysize = default(long), string encryptedkeypair64 = default(string), string publickey = default(string))
        {
            
            this.udid = udid;
            
            this.keyringudid = keyringudid;
            
            this.keypairtype = keypairtype;
            
            this.algorithm = algorithm;
            
            this.keysize = keysize;
            
            this.encryptedkeypair64 = encryptedkeypair64;
            
            this.publickey = publickey;
            
            CellId = CellIdFactory.NewCellId();
        }
        
        public string udid;
        
        public string keyringudid;
        
        public KMAKeyPairType keypairtype;
        
        public string algorithm;
        
        public long keysize;
        
        public string encryptedkeypair64;
        
        public string publickey;
        
        public static bool operator ==(KMAKeyPair a, KMAKeyPair b)
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
                
                (a.udid == b.udid)
                &&
                (a.keyringudid == b.keyringudid)
                &&
                (a.keypairtype == b.keypairtype)
                &&
                (a.algorithm == b.algorithm)
                &&
                (a.keysize == b.keysize)
                &&
                (a.encryptedkeypair64 == b.encryptedkeypair64)
                &&
                (a.publickey == b.publickey)
                
                ;
            
        }
        public static bool operator !=(KMAKeyPair a, KMAKeyPair b)
        {
            return !(a == b);
        }
        #region Text processing
        /// <summary>
        /// Converts the string representation of a KMAKeyPair to its
        /// struct equivalent. A return value indicates whether the 
        /// operation succeeded.
        /// </summary>
        /// <param name="input">A string to convert.</param>
        /// <param name="value">
        /// When this method returns, contains the struct equivalent of the value contained 
        /// in input, if the conversion succeeded, or default(KMAKeyPair) if the conversion
        /// failed. The conversion fails if the input parameter is null or String.Empty, or is 
        /// not of the correct format. This parameter is passed uninitialized.
        /// </param>
        /// <returns>
        /// True if input was converted successfully; otherwise, false.
        /// </returns>
        public static bool TryParse(string input, out KMAKeyPair value)
        {
            try
            {
                value = Newtonsoft.Json.JsonConvert.DeserializeObject<KMAKeyPair>(input);
                return true;
            }
            catch { value = default(KMAKeyPair); return false; }
        }
        public static KMAKeyPair Parse(string input)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<KMAKeyPair>(input);
        }
        ///<summary>Converts a KMAKeyPair to its string representation, in JSON format.</summary>
        ///<returns>A string representation of the KMAKeyPair.</returns>
        public override string ToString()
        {
            return Serializer.ToString(this);
        }
        #endregion
        #region Lookup tables
        internal static StringLookupTable FieldLookupTable = new StringLookupTable(
            
            "udid"
            ,
            "keyringudid"
            ,
            "keypairtype"
            ,
            "algorithm"
            ,
            "keysize"
            ,
            "encryptedkeypair64"
            ,
            "publickey"
            
            );
        internal static HashSet<string> AppendToFieldRerouteSet = new HashSet<string>()
        {
            
            "keypairtype"
            ,
            "keysize"
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
                return TypeConverter<T>.ConvertFrom_string(this.udid);
                
                case 1:
                return TypeConverter<T>.ConvertFrom_string(this.keyringudid);
                
                case 2:
                return TypeConverter<T>.ConvertFrom_KMAKeyPairType(this.keypairtype);
                
                case 3:
                return TypeConverter<T>.ConvertFrom_string(this.algorithm);
                
                case 4:
                return TypeConverter<T>.ConvertFrom_long(this.keysize);
                
                case 5:
                return TypeConverter<T>.ConvertFrom_string(this.encryptedkeypair64);
                
                case 6:
                return TypeConverter<T>.ConvertFrom_string(this.publickey);
                
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
                this.udid = TypeConverter<T>.ConvertTo_string(value);
                break;
                
                case 1:
                this.keyringudid = TypeConverter<T>.ConvertTo_string(value);
                break;
                
                case 2:
                this.keypairtype = TypeConverter<T>.ConvertTo_KMAKeyPairType(value);
                break;
                
                case 3:
                this.algorithm = TypeConverter<T>.ConvertTo_string(value);
                break;
                
                case 4:
                this.keysize = TypeConverter<T>.ConvertTo_long(value);
                break;
                
                case 5:
                this.encryptedkeypair64 = TypeConverter<T>.ConvertTo_string(value);
                break;
                
                case 6:
                this.publickey = TypeConverter<T>.ConvertTo_string(value);
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
                
                case 3:
                
                return true;
                
                case 4:
                
                return true;
                
                case 5:
                
                return true;
                
                case 6:
                
                return true;
                
                default:
                return false;
            }
        }
        /// <summary>
        /// Append <paramref name="value"/> to the target field. Note that if the target field
        /// is not appendable(string or list), calling this method is equivalent to <see cref="TDW.KMAServer.GenericCellAccessor.SetField(string, T)"/>.
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
                
                case 0:
                
                {
                    if (this.udid == null)
                        this.udid = TypeConverter<T>.ConvertTo_string(value);
                    else
                        this.udid += TypeConverter<T>.ConvertTo_string(value);
                }
                
                break;
                
                case 1:
                
                {
                    if (this.keyringudid == null)
                        this.keyringudid = TypeConverter<T>.ConvertTo_string(value);
                    else
                        this.keyringudid += TypeConverter<T>.ConvertTo_string(value);
                }
                
                break;
                
                case 3:
                
                {
                    if (this.algorithm == null)
                        this.algorithm = TypeConverter<T>.ConvertTo_string(value);
                    else
                        this.algorithm += TypeConverter<T>.ConvertTo_string(value);
                }
                
                break;
                
                case 5:
                
                {
                    if (this.encryptedkeypair64 == null)
                        this.encryptedkeypair64 = TypeConverter<T>.ConvertTo_string(value);
                    else
                        this.encryptedkeypair64 += TypeConverter<T>.ConvertTo_string(value);
                }
                
                break;
                
                case 6:
                
                {
                    if (this.publickey == null)
                        this.publickey = TypeConverter<T>.ConvertTo_string(value);
                    else
                        this.publickey += TypeConverter<T>.ConvertTo_string(value);
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
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.udid, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("udid", TypeConverter<T>.ConvertFrom_string(this.udid));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.keyringudid, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("keyringudid", TypeConverter<T>.ConvertFrom_string(this.keyringudid));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.algorithm, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("algorithm", TypeConverter<T>.ConvertFrom_string(this.algorithm));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.keysize, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("keysize", TypeConverter<T>.ConvertFrom_long(this.keysize));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.encryptedkeypair64, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("encryptedkeypair64", TypeConverter<T>.ConvertFrom_string(this.encryptedkeypair64));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.publickey, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("publickey", TypeConverter<T>.ConvertFrom_string(this.publickey));
                
                break;
                
                case 1:
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.udid, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("udid", TypeConverter<T>.ConvertFrom_string(this.udid));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.keyringudid, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("keyringudid", TypeConverter<T>.ConvertFrom_string(this.keyringudid));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.algorithm, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("algorithm", TypeConverter<T>.ConvertFrom_string(this.algorithm));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.keysize, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("keysize", TypeConverter<T>.ConvertFrom_long(this.keysize));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.encryptedkeypair64, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("encryptedkeypair64", TypeConverter<T>.ConvertFrom_string(this.encryptedkeypair64));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.publickey, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("publickey", TypeConverter<T>.ConvertFrom_string(this.publickey));
                
                break;
                
                case 2:
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.udid, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("udid", TypeConverter<T>.ConvertFrom_string(this.udid));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.keyringudid, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("keyringudid", TypeConverter<T>.ConvertFrom_string(this.keyringudid));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.keypairtype, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("keypairtype", TypeConverter<T>.ConvertFrom_KMAKeyPairType(this.keypairtype));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.algorithm, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("algorithm", TypeConverter<T>.ConvertFrom_string(this.algorithm));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.keysize, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("keysize", TypeConverter<T>.ConvertFrom_long(this.keysize));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.encryptedkeypair64, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("encryptedkeypair64", TypeConverter<T>.ConvertFrom_string(this.encryptedkeypair64));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.publickey, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("publickey", TypeConverter<T>.ConvertFrom_string(this.publickey));
                
                break;
                
                case 3:
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.udid, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("udid", TypeConverter<T>.ConvertFrom_string(this.udid));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.keyringudid, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("keyringudid", TypeConverter<T>.ConvertFrom_string(this.keyringudid));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.keypairtype, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("keypairtype", TypeConverter<T>.ConvertFrom_KMAKeyPairType(this.keypairtype));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.algorithm, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("algorithm", TypeConverter<T>.ConvertFrom_string(this.algorithm));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.keysize, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("keysize", TypeConverter<T>.ConvertFrom_long(this.keysize));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.encryptedkeypair64, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("encryptedkeypair64", TypeConverter<T>.ConvertFrom_string(this.encryptedkeypair64));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.publickey, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("publickey", TypeConverter<T>.ConvertFrom_string(this.publickey));
                
                break;
                
                case 4:
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.udid, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("udid", TypeConverter<T>.ConvertFrom_string(this.udid));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.keyringudid, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("keyringudid", TypeConverter<T>.ConvertFrom_string(this.keyringudid));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.keypairtype, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("keypairtype", TypeConverter<T>.ConvertFrom_KMAKeyPairType(this.keypairtype));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.algorithm, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("algorithm", TypeConverter<T>.ConvertFrom_string(this.algorithm));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.encryptedkeypair64, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("encryptedkeypair64", TypeConverter<T>.ConvertFrom_string(this.encryptedkeypair64));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.publickey, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("publickey", TypeConverter<T>.ConvertFrom_string(this.publickey));
                
                break;
                
                default:
                Throw.incompatible_with_cell();
                break;
            }
            yield break;
        }
        #region enumerate value constructs
        
        private IEnumerable<T> _enumerate_from_udid<T>()
        {
            
            switch (TypeConverter<T>.type_id)
            {
                
                case 0:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.udid);
                        
                    }
                    break;
                
                case 1:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.udid);
                        
                    }
                    break;
                
                case 2:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.udid);
                        
                    }
                    break;
                
                case 3:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.udid);
                        
                    }
                    break;
                
                case 4:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.udid);
                        
                    }
                    break;
                
                default:
                    Throw.incompatible_with_cell();
                    break;
            }
            yield break;
            
        }
        
        private IEnumerable<T> _enumerate_from_keyringudid<T>()
        {
            
            switch (TypeConverter<T>.type_id)
            {
                
                case 0:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.keyringudid);
                        
                    }
                    break;
                
                case 1:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.keyringudid);
                        
                    }
                    break;
                
                case 2:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.keyringudid);
                        
                    }
                    break;
                
                case 3:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.keyringudid);
                        
                    }
                    break;
                
                case 4:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.keyringudid);
                        
                    }
                    break;
                
                default:
                    Throw.incompatible_with_cell();
                    break;
            }
            yield break;
            
        }
        
        private IEnumerable<T> _enumerate_from_keypairtype<T>()
        {
            
            switch (TypeConverter<T>.type_id)
            {
                
                case 2:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_KMAKeyPairType(this.keypairtype);
                        
                    }
                    break;
                
                case 3:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_KMAKeyPairType(this.keypairtype);
                        
                    }
                    break;
                
                case 4:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_KMAKeyPairType(this.keypairtype);
                        
                    }
                    break;
                
                default:
                    Throw.incompatible_with_cell();
                    break;
            }
            yield break;
            
        }
        
        private IEnumerable<T> _enumerate_from_algorithm<T>()
        {
            
            switch (TypeConverter<T>.type_id)
            {
                
                case 0:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.algorithm);
                        
                    }
                    break;
                
                case 1:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.algorithm);
                        
                    }
                    break;
                
                case 2:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.algorithm);
                        
                    }
                    break;
                
                case 3:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.algorithm);
                        
                    }
                    break;
                
                case 4:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.algorithm);
                        
                    }
                    break;
                
                default:
                    Throw.incompatible_with_cell();
                    break;
            }
            yield break;
            
        }
        
        private IEnumerable<T> _enumerate_from_keysize<T>()
        {
            
            switch (TypeConverter<T>.type_id)
            {
                
                case 0:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_long(this.keysize);
                        
                    }
                    break;
                
                case 1:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_long(this.keysize);
                        
                    }
                    break;
                
                case 2:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_long(this.keysize);
                        
                    }
                    break;
                
                case 3:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_long(this.keysize);
                        
                    }
                    break;
                
                default:
                    Throw.incompatible_with_cell();
                    break;
            }
            yield break;
            
        }
        
        private IEnumerable<T> _enumerate_from_encryptedkeypair64<T>()
        {
            
            switch (TypeConverter<T>.type_id)
            {
                
                case 0:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.encryptedkeypair64);
                        
                    }
                    break;
                
                case 1:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.encryptedkeypair64);
                        
                    }
                    break;
                
                case 2:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.encryptedkeypair64);
                        
                    }
                    break;
                
                case 3:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.encryptedkeypair64);
                        
                    }
                    break;
                
                case 4:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.encryptedkeypair64);
                        
                    }
                    break;
                
                default:
                    Throw.incompatible_with_cell();
                    break;
            }
            yield break;
            
        }
        
        private IEnumerable<T> _enumerate_from_publickey<T>()
        {
            
            switch (TypeConverter<T>.type_id)
            {
                
                case 0:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.publickey);
                        
                    }
                    break;
                
                case 1:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.publickey);
                        
                    }
                    break;
                
                case 2:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.publickey);
                        
                    }
                    break;
                
                case 3:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.publickey);
                        
                    }
                    break;
                
                case 4:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.publickey);
                        
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
                return _enumerate_from_udid<T>();
                
                case 1:
                return _enumerate_from_keyringudid<T>();
                
                case 2:
                return _enumerate_from_keypairtype<T>();
                
                case 3:
                return _enumerate_from_algorithm<T>();
                
                case 4:
                return _enumerate_from_keysize<T>();
                
                case 5:
                return _enumerate_from_encryptedkeypair64<T>();
                
                case 6:
                return _enumerate_from_publickey<T>();
                
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
                
                foreach (var val in _enumerate_from_udid<T>())
                    yield return val;
                
                foreach (var val in _enumerate_from_keyringudid<T>())
                    yield return val;
                
                foreach (var val in _enumerate_from_keypairtype<T>())
                    yield return val;
                
                foreach (var val in _enumerate_from_algorithm<T>())
                    yield return val;
                
                foreach (var val in _enumerate_from_keysize<T>())
                    yield return val;
                
                foreach (var val in _enumerate_from_encryptedkeypair64<T>())
                    yield return val;
                
                foreach (var val in _enumerate_from_publickey<T>())
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
            return (KMAKeyPair_Accessor)this;
        }
        #endregion
        #region Other interfaces
        string ITypeDescriptor.TypeName
        {
            get { return StorageSchema.s_cellTypeName_KMAKeyPair; }
        }
        Type ITypeDescriptor.Type
        {
            get { return StorageSchema.s_cellType_KMAKeyPair; }
        }
        bool ITypeDescriptor.IsOfType<T>()
        {
            return typeof(T) == StorageSchema.s_cellType_KMAKeyPair;
        }
        bool ITypeDescriptor.IsList()
        {
            return false;
        }
        IEnumerable<IFieldDescriptor> ICellDescriptor.GetFieldDescriptors()
        {
            return StorageSchema.KMAKeyPair.GetFieldDescriptors();
        }
        IAttributeCollection ICellDescriptor.GetFieldAttributes(string fieldName)
        {
            return StorageSchema.KMAKeyPair.GetFieldAttributes(fieldName);
        }
        string IAttributeCollection.GetAttributeValue(string attributeKey)
        {
            return StorageSchema.KMAKeyPair.GetAttributeValue(attributeKey);
        }
        IReadOnlyDictionary<string, string> IAttributeCollection.Attributes
        {
            get { return StorageSchema.KMAKeyPair.Attributes; }
        }
        IEnumerable<string> ICellDescriptor.GetFieldNames()
        {
            
            {
                yield return "udid";
            }
            
            {
                yield return "keyringudid";
            }
            
            {
                yield return "keypairtype";
            }
            
            {
                yield return "algorithm";
            }
            
            {
                yield return "keysize";
            }
            
            {
                yield return "encryptedkeypair64";
            }
            
            {
                yield return "publickey";
            }
            
        }
        ushort ICellDescriptor.CellType
        {
            get
            {
                return (ushort)CellType.KMAKeyPair;
            }
        }
        #endregion
    }
    /// <summary>
    /// Provides in-place operations of KMAKeyPair defined in TSL.
    /// </summary>
    public unsafe class KMAKeyPair_Accessor : ICellAccessor
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
        private unsafe KMAKeyPair_Accessor()
        {
                    udid_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        keyringudid_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        algorithm_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        encryptedkeypair64_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        publickey_Accessor_Field = new StringAccessor(null,
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
            {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
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
            {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            int size = (int)(targetPtr - m_ptr);
            return size;
        }
        public ResizeFunctionDelegate ResizeFunction { get; set; }
        #endregion
        private static byte[] s_default_content = null;
        private static unsafe byte[] construct( string udid = default(string) , string keyringudid = default(string) , KMAKeyPairType keypairtype = default(KMAKeyPairType) , string algorithm = default(string) , long keysize = default(long) , string encryptedkeypair64 = default(string) , string publickey = default(string) )
        {
            if (s_default_content != null) return s_default_content;
            
            byte* targetPtr;
            
            targetPtr = null;
            
            {

        if(udid!= null)
        {
            int strlen_2 = udid.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(keyringudid!= null)
        {
            int strlen_2 = keyringudid.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 1;

        if(algorithm!= null)
        {
            int strlen_2 = algorithm.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

        if(encryptedkeypair64!= null)
        {
            int strlen_2 = encryptedkeypair64.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(publickey!= null)
        {
            int strlen_2 = publickey.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            byte[] tmpcell = new byte[(int)(targetPtr)];
            fixed (byte* _tmpcellptr = tmpcell)
            {
                targetPtr = _tmpcellptr;
                
            {

        if(udid!= null)
        {
            int strlen_2 = udid.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = udid)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(keyringudid!= null)
        {
            int strlen_2 = keyringudid.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = keyringudid)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(KMAKeyPairType*)targetPtr = keypairtype;
            targetPtr += 1;

        if(algorithm!= null)
        {
            int strlen_2 = algorithm.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = algorithm)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = keysize;
            targetPtr += 8;

        if(encryptedkeypair64!= null)
        {
            int strlen_2 = encryptedkeypair64.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = encryptedkeypair64)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(publickey!= null)
        {
            int strlen_2 = publickey.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = publickey)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
            }
            
            s_default_content = tmpcell;
            return tmpcell;
        }
        StringAccessor udid_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field udid.
        ///</summary>
        public unsafe StringAccessor udid
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {}udid_Accessor_Field.m_ptr = targetPtr + 4;
                udid_Accessor_Field.m_cellId = this.m_cellId;
                return udid_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                udid_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != udid_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    udid_Accessor_Field.m_ptr = udid_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, udid_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        udid_Accessor_Field.m_ptr = udid_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, udid_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        StringAccessor keyringudid_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field keyringudid.
        ///</summary>
        public unsafe StringAccessor keyringudid
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);}keyringudid_Accessor_Field.m_ptr = targetPtr + 4;
                keyringudid_Accessor_Field.m_cellId = this.m_cellId;
                return keyringudid_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                keyringudid_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != keyringudid_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    keyringudid_Accessor_Field.m_ptr = keyringudid_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, keyringudid_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        keyringudid_Accessor_Field.m_ptr = keyringudid_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, keyringudid_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        
        ///<summary>
        ///Provides in-place access to the object field keypairtype.
        ///</summary>
        public unsafe KMAKeyPairType keypairtype
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                return *(KMAKeyPairType*)(targetPtr);
                
            }
            set
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}                *(KMAKeyPairType*)targetPtr = value;
            }
        }
        StringAccessor algorithm_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field algorithm.
        ///</summary>
        public unsafe StringAccessor algorithm
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 1;
}algorithm_Accessor_Field.m_ptr = targetPtr + 4;
                algorithm_Accessor_Field.m_cellId = this.m_cellId;
                return algorithm_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                algorithm_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 1;
}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != algorithm_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    algorithm_Accessor_Field.m_ptr = algorithm_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, algorithm_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        algorithm_Accessor_Field.m_ptr = algorithm_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, algorithm_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        
        ///<summary>
        ///Provides in-place access to the object field keysize.
        ///</summary>
        public unsafe long keysize
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}
                return *(long*)(targetPtr);
                
            }
            set
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}                *(long*)targetPtr = value;
            }
        }
        StringAccessor encryptedkeypair64_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field encryptedkeypair64.
        ///</summary>
        public unsafe StringAccessor encryptedkeypair64
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}encryptedkeypair64_Accessor_Field.m_ptr = targetPtr + 4;
                encryptedkeypair64_Accessor_Field.m_cellId = this.m_cellId;
                return encryptedkeypair64_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                encryptedkeypair64_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != encryptedkeypair64_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    encryptedkeypair64_Accessor_Field.m_ptr = encryptedkeypair64_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, encryptedkeypair64_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        encryptedkeypair64_Accessor_Field.m_ptr = encryptedkeypair64_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, encryptedkeypair64_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        StringAccessor publickey_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field publickey.
        ///</summary>
        public unsafe StringAccessor publickey
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);}publickey_Accessor_Field.m_ptr = targetPtr + 4;
                publickey_Accessor_Field.m_cellId = this.m_cellId;
                return publickey_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                publickey_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != publickey_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    publickey_Accessor_Field.m_ptr = publickey_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, publickey_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        publickey_Accessor_Field.m_ptr = publickey_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, publickey_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        
        public static unsafe implicit operator KMAKeyPair(KMAKeyPair_Accessor accessor)
        {
            
            return new KMAKeyPair(accessor.CellId
            
            ,
            
                    accessor.udid
            ,
            
                    accessor.keyringudid
            ,
            
                    accessor.keypairtype
            ,
            
                    accessor.algorithm
            ,
            
                    accessor.keysize
            ,
            
                    accessor.encryptedkeypair64
            ,
            
                    accessor.publickey
            );
        }
        
        public unsafe static implicit operator KMAKeyPair_Accessor(KMAKeyPair field)
        {
            byte* targetPtr = null;
            
            {

        if(field.udid!= null)
        {
            int strlen_2 = field.udid.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.keyringudid!= null)
        {
            int strlen_2 = field.keyringudid.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 1;

        if(field.algorithm!= null)
        {
            int strlen_2 = field.algorithm.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

        if(field.encryptedkeypair64!= null)
        {
            int strlen_2 = field.encryptedkeypair64.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.publickey!= null)
        {
            int strlen_2 = field.publickey.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            byte* tmpcellptr = BufferAllocator.AllocBuffer((int)targetPtr);
            Memory.memset(tmpcellptr, 0, (ulong)targetPtr);
            targetPtr = tmpcellptr;
            
            {

        if(field.udid!= null)
        {
            int strlen_2 = field.udid.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.udid)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.keyringudid!= null)
        {
            int strlen_2 = field.keyringudid.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.keyringudid)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(KMAKeyPairType*)targetPtr = field.keypairtype;
            targetPtr += 1;

        if(field.algorithm!= null)
        {
            int strlen_2 = field.algorithm.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.algorithm)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = field.keysize;
            targetPtr += 8;

        if(field.encryptedkeypair64!= null)
        {
            int strlen_2 = field.encryptedkeypair64.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.encryptedkeypair64)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.publickey!= null)
        {
            int strlen_2 = field.publickey.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.publickey)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }KMAKeyPair_Accessor ret;
            
            ret = KMAKeyPair_Accessor._get()._Setup(field.CellId, tmpcellptr, -1, 0, null);
            ret.m_cellId = field.CellId;
            
            return ret;
        }
        
        public static bool operator ==(KMAKeyPair_Accessor a, KMAKeyPair_Accessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            byte* targetPtr = a.m_ptr;
            {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            int lengthA = (int)(targetPtr - a.m_ptr);
            targetPtr = b.m_ptr;
            {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            int lengthB = (int)(targetPtr - b.m_ptr);
            if(lengthA != lengthB) return false;
            return Memory.Compare(a.m_ptr,b.m_ptr,lengthA);
        }
        public static bool operator != (KMAKeyPair_Accessor a, KMAKeyPair_Accessor b)
        {
            return !(a == b);
        }
        
        public static bool operator ==(KMAKeyPair_Accessor a, KMAKeyPair b)
        {
            KMAKeyPair_Accessor bb = b;
            return (a == bb);
        }
        public static bool operator !=(KMAKeyPair_Accessor a, KMAKeyPair b)
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
        internal unsafe KMAKeyPair_Accessor _Lock(long cellId, CellAccessOptions options)
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
                    if (cellType != (ushort)CellType.KMAKeyPair)
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
                        eResult                = Global.LocalStorage.AddOrUse(cellId, defaultContent, ref size, (ushort)CellType.KMAKeyPair, out this.m_ptr, out this.m_cellEntryIndex);
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
        internal unsafe KMAKeyPair_Accessor _Lock(long cellId, CellAccessOptions options, LocalTransactionContext tx)
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
                    if (cellType != (ushort)CellType.KMAKeyPair)
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
                        eResult                = Global.LocalStorage.AddOrUse(tx, cellId, defaultContent, ref size, (ushort)CellType.KMAKeyPair, out this.m_ptr, out this.m_cellEntryIndex);
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
        private class PoolPolicy : IPooledObjectPolicy<KMAKeyPair_Accessor>
        {
            public KMAKeyPair_Accessor Create()
            {
                return new KMAKeyPair_Accessor();
            }
            public bool Return(KMAKeyPair_Accessor obj)
            {
                return !obj.m_IsIterator;
            }
        }
        private static DefaultObjectPool<KMAKeyPair_Accessor> s_accessor_pool = new DefaultObjectPool<KMAKeyPair_Accessor>(new PoolPolicy());
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static KMAKeyPair_Accessor _get() => s_accessor_pool.Get();
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void _put(KMAKeyPair_Accessor item) => s_accessor_pool.Return(item);
        /// <summary>
        /// For internal use only.
        /// Caller guarantees that entry lock is obtained.
        /// Does not handle CellAccessOptions. Only copy to the accessor.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal KMAKeyPair_Accessor _Setup(long CellId, byte* cellPtr, int entryIndex, CellAccessOptions options)
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
        internal KMAKeyPair_Accessor _Setup(long CellId, byte* cellPtr, int entryIndex, CellAccessOptions options, LocalTransactionContext tx)
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
        internal static KMAKeyPair_Accessor AllocIterativeAccessor(CellInfo info, LocalTransactionContext tx)
        {
            KMAKeyPair_Accessor accessor = new KMAKeyPair_Accessor();
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
        /// If write-ahead-log behavior is specified on <see cref="TDW.KMAServer.StorageExtension_KMAKeyPair.UseKMAKeyPair"/>,
        /// the changes will be committed to the write-ahead log.
        /// </summary>
        public void Dispose()
        {
            if (m_cellEntryIndex >= 0)
            {
                if ((m_options & c_WALFlags) != 0)
                {
                    LocalMemoryStorage.CWriteAheadLog(this.CellId, this.m_ptr, this.CellSize, (ushort)CellType.KMAKeyPair, m_options);
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
        /// <summary>Converts a KMAKeyPair_Accessor to its string representation, in JSON format.</summary>
        /// <returns>A string representation of the KMAKeyPair.</returns>
        public override string ToString()
        {
            return Serializer.ToString(this);
        }
        #endregion
        #region Lookup tables
        internal static StringLookupTable FieldLookupTable = new StringLookupTable(
            
            "udid"
            ,
            "keyringudid"
            ,
            "keypairtype"
            ,
            "algorithm"
            ,
            "keysize"
            ,
            "encryptedkeypair64"
            ,
            "publickey"
            
            );
        static HashSet<string> AppendToFieldRerouteSet = new HashSet<string>()
        {
            
            "keypairtype"
            ,
            "keysize"
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
                return TypeConverter<T>.ConvertFrom_string(this.udid);
                
                case 1:
                return TypeConverter<T>.ConvertFrom_string(this.keyringudid);
                
                case 2:
                return TypeConverter<T>.ConvertFrom_KMAKeyPairType(this.keypairtype);
                
                case 3:
                return TypeConverter<T>.ConvertFrom_string(this.algorithm);
                
                case 4:
                return TypeConverter<T>.ConvertFrom_long(this.keysize);
                
                case 5:
                return TypeConverter<T>.ConvertFrom_string(this.encryptedkeypair64);
                
                case 6:
                return TypeConverter<T>.ConvertFrom_string(this.publickey);
                
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
                    string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                    
            {
                this.udid = conversion_result;
            }
            
                }
                break;
                
                case 1:
                {
                    string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                    
            {
                this.keyringudid = conversion_result;
            }
            
                }
                break;
                
                case 2:
                {
                    KMAKeyPairType conversion_result = TypeConverter<T>.ConvertTo_KMAKeyPairType(value);
                    
            {
                this.keypairtype = conversion_result;
            }
            
                }
                break;
                
                case 3:
                {
                    string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                    
            {
                this.algorithm = conversion_result;
            }
            
                }
                break;
                
                case 4:
                {
                    long conversion_result = TypeConverter<T>.ConvertTo_long(value);
                    
            {
                this.keysize = conversion_result;
            }
            
                }
                break;
                
                case 5:
                {
                    string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                    
            {
                this.encryptedkeypair64 = conversion_result;
            }
            
                }
                break;
                
                case 6:
                {
                    string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                    
            {
                this.publickey = conversion_result;
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
                
                case 3:
                
                return true;
                
                case 4:
                
                return true;
                
                case 5:
                
                return true;
                
                case 6:
                
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
                
                case 0:
                
                {
                    
                    this.udid += TypeConverter<T>.ConvertTo_string(value);
                }
                
                break;
                
                case 1:
                
                {
                    
                    this.keyringudid += TypeConverter<T>.ConvertTo_string(value);
                }
                
                break;
                
                case 3:
                
                {
                    
                    this.algorithm += TypeConverter<T>.ConvertTo_string(value);
                }
                
                break;
                
                case 5:
                
                {
                    
                    this.encryptedkeypair64 += TypeConverter<T>.ConvertTo_string(value);
                }
                
                break;
                
                case 6:
                
                {
                    
                    this.publickey += TypeConverter<T>.ConvertTo_string(value);
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
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.udid, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("udid", TypeConverter<T>.ConvertFrom_string(this.udid));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.keyringudid, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("keyringudid", TypeConverter<T>.ConvertFrom_string(this.keyringudid));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.algorithm, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("algorithm", TypeConverter<T>.ConvertFrom_string(this.algorithm));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.keysize, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("keysize", TypeConverter<T>.ConvertFrom_long(this.keysize));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.encryptedkeypair64, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("encryptedkeypair64", TypeConverter<T>.ConvertFrom_string(this.encryptedkeypair64));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.publickey, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("publickey", TypeConverter<T>.ConvertFrom_string(this.publickey));
                
                break;
                
                case 1:
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.udid, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("udid", TypeConverter<T>.ConvertFrom_string(this.udid));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.keyringudid, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("keyringudid", TypeConverter<T>.ConvertFrom_string(this.keyringudid));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.algorithm, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("algorithm", TypeConverter<T>.ConvertFrom_string(this.algorithm));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.keysize, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("keysize", TypeConverter<T>.ConvertFrom_long(this.keysize));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.encryptedkeypair64, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("encryptedkeypair64", TypeConverter<T>.ConvertFrom_string(this.encryptedkeypair64));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.publickey, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("publickey", TypeConverter<T>.ConvertFrom_string(this.publickey));
                
                break;
                
                case 2:
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.udid, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("udid", TypeConverter<T>.ConvertFrom_string(this.udid));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.keyringudid, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("keyringudid", TypeConverter<T>.ConvertFrom_string(this.keyringudid));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.keypairtype, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("keypairtype", TypeConverter<T>.ConvertFrom_KMAKeyPairType(this.keypairtype));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.algorithm, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("algorithm", TypeConverter<T>.ConvertFrom_string(this.algorithm));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.keysize, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("keysize", TypeConverter<T>.ConvertFrom_long(this.keysize));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.encryptedkeypair64, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("encryptedkeypair64", TypeConverter<T>.ConvertFrom_string(this.encryptedkeypair64));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.publickey, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("publickey", TypeConverter<T>.ConvertFrom_string(this.publickey));
                
                break;
                
                case 3:
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.udid, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("udid", TypeConverter<T>.ConvertFrom_string(this.udid));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.keyringudid, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("keyringudid", TypeConverter<T>.ConvertFrom_string(this.keyringudid));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.keypairtype, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("keypairtype", TypeConverter<T>.ConvertFrom_KMAKeyPairType(this.keypairtype));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.algorithm, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("algorithm", TypeConverter<T>.ConvertFrom_string(this.algorithm));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.keysize, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("keysize", TypeConverter<T>.ConvertFrom_long(this.keysize));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.encryptedkeypair64, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("encryptedkeypair64", TypeConverter<T>.ConvertFrom_string(this.encryptedkeypair64));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.publickey, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("publickey", TypeConverter<T>.ConvertFrom_string(this.publickey));
                
                break;
                
                case 4:
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.udid, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("udid", TypeConverter<T>.ConvertFrom_string(this.udid));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.keyringudid, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("keyringudid", TypeConverter<T>.ConvertFrom_string(this.keyringudid));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.keypairtype, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("keypairtype", TypeConverter<T>.ConvertFrom_KMAKeyPairType(this.keypairtype));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.algorithm, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("algorithm", TypeConverter<T>.ConvertFrom_string(this.algorithm));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.encryptedkeypair64, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("encryptedkeypair64", TypeConverter<T>.ConvertFrom_string(this.encryptedkeypair64));
                
                if (StorageSchema.KMAKeyPair_descriptor.check_attribute(StorageSchema.KMAKeyPair_descriptor.publickey, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("publickey", TypeConverter<T>.ConvertFrom_string(this.publickey));
                
                break;
                
                default:
                Throw.incompatible_with_cell();
                break;
            }
            yield break;
        }
        #region enumerate value methods
        
        private IEnumerable<T> _enumerate_from_udid<T>()
        {
            
            switch (TypeConverter<T>.type_id)
            {
                
                case 0:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.udid);
                        
                    }
                    break;
                
                case 1:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.udid);
                        
                    }
                    break;
                
                case 2:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.udid);
                        
                    }
                    break;
                
                case 3:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.udid);
                        
                    }
                    break;
                
                case 4:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.udid);
                        
                    }
                    break;
                
                default:
                    Throw.incompatible_with_cell();
                    break;
            }
            yield break;
            
        }
        
        private IEnumerable<T> _enumerate_from_keyringudid<T>()
        {
            
            switch (TypeConverter<T>.type_id)
            {
                
                case 0:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.keyringudid);
                        
                    }
                    break;
                
                case 1:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.keyringudid);
                        
                    }
                    break;
                
                case 2:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.keyringudid);
                        
                    }
                    break;
                
                case 3:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.keyringudid);
                        
                    }
                    break;
                
                case 4:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.keyringudid);
                        
                    }
                    break;
                
                default:
                    Throw.incompatible_with_cell();
                    break;
            }
            yield break;
            
        }
        
        private IEnumerable<T> _enumerate_from_keypairtype<T>()
        {
            
            switch (TypeConverter<T>.type_id)
            {
                
                case 2:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_KMAKeyPairType(this.keypairtype);
                        
                    }
                    break;
                
                case 3:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_KMAKeyPairType(this.keypairtype);
                        
                    }
                    break;
                
                case 4:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_KMAKeyPairType(this.keypairtype);
                        
                    }
                    break;
                
                default:
                    Throw.incompatible_with_cell();
                    break;
            }
            yield break;
            
        }
        
        private IEnumerable<T> _enumerate_from_algorithm<T>()
        {
            
            switch (TypeConverter<T>.type_id)
            {
                
                case 0:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.algorithm);
                        
                    }
                    break;
                
                case 1:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.algorithm);
                        
                    }
                    break;
                
                case 2:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.algorithm);
                        
                    }
                    break;
                
                case 3:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.algorithm);
                        
                    }
                    break;
                
                case 4:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.algorithm);
                        
                    }
                    break;
                
                default:
                    Throw.incompatible_with_cell();
                    break;
            }
            yield break;
            
        }
        
        private IEnumerable<T> _enumerate_from_keysize<T>()
        {
            
            switch (TypeConverter<T>.type_id)
            {
                
                case 0:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_long(this.keysize);
                        
                    }
                    break;
                
                case 1:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_long(this.keysize);
                        
                    }
                    break;
                
                case 2:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_long(this.keysize);
                        
                    }
                    break;
                
                case 3:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_long(this.keysize);
                        
                    }
                    break;
                
                default:
                    Throw.incompatible_with_cell();
                    break;
            }
            yield break;
            
        }
        
        private IEnumerable<T> _enumerate_from_encryptedkeypair64<T>()
        {
            
            switch (TypeConverter<T>.type_id)
            {
                
                case 0:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.encryptedkeypair64);
                        
                    }
                    break;
                
                case 1:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.encryptedkeypair64);
                        
                    }
                    break;
                
                case 2:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.encryptedkeypair64);
                        
                    }
                    break;
                
                case 3:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.encryptedkeypair64);
                        
                    }
                    break;
                
                case 4:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.encryptedkeypair64);
                        
                    }
                    break;
                
                default:
                    Throw.incompatible_with_cell();
                    break;
            }
            yield break;
            
        }
        
        private IEnumerable<T> _enumerate_from_publickey<T>()
        {
            
            switch (TypeConverter<T>.type_id)
            {
                
                case 0:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.publickey);
                        
                    }
                    break;
                
                case 1:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.publickey);
                        
                    }
                    break;
                
                case 2:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.publickey);
                        
                    }
                    break;
                
                case 3:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.publickey);
                        
                    }
                    break;
                
                case 4:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.publickey);
                        
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
                return _enumerate_from_udid<T>();
                
                case 1:
                return _enumerate_from_keyringudid<T>();
                
                case 2:
                return _enumerate_from_keypairtype<T>();
                
                case 3:
                return _enumerate_from_algorithm<T>();
                
                case 4:
                return _enumerate_from_keysize<T>();
                
                case 5:
                return _enumerate_from_encryptedkeypair64<T>();
                
                case 6:
                return _enumerate_from_publickey<T>();
                
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
                
                foreach (var val in _enumerate_from_udid<T>())
                    yield return val;
                
                foreach (var val in _enumerate_from_keyringudid<T>())
                    yield return val;
                
                foreach (var val in _enumerate_from_keypairtype<T>())
                    yield return val;
                
                foreach (var val in _enumerate_from_algorithm<T>())
                    yield return val;
                
                foreach (var val in _enumerate_from_keysize<T>())
                    yield return val;
                
                foreach (var val in _enumerate_from_encryptedkeypair64<T>())
                    yield return val;
                
                foreach (var val in _enumerate_from_publickey<T>())
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
                yield return "udid";
            }
            
            {
                yield return "keyringudid";
            }
            
            {
                yield return "keypairtype";
            }
            
            {
                yield return "algorithm";
            }
            
            {
                yield return "keysize";
            }
            
            {
                yield return "encryptedkeypair64";
            }
            
            {
                yield return "publickey";
            }
            
        }
        IAttributeCollection ICellDescriptor.GetFieldAttributes(string fieldName)
        {
            return StorageSchema.KMAKeyPair.GetFieldAttributes(fieldName);
        }
        IEnumerable<IFieldDescriptor> ICellDescriptor.GetFieldDescriptors()
        {
            return StorageSchema.KMAKeyPair.GetFieldDescriptors();
        }
        string ITypeDescriptor.TypeName
        {
            get { return StorageSchema.s_cellTypeName_KMAKeyPair; }
        }
        Type ITypeDescriptor.Type
        {
            get { return StorageSchema.s_cellType_KMAKeyPair; }
        }
        bool ITypeDescriptor.IsOfType<T>()
        {
            return typeof(T) == StorageSchema.s_cellType_KMAKeyPair;
        }
        bool ITypeDescriptor.IsList()
        {
            return false;
        }
        IReadOnlyDictionary<string, string> IAttributeCollection.Attributes
        {
            get { return StorageSchema.KMAKeyPair.Attributes; }
        }
        string IAttributeCollection.GetAttributeValue(string attributeKey)
        {
            return StorageSchema.KMAKeyPair.GetAttributeValue(attributeKey);
        }
        ushort ICellDescriptor.CellType
        {
            get
            {
                return (ushort)CellType.KMAKeyPair;
            }
        }
        public ICellAccessor Serialize()
        {
            return this;
        }
        #endregion
        public ICell Deserialize()
        {
            return (KMAKeyPair)this;
        }
    }
    ///<summary>
    ///Provides interfaces for accessing KMAKeyPair cells
    ///on <see cref="Trinity.Storage.LocalMemorySotrage"/>.
    static public class StorageExtension_KMAKeyPair
    {
        #region IKeyValueStore non logging
        /// <summary>
        /// Adds a new cell of type KMAKeyPair to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. The value of the cell is specified in the method parameters.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.IKeyValueStore"/> instance.</param>
        /// <param name="cellId">A 64-bit cell Id.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveKMAKeyPair(this IKeyValueStore storage, long cellId, string udid = default(string), string keyringudid = default(string), KMAKeyPairType keypairtype = default(KMAKeyPairType), string algorithm = default(string), long keysize = default(long), string encryptedkeypair64 = default(string), string publickey = default(string))
        {
            
            byte* targetPtr;
            
            targetPtr = null;
            
            {

        if(udid!= null)
        {
            int strlen_2 = udid.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(keyringudid!= null)
        {
            int strlen_2 = keyringudid.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 1;

        if(algorithm!= null)
        {
            int strlen_2 = algorithm.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

        if(encryptedkeypair64!= null)
        {
            int strlen_2 = encryptedkeypair64.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(publickey!= null)
        {
            int strlen_2 = publickey.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            byte[] tmpcell = new byte[(int)(targetPtr)];
            fixed (byte* _tmpcellptr = tmpcell)
            {
                targetPtr = _tmpcellptr;
                
            {

        if(udid!= null)
        {
            int strlen_2 = udid.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = udid)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(keyringudid!= null)
        {
            int strlen_2 = keyringudid.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = keyringudid)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(KMAKeyPairType*)targetPtr = keypairtype;
            targetPtr += 1;

        if(algorithm!= null)
        {
            int strlen_2 = algorithm.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = algorithm)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = keysize;
            targetPtr += 8;

        if(encryptedkeypair64!= null)
        {
            int strlen_2 = encryptedkeypair64.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = encryptedkeypair64)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(publickey!= null)
        {
            int strlen_2 = publickey.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = publickey)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
            }
            
            return storage.SaveCell(cellId, tmpcell, (ushort)CellType.KMAKeyPair) == TrinityErrorCode.E_SUCCESS;
        }
        /// <summary>
        /// Adds a new cell of type KMAKeyPair to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. The parameter <paramref name="cellId"/> overrides the cell id in the content object.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.IKeyValueStore"/> instance.</param>
        /// <param name="cellId">A 64-bit cell Id.</param>
        /// <param name="cellContent">The content of the cell.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveKMAKeyPair(this IKeyValueStore storage, long cellId, KMAKeyPair cellContent)
        {
            return SaveKMAKeyPair(storage, cellId  , cellContent.udid  , cellContent.keyringudid  , cellContent.keypairtype  , cellContent.algorithm  , cellContent.keysize  , cellContent.encryptedkeypair64  , cellContent.publickey );
        }
        /// <summary>
        /// Adds a new cell of type KMAKeyPair to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. Cell Id is specified by the CellId field in the content object.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.IKeyValueStore"/> instance.</param>
        /// <param name="cellContent">The content of the cell.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveKMAKeyPair(this IKeyValueStore storage, KMAKeyPair cellContent)
        {
            return SaveKMAKeyPair(storage, cellContent.CellId  , cellContent.udid  , cellContent.keyringudid  , cellContent.keypairtype  , cellContent.algorithm  , cellContent.keysize  , cellContent.encryptedkeypair64  , cellContent.publickey );
        }
        /// <summary>
        /// Loads the content of the specified cell. Any changes done to this object are not written to the store, unless
        /// the content object is saved back into the storage.
        /// <param name="storage"/>A <see cref="Trinity.Storage.IKeyValueStore"/> instance.</param>
        /// </summary>
        public unsafe static KMAKeyPair LoadKMAKeyPair(this IKeyValueStore storage, long cellId)
        {
            if (TrinityErrorCode.E_SUCCESS == storage.LoadCell(cellId, out var buff))
            {
                fixed (byte* p = buff)
                {
                    return KMAKeyPair_Accessor._get()._Setup(cellId, p, -1, 0);
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
        /// the cell as a KMAKeyPair. Any changes done to the accessor
        /// are written to the storage immediately.
        /// If <c><see cref="Trinity.TrinityConfig.ReadOnly"/> == false</c>,
        /// on calling this method, it attempts to acquire the lock of the cell,
        /// and blocks until it gets the lock. Otherwise this method is wait-free.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">The id of the specified cell.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <returns>A <see cref="TDW.KMAServer.KMAKeyPair"/> instance.</returns>
        public unsafe static KMAKeyPair_Accessor UseKMAKeyPair(this Trinity.Storage.LocalMemoryStorage storage, long cellId, CellAccessOptions options)
        {
            return KMAKeyPair_Accessor._get()._Lock(cellId, options);
        }
        /// <summary>
        /// Allocate a cell accessor on the specified cell, which interprets
        /// the cell as a KMAKeyPair. Any changes done to the accessor
        /// are written to the storage immediately.
        /// If <c><see cref="Trinity.TrinityConfig.ReadOnly"/> == false</c>,
        /// on calling this method, it attempts to acquire the lock of the cell,
        /// and blocks until it gets the lock.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">The id of the specified cell.</param>
        /// <returns>A <see cref="" + script.RootNamespace + ".KMAKeyPair"/> instance.</returns>
        public unsafe static KMAKeyPair_Accessor UseKMAKeyPair(this Trinity.Storage.LocalMemoryStorage storage, long cellId)
        {
            return KMAKeyPair_Accessor._get()._Lock(cellId, CellAccessOptions.ThrowExceptionOnCellNotFound);
        }
        #endregion
        #region LocalStorage Non-Tx logging
        /// <summary>
        /// Adds a new cell of type KMAKeyPair to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. The value of the cell is specified in the method parameters.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">A 64-bit cell Id.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveKMAKeyPair(this Trinity.Storage.LocalMemoryStorage storage, CellAccessOptions options, long cellId, string udid = default(string), string keyringudid = default(string), KMAKeyPairType keypairtype = default(KMAKeyPairType), string algorithm = default(string), long keysize = default(long), string encryptedkeypair64 = default(string), string publickey = default(string))
        {
            
            byte* targetPtr;
            
            targetPtr = null;
            
            {

        if(udid!= null)
        {
            int strlen_2 = udid.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(keyringudid!= null)
        {
            int strlen_2 = keyringudid.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 1;

        if(algorithm!= null)
        {
            int strlen_2 = algorithm.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

        if(encryptedkeypair64!= null)
        {
            int strlen_2 = encryptedkeypair64.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(publickey!= null)
        {
            int strlen_2 = publickey.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            byte[] tmpcell = new byte[(int)(targetPtr)];
            fixed (byte* _tmpcellptr = tmpcell)
            {
                targetPtr = _tmpcellptr;
                
            {

        if(udid!= null)
        {
            int strlen_2 = udid.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = udid)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(keyringudid!= null)
        {
            int strlen_2 = keyringudid.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = keyringudid)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(KMAKeyPairType*)targetPtr = keypairtype;
            targetPtr += 1;

        if(algorithm!= null)
        {
            int strlen_2 = algorithm.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = algorithm)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = keysize;
            targetPtr += 8;

        if(encryptedkeypair64!= null)
        {
            int strlen_2 = encryptedkeypair64.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = encryptedkeypair64)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(publickey!= null)
        {
            int strlen_2 = publickey.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = publickey)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
            }
            
            return storage.SaveCell(options, cellId, tmpcell, 0, tmpcell.Length, (ushort)CellType.KMAKeyPair) == TrinityErrorCode.E_SUCCESS;
        }
        /// <summary>
        /// Adds a new cell of type KMAKeyPair to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. The parameter <paramref name="cellId"/> overrides the cell id in the content object.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">A 64-bit cell Id.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <param name="cellContent">The content of the cell.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveKMAKeyPair(this Trinity.Storage.LocalMemoryStorage storage, CellAccessOptions options, long cellId, KMAKeyPair cellContent)
        {
            return SaveKMAKeyPair(storage, options, cellId  , cellContent.udid  , cellContent.keyringudid  , cellContent.keypairtype  , cellContent.algorithm  , cellContent.keysize  , cellContent.encryptedkeypair64  , cellContent.publickey );
        }
        /// <summary>
        /// Adds a new cell of type KMAKeyPair to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. Cell Id is specified by the CellId field in the content object.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <param name="cellContent">The content of the cell.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveKMAKeyPair(this Trinity.Storage.LocalMemoryStorage storage, CellAccessOptions options, KMAKeyPair cellContent)
        {
            return SaveKMAKeyPair(storage, options, cellContent.CellId  , cellContent.udid  , cellContent.keyringudid  , cellContent.keypairtype  , cellContent.algorithm  , cellContent.keysize  , cellContent.encryptedkeypair64  , cellContent.publickey );
        }
        /// <summary>
        /// Loads the content of the specified cell. Any changes done to this object are not written to the store, unless
        /// the content object is saved back into the storage.
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// </summary>
        public unsafe static KMAKeyPair LoadKMAKeyPair(this Trinity.Storage.LocalMemoryStorage storage, long cellId)
        {
            using (var cell = KMAKeyPair_Accessor._get()._Lock(cellId, CellAccessOptions.ThrowExceptionOnCellNotFound))
            {
                return cell;
            }
        }
        #endregion
        #region LocalMemoryStorage Tx accessors
        /// <summary>
        /// Allocate a cell accessor on the specified cell, which interprets
        /// the cell as a KMAKeyPair. Any changes done to the accessor
        /// are written to the storage immediately.
        /// If <c><see cref="Trinity.TrinityConfig.ReadOnly"/> == false</c>,
        /// on calling this method, it attempts to acquire the lock of the cell,
        /// and blocks until it gets the lock. Otherwise this method is wait-free.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">The id of the specified cell.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <returns>A <see cref="TDW.KMAServer.KMAKeyPair"/> instance.</returns>
        public unsafe static KMAKeyPair_Accessor UseKMAKeyPair(this Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx, long cellId, CellAccessOptions options)
        {
            return KMAKeyPair_Accessor._get()._Lock(cellId, options, tx);
        }
        /// <summary>
        /// Allocate a cell accessor on the specified cell, which interprets
        /// the cell as a KMAKeyPair. Any changes done to the accessor
        /// are written to the storage immediately.
        /// If <c><see cref="Trinity.TrinityConfig.ReadOnly"/> == false</c>,
        /// on calling this method, it attempts to acquire the lock of the cell,
        /// and blocks until it gets the lock.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">The id of the specified cell.</param>
        /// <returns>A <see cref="" + script.RootNamespace + ".KMAKeyPair"/> instance.</returns>
        public unsafe static KMAKeyPair_Accessor UseKMAKeyPair(this Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx, long cellId)
        {
            return KMAKeyPair_Accessor._get()._Lock(cellId, CellAccessOptions.ThrowExceptionOnCellNotFound, tx);
        }
        #endregion
        #region LocalStorage Tx logging
        /// <summary>
        /// Adds a new cell of type KMAKeyPair to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. The value of the cell is specified in the method parameters.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">A 64-bit cell Id.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveKMAKeyPair(this Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx, CellAccessOptions options, long cellId, string udid = default(string), string keyringudid = default(string), KMAKeyPairType keypairtype = default(KMAKeyPairType), string algorithm = default(string), long keysize = default(long), string encryptedkeypair64 = default(string), string publickey = default(string))
        {
            
            byte* targetPtr;
            
            targetPtr = null;
            
            {

        if(udid!= null)
        {
            int strlen_2 = udid.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(keyringudid!= null)
        {
            int strlen_2 = keyringudid.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 1;

        if(algorithm!= null)
        {
            int strlen_2 = algorithm.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

        if(encryptedkeypair64!= null)
        {
            int strlen_2 = encryptedkeypair64.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(publickey!= null)
        {
            int strlen_2 = publickey.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            byte[] tmpcell = new byte[(int)(targetPtr)];
            fixed (byte* _tmpcellptr = tmpcell)
            {
                targetPtr = _tmpcellptr;
                
            {

        if(udid!= null)
        {
            int strlen_2 = udid.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = udid)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(keyringudid!= null)
        {
            int strlen_2 = keyringudid.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = keyringudid)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(KMAKeyPairType*)targetPtr = keypairtype;
            targetPtr += 1;

        if(algorithm!= null)
        {
            int strlen_2 = algorithm.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = algorithm)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = keysize;
            targetPtr += 8;

        if(encryptedkeypair64!= null)
        {
            int strlen_2 = encryptedkeypair64.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = encryptedkeypair64)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(publickey!= null)
        {
            int strlen_2 = publickey.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = publickey)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
            }
            
            return storage.SaveCell(tx, options, cellId, tmpcell, 0, tmpcell.Length, (ushort)CellType.KMAKeyPair) == TrinityErrorCode.E_SUCCESS;
        }
        /// <summary>
        /// Adds a new cell of type KMAKeyPair to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. The parameter <paramref name="cellId"/> overrides the cell id in the content object.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">A 64-bit cell Id.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <param name="cellContent">The content of the cell.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveKMAKeyPair(this Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx, CellAccessOptions options, long cellId, KMAKeyPair cellContent)
        {
            return SaveKMAKeyPair(storage, tx, options, cellId  , cellContent.udid  , cellContent.keyringudid  , cellContent.keypairtype  , cellContent.algorithm  , cellContent.keysize  , cellContent.encryptedkeypair64  , cellContent.publickey );
        }
        /// <summary>
        /// Adds a new cell of type KMAKeyPair to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. Cell Id is specified by the CellId field in the content object.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <param name="cellContent">The content of the cell.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveKMAKeyPair(this Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx, CellAccessOptions options, KMAKeyPair cellContent)
        {
            return SaveKMAKeyPair(storage, tx, options, cellContent.CellId  , cellContent.udid  , cellContent.keyringudid  , cellContent.keypairtype  , cellContent.algorithm  , cellContent.keysize  , cellContent.encryptedkeypair64  , cellContent.publickey );
        }
        /// <summary>
        /// Loads the content of the specified cell. Any changes done to this object are not written to the store, unless
        /// the content object is saved back into the storage.
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// </summary>
        public unsafe static KMAKeyPair LoadKMAKeyPair(this Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx, long cellId)
        {
            using (var cell = KMAKeyPair_Accessor._get()._Lock(cellId, CellAccessOptions.ThrowExceptionOnCellNotFound, tx))
            {
                return cell;
            }
        }
        #endregion
    }
}

#pragma warning restore 162,168,649,660,661,1522
