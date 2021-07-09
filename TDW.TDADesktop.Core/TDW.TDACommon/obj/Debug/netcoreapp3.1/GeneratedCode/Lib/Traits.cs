#pragma warning disable 162,168,649,660,661,1522

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trinity.TSL;
using Trinity.TSL.Lib;
namespace TDW.TDACommon
{
    internal class TypeSystem
    {
        #region TypeID lookup table
        private static Dictionary<Type, uint> TypeIDLookupTable = new Dictionary<Type, uint>()
        {
            
            { typeof(long), 0 }
            ,
            { typeof(string), 1 }
            ,
            { typeof(long[]), 2 }
            ,
            { typeof(List<long>), 3 }
            ,
            { typeof(List<string>), 4 }
            ,
            { typeof(TDABasket), 5 }
            ,
            { typeof(TDALedgers), 6 }
            ,
        };
        #endregion
        #region CellTypeID lookup table
        private static Dictionary<Type, uint> CellTypeIDLookupTable = new Dictionary<Type, uint>()
        {
            
            { typeof(TDARootCell), 0 }
            ,
            { typeof(TDABasketItemCell), 1 }
            ,
            { typeof(TDASubledgerCell), 2 }
            ,
            { typeof(TDAMasterKeyLedgerCell), 3 }
            ,
            { typeof(TDAKeyRingLedgerCell), 4 }
            ,
            { typeof(TDAWalletLedgerCell), 5 }
            ,
            { typeof(TDAVDAddressLedgerCell), 6 }
            
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
        
        T ConvertFrom_long(long value);
        long ConvertTo_long(T value);
        TypeConversionAction GetConversionActionTo_long();
        IEnumerable<long> Enumerate_long(T value);
        
        T ConvertFrom_string(string value);
        string ConvertTo_string(T value);
        TypeConversionAction GetConversionActionTo_string();
        IEnumerable<string> Enumerate_string(T value);
        
        T ConvertFrom_long_Array_4(long[] value);
        long[] ConvertTo_long_Array_4(T value);
        TypeConversionAction GetConversionActionTo_long_Array_4();
        IEnumerable<long[]> Enumerate_long_Array_4(T value);
        
        T ConvertFrom_List_long(List<long> value);
        List<long> ConvertTo_List_long(T value);
        TypeConversionAction GetConversionActionTo_List_long();
        IEnumerable<List<long>> Enumerate_List_long(T value);
        
        T ConvertFrom_List_string(List<string> value);
        List<string> ConvertTo_List_string(T value);
        TypeConversionAction GetConversionActionTo_List_string();
        IEnumerable<List<string>> Enumerate_List_string(T value);
        
        T ConvertFrom_TDABasket(TDABasket value);
        TDABasket ConvertTo_TDABasket(T value);
        TypeConversionAction GetConversionActionTo_TDABasket();
        IEnumerable<TDABasket> Enumerate_TDABasket(T value);
        
        T ConvertFrom_TDALedgers(TDALedgers value);
        TDALedgers ConvertTo_TDALedgers(T value);
        TypeConversionAction GetConversionActionTo_TDALedgers();
        IEnumerable<TDALedgers> Enumerate_TDALedgers(T value);
        
    }
    internal class TypeConverter<T> : ITypeConverter<T>
    {
        internal class _TypeConverterImpl : ITypeConverter<object>
            
            , ITypeConverter<long>
        
            , ITypeConverter<string>
        
            , ITypeConverter<long[]>
        
            , ITypeConverter<List<long>>
        
            , ITypeConverter<List<string>>
        
            , ITypeConverter<TDABasket>
        
            , ITypeConverter<TDALedgers>
        
        {
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
            long ITypeConverter<long>.ConvertFrom_long_Array_4(long[] value)
            {
                
                throw new InvalidCastException("Invalid cast from 'long[]' to 'long'.");
                
            }
            long[] ITypeConverter<long>.ConvertTo_long_Array_4(long value)
            {
                return TypeConverter<long[]>.ConvertFrom_long(value);
            }
            TypeConversionAction ITypeConverter<long>.GetConversionActionTo_long_Array_4()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long[]> ITypeConverter<long>.Enumerate_long_Array_4(long value)
            {
                
                yield break;
            }
            long ITypeConverter<long>.ConvertFrom_List_long(List<long> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<long>' to 'long'.");
                
            }
            List<long> ITypeConverter<long>.ConvertTo_List_long(long value)
            {
                return TypeConverter<List<long>>.ConvertFrom_long(value);
            }
            TypeConversionAction ITypeConverter<long>.GetConversionActionTo_List_long()
            {
                
                return TypeConversionAction.TC_WRAPINLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<long>> ITypeConverter<long>.Enumerate_List_long(long value)
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
            long ITypeConverter<long>.ConvertFrom_TDABasket(TDABasket value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDABasket' to 'long'.");
                
            }
            TDABasket ITypeConverter<long>.ConvertTo_TDABasket(long value)
            {
                return TypeConverter<TDABasket>.ConvertFrom_long(value);
            }
            TypeConversionAction ITypeConverter<long>.GetConversionActionTo_TDABasket()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDABasket> ITypeConverter<long>.Enumerate_TDABasket(long value)
            {
                
                yield break;
            }
            long ITypeConverter<long>.ConvertFrom_TDALedgers(TDALedgers value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDALedgers' to 'long'.");
                
            }
            TDALedgers ITypeConverter<long>.ConvertTo_TDALedgers(long value)
            {
                return TypeConverter<TDALedgers>.ConvertFrom_long(value);
            }
            TypeConversionAction ITypeConverter<long>.GetConversionActionTo_TDALedgers()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDALedgers> ITypeConverter<long>.Enumerate_TDALedgers(long value)
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
            string ITypeConverter<string>.ConvertFrom_long_Array_4(long[] value)
            {
                
                return Serializer.ToString(value);
                
            }
            long[] ITypeConverter<string>.ConvertTo_long_Array_4(string value)
            {
                return TypeConverter<long[]>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_long_Array_4()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long[]> ITypeConverter<string>.Enumerate_long_Array_4(string value)
            {
                
                yield break;
            }
            string ITypeConverter<string>.ConvertFrom_List_long(List<long> value)
            {
                
                return Serializer.ToString(value);
                
            }
            List<long> ITypeConverter<string>.ConvertTo_List_long(string value)
            {
                return TypeConverter<List<long>>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_List_long()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<long>> ITypeConverter<string>.Enumerate_List_long(string value)
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
            string ITypeConverter<string>.ConvertFrom_TDABasket(TDABasket value)
            {
                
                return Serializer.ToString(value);
                
            }
            TDABasket ITypeConverter<string>.ConvertTo_TDABasket(string value)
            {
                return TypeConverter<TDABasket>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_TDABasket()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDABasket> ITypeConverter<string>.Enumerate_TDABasket(string value)
            {
                
                yield break;
            }
            string ITypeConverter<string>.ConvertFrom_TDALedgers(TDALedgers value)
            {
                
                return Serializer.ToString(value);
                
            }
            TDALedgers ITypeConverter<string>.ConvertTo_TDALedgers(string value)
            {
                return TypeConverter<TDALedgers>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_TDALedgers()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDALedgers> ITypeConverter<string>.Enumerate_TDALedgers(string value)
            {
                
                yield break;
            }
            long[] ITypeConverter<long[]>.ConvertFrom_long(long value)
            {
                
                throw new InvalidCastException("Invalid cast from 'long' to 'long[]'.");
                
            }
            long ITypeConverter<long[]>.ConvertTo_long(long[] value)
            {
                return TypeConverter<long>.ConvertFrom_long_Array_4(value);
            }
            TypeConversionAction ITypeConverter<long[]>.GetConversionActionTo_long()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long> ITypeConverter<long[]>.Enumerate_long(long[] value)
            {
                
                {
                    
                    for (int long_0 = 0; long_0 < 4; ++long_0)
                    
                    {
                        
                        yield return (value[long_0]);
                        
                    }
                }
                
                yield break;
            }
            long[] ITypeConverter<long[]>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    long[] intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = ExternalParser.TryParse_long_Array_4(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        Throw.cannot_parse(value, "long[]");
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<long[]>.ConvertTo_string(long[] value)
            {
                return TypeConverter<string>.ConvertFrom_long_Array_4(value);
            }
            TypeConversionAction ITypeConverter<long[]>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<long[]>.Enumerate_string(long[] value)
            {
                
                {
                    
                    for (int long_0 = 0; long_0 < 4; ++long_0)
                    
                    {
                        
                        yield return (TypeConverter<string>.ConvertFrom_long(value[long_0]));
                        
                    }
                }
                
                yield break;
            }
            long[] ITypeConverter<long[]>.ConvertFrom_long_Array_4(long[] value)
            {
                
                return (long[])value;
                
            }
            long[] ITypeConverter<long[]>.ConvertTo_long_Array_4(long[] value)
            {
                return TypeConverter<long[]>.ConvertFrom_long_Array_4(value);
            }
            TypeConversionAction ITypeConverter<long[]>.GetConversionActionTo_long_Array_4()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long[]> ITypeConverter<long[]>.Enumerate_long_Array_4(long[] value)
            {
                
                yield break;
            }
            long[] ITypeConverter<long[]>.ConvertFrom_List_long(List<long> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<long>' to 'long[]'.");
                
            }
            List<long> ITypeConverter<long[]>.ConvertTo_List_long(long[] value)
            {
                return TypeConverter<List<long>>.ConvertFrom_long_Array_4(value);
            }
            TypeConversionAction ITypeConverter<long[]>.GetConversionActionTo_List_long()
            {
                
                return TypeConversionAction.TC_ARRAYTOLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<long>> ITypeConverter<long[]>.Enumerate_List_long(long[] value)
            {
                
                {
                    
                    for (int long_0 = 0; long_0 < 4; ++long_0)
                    
                    {
                        
                        yield return (TypeConverter<List<long>>.ConvertFrom_long(value[long_0]));
                        
                    }
                }
                
                yield break;
            }
            long[] ITypeConverter<long[]>.ConvertFrom_List_string(List<string> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<string>' to 'long[]'.");
                
            }
            List<string> ITypeConverter<long[]>.ConvertTo_List_string(long[] value)
            {
                return TypeConverter<List<string>>.ConvertFrom_long_Array_4(value);
            }
            TypeConversionAction ITypeConverter<long[]>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_WRAPINLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<long[]>.Enumerate_List_string(long[] value)
            {
                
                {
                    
                    for (int long_0 = 0; long_0 < 4; ++long_0)
                    
                    {
                        
                        yield return (TypeConverter<List<string>>.ConvertFrom_long(value[long_0]));
                        
                    }
                }
                
                yield break;
            }
            long[] ITypeConverter<long[]>.ConvertFrom_TDABasket(TDABasket value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDABasket' to 'long[]'.");
                
            }
            TDABasket ITypeConverter<long[]>.ConvertTo_TDABasket(long[] value)
            {
                return TypeConverter<TDABasket>.ConvertFrom_long_Array_4(value);
            }
            TypeConversionAction ITypeConverter<long[]>.GetConversionActionTo_TDABasket()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDABasket> ITypeConverter<long[]>.Enumerate_TDABasket(long[] value)
            {
                
                yield break;
            }
            long[] ITypeConverter<long[]>.ConvertFrom_TDALedgers(TDALedgers value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDALedgers' to 'long[]'.");
                
            }
            TDALedgers ITypeConverter<long[]>.ConvertTo_TDALedgers(long[] value)
            {
                return TypeConverter<TDALedgers>.ConvertFrom_long_Array_4(value);
            }
            TypeConversionAction ITypeConverter<long[]>.GetConversionActionTo_TDALedgers()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDALedgers> ITypeConverter<long[]>.Enumerate_TDALedgers(long[] value)
            {
                
                yield break;
            }
            List<long> ITypeConverter<List<long>>.ConvertFrom_long(long value)
            {
                
                {
                    List<long> intermediate_result = new List<long>();
                    intermediate_result.Add(TypeConverter<long>.ConvertFrom_long(value));
                    return intermediate_result;
                }
                
            }
            long ITypeConverter<List<long>>.ConvertTo_long(List<long> value)
            {
                return TypeConverter<long>.ConvertFrom_List_long(value);
            }
            TypeConversionAction ITypeConverter<List<long>>.GetConversionActionTo_long()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long> ITypeConverter<List<long>>.Enumerate_long(List<long> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<long>.ConvertFrom_long(element);
                
                yield break;
            }
            List<long> ITypeConverter<List<long>>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    List<long> intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = ExternalParser.TryParse_List_long(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        try
                        {
                            long element = TypeConverter<long>.ConvertFrom_string(value);
                            intermediate_result = new List<long>();
                            intermediate_result.Add(element);
                        }
                        catch
                        {
                            throw new ArgumentException("Cannot parse \"" + value + "\" into either 'List<long>' or 'long'.");
                        }
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<List<long>>.ConvertTo_string(List<long> value)
            {
                return TypeConverter<string>.ConvertFrom_List_long(value);
            }
            TypeConversionAction ITypeConverter<List<long>>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<List<long>>.Enumerate_string(List<long> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<string>.ConvertFrom_long(element);
                
                yield break;
            }
            List<long> ITypeConverter<List<long>>.ConvertFrom_long_Array_4(long[] value)
            {
                
                return TypeConverter<long[]>.Enumerate_long(value).ToList();
                
            }
            long[] ITypeConverter<List<long>>.ConvertTo_long_Array_4(List<long> value)
            {
                return TypeConverter<long[]>.ConvertFrom_List_long(value);
            }
            TypeConversionAction ITypeConverter<List<long>>.GetConversionActionTo_long_Array_4()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long[]> ITypeConverter<List<long>>.Enumerate_long_Array_4(List<long> value)
            {
                
                yield break;
            }
            List<long> ITypeConverter<List<long>>.ConvertFrom_List_long(List<long> value)
            {
                
                return (List<long>)value;
                
            }
            List<long> ITypeConverter<List<long>>.ConvertTo_List_long(List<long> value)
            {
                return TypeConverter<List<long>>.ConvertFrom_List_long(value);
            }
            TypeConversionAction ITypeConverter<List<long>>.GetConversionActionTo_List_long()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<long>> ITypeConverter<List<long>>.Enumerate_List_long(List<long> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<List<long>>.ConvertFrom_long(element);
                
                yield break;
            }
            List<long> ITypeConverter<List<long>>.ConvertFrom_List_string(List<string> value)
            {
                
                {
                    List<long> intermediate_result = new List<long>();
                    foreach (var element in value)
                    {
                        intermediate_result.Add(TypeConverter<long>.ConvertFrom_string(element));
                    }
                    return intermediate_result;
                }
                
            }
            List<string> ITypeConverter<List<long>>.ConvertTo_List_string(List<long> value)
            {
                return TypeConverter<List<string>>.ConvertFrom_List_long(value);
            }
            TypeConversionAction ITypeConverter<List<long>>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_CONVERTLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<List<long>>.Enumerate_List_string(List<long> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<List<string>>.ConvertFrom_long(element);
                
                yield break;
            }
            List<long> ITypeConverter<List<long>>.ConvertFrom_TDABasket(TDABasket value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDABasket' to 'List<long>'.");
                
            }
            TDABasket ITypeConverter<List<long>>.ConvertTo_TDABasket(List<long> value)
            {
                return TypeConverter<TDABasket>.ConvertFrom_List_long(value);
            }
            TypeConversionAction ITypeConverter<List<long>>.GetConversionActionTo_TDABasket()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDABasket> ITypeConverter<List<long>>.Enumerate_TDABasket(List<long> value)
            {
                
                yield break;
            }
            List<long> ITypeConverter<List<long>>.ConvertFrom_TDALedgers(TDALedgers value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDALedgers' to 'List<long>'.");
                
            }
            TDALedgers ITypeConverter<List<long>>.ConvertTo_TDALedgers(List<long> value)
            {
                return TypeConverter<TDALedgers>.ConvertFrom_List_long(value);
            }
            TypeConversionAction ITypeConverter<List<long>>.GetConversionActionTo_TDALedgers()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDALedgers> ITypeConverter<List<long>>.Enumerate_TDALedgers(List<long> value)
            {
                
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
            List<string> ITypeConverter<List<string>>.ConvertFrom_long_Array_4(long[] value)
            {
                
                {
                    List<string> intermediate_result = new List<string>();
                    intermediate_result.Add(TypeConverter<string>.ConvertFrom_long_Array_4(value));
                    return intermediate_result;
                }
                
            }
            long[] ITypeConverter<List<string>>.ConvertTo_long_Array_4(List<string> value)
            {
                return TypeConverter<long[]>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_long_Array_4()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long[]> ITypeConverter<List<string>>.Enumerate_long_Array_4(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<long[]>.ConvertFrom_string(element);
                
                yield break;
            }
            List<string> ITypeConverter<List<string>>.ConvertFrom_List_long(List<long> value)
            {
                
                {
                    List<string> intermediate_result = new List<string>();
                    foreach (var element in value)
                    {
                        intermediate_result.Add(TypeConverter<string>.ConvertFrom_long(element));
                    }
                    return intermediate_result;
                }
                
            }
            List<long> ITypeConverter<List<string>>.ConvertTo_List_long(List<string> value)
            {
                return TypeConverter<List<long>>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_List_long()
            {
                
                return TypeConversionAction.TC_CONVERTLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<long>> ITypeConverter<List<string>>.Enumerate_List_long(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<List<long>>.ConvertFrom_string(element);
                
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
            List<string> ITypeConverter<List<string>>.ConvertFrom_TDABasket(TDABasket value)
            {
                
                {
                    List<string> intermediate_result = new List<string>();
                    intermediate_result.Add(TypeConverter<string>.ConvertFrom_TDABasket(value));
                    return intermediate_result;
                }
                
            }
            TDABasket ITypeConverter<List<string>>.ConvertTo_TDABasket(List<string> value)
            {
                return TypeConverter<TDABasket>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_TDABasket()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDABasket> ITypeConverter<List<string>>.Enumerate_TDABasket(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<TDABasket>.ConvertFrom_string(element);
                
                yield break;
            }
            List<string> ITypeConverter<List<string>>.ConvertFrom_TDALedgers(TDALedgers value)
            {
                
                {
                    List<string> intermediate_result = new List<string>();
                    intermediate_result.Add(TypeConverter<string>.ConvertFrom_TDALedgers(value));
                    return intermediate_result;
                }
                
            }
            TDALedgers ITypeConverter<List<string>>.ConvertTo_TDALedgers(List<string> value)
            {
                return TypeConverter<TDALedgers>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_TDALedgers()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDALedgers> ITypeConverter<List<string>>.Enumerate_TDALedgers(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<TDALedgers>.ConvertFrom_string(element);
                
                yield break;
            }
            TDABasket ITypeConverter<TDABasket>.ConvertFrom_long(long value)
            {
                
                throw new InvalidCastException("Invalid cast from 'long' to 'TDABasket'.");
                
            }
            long ITypeConverter<TDABasket>.ConvertTo_long(TDABasket value)
            {
                return TypeConverter<long>.ConvertFrom_TDABasket(value);
            }
            TypeConversionAction ITypeConverter<TDABasket>.GetConversionActionTo_long()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long> ITypeConverter<TDABasket>.Enumerate_long(TDABasket value)
            {
                
                yield break;
            }
            TDABasket ITypeConverter<TDABasket>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    TDABasket intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = TDABasket.TryParse(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        Throw.cannot_parse(value, "TDABasket");
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<TDABasket>.ConvertTo_string(TDABasket value)
            {
                return TypeConverter<string>.ConvertFrom_TDABasket(value);
            }
            TypeConversionAction ITypeConverter<TDABasket>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<TDABasket>.Enumerate_string(TDABasket value)
            {
                
                yield break;
            }
            TDABasket ITypeConverter<TDABasket>.ConvertFrom_long_Array_4(long[] value)
            {
                
                throw new InvalidCastException("Invalid cast from 'long[]' to 'TDABasket'.");
                
            }
            long[] ITypeConverter<TDABasket>.ConvertTo_long_Array_4(TDABasket value)
            {
                return TypeConverter<long[]>.ConvertFrom_TDABasket(value);
            }
            TypeConversionAction ITypeConverter<TDABasket>.GetConversionActionTo_long_Array_4()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long[]> ITypeConverter<TDABasket>.Enumerate_long_Array_4(TDABasket value)
            {
                
                yield break;
            }
            TDABasket ITypeConverter<TDABasket>.ConvertFrom_List_long(List<long> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<long>' to 'TDABasket'.");
                
            }
            List<long> ITypeConverter<TDABasket>.ConvertTo_List_long(TDABasket value)
            {
                return TypeConverter<List<long>>.ConvertFrom_TDABasket(value);
            }
            TypeConversionAction ITypeConverter<TDABasket>.GetConversionActionTo_List_long()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<long>> ITypeConverter<TDABasket>.Enumerate_List_long(TDABasket value)
            {
                
                yield break;
            }
            TDABasket ITypeConverter<TDABasket>.ConvertFrom_List_string(List<string> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<string>' to 'TDABasket'.");
                
            }
            List<string> ITypeConverter<TDABasket>.ConvertTo_List_string(TDABasket value)
            {
                return TypeConverter<List<string>>.ConvertFrom_TDABasket(value);
            }
            TypeConversionAction ITypeConverter<TDABasket>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_WRAPINLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<TDABasket>.Enumerate_List_string(TDABasket value)
            {
                
                yield break;
            }
            TDABasket ITypeConverter<TDABasket>.ConvertFrom_TDABasket(TDABasket value)
            {
                
                return (TDABasket)value;
                
            }
            TDABasket ITypeConverter<TDABasket>.ConvertTo_TDABasket(TDABasket value)
            {
                return TypeConverter<TDABasket>.ConvertFrom_TDABasket(value);
            }
            TypeConversionAction ITypeConverter<TDABasket>.GetConversionActionTo_TDABasket()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDABasket> ITypeConverter<TDABasket>.Enumerate_TDABasket(TDABasket value)
            {
                
                yield break;
            }
            TDABasket ITypeConverter<TDABasket>.ConvertFrom_TDALedgers(TDALedgers value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDALedgers' to 'TDABasket'.");
                
            }
            TDALedgers ITypeConverter<TDABasket>.ConvertTo_TDALedgers(TDABasket value)
            {
                return TypeConverter<TDALedgers>.ConvertFrom_TDABasket(value);
            }
            TypeConversionAction ITypeConverter<TDABasket>.GetConversionActionTo_TDALedgers()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDALedgers> ITypeConverter<TDABasket>.Enumerate_TDALedgers(TDABasket value)
            {
                
                yield break;
            }
            TDALedgers ITypeConverter<TDALedgers>.ConvertFrom_long(long value)
            {
                
                throw new InvalidCastException("Invalid cast from 'long' to 'TDALedgers'.");
                
            }
            long ITypeConverter<TDALedgers>.ConvertTo_long(TDALedgers value)
            {
                return TypeConverter<long>.ConvertFrom_TDALedgers(value);
            }
            TypeConversionAction ITypeConverter<TDALedgers>.GetConversionActionTo_long()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long> ITypeConverter<TDALedgers>.Enumerate_long(TDALedgers value)
            {
                
                yield break;
            }
            TDALedgers ITypeConverter<TDALedgers>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    TDALedgers intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = TDALedgers.TryParse(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        Throw.cannot_parse(value, "TDALedgers");
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<TDALedgers>.ConvertTo_string(TDALedgers value)
            {
                return TypeConverter<string>.ConvertFrom_TDALedgers(value);
            }
            TypeConversionAction ITypeConverter<TDALedgers>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<TDALedgers>.Enumerate_string(TDALedgers value)
            {
                
                yield break;
            }
            TDALedgers ITypeConverter<TDALedgers>.ConvertFrom_long_Array_4(long[] value)
            {
                
                throw new InvalidCastException("Invalid cast from 'long[]' to 'TDALedgers'.");
                
            }
            long[] ITypeConverter<TDALedgers>.ConvertTo_long_Array_4(TDALedgers value)
            {
                return TypeConverter<long[]>.ConvertFrom_TDALedgers(value);
            }
            TypeConversionAction ITypeConverter<TDALedgers>.GetConversionActionTo_long_Array_4()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long[]> ITypeConverter<TDALedgers>.Enumerate_long_Array_4(TDALedgers value)
            {
                
                yield break;
            }
            TDALedgers ITypeConverter<TDALedgers>.ConvertFrom_List_long(List<long> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<long>' to 'TDALedgers'.");
                
            }
            List<long> ITypeConverter<TDALedgers>.ConvertTo_List_long(TDALedgers value)
            {
                return TypeConverter<List<long>>.ConvertFrom_TDALedgers(value);
            }
            TypeConversionAction ITypeConverter<TDALedgers>.GetConversionActionTo_List_long()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<long>> ITypeConverter<TDALedgers>.Enumerate_List_long(TDALedgers value)
            {
                
                yield break;
            }
            TDALedgers ITypeConverter<TDALedgers>.ConvertFrom_List_string(List<string> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<string>' to 'TDALedgers'.");
                
            }
            List<string> ITypeConverter<TDALedgers>.ConvertTo_List_string(TDALedgers value)
            {
                return TypeConverter<List<string>>.ConvertFrom_TDALedgers(value);
            }
            TypeConversionAction ITypeConverter<TDALedgers>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_WRAPINLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<TDALedgers>.Enumerate_List_string(TDALedgers value)
            {
                
                yield break;
            }
            TDALedgers ITypeConverter<TDALedgers>.ConvertFrom_TDABasket(TDABasket value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDABasket' to 'TDALedgers'.");
                
            }
            TDABasket ITypeConverter<TDALedgers>.ConvertTo_TDABasket(TDALedgers value)
            {
                return TypeConverter<TDABasket>.ConvertFrom_TDALedgers(value);
            }
            TypeConversionAction ITypeConverter<TDALedgers>.GetConversionActionTo_TDABasket()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDABasket> ITypeConverter<TDALedgers>.Enumerate_TDABasket(TDALedgers value)
            {
                
                yield break;
            }
            TDALedgers ITypeConverter<TDALedgers>.ConvertFrom_TDALedgers(TDALedgers value)
            {
                
                return (TDALedgers)value;
                
            }
            TDALedgers ITypeConverter<TDALedgers>.ConvertTo_TDALedgers(TDALedgers value)
            {
                return TypeConverter<TDALedgers>.ConvertFrom_TDALedgers(value);
            }
            TypeConversionAction ITypeConverter<TDALedgers>.GetConversionActionTo_TDALedgers()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDALedgers> ITypeConverter<TDALedgers>.Enumerate_TDALedgers(TDALedgers value)
            {
                
                yield break;
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
            
            object ITypeConverter<object>.ConvertFrom_long_Array_4(long[] value)
            {
                return value;
            }
            long[] ITypeConverter<object>.ConvertTo_long_Array_4(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_long_Array_4()
            {
                throw new NotImplementedException();
            }
            IEnumerable<long[]> ITypeConverter<object>.Enumerate_long_Array_4(object value)
            {
                throw new NotImplementedException();
            }
            
            object ITypeConverter<object>.ConvertFrom_List_long(List<long> value)
            {
                return value;
            }
            List<long> ITypeConverter<object>.ConvertTo_List_long(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_List_long()
            {
                throw new NotImplementedException();
            }
            IEnumerable<List<long>> ITypeConverter<object>.Enumerate_List_long(object value)
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
            
            object ITypeConverter<object>.ConvertFrom_TDABasket(TDABasket value)
            {
                return value;
            }
            TDABasket ITypeConverter<object>.ConvertTo_TDABasket(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_TDABasket()
            {
                throw new NotImplementedException();
            }
            IEnumerable<TDABasket> ITypeConverter<object>.Enumerate_TDABasket(object value)
            {
                throw new NotImplementedException();
            }
            
            object ITypeConverter<object>.ConvertFrom_TDALedgers(TDALedgers value)
            {
                return value;
            }
            TDALedgers ITypeConverter<object>.ConvertTo_TDALedgers(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_TDALedgers()
            {
                throw new NotImplementedException();
            }
            IEnumerable<TDALedgers> ITypeConverter<object>.Enumerate_TDALedgers(object value)
            {
                throw new NotImplementedException();
            }
            
        }
        internal static readonly ITypeConverter<T> s_type_converter = new _TypeConverterImpl() as ITypeConverter<T> ?? new TypeConverter<T>();
        #region Default implementation
        
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
        
        T ITypeConverter<T>.ConvertFrom_long_Array_4(long[] value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        long[] ITypeConverter<T>.ConvertTo_long_Array_4(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_long_Array_4()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<long[]> ITypeConverter<T>.Enumerate_long_Array_4(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        
        T ITypeConverter<T>.ConvertFrom_List_long(List<long> value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        List<long> ITypeConverter<T>.ConvertTo_List_long(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_List_long()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<List<long>> ITypeConverter<T>.Enumerate_List_long(T value)
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
        
        T ITypeConverter<T>.ConvertFrom_TDABasket(TDABasket value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TDABasket ITypeConverter<T>.ConvertTo_TDABasket(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_TDABasket()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<TDABasket> ITypeConverter<T>.Enumerate_TDABasket(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        
        T ITypeConverter<T>.ConvertFrom_TDALedgers(TDALedgers value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TDALedgers ITypeConverter<T>.ConvertTo_TDALedgers(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_TDALedgers()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<TDALedgers> ITypeConverter<T>.Enumerate_TDALedgers(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        
        #endregion
        internal static readonly uint type_id = TypeSystem.GetTypeID(typeof(T));
        
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
        
        internal static T ConvertFrom_long_Array_4(long[] value)
        {
            return s_type_converter.ConvertFrom_long_Array_4(value);
        }
        internal static long[] ConvertTo_long_Array_4(T value)
        {
            return s_type_converter.ConvertTo_long_Array_4(value);
        }
        internal static TypeConversionAction GetConversionActionTo_long_Array_4()
        {
            return s_type_converter.GetConversionActionTo_long_Array_4();
        }
        internal static IEnumerable<long[]> Enumerate_long_Array_4(T value)
        {
            return s_type_converter.Enumerate_long_Array_4(value);
        }
        
        internal static T ConvertFrom_List_long(List<long> value)
        {
            return s_type_converter.ConvertFrom_List_long(value);
        }
        internal static List<long> ConvertTo_List_long(T value)
        {
            return s_type_converter.ConvertTo_List_long(value);
        }
        internal static TypeConversionAction GetConversionActionTo_List_long()
        {
            return s_type_converter.GetConversionActionTo_List_long();
        }
        internal static IEnumerable<List<long>> Enumerate_List_long(T value)
        {
            return s_type_converter.Enumerate_List_long(value);
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
        
        internal static T ConvertFrom_TDABasket(TDABasket value)
        {
            return s_type_converter.ConvertFrom_TDABasket(value);
        }
        internal static TDABasket ConvertTo_TDABasket(T value)
        {
            return s_type_converter.ConvertTo_TDABasket(value);
        }
        internal static TypeConversionAction GetConversionActionTo_TDABasket()
        {
            return s_type_converter.GetConversionActionTo_TDABasket();
        }
        internal static IEnumerable<TDABasket> Enumerate_TDABasket(T value)
        {
            return s_type_converter.Enumerate_TDABasket(value);
        }
        
        internal static T ConvertFrom_TDALedgers(TDALedgers value)
        {
            return s_type_converter.ConvertFrom_TDALedgers(value);
        }
        internal static TDALedgers ConvertTo_TDALedgers(T value)
        {
            return s_type_converter.ConvertTo_TDALedgers(value);
        }
        internal static TypeConversionAction GetConversionActionTo_TDALedgers()
        {
            return s_type_converter.GetConversionActionTo_TDALedgers();
        }
        internal static IEnumerable<TDALedgers> Enumerate_TDALedgers(T value)
        {
            return s_type_converter.Enumerate_TDALedgers(value);
        }
        
    }
}

#pragma warning restore 162,168,649,660,661,1522
