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
            { typeof(TRACredentialContent), 6 }
            ,
            { typeof(TRACredentialCore), 7 }
            ,
            { typeof(TRACredentialEnvelope), 8 }
            ,
            { typeof(TRACredentialWrapper), 9 }
            ,
            { typeof(TRAKeyValuePair), 10 }
            ,
            { typeof(TRACredentialType), 11 }
            ,
            { typeof(TRAEncryptionFlag), 12 }
            ,
            { typeof(TRATrustLevel), 13 }
            ,
            { typeof(List<List<TRAKeyValuePair>>), 15 }
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
        
        T ConvertFrom_TRACredentialContent(TRACredentialContent value);
        TRACredentialContent ConvertTo_TRACredentialContent(T value);
        TypeConversionAction GetConversionActionTo_TRACredentialContent();
        IEnumerable<TRACredentialContent> Enumerate_TRACredentialContent(T value);
        
        T ConvertFrom_TRACredentialCore(TRACredentialCore value);
        TRACredentialCore ConvertTo_TRACredentialCore(T value);
        TypeConversionAction GetConversionActionTo_TRACredentialCore();
        IEnumerable<TRACredentialCore> Enumerate_TRACredentialCore(T value);
        
        T ConvertFrom_TRACredentialEnvelope(TRACredentialEnvelope value);
        TRACredentialEnvelope ConvertTo_TRACredentialEnvelope(T value);
        TypeConversionAction GetConversionActionTo_TRACredentialEnvelope();
        IEnumerable<TRACredentialEnvelope> Enumerate_TRACredentialEnvelope(T value);
        
        T ConvertFrom_TRACredentialWrapper(TRACredentialWrapper value);
        TRACredentialWrapper ConvertTo_TRACredentialWrapper(T value);
        TypeConversionAction GetConversionActionTo_TRACredentialWrapper();
        IEnumerable<TRACredentialWrapper> Enumerate_TRACredentialWrapper(T value);
        
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
        
            , ITypeConverter<TRACredentialContent>
        
            , ITypeConverter<TRACredentialCore>
        
            , ITypeConverter<TRACredentialEnvelope>
        
            , ITypeConverter<TRACredentialWrapper>
        
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
            long ITypeConverter<long>.ConvertFrom_TRACredentialContent(TRACredentialContent value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialContent' to 'long'.");
                
            }
            TRACredentialContent ITypeConverter<long>.ConvertTo_TRACredentialContent(long value)
            {
                return TypeConverter<TRACredentialContent>.ConvertFrom_long(value);
            }
            TypeConversionAction ITypeConverter<long>.GetConversionActionTo_TRACredentialContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialContent> ITypeConverter<long>.Enumerate_TRACredentialContent(long value)
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
            long ITypeConverter<long>.ConvertFrom_TRACredentialEnvelope(TRACredentialEnvelope value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialEnvelope' to 'long'.");
                
            }
            TRACredentialEnvelope ITypeConverter<long>.ConvertTo_TRACredentialEnvelope(long value)
            {
                return TypeConverter<TRACredentialEnvelope>.ConvertFrom_long(value);
            }
            TypeConversionAction ITypeConverter<long>.GetConversionActionTo_TRACredentialEnvelope()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialEnvelope> ITypeConverter<long>.Enumerate_TRACredentialEnvelope(long value)
            {
                
                yield break;
            }
            long ITypeConverter<long>.ConvertFrom_TRACredentialWrapper(TRACredentialWrapper value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialWrapper' to 'long'.");
                
            }
            TRACredentialWrapper ITypeConverter<long>.ConvertTo_TRACredentialWrapper(long value)
            {
                return TypeConverter<TRACredentialWrapper>.ConvertFrom_long(value);
            }
            TypeConversionAction ITypeConverter<long>.GetConversionActionTo_TRACredentialWrapper()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialWrapper> ITypeConverter<long>.Enumerate_TRACredentialWrapper(long value)
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
            string ITypeConverter<string>.ConvertFrom_TRACredentialContent(TRACredentialContent value)
            {
                
                return Serializer.ToString(value);
                
            }
            TRACredentialContent ITypeConverter<string>.ConvertTo_TRACredentialContent(string value)
            {
                return TypeConverter<TRACredentialContent>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_TRACredentialContent()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialContent> ITypeConverter<string>.Enumerate_TRACredentialContent(string value)
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
            string ITypeConverter<string>.ConvertFrom_TRACredentialEnvelope(TRACredentialEnvelope value)
            {
                
                return Serializer.ToString(value);
                
            }
            TRACredentialEnvelope ITypeConverter<string>.ConvertTo_TRACredentialEnvelope(string value)
            {
                return TypeConverter<TRACredentialEnvelope>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_TRACredentialEnvelope()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialEnvelope> ITypeConverter<string>.Enumerate_TRACredentialEnvelope(string value)
            {
                
                yield break;
            }
            string ITypeConverter<string>.ConvertFrom_TRACredentialWrapper(TRACredentialWrapper value)
            {
                
                return Serializer.ToString(value);
                
            }
            TRACredentialWrapper ITypeConverter<string>.ConvertTo_TRACredentialWrapper(string value)
            {
                return TypeConverter<TRACredentialWrapper>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_TRACredentialWrapper()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialWrapper> ITypeConverter<string>.Enumerate_TRACredentialWrapper(string value)
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
            List<string> ITypeConverter<List<string>>.ConvertFrom_TRACredentialContent(TRACredentialContent value)
            {
                
                {
                    List<string> intermediate_result = new List<string>();
                    intermediate_result.Add(TypeConverter<string>.ConvertFrom_TRACredentialContent(value));
                    return intermediate_result;
                }
                
            }
            TRACredentialContent ITypeConverter<List<string>>.ConvertTo_TRACredentialContent(List<string> value)
            {
                return TypeConverter<TRACredentialContent>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_TRACredentialContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialContent> ITypeConverter<List<string>>.Enumerate_TRACredentialContent(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<TRACredentialContent>.ConvertFrom_string(element);
                
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
            List<string> ITypeConverter<List<string>>.ConvertFrom_TRACredentialEnvelope(TRACredentialEnvelope value)
            {
                
                {
                    List<string> intermediate_result = new List<string>();
                    intermediate_result.Add(TypeConverter<string>.ConvertFrom_TRACredentialEnvelope(value));
                    return intermediate_result;
                }
                
            }
            TRACredentialEnvelope ITypeConverter<List<string>>.ConvertTo_TRACredentialEnvelope(List<string> value)
            {
                return TypeConverter<TRACredentialEnvelope>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_TRACredentialEnvelope()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialEnvelope> ITypeConverter<List<string>>.Enumerate_TRACredentialEnvelope(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<TRACredentialEnvelope>.ConvertFrom_string(element);
                
                yield break;
            }
            List<string> ITypeConverter<List<string>>.ConvertFrom_TRACredentialWrapper(TRACredentialWrapper value)
            {
                
                {
                    List<string> intermediate_result = new List<string>();
                    intermediate_result.Add(TypeConverter<string>.ConvertFrom_TRACredentialWrapper(value));
                    return intermediate_result;
                }
                
            }
            TRACredentialWrapper ITypeConverter<List<string>>.ConvertTo_TRACredentialWrapper(List<string> value)
            {
                return TypeConverter<TRACredentialWrapper>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_TRACredentialWrapper()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialWrapper> ITypeConverter<List<string>>.Enumerate_TRACredentialWrapper(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<TRACredentialWrapper>.ConvertFrom_string(element);
                
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
            List<TRAClaim> ITypeConverter<List<TRAClaim>>.ConvertFrom_TRACredentialContent(TRACredentialContent value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialContent' to 'List<TRAClaim>'.");
                
            }
            TRACredentialContent ITypeConverter<List<TRAClaim>>.ConvertTo_TRACredentialContent(List<TRAClaim> value)
            {
                return TypeConverter<TRACredentialContent>.ConvertFrom_List_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<List<TRAClaim>>.GetConversionActionTo_TRACredentialContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialContent> ITypeConverter<List<TRAClaim>>.Enumerate_TRACredentialContent(List<TRAClaim> value)
            {
                
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
            List<TRAClaim> ITypeConverter<List<TRAClaim>>.ConvertFrom_TRACredentialEnvelope(TRACredentialEnvelope value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialEnvelope' to 'List<TRAClaim>'.");
                
            }
            TRACredentialEnvelope ITypeConverter<List<TRAClaim>>.ConvertTo_TRACredentialEnvelope(List<TRAClaim> value)
            {
                return TypeConverter<TRACredentialEnvelope>.ConvertFrom_List_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<List<TRAClaim>>.GetConversionActionTo_TRACredentialEnvelope()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialEnvelope> ITypeConverter<List<TRAClaim>>.Enumerate_TRACredentialEnvelope(List<TRAClaim> value)
            {
                
                yield break;
            }
            List<TRAClaim> ITypeConverter<List<TRAClaim>>.ConvertFrom_TRACredentialWrapper(TRACredentialWrapper value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialWrapper' to 'List<TRAClaim>'.");
                
            }
            TRACredentialWrapper ITypeConverter<List<TRAClaim>>.ConvertTo_TRACredentialWrapper(List<TRAClaim> value)
            {
                return TypeConverter<TRACredentialWrapper>.ConvertFrom_List_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<List<TRAClaim>>.GetConversionActionTo_TRACredentialWrapper()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialWrapper> ITypeConverter<List<TRAClaim>>.Enumerate_TRACredentialWrapper(List<TRAClaim> value)
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
            List<TRAKeyValuePair> ITypeConverter<List<TRAKeyValuePair>>.ConvertFrom_TRACredentialContent(TRACredentialContent value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialContent' to 'List<TRAKeyValuePair>'.");
                
            }
            TRACredentialContent ITypeConverter<List<TRAKeyValuePair>>.ConvertTo_TRACredentialContent(List<TRAKeyValuePair> value)
            {
                return TypeConverter<TRACredentialContent>.ConvertFrom_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<TRAKeyValuePair>>.GetConversionActionTo_TRACredentialContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialContent> ITypeConverter<List<TRAKeyValuePair>>.Enumerate_TRACredentialContent(List<TRAKeyValuePair> value)
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
            List<TRAKeyValuePair> ITypeConverter<List<TRAKeyValuePair>>.ConvertFrom_TRACredentialEnvelope(TRACredentialEnvelope value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialEnvelope' to 'List<TRAKeyValuePair>'.");
                
            }
            TRACredentialEnvelope ITypeConverter<List<TRAKeyValuePair>>.ConvertTo_TRACredentialEnvelope(List<TRAKeyValuePair> value)
            {
                return TypeConverter<TRACredentialEnvelope>.ConvertFrom_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<TRAKeyValuePair>>.GetConversionActionTo_TRACredentialEnvelope()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialEnvelope> ITypeConverter<List<TRAKeyValuePair>>.Enumerate_TRACredentialEnvelope(List<TRAKeyValuePair> value)
            {
                
                yield break;
            }
            List<TRAKeyValuePair> ITypeConverter<List<TRAKeyValuePair>>.ConvertFrom_TRACredentialWrapper(TRACredentialWrapper value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialWrapper' to 'List<TRAKeyValuePair>'.");
                
            }
            TRACredentialWrapper ITypeConverter<List<TRAKeyValuePair>>.ConvertTo_TRACredentialWrapper(List<TRAKeyValuePair> value)
            {
                return TypeConverter<TRACredentialWrapper>.ConvertFrom_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<TRAKeyValuePair>>.GetConversionActionTo_TRACredentialWrapper()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialWrapper> ITypeConverter<List<TRAKeyValuePair>>.Enumerate_TRACredentialWrapper(List<TRAKeyValuePair> value)
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
            TRAClaim ITypeConverter<TRAClaim>.ConvertFrom_TRACredentialContent(TRACredentialContent value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialContent' to 'TRAClaim'.");
                
            }
            TRACredentialContent ITypeConverter<TRAClaim>.ConvertTo_TRACredentialContent(TRAClaim value)
            {
                return TypeConverter<TRACredentialContent>.ConvertFrom_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<TRAClaim>.GetConversionActionTo_TRACredentialContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialContent> ITypeConverter<TRAClaim>.Enumerate_TRACredentialContent(TRAClaim value)
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
            TRAClaim ITypeConverter<TRAClaim>.ConvertFrom_TRACredentialEnvelope(TRACredentialEnvelope value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialEnvelope' to 'TRAClaim'.");
                
            }
            TRACredentialEnvelope ITypeConverter<TRAClaim>.ConvertTo_TRACredentialEnvelope(TRAClaim value)
            {
                return TypeConverter<TRACredentialEnvelope>.ConvertFrom_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<TRAClaim>.GetConversionActionTo_TRACredentialEnvelope()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialEnvelope> ITypeConverter<TRAClaim>.Enumerate_TRACredentialEnvelope(TRAClaim value)
            {
                
                yield break;
            }
            TRAClaim ITypeConverter<TRAClaim>.ConvertFrom_TRACredentialWrapper(TRACredentialWrapper value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialWrapper' to 'TRAClaim'.");
                
            }
            TRACredentialWrapper ITypeConverter<TRAClaim>.ConvertTo_TRACredentialWrapper(TRAClaim value)
            {
                return TypeConverter<TRACredentialWrapper>.ConvertFrom_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<TRAClaim>.GetConversionActionTo_TRACredentialWrapper()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialWrapper> ITypeConverter<TRAClaim>.Enumerate_TRACredentialWrapper(TRAClaim value)
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
            TRACredentialContent ITypeConverter<TRACredentialContent>.ConvertFrom_long(long value)
            {
                
                throw new InvalidCastException("Invalid cast from 'long' to 'TRACredentialContent'.");
                
            }
            long ITypeConverter<TRACredentialContent>.ConvertTo_long(TRACredentialContent value)
            {
                return TypeConverter<long>.ConvertFrom_TRACredentialContent(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialContent>.GetConversionActionTo_long()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long> ITypeConverter<TRACredentialContent>.Enumerate_long(TRACredentialContent value)
            {
                
                yield break;
            }
            TRACredentialContent ITypeConverter<TRACredentialContent>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    TRACredentialContent intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = TRACredentialContent.TryParse(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        Throw.cannot_parse(value, "TRACredentialContent");
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<TRACredentialContent>.ConvertTo_string(TRACredentialContent value)
            {
                return TypeConverter<string>.ConvertFrom_TRACredentialContent(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialContent>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<TRACredentialContent>.Enumerate_string(TRACredentialContent value)
            {
                
                yield break;
            }
            TRACredentialContent ITypeConverter<TRACredentialContent>.ConvertFrom_List_string(List<string> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<string>' to 'TRACredentialContent'.");
                
            }
            List<string> ITypeConverter<TRACredentialContent>.ConvertTo_List_string(TRACredentialContent value)
            {
                return TypeConverter<List<string>>.ConvertFrom_TRACredentialContent(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialContent>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_WRAPINLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<TRACredentialContent>.Enumerate_List_string(TRACredentialContent value)
            {
                
                yield break;
            }
            TRACredentialContent ITypeConverter<TRACredentialContent>.ConvertFrom_List_TRAClaim(List<TRAClaim> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<TRAClaim>' to 'TRACredentialContent'.");
                
            }
            List<TRAClaim> ITypeConverter<TRACredentialContent>.ConvertTo_List_TRAClaim(TRACredentialContent value)
            {
                return TypeConverter<List<TRAClaim>>.ConvertFrom_TRACredentialContent(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialContent>.GetConversionActionTo_List_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAClaim>> ITypeConverter<TRACredentialContent>.Enumerate_List_TRAClaim(TRACredentialContent value)
            {
                
                yield break;
            }
            TRACredentialContent ITypeConverter<TRACredentialContent>.ConvertFrom_List_TRAKeyValuePair(List<TRAKeyValuePair> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<TRAKeyValuePair>' to 'TRACredentialContent'.");
                
            }
            List<TRAKeyValuePair> ITypeConverter<TRACredentialContent>.ConvertTo_List_TRAKeyValuePair(TRACredentialContent value)
            {
                return TypeConverter<List<TRAKeyValuePair>>.ConvertFrom_TRACredentialContent(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialContent>.GetConversionActionTo_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAKeyValuePair>> ITypeConverter<TRACredentialContent>.Enumerate_List_TRAKeyValuePair(TRACredentialContent value)
            {
                
                yield break;
            }
            TRACredentialContent ITypeConverter<TRACredentialContent>.ConvertFrom_TRAClaim(TRAClaim value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAClaim' to 'TRACredentialContent'.");
                
            }
            TRAClaim ITypeConverter<TRACredentialContent>.ConvertTo_TRAClaim(TRACredentialContent value)
            {
                return TypeConverter<TRAClaim>.ConvertFrom_TRACredentialContent(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialContent>.GetConversionActionTo_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAClaim> ITypeConverter<TRACredentialContent>.Enumerate_TRAClaim(TRACredentialContent value)
            {
                
                yield break;
            }
            TRACredentialContent ITypeConverter<TRACredentialContent>.ConvertFrom_TRACredentialContent(TRACredentialContent value)
            {
                
                return (TRACredentialContent)value;
                
            }
            TRACredentialContent ITypeConverter<TRACredentialContent>.ConvertTo_TRACredentialContent(TRACredentialContent value)
            {
                return TypeConverter<TRACredentialContent>.ConvertFrom_TRACredentialContent(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialContent>.GetConversionActionTo_TRACredentialContent()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialContent> ITypeConverter<TRACredentialContent>.Enumerate_TRACredentialContent(TRACredentialContent value)
            {
                
                yield break;
            }
            TRACredentialContent ITypeConverter<TRACredentialContent>.ConvertFrom_TRACredentialCore(TRACredentialCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialCore' to 'TRACredentialContent'.");
                
            }
            TRACredentialCore ITypeConverter<TRACredentialContent>.ConvertTo_TRACredentialCore(TRACredentialContent value)
            {
                return TypeConverter<TRACredentialCore>.ConvertFrom_TRACredentialContent(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialContent>.GetConversionActionTo_TRACredentialCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialCore> ITypeConverter<TRACredentialContent>.Enumerate_TRACredentialCore(TRACredentialContent value)
            {
                
                yield break;
            }
            TRACredentialContent ITypeConverter<TRACredentialContent>.ConvertFrom_TRACredentialEnvelope(TRACredentialEnvelope value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialEnvelope' to 'TRACredentialContent'.");
                
            }
            TRACredentialEnvelope ITypeConverter<TRACredentialContent>.ConvertTo_TRACredentialEnvelope(TRACredentialContent value)
            {
                return TypeConverter<TRACredentialEnvelope>.ConvertFrom_TRACredentialContent(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialContent>.GetConversionActionTo_TRACredentialEnvelope()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialEnvelope> ITypeConverter<TRACredentialContent>.Enumerate_TRACredentialEnvelope(TRACredentialContent value)
            {
                
                yield break;
            }
            TRACredentialContent ITypeConverter<TRACredentialContent>.ConvertFrom_TRACredentialWrapper(TRACredentialWrapper value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialWrapper' to 'TRACredentialContent'.");
                
            }
            TRACredentialWrapper ITypeConverter<TRACredentialContent>.ConvertTo_TRACredentialWrapper(TRACredentialContent value)
            {
                return TypeConverter<TRACredentialWrapper>.ConvertFrom_TRACredentialContent(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialContent>.GetConversionActionTo_TRACredentialWrapper()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialWrapper> ITypeConverter<TRACredentialContent>.Enumerate_TRACredentialWrapper(TRACredentialContent value)
            {
                
                yield break;
            }
            TRACredentialContent ITypeConverter<TRACredentialContent>.ConvertFrom_TRAKeyValuePair(TRAKeyValuePair value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAKeyValuePair' to 'TRACredentialContent'.");
                
            }
            TRAKeyValuePair ITypeConverter<TRACredentialContent>.ConvertTo_TRAKeyValuePair(TRACredentialContent value)
            {
                return TypeConverter<TRAKeyValuePair>.ConvertFrom_TRACredentialContent(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialContent>.GetConversionActionTo_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAKeyValuePair> ITypeConverter<TRACredentialContent>.Enumerate_TRAKeyValuePair(TRACredentialContent value)
            {
                
                yield break;
            }
            TRACredentialContent ITypeConverter<TRACredentialContent>.ConvertFrom_TRACredentialType(TRACredentialType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialType' to 'TRACredentialContent'.");
                
            }
            TRACredentialType ITypeConverter<TRACredentialContent>.ConvertTo_TRACredentialType(TRACredentialContent value)
            {
                return TypeConverter<TRACredentialType>.ConvertFrom_TRACredentialContent(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialContent>.GetConversionActionTo_TRACredentialType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialType> ITypeConverter<TRACredentialContent>.Enumerate_TRACredentialType(TRACredentialContent value)
            {
                
                yield break;
            }
            TRACredentialContent ITypeConverter<TRACredentialContent>.ConvertFrom_TRAEncryptionFlag(TRAEncryptionFlag value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAEncryptionFlag' to 'TRACredentialContent'.");
                
            }
            TRAEncryptionFlag ITypeConverter<TRACredentialContent>.ConvertTo_TRAEncryptionFlag(TRACredentialContent value)
            {
                return TypeConverter<TRAEncryptionFlag>.ConvertFrom_TRACredentialContent(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialContent>.GetConversionActionTo_TRAEncryptionFlag()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEncryptionFlag> ITypeConverter<TRACredentialContent>.Enumerate_TRAEncryptionFlag(TRACredentialContent value)
            {
                
                yield break;
            }
            TRACredentialContent ITypeConverter<TRACredentialContent>.ConvertFrom_TRATrustLevel(TRATrustLevel value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRATrustLevel' to 'TRACredentialContent'.");
                
            }
            TRATrustLevel ITypeConverter<TRACredentialContent>.ConvertTo_TRATrustLevel(TRACredentialContent value)
            {
                return TypeConverter<TRATrustLevel>.ConvertFrom_TRACredentialContent(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialContent>.GetConversionActionTo_TRATrustLevel()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRATrustLevel> ITypeConverter<TRACredentialContent>.Enumerate_TRATrustLevel(TRACredentialContent value)
            {
                
                yield break;
            }
            TRACredentialContent ITypeConverter<TRACredentialContent>.ConvertFrom_List_List_TRAKeyValuePair(List<List<TRAKeyValuePair>> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<List<TRAKeyValuePair>>' to 'TRACredentialContent'.");
                
            }
            List<List<TRAKeyValuePair>> ITypeConverter<TRACredentialContent>.ConvertTo_List_List_TRAKeyValuePair(TRACredentialContent value)
            {
                return TypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_TRACredentialContent(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialContent>.GetConversionActionTo_List_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<List<TRAKeyValuePair>>> ITypeConverter<TRACredentialContent>.Enumerate_List_List_TRAKeyValuePair(TRACredentialContent value)
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
            TRACredentialCore ITypeConverter<TRACredentialCore>.ConvertFrom_TRACredentialContent(TRACredentialContent value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialContent' to 'TRACredentialCore'.");
                
            }
            TRACredentialContent ITypeConverter<TRACredentialCore>.ConvertTo_TRACredentialContent(TRACredentialCore value)
            {
                return TypeConverter<TRACredentialContent>.ConvertFrom_TRACredentialCore(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialCore>.GetConversionActionTo_TRACredentialContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialContent> ITypeConverter<TRACredentialCore>.Enumerate_TRACredentialContent(TRACredentialCore value)
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
            TRACredentialCore ITypeConverter<TRACredentialCore>.ConvertFrom_TRACredentialEnvelope(TRACredentialEnvelope value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialEnvelope' to 'TRACredentialCore'.");
                
            }
            TRACredentialEnvelope ITypeConverter<TRACredentialCore>.ConvertTo_TRACredentialEnvelope(TRACredentialCore value)
            {
                return TypeConverter<TRACredentialEnvelope>.ConvertFrom_TRACredentialCore(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialCore>.GetConversionActionTo_TRACredentialEnvelope()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialEnvelope> ITypeConverter<TRACredentialCore>.Enumerate_TRACredentialEnvelope(TRACredentialCore value)
            {
                
                yield break;
            }
            TRACredentialCore ITypeConverter<TRACredentialCore>.ConvertFrom_TRACredentialWrapper(TRACredentialWrapper value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialWrapper' to 'TRACredentialCore'.");
                
            }
            TRACredentialWrapper ITypeConverter<TRACredentialCore>.ConvertTo_TRACredentialWrapper(TRACredentialCore value)
            {
                return TypeConverter<TRACredentialWrapper>.ConvertFrom_TRACredentialCore(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialCore>.GetConversionActionTo_TRACredentialWrapper()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialWrapper> ITypeConverter<TRACredentialCore>.Enumerate_TRACredentialWrapper(TRACredentialCore value)
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
            TRACredentialEnvelope ITypeConverter<TRACredentialEnvelope>.ConvertFrom_long(long value)
            {
                
                throw new InvalidCastException("Invalid cast from 'long' to 'TRACredentialEnvelope'.");
                
            }
            long ITypeConverter<TRACredentialEnvelope>.ConvertTo_long(TRACredentialEnvelope value)
            {
                return TypeConverter<long>.ConvertFrom_TRACredentialEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialEnvelope>.GetConversionActionTo_long()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long> ITypeConverter<TRACredentialEnvelope>.Enumerate_long(TRACredentialEnvelope value)
            {
                
                yield break;
            }
            TRACredentialEnvelope ITypeConverter<TRACredentialEnvelope>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    TRACredentialEnvelope intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = TRACredentialEnvelope.TryParse(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        Throw.cannot_parse(value, "TRACredentialEnvelope");
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<TRACredentialEnvelope>.ConvertTo_string(TRACredentialEnvelope value)
            {
                return TypeConverter<string>.ConvertFrom_TRACredentialEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialEnvelope>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<TRACredentialEnvelope>.Enumerate_string(TRACredentialEnvelope value)
            {
                
                yield break;
            }
            TRACredentialEnvelope ITypeConverter<TRACredentialEnvelope>.ConvertFrom_List_string(List<string> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<string>' to 'TRACredentialEnvelope'.");
                
            }
            List<string> ITypeConverter<TRACredentialEnvelope>.ConvertTo_List_string(TRACredentialEnvelope value)
            {
                return TypeConverter<List<string>>.ConvertFrom_TRACredentialEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialEnvelope>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_WRAPINLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<TRACredentialEnvelope>.Enumerate_List_string(TRACredentialEnvelope value)
            {
                
                yield break;
            }
            TRACredentialEnvelope ITypeConverter<TRACredentialEnvelope>.ConvertFrom_List_TRAClaim(List<TRAClaim> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<TRAClaim>' to 'TRACredentialEnvelope'.");
                
            }
            List<TRAClaim> ITypeConverter<TRACredentialEnvelope>.ConvertTo_List_TRAClaim(TRACredentialEnvelope value)
            {
                return TypeConverter<List<TRAClaim>>.ConvertFrom_TRACredentialEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialEnvelope>.GetConversionActionTo_List_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAClaim>> ITypeConverter<TRACredentialEnvelope>.Enumerate_List_TRAClaim(TRACredentialEnvelope value)
            {
                
                yield break;
            }
            TRACredentialEnvelope ITypeConverter<TRACredentialEnvelope>.ConvertFrom_List_TRAKeyValuePair(List<TRAKeyValuePair> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<TRAKeyValuePair>' to 'TRACredentialEnvelope'.");
                
            }
            List<TRAKeyValuePair> ITypeConverter<TRACredentialEnvelope>.ConvertTo_List_TRAKeyValuePair(TRACredentialEnvelope value)
            {
                return TypeConverter<List<TRAKeyValuePair>>.ConvertFrom_TRACredentialEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialEnvelope>.GetConversionActionTo_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAKeyValuePair>> ITypeConverter<TRACredentialEnvelope>.Enumerate_List_TRAKeyValuePair(TRACredentialEnvelope value)
            {
                
                yield break;
            }
            TRACredentialEnvelope ITypeConverter<TRACredentialEnvelope>.ConvertFrom_TRAClaim(TRAClaim value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAClaim' to 'TRACredentialEnvelope'.");
                
            }
            TRAClaim ITypeConverter<TRACredentialEnvelope>.ConvertTo_TRAClaim(TRACredentialEnvelope value)
            {
                return TypeConverter<TRAClaim>.ConvertFrom_TRACredentialEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialEnvelope>.GetConversionActionTo_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAClaim> ITypeConverter<TRACredentialEnvelope>.Enumerate_TRAClaim(TRACredentialEnvelope value)
            {
                
                yield break;
            }
            TRACredentialEnvelope ITypeConverter<TRACredentialEnvelope>.ConvertFrom_TRACredentialContent(TRACredentialContent value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialContent' to 'TRACredentialEnvelope'.");
                
            }
            TRACredentialContent ITypeConverter<TRACredentialEnvelope>.ConvertTo_TRACredentialContent(TRACredentialEnvelope value)
            {
                return TypeConverter<TRACredentialContent>.ConvertFrom_TRACredentialEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialEnvelope>.GetConversionActionTo_TRACredentialContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialContent> ITypeConverter<TRACredentialEnvelope>.Enumerate_TRACredentialContent(TRACredentialEnvelope value)
            {
                
                yield break;
            }
            TRACredentialEnvelope ITypeConverter<TRACredentialEnvelope>.ConvertFrom_TRACredentialCore(TRACredentialCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialCore' to 'TRACredentialEnvelope'.");
                
            }
            TRACredentialCore ITypeConverter<TRACredentialEnvelope>.ConvertTo_TRACredentialCore(TRACredentialEnvelope value)
            {
                return TypeConverter<TRACredentialCore>.ConvertFrom_TRACredentialEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialEnvelope>.GetConversionActionTo_TRACredentialCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialCore> ITypeConverter<TRACredentialEnvelope>.Enumerate_TRACredentialCore(TRACredentialEnvelope value)
            {
                
                yield break;
            }
            TRACredentialEnvelope ITypeConverter<TRACredentialEnvelope>.ConvertFrom_TRACredentialEnvelope(TRACredentialEnvelope value)
            {
                
                return (TRACredentialEnvelope)value;
                
            }
            TRACredentialEnvelope ITypeConverter<TRACredentialEnvelope>.ConvertTo_TRACredentialEnvelope(TRACredentialEnvelope value)
            {
                return TypeConverter<TRACredentialEnvelope>.ConvertFrom_TRACredentialEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialEnvelope>.GetConversionActionTo_TRACredentialEnvelope()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialEnvelope> ITypeConverter<TRACredentialEnvelope>.Enumerate_TRACredentialEnvelope(TRACredentialEnvelope value)
            {
                
                yield break;
            }
            TRACredentialEnvelope ITypeConverter<TRACredentialEnvelope>.ConvertFrom_TRACredentialWrapper(TRACredentialWrapper value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialWrapper' to 'TRACredentialEnvelope'.");
                
            }
            TRACredentialWrapper ITypeConverter<TRACredentialEnvelope>.ConvertTo_TRACredentialWrapper(TRACredentialEnvelope value)
            {
                return TypeConverter<TRACredentialWrapper>.ConvertFrom_TRACredentialEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialEnvelope>.GetConversionActionTo_TRACredentialWrapper()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialWrapper> ITypeConverter<TRACredentialEnvelope>.Enumerate_TRACredentialWrapper(TRACredentialEnvelope value)
            {
                
                yield break;
            }
            TRACredentialEnvelope ITypeConverter<TRACredentialEnvelope>.ConvertFrom_TRAKeyValuePair(TRAKeyValuePair value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAKeyValuePair' to 'TRACredentialEnvelope'.");
                
            }
            TRAKeyValuePair ITypeConverter<TRACredentialEnvelope>.ConvertTo_TRAKeyValuePair(TRACredentialEnvelope value)
            {
                return TypeConverter<TRAKeyValuePair>.ConvertFrom_TRACredentialEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialEnvelope>.GetConversionActionTo_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAKeyValuePair> ITypeConverter<TRACredentialEnvelope>.Enumerate_TRAKeyValuePair(TRACredentialEnvelope value)
            {
                
                yield break;
            }
            TRACredentialEnvelope ITypeConverter<TRACredentialEnvelope>.ConvertFrom_TRACredentialType(TRACredentialType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialType' to 'TRACredentialEnvelope'.");
                
            }
            TRACredentialType ITypeConverter<TRACredentialEnvelope>.ConvertTo_TRACredentialType(TRACredentialEnvelope value)
            {
                return TypeConverter<TRACredentialType>.ConvertFrom_TRACredentialEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialEnvelope>.GetConversionActionTo_TRACredentialType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialType> ITypeConverter<TRACredentialEnvelope>.Enumerate_TRACredentialType(TRACredentialEnvelope value)
            {
                
                yield break;
            }
            TRACredentialEnvelope ITypeConverter<TRACredentialEnvelope>.ConvertFrom_TRAEncryptionFlag(TRAEncryptionFlag value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAEncryptionFlag' to 'TRACredentialEnvelope'.");
                
            }
            TRAEncryptionFlag ITypeConverter<TRACredentialEnvelope>.ConvertTo_TRAEncryptionFlag(TRACredentialEnvelope value)
            {
                return TypeConverter<TRAEncryptionFlag>.ConvertFrom_TRACredentialEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialEnvelope>.GetConversionActionTo_TRAEncryptionFlag()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEncryptionFlag> ITypeConverter<TRACredentialEnvelope>.Enumerate_TRAEncryptionFlag(TRACredentialEnvelope value)
            {
                
                yield break;
            }
            TRACredentialEnvelope ITypeConverter<TRACredentialEnvelope>.ConvertFrom_TRATrustLevel(TRATrustLevel value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRATrustLevel' to 'TRACredentialEnvelope'.");
                
            }
            TRATrustLevel ITypeConverter<TRACredentialEnvelope>.ConvertTo_TRATrustLevel(TRACredentialEnvelope value)
            {
                return TypeConverter<TRATrustLevel>.ConvertFrom_TRACredentialEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialEnvelope>.GetConversionActionTo_TRATrustLevel()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRATrustLevel> ITypeConverter<TRACredentialEnvelope>.Enumerate_TRATrustLevel(TRACredentialEnvelope value)
            {
                
                yield break;
            }
            TRACredentialEnvelope ITypeConverter<TRACredentialEnvelope>.ConvertFrom_List_List_TRAKeyValuePair(List<List<TRAKeyValuePair>> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<List<TRAKeyValuePair>>' to 'TRACredentialEnvelope'.");
                
            }
            List<List<TRAKeyValuePair>> ITypeConverter<TRACredentialEnvelope>.ConvertTo_List_List_TRAKeyValuePair(TRACredentialEnvelope value)
            {
                return TypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_TRACredentialEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialEnvelope>.GetConversionActionTo_List_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<List<TRAKeyValuePair>>> ITypeConverter<TRACredentialEnvelope>.Enumerate_List_List_TRAKeyValuePair(TRACredentialEnvelope value)
            {
                
                yield break;
            }
            TRACredentialWrapper ITypeConverter<TRACredentialWrapper>.ConvertFrom_long(long value)
            {
                
                throw new InvalidCastException("Invalid cast from 'long' to 'TRACredentialWrapper'.");
                
            }
            long ITypeConverter<TRACredentialWrapper>.ConvertTo_long(TRACredentialWrapper value)
            {
                return TypeConverter<long>.ConvertFrom_TRACredentialWrapper(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialWrapper>.GetConversionActionTo_long()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long> ITypeConverter<TRACredentialWrapper>.Enumerate_long(TRACredentialWrapper value)
            {
                
                yield break;
            }
            TRACredentialWrapper ITypeConverter<TRACredentialWrapper>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    TRACredentialWrapper intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = TRACredentialWrapper.TryParse(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        Throw.cannot_parse(value, "TRACredentialWrapper");
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<TRACredentialWrapper>.ConvertTo_string(TRACredentialWrapper value)
            {
                return TypeConverter<string>.ConvertFrom_TRACredentialWrapper(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialWrapper>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<TRACredentialWrapper>.Enumerate_string(TRACredentialWrapper value)
            {
                
                yield break;
            }
            TRACredentialWrapper ITypeConverter<TRACredentialWrapper>.ConvertFrom_List_string(List<string> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<string>' to 'TRACredentialWrapper'.");
                
            }
            List<string> ITypeConverter<TRACredentialWrapper>.ConvertTo_List_string(TRACredentialWrapper value)
            {
                return TypeConverter<List<string>>.ConvertFrom_TRACredentialWrapper(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialWrapper>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_WRAPINLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<TRACredentialWrapper>.Enumerate_List_string(TRACredentialWrapper value)
            {
                
                yield break;
            }
            TRACredentialWrapper ITypeConverter<TRACredentialWrapper>.ConvertFrom_List_TRAClaim(List<TRAClaim> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<TRAClaim>' to 'TRACredentialWrapper'.");
                
            }
            List<TRAClaim> ITypeConverter<TRACredentialWrapper>.ConvertTo_List_TRAClaim(TRACredentialWrapper value)
            {
                return TypeConverter<List<TRAClaim>>.ConvertFrom_TRACredentialWrapper(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialWrapper>.GetConversionActionTo_List_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAClaim>> ITypeConverter<TRACredentialWrapper>.Enumerate_List_TRAClaim(TRACredentialWrapper value)
            {
                
                yield break;
            }
            TRACredentialWrapper ITypeConverter<TRACredentialWrapper>.ConvertFrom_List_TRAKeyValuePair(List<TRAKeyValuePair> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<TRAKeyValuePair>' to 'TRACredentialWrapper'.");
                
            }
            List<TRAKeyValuePair> ITypeConverter<TRACredentialWrapper>.ConvertTo_List_TRAKeyValuePair(TRACredentialWrapper value)
            {
                return TypeConverter<List<TRAKeyValuePair>>.ConvertFrom_TRACredentialWrapper(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialWrapper>.GetConversionActionTo_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAKeyValuePair>> ITypeConverter<TRACredentialWrapper>.Enumerate_List_TRAKeyValuePair(TRACredentialWrapper value)
            {
                
                yield break;
            }
            TRACredentialWrapper ITypeConverter<TRACredentialWrapper>.ConvertFrom_TRAClaim(TRAClaim value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAClaim' to 'TRACredentialWrapper'.");
                
            }
            TRAClaim ITypeConverter<TRACredentialWrapper>.ConvertTo_TRAClaim(TRACredentialWrapper value)
            {
                return TypeConverter<TRAClaim>.ConvertFrom_TRACredentialWrapper(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialWrapper>.GetConversionActionTo_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAClaim> ITypeConverter<TRACredentialWrapper>.Enumerate_TRAClaim(TRACredentialWrapper value)
            {
                
                yield break;
            }
            TRACredentialWrapper ITypeConverter<TRACredentialWrapper>.ConvertFrom_TRACredentialContent(TRACredentialContent value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialContent' to 'TRACredentialWrapper'.");
                
            }
            TRACredentialContent ITypeConverter<TRACredentialWrapper>.ConvertTo_TRACredentialContent(TRACredentialWrapper value)
            {
                return TypeConverter<TRACredentialContent>.ConvertFrom_TRACredentialWrapper(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialWrapper>.GetConversionActionTo_TRACredentialContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialContent> ITypeConverter<TRACredentialWrapper>.Enumerate_TRACredentialContent(TRACredentialWrapper value)
            {
                
                yield break;
            }
            TRACredentialWrapper ITypeConverter<TRACredentialWrapper>.ConvertFrom_TRACredentialCore(TRACredentialCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialCore' to 'TRACredentialWrapper'.");
                
            }
            TRACredentialCore ITypeConverter<TRACredentialWrapper>.ConvertTo_TRACredentialCore(TRACredentialWrapper value)
            {
                return TypeConverter<TRACredentialCore>.ConvertFrom_TRACredentialWrapper(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialWrapper>.GetConversionActionTo_TRACredentialCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialCore> ITypeConverter<TRACredentialWrapper>.Enumerate_TRACredentialCore(TRACredentialWrapper value)
            {
                
                yield break;
            }
            TRACredentialWrapper ITypeConverter<TRACredentialWrapper>.ConvertFrom_TRACredentialEnvelope(TRACredentialEnvelope value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialEnvelope' to 'TRACredentialWrapper'.");
                
            }
            TRACredentialEnvelope ITypeConverter<TRACredentialWrapper>.ConvertTo_TRACredentialEnvelope(TRACredentialWrapper value)
            {
                return TypeConverter<TRACredentialEnvelope>.ConvertFrom_TRACredentialWrapper(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialWrapper>.GetConversionActionTo_TRACredentialEnvelope()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialEnvelope> ITypeConverter<TRACredentialWrapper>.Enumerate_TRACredentialEnvelope(TRACredentialWrapper value)
            {
                
                yield break;
            }
            TRACredentialWrapper ITypeConverter<TRACredentialWrapper>.ConvertFrom_TRACredentialWrapper(TRACredentialWrapper value)
            {
                
                return (TRACredentialWrapper)value;
                
            }
            TRACredentialWrapper ITypeConverter<TRACredentialWrapper>.ConvertTo_TRACredentialWrapper(TRACredentialWrapper value)
            {
                return TypeConverter<TRACredentialWrapper>.ConvertFrom_TRACredentialWrapper(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialWrapper>.GetConversionActionTo_TRACredentialWrapper()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialWrapper> ITypeConverter<TRACredentialWrapper>.Enumerate_TRACredentialWrapper(TRACredentialWrapper value)
            {
                
                yield break;
            }
            TRACredentialWrapper ITypeConverter<TRACredentialWrapper>.ConvertFrom_TRAKeyValuePair(TRAKeyValuePair value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAKeyValuePair' to 'TRACredentialWrapper'.");
                
            }
            TRAKeyValuePair ITypeConverter<TRACredentialWrapper>.ConvertTo_TRAKeyValuePair(TRACredentialWrapper value)
            {
                return TypeConverter<TRAKeyValuePair>.ConvertFrom_TRACredentialWrapper(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialWrapper>.GetConversionActionTo_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAKeyValuePair> ITypeConverter<TRACredentialWrapper>.Enumerate_TRAKeyValuePair(TRACredentialWrapper value)
            {
                
                yield break;
            }
            TRACredentialWrapper ITypeConverter<TRACredentialWrapper>.ConvertFrom_TRACredentialType(TRACredentialType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialType' to 'TRACredentialWrapper'.");
                
            }
            TRACredentialType ITypeConverter<TRACredentialWrapper>.ConvertTo_TRACredentialType(TRACredentialWrapper value)
            {
                return TypeConverter<TRACredentialType>.ConvertFrom_TRACredentialWrapper(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialWrapper>.GetConversionActionTo_TRACredentialType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialType> ITypeConverter<TRACredentialWrapper>.Enumerate_TRACredentialType(TRACredentialWrapper value)
            {
                
                yield break;
            }
            TRACredentialWrapper ITypeConverter<TRACredentialWrapper>.ConvertFrom_TRAEncryptionFlag(TRAEncryptionFlag value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAEncryptionFlag' to 'TRACredentialWrapper'.");
                
            }
            TRAEncryptionFlag ITypeConverter<TRACredentialWrapper>.ConvertTo_TRAEncryptionFlag(TRACredentialWrapper value)
            {
                return TypeConverter<TRAEncryptionFlag>.ConvertFrom_TRACredentialWrapper(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialWrapper>.GetConversionActionTo_TRAEncryptionFlag()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEncryptionFlag> ITypeConverter<TRACredentialWrapper>.Enumerate_TRAEncryptionFlag(TRACredentialWrapper value)
            {
                
                yield break;
            }
            TRACredentialWrapper ITypeConverter<TRACredentialWrapper>.ConvertFrom_TRATrustLevel(TRATrustLevel value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRATrustLevel' to 'TRACredentialWrapper'.");
                
            }
            TRATrustLevel ITypeConverter<TRACredentialWrapper>.ConvertTo_TRATrustLevel(TRACredentialWrapper value)
            {
                return TypeConverter<TRATrustLevel>.ConvertFrom_TRACredentialWrapper(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialWrapper>.GetConversionActionTo_TRATrustLevel()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRATrustLevel> ITypeConverter<TRACredentialWrapper>.Enumerate_TRATrustLevel(TRACredentialWrapper value)
            {
                
                yield break;
            }
            TRACredentialWrapper ITypeConverter<TRACredentialWrapper>.ConvertFrom_List_List_TRAKeyValuePair(List<List<TRAKeyValuePair>> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<List<TRAKeyValuePair>>' to 'TRACredentialWrapper'.");
                
            }
            List<List<TRAKeyValuePair>> ITypeConverter<TRACredentialWrapper>.ConvertTo_List_List_TRAKeyValuePair(TRACredentialWrapper value)
            {
                return TypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_TRACredentialWrapper(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialWrapper>.GetConversionActionTo_List_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<List<TRAKeyValuePair>>> ITypeConverter<TRACredentialWrapper>.Enumerate_List_List_TRAKeyValuePair(TRACredentialWrapper value)
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
            TRAKeyValuePair ITypeConverter<TRAKeyValuePair>.ConvertFrom_TRACredentialContent(TRACredentialContent value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialContent' to 'TRAKeyValuePair'.");
                
            }
            TRACredentialContent ITypeConverter<TRAKeyValuePair>.ConvertTo_TRACredentialContent(TRAKeyValuePair value)
            {
                return TypeConverter<TRACredentialContent>.ConvertFrom_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<TRAKeyValuePair>.GetConversionActionTo_TRACredentialContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialContent> ITypeConverter<TRAKeyValuePair>.Enumerate_TRACredentialContent(TRAKeyValuePair value)
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
            TRAKeyValuePair ITypeConverter<TRAKeyValuePair>.ConvertFrom_TRACredentialEnvelope(TRACredentialEnvelope value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialEnvelope' to 'TRAKeyValuePair'.");
                
            }
            TRACredentialEnvelope ITypeConverter<TRAKeyValuePair>.ConvertTo_TRACredentialEnvelope(TRAKeyValuePair value)
            {
                return TypeConverter<TRACredentialEnvelope>.ConvertFrom_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<TRAKeyValuePair>.GetConversionActionTo_TRACredentialEnvelope()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialEnvelope> ITypeConverter<TRAKeyValuePair>.Enumerate_TRACredentialEnvelope(TRAKeyValuePair value)
            {
                
                yield break;
            }
            TRAKeyValuePair ITypeConverter<TRAKeyValuePair>.ConvertFrom_TRACredentialWrapper(TRACredentialWrapper value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialWrapper' to 'TRAKeyValuePair'.");
                
            }
            TRACredentialWrapper ITypeConverter<TRAKeyValuePair>.ConvertTo_TRACredentialWrapper(TRAKeyValuePair value)
            {
                return TypeConverter<TRACredentialWrapper>.ConvertFrom_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<TRAKeyValuePair>.GetConversionActionTo_TRACredentialWrapper()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialWrapper> ITypeConverter<TRAKeyValuePair>.Enumerate_TRACredentialWrapper(TRAKeyValuePair value)
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
            TRACredentialType ITypeConverter<TRACredentialType>.ConvertFrom_TRACredentialContent(TRACredentialContent value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialContent' to 'TRACredentialType'.");
                
            }
            TRACredentialContent ITypeConverter<TRACredentialType>.ConvertTo_TRACredentialContent(TRACredentialType value)
            {
                return TypeConverter<TRACredentialContent>.ConvertFrom_TRACredentialType(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialType>.GetConversionActionTo_TRACredentialContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialContent> ITypeConverter<TRACredentialType>.Enumerate_TRACredentialContent(TRACredentialType value)
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
            TRACredentialType ITypeConverter<TRACredentialType>.ConvertFrom_TRACredentialEnvelope(TRACredentialEnvelope value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialEnvelope' to 'TRACredentialType'.");
                
            }
            TRACredentialEnvelope ITypeConverter<TRACredentialType>.ConvertTo_TRACredentialEnvelope(TRACredentialType value)
            {
                return TypeConverter<TRACredentialEnvelope>.ConvertFrom_TRACredentialType(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialType>.GetConversionActionTo_TRACredentialEnvelope()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialEnvelope> ITypeConverter<TRACredentialType>.Enumerate_TRACredentialEnvelope(TRACredentialType value)
            {
                
                yield break;
            }
            TRACredentialType ITypeConverter<TRACredentialType>.ConvertFrom_TRACredentialWrapper(TRACredentialWrapper value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialWrapper' to 'TRACredentialType'.");
                
            }
            TRACredentialWrapper ITypeConverter<TRACredentialType>.ConvertTo_TRACredentialWrapper(TRACredentialType value)
            {
                return TypeConverter<TRACredentialWrapper>.ConvertFrom_TRACredentialType(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialType>.GetConversionActionTo_TRACredentialWrapper()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialWrapper> ITypeConverter<TRACredentialType>.Enumerate_TRACredentialWrapper(TRACredentialType value)
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
            TRAEncryptionFlag ITypeConverter<TRAEncryptionFlag>.ConvertFrom_TRACredentialContent(TRACredentialContent value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialContent' to 'TRAEncryptionFlag'.");
                
            }
            TRACredentialContent ITypeConverter<TRAEncryptionFlag>.ConvertTo_TRACredentialContent(TRAEncryptionFlag value)
            {
                return TypeConverter<TRACredentialContent>.ConvertFrom_TRAEncryptionFlag(value);
            }
            TypeConversionAction ITypeConverter<TRAEncryptionFlag>.GetConversionActionTo_TRACredentialContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialContent> ITypeConverter<TRAEncryptionFlag>.Enumerate_TRACredentialContent(TRAEncryptionFlag value)
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
            TRAEncryptionFlag ITypeConverter<TRAEncryptionFlag>.ConvertFrom_TRACredentialEnvelope(TRACredentialEnvelope value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialEnvelope' to 'TRAEncryptionFlag'.");
                
            }
            TRACredentialEnvelope ITypeConverter<TRAEncryptionFlag>.ConvertTo_TRACredentialEnvelope(TRAEncryptionFlag value)
            {
                return TypeConverter<TRACredentialEnvelope>.ConvertFrom_TRAEncryptionFlag(value);
            }
            TypeConversionAction ITypeConverter<TRAEncryptionFlag>.GetConversionActionTo_TRACredentialEnvelope()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialEnvelope> ITypeConverter<TRAEncryptionFlag>.Enumerate_TRACredentialEnvelope(TRAEncryptionFlag value)
            {
                
                yield break;
            }
            TRAEncryptionFlag ITypeConverter<TRAEncryptionFlag>.ConvertFrom_TRACredentialWrapper(TRACredentialWrapper value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialWrapper' to 'TRAEncryptionFlag'.");
                
            }
            TRACredentialWrapper ITypeConverter<TRAEncryptionFlag>.ConvertTo_TRACredentialWrapper(TRAEncryptionFlag value)
            {
                return TypeConverter<TRACredentialWrapper>.ConvertFrom_TRAEncryptionFlag(value);
            }
            TypeConversionAction ITypeConverter<TRAEncryptionFlag>.GetConversionActionTo_TRACredentialWrapper()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialWrapper> ITypeConverter<TRAEncryptionFlag>.Enumerate_TRACredentialWrapper(TRAEncryptionFlag value)
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
            TRATrustLevel ITypeConverter<TRATrustLevel>.ConvertFrom_TRACredentialContent(TRACredentialContent value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialContent' to 'TRATrustLevel'.");
                
            }
            TRACredentialContent ITypeConverter<TRATrustLevel>.ConvertTo_TRACredentialContent(TRATrustLevel value)
            {
                return TypeConverter<TRACredentialContent>.ConvertFrom_TRATrustLevel(value);
            }
            TypeConversionAction ITypeConverter<TRATrustLevel>.GetConversionActionTo_TRACredentialContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialContent> ITypeConverter<TRATrustLevel>.Enumerate_TRACredentialContent(TRATrustLevel value)
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
            TRATrustLevel ITypeConverter<TRATrustLevel>.ConvertFrom_TRACredentialEnvelope(TRACredentialEnvelope value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialEnvelope' to 'TRATrustLevel'.");
                
            }
            TRACredentialEnvelope ITypeConverter<TRATrustLevel>.ConvertTo_TRACredentialEnvelope(TRATrustLevel value)
            {
                return TypeConverter<TRACredentialEnvelope>.ConvertFrom_TRATrustLevel(value);
            }
            TypeConversionAction ITypeConverter<TRATrustLevel>.GetConversionActionTo_TRACredentialEnvelope()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialEnvelope> ITypeConverter<TRATrustLevel>.Enumerate_TRACredentialEnvelope(TRATrustLevel value)
            {
                
                yield break;
            }
            TRATrustLevel ITypeConverter<TRATrustLevel>.ConvertFrom_TRACredentialWrapper(TRACredentialWrapper value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialWrapper' to 'TRATrustLevel'.");
                
            }
            TRACredentialWrapper ITypeConverter<TRATrustLevel>.ConvertTo_TRACredentialWrapper(TRATrustLevel value)
            {
                return TypeConverter<TRACredentialWrapper>.ConvertFrom_TRATrustLevel(value);
            }
            TypeConversionAction ITypeConverter<TRATrustLevel>.GetConversionActionTo_TRACredentialWrapper()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialWrapper> ITypeConverter<TRATrustLevel>.Enumerate_TRACredentialWrapper(TRATrustLevel value)
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
            List<List<TRAKeyValuePair>> ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_TRACredentialContent(TRACredentialContent value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialContent' to 'List<List<TRAKeyValuePair>>'.");
                
            }
            TRACredentialContent ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertTo_TRACredentialContent(List<List<TRAKeyValuePair>> value)
            {
                return TypeConverter<TRACredentialContent>.ConvertFrom_List_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<List<TRAKeyValuePair>>>.GetConversionActionTo_TRACredentialContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialContent> ITypeConverter<List<List<TRAKeyValuePair>>>.Enumerate_TRACredentialContent(List<List<TRAKeyValuePair>> value)
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
            List<List<TRAKeyValuePair>> ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_TRACredentialEnvelope(TRACredentialEnvelope value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialEnvelope' to 'List<List<TRAKeyValuePair>>'.");
                
            }
            TRACredentialEnvelope ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertTo_TRACredentialEnvelope(List<List<TRAKeyValuePair>> value)
            {
                return TypeConverter<TRACredentialEnvelope>.ConvertFrom_List_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<List<TRAKeyValuePair>>>.GetConversionActionTo_TRACredentialEnvelope()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialEnvelope> ITypeConverter<List<List<TRAKeyValuePair>>>.Enumerate_TRACredentialEnvelope(List<List<TRAKeyValuePair>> value)
            {
                
                yield break;
            }
            List<List<TRAKeyValuePair>> ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_TRACredentialWrapper(TRACredentialWrapper value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialWrapper' to 'List<List<TRAKeyValuePair>>'.");
                
            }
            TRACredentialWrapper ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertTo_TRACredentialWrapper(List<List<TRAKeyValuePair>> value)
            {
                return TypeConverter<TRACredentialWrapper>.ConvertFrom_List_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<List<TRAKeyValuePair>>>.GetConversionActionTo_TRACredentialWrapper()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialWrapper> ITypeConverter<List<List<TRAKeyValuePair>>>.Enumerate_TRACredentialWrapper(List<List<TRAKeyValuePair>> value)
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
            
            object ITypeConverter<object>.ConvertFrom_TRACredentialContent(TRACredentialContent value)
            {
                return value;
            }
            TRACredentialContent ITypeConverter<object>.ConvertTo_TRACredentialContent(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_TRACredentialContent()
            {
                throw new NotImplementedException();
            }
            IEnumerable<TRACredentialContent> ITypeConverter<object>.Enumerate_TRACredentialContent(object value)
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
            
            object ITypeConverter<object>.ConvertFrom_TRACredentialEnvelope(TRACredentialEnvelope value)
            {
                return value;
            }
            TRACredentialEnvelope ITypeConverter<object>.ConvertTo_TRACredentialEnvelope(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_TRACredentialEnvelope()
            {
                throw new NotImplementedException();
            }
            IEnumerable<TRACredentialEnvelope> ITypeConverter<object>.Enumerate_TRACredentialEnvelope(object value)
            {
                throw new NotImplementedException();
            }
            
            object ITypeConverter<object>.ConvertFrom_TRACredentialWrapper(TRACredentialWrapper value)
            {
                return value;
            }
            TRACredentialWrapper ITypeConverter<object>.ConvertTo_TRACredentialWrapper(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_TRACredentialWrapper()
            {
                throw new NotImplementedException();
            }
            IEnumerable<TRACredentialWrapper> ITypeConverter<object>.Enumerate_TRACredentialWrapper(object value)
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
        
        T ITypeConverter<T>.ConvertFrom_TRACredentialContent(TRACredentialContent value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TRACredentialContent ITypeConverter<T>.ConvertTo_TRACredentialContent(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_TRACredentialContent()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<TRACredentialContent> ITypeConverter<T>.Enumerate_TRACredentialContent(T value)
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
        
        T ITypeConverter<T>.ConvertFrom_TRACredentialEnvelope(TRACredentialEnvelope value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TRACredentialEnvelope ITypeConverter<T>.ConvertTo_TRACredentialEnvelope(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_TRACredentialEnvelope()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<TRACredentialEnvelope> ITypeConverter<T>.Enumerate_TRACredentialEnvelope(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        
        T ITypeConverter<T>.ConvertFrom_TRACredentialWrapper(TRACredentialWrapper value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TRACredentialWrapper ITypeConverter<T>.ConvertTo_TRACredentialWrapper(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_TRACredentialWrapper()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<TRACredentialWrapper> ITypeConverter<T>.Enumerate_TRACredentialWrapper(T value)
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
        
        internal static T ConvertFrom_TRACredentialContent(TRACredentialContent value)
        {
            return s_type_converter.ConvertFrom_TRACredentialContent(value);
        }
        internal static TRACredentialContent ConvertTo_TRACredentialContent(T value)
        {
            return s_type_converter.ConvertTo_TRACredentialContent(value);
        }
        internal static TypeConversionAction GetConversionActionTo_TRACredentialContent()
        {
            return s_type_converter.GetConversionActionTo_TRACredentialContent();
        }
        internal static IEnumerable<TRACredentialContent> Enumerate_TRACredentialContent(T value)
        {
            return s_type_converter.Enumerate_TRACredentialContent(value);
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
        
        internal static T ConvertFrom_TRACredentialEnvelope(TRACredentialEnvelope value)
        {
            return s_type_converter.ConvertFrom_TRACredentialEnvelope(value);
        }
        internal static TRACredentialEnvelope ConvertTo_TRACredentialEnvelope(T value)
        {
            return s_type_converter.ConvertTo_TRACredentialEnvelope(value);
        }
        internal static TypeConversionAction GetConversionActionTo_TRACredentialEnvelope()
        {
            return s_type_converter.GetConversionActionTo_TRACredentialEnvelope();
        }
        internal static IEnumerable<TRACredentialEnvelope> Enumerate_TRACredentialEnvelope(T value)
        {
            return s_type_converter.Enumerate_TRACredentialEnvelope(value);
        }
        
        internal static T ConvertFrom_TRACredentialWrapper(TRACredentialWrapper value)
        {
            return s_type_converter.ConvertFrom_TRACredentialWrapper(value);
        }
        internal static TRACredentialWrapper ConvertTo_TRACredentialWrapper(T value)
        {
            return s_type_converter.ConvertTo_TRACredentialWrapper(value);
        }
        internal static TypeConversionAction GetConversionActionTo_TRACredentialWrapper()
        {
            return s_type_converter.GetConversionActionTo_TRACredentialWrapper();
        }
        internal static IEnumerable<TRACredentialWrapper> Enumerate_TRACredentialWrapper(T value)
        {
            return s_type_converter.Enumerate_TRACredentialWrapper(value);
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
