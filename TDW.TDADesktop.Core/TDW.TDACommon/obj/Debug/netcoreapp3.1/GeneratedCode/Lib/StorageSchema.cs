#pragma warning disable 162,168,649,660,661,1522
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trinity.Storage;
using Trinity.TSL;
namespace TDW.TDACommon
{
    /// <summary>
    /// Exposes the data modeling schema defined in the TSL.
    /// </summary>
    public class StorageSchema : IStorageSchema
    {
        #region CellType lookup table
        internal static Dictionary<string, CellType> cellTypeLookupTable = new Dictionary<string, CellType>()
        {
            
            {"TDARootCell", global::TDW.TDACommon.CellType.TDARootCell}
            ,
            {"TDABasketItemCell", global::TDW.TDACommon.CellType.TDABasketItemCell}
            ,
            {"TDASubledgerCell", global::TDW.TDACommon.CellType.TDASubledgerCell}
            ,
            {"TDAMasterKeyLedgerCell", global::TDW.TDACommon.CellType.TDAMasterKeyLedgerCell}
            ,
            {"TDAKeyRingLedgerCell", global::TDW.TDACommon.CellType.TDAKeyRingLedgerCell}
            ,
            {"TDAWalletLedgerCell", global::TDW.TDACommon.CellType.TDAWalletLedgerCell}
            ,
            {"TDAVDAddressLedgerCell", global::TDW.TDACommon.CellType.TDAVDAddressLedgerCell}
            
        };
        #endregion
        
        internal static readonly Type   s_cellType_TDARootCell       = typeof(global::TDW.TDACommon.TDARootCell);
        internal static readonly string s_cellTypeName_TDARootCell   = "TDARootCell";
        internal class TDARootCell_descriptor : ICellDescriptor
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
            
            internal class inbasket_descriptor : IFieldDescriptor
            {
                private static IReadOnlyDictionary<string, string> s_attributes = new Dictionary<string, string>
                {
                    
                };
                private static string s_typename = "TDABasket";
                private static Type   s_type     = typeof(TDABasket);
                public string Name
                {
                    get { return "inbasket"; }
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
            internal static inbasket_descriptor inbasket = new inbasket_descriptor();
            
            internal class outbasket_descriptor : IFieldDescriptor
            {
                private static IReadOnlyDictionary<string, string> s_attributes = new Dictionary<string, string>
                {
                    
                };
                private static string s_typename = "TDABasket";
                private static Type   s_type     = typeof(TDABasket);
                public string Name
                {
                    get { return "outbasket"; }
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
            internal static outbasket_descriptor outbasket = new outbasket_descriptor();
            
            internal class ledgers_descriptor : IFieldDescriptor
            {
                private static IReadOnlyDictionary<string, string> s_attributes = new Dictionary<string, string>
                {
                    
                };
                private static string s_typename = "TDALedgers";
                private static Type   s_type     = typeof(TDALedgers);
                public string Name
                {
                    get { return "ledgers"; }
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
            internal static ledgers_descriptor ledgers = new ledgers_descriptor();
            
            #region ICellDescriptor
            public IEnumerable<string> GetFieldNames()
            {
                
                yield return "inbasket";
                
                yield return "outbasket";
                
                yield return "ledgers";
                
            }
            public IAttributeCollection GetFieldAttributes(string fieldName)
            {
                int field_id = global::TDW.TDACommon.TDARootCell.FieldLookupTable.Lookup(fieldName);
                if (field_id == -1)
                    Throw.undefined_field();
                switch (field_id)
                {
                    
                    case 0:
                        return inbasket;
                    
                    case 1:
                        return outbasket;
                    
                    case 2:
                        return ledgers;
                    
                }
                /* Should not reach here */
                throw new Exception("Internal error T6001");
            }
            public IEnumerable<IFieldDescriptor> GetFieldDescriptors()
            {
                
                yield return inbasket;
                
                yield return outbasket;
                
                yield return ledgers;
                
            }
            ushort ICellDescriptor.CellType
            {
                get { return (ushort)CellType.TDARootCell; }
            }
            #endregion
            #region ITypeDescriptor
            public string TypeName
            {
                get { return s_cellTypeName_TDARootCell; }
            }
            public Type Type
            {
                get { return s_cellType_TDARootCell; }
            }
            public bool IsOfType<T>()
            {
                return typeof(T) == s_cellType_TDARootCell;
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
        internal static readonly TDARootCell_descriptor s_cellDescriptor_TDARootCell = new TDARootCell_descriptor();
        /// <summary>
        /// Get the cell descriptor for TDARootCell.
        /// </summary>
        public static ICellDescriptor TDARootCell { get { return s_cellDescriptor_TDARootCell; } }
        
        internal static readonly Type   s_cellType_TDABasketItemCell       = typeof(global::TDW.TDACommon.TDABasketItemCell);
        internal static readonly string s_cellTypeName_TDABasketItemCell   = "TDABasketItemCell";
        internal class TDABasketItemCell_descriptor : ICellDescriptor
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
            
            internal class credentialudid_descriptor : IFieldDescriptor
            {
                private static IReadOnlyDictionary<string, string> s_attributes = new Dictionary<string, string>
                {
                    
                };
                private static string s_typename = "string";
                private static Type   s_type     = typeof(string);
                public string Name
                {
                    get { return "credentialudid"; }
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
            internal static credentialudid_descriptor credentialudid = new credentialudid_descriptor();
            
            #region ICellDescriptor
            public IEnumerable<string> GetFieldNames()
            {
                
                yield return "credentialudid";
                
            }
            public IAttributeCollection GetFieldAttributes(string fieldName)
            {
                int field_id = global::TDW.TDACommon.TDABasketItemCell.FieldLookupTable.Lookup(fieldName);
                if (field_id == -1)
                    Throw.undefined_field();
                switch (field_id)
                {
                    
                    case 0:
                        return credentialudid;
                    
                }
                /* Should not reach here */
                throw new Exception("Internal error T6001");
            }
            public IEnumerable<IFieldDescriptor> GetFieldDescriptors()
            {
                
                yield return credentialudid;
                
            }
            ushort ICellDescriptor.CellType
            {
                get { return (ushort)CellType.TDABasketItemCell; }
            }
            #endregion
            #region ITypeDescriptor
            public string TypeName
            {
                get { return s_cellTypeName_TDABasketItemCell; }
            }
            public Type Type
            {
                get { return s_cellType_TDABasketItemCell; }
            }
            public bool IsOfType<T>()
            {
                return typeof(T) == s_cellType_TDABasketItemCell;
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
        internal static readonly TDABasketItemCell_descriptor s_cellDescriptor_TDABasketItemCell = new TDABasketItemCell_descriptor();
        /// <summary>
        /// Get the cell descriptor for TDABasketItemCell.
        /// </summary>
        public static ICellDescriptor TDABasketItemCell { get { return s_cellDescriptor_TDABasketItemCell; } }
        
        internal static readonly Type   s_cellType_TDASubledgerCell       = typeof(global::TDW.TDACommon.TDASubledgerCell);
        internal static readonly string s_cellTypeName_TDASubledgerCell   = "TDASubledgerCell";
        internal class TDASubledgerCell_descriptor : ICellDescriptor
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
            
            internal class name_descriptor : IFieldDescriptor
            {
                private static IReadOnlyDictionary<string, string> s_attributes = new Dictionary<string, string>
                {
                    
                };
                private static string s_typename = "string";
                private static Type   s_type     = typeof(string);
                public string Name
                {
                    get { return "name"; }
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
            internal static name_descriptor name = new name_descriptor();
            
            internal class subledgerids_descriptor : IFieldDescriptor
            {
                private static IReadOnlyDictionary<string, string> s_attributes = new Dictionary<string, string>
                {
                    
                };
                private static string s_typename = "List<long>";
                private static Type   s_type     = typeof(List<long>);
                public string Name
                {
                    get { return "subledgerids"; }
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
                    
                    return true;
                    
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
            internal static subledgerids_descriptor subledgerids = new subledgerids_descriptor();
            
            internal class itemudids_descriptor : IFieldDescriptor
            {
                private static IReadOnlyDictionary<string, string> s_attributes = new Dictionary<string, string>
                {
                    
                };
                private static string s_typename = "List<string>";
                private static Type   s_type     = typeof(List<string>);
                public string Name
                {
                    get { return "itemudids"; }
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
                    
                    return true;
                    
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
            internal static itemudids_descriptor itemudids = new itemudids_descriptor();
            
            #region ICellDescriptor
            public IEnumerable<string> GetFieldNames()
            {
                
                yield return "name";
                
                yield return "subledgerids";
                
                yield return "itemudids";
                
            }
            public IAttributeCollection GetFieldAttributes(string fieldName)
            {
                int field_id = global::TDW.TDACommon.TDASubledgerCell.FieldLookupTable.Lookup(fieldName);
                if (field_id == -1)
                    Throw.undefined_field();
                switch (field_id)
                {
                    
                    case 0:
                        return name;
                    
                    case 1:
                        return subledgerids;
                    
                    case 2:
                        return itemudids;
                    
                }
                /* Should not reach here */
                throw new Exception("Internal error T6001");
            }
            public IEnumerable<IFieldDescriptor> GetFieldDescriptors()
            {
                
                yield return name;
                
                yield return subledgerids;
                
                yield return itemudids;
                
            }
            ushort ICellDescriptor.CellType
            {
                get { return (ushort)CellType.TDASubledgerCell; }
            }
            #endregion
            #region ITypeDescriptor
            public string TypeName
            {
                get { return s_cellTypeName_TDASubledgerCell; }
            }
            public Type Type
            {
                get { return s_cellType_TDASubledgerCell; }
            }
            public bool IsOfType<T>()
            {
                return typeof(T) == s_cellType_TDASubledgerCell;
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
        internal static readonly TDASubledgerCell_descriptor s_cellDescriptor_TDASubledgerCell = new TDASubledgerCell_descriptor();
        /// <summary>
        /// Get the cell descriptor for TDASubledgerCell.
        /// </summary>
        public static ICellDescriptor TDASubledgerCell { get { return s_cellDescriptor_TDASubledgerCell; } }
        
        internal static readonly Type   s_cellType_TDAMasterKeyLedgerCell       = typeof(global::TDW.TDACommon.TDAMasterKeyLedgerCell);
        internal static readonly string s_cellTypeName_TDAMasterKeyLedgerCell   = "TDAMasterKeyLedgerCell";
        internal class TDAMasterKeyLedgerCell_descriptor : ICellDescriptor
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
            
            internal class masterkeyids_descriptor : IFieldDescriptor
            {
                private static IReadOnlyDictionary<string, string> s_attributes = new Dictionary<string, string>
                {
                    
                };
                private static string s_typename = "List<string>";
                private static Type   s_type     = typeof(List<string>);
                public string Name
                {
                    get { return "masterkeyids"; }
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
                    
                    return true;
                    
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
            internal static masterkeyids_descriptor masterkeyids = new masterkeyids_descriptor();
            
            #region ICellDescriptor
            public IEnumerable<string> GetFieldNames()
            {
                
                yield return "masterkeyids";
                
            }
            public IAttributeCollection GetFieldAttributes(string fieldName)
            {
                int field_id = global::TDW.TDACommon.TDAMasterKeyLedgerCell.FieldLookupTable.Lookup(fieldName);
                if (field_id == -1)
                    Throw.undefined_field();
                switch (field_id)
                {
                    
                    case 0:
                        return masterkeyids;
                    
                }
                /* Should not reach here */
                throw new Exception("Internal error T6001");
            }
            public IEnumerable<IFieldDescriptor> GetFieldDescriptors()
            {
                
                yield return masterkeyids;
                
            }
            ushort ICellDescriptor.CellType
            {
                get { return (ushort)CellType.TDAMasterKeyLedgerCell; }
            }
            #endregion
            #region ITypeDescriptor
            public string TypeName
            {
                get { return s_cellTypeName_TDAMasterKeyLedgerCell; }
            }
            public Type Type
            {
                get { return s_cellType_TDAMasterKeyLedgerCell; }
            }
            public bool IsOfType<T>()
            {
                return typeof(T) == s_cellType_TDAMasterKeyLedgerCell;
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
        internal static readonly TDAMasterKeyLedgerCell_descriptor s_cellDescriptor_TDAMasterKeyLedgerCell = new TDAMasterKeyLedgerCell_descriptor();
        /// <summary>
        /// Get the cell descriptor for TDAMasterKeyLedgerCell.
        /// </summary>
        public static ICellDescriptor TDAMasterKeyLedgerCell { get { return s_cellDescriptor_TDAMasterKeyLedgerCell; } }
        
        internal static readonly Type   s_cellType_TDAKeyRingLedgerCell       = typeof(global::TDW.TDACommon.TDAKeyRingLedgerCell);
        internal static readonly string s_cellTypeName_TDAKeyRingLedgerCell   = "TDAKeyRingLedgerCell";
        internal class TDAKeyRingLedgerCell_descriptor : ICellDescriptor
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
            
            internal class subledgerids_descriptor : IFieldDescriptor
            {
                private static IReadOnlyDictionary<string, string> s_attributes = new Dictionary<string, string>
                {
                    
                };
                private static string s_typename = "List<long>";
                private static Type   s_type     = typeof(List<long>);
                public string Name
                {
                    get { return "subledgerids"; }
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
                    
                    return true;
                    
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
            internal static subledgerids_descriptor subledgerids = new subledgerids_descriptor();
            
            #region ICellDescriptor
            public IEnumerable<string> GetFieldNames()
            {
                
                yield return "subledgerids";
                
            }
            public IAttributeCollection GetFieldAttributes(string fieldName)
            {
                int field_id = global::TDW.TDACommon.TDAKeyRingLedgerCell.FieldLookupTable.Lookup(fieldName);
                if (field_id == -1)
                    Throw.undefined_field();
                switch (field_id)
                {
                    
                    case 0:
                        return subledgerids;
                    
                }
                /* Should not reach here */
                throw new Exception("Internal error T6001");
            }
            public IEnumerable<IFieldDescriptor> GetFieldDescriptors()
            {
                
                yield return subledgerids;
                
            }
            ushort ICellDescriptor.CellType
            {
                get { return (ushort)CellType.TDAKeyRingLedgerCell; }
            }
            #endregion
            #region ITypeDescriptor
            public string TypeName
            {
                get { return s_cellTypeName_TDAKeyRingLedgerCell; }
            }
            public Type Type
            {
                get { return s_cellType_TDAKeyRingLedgerCell; }
            }
            public bool IsOfType<T>()
            {
                return typeof(T) == s_cellType_TDAKeyRingLedgerCell;
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
        internal static readonly TDAKeyRingLedgerCell_descriptor s_cellDescriptor_TDAKeyRingLedgerCell = new TDAKeyRingLedgerCell_descriptor();
        /// <summary>
        /// Get the cell descriptor for TDAKeyRingLedgerCell.
        /// </summary>
        public static ICellDescriptor TDAKeyRingLedgerCell { get { return s_cellDescriptor_TDAKeyRingLedgerCell; } }
        
        internal static readonly Type   s_cellType_TDAWalletLedgerCell       = typeof(global::TDW.TDACommon.TDAWalletLedgerCell);
        internal static readonly string s_cellTypeName_TDAWalletLedgerCell   = "TDAWalletLedgerCell";
        internal class TDAWalletLedgerCell_descriptor : ICellDescriptor
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
            
            internal class subledgerids_descriptor : IFieldDescriptor
            {
                private static IReadOnlyDictionary<string, string> s_attributes = new Dictionary<string, string>
                {
                    
                };
                private static string s_typename = "List<long>";
                private static Type   s_type     = typeof(List<long>);
                public string Name
                {
                    get { return "subledgerids"; }
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
                    
                    return true;
                    
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
            internal static subledgerids_descriptor subledgerids = new subledgerids_descriptor();
            
            #region ICellDescriptor
            public IEnumerable<string> GetFieldNames()
            {
                
                yield return "subledgerids";
                
            }
            public IAttributeCollection GetFieldAttributes(string fieldName)
            {
                int field_id = global::TDW.TDACommon.TDAWalletLedgerCell.FieldLookupTable.Lookup(fieldName);
                if (field_id == -1)
                    Throw.undefined_field();
                switch (field_id)
                {
                    
                    case 0:
                        return subledgerids;
                    
                }
                /* Should not reach here */
                throw new Exception("Internal error T6001");
            }
            public IEnumerable<IFieldDescriptor> GetFieldDescriptors()
            {
                
                yield return subledgerids;
                
            }
            ushort ICellDescriptor.CellType
            {
                get { return (ushort)CellType.TDAWalletLedgerCell; }
            }
            #endregion
            #region ITypeDescriptor
            public string TypeName
            {
                get { return s_cellTypeName_TDAWalletLedgerCell; }
            }
            public Type Type
            {
                get { return s_cellType_TDAWalletLedgerCell; }
            }
            public bool IsOfType<T>()
            {
                return typeof(T) == s_cellType_TDAWalletLedgerCell;
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
        internal static readonly TDAWalletLedgerCell_descriptor s_cellDescriptor_TDAWalletLedgerCell = new TDAWalletLedgerCell_descriptor();
        /// <summary>
        /// Get the cell descriptor for TDAWalletLedgerCell.
        /// </summary>
        public static ICellDescriptor TDAWalletLedgerCell { get { return s_cellDescriptor_TDAWalletLedgerCell; } }
        
        internal static readonly Type   s_cellType_TDAVDAddressLedgerCell       = typeof(global::TDW.TDACommon.TDAVDAddressLedgerCell);
        internal static readonly string s_cellTypeName_TDAVDAddressLedgerCell   = "TDAVDAddressLedgerCell";
        internal class TDAVDAddressLedgerCell_descriptor : ICellDescriptor
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
            
            internal class subledgerids_descriptor : IFieldDescriptor
            {
                private static IReadOnlyDictionary<string, string> s_attributes = new Dictionary<string, string>
                {
                    
                };
                private static string s_typename = "List<long>";
                private static Type   s_type     = typeof(List<long>);
                public string Name
                {
                    get { return "subledgerids"; }
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
                    
                    return true;
                    
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
            internal static subledgerids_descriptor subledgerids = new subledgerids_descriptor();
            
            #region ICellDescriptor
            public IEnumerable<string> GetFieldNames()
            {
                
                yield return "subledgerids";
                
            }
            public IAttributeCollection GetFieldAttributes(string fieldName)
            {
                int field_id = global::TDW.TDACommon.TDAVDAddressLedgerCell.FieldLookupTable.Lookup(fieldName);
                if (field_id == -1)
                    Throw.undefined_field();
                switch (field_id)
                {
                    
                    case 0:
                        return subledgerids;
                    
                }
                /* Should not reach here */
                throw new Exception("Internal error T6001");
            }
            public IEnumerable<IFieldDescriptor> GetFieldDescriptors()
            {
                
                yield return subledgerids;
                
            }
            ushort ICellDescriptor.CellType
            {
                get { return (ushort)CellType.TDAVDAddressLedgerCell; }
            }
            #endregion
            #region ITypeDescriptor
            public string TypeName
            {
                get { return s_cellTypeName_TDAVDAddressLedgerCell; }
            }
            public Type Type
            {
                get { return s_cellType_TDAVDAddressLedgerCell; }
            }
            public bool IsOfType<T>()
            {
                return typeof(T) == s_cellType_TDAVDAddressLedgerCell;
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
        internal static readonly TDAVDAddressLedgerCell_descriptor s_cellDescriptor_TDAVDAddressLedgerCell = new TDAVDAddressLedgerCell_descriptor();
        /// <summary>
        /// Get the cell descriptor for TDAVDAddressLedgerCell.
        /// </summary>
        public static ICellDescriptor TDAVDAddressLedgerCell { get { return s_cellDescriptor_TDAVDAddressLedgerCell; } }
        
        /// <summary>
        /// Enumerates descriptors for all cells defined in the TSL.
        /// </summary>
        public static IEnumerable<ICellDescriptor> CellDescriptors
        {
            get
            {
                
                yield return TDARootCell;
                
                yield return TDABasketItemCell;
                
                yield return TDASubledgerCell;
                
                yield return TDAMasterKeyLedgerCell;
                
                yield return TDAKeyRingLedgerCell;
                
                yield return TDAWalletLedgerCell;
                
                yield return TDAVDAddressLedgerCell;
                
                yield break;
            }
        }
        /// <summary>
        /// Converts a type string to <see cref="TDW.TDACommon.CellType"/>.
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
                
                yield return "{{List<long>}|{List<long>}|{long[4]}}";
                
                yield return "{string}";
                
                yield return "{string|List<long>|List<string>}";
                
                yield return "{List<string>}";
                
                yield return "{List<long>}";
                
                yield return "{List<long>}";
                
                yield return "{List<long>}";
                
                yield break;
            }
        }
        #endregion
    }
}

#pragma warning restore 162,168,649,660,661,1522
