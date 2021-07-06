#pragma warning disable 162,168,649,660,661,1522

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trinity.TSL;
using Trinity.TSL.Lib;
namespace TDW.TRAServer
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
            { typeof(List<string>), 2 }
            ,
            { typeof(List<TRAClaim>), 3 }
            ,
            { typeof(List<TRAKeyValuePair>), 4 }
            ,
            { typeof(TRAClaim), 5 }
            ,
            { typeof(TRACredentialCore), 6 }
            ,
            { typeof(TRAEnvelope), 7 }
            ,
            { typeof(TRAKeyValuePair), 8 }
            ,
            { typeof(TRACredentialType), 9 }
            ,
            { typeof(TRAEncryptionFlag), 10 }
            ,
            { typeof(TRATrustLevel), 11 }
            ,
            { typeof(List<List<TRAKeyValuePair>>), 13 }
            ,
        };
        #endregion
        #region CellTypeID lookup table
        private static Dictionary<Type, uint> CellTypeIDLookupTable = new Dictionary<Type, uint>()
        {
            
            { typeof(TDWCredential), 0 }
            
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
        
        T ConvertFrom_List_string(List<string> value);
        List<string> ConvertTo_List_string(T value);
        TypeConversionAction GetConversionActionTo_List_string();
        IEnumerable<List<string>> Enumerate_List_string(T value);
        
        T ConvertFrom_List_TRAClaim(List<TRAClaim> value);
        List<TRAClaim> ConvertTo_List_TRAClaim(T value);
        TypeConversionAction GetConversionActionTo_List_TRAClaim();
        IEnumerable<List<TRAClaim>> Enumerate_List_TRAClaim(T value);
        
        T ConvertFrom_List_TRAKeyValuePair(List<TRAKeyValuePair> value);
        List<TRAKeyValuePair> ConvertTo_List_TRAKeyValuePair(T value);
        TypeConversionAction GetConversionActionTo_List_TRAKeyValuePair();
        IEnumerable<List<TRAKeyValuePair>> Enumerate_List_TRAKeyValuePair(T value);
        
        T ConvertFrom_TRAClaim(TRAClaim value);
        TRAClaim ConvertTo_TRAClaim(T value);
        TypeConversionAction GetConversionActionTo_TRAClaim();
        IEnumerable<TRAClaim> Enumerate_TRAClaim(T value);
        
        T ConvertFrom_TRACredentialCore(TRACredentialCore value);
        TRACredentialCore ConvertTo_TRACredentialCore(T value);
        TypeConversionAction GetConversionActionTo_TRACredentialCore();
        IEnumerable<TRACredentialCore> Enumerate_TRACredentialCore(T value);
        
        T ConvertFrom_TRAEnvelope(TRAEnvelope value);
        TRAEnvelope ConvertTo_TRAEnvelope(T value);
        TypeConversionAction GetConversionActionTo_TRAEnvelope();
        IEnumerable<TRAEnvelope> Enumerate_TRAEnvelope(T value);
        
        T ConvertFrom_TRAKeyValuePair(TRAKeyValuePair value);
        TRAKeyValuePair ConvertTo_TRAKeyValuePair(T value);
        TypeConversionAction GetConversionActionTo_TRAKeyValuePair();
        IEnumerable<TRAKeyValuePair> Enumerate_TRAKeyValuePair(T value);
        
        T ConvertFrom_TRACredentialType(TRACredentialType value);
        TRACredentialType ConvertTo_TRACredentialType(T value);
        TypeConversionAction GetConversionActionTo_TRACredentialType();
        IEnumerable<TRACredentialType> Enumerate_TRACredentialType(T value);
        
        T ConvertFrom_TRAEncryptionFlag(TRAEncryptionFlag value);
        TRAEncryptionFlag ConvertTo_TRAEncryptionFlag(T value);
        TypeConversionAction GetConversionActionTo_TRAEncryptionFlag();
        IEnumerable<TRAEncryptionFlag> Enumerate_TRAEncryptionFlag(T value);
        
        T ConvertFrom_TRATrustLevel(TRATrustLevel value);
        TRATrustLevel ConvertTo_TRATrustLevel(T value);
        TypeConversionAction GetConversionActionTo_TRATrustLevel();
        IEnumerable<TRATrustLevel> Enumerate_TRATrustLevel(T value);
        
        T ConvertFrom_List_List_TRAKeyValuePair(List<List<TRAKeyValuePair>> value);
        List<List<TRAKeyValuePair>> ConvertTo_List_List_TRAKeyValuePair(T value);
        TypeConversionAction GetConversionActionTo_List_List_TRAKeyValuePair();
        IEnumerable<List<List<TRAKeyValuePair>>> Enumerate_List_List_TRAKeyValuePair(T value);
        
    }
    internal class TypeConverter<T> : ITypeConverter<T>
    {
        internal class _TypeConverterImpl : ITypeConverter<object>
            
            , ITypeConverter<long>
        
            , ITypeConverter<string>
        
            , ITypeConverter<List<string>>
        
            , ITypeConverter<List<TRAClaim>>
        
            , ITypeConverter<List<TRAKeyValuePair>>
        
            , ITypeConverter<TRAClaim>
        
            , ITypeConverter<TRACredentialCore>
        
            , ITypeConverter<TRAEnvelope>
        
            , ITypeConverter<TRAKeyValuePair>
        
            , ITypeConverter<TRACredentialType>
        
            , ITypeConverter<TRAEncryptionFlag>
        
            , ITypeConverter<TRATrustLevel>
        
            , ITypeConverter<List<List<TRAKeyValuePair>>>
        
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
            long ITypeConverter<long>.ConvertFrom_List_TRAClaim(List<TRAClaim> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<TRAClaim>' to 'long'.");
                
            }
            List<TRAClaim> ITypeConverter<long>.ConvertTo_List_TRAClaim(long value)
            {
                return TypeConverter<List<TRAClaim>>.ConvertFrom_long(value);
            }
            TypeConversionAction ITypeConverter<long>.GetConversionActionTo_List_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAClaim>> ITypeConverter<long>.Enumerate_List_TRAClaim(long value)
            {
                
                yield break;
            }
            long ITypeConverter<long>.ConvertFrom_List_TRAKeyValuePair(List<TRAKeyValuePair> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<TRAKeyValuePair>' to 'long'.");
                
            }
            List<TRAKeyValuePair> ITypeConverter<long>.ConvertTo_List_TRAKeyValuePair(long value)
            {
                return TypeConverter<List<TRAKeyValuePair>>.ConvertFrom_long(value);
            }
            TypeConversionAction ITypeConverter<long>.GetConversionActionTo_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAKeyValuePair>> ITypeConverter<long>.Enumerate_List_TRAKeyValuePair(long value)
            {
                
                yield break;
            }
            long ITypeConverter<long>.ConvertFrom_TRAClaim(TRAClaim value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAClaim' to 'long'.");
                
            }
            TRAClaim ITypeConverter<long>.ConvertTo_TRAClaim(long value)
            {
                return TypeConverter<TRAClaim>.ConvertFrom_long(value);
            }
            TypeConversionAction ITypeConverter<long>.GetConversionActionTo_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAClaim> ITypeConverter<long>.Enumerate_TRAClaim(long value)
            {
                
                yield break;
            }
            long ITypeConverter<long>.ConvertFrom_TRACredentialCore(TRACredentialCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialCore' to 'long'.");
                
            }
            TRACredentialCore ITypeConverter<long>.ConvertTo_TRACredentialCore(long value)
            {
                return TypeConverter<TRACredentialCore>.ConvertFrom_long(value);
            }
            TypeConversionAction ITypeConverter<long>.GetConversionActionTo_TRACredentialCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialCore> ITypeConverter<long>.Enumerate_TRACredentialCore(long value)
            {
                
                yield break;
            }
            long ITypeConverter<long>.ConvertFrom_TRAEnvelope(TRAEnvelope value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAEnvelope' to 'long'.");
                
            }
            TRAEnvelope ITypeConverter<long>.ConvertTo_TRAEnvelope(long value)
            {
                return TypeConverter<TRAEnvelope>.ConvertFrom_long(value);
            }
            TypeConversionAction ITypeConverter<long>.GetConversionActionTo_TRAEnvelope()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEnvelope> ITypeConverter<long>.Enumerate_TRAEnvelope(long value)
            {
                
                yield break;
            }
            long ITypeConverter<long>.ConvertFrom_TRAKeyValuePair(TRAKeyValuePair value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAKeyValuePair' to 'long'.");
                
            }
            TRAKeyValuePair ITypeConverter<long>.ConvertTo_TRAKeyValuePair(long value)
            {
                return TypeConverter<TRAKeyValuePair>.ConvertFrom_long(value);
            }
            TypeConversionAction ITypeConverter<long>.GetConversionActionTo_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAKeyValuePair> ITypeConverter<long>.Enumerate_TRAKeyValuePair(long value)
            {
                
                yield break;
            }
            long ITypeConverter<long>.ConvertFrom_TRACredentialType(TRACredentialType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialType' to 'long'.");
                
            }
            TRACredentialType ITypeConverter<long>.ConvertTo_TRACredentialType(long value)
            {
                return TypeConverter<TRACredentialType>.ConvertFrom_long(value);
            }
            TypeConversionAction ITypeConverter<long>.GetConversionActionTo_TRACredentialType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialType> ITypeConverter<long>.Enumerate_TRACredentialType(long value)
            {
                
                yield break;
            }
            long ITypeConverter<long>.ConvertFrom_TRAEncryptionFlag(TRAEncryptionFlag value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAEncryptionFlag' to 'long'.");
                
            }
            TRAEncryptionFlag ITypeConverter<long>.ConvertTo_TRAEncryptionFlag(long value)
            {
                return TypeConverter<TRAEncryptionFlag>.ConvertFrom_long(value);
            }
            TypeConversionAction ITypeConverter<long>.GetConversionActionTo_TRAEncryptionFlag()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEncryptionFlag> ITypeConverter<long>.Enumerate_TRAEncryptionFlag(long value)
            {
                
                yield break;
            }
            long ITypeConverter<long>.ConvertFrom_TRATrustLevel(TRATrustLevel value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRATrustLevel' to 'long'.");
                
            }
            TRATrustLevel ITypeConverter<long>.ConvertTo_TRATrustLevel(long value)
            {
                return TypeConverter<TRATrustLevel>.ConvertFrom_long(value);
            }
            TypeConversionAction ITypeConverter<long>.GetConversionActionTo_TRATrustLevel()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRATrustLevel> ITypeConverter<long>.Enumerate_TRATrustLevel(long value)
            {
                
                yield break;
            }
            long ITypeConverter<long>.ConvertFrom_List_List_TRAKeyValuePair(List<List<TRAKeyValuePair>> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<List<TRAKeyValuePair>>' to 'long'.");
                
            }
            List<List<TRAKeyValuePair>> ITypeConverter<long>.ConvertTo_List_List_TRAKeyValuePair(long value)
            {
                return TypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_long(value);
            }
            TypeConversionAction ITypeConverter<long>.GetConversionActionTo_List_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<List<TRAKeyValuePair>>> ITypeConverter<long>.Enumerate_List_List_TRAKeyValuePair(long value)
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
            string ITypeConverter<string>.ConvertFrom_List_TRAClaim(List<TRAClaim> value)
            {
                
                return Serializer.ToString(value);
                
            }
            List<TRAClaim> ITypeConverter<string>.ConvertTo_List_TRAClaim(string value)
            {
                return TypeConverter<List<TRAClaim>>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_List_TRAClaim()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAClaim>> ITypeConverter<string>.Enumerate_List_TRAClaim(string value)
            {
                
                yield break;
            }
            string ITypeConverter<string>.ConvertFrom_List_TRAKeyValuePair(List<TRAKeyValuePair> value)
            {
                
                return Serializer.ToString(value);
                
            }
            List<TRAKeyValuePair> ITypeConverter<string>.ConvertTo_List_TRAKeyValuePair(string value)
            {
                return TypeConverter<List<TRAKeyValuePair>>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAKeyValuePair>> ITypeConverter<string>.Enumerate_List_TRAKeyValuePair(string value)
            {
                
                yield break;
            }
            string ITypeConverter<string>.ConvertFrom_TRAClaim(TRAClaim value)
            {
                
                return Serializer.ToString(value);
                
            }
            TRAClaim ITypeConverter<string>.ConvertTo_TRAClaim(string value)
            {
                return TypeConverter<TRAClaim>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_TRAClaim()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAClaim> ITypeConverter<string>.Enumerate_TRAClaim(string value)
            {
                
                yield break;
            }
            string ITypeConverter<string>.ConvertFrom_TRACredentialCore(TRACredentialCore value)
            {
                
                return Serializer.ToString(value);
                
            }
            TRACredentialCore ITypeConverter<string>.ConvertTo_TRACredentialCore(string value)
            {
                return TypeConverter<TRACredentialCore>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_TRACredentialCore()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialCore> ITypeConverter<string>.Enumerate_TRACredentialCore(string value)
            {
                
                yield break;
            }
            string ITypeConverter<string>.ConvertFrom_TRAEnvelope(TRAEnvelope value)
            {
                
                return Serializer.ToString(value);
                
            }
            TRAEnvelope ITypeConverter<string>.ConvertTo_TRAEnvelope(string value)
            {
                return TypeConverter<TRAEnvelope>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_TRAEnvelope()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEnvelope> ITypeConverter<string>.Enumerate_TRAEnvelope(string value)
            {
                
                yield break;
            }
            string ITypeConverter<string>.ConvertFrom_TRAKeyValuePair(TRAKeyValuePair value)
            {
                
                return Serializer.ToString(value);
                
            }
            TRAKeyValuePair ITypeConverter<string>.ConvertTo_TRAKeyValuePair(string value)
            {
                return TypeConverter<TRAKeyValuePair>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAKeyValuePair> ITypeConverter<string>.Enumerate_TRAKeyValuePair(string value)
            {
                
                yield break;
            }
            string ITypeConverter<string>.ConvertFrom_TRACredentialType(TRACredentialType value)
            {
                
                return Serializer.ToString(value);
                
            }
            TRACredentialType ITypeConverter<string>.ConvertTo_TRACredentialType(string value)
            {
                return TypeConverter<TRACredentialType>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_TRACredentialType()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialType> ITypeConverter<string>.Enumerate_TRACredentialType(string value)
            {
                
                yield break;
            }
            string ITypeConverter<string>.ConvertFrom_TRAEncryptionFlag(TRAEncryptionFlag value)
            {
                
                return Serializer.ToString(value);
                
            }
            TRAEncryptionFlag ITypeConverter<string>.ConvertTo_TRAEncryptionFlag(string value)
            {
                return TypeConverter<TRAEncryptionFlag>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_TRAEncryptionFlag()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEncryptionFlag> ITypeConverter<string>.Enumerate_TRAEncryptionFlag(string value)
            {
                
                yield break;
            }
            string ITypeConverter<string>.ConvertFrom_TRATrustLevel(TRATrustLevel value)
            {
                
                return Serializer.ToString(value);
                
            }
            TRATrustLevel ITypeConverter<string>.ConvertTo_TRATrustLevel(string value)
            {
                return TypeConverter<TRATrustLevel>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_TRATrustLevel()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRATrustLevel> ITypeConverter<string>.Enumerate_TRATrustLevel(string value)
            {
                
                yield break;
            }
            string ITypeConverter<string>.ConvertFrom_List_List_TRAKeyValuePair(List<List<TRAKeyValuePair>> value)
            {
                
                return Serializer.ToString(value);
                
            }
            List<List<TRAKeyValuePair>> ITypeConverter<string>.ConvertTo_List_List_TRAKeyValuePair(string value)
            {
                return TypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_List_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<List<TRAKeyValuePair>>> ITypeConverter<string>.Enumerate_List_List_TRAKeyValuePair(string value)
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
            List<string> ITypeConverter<List<string>>.ConvertFrom_List_TRAClaim(List<TRAClaim> value)
            {
                
                {
                    List<string> intermediate_result = new List<string>();
                    foreach (var element in value)
                    {
                        intermediate_result.Add(TypeConverter<string>.ConvertFrom_TRAClaim(element));
                    }
                    return intermediate_result;
                }
                
            }
            List<TRAClaim> ITypeConverter<List<string>>.ConvertTo_List_TRAClaim(List<string> value)
            {
                return TypeConverter<List<TRAClaim>>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_List_TRAClaim()
            {
                
                return TypeConversionAction.TC_CONVERTLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAClaim>> ITypeConverter<List<string>>.Enumerate_List_TRAClaim(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<List<TRAClaim>>.ConvertFrom_string(element);
                
                yield break;
            }
            List<string> ITypeConverter<List<string>>.ConvertFrom_List_TRAKeyValuePair(List<TRAKeyValuePair> value)
            {
                
                {
                    List<string> intermediate_result = new List<string>();
                    foreach (var element in value)
                    {
                        intermediate_result.Add(TypeConverter<string>.ConvertFrom_TRAKeyValuePair(element));
                    }
                    return intermediate_result;
                }
                
            }
            List<TRAKeyValuePair> ITypeConverter<List<string>>.ConvertTo_List_TRAKeyValuePair(List<string> value)
            {
                return TypeConverter<List<TRAKeyValuePair>>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_CONVERTLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAKeyValuePair>> ITypeConverter<List<string>>.Enumerate_List_TRAKeyValuePair(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<List<TRAKeyValuePair>>.ConvertFrom_string(element);
                
                yield break;
            }
            List<string> ITypeConverter<List<string>>.ConvertFrom_TRAClaim(TRAClaim value)
            {
                
                {
                    List<string> intermediate_result = new List<string>();
                    intermediate_result.Add(TypeConverter<string>.ConvertFrom_TRAClaim(value));
                    return intermediate_result;
                }
                
            }
            TRAClaim ITypeConverter<List<string>>.ConvertTo_TRAClaim(List<string> value)
            {
                return TypeConverter<TRAClaim>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAClaim> ITypeConverter<List<string>>.Enumerate_TRAClaim(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<TRAClaim>.ConvertFrom_string(element);
                
                yield break;
            }
            List<string> ITypeConverter<List<string>>.ConvertFrom_TRACredentialCore(TRACredentialCore value)
            {
                
                {
                    List<string> intermediate_result = new List<string>();
                    intermediate_result.Add(TypeConverter<string>.ConvertFrom_TRACredentialCore(value));
                    return intermediate_result;
                }
                
            }
            TRACredentialCore ITypeConverter<List<string>>.ConvertTo_TRACredentialCore(List<string> value)
            {
                return TypeConverter<TRACredentialCore>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_TRACredentialCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialCore> ITypeConverter<List<string>>.Enumerate_TRACredentialCore(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<TRACredentialCore>.ConvertFrom_string(element);
                
                yield break;
            }
            List<string> ITypeConverter<List<string>>.ConvertFrom_TRAEnvelope(TRAEnvelope value)
            {
                
                {
                    List<string> intermediate_result = new List<string>();
                    intermediate_result.Add(TypeConverter<string>.ConvertFrom_TRAEnvelope(value));
                    return intermediate_result;
                }
                
            }
            TRAEnvelope ITypeConverter<List<string>>.ConvertTo_TRAEnvelope(List<string> value)
            {
                return TypeConverter<TRAEnvelope>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_TRAEnvelope()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEnvelope> ITypeConverter<List<string>>.Enumerate_TRAEnvelope(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<TRAEnvelope>.ConvertFrom_string(element);
                
                yield break;
            }
            List<string> ITypeConverter<List<string>>.ConvertFrom_TRAKeyValuePair(TRAKeyValuePair value)
            {
                
                {
                    List<string> intermediate_result = new List<string>();
                    intermediate_result.Add(TypeConverter<string>.ConvertFrom_TRAKeyValuePair(value));
                    return intermediate_result;
                }
                
            }
            TRAKeyValuePair ITypeConverter<List<string>>.ConvertTo_TRAKeyValuePair(List<string> value)
            {
                return TypeConverter<TRAKeyValuePair>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAKeyValuePair> ITypeConverter<List<string>>.Enumerate_TRAKeyValuePair(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<TRAKeyValuePair>.ConvertFrom_string(element);
                
                yield break;
            }
            List<string> ITypeConverter<List<string>>.ConvertFrom_TRACredentialType(TRACredentialType value)
            {
                
                {
                    List<string> intermediate_result = new List<string>();
                    intermediate_result.Add(TypeConverter<string>.ConvertFrom_TRACredentialType(value));
                    return intermediate_result;
                }
                
            }
            TRACredentialType ITypeConverter<List<string>>.ConvertTo_TRACredentialType(List<string> value)
            {
                return TypeConverter<TRACredentialType>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_TRACredentialType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialType> ITypeConverter<List<string>>.Enumerate_TRACredentialType(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<TRACredentialType>.ConvertFrom_string(element);
                
                yield break;
            }
            List<string> ITypeConverter<List<string>>.ConvertFrom_TRAEncryptionFlag(TRAEncryptionFlag value)
            {
                
                {
                    List<string> intermediate_result = new List<string>();
                    intermediate_result.Add(TypeConverter<string>.ConvertFrom_TRAEncryptionFlag(value));
                    return intermediate_result;
                }
                
            }
            TRAEncryptionFlag ITypeConverter<List<string>>.ConvertTo_TRAEncryptionFlag(List<string> value)
            {
                return TypeConverter<TRAEncryptionFlag>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_TRAEncryptionFlag()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEncryptionFlag> ITypeConverter<List<string>>.Enumerate_TRAEncryptionFlag(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<TRAEncryptionFlag>.ConvertFrom_string(element);
                
                yield break;
            }
            List<string> ITypeConverter<List<string>>.ConvertFrom_TRATrustLevel(TRATrustLevel value)
            {
                
                {
                    List<string> intermediate_result = new List<string>();
                    intermediate_result.Add(TypeConverter<string>.ConvertFrom_TRATrustLevel(value));
                    return intermediate_result;
                }
                
            }
            TRATrustLevel ITypeConverter<List<string>>.ConvertTo_TRATrustLevel(List<string> value)
            {
                return TypeConverter<TRATrustLevel>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_TRATrustLevel()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRATrustLevel> ITypeConverter<List<string>>.Enumerate_TRATrustLevel(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<TRATrustLevel>.ConvertFrom_string(element);
                
                yield break;
            }
            List<string> ITypeConverter<List<string>>.ConvertFrom_List_List_TRAKeyValuePair(List<List<TRAKeyValuePair>> value)
            {
                
                {
                    List<string> intermediate_result = new List<string>();
                    foreach (var element in value)
                    {
                        intermediate_result.Add(TypeConverter<string>.ConvertFrom_List_TRAKeyValuePair(element));
                    }
                    return intermediate_result;
                }
                
            }
            List<List<TRAKeyValuePair>> ITypeConverter<List<string>>.ConvertTo_List_List_TRAKeyValuePair(List<string> value)
            {
                return TypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_List_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_CONVERTLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<List<TRAKeyValuePair>>> ITypeConverter<List<string>>.Enumerate_List_List_TRAKeyValuePair(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_string(element);
                
                yield break;
            }
            List<TRAClaim> ITypeConverter<List<TRAClaim>>.ConvertFrom_long(long value)
            {
                
                throw new InvalidCastException("Invalid cast from 'long' to 'List<TRAClaim>'.");
                
            }
            long ITypeConverter<List<TRAClaim>>.ConvertTo_long(List<TRAClaim> value)
            {
                return TypeConverter<long>.ConvertFrom_List_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<List<TRAClaim>>.GetConversionActionTo_long()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long> ITypeConverter<List<TRAClaim>>.Enumerate_long(List<TRAClaim> value)
            {
                
                yield break;
            }
            List<TRAClaim> ITypeConverter<List<TRAClaim>>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    List<TRAClaim> intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = ExternalParser.TryParse_List_TRAClaim(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        try
                        {
                            TRAClaim element = TypeConverter<TRAClaim>.ConvertFrom_string(value);
                            intermediate_result = new List<TRAClaim>();
                            intermediate_result.Add(element);
                        }
                        catch
                        {
                            throw new ArgumentException("Cannot parse \"" + value + "\" into either 'List<TRAClaim>' or 'TRAClaim'.");
                        }
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<List<TRAClaim>>.ConvertTo_string(List<TRAClaim> value)
            {
                return TypeConverter<string>.ConvertFrom_List_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<List<TRAClaim>>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<List<TRAClaim>>.Enumerate_string(List<TRAClaim> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<string>.ConvertFrom_TRAClaim(element);
                
                yield break;
            }
            List<TRAClaim> ITypeConverter<List<TRAClaim>>.ConvertFrom_List_string(List<string> value)
            {
                
                {
                    List<TRAClaim> intermediate_result = new List<TRAClaim>();
                    foreach (var element in value)
                    {
                        intermediate_result.Add(TypeConverter<TRAClaim>.ConvertFrom_string(element));
                    }
                    return intermediate_result;
                }
                
            }
            List<string> ITypeConverter<List<TRAClaim>>.ConvertTo_List_string(List<TRAClaim> value)
            {
                return TypeConverter<List<string>>.ConvertFrom_List_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<List<TRAClaim>>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_CONVERTLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<List<TRAClaim>>.Enumerate_List_string(List<TRAClaim> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<List<string>>.ConvertFrom_TRAClaim(element);
                
                yield break;
            }
            List<TRAClaim> ITypeConverter<List<TRAClaim>>.ConvertFrom_List_TRAClaim(List<TRAClaim> value)
            {
                
                return (List<TRAClaim>)value;
                
            }
            List<TRAClaim> ITypeConverter<List<TRAClaim>>.ConvertTo_List_TRAClaim(List<TRAClaim> value)
            {
                return TypeConverter<List<TRAClaim>>.ConvertFrom_List_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<List<TRAClaim>>.GetConversionActionTo_List_TRAClaim()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAClaim>> ITypeConverter<List<TRAClaim>>.Enumerate_List_TRAClaim(List<TRAClaim> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<List<TRAClaim>>.ConvertFrom_TRAClaim(element);
                
                yield break;
            }
            List<TRAClaim> ITypeConverter<List<TRAClaim>>.ConvertFrom_List_TRAKeyValuePair(List<TRAKeyValuePair> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<TRAKeyValuePair>' to 'List<TRAClaim>'.");
                
            }
            List<TRAKeyValuePair> ITypeConverter<List<TRAClaim>>.ConvertTo_List_TRAKeyValuePair(List<TRAClaim> value)
            {
                return TypeConverter<List<TRAKeyValuePair>>.ConvertFrom_List_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<List<TRAClaim>>.GetConversionActionTo_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAKeyValuePair>> ITypeConverter<List<TRAClaim>>.Enumerate_List_TRAKeyValuePair(List<TRAClaim> value)
            {
                
                yield break;
            }
            List<TRAClaim> ITypeConverter<List<TRAClaim>>.ConvertFrom_TRAClaim(TRAClaim value)
            {
                
                {
                    List<TRAClaim> intermediate_result = new List<TRAClaim>();
                    intermediate_result.Add(TypeConverter<TRAClaim>.ConvertFrom_TRAClaim(value));
                    return intermediate_result;
                }
                
            }
            TRAClaim ITypeConverter<List<TRAClaim>>.ConvertTo_TRAClaim(List<TRAClaim> value)
            {
                return TypeConverter<TRAClaim>.ConvertFrom_List_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<List<TRAClaim>>.GetConversionActionTo_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAClaim> ITypeConverter<List<TRAClaim>>.Enumerate_TRAClaim(List<TRAClaim> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<TRAClaim>.ConvertFrom_TRAClaim(element);
                
                yield break;
            }
            List<TRAClaim> ITypeConverter<List<TRAClaim>>.ConvertFrom_TRACredentialCore(TRACredentialCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialCore' to 'List<TRAClaim>'.");
                
            }
            TRACredentialCore ITypeConverter<List<TRAClaim>>.ConvertTo_TRACredentialCore(List<TRAClaim> value)
            {
                return TypeConverter<TRACredentialCore>.ConvertFrom_List_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<List<TRAClaim>>.GetConversionActionTo_TRACredentialCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialCore> ITypeConverter<List<TRAClaim>>.Enumerate_TRACredentialCore(List<TRAClaim> value)
            {
                
                yield break;
            }
            List<TRAClaim> ITypeConverter<List<TRAClaim>>.ConvertFrom_TRAEnvelope(TRAEnvelope value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAEnvelope' to 'List<TRAClaim>'.");
                
            }
            TRAEnvelope ITypeConverter<List<TRAClaim>>.ConvertTo_TRAEnvelope(List<TRAClaim> value)
            {
                return TypeConverter<TRAEnvelope>.ConvertFrom_List_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<List<TRAClaim>>.GetConversionActionTo_TRAEnvelope()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEnvelope> ITypeConverter<List<TRAClaim>>.Enumerate_TRAEnvelope(List<TRAClaim> value)
            {
                
                yield break;
            }
            List<TRAClaim> ITypeConverter<List<TRAClaim>>.ConvertFrom_TRAKeyValuePair(TRAKeyValuePair value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAKeyValuePair' to 'List<TRAClaim>'.");
                
            }
            TRAKeyValuePair ITypeConverter<List<TRAClaim>>.ConvertTo_TRAKeyValuePair(List<TRAClaim> value)
            {
                return TypeConverter<TRAKeyValuePair>.ConvertFrom_List_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<List<TRAClaim>>.GetConversionActionTo_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAKeyValuePair> ITypeConverter<List<TRAClaim>>.Enumerate_TRAKeyValuePair(List<TRAClaim> value)
            {
                
                yield break;
            }
            List<TRAClaim> ITypeConverter<List<TRAClaim>>.ConvertFrom_TRACredentialType(TRACredentialType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialType' to 'List<TRAClaim>'.");
                
            }
            TRACredentialType ITypeConverter<List<TRAClaim>>.ConvertTo_TRACredentialType(List<TRAClaim> value)
            {
                return TypeConverter<TRACredentialType>.ConvertFrom_List_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<List<TRAClaim>>.GetConversionActionTo_TRACredentialType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialType> ITypeConverter<List<TRAClaim>>.Enumerate_TRACredentialType(List<TRAClaim> value)
            {
                
                yield break;
            }
            List<TRAClaim> ITypeConverter<List<TRAClaim>>.ConvertFrom_TRAEncryptionFlag(TRAEncryptionFlag value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAEncryptionFlag' to 'List<TRAClaim>'.");
                
            }
            TRAEncryptionFlag ITypeConverter<List<TRAClaim>>.ConvertTo_TRAEncryptionFlag(List<TRAClaim> value)
            {
                return TypeConverter<TRAEncryptionFlag>.ConvertFrom_List_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<List<TRAClaim>>.GetConversionActionTo_TRAEncryptionFlag()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEncryptionFlag> ITypeConverter<List<TRAClaim>>.Enumerate_TRAEncryptionFlag(List<TRAClaim> value)
            {
                
                yield break;
            }
            List<TRAClaim> ITypeConverter<List<TRAClaim>>.ConvertFrom_TRATrustLevel(TRATrustLevel value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRATrustLevel' to 'List<TRAClaim>'.");
                
            }
            TRATrustLevel ITypeConverter<List<TRAClaim>>.ConvertTo_TRATrustLevel(List<TRAClaim> value)
            {
                return TypeConverter<TRATrustLevel>.ConvertFrom_List_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<List<TRAClaim>>.GetConversionActionTo_TRATrustLevel()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRATrustLevel> ITypeConverter<List<TRAClaim>>.Enumerate_TRATrustLevel(List<TRAClaim> value)
            {
                
                yield break;
            }
            List<TRAClaim> ITypeConverter<List<TRAClaim>>.ConvertFrom_List_List_TRAKeyValuePair(List<List<TRAKeyValuePair>> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<List<TRAKeyValuePair>>' to 'List<TRAClaim>'.");
                
            }
            List<List<TRAKeyValuePair>> ITypeConverter<List<TRAClaim>>.ConvertTo_List_List_TRAKeyValuePair(List<TRAClaim> value)
            {
                return TypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_List_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<List<TRAClaim>>.GetConversionActionTo_List_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<List<TRAKeyValuePair>>> ITypeConverter<List<TRAClaim>>.Enumerate_List_List_TRAKeyValuePair(List<TRAClaim> value)
            {
                
                yield break;
            }
            List<TRAKeyValuePair> ITypeConverter<List<TRAKeyValuePair>>.ConvertFrom_long(long value)
            {
                
                throw new InvalidCastException("Invalid cast from 'long' to 'List<TRAKeyValuePair>'.");
                
            }
            long ITypeConverter<List<TRAKeyValuePair>>.ConvertTo_long(List<TRAKeyValuePair> value)
            {
                return TypeConverter<long>.ConvertFrom_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<TRAKeyValuePair>>.GetConversionActionTo_long()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long> ITypeConverter<List<TRAKeyValuePair>>.Enumerate_long(List<TRAKeyValuePair> value)
            {
                
                yield break;
            }
            List<TRAKeyValuePair> ITypeConverter<List<TRAKeyValuePair>>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    List<TRAKeyValuePair> intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = ExternalParser.TryParse_List_TRAKeyValuePair(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        try
                        {
                            TRAKeyValuePair element = TypeConverter<TRAKeyValuePair>.ConvertFrom_string(value);
                            intermediate_result = new List<TRAKeyValuePair>();
                            intermediate_result.Add(element);
                        }
                        catch
                        {
                            throw new ArgumentException("Cannot parse \"" + value + "\" into either 'List<TRAKeyValuePair>' or 'TRAKeyValuePair'.");
                        }
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<List<TRAKeyValuePair>>.ConvertTo_string(List<TRAKeyValuePair> value)
            {
                return TypeConverter<string>.ConvertFrom_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<TRAKeyValuePair>>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<List<TRAKeyValuePair>>.Enumerate_string(List<TRAKeyValuePair> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<string>.ConvertFrom_TRAKeyValuePair(element);
                
                yield break;
            }
            List<TRAKeyValuePair> ITypeConverter<List<TRAKeyValuePair>>.ConvertFrom_List_string(List<string> value)
            {
                
                {
                    List<TRAKeyValuePair> intermediate_result = new List<TRAKeyValuePair>();
                    foreach (var element in value)
                    {
                        intermediate_result.Add(TypeConverter<TRAKeyValuePair>.ConvertFrom_string(element));
                    }
                    return intermediate_result;
                }
                
            }
            List<string> ITypeConverter<List<TRAKeyValuePair>>.ConvertTo_List_string(List<TRAKeyValuePair> value)
            {
                return TypeConverter<List<string>>.ConvertFrom_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<TRAKeyValuePair>>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_CONVERTLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<List<TRAKeyValuePair>>.Enumerate_List_string(List<TRAKeyValuePair> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<List<string>>.ConvertFrom_TRAKeyValuePair(element);
                
                yield break;
            }
            List<TRAKeyValuePair> ITypeConverter<List<TRAKeyValuePair>>.ConvertFrom_List_TRAClaim(List<TRAClaim> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<TRAClaim>' to 'List<TRAKeyValuePair>'.");
                
            }
            List<TRAClaim> ITypeConverter<List<TRAKeyValuePair>>.ConvertTo_List_TRAClaim(List<TRAKeyValuePair> value)
            {
                return TypeConverter<List<TRAClaim>>.ConvertFrom_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<TRAKeyValuePair>>.GetConversionActionTo_List_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAClaim>> ITypeConverter<List<TRAKeyValuePair>>.Enumerate_List_TRAClaim(List<TRAKeyValuePair> value)
            {
                
                yield break;
            }
            List<TRAKeyValuePair> ITypeConverter<List<TRAKeyValuePair>>.ConvertFrom_List_TRAKeyValuePair(List<TRAKeyValuePair> value)
            {
                
                return (List<TRAKeyValuePair>)value;
                
            }
            List<TRAKeyValuePair> ITypeConverter<List<TRAKeyValuePair>>.ConvertTo_List_TRAKeyValuePair(List<TRAKeyValuePair> value)
            {
                return TypeConverter<List<TRAKeyValuePair>>.ConvertFrom_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<TRAKeyValuePair>>.GetConversionActionTo_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAKeyValuePair>> ITypeConverter<List<TRAKeyValuePair>>.Enumerate_List_TRAKeyValuePair(List<TRAKeyValuePair> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<List<TRAKeyValuePair>>.ConvertFrom_TRAKeyValuePair(element);
                
                yield break;
            }
            List<TRAKeyValuePair> ITypeConverter<List<TRAKeyValuePair>>.ConvertFrom_TRAClaim(TRAClaim value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAClaim' to 'List<TRAKeyValuePair>'.");
                
            }
            TRAClaim ITypeConverter<List<TRAKeyValuePair>>.ConvertTo_TRAClaim(List<TRAKeyValuePair> value)
            {
                return TypeConverter<TRAClaim>.ConvertFrom_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<TRAKeyValuePair>>.GetConversionActionTo_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAClaim> ITypeConverter<List<TRAKeyValuePair>>.Enumerate_TRAClaim(List<TRAKeyValuePair> value)
            {
                
                yield break;
            }
            List<TRAKeyValuePair> ITypeConverter<List<TRAKeyValuePair>>.ConvertFrom_TRACredentialCore(TRACredentialCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialCore' to 'List<TRAKeyValuePair>'.");
                
            }
            TRACredentialCore ITypeConverter<List<TRAKeyValuePair>>.ConvertTo_TRACredentialCore(List<TRAKeyValuePair> value)
            {
                return TypeConverter<TRACredentialCore>.ConvertFrom_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<TRAKeyValuePair>>.GetConversionActionTo_TRACredentialCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialCore> ITypeConverter<List<TRAKeyValuePair>>.Enumerate_TRACredentialCore(List<TRAKeyValuePair> value)
            {
                
                yield break;
            }
            List<TRAKeyValuePair> ITypeConverter<List<TRAKeyValuePair>>.ConvertFrom_TRAEnvelope(TRAEnvelope value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAEnvelope' to 'List<TRAKeyValuePair>'.");
                
            }
            TRAEnvelope ITypeConverter<List<TRAKeyValuePair>>.ConvertTo_TRAEnvelope(List<TRAKeyValuePair> value)
            {
                return TypeConverter<TRAEnvelope>.ConvertFrom_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<TRAKeyValuePair>>.GetConversionActionTo_TRAEnvelope()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEnvelope> ITypeConverter<List<TRAKeyValuePair>>.Enumerate_TRAEnvelope(List<TRAKeyValuePair> value)
            {
                
                yield break;
            }
            List<TRAKeyValuePair> ITypeConverter<List<TRAKeyValuePair>>.ConvertFrom_TRAKeyValuePair(TRAKeyValuePair value)
            {
                
                {
                    List<TRAKeyValuePair> intermediate_result = new List<TRAKeyValuePair>();
                    intermediate_result.Add(TypeConverter<TRAKeyValuePair>.ConvertFrom_TRAKeyValuePair(value));
                    return intermediate_result;
                }
                
            }
            TRAKeyValuePair ITypeConverter<List<TRAKeyValuePair>>.ConvertTo_TRAKeyValuePair(List<TRAKeyValuePair> value)
            {
                return TypeConverter<TRAKeyValuePair>.ConvertFrom_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<TRAKeyValuePair>>.GetConversionActionTo_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAKeyValuePair> ITypeConverter<List<TRAKeyValuePair>>.Enumerate_TRAKeyValuePair(List<TRAKeyValuePair> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<TRAKeyValuePair>.ConvertFrom_TRAKeyValuePair(element);
                
                yield break;
            }
            List<TRAKeyValuePair> ITypeConverter<List<TRAKeyValuePair>>.ConvertFrom_TRACredentialType(TRACredentialType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialType' to 'List<TRAKeyValuePair>'.");
                
            }
            TRACredentialType ITypeConverter<List<TRAKeyValuePair>>.ConvertTo_TRACredentialType(List<TRAKeyValuePair> value)
            {
                return TypeConverter<TRACredentialType>.ConvertFrom_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<TRAKeyValuePair>>.GetConversionActionTo_TRACredentialType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialType> ITypeConverter<List<TRAKeyValuePair>>.Enumerate_TRACredentialType(List<TRAKeyValuePair> value)
            {
                
                yield break;
            }
            List<TRAKeyValuePair> ITypeConverter<List<TRAKeyValuePair>>.ConvertFrom_TRAEncryptionFlag(TRAEncryptionFlag value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAEncryptionFlag' to 'List<TRAKeyValuePair>'.");
                
            }
            TRAEncryptionFlag ITypeConverter<List<TRAKeyValuePair>>.ConvertTo_TRAEncryptionFlag(List<TRAKeyValuePair> value)
            {
                return TypeConverter<TRAEncryptionFlag>.ConvertFrom_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<TRAKeyValuePair>>.GetConversionActionTo_TRAEncryptionFlag()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEncryptionFlag> ITypeConverter<List<TRAKeyValuePair>>.Enumerate_TRAEncryptionFlag(List<TRAKeyValuePair> value)
            {
                
                yield break;
            }
            List<TRAKeyValuePair> ITypeConverter<List<TRAKeyValuePair>>.ConvertFrom_TRATrustLevel(TRATrustLevel value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRATrustLevel' to 'List<TRAKeyValuePair>'.");
                
            }
            TRATrustLevel ITypeConverter<List<TRAKeyValuePair>>.ConvertTo_TRATrustLevel(List<TRAKeyValuePair> value)
            {
                return TypeConverter<TRATrustLevel>.ConvertFrom_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<TRAKeyValuePair>>.GetConversionActionTo_TRATrustLevel()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRATrustLevel> ITypeConverter<List<TRAKeyValuePair>>.Enumerate_TRATrustLevel(List<TRAKeyValuePair> value)
            {
                
                yield break;
            }
            List<TRAKeyValuePair> ITypeConverter<List<TRAKeyValuePair>>.ConvertFrom_List_List_TRAKeyValuePair(List<List<TRAKeyValuePair>> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<List<TRAKeyValuePair>>' to 'List<TRAKeyValuePair>'.");
                
            }
            List<List<TRAKeyValuePair>> ITypeConverter<List<TRAKeyValuePair>>.ConvertTo_List_List_TRAKeyValuePair(List<TRAKeyValuePair> value)
            {
                return TypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<TRAKeyValuePair>>.GetConversionActionTo_List_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_CONVERTLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<List<TRAKeyValuePair>>> ITypeConverter<List<TRAKeyValuePair>>.Enumerate_List_List_TRAKeyValuePair(List<TRAKeyValuePair> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_TRAKeyValuePair(element);
                
                yield break;
            }
            TRAClaim ITypeConverter<TRAClaim>.ConvertFrom_long(long value)
            {
                
                throw new InvalidCastException("Invalid cast from 'long' to 'TRAClaim'.");
                
            }
            long ITypeConverter<TRAClaim>.ConvertTo_long(TRAClaim value)
            {
                return TypeConverter<long>.ConvertFrom_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<TRAClaim>.GetConversionActionTo_long()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long> ITypeConverter<TRAClaim>.Enumerate_long(TRAClaim value)
            {
                
                yield break;
            }
            TRAClaim ITypeConverter<TRAClaim>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    TRAClaim intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = TRAClaim.TryParse(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        Throw.cannot_parse(value, "TRAClaim");
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<TRAClaim>.ConvertTo_string(TRAClaim value)
            {
                return TypeConverter<string>.ConvertFrom_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<TRAClaim>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<TRAClaim>.Enumerate_string(TRAClaim value)
            {
                
                yield break;
            }
            TRAClaim ITypeConverter<TRAClaim>.ConvertFrom_List_string(List<string> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<string>' to 'TRAClaim'.");
                
            }
            List<string> ITypeConverter<TRAClaim>.ConvertTo_List_string(TRAClaim value)
            {
                return TypeConverter<List<string>>.ConvertFrom_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<TRAClaim>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_WRAPINLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<TRAClaim>.Enumerate_List_string(TRAClaim value)
            {
                
                yield break;
            }
            TRAClaim ITypeConverter<TRAClaim>.ConvertFrom_List_TRAClaim(List<TRAClaim> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<TRAClaim>' to 'TRAClaim'.");
                
            }
            List<TRAClaim> ITypeConverter<TRAClaim>.ConvertTo_List_TRAClaim(TRAClaim value)
            {
                return TypeConverter<List<TRAClaim>>.ConvertFrom_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<TRAClaim>.GetConversionActionTo_List_TRAClaim()
            {
                
                return TypeConversionAction.TC_WRAPINLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAClaim>> ITypeConverter<TRAClaim>.Enumerate_List_TRAClaim(TRAClaim value)
            {
                
                yield break;
            }
            TRAClaim ITypeConverter<TRAClaim>.ConvertFrom_List_TRAKeyValuePair(List<TRAKeyValuePair> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<TRAKeyValuePair>' to 'TRAClaim'.");
                
            }
            List<TRAKeyValuePair> ITypeConverter<TRAClaim>.ConvertTo_List_TRAKeyValuePair(TRAClaim value)
            {
                return TypeConverter<List<TRAKeyValuePair>>.ConvertFrom_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<TRAClaim>.GetConversionActionTo_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAKeyValuePair>> ITypeConverter<TRAClaim>.Enumerate_List_TRAKeyValuePair(TRAClaim value)
            {
                
                yield break;
            }
            TRAClaim ITypeConverter<TRAClaim>.ConvertFrom_TRAClaim(TRAClaim value)
            {
                
                return (TRAClaim)value;
                
            }
            TRAClaim ITypeConverter<TRAClaim>.ConvertTo_TRAClaim(TRAClaim value)
            {
                return TypeConverter<TRAClaim>.ConvertFrom_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<TRAClaim>.GetConversionActionTo_TRAClaim()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAClaim> ITypeConverter<TRAClaim>.Enumerate_TRAClaim(TRAClaim value)
            {
                
                yield break;
            }
            TRAClaim ITypeConverter<TRAClaim>.ConvertFrom_TRACredentialCore(TRACredentialCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialCore' to 'TRAClaim'.");
                
            }
            TRACredentialCore ITypeConverter<TRAClaim>.ConvertTo_TRACredentialCore(TRAClaim value)
            {
                return TypeConverter<TRACredentialCore>.ConvertFrom_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<TRAClaim>.GetConversionActionTo_TRACredentialCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialCore> ITypeConverter<TRAClaim>.Enumerate_TRACredentialCore(TRAClaim value)
            {
                
                yield break;
            }
            TRAClaim ITypeConverter<TRAClaim>.ConvertFrom_TRAEnvelope(TRAEnvelope value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAEnvelope' to 'TRAClaim'.");
                
            }
            TRAEnvelope ITypeConverter<TRAClaim>.ConvertTo_TRAEnvelope(TRAClaim value)
            {
                return TypeConverter<TRAEnvelope>.ConvertFrom_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<TRAClaim>.GetConversionActionTo_TRAEnvelope()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEnvelope> ITypeConverter<TRAClaim>.Enumerate_TRAEnvelope(TRAClaim value)
            {
                
                yield break;
            }
            TRAClaim ITypeConverter<TRAClaim>.ConvertFrom_TRAKeyValuePair(TRAKeyValuePair value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAKeyValuePair' to 'TRAClaim'.");
                
            }
            TRAKeyValuePair ITypeConverter<TRAClaim>.ConvertTo_TRAKeyValuePair(TRAClaim value)
            {
                return TypeConverter<TRAKeyValuePair>.ConvertFrom_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<TRAClaim>.GetConversionActionTo_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAKeyValuePair> ITypeConverter<TRAClaim>.Enumerate_TRAKeyValuePair(TRAClaim value)
            {
                
                yield break;
            }
            TRAClaim ITypeConverter<TRAClaim>.ConvertFrom_TRACredentialType(TRACredentialType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialType' to 'TRAClaim'.");
                
            }
            TRACredentialType ITypeConverter<TRAClaim>.ConvertTo_TRACredentialType(TRAClaim value)
            {
                return TypeConverter<TRACredentialType>.ConvertFrom_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<TRAClaim>.GetConversionActionTo_TRACredentialType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialType> ITypeConverter<TRAClaim>.Enumerate_TRACredentialType(TRAClaim value)
            {
                
                yield break;
            }
            TRAClaim ITypeConverter<TRAClaim>.ConvertFrom_TRAEncryptionFlag(TRAEncryptionFlag value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAEncryptionFlag' to 'TRAClaim'.");
                
            }
            TRAEncryptionFlag ITypeConverter<TRAClaim>.ConvertTo_TRAEncryptionFlag(TRAClaim value)
            {
                return TypeConverter<TRAEncryptionFlag>.ConvertFrom_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<TRAClaim>.GetConversionActionTo_TRAEncryptionFlag()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEncryptionFlag> ITypeConverter<TRAClaim>.Enumerate_TRAEncryptionFlag(TRAClaim value)
            {
                
                yield break;
            }
            TRAClaim ITypeConverter<TRAClaim>.ConvertFrom_TRATrustLevel(TRATrustLevel value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRATrustLevel' to 'TRAClaim'.");
                
            }
            TRATrustLevel ITypeConverter<TRAClaim>.ConvertTo_TRATrustLevel(TRAClaim value)
            {
                return TypeConverter<TRATrustLevel>.ConvertFrom_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<TRAClaim>.GetConversionActionTo_TRATrustLevel()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRATrustLevel> ITypeConverter<TRAClaim>.Enumerate_TRATrustLevel(TRAClaim value)
            {
                
                yield break;
            }
            TRAClaim ITypeConverter<TRAClaim>.ConvertFrom_List_List_TRAKeyValuePair(List<List<TRAKeyValuePair>> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<List<TRAKeyValuePair>>' to 'TRAClaim'.");
                
            }
            List<List<TRAKeyValuePair>> ITypeConverter<TRAClaim>.ConvertTo_List_List_TRAKeyValuePair(TRAClaim value)
            {
                return TypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<TRAClaim>.GetConversionActionTo_List_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<List<TRAKeyValuePair>>> ITypeConverter<TRAClaim>.Enumerate_List_List_TRAKeyValuePair(TRAClaim value)
            {
                
                yield break;
            }
            TRACredentialCore ITypeConverter<TRACredentialCore>.ConvertFrom_long(long value)
            {
                
                throw new InvalidCastException("Invalid cast from 'long' to 'TRACredentialCore'.");
                
            }
            long ITypeConverter<TRACredentialCore>.ConvertTo_long(TRACredentialCore value)
            {
                return TypeConverter<long>.ConvertFrom_TRACredentialCore(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialCore>.GetConversionActionTo_long()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long> ITypeConverter<TRACredentialCore>.Enumerate_long(TRACredentialCore value)
            {
                
                yield break;
            }
            TRACredentialCore ITypeConverter<TRACredentialCore>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    TRACredentialCore intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = TRACredentialCore.TryParse(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        Throw.cannot_parse(value, "TRACredentialCore");
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<TRACredentialCore>.ConvertTo_string(TRACredentialCore value)
            {
                return TypeConverter<string>.ConvertFrom_TRACredentialCore(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialCore>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<TRACredentialCore>.Enumerate_string(TRACredentialCore value)
            {
                
                yield break;
            }
            TRACredentialCore ITypeConverter<TRACredentialCore>.ConvertFrom_List_string(List<string> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<string>' to 'TRACredentialCore'.");
                
            }
            List<string> ITypeConverter<TRACredentialCore>.ConvertTo_List_string(TRACredentialCore value)
            {
                return TypeConverter<List<string>>.ConvertFrom_TRACredentialCore(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialCore>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_WRAPINLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<TRACredentialCore>.Enumerate_List_string(TRACredentialCore value)
            {
                
                yield break;
            }
            TRACredentialCore ITypeConverter<TRACredentialCore>.ConvertFrom_List_TRAClaim(List<TRAClaim> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<TRAClaim>' to 'TRACredentialCore'.");
                
            }
            List<TRAClaim> ITypeConverter<TRACredentialCore>.ConvertTo_List_TRAClaim(TRACredentialCore value)
            {
                return TypeConverter<List<TRAClaim>>.ConvertFrom_TRACredentialCore(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialCore>.GetConversionActionTo_List_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAClaim>> ITypeConverter<TRACredentialCore>.Enumerate_List_TRAClaim(TRACredentialCore value)
            {
                
                yield break;
            }
            TRACredentialCore ITypeConverter<TRACredentialCore>.ConvertFrom_List_TRAKeyValuePair(List<TRAKeyValuePair> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<TRAKeyValuePair>' to 'TRACredentialCore'.");
                
            }
            List<TRAKeyValuePair> ITypeConverter<TRACredentialCore>.ConvertTo_List_TRAKeyValuePair(TRACredentialCore value)
            {
                return TypeConverter<List<TRAKeyValuePair>>.ConvertFrom_TRACredentialCore(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialCore>.GetConversionActionTo_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAKeyValuePair>> ITypeConverter<TRACredentialCore>.Enumerate_List_TRAKeyValuePair(TRACredentialCore value)
            {
                
                yield break;
            }
            TRACredentialCore ITypeConverter<TRACredentialCore>.ConvertFrom_TRAClaim(TRAClaim value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAClaim' to 'TRACredentialCore'.");
                
            }
            TRAClaim ITypeConverter<TRACredentialCore>.ConvertTo_TRAClaim(TRACredentialCore value)
            {
                return TypeConverter<TRAClaim>.ConvertFrom_TRACredentialCore(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialCore>.GetConversionActionTo_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAClaim> ITypeConverter<TRACredentialCore>.Enumerate_TRAClaim(TRACredentialCore value)
            {
                
                yield break;
            }
            TRACredentialCore ITypeConverter<TRACredentialCore>.ConvertFrom_TRACredentialCore(TRACredentialCore value)
            {
                
                return (TRACredentialCore)value;
                
            }
            TRACredentialCore ITypeConverter<TRACredentialCore>.ConvertTo_TRACredentialCore(TRACredentialCore value)
            {
                return TypeConverter<TRACredentialCore>.ConvertFrom_TRACredentialCore(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialCore>.GetConversionActionTo_TRACredentialCore()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialCore> ITypeConverter<TRACredentialCore>.Enumerate_TRACredentialCore(TRACredentialCore value)
            {
                
                yield break;
            }
            TRACredentialCore ITypeConverter<TRACredentialCore>.ConvertFrom_TRAEnvelope(TRAEnvelope value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAEnvelope' to 'TRACredentialCore'.");
                
            }
            TRAEnvelope ITypeConverter<TRACredentialCore>.ConvertTo_TRAEnvelope(TRACredentialCore value)
            {
                return TypeConverter<TRAEnvelope>.ConvertFrom_TRACredentialCore(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialCore>.GetConversionActionTo_TRAEnvelope()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEnvelope> ITypeConverter<TRACredentialCore>.Enumerate_TRAEnvelope(TRACredentialCore value)
            {
                
                yield break;
            }
            TRACredentialCore ITypeConverter<TRACredentialCore>.ConvertFrom_TRAKeyValuePair(TRAKeyValuePair value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAKeyValuePair' to 'TRACredentialCore'.");
                
            }
            TRAKeyValuePair ITypeConverter<TRACredentialCore>.ConvertTo_TRAKeyValuePair(TRACredentialCore value)
            {
                return TypeConverter<TRAKeyValuePair>.ConvertFrom_TRACredentialCore(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialCore>.GetConversionActionTo_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAKeyValuePair> ITypeConverter<TRACredentialCore>.Enumerate_TRAKeyValuePair(TRACredentialCore value)
            {
                
                yield break;
            }
            TRACredentialCore ITypeConverter<TRACredentialCore>.ConvertFrom_TRACredentialType(TRACredentialType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialType' to 'TRACredentialCore'.");
                
            }
            TRACredentialType ITypeConverter<TRACredentialCore>.ConvertTo_TRACredentialType(TRACredentialCore value)
            {
                return TypeConverter<TRACredentialType>.ConvertFrom_TRACredentialCore(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialCore>.GetConversionActionTo_TRACredentialType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialType> ITypeConverter<TRACredentialCore>.Enumerate_TRACredentialType(TRACredentialCore value)
            {
                
                yield break;
            }
            TRACredentialCore ITypeConverter<TRACredentialCore>.ConvertFrom_TRAEncryptionFlag(TRAEncryptionFlag value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAEncryptionFlag' to 'TRACredentialCore'.");
                
            }
            TRAEncryptionFlag ITypeConverter<TRACredentialCore>.ConvertTo_TRAEncryptionFlag(TRACredentialCore value)
            {
                return TypeConverter<TRAEncryptionFlag>.ConvertFrom_TRACredentialCore(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialCore>.GetConversionActionTo_TRAEncryptionFlag()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEncryptionFlag> ITypeConverter<TRACredentialCore>.Enumerate_TRAEncryptionFlag(TRACredentialCore value)
            {
                
                yield break;
            }
            TRACredentialCore ITypeConverter<TRACredentialCore>.ConvertFrom_TRATrustLevel(TRATrustLevel value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRATrustLevel' to 'TRACredentialCore'.");
                
            }
            TRATrustLevel ITypeConverter<TRACredentialCore>.ConvertTo_TRATrustLevel(TRACredentialCore value)
            {
                return TypeConverter<TRATrustLevel>.ConvertFrom_TRACredentialCore(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialCore>.GetConversionActionTo_TRATrustLevel()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRATrustLevel> ITypeConverter<TRACredentialCore>.Enumerate_TRATrustLevel(TRACredentialCore value)
            {
                
                yield break;
            }
            TRACredentialCore ITypeConverter<TRACredentialCore>.ConvertFrom_List_List_TRAKeyValuePair(List<List<TRAKeyValuePair>> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<List<TRAKeyValuePair>>' to 'TRACredentialCore'.");
                
            }
            List<List<TRAKeyValuePair>> ITypeConverter<TRACredentialCore>.ConvertTo_List_List_TRAKeyValuePair(TRACredentialCore value)
            {
                return TypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_TRACredentialCore(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialCore>.GetConversionActionTo_List_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<List<TRAKeyValuePair>>> ITypeConverter<TRACredentialCore>.Enumerate_List_List_TRAKeyValuePair(TRACredentialCore value)
            {
                
                yield break;
            }
            TRAEnvelope ITypeConverter<TRAEnvelope>.ConvertFrom_long(long value)
            {
                
                throw new InvalidCastException("Invalid cast from 'long' to 'TRAEnvelope'.");
                
            }
            long ITypeConverter<TRAEnvelope>.ConvertTo_long(TRAEnvelope value)
            {
                return TypeConverter<long>.ConvertFrom_TRAEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRAEnvelope>.GetConversionActionTo_long()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long> ITypeConverter<TRAEnvelope>.Enumerate_long(TRAEnvelope value)
            {
                
                yield break;
            }
            TRAEnvelope ITypeConverter<TRAEnvelope>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    TRAEnvelope intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = TRAEnvelope.TryParse(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        Throw.cannot_parse(value, "TRAEnvelope");
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<TRAEnvelope>.ConvertTo_string(TRAEnvelope value)
            {
                return TypeConverter<string>.ConvertFrom_TRAEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRAEnvelope>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<TRAEnvelope>.Enumerate_string(TRAEnvelope value)
            {
                
                yield break;
            }
            TRAEnvelope ITypeConverter<TRAEnvelope>.ConvertFrom_List_string(List<string> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<string>' to 'TRAEnvelope'.");
                
            }
            List<string> ITypeConverter<TRAEnvelope>.ConvertTo_List_string(TRAEnvelope value)
            {
                return TypeConverter<List<string>>.ConvertFrom_TRAEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRAEnvelope>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_WRAPINLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<TRAEnvelope>.Enumerate_List_string(TRAEnvelope value)
            {
                
                yield break;
            }
            TRAEnvelope ITypeConverter<TRAEnvelope>.ConvertFrom_List_TRAClaim(List<TRAClaim> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<TRAClaim>' to 'TRAEnvelope'.");
                
            }
            List<TRAClaim> ITypeConverter<TRAEnvelope>.ConvertTo_List_TRAClaim(TRAEnvelope value)
            {
                return TypeConverter<List<TRAClaim>>.ConvertFrom_TRAEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRAEnvelope>.GetConversionActionTo_List_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAClaim>> ITypeConverter<TRAEnvelope>.Enumerate_List_TRAClaim(TRAEnvelope value)
            {
                
                yield break;
            }
            TRAEnvelope ITypeConverter<TRAEnvelope>.ConvertFrom_List_TRAKeyValuePair(List<TRAKeyValuePair> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<TRAKeyValuePair>' to 'TRAEnvelope'.");
                
            }
            List<TRAKeyValuePair> ITypeConverter<TRAEnvelope>.ConvertTo_List_TRAKeyValuePair(TRAEnvelope value)
            {
                return TypeConverter<List<TRAKeyValuePair>>.ConvertFrom_TRAEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRAEnvelope>.GetConversionActionTo_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAKeyValuePair>> ITypeConverter<TRAEnvelope>.Enumerate_List_TRAKeyValuePair(TRAEnvelope value)
            {
                
                yield break;
            }
            TRAEnvelope ITypeConverter<TRAEnvelope>.ConvertFrom_TRAClaim(TRAClaim value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAClaim' to 'TRAEnvelope'.");
                
            }
            TRAClaim ITypeConverter<TRAEnvelope>.ConvertTo_TRAClaim(TRAEnvelope value)
            {
                return TypeConverter<TRAClaim>.ConvertFrom_TRAEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRAEnvelope>.GetConversionActionTo_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAClaim> ITypeConverter<TRAEnvelope>.Enumerate_TRAClaim(TRAEnvelope value)
            {
                
                yield break;
            }
            TRAEnvelope ITypeConverter<TRAEnvelope>.ConvertFrom_TRACredentialCore(TRACredentialCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialCore' to 'TRAEnvelope'.");
                
            }
            TRACredentialCore ITypeConverter<TRAEnvelope>.ConvertTo_TRACredentialCore(TRAEnvelope value)
            {
                return TypeConverter<TRACredentialCore>.ConvertFrom_TRAEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRAEnvelope>.GetConversionActionTo_TRACredentialCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialCore> ITypeConverter<TRAEnvelope>.Enumerate_TRACredentialCore(TRAEnvelope value)
            {
                
                yield break;
            }
            TRAEnvelope ITypeConverter<TRAEnvelope>.ConvertFrom_TRAEnvelope(TRAEnvelope value)
            {
                
                return (TRAEnvelope)value;
                
            }
            TRAEnvelope ITypeConverter<TRAEnvelope>.ConvertTo_TRAEnvelope(TRAEnvelope value)
            {
                return TypeConverter<TRAEnvelope>.ConvertFrom_TRAEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRAEnvelope>.GetConversionActionTo_TRAEnvelope()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEnvelope> ITypeConverter<TRAEnvelope>.Enumerate_TRAEnvelope(TRAEnvelope value)
            {
                
                yield break;
            }
            TRAEnvelope ITypeConverter<TRAEnvelope>.ConvertFrom_TRAKeyValuePair(TRAKeyValuePair value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAKeyValuePair' to 'TRAEnvelope'.");
                
            }
            TRAKeyValuePair ITypeConverter<TRAEnvelope>.ConvertTo_TRAKeyValuePair(TRAEnvelope value)
            {
                return TypeConverter<TRAKeyValuePair>.ConvertFrom_TRAEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRAEnvelope>.GetConversionActionTo_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAKeyValuePair> ITypeConverter<TRAEnvelope>.Enumerate_TRAKeyValuePair(TRAEnvelope value)
            {
                
                yield break;
            }
            TRAEnvelope ITypeConverter<TRAEnvelope>.ConvertFrom_TRACredentialType(TRACredentialType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialType' to 'TRAEnvelope'.");
                
            }
            TRACredentialType ITypeConverter<TRAEnvelope>.ConvertTo_TRACredentialType(TRAEnvelope value)
            {
                return TypeConverter<TRACredentialType>.ConvertFrom_TRAEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRAEnvelope>.GetConversionActionTo_TRACredentialType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialType> ITypeConverter<TRAEnvelope>.Enumerate_TRACredentialType(TRAEnvelope value)
            {
                
                yield break;
            }
            TRAEnvelope ITypeConverter<TRAEnvelope>.ConvertFrom_TRAEncryptionFlag(TRAEncryptionFlag value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAEncryptionFlag' to 'TRAEnvelope'.");
                
            }
            TRAEncryptionFlag ITypeConverter<TRAEnvelope>.ConvertTo_TRAEncryptionFlag(TRAEnvelope value)
            {
                return TypeConverter<TRAEncryptionFlag>.ConvertFrom_TRAEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRAEnvelope>.GetConversionActionTo_TRAEncryptionFlag()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEncryptionFlag> ITypeConverter<TRAEnvelope>.Enumerate_TRAEncryptionFlag(TRAEnvelope value)
            {
                
                yield break;
            }
            TRAEnvelope ITypeConverter<TRAEnvelope>.ConvertFrom_TRATrustLevel(TRATrustLevel value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRATrustLevel' to 'TRAEnvelope'.");
                
            }
            TRATrustLevel ITypeConverter<TRAEnvelope>.ConvertTo_TRATrustLevel(TRAEnvelope value)
            {
                return TypeConverter<TRATrustLevel>.ConvertFrom_TRAEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRAEnvelope>.GetConversionActionTo_TRATrustLevel()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRATrustLevel> ITypeConverter<TRAEnvelope>.Enumerate_TRATrustLevel(TRAEnvelope value)
            {
                
                yield break;
            }
            TRAEnvelope ITypeConverter<TRAEnvelope>.ConvertFrom_List_List_TRAKeyValuePair(List<List<TRAKeyValuePair>> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<List<TRAKeyValuePair>>' to 'TRAEnvelope'.");
                
            }
            List<List<TRAKeyValuePair>> ITypeConverter<TRAEnvelope>.ConvertTo_List_List_TRAKeyValuePair(TRAEnvelope value)
            {
                return TypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_TRAEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRAEnvelope>.GetConversionActionTo_List_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<List<TRAKeyValuePair>>> ITypeConverter<TRAEnvelope>.Enumerate_List_List_TRAKeyValuePair(TRAEnvelope value)
            {
                
                yield break;
            }
            TRAKeyValuePair ITypeConverter<TRAKeyValuePair>.ConvertFrom_long(long value)
            {
                
                throw new InvalidCastException("Invalid cast from 'long' to 'TRAKeyValuePair'.");
                
            }
            long ITypeConverter<TRAKeyValuePair>.ConvertTo_long(TRAKeyValuePair value)
            {
                return TypeConverter<long>.ConvertFrom_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<TRAKeyValuePair>.GetConversionActionTo_long()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long> ITypeConverter<TRAKeyValuePair>.Enumerate_long(TRAKeyValuePair value)
            {
                
                yield break;
            }
            TRAKeyValuePair ITypeConverter<TRAKeyValuePair>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    TRAKeyValuePair intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = TRAKeyValuePair.TryParse(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        Throw.cannot_parse(value, "TRAKeyValuePair");
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<TRAKeyValuePair>.ConvertTo_string(TRAKeyValuePair value)
            {
                return TypeConverter<string>.ConvertFrom_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<TRAKeyValuePair>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<TRAKeyValuePair>.Enumerate_string(TRAKeyValuePair value)
            {
                
                yield break;
            }
            TRAKeyValuePair ITypeConverter<TRAKeyValuePair>.ConvertFrom_List_string(List<string> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<string>' to 'TRAKeyValuePair'.");
                
            }
            List<string> ITypeConverter<TRAKeyValuePair>.ConvertTo_List_string(TRAKeyValuePair value)
            {
                return TypeConverter<List<string>>.ConvertFrom_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<TRAKeyValuePair>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_WRAPINLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<TRAKeyValuePair>.Enumerate_List_string(TRAKeyValuePair value)
            {
                
                yield break;
            }
            TRAKeyValuePair ITypeConverter<TRAKeyValuePair>.ConvertFrom_List_TRAClaim(List<TRAClaim> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<TRAClaim>' to 'TRAKeyValuePair'.");
                
            }
            List<TRAClaim> ITypeConverter<TRAKeyValuePair>.ConvertTo_List_TRAClaim(TRAKeyValuePair value)
            {
                return TypeConverter<List<TRAClaim>>.ConvertFrom_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<TRAKeyValuePair>.GetConversionActionTo_List_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAClaim>> ITypeConverter<TRAKeyValuePair>.Enumerate_List_TRAClaim(TRAKeyValuePair value)
            {
                
                yield break;
            }
            TRAKeyValuePair ITypeConverter<TRAKeyValuePair>.ConvertFrom_List_TRAKeyValuePair(List<TRAKeyValuePair> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<TRAKeyValuePair>' to 'TRAKeyValuePair'.");
                
            }
            List<TRAKeyValuePair> ITypeConverter<TRAKeyValuePair>.ConvertTo_List_TRAKeyValuePair(TRAKeyValuePair value)
            {
                return TypeConverter<List<TRAKeyValuePair>>.ConvertFrom_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<TRAKeyValuePair>.GetConversionActionTo_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_WRAPINLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAKeyValuePair>> ITypeConverter<TRAKeyValuePair>.Enumerate_List_TRAKeyValuePair(TRAKeyValuePair value)
            {
                
                yield break;
            }
            TRAKeyValuePair ITypeConverter<TRAKeyValuePair>.ConvertFrom_TRAClaim(TRAClaim value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAClaim' to 'TRAKeyValuePair'.");
                
            }
            TRAClaim ITypeConverter<TRAKeyValuePair>.ConvertTo_TRAClaim(TRAKeyValuePair value)
            {
                return TypeConverter<TRAClaim>.ConvertFrom_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<TRAKeyValuePair>.GetConversionActionTo_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAClaim> ITypeConverter<TRAKeyValuePair>.Enumerate_TRAClaim(TRAKeyValuePair value)
            {
                
                yield break;
            }
            TRAKeyValuePair ITypeConverter<TRAKeyValuePair>.ConvertFrom_TRACredentialCore(TRACredentialCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialCore' to 'TRAKeyValuePair'.");
                
            }
            TRACredentialCore ITypeConverter<TRAKeyValuePair>.ConvertTo_TRACredentialCore(TRAKeyValuePair value)
            {
                return TypeConverter<TRACredentialCore>.ConvertFrom_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<TRAKeyValuePair>.GetConversionActionTo_TRACredentialCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialCore> ITypeConverter<TRAKeyValuePair>.Enumerate_TRACredentialCore(TRAKeyValuePair value)
            {
                
                yield break;
            }
            TRAKeyValuePair ITypeConverter<TRAKeyValuePair>.ConvertFrom_TRAEnvelope(TRAEnvelope value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAEnvelope' to 'TRAKeyValuePair'.");
                
            }
            TRAEnvelope ITypeConverter<TRAKeyValuePair>.ConvertTo_TRAEnvelope(TRAKeyValuePair value)
            {
                return TypeConverter<TRAEnvelope>.ConvertFrom_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<TRAKeyValuePair>.GetConversionActionTo_TRAEnvelope()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEnvelope> ITypeConverter<TRAKeyValuePair>.Enumerate_TRAEnvelope(TRAKeyValuePair value)
            {
                
                yield break;
            }
            TRAKeyValuePair ITypeConverter<TRAKeyValuePair>.ConvertFrom_TRAKeyValuePair(TRAKeyValuePair value)
            {
                
                return (TRAKeyValuePair)value;
                
            }
            TRAKeyValuePair ITypeConverter<TRAKeyValuePair>.ConvertTo_TRAKeyValuePair(TRAKeyValuePair value)
            {
                return TypeConverter<TRAKeyValuePair>.ConvertFrom_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<TRAKeyValuePair>.GetConversionActionTo_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAKeyValuePair> ITypeConverter<TRAKeyValuePair>.Enumerate_TRAKeyValuePair(TRAKeyValuePair value)
            {
                
                yield break;
            }
            TRAKeyValuePair ITypeConverter<TRAKeyValuePair>.ConvertFrom_TRACredentialType(TRACredentialType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialType' to 'TRAKeyValuePair'.");
                
            }
            TRACredentialType ITypeConverter<TRAKeyValuePair>.ConvertTo_TRACredentialType(TRAKeyValuePair value)
            {
                return TypeConverter<TRACredentialType>.ConvertFrom_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<TRAKeyValuePair>.GetConversionActionTo_TRACredentialType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialType> ITypeConverter<TRAKeyValuePair>.Enumerate_TRACredentialType(TRAKeyValuePair value)
            {
                
                yield break;
            }
            TRAKeyValuePair ITypeConverter<TRAKeyValuePair>.ConvertFrom_TRAEncryptionFlag(TRAEncryptionFlag value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAEncryptionFlag' to 'TRAKeyValuePair'.");
                
            }
            TRAEncryptionFlag ITypeConverter<TRAKeyValuePair>.ConvertTo_TRAEncryptionFlag(TRAKeyValuePair value)
            {
                return TypeConverter<TRAEncryptionFlag>.ConvertFrom_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<TRAKeyValuePair>.GetConversionActionTo_TRAEncryptionFlag()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEncryptionFlag> ITypeConverter<TRAKeyValuePair>.Enumerate_TRAEncryptionFlag(TRAKeyValuePair value)
            {
                
                yield break;
            }
            TRAKeyValuePair ITypeConverter<TRAKeyValuePair>.ConvertFrom_TRATrustLevel(TRATrustLevel value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRATrustLevel' to 'TRAKeyValuePair'.");
                
            }
            TRATrustLevel ITypeConverter<TRAKeyValuePair>.ConvertTo_TRATrustLevel(TRAKeyValuePair value)
            {
                return TypeConverter<TRATrustLevel>.ConvertFrom_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<TRAKeyValuePair>.GetConversionActionTo_TRATrustLevel()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRATrustLevel> ITypeConverter<TRAKeyValuePair>.Enumerate_TRATrustLevel(TRAKeyValuePair value)
            {
                
                yield break;
            }
            TRAKeyValuePair ITypeConverter<TRAKeyValuePair>.ConvertFrom_List_List_TRAKeyValuePair(List<List<TRAKeyValuePair>> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<List<TRAKeyValuePair>>' to 'TRAKeyValuePair'.");
                
            }
            List<List<TRAKeyValuePair>> ITypeConverter<TRAKeyValuePair>.ConvertTo_List_List_TRAKeyValuePair(TRAKeyValuePair value)
            {
                return TypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<TRAKeyValuePair>.GetConversionActionTo_List_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_WRAPINLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<List<TRAKeyValuePair>>> ITypeConverter<TRAKeyValuePair>.Enumerate_List_List_TRAKeyValuePair(TRAKeyValuePair value)
            {
                
                yield break;
            }
            TRACredentialType ITypeConverter<TRACredentialType>.ConvertFrom_long(long value)
            {
                
                throw new InvalidCastException("Invalid cast from 'long' to 'TRACredentialType'.");
                
            }
            long ITypeConverter<TRACredentialType>.ConvertTo_long(TRACredentialType value)
            {
                return TypeConverter<long>.ConvertFrom_TRACredentialType(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialType>.GetConversionActionTo_long()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long> ITypeConverter<TRACredentialType>.Enumerate_long(TRACredentialType value)
            {
                
                yield break;
            }
            TRACredentialType ITypeConverter<TRACredentialType>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    TRACredentialType intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = TRACredentialType.TryParse(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        Throw.cannot_parse(value, "TRACredentialType");
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<TRACredentialType>.ConvertTo_string(TRACredentialType value)
            {
                return TypeConverter<string>.ConvertFrom_TRACredentialType(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialType>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<TRACredentialType>.Enumerate_string(TRACredentialType value)
            {
                
                yield break;
            }
            TRACredentialType ITypeConverter<TRACredentialType>.ConvertFrom_List_string(List<string> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<string>' to 'TRACredentialType'.");
                
            }
            List<string> ITypeConverter<TRACredentialType>.ConvertTo_List_string(TRACredentialType value)
            {
                return TypeConverter<List<string>>.ConvertFrom_TRACredentialType(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialType>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_WRAPINLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<TRACredentialType>.Enumerate_List_string(TRACredentialType value)
            {
                
                yield break;
            }
            TRACredentialType ITypeConverter<TRACredentialType>.ConvertFrom_List_TRAClaim(List<TRAClaim> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<TRAClaim>' to 'TRACredentialType'.");
                
            }
            List<TRAClaim> ITypeConverter<TRACredentialType>.ConvertTo_List_TRAClaim(TRACredentialType value)
            {
                return TypeConverter<List<TRAClaim>>.ConvertFrom_TRACredentialType(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialType>.GetConversionActionTo_List_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAClaim>> ITypeConverter<TRACredentialType>.Enumerate_List_TRAClaim(TRACredentialType value)
            {
                
                yield break;
            }
            TRACredentialType ITypeConverter<TRACredentialType>.ConvertFrom_List_TRAKeyValuePair(List<TRAKeyValuePair> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<TRAKeyValuePair>' to 'TRACredentialType'.");
                
            }
            List<TRAKeyValuePair> ITypeConverter<TRACredentialType>.ConvertTo_List_TRAKeyValuePair(TRACredentialType value)
            {
                return TypeConverter<List<TRAKeyValuePair>>.ConvertFrom_TRACredentialType(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialType>.GetConversionActionTo_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAKeyValuePair>> ITypeConverter<TRACredentialType>.Enumerate_List_TRAKeyValuePair(TRACredentialType value)
            {
                
                yield break;
            }
            TRACredentialType ITypeConverter<TRACredentialType>.ConvertFrom_TRAClaim(TRAClaim value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAClaim' to 'TRACredentialType'.");
                
            }
            TRAClaim ITypeConverter<TRACredentialType>.ConvertTo_TRAClaim(TRACredentialType value)
            {
                return TypeConverter<TRAClaim>.ConvertFrom_TRACredentialType(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialType>.GetConversionActionTo_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAClaim> ITypeConverter<TRACredentialType>.Enumerate_TRAClaim(TRACredentialType value)
            {
                
                yield break;
            }
            TRACredentialType ITypeConverter<TRACredentialType>.ConvertFrom_TRACredentialCore(TRACredentialCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialCore' to 'TRACredentialType'.");
                
            }
            TRACredentialCore ITypeConverter<TRACredentialType>.ConvertTo_TRACredentialCore(TRACredentialType value)
            {
                return TypeConverter<TRACredentialCore>.ConvertFrom_TRACredentialType(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialType>.GetConversionActionTo_TRACredentialCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialCore> ITypeConverter<TRACredentialType>.Enumerate_TRACredentialCore(TRACredentialType value)
            {
                
                yield break;
            }
            TRACredentialType ITypeConverter<TRACredentialType>.ConvertFrom_TRAEnvelope(TRAEnvelope value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAEnvelope' to 'TRACredentialType'.");
                
            }
            TRAEnvelope ITypeConverter<TRACredentialType>.ConvertTo_TRAEnvelope(TRACredentialType value)
            {
                return TypeConverter<TRAEnvelope>.ConvertFrom_TRACredentialType(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialType>.GetConversionActionTo_TRAEnvelope()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEnvelope> ITypeConverter<TRACredentialType>.Enumerate_TRAEnvelope(TRACredentialType value)
            {
                
                yield break;
            }
            TRACredentialType ITypeConverter<TRACredentialType>.ConvertFrom_TRAKeyValuePair(TRAKeyValuePair value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAKeyValuePair' to 'TRACredentialType'.");
                
            }
            TRAKeyValuePair ITypeConverter<TRACredentialType>.ConvertTo_TRAKeyValuePair(TRACredentialType value)
            {
                return TypeConverter<TRAKeyValuePair>.ConvertFrom_TRACredentialType(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialType>.GetConversionActionTo_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAKeyValuePair> ITypeConverter<TRACredentialType>.Enumerate_TRAKeyValuePair(TRACredentialType value)
            {
                
                yield break;
            }
            TRACredentialType ITypeConverter<TRACredentialType>.ConvertFrom_TRACredentialType(TRACredentialType value)
            {
                
                return (TRACredentialType)value;
                
            }
            TRACredentialType ITypeConverter<TRACredentialType>.ConvertTo_TRACredentialType(TRACredentialType value)
            {
                return TypeConverter<TRACredentialType>.ConvertFrom_TRACredentialType(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialType>.GetConversionActionTo_TRACredentialType()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialType> ITypeConverter<TRACredentialType>.Enumerate_TRACredentialType(TRACredentialType value)
            {
                
                yield break;
            }
            TRACredentialType ITypeConverter<TRACredentialType>.ConvertFrom_TRAEncryptionFlag(TRAEncryptionFlag value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAEncryptionFlag' to 'TRACredentialType'.");
                
            }
            TRAEncryptionFlag ITypeConverter<TRACredentialType>.ConvertTo_TRAEncryptionFlag(TRACredentialType value)
            {
                return TypeConverter<TRAEncryptionFlag>.ConvertFrom_TRACredentialType(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialType>.GetConversionActionTo_TRAEncryptionFlag()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEncryptionFlag> ITypeConverter<TRACredentialType>.Enumerate_TRAEncryptionFlag(TRACredentialType value)
            {
                
                yield break;
            }
            TRACredentialType ITypeConverter<TRACredentialType>.ConvertFrom_TRATrustLevel(TRATrustLevel value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRATrustLevel' to 'TRACredentialType'.");
                
            }
            TRATrustLevel ITypeConverter<TRACredentialType>.ConvertTo_TRATrustLevel(TRACredentialType value)
            {
                return TypeConverter<TRATrustLevel>.ConvertFrom_TRACredentialType(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialType>.GetConversionActionTo_TRATrustLevel()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRATrustLevel> ITypeConverter<TRACredentialType>.Enumerate_TRATrustLevel(TRACredentialType value)
            {
                
                yield break;
            }
            TRACredentialType ITypeConverter<TRACredentialType>.ConvertFrom_List_List_TRAKeyValuePair(List<List<TRAKeyValuePair>> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<List<TRAKeyValuePair>>' to 'TRACredentialType'.");
                
            }
            List<List<TRAKeyValuePair>> ITypeConverter<TRACredentialType>.ConvertTo_List_List_TRAKeyValuePair(TRACredentialType value)
            {
                return TypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_TRACredentialType(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialType>.GetConversionActionTo_List_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<List<TRAKeyValuePair>>> ITypeConverter<TRACredentialType>.Enumerate_List_List_TRAKeyValuePair(TRACredentialType value)
            {
                
                yield break;
            }
            TRAEncryptionFlag ITypeConverter<TRAEncryptionFlag>.ConvertFrom_long(long value)
            {
                
                throw new InvalidCastException("Invalid cast from 'long' to 'TRAEncryptionFlag'.");
                
            }
            long ITypeConverter<TRAEncryptionFlag>.ConvertTo_long(TRAEncryptionFlag value)
            {
                return TypeConverter<long>.ConvertFrom_TRAEncryptionFlag(value);
            }
            TypeConversionAction ITypeConverter<TRAEncryptionFlag>.GetConversionActionTo_long()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long> ITypeConverter<TRAEncryptionFlag>.Enumerate_long(TRAEncryptionFlag value)
            {
                
                yield break;
            }
            TRAEncryptionFlag ITypeConverter<TRAEncryptionFlag>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    TRAEncryptionFlag intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = TRAEncryptionFlag.TryParse(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        Throw.cannot_parse(value, "TRAEncryptionFlag");
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<TRAEncryptionFlag>.ConvertTo_string(TRAEncryptionFlag value)
            {
                return TypeConverter<string>.ConvertFrom_TRAEncryptionFlag(value);
            }
            TypeConversionAction ITypeConverter<TRAEncryptionFlag>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<TRAEncryptionFlag>.Enumerate_string(TRAEncryptionFlag value)
            {
                
                yield break;
            }
            TRAEncryptionFlag ITypeConverter<TRAEncryptionFlag>.ConvertFrom_List_string(List<string> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<string>' to 'TRAEncryptionFlag'.");
                
            }
            List<string> ITypeConverter<TRAEncryptionFlag>.ConvertTo_List_string(TRAEncryptionFlag value)
            {
                return TypeConverter<List<string>>.ConvertFrom_TRAEncryptionFlag(value);
            }
            TypeConversionAction ITypeConverter<TRAEncryptionFlag>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_WRAPINLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<TRAEncryptionFlag>.Enumerate_List_string(TRAEncryptionFlag value)
            {
                
                yield break;
            }
            TRAEncryptionFlag ITypeConverter<TRAEncryptionFlag>.ConvertFrom_List_TRAClaim(List<TRAClaim> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<TRAClaim>' to 'TRAEncryptionFlag'.");
                
            }
            List<TRAClaim> ITypeConverter<TRAEncryptionFlag>.ConvertTo_List_TRAClaim(TRAEncryptionFlag value)
            {
                return TypeConverter<List<TRAClaim>>.ConvertFrom_TRAEncryptionFlag(value);
            }
            TypeConversionAction ITypeConverter<TRAEncryptionFlag>.GetConversionActionTo_List_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAClaim>> ITypeConverter<TRAEncryptionFlag>.Enumerate_List_TRAClaim(TRAEncryptionFlag value)
            {
                
                yield break;
            }
            TRAEncryptionFlag ITypeConverter<TRAEncryptionFlag>.ConvertFrom_List_TRAKeyValuePair(List<TRAKeyValuePair> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<TRAKeyValuePair>' to 'TRAEncryptionFlag'.");
                
            }
            List<TRAKeyValuePair> ITypeConverter<TRAEncryptionFlag>.ConvertTo_List_TRAKeyValuePair(TRAEncryptionFlag value)
            {
                return TypeConverter<List<TRAKeyValuePair>>.ConvertFrom_TRAEncryptionFlag(value);
            }
            TypeConversionAction ITypeConverter<TRAEncryptionFlag>.GetConversionActionTo_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAKeyValuePair>> ITypeConverter<TRAEncryptionFlag>.Enumerate_List_TRAKeyValuePair(TRAEncryptionFlag value)
            {
                
                yield break;
            }
            TRAEncryptionFlag ITypeConverter<TRAEncryptionFlag>.ConvertFrom_TRAClaim(TRAClaim value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAClaim' to 'TRAEncryptionFlag'.");
                
            }
            TRAClaim ITypeConverter<TRAEncryptionFlag>.ConvertTo_TRAClaim(TRAEncryptionFlag value)
            {
                return TypeConverter<TRAClaim>.ConvertFrom_TRAEncryptionFlag(value);
            }
            TypeConversionAction ITypeConverter<TRAEncryptionFlag>.GetConversionActionTo_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAClaim> ITypeConverter<TRAEncryptionFlag>.Enumerate_TRAClaim(TRAEncryptionFlag value)
            {
                
                yield break;
            }
            TRAEncryptionFlag ITypeConverter<TRAEncryptionFlag>.ConvertFrom_TRACredentialCore(TRACredentialCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialCore' to 'TRAEncryptionFlag'.");
                
            }
            TRACredentialCore ITypeConverter<TRAEncryptionFlag>.ConvertTo_TRACredentialCore(TRAEncryptionFlag value)
            {
                return TypeConverter<TRACredentialCore>.ConvertFrom_TRAEncryptionFlag(value);
            }
            TypeConversionAction ITypeConverter<TRAEncryptionFlag>.GetConversionActionTo_TRACredentialCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialCore> ITypeConverter<TRAEncryptionFlag>.Enumerate_TRACredentialCore(TRAEncryptionFlag value)
            {
                
                yield break;
            }
            TRAEncryptionFlag ITypeConverter<TRAEncryptionFlag>.ConvertFrom_TRAEnvelope(TRAEnvelope value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAEnvelope' to 'TRAEncryptionFlag'.");
                
            }
            TRAEnvelope ITypeConverter<TRAEncryptionFlag>.ConvertTo_TRAEnvelope(TRAEncryptionFlag value)
            {
                return TypeConverter<TRAEnvelope>.ConvertFrom_TRAEncryptionFlag(value);
            }
            TypeConversionAction ITypeConverter<TRAEncryptionFlag>.GetConversionActionTo_TRAEnvelope()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEnvelope> ITypeConverter<TRAEncryptionFlag>.Enumerate_TRAEnvelope(TRAEncryptionFlag value)
            {
                
                yield break;
            }
            TRAEncryptionFlag ITypeConverter<TRAEncryptionFlag>.ConvertFrom_TRAKeyValuePair(TRAKeyValuePair value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAKeyValuePair' to 'TRAEncryptionFlag'.");
                
            }
            TRAKeyValuePair ITypeConverter<TRAEncryptionFlag>.ConvertTo_TRAKeyValuePair(TRAEncryptionFlag value)
            {
                return TypeConverter<TRAKeyValuePair>.ConvertFrom_TRAEncryptionFlag(value);
            }
            TypeConversionAction ITypeConverter<TRAEncryptionFlag>.GetConversionActionTo_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAKeyValuePair> ITypeConverter<TRAEncryptionFlag>.Enumerate_TRAKeyValuePair(TRAEncryptionFlag value)
            {
                
                yield break;
            }
            TRAEncryptionFlag ITypeConverter<TRAEncryptionFlag>.ConvertFrom_TRACredentialType(TRACredentialType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialType' to 'TRAEncryptionFlag'.");
                
            }
            TRACredentialType ITypeConverter<TRAEncryptionFlag>.ConvertTo_TRACredentialType(TRAEncryptionFlag value)
            {
                return TypeConverter<TRACredentialType>.ConvertFrom_TRAEncryptionFlag(value);
            }
            TypeConversionAction ITypeConverter<TRAEncryptionFlag>.GetConversionActionTo_TRACredentialType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialType> ITypeConverter<TRAEncryptionFlag>.Enumerate_TRACredentialType(TRAEncryptionFlag value)
            {
                
                yield break;
            }
            TRAEncryptionFlag ITypeConverter<TRAEncryptionFlag>.ConvertFrom_TRAEncryptionFlag(TRAEncryptionFlag value)
            {
                
                return (TRAEncryptionFlag)value;
                
            }
            TRAEncryptionFlag ITypeConverter<TRAEncryptionFlag>.ConvertTo_TRAEncryptionFlag(TRAEncryptionFlag value)
            {
                return TypeConverter<TRAEncryptionFlag>.ConvertFrom_TRAEncryptionFlag(value);
            }
            TypeConversionAction ITypeConverter<TRAEncryptionFlag>.GetConversionActionTo_TRAEncryptionFlag()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEncryptionFlag> ITypeConverter<TRAEncryptionFlag>.Enumerate_TRAEncryptionFlag(TRAEncryptionFlag value)
            {
                
                yield break;
            }
            TRAEncryptionFlag ITypeConverter<TRAEncryptionFlag>.ConvertFrom_TRATrustLevel(TRATrustLevel value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRATrustLevel' to 'TRAEncryptionFlag'.");
                
            }
            TRATrustLevel ITypeConverter<TRAEncryptionFlag>.ConvertTo_TRATrustLevel(TRAEncryptionFlag value)
            {
                return TypeConverter<TRATrustLevel>.ConvertFrom_TRAEncryptionFlag(value);
            }
            TypeConversionAction ITypeConverter<TRAEncryptionFlag>.GetConversionActionTo_TRATrustLevel()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRATrustLevel> ITypeConverter<TRAEncryptionFlag>.Enumerate_TRATrustLevel(TRAEncryptionFlag value)
            {
                
                yield break;
            }
            TRAEncryptionFlag ITypeConverter<TRAEncryptionFlag>.ConvertFrom_List_List_TRAKeyValuePair(List<List<TRAKeyValuePair>> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<List<TRAKeyValuePair>>' to 'TRAEncryptionFlag'.");
                
            }
            List<List<TRAKeyValuePair>> ITypeConverter<TRAEncryptionFlag>.ConvertTo_List_List_TRAKeyValuePair(TRAEncryptionFlag value)
            {
                return TypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_TRAEncryptionFlag(value);
            }
            TypeConversionAction ITypeConverter<TRAEncryptionFlag>.GetConversionActionTo_List_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<List<TRAKeyValuePair>>> ITypeConverter<TRAEncryptionFlag>.Enumerate_List_List_TRAKeyValuePair(TRAEncryptionFlag value)
            {
                
                yield break;
            }
            TRATrustLevel ITypeConverter<TRATrustLevel>.ConvertFrom_long(long value)
            {
                
                throw new InvalidCastException("Invalid cast from 'long' to 'TRATrustLevel'.");
                
            }
            long ITypeConverter<TRATrustLevel>.ConvertTo_long(TRATrustLevel value)
            {
                return TypeConverter<long>.ConvertFrom_TRATrustLevel(value);
            }
            TypeConversionAction ITypeConverter<TRATrustLevel>.GetConversionActionTo_long()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long> ITypeConverter<TRATrustLevel>.Enumerate_long(TRATrustLevel value)
            {
                
                yield break;
            }
            TRATrustLevel ITypeConverter<TRATrustLevel>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    TRATrustLevel intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = TRATrustLevel.TryParse(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        Throw.cannot_parse(value, "TRATrustLevel");
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<TRATrustLevel>.ConvertTo_string(TRATrustLevel value)
            {
                return TypeConverter<string>.ConvertFrom_TRATrustLevel(value);
            }
            TypeConversionAction ITypeConverter<TRATrustLevel>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<TRATrustLevel>.Enumerate_string(TRATrustLevel value)
            {
                
                yield break;
            }
            TRATrustLevel ITypeConverter<TRATrustLevel>.ConvertFrom_List_string(List<string> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<string>' to 'TRATrustLevel'.");
                
            }
            List<string> ITypeConverter<TRATrustLevel>.ConvertTo_List_string(TRATrustLevel value)
            {
                return TypeConverter<List<string>>.ConvertFrom_TRATrustLevel(value);
            }
            TypeConversionAction ITypeConverter<TRATrustLevel>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_WRAPINLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<TRATrustLevel>.Enumerate_List_string(TRATrustLevel value)
            {
                
                yield break;
            }
            TRATrustLevel ITypeConverter<TRATrustLevel>.ConvertFrom_List_TRAClaim(List<TRAClaim> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<TRAClaim>' to 'TRATrustLevel'.");
                
            }
            List<TRAClaim> ITypeConverter<TRATrustLevel>.ConvertTo_List_TRAClaim(TRATrustLevel value)
            {
                return TypeConverter<List<TRAClaim>>.ConvertFrom_TRATrustLevel(value);
            }
            TypeConversionAction ITypeConverter<TRATrustLevel>.GetConversionActionTo_List_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAClaim>> ITypeConverter<TRATrustLevel>.Enumerate_List_TRAClaim(TRATrustLevel value)
            {
                
                yield break;
            }
            TRATrustLevel ITypeConverter<TRATrustLevel>.ConvertFrom_List_TRAKeyValuePair(List<TRAKeyValuePair> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<TRAKeyValuePair>' to 'TRATrustLevel'.");
                
            }
            List<TRAKeyValuePair> ITypeConverter<TRATrustLevel>.ConvertTo_List_TRAKeyValuePair(TRATrustLevel value)
            {
                return TypeConverter<List<TRAKeyValuePair>>.ConvertFrom_TRATrustLevel(value);
            }
            TypeConversionAction ITypeConverter<TRATrustLevel>.GetConversionActionTo_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAKeyValuePair>> ITypeConverter<TRATrustLevel>.Enumerate_List_TRAKeyValuePair(TRATrustLevel value)
            {
                
                yield break;
            }
            TRATrustLevel ITypeConverter<TRATrustLevel>.ConvertFrom_TRAClaim(TRAClaim value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAClaim' to 'TRATrustLevel'.");
                
            }
            TRAClaim ITypeConverter<TRATrustLevel>.ConvertTo_TRAClaim(TRATrustLevel value)
            {
                return TypeConverter<TRAClaim>.ConvertFrom_TRATrustLevel(value);
            }
            TypeConversionAction ITypeConverter<TRATrustLevel>.GetConversionActionTo_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAClaim> ITypeConverter<TRATrustLevel>.Enumerate_TRAClaim(TRATrustLevel value)
            {
                
                yield break;
            }
            TRATrustLevel ITypeConverter<TRATrustLevel>.ConvertFrom_TRACredentialCore(TRACredentialCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialCore' to 'TRATrustLevel'.");
                
            }
            TRACredentialCore ITypeConverter<TRATrustLevel>.ConvertTo_TRACredentialCore(TRATrustLevel value)
            {
                return TypeConverter<TRACredentialCore>.ConvertFrom_TRATrustLevel(value);
            }
            TypeConversionAction ITypeConverter<TRATrustLevel>.GetConversionActionTo_TRACredentialCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialCore> ITypeConverter<TRATrustLevel>.Enumerate_TRACredentialCore(TRATrustLevel value)
            {
                
                yield break;
            }
            TRATrustLevel ITypeConverter<TRATrustLevel>.ConvertFrom_TRAEnvelope(TRAEnvelope value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAEnvelope' to 'TRATrustLevel'.");
                
            }
            TRAEnvelope ITypeConverter<TRATrustLevel>.ConvertTo_TRAEnvelope(TRATrustLevel value)
            {
                return TypeConverter<TRAEnvelope>.ConvertFrom_TRATrustLevel(value);
            }
            TypeConversionAction ITypeConverter<TRATrustLevel>.GetConversionActionTo_TRAEnvelope()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEnvelope> ITypeConverter<TRATrustLevel>.Enumerate_TRAEnvelope(TRATrustLevel value)
            {
                
                yield break;
            }
            TRATrustLevel ITypeConverter<TRATrustLevel>.ConvertFrom_TRAKeyValuePair(TRAKeyValuePair value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAKeyValuePair' to 'TRATrustLevel'.");
                
            }
            TRAKeyValuePair ITypeConverter<TRATrustLevel>.ConvertTo_TRAKeyValuePair(TRATrustLevel value)
            {
                return TypeConverter<TRAKeyValuePair>.ConvertFrom_TRATrustLevel(value);
            }
            TypeConversionAction ITypeConverter<TRATrustLevel>.GetConversionActionTo_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAKeyValuePair> ITypeConverter<TRATrustLevel>.Enumerate_TRAKeyValuePair(TRATrustLevel value)
            {
                
                yield break;
            }
            TRATrustLevel ITypeConverter<TRATrustLevel>.ConvertFrom_TRACredentialType(TRACredentialType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialType' to 'TRATrustLevel'.");
                
            }
            TRACredentialType ITypeConverter<TRATrustLevel>.ConvertTo_TRACredentialType(TRATrustLevel value)
            {
                return TypeConverter<TRACredentialType>.ConvertFrom_TRATrustLevel(value);
            }
            TypeConversionAction ITypeConverter<TRATrustLevel>.GetConversionActionTo_TRACredentialType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialType> ITypeConverter<TRATrustLevel>.Enumerate_TRACredentialType(TRATrustLevel value)
            {
                
                yield break;
            }
            TRATrustLevel ITypeConverter<TRATrustLevel>.ConvertFrom_TRAEncryptionFlag(TRAEncryptionFlag value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAEncryptionFlag' to 'TRATrustLevel'.");
                
            }
            TRAEncryptionFlag ITypeConverter<TRATrustLevel>.ConvertTo_TRAEncryptionFlag(TRATrustLevel value)
            {
                return TypeConverter<TRAEncryptionFlag>.ConvertFrom_TRATrustLevel(value);
            }
            TypeConversionAction ITypeConverter<TRATrustLevel>.GetConversionActionTo_TRAEncryptionFlag()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEncryptionFlag> ITypeConverter<TRATrustLevel>.Enumerate_TRAEncryptionFlag(TRATrustLevel value)
            {
                
                yield break;
            }
            TRATrustLevel ITypeConverter<TRATrustLevel>.ConvertFrom_TRATrustLevel(TRATrustLevel value)
            {
                
                return (TRATrustLevel)value;
                
            }
            TRATrustLevel ITypeConverter<TRATrustLevel>.ConvertTo_TRATrustLevel(TRATrustLevel value)
            {
                return TypeConverter<TRATrustLevel>.ConvertFrom_TRATrustLevel(value);
            }
            TypeConversionAction ITypeConverter<TRATrustLevel>.GetConversionActionTo_TRATrustLevel()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRATrustLevel> ITypeConverter<TRATrustLevel>.Enumerate_TRATrustLevel(TRATrustLevel value)
            {
                
                yield break;
            }
            TRATrustLevel ITypeConverter<TRATrustLevel>.ConvertFrom_List_List_TRAKeyValuePair(List<List<TRAKeyValuePair>> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<List<TRAKeyValuePair>>' to 'TRATrustLevel'.");
                
            }
            List<List<TRAKeyValuePair>> ITypeConverter<TRATrustLevel>.ConvertTo_List_List_TRAKeyValuePair(TRATrustLevel value)
            {
                return TypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_TRATrustLevel(value);
            }
            TypeConversionAction ITypeConverter<TRATrustLevel>.GetConversionActionTo_List_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<List<TRAKeyValuePair>>> ITypeConverter<TRATrustLevel>.Enumerate_List_List_TRAKeyValuePair(TRATrustLevel value)
            {
                
                yield break;
            }
            List<List<TRAKeyValuePair>> ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_long(long value)
            {
                
                throw new InvalidCastException("Invalid cast from 'long' to 'List<List<TRAKeyValuePair>>'.");
                
            }
            long ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertTo_long(List<List<TRAKeyValuePair>> value)
            {
                return TypeConverter<long>.ConvertFrom_List_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<List<TRAKeyValuePair>>>.GetConversionActionTo_long()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long> ITypeConverter<List<List<TRAKeyValuePair>>>.Enumerate_long(List<List<TRAKeyValuePair>> value)
            {
                
                yield break;
            }
            List<List<TRAKeyValuePair>> ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    List<List<TRAKeyValuePair>> intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = ExternalParser.TryParse_List_List_TRAKeyValuePair(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        try
                        {
                            List<TRAKeyValuePair> element = TypeConverter<List<TRAKeyValuePair>>.ConvertFrom_string(value);
                            intermediate_result = new List<List<TRAKeyValuePair>>();
                            intermediate_result.Add(element);
                        }
                        catch
                        {
                            throw new ArgumentException("Cannot parse \"" + value + "\" into either 'List<List<TRAKeyValuePair>>' or 'List<TRAKeyValuePair>'.");
                        }
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertTo_string(List<List<TRAKeyValuePair>> value)
            {
                return TypeConverter<string>.ConvertFrom_List_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<List<TRAKeyValuePair>>>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<List<List<TRAKeyValuePair>>>.Enumerate_string(List<List<TRAKeyValuePair>> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<string>.ConvertFrom_List_TRAKeyValuePair(element);
                
                yield break;
            }
            List<List<TRAKeyValuePair>> ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_List_string(List<string> value)
            {
                
                {
                    List<List<TRAKeyValuePair>> intermediate_result = new List<List<TRAKeyValuePair>>();
                    foreach (var element in value)
                    {
                        intermediate_result.Add(TypeConverter<List<TRAKeyValuePair>>.ConvertFrom_string(element));
                    }
                    return intermediate_result;
                }
                
            }
            List<string> ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertTo_List_string(List<List<TRAKeyValuePair>> value)
            {
                return TypeConverter<List<string>>.ConvertFrom_List_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<List<TRAKeyValuePair>>>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_CONVERTLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<List<List<TRAKeyValuePair>>>.Enumerate_List_string(List<List<TRAKeyValuePair>> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<List<string>>.ConvertFrom_List_TRAKeyValuePair(element);
                
                yield break;
            }
            List<List<TRAKeyValuePair>> ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_List_TRAClaim(List<TRAClaim> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<TRAClaim>' to 'List<List<TRAKeyValuePair>>'.");
                
            }
            List<TRAClaim> ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertTo_List_TRAClaim(List<List<TRAKeyValuePair>> value)
            {
                return TypeConverter<List<TRAClaim>>.ConvertFrom_List_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<List<TRAKeyValuePair>>>.GetConversionActionTo_List_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAClaim>> ITypeConverter<List<List<TRAKeyValuePair>>>.Enumerate_List_TRAClaim(List<List<TRAKeyValuePair>> value)
            {
                
                yield break;
            }
            List<List<TRAKeyValuePair>> ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_List_TRAKeyValuePair(List<TRAKeyValuePair> value)
            {
                
                {
                    List<List<TRAKeyValuePair>> intermediate_result = new List<List<TRAKeyValuePair>>();
                    foreach (var element in value)
                    {
                        intermediate_result.Add(TypeConverter<List<TRAKeyValuePair>>.ConvertFrom_TRAKeyValuePair(element));
                    }
                    return intermediate_result;
                }
                
            }
            List<TRAKeyValuePair> ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertTo_List_TRAKeyValuePair(List<List<TRAKeyValuePair>> value)
            {
                return TypeConverter<List<TRAKeyValuePair>>.ConvertFrom_List_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<List<TRAKeyValuePair>>>.GetConversionActionTo_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAKeyValuePair>> ITypeConverter<List<List<TRAKeyValuePair>>>.Enumerate_List_TRAKeyValuePair(List<List<TRAKeyValuePair>> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<List<TRAKeyValuePair>>.ConvertFrom_List_TRAKeyValuePair(element);
                
                yield break;
            }
            List<List<TRAKeyValuePair>> ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_TRAClaim(TRAClaim value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAClaim' to 'List<List<TRAKeyValuePair>>'.");
                
            }
            TRAClaim ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertTo_TRAClaim(List<List<TRAKeyValuePair>> value)
            {
                return TypeConverter<TRAClaim>.ConvertFrom_List_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<List<TRAKeyValuePair>>>.GetConversionActionTo_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAClaim> ITypeConverter<List<List<TRAKeyValuePair>>>.Enumerate_TRAClaim(List<List<TRAKeyValuePair>> value)
            {
                
                yield break;
            }
            List<List<TRAKeyValuePair>> ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_TRACredentialCore(TRACredentialCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialCore' to 'List<List<TRAKeyValuePair>>'.");
                
            }
            TRACredentialCore ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertTo_TRACredentialCore(List<List<TRAKeyValuePair>> value)
            {
                return TypeConverter<TRACredentialCore>.ConvertFrom_List_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<List<TRAKeyValuePair>>>.GetConversionActionTo_TRACredentialCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialCore> ITypeConverter<List<List<TRAKeyValuePair>>>.Enumerate_TRACredentialCore(List<List<TRAKeyValuePair>> value)
            {
                
                yield break;
            }
            List<List<TRAKeyValuePair>> ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_TRAEnvelope(TRAEnvelope value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAEnvelope' to 'List<List<TRAKeyValuePair>>'.");
                
            }
            TRAEnvelope ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertTo_TRAEnvelope(List<List<TRAKeyValuePair>> value)
            {
                return TypeConverter<TRAEnvelope>.ConvertFrom_List_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<List<TRAKeyValuePair>>>.GetConversionActionTo_TRAEnvelope()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEnvelope> ITypeConverter<List<List<TRAKeyValuePair>>>.Enumerate_TRAEnvelope(List<List<TRAKeyValuePair>> value)
            {
                
                yield break;
            }
            List<List<TRAKeyValuePair>> ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_TRAKeyValuePair(TRAKeyValuePair value)
            {
                
                {
                    List<List<TRAKeyValuePair>> intermediate_result = new List<List<TRAKeyValuePair>>();
                    intermediate_result.Add(TypeConverter<List<TRAKeyValuePair>>.ConvertFrom_TRAKeyValuePair(value));
                    return intermediate_result;
                }
                
            }
            TRAKeyValuePair ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertTo_TRAKeyValuePair(List<List<TRAKeyValuePair>> value)
            {
                return TypeConverter<TRAKeyValuePair>.ConvertFrom_List_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<List<TRAKeyValuePair>>>.GetConversionActionTo_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAKeyValuePair> ITypeConverter<List<List<TRAKeyValuePair>>>.Enumerate_TRAKeyValuePair(List<List<TRAKeyValuePair>> value)
            {
                
                yield break;
            }
            List<List<TRAKeyValuePair>> ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_TRACredentialType(TRACredentialType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialType' to 'List<List<TRAKeyValuePair>>'.");
                
            }
            TRACredentialType ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertTo_TRACredentialType(List<List<TRAKeyValuePair>> value)
            {
                return TypeConverter<TRACredentialType>.ConvertFrom_List_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<List<TRAKeyValuePair>>>.GetConversionActionTo_TRACredentialType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialType> ITypeConverter<List<List<TRAKeyValuePair>>>.Enumerate_TRACredentialType(List<List<TRAKeyValuePair>> value)
            {
                
                yield break;
            }
            List<List<TRAKeyValuePair>> ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_TRAEncryptionFlag(TRAEncryptionFlag value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAEncryptionFlag' to 'List<List<TRAKeyValuePair>>'.");
                
            }
            TRAEncryptionFlag ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertTo_TRAEncryptionFlag(List<List<TRAKeyValuePair>> value)
            {
                return TypeConverter<TRAEncryptionFlag>.ConvertFrom_List_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<List<TRAKeyValuePair>>>.GetConversionActionTo_TRAEncryptionFlag()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEncryptionFlag> ITypeConverter<List<List<TRAKeyValuePair>>>.Enumerate_TRAEncryptionFlag(List<List<TRAKeyValuePair>> value)
            {
                
                yield break;
            }
            List<List<TRAKeyValuePair>> ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_TRATrustLevel(TRATrustLevel value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRATrustLevel' to 'List<List<TRAKeyValuePair>>'.");
                
            }
            TRATrustLevel ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertTo_TRATrustLevel(List<List<TRAKeyValuePair>> value)
            {
                return TypeConverter<TRATrustLevel>.ConvertFrom_List_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<List<TRAKeyValuePair>>>.GetConversionActionTo_TRATrustLevel()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRATrustLevel> ITypeConverter<List<List<TRAKeyValuePair>>>.Enumerate_TRATrustLevel(List<List<TRAKeyValuePair>> value)
            {
                
                yield break;
            }
            List<List<TRAKeyValuePair>> ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_List_List_TRAKeyValuePair(List<List<TRAKeyValuePair>> value)
            {
                
                return (List<List<TRAKeyValuePair>>)value;
                
            }
            List<List<TRAKeyValuePair>> ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertTo_List_List_TRAKeyValuePair(List<List<TRAKeyValuePair>> value)
            {
                return TypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_List_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<List<TRAKeyValuePair>>>.GetConversionActionTo_List_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<List<TRAKeyValuePair>>> ITypeConverter<List<List<TRAKeyValuePair>>>.Enumerate_List_List_TRAKeyValuePair(List<List<TRAKeyValuePair>> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_List_TRAKeyValuePair(element);
                
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
            
            object ITypeConverter<object>.ConvertFrom_List_TRAClaim(List<TRAClaim> value)
            {
                return value;
            }
            List<TRAClaim> ITypeConverter<object>.ConvertTo_List_TRAClaim(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_List_TRAClaim()
            {
                throw new NotImplementedException();
            }
            IEnumerable<List<TRAClaim>> ITypeConverter<object>.Enumerate_List_TRAClaim(object value)
            {
                throw new NotImplementedException();
            }
            
            object ITypeConverter<object>.ConvertFrom_List_TRAKeyValuePair(List<TRAKeyValuePair> value)
            {
                return value;
            }
            List<TRAKeyValuePair> ITypeConverter<object>.ConvertTo_List_TRAKeyValuePair(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_List_TRAKeyValuePair()
            {
                throw new NotImplementedException();
            }
            IEnumerable<List<TRAKeyValuePair>> ITypeConverter<object>.Enumerate_List_TRAKeyValuePair(object value)
            {
                throw new NotImplementedException();
            }
            
            object ITypeConverter<object>.ConvertFrom_TRAClaim(TRAClaim value)
            {
                return value;
            }
            TRAClaim ITypeConverter<object>.ConvertTo_TRAClaim(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_TRAClaim()
            {
                throw new NotImplementedException();
            }
            IEnumerable<TRAClaim> ITypeConverter<object>.Enumerate_TRAClaim(object value)
            {
                throw new NotImplementedException();
            }
            
            object ITypeConverter<object>.ConvertFrom_TRACredentialCore(TRACredentialCore value)
            {
                return value;
            }
            TRACredentialCore ITypeConverter<object>.ConvertTo_TRACredentialCore(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_TRACredentialCore()
            {
                throw new NotImplementedException();
            }
            IEnumerable<TRACredentialCore> ITypeConverter<object>.Enumerate_TRACredentialCore(object value)
            {
                throw new NotImplementedException();
            }
            
            object ITypeConverter<object>.ConvertFrom_TRAEnvelope(TRAEnvelope value)
            {
                return value;
            }
            TRAEnvelope ITypeConverter<object>.ConvertTo_TRAEnvelope(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_TRAEnvelope()
            {
                throw new NotImplementedException();
            }
            IEnumerable<TRAEnvelope> ITypeConverter<object>.Enumerate_TRAEnvelope(object value)
            {
                throw new NotImplementedException();
            }
            
            object ITypeConverter<object>.ConvertFrom_TRAKeyValuePair(TRAKeyValuePair value)
            {
                return value;
            }
            TRAKeyValuePair ITypeConverter<object>.ConvertTo_TRAKeyValuePair(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_TRAKeyValuePair()
            {
                throw new NotImplementedException();
            }
            IEnumerable<TRAKeyValuePair> ITypeConverter<object>.Enumerate_TRAKeyValuePair(object value)
            {
                throw new NotImplementedException();
            }
            
            object ITypeConverter<object>.ConvertFrom_TRACredentialType(TRACredentialType value)
            {
                return value;
            }
            TRACredentialType ITypeConverter<object>.ConvertTo_TRACredentialType(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_TRACredentialType()
            {
                throw new NotImplementedException();
            }
            IEnumerable<TRACredentialType> ITypeConverter<object>.Enumerate_TRACredentialType(object value)
            {
                throw new NotImplementedException();
            }
            
            object ITypeConverter<object>.ConvertFrom_TRAEncryptionFlag(TRAEncryptionFlag value)
            {
                return value;
            }
            TRAEncryptionFlag ITypeConverter<object>.ConvertTo_TRAEncryptionFlag(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_TRAEncryptionFlag()
            {
                throw new NotImplementedException();
            }
            IEnumerable<TRAEncryptionFlag> ITypeConverter<object>.Enumerate_TRAEncryptionFlag(object value)
            {
                throw new NotImplementedException();
            }
            
            object ITypeConverter<object>.ConvertFrom_TRATrustLevel(TRATrustLevel value)
            {
                return value;
            }
            TRATrustLevel ITypeConverter<object>.ConvertTo_TRATrustLevel(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_TRATrustLevel()
            {
                throw new NotImplementedException();
            }
            IEnumerable<TRATrustLevel> ITypeConverter<object>.Enumerate_TRATrustLevel(object value)
            {
                throw new NotImplementedException();
            }
            
            object ITypeConverter<object>.ConvertFrom_List_List_TRAKeyValuePair(List<List<TRAKeyValuePair>> value)
            {
                return value;
            }
            List<List<TRAKeyValuePair>> ITypeConverter<object>.ConvertTo_List_List_TRAKeyValuePair(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_List_List_TRAKeyValuePair()
            {
                throw new NotImplementedException();
            }
            IEnumerable<List<List<TRAKeyValuePair>>> ITypeConverter<object>.Enumerate_List_List_TRAKeyValuePair(object value)
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
        
        T ITypeConverter<T>.ConvertFrom_List_TRAClaim(List<TRAClaim> value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        List<TRAClaim> ITypeConverter<T>.ConvertTo_List_TRAClaim(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_List_TRAClaim()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<List<TRAClaim>> ITypeConverter<T>.Enumerate_List_TRAClaim(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        
        T ITypeConverter<T>.ConvertFrom_List_TRAKeyValuePair(List<TRAKeyValuePair> value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        List<TRAKeyValuePair> ITypeConverter<T>.ConvertTo_List_TRAKeyValuePair(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_List_TRAKeyValuePair()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<List<TRAKeyValuePair>> ITypeConverter<T>.Enumerate_List_TRAKeyValuePair(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        
        T ITypeConverter<T>.ConvertFrom_TRAClaim(TRAClaim value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TRAClaim ITypeConverter<T>.ConvertTo_TRAClaim(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_TRAClaim()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<TRAClaim> ITypeConverter<T>.Enumerate_TRAClaim(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        
        T ITypeConverter<T>.ConvertFrom_TRACredentialCore(TRACredentialCore value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TRACredentialCore ITypeConverter<T>.ConvertTo_TRACredentialCore(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_TRACredentialCore()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<TRACredentialCore> ITypeConverter<T>.Enumerate_TRACredentialCore(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        
        T ITypeConverter<T>.ConvertFrom_TRAEnvelope(TRAEnvelope value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TRAEnvelope ITypeConverter<T>.ConvertTo_TRAEnvelope(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_TRAEnvelope()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<TRAEnvelope> ITypeConverter<T>.Enumerate_TRAEnvelope(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        
        T ITypeConverter<T>.ConvertFrom_TRAKeyValuePair(TRAKeyValuePair value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TRAKeyValuePair ITypeConverter<T>.ConvertTo_TRAKeyValuePair(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_TRAKeyValuePair()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<TRAKeyValuePair> ITypeConverter<T>.Enumerate_TRAKeyValuePair(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        
        T ITypeConverter<T>.ConvertFrom_TRACredentialType(TRACredentialType value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TRACredentialType ITypeConverter<T>.ConvertTo_TRACredentialType(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_TRACredentialType()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<TRACredentialType> ITypeConverter<T>.Enumerate_TRACredentialType(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        
        T ITypeConverter<T>.ConvertFrom_TRAEncryptionFlag(TRAEncryptionFlag value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TRAEncryptionFlag ITypeConverter<T>.ConvertTo_TRAEncryptionFlag(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_TRAEncryptionFlag()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<TRAEncryptionFlag> ITypeConverter<T>.Enumerate_TRAEncryptionFlag(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        
        T ITypeConverter<T>.ConvertFrom_TRATrustLevel(TRATrustLevel value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TRATrustLevel ITypeConverter<T>.ConvertTo_TRATrustLevel(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_TRATrustLevel()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<TRATrustLevel> ITypeConverter<T>.Enumerate_TRATrustLevel(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        
        T ITypeConverter<T>.ConvertFrom_List_List_TRAKeyValuePair(List<List<TRAKeyValuePair>> value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        List<List<TRAKeyValuePair>> ITypeConverter<T>.ConvertTo_List_List_TRAKeyValuePair(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_List_List_TRAKeyValuePair()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<List<List<TRAKeyValuePair>>> ITypeConverter<T>.Enumerate_List_List_TRAKeyValuePair(T value)
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
        
        internal static T ConvertFrom_List_TRAClaim(List<TRAClaim> value)
        {
            return s_type_converter.ConvertFrom_List_TRAClaim(value);
        }
        internal static List<TRAClaim> ConvertTo_List_TRAClaim(T value)
        {
            return s_type_converter.ConvertTo_List_TRAClaim(value);
        }
        internal static TypeConversionAction GetConversionActionTo_List_TRAClaim()
        {
            return s_type_converter.GetConversionActionTo_List_TRAClaim();
        }
        internal static IEnumerable<List<TRAClaim>> Enumerate_List_TRAClaim(T value)
        {
            return s_type_converter.Enumerate_List_TRAClaim(value);
        }
        
        internal static T ConvertFrom_List_TRAKeyValuePair(List<TRAKeyValuePair> value)
        {
            return s_type_converter.ConvertFrom_List_TRAKeyValuePair(value);
        }
        internal static List<TRAKeyValuePair> ConvertTo_List_TRAKeyValuePair(T value)
        {
            return s_type_converter.ConvertTo_List_TRAKeyValuePair(value);
        }
        internal static TypeConversionAction GetConversionActionTo_List_TRAKeyValuePair()
        {
            return s_type_converter.GetConversionActionTo_List_TRAKeyValuePair();
        }
        internal static IEnumerable<List<TRAKeyValuePair>> Enumerate_List_TRAKeyValuePair(T value)
        {
            return s_type_converter.Enumerate_List_TRAKeyValuePair(value);
        }
        
        internal static T ConvertFrom_TRAClaim(TRAClaim value)
        {
            return s_type_converter.ConvertFrom_TRAClaim(value);
        }
        internal static TRAClaim ConvertTo_TRAClaim(T value)
        {
            return s_type_converter.ConvertTo_TRAClaim(value);
        }
        internal static TypeConversionAction GetConversionActionTo_TRAClaim()
        {
            return s_type_converter.GetConversionActionTo_TRAClaim();
        }
        internal static IEnumerable<TRAClaim> Enumerate_TRAClaim(T value)
        {
            return s_type_converter.Enumerate_TRAClaim(value);
        }
        
        internal static T ConvertFrom_TRACredentialCore(TRACredentialCore value)
        {
            return s_type_converter.ConvertFrom_TRACredentialCore(value);
        }
        internal static TRACredentialCore ConvertTo_TRACredentialCore(T value)
        {
            return s_type_converter.ConvertTo_TRACredentialCore(value);
        }
        internal static TypeConversionAction GetConversionActionTo_TRACredentialCore()
        {
            return s_type_converter.GetConversionActionTo_TRACredentialCore();
        }
        internal static IEnumerable<TRACredentialCore> Enumerate_TRACredentialCore(T value)
        {
            return s_type_converter.Enumerate_TRACredentialCore(value);
        }
        
        internal static T ConvertFrom_TRAEnvelope(TRAEnvelope value)
        {
            return s_type_converter.ConvertFrom_TRAEnvelope(value);
        }
        internal static TRAEnvelope ConvertTo_TRAEnvelope(T value)
        {
            return s_type_converter.ConvertTo_TRAEnvelope(value);
        }
        internal static TypeConversionAction GetConversionActionTo_TRAEnvelope()
        {
            return s_type_converter.GetConversionActionTo_TRAEnvelope();
        }
        internal static IEnumerable<TRAEnvelope> Enumerate_TRAEnvelope(T value)
        {
            return s_type_converter.Enumerate_TRAEnvelope(value);
        }
        
        internal static T ConvertFrom_TRAKeyValuePair(TRAKeyValuePair value)
        {
            return s_type_converter.ConvertFrom_TRAKeyValuePair(value);
        }
        internal static TRAKeyValuePair ConvertTo_TRAKeyValuePair(T value)
        {
            return s_type_converter.ConvertTo_TRAKeyValuePair(value);
        }
        internal static TypeConversionAction GetConversionActionTo_TRAKeyValuePair()
        {
            return s_type_converter.GetConversionActionTo_TRAKeyValuePair();
        }
        internal static IEnumerable<TRAKeyValuePair> Enumerate_TRAKeyValuePair(T value)
        {
            return s_type_converter.Enumerate_TRAKeyValuePair(value);
        }
        
        internal static T ConvertFrom_TRACredentialType(TRACredentialType value)
        {
            return s_type_converter.ConvertFrom_TRACredentialType(value);
        }
        internal static TRACredentialType ConvertTo_TRACredentialType(T value)
        {
            return s_type_converter.ConvertTo_TRACredentialType(value);
        }
        internal static TypeConversionAction GetConversionActionTo_TRACredentialType()
        {
            return s_type_converter.GetConversionActionTo_TRACredentialType();
        }
        internal static IEnumerable<TRACredentialType> Enumerate_TRACredentialType(T value)
        {
            return s_type_converter.Enumerate_TRACredentialType(value);
        }
        
        internal static T ConvertFrom_TRAEncryptionFlag(TRAEncryptionFlag value)
        {
            return s_type_converter.ConvertFrom_TRAEncryptionFlag(value);
        }
        internal static TRAEncryptionFlag ConvertTo_TRAEncryptionFlag(T value)
        {
            return s_type_converter.ConvertTo_TRAEncryptionFlag(value);
        }
        internal static TypeConversionAction GetConversionActionTo_TRAEncryptionFlag()
        {
            return s_type_converter.GetConversionActionTo_TRAEncryptionFlag();
        }
        internal static IEnumerable<TRAEncryptionFlag> Enumerate_TRAEncryptionFlag(T value)
        {
            return s_type_converter.Enumerate_TRAEncryptionFlag(value);
        }
        
        internal static T ConvertFrom_TRATrustLevel(TRATrustLevel value)
        {
            return s_type_converter.ConvertFrom_TRATrustLevel(value);
        }
        internal static TRATrustLevel ConvertTo_TRATrustLevel(T value)
        {
            return s_type_converter.ConvertTo_TRATrustLevel(value);
        }
        internal static TypeConversionAction GetConversionActionTo_TRATrustLevel()
        {
            return s_type_converter.GetConversionActionTo_TRATrustLevel();
        }
        internal static IEnumerable<TRATrustLevel> Enumerate_TRATrustLevel(T value)
        {
            return s_type_converter.Enumerate_TRATrustLevel(value);
        }
        
        internal static T ConvertFrom_List_List_TRAKeyValuePair(List<List<TRAKeyValuePair>> value)
        {
            return s_type_converter.ConvertFrom_List_List_TRAKeyValuePair(value);
        }
        internal static List<List<TRAKeyValuePair>> ConvertTo_List_List_TRAKeyValuePair(T value)
        {
            return s_type_converter.ConvertTo_List_List_TRAKeyValuePair(value);
        }
        internal static TypeConversionAction GetConversionActionTo_List_List_TRAKeyValuePair()
        {
            return s_type_converter.GetConversionActionTo_List_List_TRAKeyValuePair();
        }
        internal static IEnumerable<List<List<TRAKeyValuePair>>> Enumerate_List_List_TRAKeyValuePair(T value)
        {
            return s_type_converter.Enumerate_List_List_TRAKeyValuePair(value);
        }
        
    }
}

#pragma warning restore 162,168,649,660,661,1522
