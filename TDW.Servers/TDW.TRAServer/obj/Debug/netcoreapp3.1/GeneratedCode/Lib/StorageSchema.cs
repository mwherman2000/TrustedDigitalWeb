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
            
            {"TRACredential_Cell", global::TDW.TRAServer.CellType.TRACredential_Cell}
            ,
            {"TRATimestampCell", global::TDW.TRAServer.CellType.TRATimestampCell}
            ,
            {"TDWGeoLocationCell", global::TDW.TRAServer.CellType.TDWGeoLocationCell}
            ,
            {"TRAPostalAddressCell", global::TDW.TRAServer.CellType.TRAPostalAddressCell}
            ,
            {"Cac_Item_Cell", global::TDW.TRAServer.CellType.Cac_Item_Cell}
            ,
            {"Cac_ExternalReference_Cell", global::TDW.TRAServer.CellType.Cac_ExternalReference_Cell}
            ,
            {"Cac_Address_Cell", global::TDW.TRAServer.CellType.Cac_Address_Cell}
            ,
            {"Cac_PostalAddress_Cell", global::TDW.TRAServer.CellType.Cac_PostalAddress_Cell}
            ,
            {"Cac_PartyLegalEntity_Cell", global::TDW.TRAServer.CellType.Cac_PartyLegalEntity_Cell}
            ,
            {"Cac_Contact_Cell", global::TDW.TRAServer.CellType.Cac_Contact_Cell}
            ,
            {"Cac_Person_Cell", global::TDW.TRAServer.CellType.Cac_Person_Cell}
            ,
            {"Cac_PaymentMeans_Cell", global::TDW.TRAServer.CellType.Cac_PaymentMeans_Cell}
            ,
            {"Cac_PayeeFinancialAccount_Cell", global::TDW.TRAServer.CellType.Cac_PayeeFinancialAccount_Cell}
            ,
            {"Cac_Party_Cell", global::TDW.TRAServer.CellType.Cac_Party_Cell}
            ,
            {"UBL21_Invoice2_Cell", global::TDW.TRAServer.CellType.UBL21_Invoice2_Cell}
            
        };
        #endregion
        
        internal static readonly Type   s_cellType_TRACredential_Cell       = typeof(global::TDW.TRAServer.TRACredential_Cell);
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
                int field_id = global::TDW.TRAServer.TRACredential_Cell.FieldLookupTable.Lookup(fieldName);
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
        
        internal static readonly Type   s_cellType_Cac_Item_Cell       = typeof(global::TDW.TRAServer.Cac_Item_Cell);
        internal static readonly string s_cellTypeName_Cac_Item_Cell   = "Cac_Item_Cell";
        internal class Cac_Item_Cell_descriptor : ICellDescriptor
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
                private static string s_typename = "Cac_Item_Envelope";
                private static Type   s_type     = typeof(Cac_Item_Envelope);
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
                int field_id = global::TDW.TRAServer.Cac_Item_Cell.FieldLookupTable.Lookup(fieldName);
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
                get { return (ushort)CellType.Cac_Item_Cell; }
            }
            #endregion
            #region ITypeDescriptor
            public string TypeName
            {
                get { return s_cellTypeName_Cac_Item_Cell; }
            }
            public Type Type
            {
                get { return s_cellType_Cac_Item_Cell; }
            }
            public bool IsOfType<T>()
            {
                return typeof(T) == s_cellType_Cac_Item_Cell;
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
        internal static readonly Cac_Item_Cell_descriptor s_cellDescriptor_Cac_Item_Cell = new Cac_Item_Cell_descriptor();
        /// <summary>
        /// Get the cell descriptor for Cac_Item_Cell.
        /// </summary>
        public static ICellDescriptor Cac_Item_Cell { get { return s_cellDescriptor_Cac_Item_Cell; } }
        
        internal static readonly Type   s_cellType_Cac_ExternalReference_Cell       = typeof(global::TDW.TRAServer.Cac_ExternalReference_Cell);
        internal static readonly string s_cellTypeName_Cac_ExternalReference_Cell   = "Cac_ExternalReference_Cell";
        internal class Cac_ExternalReference_Cell_descriptor : ICellDescriptor
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
                private static string s_typename = "Cac_ExternalReference_Envelope";
                private static Type   s_type     = typeof(Cac_ExternalReference_Envelope);
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
                int field_id = global::TDW.TRAServer.Cac_ExternalReference_Cell.FieldLookupTable.Lookup(fieldName);
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
                get { return (ushort)CellType.Cac_ExternalReference_Cell; }
            }
            #endregion
            #region ITypeDescriptor
            public string TypeName
            {
                get { return s_cellTypeName_Cac_ExternalReference_Cell; }
            }
            public Type Type
            {
                get { return s_cellType_Cac_ExternalReference_Cell; }
            }
            public bool IsOfType<T>()
            {
                return typeof(T) == s_cellType_Cac_ExternalReference_Cell;
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
        internal static readonly Cac_ExternalReference_Cell_descriptor s_cellDescriptor_Cac_ExternalReference_Cell = new Cac_ExternalReference_Cell_descriptor();
        /// <summary>
        /// Get the cell descriptor for Cac_ExternalReference_Cell.
        /// </summary>
        public static ICellDescriptor Cac_ExternalReference_Cell { get { return s_cellDescriptor_Cac_ExternalReference_Cell; } }
        
        internal static readonly Type   s_cellType_Cac_Address_Cell       = typeof(global::TDW.TRAServer.Cac_Address_Cell);
        internal static readonly string s_cellTypeName_Cac_Address_Cell   = "Cac_Address_Cell";
        internal class Cac_Address_Cell_descriptor : ICellDescriptor
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
                private static string s_typename = "Cac_Address_Envelope";
                private static Type   s_type     = typeof(Cac_Address_Envelope);
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
                int field_id = global::TDW.TRAServer.Cac_Address_Cell.FieldLookupTable.Lookup(fieldName);
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
                get { return (ushort)CellType.Cac_Address_Cell; }
            }
            #endregion
            #region ITypeDescriptor
            public string TypeName
            {
                get { return s_cellTypeName_Cac_Address_Cell; }
            }
            public Type Type
            {
                get { return s_cellType_Cac_Address_Cell; }
            }
            public bool IsOfType<T>()
            {
                return typeof(T) == s_cellType_Cac_Address_Cell;
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
        internal static readonly Cac_Address_Cell_descriptor s_cellDescriptor_Cac_Address_Cell = new Cac_Address_Cell_descriptor();
        /// <summary>
        /// Get the cell descriptor for Cac_Address_Cell.
        /// </summary>
        public static ICellDescriptor Cac_Address_Cell { get { return s_cellDescriptor_Cac_Address_Cell; } }
        
        internal static readonly Type   s_cellType_Cac_PostalAddress_Cell       = typeof(global::TDW.TRAServer.Cac_PostalAddress_Cell);
        internal static readonly string s_cellTypeName_Cac_PostalAddress_Cell   = "Cac_PostalAddress_Cell";
        internal class Cac_PostalAddress_Cell_descriptor : ICellDescriptor
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
                private static string s_typename = "Cac_Address_Envelope";
                private static Type   s_type     = typeof(Cac_Address_Envelope);
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
                int field_id = global::TDW.TRAServer.Cac_PostalAddress_Cell.FieldLookupTable.Lookup(fieldName);
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
                get { return (ushort)CellType.Cac_PostalAddress_Cell; }
            }
            #endregion
            #region ITypeDescriptor
            public string TypeName
            {
                get { return s_cellTypeName_Cac_PostalAddress_Cell; }
            }
            public Type Type
            {
                get { return s_cellType_Cac_PostalAddress_Cell; }
            }
            public bool IsOfType<T>()
            {
                return typeof(T) == s_cellType_Cac_PostalAddress_Cell;
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
        internal static readonly Cac_PostalAddress_Cell_descriptor s_cellDescriptor_Cac_PostalAddress_Cell = new Cac_PostalAddress_Cell_descriptor();
        /// <summary>
        /// Get the cell descriptor for Cac_PostalAddress_Cell.
        /// </summary>
        public static ICellDescriptor Cac_PostalAddress_Cell { get { return s_cellDescriptor_Cac_PostalAddress_Cell; } }
        
        internal static readonly Type   s_cellType_Cac_PartyLegalEntity_Cell       = typeof(global::TDW.TRAServer.Cac_PartyLegalEntity_Cell);
        internal static readonly string s_cellTypeName_Cac_PartyLegalEntity_Cell   = "Cac_PartyLegalEntity_Cell";
        internal class Cac_PartyLegalEntity_Cell_descriptor : ICellDescriptor
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
                private static string s_typename = "Cac_PartyLegalEntity_Envelope";
                private static Type   s_type     = typeof(Cac_PartyLegalEntity_Envelope);
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
                int field_id = global::TDW.TRAServer.Cac_PartyLegalEntity_Cell.FieldLookupTable.Lookup(fieldName);
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
                get { return (ushort)CellType.Cac_PartyLegalEntity_Cell; }
            }
            #endregion
            #region ITypeDescriptor
            public string TypeName
            {
                get { return s_cellTypeName_Cac_PartyLegalEntity_Cell; }
            }
            public Type Type
            {
                get { return s_cellType_Cac_PartyLegalEntity_Cell; }
            }
            public bool IsOfType<T>()
            {
                return typeof(T) == s_cellType_Cac_PartyLegalEntity_Cell;
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
        internal static readonly Cac_PartyLegalEntity_Cell_descriptor s_cellDescriptor_Cac_PartyLegalEntity_Cell = new Cac_PartyLegalEntity_Cell_descriptor();
        /// <summary>
        /// Get the cell descriptor for Cac_PartyLegalEntity_Cell.
        /// </summary>
        public static ICellDescriptor Cac_PartyLegalEntity_Cell { get { return s_cellDescriptor_Cac_PartyLegalEntity_Cell; } }
        
        internal static readonly Type   s_cellType_Cac_Contact_Cell       = typeof(global::TDW.TRAServer.Cac_Contact_Cell);
        internal static readonly string s_cellTypeName_Cac_Contact_Cell   = "Cac_Contact_Cell";
        internal class Cac_Contact_Cell_descriptor : ICellDescriptor
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
                private static string s_typename = "Cac_Contact_Envelope";
                private static Type   s_type     = typeof(Cac_Contact_Envelope);
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
                int field_id = global::TDW.TRAServer.Cac_Contact_Cell.FieldLookupTable.Lookup(fieldName);
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
                get { return (ushort)CellType.Cac_Contact_Cell; }
            }
            #endregion
            #region ITypeDescriptor
            public string TypeName
            {
                get { return s_cellTypeName_Cac_Contact_Cell; }
            }
            public Type Type
            {
                get { return s_cellType_Cac_Contact_Cell; }
            }
            public bool IsOfType<T>()
            {
                return typeof(T) == s_cellType_Cac_Contact_Cell;
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
        internal static readonly Cac_Contact_Cell_descriptor s_cellDescriptor_Cac_Contact_Cell = new Cac_Contact_Cell_descriptor();
        /// <summary>
        /// Get the cell descriptor for Cac_Contact_Cell.
        /// </summary>
        public static ICellDescriptor Cac_Contact_Cell { get { return s_cellDescriptor_Cac_Contact_Cell; } }
        
        internal static readonly Type   s_cellType_Cac_Person_Cell       = typeof(global::TDW.TRAServer.Cac_Person_Cell);
        internal static readonly string s_cellTypeName_Cac_Person_Cell   = "Cac_Person_Cell";
        internal class Cac_Person_Cell_descriptor : ICellDescriptor
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
                private static string s_typename = "Cac_Person_Envelope";
                private static Type   s_type     = typeof(Cac_Person_Envelope);
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
                int field_id = global::TDW.TRAServer.Cac_Person_Cell.FieldLookupTable.Lookup(fieldName);
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
                get { return (ushort)CellType.Cac_Person_Cell; }
            }
            #endregion
            #region ITypeDescriptor
            public string TypeName
            {
                get { return s_cellTypeName_Cac_Person_Cell; }
            }
            public Type Type
            {
                get { return s_cellType_Cac_Person_Cell; }
            }
            public bool IsOfType<T>()
            {
                return typeof(T) == s_cellType_Cac_Person_Cell;
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
        internal static readonly Cac_Person_Cell_descriptor s_cellDescriptor_Cac_Person_Cell = new Cac_Person_Cell_descriptor();
        /// <summary>
        /// Get the cell descriptor for Cac_Person_Cell.
        /// </summary>
        public static ICellDescriptor Cac_Person_Cell { get { return s_cellDescriptor_Cac_Person_Cell; } }
        
        internal static readonly Type   s_cellType_Cac_PaymentMeans_Cell       = typeof(global::TDW.TRAServer.Cac_PaymentMeans_Cell);
        internal static readonly string s_cellTypeName_Cac_PaymentMeans_Cell   = "Cac_PaymentMeans_Cell";
        internal class Cac_PaymentMeans_Cell_descriptor : ICellDescriptor
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
                private static string s_typename = "Cac_PaymentMeans_Envelope";
                private static Type   s_type     = typeof(Cac_PaymentMeans_Envelope);
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
                int field_id = global::TDW.TRAServer.Cac_PaymentMeans_Cell.FieldLookupTable.Lookup(fieldName);
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
                get { return (ushort)CellType.Cac_PaymentMeans_Cell; }
            }
            #endregion
            #region ITypeDescriptor
            public string TypeName
            {
                get { return s_cellTypeName_Cac_PaymentMeans_Cell; }
            }
            public Type Type
            {
                get { return s_cellType_Cac_PaymentMeans_Cell; }
            }
            public bool IsOfType<T>()
            {
                return typeof(T) == s_cellType_Cac_PaymentMeans_Cell;
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
        internal static readonly Cac_PaymentMeans_Cell_descriptor s_cellDescriptor_Cac_PaymentMeans_Cell = new Cac_PaymentMeans_Cell_descriptor();
        /// <summary>
        /// Get the cell descriptor for Cac_PaymentMeans_Cell.
        /// </summary>
        public static ICellDescriptor Cac_PaymentMeans_Cell { get { return s_cellDescriptor_Cac_PaymentMeans_Cell; } }
        
        internal static readonly Type   s_cellType_Cac_PayeeFinancialAccount_Cell       = typeof(global::TDW.TRAServer.Cac_PayeeFinancialAccount_Cell);
        internal static readonly string s_cellTypeName_Cac_PayeeFinancialAccount_Cell   = "Cac_PayeeFinancialAccount_Cell";
        internal class Cac_PayeeFinancialAccount_Cell_descriptor : ICellDescriptor
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
                private static string s_typename = "Cac_PayeeFinancialAccount_Envelope";
                private static Type   s_type     = typeof(Cac_PayeeFinancialAccount_Envelope);
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
                int field_id = global::TDW.TRAServer.Cac_PayeeFinancialAccount_Cell.FieldLookupTable.Lookup(fieldName);
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
                get { return (ushort)CellType.Cac_PayeeFinancialAccount_Cell; }
            }
            #endregion
            #region ITypeDescriptor
            public string TypeName
            {
                get { return s_cellTypeName_Cac_PayeeFinancialAccount_Cell; }
            }
            public Type Type
            {
                get { return s_cellType_Cac_PayeeFinancialAccount_Cell; }
            }
            public bool IsOfType<T>()
            {
                return typeof(T) == s_cellType_Cac_PayeeFinancialAccount_Cell;
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
        internal static readonly Cac_PayeeFinancialAccount_Cell_descriptor s_cellDescriptor_Cac_PayeeFinancialAccount_Cell = new Cac_PayeeFinancialAccount_Cell_descriptor();
        /// <summary>
        /// Get the cell descriptor for Cac_PayeeFinancialAccount_Cell.
        /// </summary>
        public static ICellDescriptor Cac_PayeeFinancialAccount_Cell { get { return s_cellDescriptor_Cac_PayeeFinancialAccount_Cell; } }
        
        internal static readonly Type   s_cellType_Cac_Party_Cell       = typeof(global::TDW.TRAServer.Cac_Party_Cell);
        internal static readonly string s_cellTypeName_Cac_Party_Cell   = "Cac_Party_Cell";
        internal class Cac_Party_Cell_descriptor : ICellDescriptor
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
                private static string s_typename = "Cac_Party_Envelope";
                private static Type   s_type     = typeof(Cac_Party_Envelope);
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
                int field_id = global::TDW.TRAServer.Cac_Party_Cell.FieldLookupTable.Lookup(fieldName);
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
                get { return (ushort)CellType.Cac_Party_Cell; }
            }
            #endregion
            #region ITypeDescriptor
            public string TypeName
            {
                get { return s_cellTypeName_Cac_Party_Cell; }
            }
            public Type Type
            {
                get { return s_cellType_Cac_Party_Cell; }
            }
            public bool IsOfType<T>()
            {
                return typeof(T) == s_cellType_Cac_Party_Cell;
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
        internal static readonly Cac_Party_Cell_descriptor s_cellDescriptor_Cac_Party_Cell = new Cac_Party_Cell_descriptor();
        /// <summary>
        /// Get the cell descriptor for Cac_Party_Cell.
        /// </summary>
        public static ICellDescriptor Cac_Party_Cell { get { return s_cellDescriptor_Cac_Party_Cell; } }
        
        internal static readonly Type   s_cellType_UBL21_Invoice2_Cell       = typeof(global::TDW.TRAServer.UBL21_Invoice2_Cell);
        internal static readonly string s_cellTypeName_UBL21_Invoice2_Cell   = "UBL21_Invoice2_Cell";
        internal class UBL21_Invoice2_Cell_descriptor : ICellDescriptor
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
                private static string s_typename = "UBL21_Invoice2_Envelope";
                private static Type   s_type     = typeof(UBL21_Invoice2_Envelope);
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
                int field_id = global::TDW.TRAServer.UBL21_Invoice2_Cell.FieldLookupTable.Lookup(fieldName);
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
                get { return (ushort)CellType.UBL21_Invoice2_Cell; }
            }
            #endregion
            #region ITypeDescriptor
            public string TypeName
            {
                get { return s_cellTypeName_UBL21_Invoice2_Cell; }
            }
            public Type Type
            {
                get { return s_cellType_UBL21_Invoice2_Cell; }
            }
            public bool IsOfType<T>()
            {
                return typeof(T) == s_cellType_UBL21_Invoice2_Cell;
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
        internal static readonly UBL21_Invoice2_Cell_descriptor s_cellDescriptor_UBL21_Invoice2_Cell = new UBL21_Invoice2_Cell_descriptor();
        /// <summary>
        /// Get the cell descriptor for UBL21_Invoice2_Cell.
        /// </summary>
        public static ICellDescriptor UBL21_Invoice2_Cell { get { return s_cellDescriptor_UBL21_Invoice2_Cell; } }
        
        /// <summary>
        /// Enumerates descriptors for all cells defined in the TSL.
        /// </summary>
        public static IEnumerable<ICellDescriptor> CellDescriptors
        {
            get
            {
                
                yield return TRACredential_Cell;
                
                yield return TRATimestampCell;
                
                yield return TDWGeoLocationCell;
                
                yield return TRAPostalAddressCell;
                
                yield return Cac_Item_Cell;
                
                yield return Cac_ExternalReference_Cell;
                
                yield return Cac_Address_Cell;
                
                yield return Cac_PostalAddress_Cell;
                
                yield return Cac_PartyLegalEntity_Cell;
                
                yield return Cac_Contact_Cell;
                
                yield return Cac_Person_Cell;
                
                yield return Cac_PaymentMeans_Cell;
                
                yield return Cac_PayeeFinancialAccount_Cell;
                
                yield return Cac_Party_Cell;
                
                yield return UBL21_Invoice2_Cell;
                
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
                
                yield return "{{optional {string|List<string>|{string|{string}|{string|optional string|string}|List<{string|string|string}>|{{string|optional string|string}|double|{{string|optional string|string}}}}}|optional string|{TRACredentialType|long|TRATrustLevel|TRAEncryptionFlag|string|optional string|optional string}}|{optional string|optional string|optional string|optional List<string>}}";
                
                yield return "{{optional {string|List<string>|{optional string|optional {string|string}}}|optional string|{TRACredentialType|long|TRATrustLevel|TRAEncryptionFlag|string|optional string|optional string}}|{optional string|optional string|optional string|optional List<string>}}";
                
                yield return "{{optional {string|List<string>|{string|string|string|string|string|string|string|string|{{string|string|string}}}}|optional string|{TRACredentialType|long|TRATrustLevel|TRAEncryptionFlag|string|optional string|optional string}}|{optional string|optional string|optional string|optional List<string>}}";
                
                yield return "{{optional {string|List<string>|{string|string|string|string|string|string|string|string|{{string|string|string}}}}|optional string|{TRACredentialType|long|TRATrustLevel|TRAEncryptionFlag|string|optional string|optional string}}|{optional string|optional string|optional string|optional List<string>}}";
                
                yield return "{{optional {string|List<string>|{string|{string|optional string|string}|string}}|optional string|{TRACredentialType|long|TRATrustLevel|TRAEncryptionFlag|string|optional string|optional string}}|{optional string|optional string|optional string|optional List<string>}}";
                
                yield return "{{optional {string|List<string>|{string|string|string}}|optional string|{TRACredentialType|long|TRATrustLevel|TRAEncryptionFlag|string|optional string|optional string}}|{optional string|optional string|optional string|optional List<string>}}";
                
                yield return "{{optional {string|List<string>|{string|string|string|string}}|optional string|{TRACredentialType|long|TRATrustLevel|TRAEncryptionFlag|string|optional string|optional string}}|{optional string|optional string|optional string|optional List<string>}}";
                
                yield return "{{optional {string|List<string>|{{string|string|string}|DateTime|string|string|string}}|optional string|{TRACredentialType|long|TRATrustLevel|TRAEncryptionFlag|string|optional string|optional string}}|{optional string|optional string|optional string|optional List<string>}}";
                
                yield return "{{optional {string|List<string>|{string|{{string}}}}|optional string|{TRACredentialType|long|TRATrustLevel|TRAEncryptionFlag|string|optional string|optional string}}|{optional string|optional string|optional string|optional List<string>}}";
                
                yield return "{{optional {string|List<string>|{{string|optional string|string}|{{string|optional string|string}}|{string}|string|{{string|optional string|string}|{{string|optional string|string}}}|string|string|string}}|optional string|{TRACredentialType|long|TRATrustLevel|TRAEncryptionFlag|string|optional string|optional string}}|{optional string|optional string|optional string|optional List<string>}}";
                
                yield return "{{{string|List<string>|{string|string|DateTime|{string|string|string}|{ISO639_1_LanguageCodes|string}|DateTime|{string|string|string}|string|{DateTime|DateTime}|{string}|{string|string|optional {string}}|List<{string|string|optional {string}}>|{string}|{string}|{string}|{DateTime|{{string|optional string|string}|string}}|string|{{ISO639_1_LanguageCodes|string}}|List<{bool|string|{string|double}}>|{{string|double}|List<{{string|double}|{string|double}|{{string|optional string|string}|double|{{string|optional string|string}}}}>}|{{string|double}|{string|double}|{string|double}|{string|double}|{string|double}|{string|double}|{string|double}|{string|double}}|List<{string|{ISO639_1_LanguageCodes|string}|{string|long}|{string|double}|string|{string}|List<{bool|string|{string|double}}>|{{string|double}|List<{{string|double}|{string|double}|{{string|optional string|string}|double|{{string|optional string|string}}}}>}|string|{{string|double}|{string|long}|{bool|string|{string|double}}}}>}}|optional string|{TRACredentialType|long|TRATrustLevel|TRAEncryptionFlag|string|optional string|optional string}}|{optional string|optional string|optional string|optional List<string>}}";
                
                yield break;
            }
        }
        #endregion
    }
}

#pragma warning restore 162,168,649,660,661,1522
