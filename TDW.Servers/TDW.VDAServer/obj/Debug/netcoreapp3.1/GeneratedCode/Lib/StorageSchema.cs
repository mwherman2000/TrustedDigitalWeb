#pragma warning disable 162,168,649,660,661,1522
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trinity.Storage;
using Trinity.TSL;
namespace TDW.VDAServer
{
    /// <summary>
    /// Exposes the data modeling schema defined in the TSL.
    /// </summary>
    public class StorageSchema : IStorageSchema
    {
        #region CellType lookup table
        internal static Dictionary<string, CellType> cellTypeLookupTable = new Dictionary<string, CellType>()
        {
            
            {"TRACredential_Cell", global::TDW.VDAServer.CellType.TRACredential_Cell}
            ,
            {"TDWVDAAccountEntryCell", global::TDW.VDAServer.CellType.TDWVDAAccountEntryCell}
            ,
            {"TDWVDASmartContractEntryCell", global::TDW.VDAServer.CellType.TDWVDASmartContractEntryCell}
            
        };
        #endregion
        
        internal static readonly Type   s_cellType_TRACredential_Cell       = typeof(global::TDW.VDAServer.TRACredential_Cell);
        internal static readonly string s_cellTypeName_TRACredential_Cell   = "TRACredential_Cell";
        internal class TRACredential_Cell_descriptor : ICellDescriptor
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
            
            internal class envelope_descriptor : IFieldDescriptor
            {
                private static IReadOnlyDictionary<string, string> s_attributes = new Dictionary<string, string>
                {
                    
                };
                private static string s_typename = "TRACredential_Envelope";
                private static Type   s_type     = typeof(TRACredential_Envelope);
                public string Name
                {
                    get { return "envelope"; }
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
            internal static envelope_descriptor envelope = new envelope_descriptor();
            
            internal class envelopeseal_descriptor : IFieldDescriptor
            {
                private static IReadOnlyDictionary<string, string> s_attributes = new Dictionary<string, string>
                {
                    
                };
                private static string s_typename = "TRACredential_EnvelopeSeal";
                private static Type   s_type     = typeof(TRACredential_EnvelopeSeal);
                public string Name
                {
                    get { return "envelopeseal"; }
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
            internal static envelopeseal_descriptor envelopeseal = new envelopeseal_descriptor();
            
            #region ICellDescriptor
            public IEnumerable<string> GetFieldNames()
            {
                
                yield return "envelope";
                
                yield return "envelopeseal";
                
            }
            public IAttributeCollection GetFieldAttributes(string fieldName)
            {
                int field_id = global::TDW.VDAServer.TRACredential_Cell.FieldLookupTable.Lookup(fieldName);
                if (field_id == -1)
                    Throw.undefined_field();
                switch (field_id)
                {
                    
                    case 0:
                        return envelope;
                    
                    case 1:
                        return envelopeseal;
                    
                }
                /* Should not reach here */
                throw new Exception("Internal error T6001");
            }
            public IEnumerable<IFieldDescriptor> GetFieldDescriptors()
            {
                
                yield return envelope;
                
                yield return envelopeseal;
                
            }
            ushort ICellDescriptor.CellType
            {
                get { return (ushort)CellType.TRACredential_Cell; }
            }
            #endregion
            #region ITypeDescriptor
            public string TypeName
            {
                get { return s_cellTypeName_TRACredential_Cell; }
            }
            public Type Type
            {
                get { return s_cellType_TRACredential_Cell; }
            }
            public bool IsOfType<T>()
            {
                return typeof(T) == s_cellType_TRACredential_Cell;
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
        internal static readonly TRACredential_Cell_descriptor s_cellDescriptor_TRACredential_Cell = new TRACredential_Cell_descriptor();
        /// <summary>
        /// Get the cell descriptor for TRACredential_Cell.
        /// </summary>
        public static ICellDescriptor TRACredential_Cell { get { return s_cellDescriptor_TRACredential_Cell; } }
        
        internal static readonly Type   s_cellType_TDWVDAAccountEntryCell       = typeof(global::TDW.VDAServer.TDWVDAAccountEntryCell);
        internal static readonly string s_cellTypeName_TDWVDAAccountEntryCell   = "TDWVDAAccountEntryCell";
        internal class TDWVDAAccountEntryCell_descriptor : ICellDescriptor
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
            
            internal class envelope_descriptor : IFieldDescriptor
            {
                private static IReadOnlyDictionary<string, string> s_attributes = new Dictionary<string, string>
                {
                    
                };
                private static string s_typename = "TDWVDAAccountEntryEnvelope";
                private static Type   s_type     = typeof(TDWVDAAccountEntryEnvelope);
                public string Name
                {
                    get { return "envelope"; }
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
            internal static envelope_descriptor envelope = new envelope_descriptor();
            
            internal class envelopeseal_descriptor : IFieldDescriptor
            {
                private static IReadOnlyDictionary<string, string> s_attributes = new Dictionary<string, string>
                {
                    
                };
                private static string s_typename = "TRACredential_EnvelopeSeal";
                private static Type   s_type     = typeof(TRACredential_EnvelopeSeal);
                public string Name
                {
                    get { return "envelopeseal"; }
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
            internal static envelopeseal_descriptor envelopeseal = new envelopeseal_descriptor();
            
            #region ICellDescriptor
            public IEnumerable<string> GetFieldNames()
            {
                
                yield return "envelope";
                
                yield return "envelopeseal";
                
            }
            public IAttributeCollection GetFieldAttributes(string fieldName)
            {
                int field_id = global::TDW.VDAServer.TDWVDAAccountEntryCell.FieldLookupTable.Lookup(fieldName);
                if (field_id == -1)
                    Throw.undefined_field();
                switch (field_id)
                {
                    
                    case 0:
                        return envelope;
                    
                    case 1:
                        return envelopeseal;
                    
                }
                /* Should not reach here */
                throw new Exception("Internal error T6001");
            }
            public IEnumerable<IFieldDescriptor> GetFieldDescriptors()
            {
                
                yield return envelope;
                
                yield return envelopeseal;
                
            }
            ushort ICellDescriptor.CellType
            {
                get { return (ushort)CellType.TDWVDAAccountEntryCell; }
            }
            #endregion
            #region ITypeDescriptor
            public string TypeName
            {
                get { return s_cellTypeName_TDWVDAAccountEntryCell; }
            }
            public Type Type
            {
                get { return s_cellType_TDWVDAAccountEntryCell; }
            }
            public bool IsOfType<T>()
            {
                return typeof(T) == s_cellType_TDWVDAAccountEntryCell;
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
        internal static readonly TDWVDAAccountEntryCell_descriptor s_cellDescriptor_TDWVDAAccountEntryCell = new TDWVDAAccountEntryCell_descriptor();
        /// <summary>
        /// Get the cell descriptor for TDWVDAAccountEntryCell.
        /// </summary>
        public static ICellDescriptor TDWVDAAccountEntryCell { get { return s_cellDescriptor_TDWVDAAccountEntryCell; } }
        
        internal static readonly Type   s_cellType_TDWVDASmartContractEntryCell       = typeof(global::TDW.VDAServer.TDWVDASmartContractEntryCell);
        internal static readonly string s_cellTypeName_TDWVDASmartContractEntryCell   = "TDWVDASmartContractEntryCell";
        internal class TDWVDASmartContractEntryCell_descriptor : ICellDescriptor
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
            
            internal class SmartContractEntryEnvelope_descriptor : IFieldDescriptor
            {
                private static IReadOnlyDictionary<string, string> s_attributes = new Dictionary<string, string>
                {
                    
                };
                private static string s_typename = "TDWVDASmartContractEntryEnvelope";
                private static Type   s_type     = typeof(TDWVDASmartContractEntryEnvelope);
                public string Name
                {
                    get { return "SmartContractEntryEnvelope"; }
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
            internal static SmartContractEntryEnvelope_descriptor SmartContractEntryEnvelope = new SmartContractEntryEnvelope_descriptor();
            
            internal class envelopeseal_descriptor : IFieldDescriptor
            {
                private static IReadOnlyDictionary<string, string> s_attributes = new Dictionary<string, string>
                {
                    
                };
                private static string s_typename = "TRACredential_EnvelopeSeal";
                private static Type   s_type     = typeof(TRACredential_EnvelopeSeal);
                public string Name
                {
                    get { return "envelopeseal"; }
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
            internal static envelopeseal_descriptor envelopeseal = new envelopeseal_descriptor();
            
            #region ICellDescriptor
            public IEnumerable<string> GetFieldNames()
            {
                
                yield return "SmartContractEntryEnvelope";
                
                yield return "envelopeseal";
                
            }
            public IAttributeCollection GetFieldAttributes(string fieldName)
            {
                int field_id = global::TDW.VDAServer.TDWVDASmartContractEntryCell.FieldLookupTable.Lookup(fieldName);
                if (field_id == -1)
                    Throw.undefined_field();
                switch (field_id)
                {
                    
                    case 0:
                        return SmartContractEntryEnvelope;
                    
                    case 1:
                        return envelopeseal;
                    
                }
                /* Should not reach here */
                throw new Exception("Internal error T6001");
            }
            public IEnumerable<IFieldDescriptor> GetFieldDescriptors()
            {
                
                yield return SmartContractEntryEnvelope;
                
                yield return envelopeseal;
                
            }
            ushort ICellDescriptor.CellType
            {
                get { return (ushort)CellType.TDWVDASmartContractEntryCell; }
            }
            #endregion
            #region ITypeDescriptor
            public string TypeName
            {
                get { return s_cellTypeName_TDWVDASmartContractEntryCell; }
            }
            public Type Type
            {
                get { return s_cellType_TDWVDASmartContractEntryCell; }
            }
            public bool IsOfType<T>()
            {
                return typeof(T) == s_cellType_TDWVDASmartContractEntryCell;
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
        internal static readonly TDWVDASmartContractEntryCell_descriptor s_cellDescriptor_TDWVDASmartContractEntryCell = new TDWVDASmartContractEntryCell_descriptor();
        /// <summary>
        /// Get the cell descriptor for TDWVDASmartContractEntryCell.
        /// </summary>
        public static ICellDescriptor TDWVDASmartContractEntryCell { get { return s_cellDescriptor_TDWVDASmartContractEntryCell; } }
        
        /// <summary>
        /// Enumerates descriptors for all cells defined in the TSL.
        /// </summary>
        public static IEnumerable<ICellDescriptor> CellDescriptors
        {
            get
            {
                
                yield return TRACredential_Cell;
                
                yield return TDWVDAAccountEntryCell;
                
                yield return TDWVDASmartContractEntryCell;
                
                yield break;
            }
        }
        /// <summary>
        /// Converts a type string to <see cref="TDW.VDAServer.CellType"/>.
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
                
                yield return "{{{string|List<string>|optional List<{string|optional string|optional List<{string|string}>|optional List<List<{string|string}>>}>|optional {string|string|string}}|{TRACredentialType|long|TRATrustLevel|TRAEncryptionFlag|string|optional string|optional string}}|{optional string|optional string|optional string|optional List<string>}}";
                
                yield return "{{optional {string|List<string>|optional {string|string|string|string}|optional {string|string|string}}|{TRACredentialType|long|TRATrustLevel|TRAEncryptionFlag|string|optional string|optional string}}|{optional string|optional string|optional string|optional List<string>}}";
                
                yield return "{{optional {string|List<string>|optional {string|string}|optional {string|string|string}}|{TRACredentialType|long|TRATrustLevel|TRAEncryptionFlag|string|optional string|optional string}}|{optional string|optional string|optional string|optional List<string>}}";
                
                yield break;
            }
        }
        #endregion
    }
}

#pragma warning restore 162,168,649,660,661,1522
