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
            
            {"TRACredentialCell", global::TDW.TRAServer.CellType.TRACredentialCell}
            ,
            {"TRATimestampCell", global::TDW.TRAServer.CellType.TRATimestampCell}
            ,
            {"TDWGeoLocationCell", global::TDW.TRAServer.CellType.TDWGeoLocationCell}
            ,
            {"TRAPostalAddressCell", global::TDW.TRAServer.CellType.TRAPostalAddressCell}
            
        };
        #endregion
        
        internal static readonly Type   s_cellType_TRACredentialCell       = typeof(global::TDW.TRAServer.TRACredentialCell);
        internal static readonly string s_cellTypeName_TRACredentialCell   = "TRACredentialCell";
        internal class TRACredentialCell_descriptor : ICellDescriptor
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
                private static string s_typename = "TRACredentialEnvelope";
                private static Type   s_type     = typeof(TRACredentialEnvelope);
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
                private static string s_typename = "TRACredentialEnvelopeSeal";
                private static Type   s_type     = typeof(TRACredentialEnvelopeSeal);
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
                int field_id = global::TDW.TRAServer.TRACredentialCell.FieldLookupTable.Lookup(fieldName);
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
                get { return (ushort)CellType.TRACredentialCell; }
            }
            #endregion
            #region ITypeDescriptor
            public string TypeName
            {
                get { return s_cellTypeName_TRACredentialCell; }
            }
            public Type Type
            {
                get { return s_cellType_TRACredentialCell; }
            }
            public bool IsOfType<T>()
            {
                return typeof(T) == s_cellType_TRACredentialCell;
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
        internal static readonly TRACredentialCell_descriptor s_cellDescriptor_TRACredentialCell = new TRACredentialCell_descriptor();
        /// <summary>
        /// Get the cell descriptor for TRACredentialCell.
        /// </summary>
        public static ICellDescriptor TRACredentialCell { get { return s_cellDescriptor_TRACredentialCell; } }
        
        internal static readonly Type   s_cellType_TRATimestampCell       = typeof(global::TDW.TRAServer.TRATimestampCell);
        internal static readonly string s_cellTypeName_TRATimestampCell   = "TRATimestampCell";
        internal class TRATimestampCell_descriptor : ICellDescriptor
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
                private static string s_typename = "TRATimestampEnvelope";
                private static Type   s_type     = typeof(TRATimestampEnvelope);
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
                private static string s_typename = "TRACredentialEnvelopeSeal";
                private static Type   s_type     = typeof(TRACredentialEnvelopeSeal);
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
                int field_id = global::TDW.TRAServer.TRATimestampCell.FieldLookupTable.Lookup(fieldName);
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
                get { return (ushort)CellType.TRATimestampCell; }
            }
            #endregion
            #region ITypeDescriptor
            public string TypeName
            {
                get { return s_cellTypeName_TRATimestampCell; }
            }
            public Type Type
            {
                get { return s_cellType_TRATimestampCell; }
            }
            public bool IsOfType<T>()
            {
                return typeof(T) == s_cellType_TRATimestampCell;
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
        internal static readonly TRATimestampCell_descriptor s_cellDescriptor_TRATimestampCell = new TRATimestampCell_descriptor();
        /// <summary>
        /// Get the cell descriptor for TRATimestampCell.
        /// </summary>
        public static ICellDescriptor TRATimestampCell { get { return s_cellDescriptor_TRATimestampCell; } }
        
        internal static readonly Type   s_cellType_TDWGeoLocationCell       = typeof(global::TDW.TRAServer.TDWGeoLocationCell);
        internal static readonly string s_cellTypeName_TDWGeoLocationCell   = "TDWGeoLocationCell";
        internal class TDWGeoLocationCell_descriptor : ICellDescriptor
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
                private static string s_typename = "TRAGeoLocationEnvelope";
                private static Type   s_type     = typeof(TRAGeoLocationEnvelope);
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
                private static string s_typename = "TRACredentialEnvelopeSeal";
                private static Type   s_type     = typeof(TRACredentialEnvelopeSeal);
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
                int field_id = global::TDW.TRAServer.TDWGeoLocationCell.FieldLookupTable.Lookup(fieldName);
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
                get { return (ushort)CellType.TDWGeoLocationCell; }
            }
            #endregion
            #region ITypeDescriptor
            public string TypeName
            {
                get { return s_cellTypeName_TDWGeoLocationCell; }
            }
            public Type Type
            {
                get { return s_cellType_TDWGeoLocationCell; }
            }
            public bool IsOfType<T>()
            {
                return typeof(T) == s_cellType_TDWGeoLocationCell;
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
        internal static readonly TDWGeoLocationCell_descriptor s_cellDescriptor_TDWGeoLocationCell = new TDWGeoLocationCell_descriptor();
        /// <summary>
        /// Get the cell descriptor for TDWGeoLocationCell.
        /// </summary>
        public static ICellDescriptor TDWGeoLocationCell { get { return s_cellDescriptor_TDWGeoLocationCell; } }
        
        internal static readonly Type   s_cellType_TRAPostalAddressCell       = typeof(global::TDW.TRAServer.TRAPostalAddressCell);
        internal static readonly string s_cellTypeName_TRAPostalAddressCell   = "TRAPostalAddressCell";
        internal class TRAPostalAddressCell_descriptor : ICellDescriptor
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
                private static string s_typename = "TRAPostalAddressEnvelope";
                private static Type   s_type     = typeof(TRAPostalAddressEnvelope);
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
                private static string s_typename = "TRACredentialEnvelopeSeal";
                private static Type   s_type     = typeof(TRACredentialEnvelopeSeal);
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
                int field_id = global::TDW.TRAServer.TRAPostalAddressCell.FieldLookupTable.Lookup(fieldName);
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
                get { return (ushort)CellType.TRAPostalAddressCell; }
            }
            #endregion
            #region ITypeDescriptor
            public string TypeName
            {
                get { return s_cellTypeName_TRAPostalAddressCell; }
            }
            public Type Type
            {
                get { return s_cellType_TRAPostalAddressCell; }
            }
            public bool IsOfType<T>()
            {
                return typeof(T) == s_cellType_TRAPostalAddressCell;
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
        internal static readonly TRAPostalAddressCell_descriptor s_cellDescriptor_TRAPostalAddressCell = new TRAPostalAddressCell_descriptor();
        /// <summary>
        /// Get the cell descriptor for TRAPostalAddressCell.
        /// </summary>
        public static ICellDescriptor TRAPostalAddressCell { get { return s_cellDescriptor_TRAPostalAddressCell; } }
        
        /// <summary>
        /// Enumerates descriptors for all cells defined in the TSL.
        /// </summary>
        public static IEnumerable<ICellDescriptor> CellDescriptors
        {
            get
            {
                
                yield return TRACredentialCell;
                
                yield return TRATimestampCell;
                
                yield return TDWGeoLocationCell;
                
                yield return TRAPostalAddressCell;
                
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
                
                yield return "{{optional {string|List<string>|List<{string|optional string|optional List<{string|string}>|optional List<List<{string|string}>>}>}|optional string|{TRACredentialType|long|TRATrustLevel|TRAEncryptionFlag|string|optional string|optional string}}|{optional string|optional string|optional string|optional List<string>}}";
                
                yield return "{{optional {string|List<string>|{long|DateTime|string}}|optional string|{TRACredentialType|long|TRATrustLevel|TRAEncryptionFlag|string|optional string|optional string}}|{optional string|optional string|optional string|optional List<string>}}";
                
                yield return "{{optional {string|List<string>|{double|double}}|optional string|{TRACredentialType|long|TRATrustLevel|TRAEncryptionFlag|string|optional string|optional string}}|{optional string|optional string|optional string|optional List<string>}}";
                
                yield return "{{optional {string|List<string>|{string|string|string|string|string|string}}|optional string|{TRACredentialType|long|TRATrustLevel|TRAEncryptionFlag|string|optional string|optional string}}|{optional string|optional string|optional string|optional List<string>}}";
                
                yield break;
            }
        }
        #endregion
    }
}

#pragma warning restore 162,168,649,660,661,1522
