#pragma warning disable 162,168,649,660,661,1522
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trinity.Storage;
using Trinity.TSL;
namespace TDW.TRAServer
{
    /// <summary>
    /// Exposes the data modeling schema defined in the TSL.
    /// </summary>
    public class StorageSchema : IStorageSchema
    {
        #region CellType lookup table
        internal static Dictionary<string, CellType> cellTypeLookupTable = new Dictionary<string, CellType>()
        {
            
            {"TDWCredential", global::TDW.TRAServer.CellType.TDWCredential}
            
        };
        #endregion
        
        internal static readonly Type   s_cellType_TDWCredential       = typeof(global::TDW.TRAServer.TDWCredential);
        internal static readonly string s_cellTypeName_TDWCredential   = "TDWCredential";
        internal class TDWCredential_descriptor : ICellDescriptor
        {
            private static IReadOnlyDictionary<string, string> s_attributes = new Dictionary<string, string>
            {
                
            };
            internal static bool check_attribute(IAttributeCollection attributes, string attributeKey, string attributeValue)
            {
                if (attributeKey == null)
                    return true;
                if (attributeValue == null)
                    return attributes.Attributes.ContainsKey(attributeKey);
                else
                    return attributes.Attributes.ContainsKey(attributeKey) && attributes.Attributes[attributeKey] == attributeValue;
            }
            
            internal class CredentialCore_descriptor : IFieldDescriptor
            {
                private static IReadOnlyDictionary<string, string> s_attributes = new Dictionary<string, string>
                {
                    
                };
                private static string s_typename = "TRACredentialCore";
                private static Type   s_type     = typeof(TRACredentialCore);
                public string Name
                {
                    get { return "CredentialCore"; }
                }
                public bool Optional
                {
                    get
                    {
                        
                        return false;
                        
                    }
                }
                public bool IsOfType<T>()
                {
                    return typeof(T) == Type;
                }
                public bool IsList()
                {
                    
                    return false;
                    
                }
                public string TypeName
                {
                    get { return s_typename; }
                }
                public Type Type
                {
                    get { return s_type; }
                }
                public IReadOnlyDictionary<string, string> Attributes
                {
                    get { return s_attributes; }
                }
                public string GetAttributeValue(string attributeKey)
                {
                    string ret = null;
                    s_attributes.TryGetValue(attributeKey, out ret);
                    return ret;
                }
            }
            internal static CredentialCore_descriptor CredentialCore = new CredentialCore_descriptor();
            
            internal class Envelope_descriptor : IFieldDescriptor
            {
                private static IReadOnlyDictionary<string, string> s_attributes = new Dictionary<string, string>
                {
                    
                };
                private static string s_typename = "TRAEnvelope";
                private static Type   s_type     = typeof(TRAEnvelope);
                public string Name
                {
                    get { return "Envelope"; }
                }
                public bool Optional
                {
                    get
                    {
                        
                        return false;
                        
                    }
                }
                public bool IsOfType<T>()
                {
                    return typeof(T) == Type;
                }
                public bool IsList()
                {
                    
                    return false;
                    
                }
                public string TypeName
                {
                    get { return s_typename; }
                }
                public Type Type
                {
                    get { return s_type; }
                }
                public IReadOnlyDictionary<string, string> Attributes
                {
                    get { return s_attributes; }
                }
                public string GetAttributeValue(string attributeKey)
                {
                    string ret = null;
                    s_attributes.TryGetValue(attributeKey, out ret);
                    return ret;
                }
            }
            internal static Envelope_descriptor Envelope = new Envelope_descriptor();
            
            internal class EncryptedCredentialCore_descriptor : IFieldDescriptor
            {
                private static IReadOnlyDictionary<string, string> s_attributes = new Dictionary<string, string>
                {
                    
                };
                private static string s_typename = "string";
                private static Type   s_type     = typeof(string);
                public string Name
                {
                    get { return "EncryptedCredentialCore"; }
                }
                public bool Optional
                {
                    get
                    {
                        
                        return true;
                        
                    }
                }
                public bool IsOfType<T>()
                {
                    return typeof(T) == Type;
                }
                public bool IsList()
                {
                    
                    return false;
                    
                }
                public string TypeName
                {
                    get { return s_typename; }
                }
                public Type Type
                {
                    get { return s_type; }
                }
                public IReadOnlyDictionary<string, string> Attributes
                {
                    get { return s_attributes; }
                }
                public string GetAttributeValue(string attributeKey)
                {
                    string ret = null;
                    s_attributes.TryGetValue(attributeKey, out ret);
                    return ret;
                }
            }
            internal static EncryptedCredentialCore_descriptor EncryptedCredentialCore = new EncryptedCredentialCore_descriptor();
            
            #region ICellDescriptor
            public IEnumerable<string> GetFieldNames()
            {
                
                yield return "CredentialCore";
                
                yield return "Envelope";
                
                yield return "EncryptedCredentialCore";
                
            }
            public IAttributeCollection GetFieldAttributes(string fieldName)
            {
                int field_id = global::TDW.TRAServer.TDWCredential.FieldLookupTable.Lookup(fieldName);
                if (field_id == -1)
                    Throw.undefined_field();
                switch (field_id)
                {
                    
                    case 0:
                        return CredentialCore;
                    
                    case 1:
                        return Envelope;
                    
                    case 2:
                        return EncryptedCredentialCore;
                    
                }
                /* Should not reach here */
                throw new Exception("Internal error T6001");
            }
            public IEnumerable<IFieldDescriptor> GetFieldDescriptors()
            {
                
                yield return CredentialCore;
                
                yield return Envelope;
                
                yield return EncryptedCredentialCore;
                
            }
            ushort ICellDescriptor.CellType
            {
                get { return (ushort)CellType.TDWCredential; }
            }
            #endregion
            #region ITypeDescriptor
            public string TypeName
            {
                get { return s_cellTypeName_TDWCredential; }
            }
            public Type Type
            {
                get { return s_cellType_TDWCredential; }
            }
            public bool IsOfType<T>()
            {
                return typeof(T) == s_cellType_TDWCredential;
            }
            public bool IsList()
            {
                return false;
            }
            #endregion
            #region IAttributeCollection
            public IReadOnlyDictionary<string, string> Attributes
            {
                get { return s_attributes; }
            }
            public string GetAttributeValue(string attributeKey)
            {
                string ret = null;
                s_attributes.TryGetValue(attributeKey, out ret);
                return ret;
            }
            #endregion
        }
        internal static readonly TDWCredential_descriptor s_cellDescriptor_TDWCredential = new TDWCredential_descriptor();
        /// <summary>
        /// Get the cell descriptor for TDWCredential.
        /// </summary>
        public static ICellDescriptor TDWCredential { get { return s_cellDescriptor_TDWCredential; } }
        
        /// <summary>
        /// Enumerates descriptors for all cells defined in the TSL.
        /// </summary>
        public static IEnumerable<ICellDescriptor> CellDescriptors
        {
            get
            {
                
                yield return TDWCredential;
                
                yield break;
            }
        }
        /// <summary>
        /// Converts a type string to <see cref="TDW.TRAServer.CellType"/>.
        /// </summary>
        /// <param name="cellTypeString">The type string to be converted.</param>
        /// <returns>The converted cell type.</returns>
        public static CellType GetCellType(string cellTypeString)
        {
            CellType ret;
            if (!cellTypeLookupTable.TryGetValue(cellTypeString, out ret))
                throw new Exception("Unrecognized cell type string.");
            return ret;
        }
        #region IStorageSchema implementation
        IEnumerable<ICellDescriptor> IStorageSchema.CellDescriptors
        {
            get { return StorageSchema.CellDescriptors; }
        }
        ushort IStorageSchema.GetCellType(string cellTypeString)
        {
            return (ushort)StorageSchema.GetCellType(cellTypeString);
        }
        IEnumerable<string> IStorageSchema.CellTypeSignatures
        {
            get
            {
                
                yield return "{{string|List<string>|List<{string|optional string|optional List<{string|string}>|optional List<List<{string|string}>>}>}|{TRACredentialType|TRAEncryptionFlag|optional string|optional string|optional string|optional List<string>}|optional string}";
                
                yield break;
            }
        }
        #endregion
    }
}

#pragma warning restore 162,168,649,660,661,1522
