#pragma warning disable 162,168,649,660,661,1522

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trinity.TSL;
using Trinity.TSL.Lib;
namespace TDW.KMAServer
{
    internal class TypeSystem
    {
        #region TypeID lookup table
        private static Dictionary<Type, uint> TypeIDLookupTable = new Dictionary<Type, uint>()
        {
            
            { typeof(bool), 0 }
            ,
            { typeof(long), 1 }
            ,
            { typeof(string), 2 }
            ,
            { typeof(List<string>), 3 }
            ,
            { typeof(KMAKeyPairType), 4 }
            ,
        };
        #endregion
        #region CellTypeID lookup table
        private static Dictionary<Type, uint> CellTypeIDLookupTable = new Dictionary<Type, uint>()
        {
            
            { typeof(KMAKeyPair), 0 }
            
        };
        #endregion
        internal static uint GetTypeID(Type t)
        {
            uint type_id;
            if (!TypeIDLookupTable.TryGetValue(t, out type_id))
                type_id = uint.MaxValue;
            return type_id;
        }
        internal static uint GetCellTypeID(Type t)
        {
            uint type_id;
            if (!CellTypeIDLookupTable.TryGetValue(t, out type_id))
                throw new Exception("Type " + t.ToString() + " is not a cell.");
            return type_id;
        }
    }
    internal enum TypeConversionAction
    {
        TC_NONCONVERTIBLE = 0,
        TC_ASSIGN,
        TC_TOSTRING,
        TC_PARSESTRING,
        TC_TOBOOL,
        TC_CONVERTLIST,
        TC_WRAPINLIST,
        TC_ARRAYTOLIST,
        TC_EXTRACTNULLABLE,
    }
    internal interface ITypeConverter<T>
    {
        
        T ConvertFrom_bool(bool value);
        bool ConvertTo_bool(T value);
        TypeConversionAction GetConversionActionTo_bool();
        IEnumerable<bool> Enumerate_bool(T value);
        
        T ConvertFrom_long(long value);
        long ConvertTo_long(T value);
        TypeConversionAction GetConversionActionTo_long();
        IEnumerable<long> Enumerate_long(T value);
        
        T ConvertFrom_string(string value);
        string ConvertTo_string(T value);
        TypeConversionAction GetConversionActionTo_string();
        IEnumerable<string> Enumerate_string(T value);
        
        T ConvertFrom_List_string(List<string> value);
        List<string> ConvertTo_List_string(T value);
        TypeConversionAction GetConversionActionTo_List_string();
        IEnumerable<List<string>> Enumerate_List_string(T value);
        
        T ConvertFrom_KMAKeyPairType(KMAKeyPairType value);
        KMAKeyPairType ConvertTo_KMAKeyPairType(T value);
        TypeConversionAction GetConversionActionTo_KMAKeyPairType();
        IEnumerable<KMAKeyPairType> Enumerate_KMAKeyPairType(T value);
        
    }
    internal class TypeConverter<T> : ITypeConverter<T>
    {
        internal class _TypeConverterImpl : ITypeConverter<object>
            
            , ITypeConverter<bool>
        
            , ITypeConverter<long>
        
            , ITypeConverter<string>
        
            , ITypeConverter<List<string>>
        
            , ITypeConverter<KMAKeyPairType>
        
        {
            bool ITypeConverter<bool>.ConvertFrom_bool(bool value)
            {
                
                return (bool)value;
                
            }
            bool ITypeConverter<bool>.ConvertTo_bool(bool value)
            {
                return TypeConverter<bool>.ConvertFrom_bool(value);
            }
            TypeConversionAction ITypeConverter<bool>.GetConversionActionTo_bool()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<bool> ITypeConverter<bool>.Enumerate_bool(bool value)
            {
                
                yield break;
            }
            bool ITypeConverter<bool>.ConvertFrom_long(long value)
            {
                
                return (value != 0);
                
            }
            long ITypeConverter<bool>.ConvertTo_long(bool value)
            {
                return TypeConverter<long>.ConvertFrom_bool(value);
            }
            TypeConversionAction ITypeConverter<bool>.GetConversionActionTo_long()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long> ITypeConverter<bool>.Enumerate_long(bool value)
            {
                
                yield break;
            }
            bool ITypeConverter<bool>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    bool intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = ExternalParser.TryParse_bool(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        Throw.cannot_parse(value, "bool");
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<bool>.ConvertTo_string(bool value)
            {
                return TypeConverter<string>.ConvertFrom_bool(value);
            }
            TypeConversionAction ITypeConverter<bool>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<bool>.Enumerate_string(bool value)
            {
                
                yield break;
            }
            bool ITypeConverter<bool>.ConvertFrom_List_string(List<string> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<string>' to 'bool'.");
                
            }
            List<string> ITypeConverter<bool>.ConvertTo_List_string(bool value)
            {
                return TypeConverter<List<string>>.ConvertFrom_bool(value);
            }
            TypeConversionAction ITypeConverter<bool>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_WRAPINLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<bool>.Enumerate_List_string(bool value)
            {
                
                yield break;
            }
            bool ITypeConverter<bool>.ConvertFrom_KMAKeyPairType(KMAKeyPairType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'KMAKeyPairType' to 'bool'.");
                
            }
            KMAKeyPairType ITypeConverter<bool>.ConvertTo_KMAKeyPairType(bool value)
            {
                return TypeConverter<KMAKeyPairType>.ConvertFrom_bool(value);
            }
            TypeConversionAction ITypeConverter<bool>.GetConversionActionTo_KMAKeyPairType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<KMAKeyPairType> ITypeConverter<bool>.Enumerate_KMAKeyPairType(bool value)
            {
                
                yield break;
            }
            long ITypeConverter<long>.ConvertFrom_bool(bool value)
            {
                
                throw new InvalidCastException("Invalid cast from 'bool' to 'long'.");
                
            }
            bool ITypeConverter<long>.ConvertTo_bool(long value)
            {
                return TypeConverter<bool>.ConvertFrom_long(value);
            }
            TypeConversionAction ITypeConverter<long>.GetConversionActionTo_bool()
            {
                
                return TypeConversionAction.TC_TOBOOL;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<bool> ITypeConverter<long>.Enumerate_bool(long value)
            {
                
                yield break;
            }
            long ITypeConverter<long>.ConvertFrom_long(long value)
            {
                
                return (long)value;
                
            }
            long ITypeConverter<long>.ConvertTo_long(long value)
            {
                return TypeConverter<long>.ConvertFrom_long(value);
            }
            TypeConversionAction ITypeConverter<long>.GetConversionActionTo_long()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long> ITypeConverter<long>.Enumerate_long(long value)
            {
                
                yield break;
            }
            long ITypeConverter<long>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    long intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = long.TryParse(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        Throw.cannot_parse(value, "long");
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<long>.ConvertTo_string(long value)
            {
                return TypeConverter<string>.ConvertFrom_long(value);
            }
            TypeConversionAction ITypeConverter<long>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<long>.Enumerate_string(long value)
            {
                
                yield break;
            }
            long ITypeConverter<long>.ConvertFrom_List_string(List<string> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<string>' to 'long'.");
                
            }
            List<string> ITypeConverter<long>.ConvertTo_List_string(long value)
            {
                return TypeConverter<List<string>>.ConvertFrom_long(value);
            }
            TypeConversionAction ITypeConverter<long>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_WRAPINLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<long>.Enumerate_List_string(long value)
            {
                
                yield break;
            }
            long ITypeConverter<long>.ConvertFrom_KMAKeyPairType(KMAKeyPairType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'KMAKeyPairType' to 'long'.");
                
            }
            KMAKeyPairType ITypeConverter<long>.ConvertTo_KMAKeyPairType(long value)
            {
                return TypeConverter<KMAKeyPairType>.ConvertFrom_long(value);
            }
            TypeConversionAction ITypeConverter<long>.GetConversionActionTo_KMAKeyPairType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<KMAKeyPairType> ITypeConverter<long>.Enumerate_KMAKeyPairType(long value)
            {
                
                yield break;
            }
            string ITypeConverter<string>.ConvertFrom_bool(bool value)
            {
                
                return Serializer.ToString(value);
                
            }
            bool ITypeConverter<string>.ConvertTo_bool(string value)
            {
                return TypeConverter<bool>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_bool()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<bool> ITypeConverter<string>.Enumerate_bool(string value)
            {
                
                yield break;
            }
            string ITypeConverter<string>.ConvertFrom_long(long value)
            {
                
                return Serializer.ToString(value);
                
            }
            long ITypeConverter<string>.ConvertTo_long(string value)
            {
                return TypeConverter<long>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_long()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long> ITypeConverter<string>.Enumerate_long(string value)
            {
                
                yield break;
            }
            string ITypeConverter<string>.ConvertFrom_string(string value)
            {
                
                return (string)value;
                
            }
            string ITypeConverter<string>.ConvertTo_string(string value)
            {
                return TypeConverter<string>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<string>.Enumerate_string(string value)
            {
                
                yield break;
            }
            string ITypeConverter<string>.ConvertFrom_List_string(List<string> value)
            {
                
                return Serializer.ToString(value);
                
            }
            List<string> ITypeConverter<string>.ConvertTo_List_string(string value)
            {
                return TypeConverter<List<string>>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<string>.Enumerate_List_string(string value)
            {
                
                yield break;
            }
            string ITypeConverter<string>.ConvertFrom_KMAKeyPairType(KMAKeyPairType value)
            {
                
                return Serializer.ToString(value);
                
            }
            KMAKeyPairType ITypeConverter<string>.ConvertTo_KMAKeyPairType(string value)
            {
                return TypeConverter<KMAKeyPairType>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_KMAKeyPairType()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<KMAKeyPairType> ITypeConverter<string>.Enumerate_KMAKeyPairType(string value)
            {
                
                yield break;
            }
            List<string> ITypeConverter<List<string>>.ConvertFrom_bool(bool value)
            {
                
                {
                    List<string> intermediate_result = new List<string>();
                    intermediate_result.Add(TypeConverter<string>.ConvertFrom_bool(value));
                    return intermediate_result;
                }
                
            }
            bool ITypeConverter<List<string>>.ConvertTo_bool(List<string> value)
            {
                return TypeConverter<bool>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_bool()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<bool> ITypeConverter<List<string>>.Enumerate_bool(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<bool>.ConvertFrom_string(element);
                
                yield break;
            }
            List<string> ITypeConverter<List<string>>.ConvertFrom_long(long value)
            {
                
                {
                    List<string> intermediate_result = new List<string>();
                    intermediate_result.Add(TypeConverter<string>.ConvertFrom_long(value));
                    return intermediate_result;
                }
                
            }
            long ITypeConverter<List<string>>.ConvertTo_long(List<string> value)
            {
                return TypeConverter<long>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_long()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long> ITypeConverter<List<string>>.Enumerate_long(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<long>.ConvertFrom_string(element);
                
                yield break;
            }
            List<string> ITypeConverter<List<string>>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    List<string> intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = ExternalParser.TryParse_List_string(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        try
                        {
                            string element = TypeConverter<string>.ConvertFrom_string(value);
                            intermediate_result = new List<string>();
                            intermediate_result.Add(element);
                        }
                        catch
                        {
                            throw new ArgumentException("Cannot parse \"" + value + "\" into either 'List<string>' or 'string'.");
                        }
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<List<string>>.ConvertTo_string(List<string> value)
            {
                return TypeConverter<string>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<List<string>>.Enumerate_string(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<string>.ConvertFrom_string(element);
                
                yield break;
            }
            List<string> ITypeConverter<List<string>>.ConvertFrom_List_string(List<string> value)
            {
                
                return (List<string>)value;
                
            }
            List<string> ITypeConverter<List<string>>.ConvertTo_List_string(List<string> value)
            {
                return TypeConverter<List<string>>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<List<string>>.Enumerate_List_string(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<List<string>>.ConvertFrom_string(element);
                
                yield break;
            }
            List<string> ITypeConverter<List<string>>.ConvertFrom_KMAKeyPairType(KMAKeyPairType value)
            {
                
                {
                    List<string> intermediate_result = new List<string>();
                    intermediate_result.Add(TypeConverter<string>.ConvertFrom_KMAKeyPairType(value));
                    return intermediate_result;
                }
                
            }
            KMAKeyPairType ITypeConverter<List<string>>.ConvertTo_KMAKeyPairType(List<string> value)
            {
                return TypeConverter<KMAKeyPairType>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_KMAKeyPairType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<KMAKeyPairType> ITypeConverter<List<string>>.Enumerate_KMAKeyPairType(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<KMAKeyPairType>.ConvertFrom_string(element);
                
                yield break;
            }
            KMAKeyPairType ITypeConverter<KMAKeyPairType>.ConvertFrom_bool(bool value)
            {
                
                throw new InvalidCastException("Invalid cast from 'bool' to 'KMAKeyPairType'.");
                
            }
            bool ITypeConverter<KMAKeyPairType>.ConvertTo_bool(KMAKeyPairType value)
            {
                return TypeConverter<bool>.ConvertFrom_KMAKeyPairType(value);
            }
            TypeConversionAction ITypeConverter<KMAKeyPairType>.GetConversionActionTo_bool()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<bool> ITypeConverter<KMAKeyPairType>.Enumerate_bool(KMAKeyPairType value)
            {
                
                yield break;
            }
            KMAKeyPairType ITypeConverter<KMAKeyPairType>.ConvertFrom_long(long value)
            {
                
                throw new InvalidCastException("Invalid cast from 'long' to 'KMAKeyPairType'.");
                
            }
            long ITypeConverter<KMAKeyPairType>.ConvertTo_long(KMAKeyPairType value)
            {
                return TypeConverter<long>.ConvertFrom_KMAKeyPairType(value);
            }
            TypeConversionAction ITypeConverter<KMAKeyPairType>.GetConversionActionTo_long()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long> ITypeConverter<KMAKeyPairType>.Enumerate_long(KMAKeyPairType value)
            {
                
                yield break;
            }
            KMAKeyPairType ITypeConverter<KMAKeyPairType>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    KMAKeyPairType intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = KMAKeyPairType.TryParse(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        Throw.cannot_parse(value, "KMAKeyPairType");
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<KMAKeyPairType>.ConvertTo_string(KMAKeyPairType value)
            {
                return TypeConverter<string>.ConvertFrom_KMAKeyPairType(value);
            }
            TypeConversionAction ITypeConverter<KMAKeyPairType>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<KMAKeyPairType>.Enumerate_string(KMAKeyPairType value)
            {
                
                yield break;
            }
            KMAKeyPairType ITypeConverter<KMAKeyPairType>.ConvertFrom_List_string(List<string> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<string>' to 'KMAKeyPairType'.");
                
            }
            List<string> ITypeConverter<KMAKeyPairType>.ConvertTo_List_string(KMAKeyPairType value)
            {
                return TypeConverter<List<string>>.ConvertFrom_KMAKeyPairType(value);
            }
            TypeConversionAction ITypeConverter<KMAKeyPairType>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_WRAPINLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<KMAKeyPairType>.Enumerate_List_string(KMAKeyPairType value)
            {
                
                yield break;
            }
            KMAKeyPairType ITypeConverter<KMAKeyPairType>.ConvertFrom_KMAKeyPairType(KMAKeyPairType value)
            {
                
                return (KMAKeyPairType)value;
                
            }
            KMAKeyPairType ITypeConverter<KMAKeyPairType>.ConvertTo_KMAKeyPairType(KMAKeyPairType value)
            {
                return TypeConverter<KMAKeyPairType>.ConvertFrom_KMAKeyPairType(value);
            }
            TypeConversionAction ITypeConverter<KMAKeyPairType>.GetConversionActionTo_KMAKeyPairType()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<KMAKeyPairType> ITypeConverter<KMAKeyPairType>.Enumerate_KMAKeyPairType(KMAKeyPairType value)
            {
                
                yield break;
            }
            
            object ITypeConverter<object>.ConvertFrom_bool(bool value)
            {
                return value;
            }
            bool ITypeConverter<object>.ConvertTo_bool(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_bool()
            {
                throw new NotImplementedException();
            }
            IEnumerable<bool> ITypeConverter<object>.Enumerate_bool(object value)
            {
                throw new NotImplementedException();
            }
            
            object ITypeConverter<object>.ConvertFrom_long(long value)
            {
                return value;
            }
            long ITypeConverter<object>.ConvertTo_long(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_long()
            {
                throw new NotImplementedException();
            }
            IEnumerable<long> ITypeConverter<object>.Enumerate_long(object value)
            {
                throw new NotImplementedException();
            }
            
            object ITypeConverter<object>.ConvertFrom_string(string value)
            {
                return value;
            }
            string ITypeConverter<object>.ConvertTo_string(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_string()
            {
                throw new NotImplementedException();
            }
            IEnumerable<string> ITypeConverter<object>.Enumerate_string(object value)
            {
                throw new NotImplementedException();
            }
            
            object ITypeConverter<object>.ConvertFrom_List_string(List<string> value)
            {
                return value;
            }
            List<string> ITypeConverter<object>.ConvertTo_List_string(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_List_string()
            {
                throw new NotImplementedException();
            }
            IEnumerable<List<string>> ITypeConverter<object>.Enumerate_List_string(object value)
            {
                throw new NotImplementedException();
            }
            
            object ITypeConverter<object>.ConvertFrom_KMAKeyPairType(KMAKeyPairType value)
            {
                return value;
            }
            KMAKeyPairType ITypeConverter<object>.ConvertTo_KMAKeyPairType(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_KMAKeyPairType()
            {
                throw new NotImplementedException();
            }
            IEnumerable<KMAKeyPairType> ITypeConverter<object>.Enumerate_KMAKeyPairType(object value)
            {
                throw new NotImplementedException();
            }
            
        }
        internal static readonly ITypeConverter<T> s_type_converter = new _TypeConverterImpl() as ITypeConverter<T> ?? new TypeConverter<T>();
        #region Default implementation
        
        T ITypeConverter<T>.ConvertFrom_bool(bool value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        bool ITypeConverter<T>.ConvertTo_bool(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_bool()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<bool> ITypeConverter<T>.Enumerate_bool(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        
        T ITypeConverter<T>.ConvertFrom_long(long value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        long ITypeConverter<T>.ConvertTo_long(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_long()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<long> ITypeConverter<T>.Enumerate_long(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        
        T ITypeConverter<T>.ConvertFrom_string(string value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        string ITypeConverter<T>.ConvertTo_string(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_string()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<string> ITypeConverter<T>.Enumerate_string(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        
        T ITypeConverter<T>.ConvertFrom_List_string(List<string> value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        List<string> ITypeConverter<T>.ConvertTo_List_string(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_List_string()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<List<string>> ITypeConverter<T>.Enumerate_List_string(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        
        T ITypeConverter<T>.ConvertFrom_KMAKeyPairType(KMAKeyPairType value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        KMAKeyPairType ITypeConverter<T>.ConvertTo_KMAKeyPairType(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_KMAKeyPairType()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<KMAKeyPairType> ITypeConverter<T>.Enumerate_KMAKeyPairType(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        
        #endregion
        internal static readonly uint type_id = TypeSystem.GetTypeID(typeof(T));
        
        internal static T ConvertFrom_bool(bool value)
        {
            return s_type_converter.ConvertFrom_bool(value);
        }
        internal static bool ConvertTo_bool(T value)
        {
            return s_type_converter.ConvertTo_bool(value);
        }
        internal static TypeConversionAction GetConversionActionTo_bool()
        {
            return s_type_converter.GetConversionActionTo_bool();
        }
        internal static IEnumerable<bool> Enumerate_bool(T value)
        {
            return s_type_converter.Enumerate_bool(value);
        }
        
        internal static T ConvertFrom_long(long value)
        {
            return s_type_converter.ConvertFrom_long(value);
        }
        internal static long ConvertTo_long(T value)
        {
            return s_type_converter.ConvertTo_long(value);
        }
        internal static TypeConversionAction GetConversionActionTo_long()
        {
            return s_type_converter.GetConversionActionTo_long();
        }
        internal static IEnumerable<long> Enumerate_long(T value)
        {
            return s_type_converter.Enumerate_long(value);
        }
        
        internal static T ConvertFrom_string(string value)
        {
            return s_type_converter.ConvertFrom_string(value);
        }
        internal static string ConvertTo_string(T value)
        {
            return s_type_converter.ConvertTo_string(value);
        }
        internal static TypeConversionAction GetConversionActionTo_string()
        {
            return s_type_converter.GetConversionActionTo_string();
        }
        internal static IEnumerable<string> Enumerate_string(T value)
        {
            return s_type_converter.Enumerate_string(value);
        }
        
        internal static T ConvertFrom_List_string(List<string> value)
        {
            return s_type_converter.ConvertFrom_List_string(value);
        }
        internal static List<string> ConvertTo_List_string(T value)
        {
            return s_type_converter.ConvertTo_List_string(value);
        }
        internal static TypeConversionAction GetConversionActionTo_List_string()
        {
            return s_type_converter.GetConversionActionTo_List_string();
        }
        internal static IEnumerable<List<string>> Enumerate_List_string(T value)
        {
            return s_type_converter.Enumerate_List_string(value);
        }
        
        internal static T ConvertFrom_KMAKeyPairType(KMAKeyPairType value)
        {
            return s_type_converter.ConvertFrom_KMAKeyPairType(value);
        }
        internal static KMAKeyPairType ConvertTo_KMAKeyPairType(T value)
        {
            return s_type_converter.ConvertTo_KMAKeyPairType(value);
        }
        internal static TypeConversionAction GetConversionActionTo_KMAKeyPairType()
        {
            return s_type_converter.GetConversionActionTo_KMAKeyPairType();
        }
        internal static IEnumerable<KMAKeyPairType> Enumerate_KMAKeyPairType(T value)
        {
            return s_type_converter.Enumerate_KMAKeyPairType(value);
        }
        
    }
}

#pragma warning restore 162,168,649,660,661,1522
