#pragma warning disable 162,168,649,660,661,1522

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trinity.TSL;
using Trinity.TSL.Lib;
namespace TDW.VDAServer
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
            { typeof(List<TRAClaim>), 4 }
            ,
            { typeof(List<TRAKeyValuePair>), 5 }
            ,
            { typeof(TDWVDAAccountEntryContent), 6 }
            ,
            { typeof(TDWVDAAccountEntryCore), 7 }
            ,
            { typeof(TDWVDAIdentityRegistryEntry), 8 }
            ,
            { typeof(TDWVDAPostInvocationParameters), 9 }
            ,
            { typeof(TDWVDARevocationListEntry), 10 }
            ,
            { typeof(TDWVDAServiceEndpointEntry), 11 }
            ,
            { typeof(TDWVDASmartContractEntryCore), 12 }
            ,
            { typeof(TRAClaim), 13 }
            ,
            { typeof(TRACredentialContent), 14 }
            ,
            { typeof(TRACredentialCore), 15 }
            ,
            { typeof(TRACredentialEnvelope), 16 }
            ,
            { typeof(TRACredentialWrapper), 17 }
            ,
            { typeof(TRAKeyValuePair), 18 }
            ,
            { typeof(TRACredentialType), 19 }
            ,
            { typeof(TRAEncryptionFlag), 20 }
            ,
            { typeof(TRAServiceType), 21 }
            ,
            { typeof(TRATrustLevel), 22 }
            ,
            { typeof(List<List<TRAKeyValuePair>>), 24 }
            ,
        };
        #endregion
        #region CellTypeID lookup table
        private static Dictionary<Type, uint> CellTypeIDLookupTable = new Dictionary<Type, uint>()
        {
            
            { typeof(TDWCredential), 0 }
            ,
            { typeof(TDWVDAAccount), 1 }
            ,
            { typeof(TDWVDASmartContract), 2 }
            
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
        
        T ConvertFrom_List_TRAClaim(List<TRAClaim> value);
        List<TRAClaim> ConvertTo_List_TRAClaim(T value);
        TypeConversionAction GetConversionActionTo_List_TRAClaim();
        IEnumerable<List<TRAClaim>> Enumerate_List_TRAClaim(T value);
        
        T ConvertFrom_List_TRAKeyValuePair(List<TRAKeyValuePair> value);
        List<TRAKeyValuePair> ConvertTo_List_TRAKeyValuePair(T value);
        TypeConversionAction GetConversionActionTo_List_TRAKeyValuePair();
        IEnumerable<List<TRAKeyValuePair>> Enumerate_List_TRAKeyValuePair(T value);
        
        T ConvertFrom_TDWVDAAccountEntryContent(TDWVDAAccountEntryContent value);
        TDWVDAAccountEntryContent ConvertTo_TDWVDAAccountEntryContent(T value);
        TypeConversionAction GetConversionActionTo_TDWVDAAccountEntryContent();
        IEnumerable<TDWVDAAccountEntryContent> Enumerate_TDWVDAAccountEntryContent(T value);
        
        T ConvertFrom_TDWVDAAccountEntryCore(TDWVDAAccountEntryCore value);
        TDWVDAAccountEntryCore ConvertTo_TDWVDAAccountEntryCore(T value);
        TypeConversionAction GetConversionActionTo_TDWVDAAccountEntryCore();
        IEnumerable<TDWVDAAccountEntryCore> Enumerate_TDWVDAAccountEntryCore(T value);
        
        T ConvertFrom_TDWVDAIdentityRegistryEntry(TDWVDAIdentityRegistryEntry value);
        TDWVDAIdentityRegistryEntry ConvertTo_TDWVDAIdentityRegistryEntry(T value);
        TypeConversionAction GetConversionActionTo_TDWVDAIdentityRegistryEntry();
        IEnumerable<TDWVDAIdentityRegistryEntry> Enumerate_TDWVDAIdentityRegistryEntry(T value);
        
        T ConvertFrom_TDWVDAPostInvocationParameters(TDWVDAPostInvocationParameters value);
        TDWVDAPostInvocationParameters ConvertTo_TDWVDAPostInvocationParameters(T value);
        TypeConversionAction GetConversionActionTo_TDWVDAPostInvocationParameters();
        IEnumerable<TDWVDAPostInvocationParameters> Enumerate_TDWVDAPostInvocationParameters(T value);
        
        T ConvertFrom_TDWVDARevocationListEntry(TDWVDARevocationListEntry value);
        TDWVDARevocationListEntry ConvertTo_TDWVDARevocationListEntry(T value);
        TypeConversionAction GetConversionActionTo_TDWVDARevocationListEntry();
        IEnumerable<TDWVDARevocationListEntry> Enumerate_TDWVDARevocationListEntry(T value);
        
        T ConvertFrom_TDWVDAServiceEndpointEntry(TDWVDAServiceEndpointEntry value);
        TDWVDAServiceEndpointEntry ConvertTo_TDWVDAServiceEndpointEntry(T value);
        TypeConversionAction GetConversionActionTo_TDWVDAServiceEndpointEntry();
        IEnumerable<TDWVDAServiceEndpointEntry> Enumerate_TDWVDAServiceEndpointEntry(T value);
        
        T ConvertFrom_TDWVDASmartContractEntryCore(TDWVDASmartContractEntryCore value);
        TDWVDASmartContractEntryCore ConvertTo_TDWVDASmartContractEntryCore(T value);
        TypeConversionAction GetConversionActionTo_TDWVDASmartContractEntryCore();
        IEnumerable<TDWVDASmartContractEntryCore> Enumerate_TDWVDASmartContractEntryCore(T value);
        
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
        
        T ConvertFrom_TRAServiceType(TRAServiceType value);
        TRAServiceType ConvertTo_TRAServiceType(T value);
        TypeConversionAction GetConversionActionTo_TRAServiceType();
        IEnumerable<TRAServiceType> Enumerate_TRAServiceType(T value);
        
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
            
            , ITypeConverter<bool>
        
            , ITypeConverter<long>
        
            , ITypeConverter<string>
        
            , ITypeConverter<List<string>>
        
            , ITypeConverter<List<TRAClaim>>
        
            , ITypeConverter<List<TRAKeyValuePair>>
        
            , ITypeConverter<TDWVDAAccountEntryContent>
        
            , ITypeConverter<TDWVDAAccountEntryCore>
        
            , ITypeConverter<TDWVDAIdentityRegistryEntry>
        
            , ITypeConverter<TDWVDAPostInvocationParameters>
        
            , ITypeConverter<TDWVDARevocationListEntry>
        
            , ITypeConverter<TDWVDAServiceEndpointEntry>
        
            , ITypeConverter<TDWVDASmartContractEntryCore>
        
            , ITypeConverter<TRAClaim>
        
            , ITypeConverter<TRACredentialContent>
        
            , ITypeConverter<TRACredentialCore>
        
            , ITypeConverter<TRACredentialEnvelope>
        
            , ITypeConverter<TRACredentialWrapper>
        
            , ITypeConverter<TRAKeyValuePair>
        
            , ITypeConverter<TRACredentialType>
        
            , ITypeConverter<TRAEncryptionFlag>
        
            , ITypeConverter<TRAServiceType>
        
            , ITypeConverter<TRATrustLevel>
        
            , ITypeConverter<List<List<TRAKeyValuePair>>>
        
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
            bool ITypeConverter<bool>.ConvertFrom_List_TRAClaim(List<TRAClaim> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<TRAClaim>' to 'bool'.");
                
            }
            List<TRAClaim> ITypeConverter<bool>.ConvertTo_List_TRAClaim(bool value)
            {
                return TypeConverter<List<TRAClaim>>.ConvertFrom_bool(value);
            }
            TypeConversionAction ITypeConverter<bool>.GetConversionActionTo_List_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAClaim>> ITypeConverter<bool>.Enumerate_List_TRAClaim(bool value)
            {
                
                yield break;
            }
            bool ITypeConverter<bool>.ConvertFrom_List_TRAKeyValuePair(List<TRAKeyValuePair> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<TRAKeyValuePair>' to 'bool'.");
                
            }
            List<TRAKeyValuePair> ITypeConverter<bool>.ConvertTo_List_TRAKeyValuePair(bool value)
            {
                return TypeConverter<List<TRAKeyValuePair>>.ConvertFrom_bool(value);
            }
            TypeConversionAction ITypeConverter<bool>.GetConversionActionTo_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAKeyValuePair>> ITypeConverter<bool>.Enumerate_List_TRAKeyValuePair(bool value)
            {
                
                yield break;
            }
            bool ITypeConverter<bool>.ConvertFrom_TDWVDAAccountEntryContent(TDWVDAAccountEntryContent value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAAccountEntryContent' to 'bool'.");
                
            }
            TDWVDAAccountEntryContent ITypeConverter<bool>.ConvertTo_TDWVDAAccountEntryContent(bool value)
            {
                return TypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_bool(value);
            }
            TypeConversionAction ITypeConverter<bool>.GetConversionActionTo_TDWVDAAccountEntryContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryContent> ITypeConverter<bool>.Enumerate_TDWVDAAccountEntryContent(bool value)
            {
                
                yield break;
            }
            bool ITypeConverter<bool>.ConvertFrom_TDWVDAAccountEntryCore(TDWVDAAccountEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAAccountEntryCore' to 'bool'.");
                
            }
            TDWVDAAccountEntryCore ITypeConverter<bool>.ConvertTo_TDWVDAAccountEntryCore(bool value)
            {
                return TypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_bool(value);
            }
            TypeConversionAction ITypeConverter<bool>.GetConversionActionTo_TDWVDAAccountEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryCore> ITypeConverter<bool>.Enumerate_TDWVDAAccountEntryCore(bool value)
            {
                
                yield break;
            }
            bool ITypeConverter<bool>.ConvertFrom_TDWVDAIdentityRegistryEntry(TDWVDAIdentityRegistryEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAIdentityRegistryEntry' to 'bool'.");
                
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<bool>.ConvertTo_TDWVDAIdentityRegistryEntry(bool value)
            {
                return TypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_bool(value);
            }
            TypeConversionAction ITypeConverter<bool>.GetConversionActionTo_TDWVDAIdentityRegistryEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAIdentityRegistryEntry> ITypeConverter<bool>.Enumerate_TDWVDAIdentityRegistryEntry(bool value)
            {
                
                yield break;
            }
            bool ITypeConverter<bool>.ConvertFrom_TDWVDAPostInvocationParameters(TDWVDAPostInvocationParameters value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAPostInvocationParameters' to 'bool'.");
                
            }
            TDWVDAPostInvocationParameters ITypeConverter<bool>.ConvertTo_TDWVDAPostInvocationParameters(bool value)
            {
                return TypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_bool(value);
            }
            TypeConversionAction ITypeConverter<bool>.GetConversionActionTo_TDWVDAPostInvocationParameters()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAPostInvocationParameters> ITypeConverter<bool>.Enumerate_TDWVDAPostInvocationParameters(bool value)
            {
                
                yield break;
            }
            bool ITypeConverter<bool>.ConvertFrom_TDWVDARevocationListEntry(TDWVDARevocationListEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDARevocationListEntry' to 'bool'.");
                
            }
            TDWVDARevocationListEntry ITypeConverter<bool>.ConvertTo_TDWVDARevocationListEntry(bool value)
            {
                return TypeConverter<TDWVDARevocationListEntry>.ConvertFrom_bool(value);
            }
            TypeConversionAction ITypeConverter<bool>.GetConversionActionTo_TDWVDARevocationListEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDARevocationListEntry> ITypeConverter<bool>.Enumerate_TDWVDARevocationListEntry(bool value)
            {
                
                yield break;
            }
            bool ITypeConverter<bool>.ConvertFrom_TDWVDAServiceEndpointEntry(TDWVDAServiceEndpointEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAServiceEndpointEntry' to 'bool'.");
                
            }
            TDWVDAServiceEndpointEntry ITypeConverter<bool>.ConvertTo_TDWVDAServiceEndpointEntry(bool value)
            {
                return TypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_bool(value);
            }
            TypeConversionAction ITypeConverter<bool>.GetConversionActionTo_TDWVDAServiceEndpointEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAServiceEndpointEntry> ITypeConverter<bool>.Enumerate_TDWVDAServiceEndpointEntry(bool value)
            {
                
                yield break;
            }
            bool ITypeConverter<bool>.ConvertFrom_TDWVDASmartContractEntryCore(TDWVDASmartContractEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDASmartContractEntryCore' to 'bool'.");
                
            }
            TDWVDASmartContractEntryCore ITypeConverter<bool>.ConvertTo_TDWVDASmartContractEntryCore(bool value)
            {
                return TypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_bool(value);
            }
            TypeConversionAction ITypeConverter<bool>.GetConversionActionTo_TDWVDASmartContractEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDASmartContractEntryCore> ITypeConverter<bool>.Enumerate_TDWVDASmartContractEntryCore(bool value)
            {
                
                yield break;
            }
            bool ITypeConverter<bool>.ConvertFrom_TRAClaim(TRAClaim value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAClaim' to 'bool'.");
                
            }
            TRAClaim ITypeConverter<bool>.ConvertTo_TRAClaim(bool value)
            {
                return TypeConverter<TRAClaim>.ConvertFrom_bool(value);
            }
            TypeConversionAction ITypeConverter<bool>.GetConversionActionTo_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAClaim> ITypeConverter<bool>.Enumerate_TRAClaim(bool value)
            {
                
                yield break;
            }
            bool ITypeConverter<bool>.ConvertFrom_TRACredentialContent(TRACredentialContent value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialContent' to 'bool'.");
                
            }
            TRACredentialContent ITypeConverter<bool>.ConvertTo_TRACredentialContent(bool value)
            {
                return TypeConverter<TRACredentialContent>.ConvertFrom_bool(value);
            }
            TypeConversionAction ITypeConverter<bool>.GetConversionActionTo_TRACredentialContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialContent> ITypeConverter<bool>.Enumerate_TRACredentialContent(bool value)
            {
                
                yield break;
            }
            bool ITypeConverter<bool>.ConvertFrom_TRACredentialCore(TRACredentialCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialCore' to 'bool'.");
                
            }
            TRACredentialCore ITypeConverter<bool>.ConvertTo_TRACredentialCore(bool value)
            {
                return TypeConverter<TRACredentialCore>.ConvertFrom_bool(value);
            }
            TypeConversionAction ITypeConverter<bool>.GetConversionActionTo_TRACredentialCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialCore> ITypeConverter<bool>.Enumerate_TRACredentialCore(bool value)
            {
                
                yield break;
            }
            bool ITypeConverter<bool>.ConvertFrom_TRACredentialEnvelope(TRACredentialEnvelope value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialEnvelope' to 'bool'.");
                
            }
            TRACredentialEnvelope ITypeConverter<bool>.ConvertTo_TRACredentialEnvelope(bool value)
            {
                return TypeConverter<TRACredentialEnvelope>.ConvertFrom_bool(value);
            }
            TypeConversionAction ITypeConverter<bool>.GetConversionActionTo_TRACredentialEnvelope()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialEnvelope> ITypeConverter<bool>.Enumerate_TRACredentialEnvelope(bool value)
            {
                
                yield break;
            }
            bool ITypeConverter<bool>.ConvertFrom_TRACredentialWrapper(TRACredentialWrapper value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialWrapper' to 'bool'.");
                
            }
            TRACredentialWrapper ITypeConverter<bool>.ConvertTo_TRACredentialWrapper(bool value)
            {
                return TypeConverter<TRACredentialWrapper>.ConvertFrom_bool(value);
            }
            TypeConversionAction ITypeConverter<bool>.GetConversionActionTo_TRACredentialWrapper()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialWrapper> ITypeConverter<bool>.Enumerate_TRACredentialWrapper(bool value)
            {
                
                yield break;
            }
            bool ITypeConverter<bool>.ConvertFrom_TRAKeyValuePair(TRAKeyValuePair value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAKeyValuePair' to 'bool'.");
                
            }
            TRAKeyValuePair ITypeConverter<bool>.ConvertTo_TRAKeyValuePair(bool value)
            {
                return TypeConverter<TRAKeyValuePair>.ConvertFrom_bool(value);
            }
            TypeConversionAction ITypeConverter<bool>.GetConversionActionTo_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAKeyValuePair> ITypeConverter<bool>.Enumerate_TRAKeyValuePair(bool value)
            {
                
                yield break;
            }
            bool ITypeConverter<bool>.ConvertFrom_TRACredentialType(TRACredentialType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialType' to 'bool'.");
                
            }
            TRACredentialType ITypeConverter<bool>.ConvertTo_TRACredentialType(bool value)
            {
                return TypeConverter<TRACredentialType>.ConvertFrom_bool(value);
            }
            TypeConversionAction ITypeConverter<bool>.GetConversionActionTo_TRACredentialType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialType> ITypeConverter<bool>.Enumerate_TRACredentialType(bool value)
            {
                
                yield break;
            }
            bool ITypeConverter<bool>.ConvertFrom_TRAEncryptionFlag(TRAEncryptionFlag value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAEncryptionFlag' to 'bool'.");
                
            }
            TRAEncryptionFlag ITypeConverter<bool>.ConvertTo_TRAEncryptionFlag(bool value)
            {
                return TypeConverter<TRAEncryptionFlag>.ConvertFrom_bool(value);
            }
            TypeConversionAction ITypeConverter<bool>.GetConversionActionTo_TRAEncryptionFlag()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEncryptionFlag> ITypeConverter<bool>.Enumerate_TRAEncryptionFlag(bool value)
            {
                
                yield break;
            }
            bool ITypeConverter<bool>.ConvertFrom_TRAServiceType(TRAServiceType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAServiceType' to 'bool'.");
                
            }
            TRAServiceType ITypeConverter<bool>.ConvertTo_TRAServiceType(bool value)
            {
                return TypeConverter<TRAServiceType>.ConvertFrom_bool(value);
            }
            TypeConversionAction ITypeConverter<bool>.GetConversionActionTo_TRAServiceType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAServiceType> ITypeConverter<bool>.Enumerate_TRAServiceType(bool value)
            {
                
                yield break;
            }
            bool ITypeConverter<bool>.ConvertFrom_TRATrustLevel(TRATrustLevel value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRATrustLevel' to 'bool'.");
                
            }
            TRATrustLevel ITypeConverter<bool>.ConvertTo_TRATrustLevel(bool value)
            {
                return TypeConverter<TRATrustLevel>.ConvertFrom_bool(value);
            }
            TypeConversionAction ITypeConverter<bool>.GetConversionActionTo_TRATrustLevel()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRATrustLevel> ITypeConverter<bool>.Enumerate_TRATrustLevel(bool value)
            {
                
                yield break;
            }
            bool ITypeConverter<bool>.ConvertFrom_List_List_TRAKeyValuePair(List<List<TRAKeyValuePair>> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<List<TRAKeyValuePair>>' to 'bool'.");
                
            }
            List<List<TRAKeyValuePair>> ITypeConverter<bool>.ConvertTo_List_List_TRAKeyValuePair(bool value)
            {
                return TypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_bool(value);
            }
            TypeConversionAction ITypeConverter<bool>.GetConversionActionTo_List_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<List<TRAKeyValuePair>>> ITypeConverter<bool>.Enumerate_List_List_TRAKeyValuePair(bool value)
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
            long ITypeConverter<long>.ConvertFrom_TDWVDAAccountEntryContent(TDWVDAAccountEntryContent value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAAccountEntryContent' to 'long'.");
                
            }
            TDWVDAAccountEntryContent ITypeConverter<long>.ConvertTo_TDWVDAAccountEntryContent(long value)
            {
                return TypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_long(value);
            }
            TypeConversionAction ITypeConverter<long>.GetConversionActionTo_TDWVDAAccountEntryContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryContent> ITypeConverter<long>.Enumerate_TDWVDAAccountEntryContent(long value)
            {
                
                yield break;
            }
            long ITypeConverter<long>.ConvertFrom_TDWVDAAccountEntryCore(TDWVDAAccountEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAAccountEntryCore' to 'long'.");
                
            }
            TDWVDAAccountEntryCore ITypeConverter<long>.ConvertTo_TDWVDAAccountEntryCore(long value)
            {
                return TypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_long(value);
            }
            TypeConversionAction ITypeConverter<long>.GetConversionActionTo_TDWVDAAccountEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryCore> ITypeConverter<long>.Enumerate_TDWVDAAccountEntryCore(long value)
            {
                
                yield break;
            }
            long ITypeConverter<long>.ConvertFrom_TDWVDAIdentityRegistryEntry(TDWVDAIdentityRegistryEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAIdentityRegistryEntry' to 'long'.");
                
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<long>.ConvertTo_TDWVDAIdentityRegistryEntry(long value)
            {
                return TypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_long(value);
            }
            TypeConversionAction ITypeConverter<long>.GetConversionActionTo_TDWVDAIdentityRegistryEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAIdentityRegistryEntry> ITypeConverter<long>.Enumerate_TDWVDAIdentityRegistryEntry(long value)
            {
                
                yield break;
            }
            long ITypeConverter<long>.ConvertFrom_TDWVDAPostInvocationParameters(TDWVDAPostInvocationParameters value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAPostInvocationParameters' to 'long'.");
                
            }
            TDWVDAPostInvocationParameters ITypeConverter<long>.ConvertTo_TDWVDAPostInvocationParameters(long value)
            {
                return TypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_long(value);
            }
            TypeConversionAction ITypeConverter<long>.GetConversionActionTo_TDWVDAPostInvocationParameters()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAPostInvocationParameters> ITypeConverter<long>.Enumerate_TDWVDAPostInvocationParameters(long value)
            {
                
                yield break;
            }
            long ITypeConverter<long>.ConvertFrom_TDWVDARevocationListEntry(TDWVDARevocationListEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDARevocationListEntry' to 'long'.");
                
            }
            TDWVDARevocationListEntry ITypeConverter<long>.ConvertTo_TDWVDARevocationListEntry(long value)
            {
                return TypeConverter<TDWVDARevocationListEntry>.ConvertFrom_long(value);
            }
            TypeConversionAction ITypeConverter<long>.GetConversionActionTo_TDWVDARevocationListEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDARevocationListEntry> ITypeConverter<long>.Enumerate_TDWVDARevocationListEntry(long value)
            {
                
                yield break;
            }
            long ITypeConverter<long>.ConvertFrom_TDWVDAServiceEndpointEntry(TDWVDAServiceEndpointEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAServiceEndpointEntry' to 'long'.");
                
            }
            TDWVDAServiceEndpointEntry ITypeConverter<long>.ConvertTo_TDWVDAServiceEndpointEntry(long value)
            {
                return TypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_long(value);
            }
            TypeConversionAction ITypeConverter<long>.GetConversionActionTo_TDWVDAServiceEndpointEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAServiceEndpointEntry> ITypeConverter<long>.Enumerate_TDWVDAServiceEndpointEntry(long value)
            {
                
                yield break;
            }
            long ITypeConverter<long>.ConvertFrom_TDWVDASmartContractEntryCore(TDWVDASmartContractEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDASmartContractEntryCore' to 'long'.");
                
            }
            TDWVDASmartContractEntryCore ITypeConverter<long>.ConvertTo_TDWVDASmartContractEntryCore(long value)
            {
                return TypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_long(value);
            }
            TypeConversionAction ITypeConverter<long>.GetConversionActionTo_TDWVDASmartContractEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDASmartContractEntryCore> ITypeConverter<long>.Enumerate_TDWVDASmartContractEntryCore(long value)
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
            long ITypeConverter<long>.ConvertFrom_TRAServiceType(TRAServiceType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAServiceType' to 'long'.");
                
            }
            TRAServiceType ITypeConverter<long>.ConvertTo_TRAServiceType(long value)
            {
                return TypeConverter<TRAServiceType>.ConvertFrom_long(value);
            }
            TypeConversionAction ITypeConverter<long>.GetConversionActionTo_TRAServiceType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAServiceType> ITypeConverter<long>.Enumerate_TRAServiceType(long value)
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
            string ITypeConverter<string>.ConvertFrom_TDWVDAAccountEntryContent(TDWVDAAccountEntryContent value)
            {
                
                return Serializer.ToString(value);
                
            }
            TDWVDAAccountEntryContent ITypeConverter<string>.ConvertTo_TDWVDAAccountEntryContent(string value)
            {
                return TypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_TDWVDAAccountEntryContent()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryContent> ITypeConverter<string>.Enumerate_TDWVDAAccountEntryContent(string value)
            {
                
                yield break;
            }
            string ITypeConverter<string>.ConvertFrom_TDWVDAAccountEntryCore(TDWVDAAccountEntryCore value)
            {
                
                return Serializer.ToString(value);
                
            }
            TDWVDAAccountEntryCore ITypeConverter<string>.ConvertTo_TDWVDAAccountEntryCore(string value)
            {
                return TypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_TDWVDAAccountEntryCore()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryCore> ITypeConverter<string>.Enumerate_TDWVDAAccountEntryCore(string value)
            {
                
                yield break;
            }
            string ITypeConverter<string>.ConvertFrom_TDWVDAIdentityRegistryEntry(TDWVDAIdentityRegistryEntry value)
            {
                
                return Serializer.ToString(value);
                
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<string>.ConvertTo_TDWVDAIdentityRegistryEntry(string value)
            {
                return TypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_TDWVDAIdentityRegistryEntry()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAIdentityRegistryEntry> ITypeConverter<string>.Enumerate_TDWVDAIdentityRegistryEntry(string value)
            {
                
                yield break;
            }
            string ITypeConverter<string>.ConvertFrom_TDWVDAPostInvocationParameters(TDWVDAPostInvocationParameters value)
            {
                
                return Serializer.ToString(value);
                
            }
            TDWVDAPostInvocationParameters ITypeConverter<string>.ConvertTo_TDWVDAPostInvocationParameters(string value)
            {
                return TypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_TDWVDAPostInvocationParameters()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAPostInvocationParameters> ITypeConverter<string>.Enumerate_TDWVDAPostInvocationParameters(string value)
            {
                
                yield break;
            }
            string ITypeConverter<string>.ConvertFrom_TDWVDARevocationListEntry(TDWVDARevocationListEntry value)
            {
                
                return Serializer.ToString(value);
                
            }
            TDWVDARevocationListEntry ITypeConverter<string>.ConvertTo_TDWVDARevocationListEntry(string value)
            {
                return TypeConverter<TDWVDARevocationListEntry>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_TDWVDARevocationListEntry()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDARevocationListEntry> ITypeConverter<string>.Enumerate_TDWVDARevocationListEntry(string value)
            {
                
                yield break;
            }
            string ITypeConverter<string>.ConvertFrom_TDWVDAServiceEndpointEntry(TDWVDAServiceEndpointEntry value)
            {
                
                return Serializer.ToString(value);
                
            }
            TDWVDAServiceEndpointEntry ITypeConverter<string>.ConvertTo_TDWVDAServiceEndpointEntry(string value)
            {
                return TypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_TDWVDAServiceEndpointEntry()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAServiceEndpointEntry> ITypeConverter<string>.Enumerate_TDWVDAServiceEndpointEntry(string value)
            {
                
                yield break;
            }
            string ITypeConverter<string>.ConvertFrom_TDWVDASmartContractEntryCore(TDWVDASmartContractEntryCore value)
            {
                
                return Serializer.ToString(value);
                
            }
            TDWVDASmartContractEntryCore ITypeConverter<string>.ConvertTo_TDWVDASmartContractEntryCore(string value)
            {
                return TypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_TDWVDASmartContractEntryCore()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDASmartContractEntryCore> ITypeConverter<string>.Enumerate_TDWVDASmartContractEntryCore(string value)
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
            string ITypeConverter<string>.ConvertFrom_TRAServiceType(TRAServiceType value)
            {
                
                return Serializer.ToString(value);
                
            }
            TRAServiceType ITypeConverter<string>.ConvertTo_TRAServiceType(string value)
            {
                return TypeConverter<TRAServiceType>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_TRAServiceType()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAServiceType> ITypeConverter<string>.Enumerate_TRAServiceType(string value)
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
            List<string> ITypeConverter<List<string>>.ConvertFrom_TDWVDAAccountEntryContent(TDWVDAAccountEntryContent value)
            {
                
                {
                    List<string> intermediate_result = new List<string>();
                    intermediate_result.Add(TypeConverter<string>.ConvertFrom_TDWVDAAccountEntryContent(value));
                    return intermediate_result;
                }
                
            }
            TDWVDAAccountEntryContent ITypeConverter<List<string>>.ConvertTo_TDWVDAAccountEntryContent(List<string> value)
            {
                return TypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_TDWVDAAccountEntryContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryContent> ITypeConverter<List<string>>.Enumerate_TDWVDAAccountEntryContent(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_string(element);
                
                yield break;
            }
            List<string> ITypeConverter<List<string>>.ConvertFrom_TDWVDAAccountEntryCore(TDWVDAAccountEntryCore value)
            {
                
                {
                    List<string> intermediate_result = new List<string>();
                    intermediate_result.Add(TypeConverter<string>.ConvertFrom_TDWVDAAccountEntryCore(value));
                    return intermediate_result;
                }
                
            }
            TDWVDAAccountEntryCore ITypeConverter<List<string>>.ConvertTo_TDWVDAAccountEntryCore(List<string> value)
            {
                return TypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_TDWVDAAccountEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryCore> ITypeConverter<List<string>>.Enumerate_TDWVDAAccountEntryCore(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_string(element);
                
                yield break;
            }
            List<string> ITypeConverter<List<string>>.ConvertFrom_TDWVDAIdentityRegistryEntry(TDWVDAIdentityRegistryEntry value)
            {
                
                {
                    List<string> intermediate_result = new List<string>();
                    intermediate_result.Add(TypeConverter<string>.ConvertFrom_TDWVDAIdentityRegistryEntry(value));
                    return intermediate_result;
                }
                
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<List<string>>.ConvertTo_TDWVDAIdentityRegistryEntry(List<string> value)
            {
                return TypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_TDWVDAIdentityRegistryEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAIdentityRegistryEntry> ITypeConverter<List<string>>.Enumerate_TDWVDAIdentityRegistryEntry(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_string(element);
                
                yield break;
            }
            List<string> ITypeConverter<List<string>>.ConvertFrom_TDWVDAPostInvocationParameters(TDWVDAPostInvocationParameters value)
            {
                
                {
                    List<string> intermediate_result = new List<string>();
                    intermediate_result.Add(TypeConverter<string>.ConvertFrom_TDWVDAPostInvocationParameters(value));
                    return intermediate_result;
                }
                
            }
            TDWVDAPostInvocationParameters ITypeConverter<List<string>>.ConvertTo_TDWVDAPostInvocationParameters(List<string> value)
            {
                return TypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_TDWVDAPostInvocationParameters()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAPostInvocationParameters> ITypeConverter<List<string>>.Enumerate_TDWVDAPostInvocationParameters(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_string(element);
                
                yield break;
            }
            List<string> ITypeConverter<List<string>>.ConvertFrom_TDWVDARevocationListEntry(TDWVDARevocationListEntry value)
            {
                
                {
                    List<string> intermediate_result = new List<string>();
                    intermediate_result.Add(TypeConverter<string>.ConvertFrom_TDWVDARevocationListEntry(value));
                    return intermediate_result;
                }
                
            }
            TDWVDARevocationListEntry ITypeConverter<List<string>>.ConvertTo_TDWVDARevocationListEntry(List<string> value)
            {
                return TypeConverter<TDWVDARevocationListEntry>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_TDWVDARevocationListEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDARevocationListEntry> ITypeConverter<List<string>>.Enumerate_TDWVDARevocationListEntry(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<TDWVDARevocationListEntry>.ConvertFrom_string(element);
                
                yield break;
            }
            List<string> ITypeConverter<List<string>>.ConvertFrom_TDWVDAServiceEndpointEntry(TDWVDAServiceEndpointEntry value)
            {
                
                {
                    List<string> intermediate_result = new List<string>();
                    intermediate_result.Add(TypeConverter<string>.ConvertFrom_TDWVDAServiceEndpointEntry(value));
                    return intermediate_result;
                }
                
            }
            TDWVDAServiceEndpointEntry ITypeConverter<List<string>>.ConvertTo_TDWVDAServiceEndpointEntry(List<string> value)
            {
                return TypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_TDWVDAServiceEndpointEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAServiceEndpointEntry> ITypeConverter<List<string>>.Enumerate_TDWVDAServiceEndpointEntry(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_string(element);
                
                yield break;
            }
            List<string> ITypeConverter<List<string>>.ConvertFrom_TDWVDASmartContractEntryCore(TDWVDASmartContractEntryCore value)
            {
                
                {
                    List<string> intermediate_result = new List<string>();
                    intermediate_result.Add(TypeConverter<string>.ConvertFrom_TDWVDASmartContractEntryCore(value));
                    return intermediate_result;
                }
                
            }
            TDWVDASmartContractEntryCore ITypeConverter<List<string>>.ConvertTo_TDWVDASmartContractEntryCore(List<string> value)
            {
                return TypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_TDWVDASmartContractEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDASmartContractEntryCore> ITypeConverter<List<string>>.Enumerate_TDWVDASmartContractEntryCore(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_string(element);
                
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
            List<string> ITypeConverter<List<string>>.ConvertFrom_TRAServiceType(TRAServiceType value)
            {
                
                {
                    List<string> intermediate_result = new List<string>();
                    intermediate_result.Add(TypeConverter<string>.ConvertFrom_TRAServiceType(value));
                    return intermediate_result;
                }
                
            }
            TRAServiceType ITypeConverter<List<string>>.ConvertTo_TRAServiceType(List<string> value)
            {
                return TypeConverter<TRAServiceType>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_TRAServiceType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAServiceType> ITypeConverter<List<string>>.Enumerate_TRAServiceType(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<TRAServiceType>.ConvertFrom_string(element);
                
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
            List<TRAClaim> ITypeConverter<List<TRAClaim>>.ConvertFrom_bool(bool value)
            {
                
                throw new InvalidCastException("Invalid cast from 'bool' to 'List<TRAClaim>'.");
                
            }
            bool ITypeConverter<List<TRAClaim>>.ConvertTo_bool(List<TRAClaim> value)
            {
                return TypeConverter<bool>.ConvertFrom_List_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<List<TRAClaim>>.GetConversionActionTo_bool()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<bool> ITypeConverter<List<TRAClaim>>.Enumerate_bool(List<TRAClaim> value)
            {
                
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
            List<TRAClaim> ITypeConverter<List<TRAClaim>>.ConvertFrom_TDWVDAAccountEntryContent(TDWVDAAccountEntryContent value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAAccountEntryContent' to 'List<TRAClaim>'.");
                
            }
            TDWVDAAccountEntryContent ITypeConverter<List<TRAClaim>>.ConvertTo_TDWVDAAccountEntryContent(List<TRAClaim> value)
            {
                return TypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_List_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<List<TRAClaim>>.GetConversionActionTo_TDWVDAAccountEntryContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryContent> ITypeConverter<List<TRAClaim>>.Enumerate_TDWVDAAccountEntryContent(List<TRAClaim> value)
            {
                
                yield break;
            }
            List<TRAClaim> ITypeConverter<List<TRAClaim>>.ConvertFrom_TDWVDAAccountEntryCore(TDWVDAAccountEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAAccountEntryCore' to 'List<TRAClaim>'.");
                
            }
            TDWVDAAccountEntryCore ITypeConverter<List<TRAClaim>>.ConvertTo_TDWVDAAccountEntryCore(List<TRAClaim> value)
            {
                return TypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_List_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<List<TRAClaim>>.GetConversionActionTo_TDWVDAAccountEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryCore> ITypeConverter<List<TRAClaim>>.Enumerate_TDWVDAAccountEntryCore(List<TRAClaim> value)
            {
                
                yield break;
            }
            List<TRAClaim> ITypeConverter<List<TRAClaim>>.ConvertFrom_TDWVDAIdentityRegistryEntry(TDWVDAIdentityRegistryEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAIdentityRegistryEntry' to 'List<TRAClaim>'.");
                
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<List<TRAClaim>>.ConvertTo_TDWVDAIdentityRegistryEntry(List<TRAClaim> value)
            {
                return TypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_List_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<List<TRAClaim>>.GetConversionActionTo_TDWVDAIdentityRegistryEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAIdentityRegistryEntry> ITypeConverter<List<TRAClaim>>.Enumerate_TDWVDAIdentityRegistryEntry(List<TRAClaim> value)
            {
                
                yield break;
            }
            List<TRAClaim> ITypeConverter<List<TRAClaim>>.ConvertFrom_TDWVDAPostInvocationParameters(TDWVDAPostInvocationParameters value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAPostInvocationParameters' to 'List<TRAClaim>'.");
                
            }
            TDWVDAPostInvocationParameters ITypeConverter<List<TRAClaim>>.ConvertTo_TDWVDAPostInvocationParameters(List<TRAClaim> value)
            {
                return TypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_List_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<List<TRAClaim>>.GetConversionActionTo_TDWVDAPostInvocationParameters()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAPostInvocationParameters> ITypeConverter<List<TRAClaim>>.Enumerate_TDWVDAPostInvocationParameters(List<TRAClaim> value)
            {
                
                yield break;
            }
            List<TRAClaim> ITypeConverter<List<TRAClaim>>.ConvertFrom_TDWVDARevocationListEntry(TDWVDARevocationListEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDARevocationListEntry' to 'List<TRAClaim>'.");
                
            }
            TDWVDARevocationListEntry ITypeConverter<List<TRAClaim>>.ConvertTo_TDWVDARevocationListEntry(List<TRAClaim> value)
            {
                return TypeConverter<TDWVDARevocationListEntry>.ConvertFrom_List_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<List<TRAClaim>>.GetConversionActionTo_TDWVDARevocationListEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDARevocationListEntry> ITypeConverter<List<TRAClaim>>.Enumerate_TDWVDARevocationListEntry(List<TRAClaim> value)
            {
                
                yield break;
            }
            List<TRAClaim> ITypeConverter<List<TRAClaim>>.ConvertFrom_TDWVDAServiceEndpointEntry(TDWVDAServiceEndpointEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAServiceEndpointEntry' to 'List<TRAClaim>'.");
                
            }
            TDWVDAServiceEndpointEntry ITypeConverter<List<TRAClaim>>.ConvertTo_TDWVDAServiceEndpointEntry(List<TRAClaim> value)
            {
                return TypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_List_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<List<TRAClaim>>.GetConversionActionTo_TDWVDAServiceEndpointEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAServiceEndpointEntry> ITypeConverter<List<TRAClaim>>.Enumerate_TDWVDAServiceEndpointEntry(List<TRAClaim> value)
            {
                
                yield break;
            }
            List<TRAClaim> ITypeConverter<List<TRAClaim>>.ConvertFrom_TDWVDASmartContractEntryCore(TDWVDASmartContractEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDASmartContractEntryCore' to 'List<TRAClaim>'.");
                
            }
            TDWVDASmartContractEntryCore ITypeConverter<List<TRAClaim>>.ConvertTo_TDWVDASmartContractEntryCore(List<TRAClaim> value)
            {
                return TypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_List_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<List<TRAClaim>>.GetConversionActionTo_TDWVDASmartContractEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDASmartContractEntryCore> ITypeConverter<List<TRAClaim>>.Enumerate_TDWVDASmartContractEntryCore(List<TRAClaim> value)
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
            List<TRAClaim> ITypeConverter<List<TRAClaim>>.ConvertFrom_TRAServiceType(TRAServiceType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAServiceType' to 'List<TRAClaim>'.");
                
            }
            TRAServiceType ITypeConverter<List<TRAClaim>>.ConvertTo_TRAServiceType(List<TRAClaim> value)
            {
                return TypeConverter<TRAServiceType>.ConvertFrom_List_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<List<TRAClaim>>.GetConversionActionTo_TRAServiceType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAServiceType> ITypeConverter<List<TRAClaim>>.Enumerate_TRAServiceType(List<TRAClaim> value)
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
            List<TRAKeyValuePair> ITypeConverter<List<TRAKeyValuePair>>.ConvertFrom_bool(bool value)
            {
                
                throw new InvalidCastException("Invalid cast from 'bool' to 'List<TRAKeyValuePair>'.");
                
            }
            bool ITypeConverter<List<TRAKeyValuePair>>.ConvertTo_bool(List<TRAKeyValuePair> value)
            {
                return TypeConverter<bool>.ConvertFrom_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<TRAKeyValuePair>>.GetConversionActionTo_bool()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<bool> ITypeConverter<List<TRAKeyValuePair>>.Enumerate_bool(List<TRAKeyValuePair> value)
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
            List<TRAKeyValuePair> ITypeConverter<List<TRAKeyValuePair>>.ConvertFrom_TDWVDAAccountEntryContent(TDWVDAAccountEntryContent value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAAccountEntryContent' to 'List<TRAKeyValuePair>'.");
                
            }
            TDWVDAAccountEntryContent ITypeConverter<List<TRAKeyValuePair>>.ConvertTo_TDWVDAAccountEntryContent(List<TRAKeyValuePair> value)
            {
                return TypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<TRAKeyValuePair>>.GetConversionActionTo_TDWVDAAccountEntryContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryContent> ITypeConverter<List<TRAKeyValuePair>>.Enumerate_TDWVDAAccountEntryContent(List<TRAKeyValuePair> value)
            {
                
                yield break;
            }
            List<TRAKeyValuePair> ITypeConverter<List<TRAKeyValuePair>>.ConvertFrom_TDWVDAAccountEntryCore(TDWVDAAccountEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAAccountEntryCore' to 'List<TRAKeyValuePair>'.");
                
            }
            TDWVDAAccountEntryCore ITypeConverter<List<TRAKeyValuePair>>.ConvertTo_TDWVDAAccountEntryCore(List<TRAKeyValuePair> value)
            {
                return TypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<TRAKeyValuePair>>.GetConversionActionTo_TDWVDAAccountEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryCore> ITypeConverter<List<TRAKeyValuePair>>.Enumerate_TDWVDAAccountEntryCore(List<TRAKeyValuePair> value)
            {
                
                yield break;
            }
            List<TRAKeyValuePair> ITypeConverter<List<TRAKeyValuePair>>.ConvertFrom_TDWVDAIdentityRegistryEntry(TDWVDAIdentityRegistryEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAIdentityRegistryEntry' to 'List<TRAKeyValuePair>'.");
                
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<List<TRAKeyValuePair>>.ConvertTo_TDWVDAIdentityRegistryEntry(List<TRAKeyValuePair> value)
            {
                return TypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<TRAKeyValuePair>>.GetConversionActionTo_TDWVDAIdentityRegistryEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAIdentityRegistryEntry> ITypeConverter<List<TRAKeyValuePair>>.Enumerate_TDWVDAIdentityRegistryEntry(List<TRAKeyValuePair> value)
            {
                
                yield break;
            }
            List<TRAKeyValuePair> ITypeConverter<List<TRAKeyValuePair>>.ConvertFrom_TDWVDAPostInvocationParameters(TDWVDAPostInvocationParameters value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAPostInvocationParameters' to 'List<TRAKeyValuePair>'.");
                
            }
            TDWVDAPostInvocationParameters ITypeConverter<List<TRAKeyValuePair>>.ConvertTo_TDWVDAPostInvocationParameters(List<TRAKeyValuePair> value)
            {
                return TypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<TRAKeyValuePair>>.GetConversionActionTo_TDWVDAPostInvocationParameters()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAPostInvocationParameters> ITypeConverter<List<TRAKeyValuePair>>.Enumerate_TDWVDAPostInvocationParameters(List<TRAKeyValuePair> value)
            {
                
                yield break;
            }
            List<TRAKeyValuePair> ITypeConverter<List<TRAKeyValuePair>>.ConvertFrom_TDWVDARevocationListEntry(TDWVDARevocationListEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDARevocationListEntry' to 'List<TRAKeyValuePair>'.");
                
            }
            TDWVDARevocationListEntry ITypeConverter<List<TRAKeyValuePair>>.ConvertTo_TDWVDARevocationListEntry(List<TRAKeyValuePair> value)
            {
                return TypeConverter<TDWVDARevocationListEntry>.ConvertFrom_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<TRAKeyValuePair>>.GetConversionActionTo_TDWVDARevocationListEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDARevocationListEntry> ITypeConverter<List<TRAKeyValuePair>>.Enumerate_TDWVDARevocationListEntry(List<TRAKeyValuePair> value)
            {
                
                yield break;
            }
            List<TRAKeyValuePair> ITypeConverter<List<TRAKeyValuePair>>.ConvertFrom_TDWVDAServiceEndpointEntry(TDWVDAServiceEndpointEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAServiceEndpointEntry' to 'List<TRAKeyValuePair>'.");
                
            }
            TDWVDAServiceEndpointEntry ITypeConverter<List<TRAKeyValuePair>>.ConvertTo_TDWVDAServiceEndpointEntry(List<TRAKeyValuePair> value)
            {
                return TypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<TRAKeyValuePair>>.GetConversionActionTo_TDWVDAServiceEndpointEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAServiceEndpointEntry> ITypeConverter<List<TRAKeyValuePair>>.Enumerate_TDWVDAServiceEndpointEntry(List<TRAKeyValuePair> value)
            {
                
                yield break;
            }
            List<TRAKeyValuePair> ITypeConverter<List<TRAKeyValuePair>>.ConvertFrom_TDWVDASmartContractEntryCore(TDWVDASmartContractEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDASmartContractEntryCore' to 'List<TRAKeyValuePair>'.");
                
            }
            TDWVDASmartContractEntryCore ITypeConverter<List<TRAKeyValuePair>>.ConvertTo_TDWVDASmartContractEntryCore(List<TRAKeyValuePair> value)
            {
                return TypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<TRAKeyValuePair>>.GetConversionActionTo_TDWVDASmartContractEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDASmartContractEntryCore> ITypeConverter<List<TRAKeyValuePair>>.Enumerate_TDWVDASmartContractEntryCore(List<TRAKeyValuePair> value)
            {
                
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
            List<TRAKeyValuePair> ITypeConverter<List<TRAKeyValuePair>>.ConvertFrom_TRAServiceType(TRAServiceType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAServiceType' to 'List<TRAKeyValuePair>'.");
                
            }
            TRAServiceType ITypeConverter<List<TRAKeyValuePair>>.ConvertTo_TRAServiceType(List<TRAKeyValuePair> value)
            {
                return TypeConverter<TRAServiceType>.ConvertFrom_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<TRAKeyValuePair>>.GetConversionActionTo_TRAServiceType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAServiceType> ITypeConverter<List<TRAKeyValuePair>>.Enumerate_TRAServiceType(List<TRAKeyValuePair> value)
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
            TDWVDAAccountEntryContent ITypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_bool(bool value)
            {
                
                throw new InvalidCastException("Invalid cast from 'bool' to 'TDWVDAAccountEntryContent'.");
                
            }
            bool ITypeConverter<TDWVDAAccountEntryContent>.ConvertTo_bool(TDWVDAAccountEntryContent value)
            {
                return TypeConverter<bool>.ConvertFrom_TDWVDAAccountEntryContent(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryContent>.GetConversionActionTo_bool()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<bool> ITypeConverter<TDWVDAAccountEntryContent>.Enumerate_bool(TDWVDAAccountEntryContent value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryContent ITypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_long(long value)
            {
                
                throw new InvalidCastException("Invalid cast from 'long' to 'TDWVDAAccountEntryContent'.");
                
            }
            long ITypeConverter<TDWVDAAccountEntryContent>.ConvertTo_long(TDWVDAAccountEntryContent value)
            {
                return TypeConverter<long>.ConvertFrom_TDWVDAAccountEntryContent(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryContent>.GetConversionActionTo_long()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long> ITypeConverter<TDWVDAAccountEntryContent>.Enumerate_long(TDWVDAAccountEntryContent value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryContent ITypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    TDWVDAAccountEntryContent intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = TDWVDAAccountEntryContent.TryParse(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        Throw.cannot_parse(value, "TDWVDAAccountEntryContent");
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<TDWVDAAccountEntryContent>.ConvertTo_string(TDWVDAAccountEntryContent value)
            {
                return TypeConverter<string>.ConvertFrom_TDWVDAAccountEntryContent(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryContent>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<TDWVDAAccountEntryContent>.Enumerate_string(TDWVDAAccountEntryContent value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryContent ITypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_List_string(List<string> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<string>' to 'TDWVDAAccountEntryContent'.");
                
            }
            List<string> ITypeConverter<TDWVDAAccountEntryContent>.ConvertTo_List_string(TDWVDAAccountEntryContent value)
            {
                return TypeConverter<List<string>>.ConvertFrom_TDWVDAAccountEntryContent(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryContent>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_WRAPINLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<TDWVDAAccountEntryContent>.Enumerate_List_string(TDWVDAAccountEntryContent value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryContent ITypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_List_TRAClaim(List<TRAClaim> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<TRAClaim>' to 'TDWVDAAccountEntryContent'.");
                
            }
            List<TRAClaim> ITypeConverter<TDWVDAAccountEntryContent>.ConvertTo_List_TRAClaim(TDWVDAAccountEntryContent value)
            {
                return TypeConverter<List<TRAClaim>>.ConvertFrom_TDWVDAAccountEntryContent(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryContent>.GetConversionActionTo_List_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAClaim>> ITypeConverter<TDWVDAAccountEntryContent>.Enumerate_List_TRAClaim(TDWVDAAccountEntryContent value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryContent ITypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_List_TRAKeyValuePair(List<TRAKeyValuePair> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<TRAKeyValuePair>' to 'TDWVDAAccountEntryContent'.");
                
            }
            List<TRAKeyValuePair> ITypeConverter<TDWVDAAccountEntryContent>.ConvertTo_List_TRAKeyValuePair(TDWVDAAccountEntryContent value)
            {
                return TypeConverter<List<TRAKeyValuePair>>.ConvertFrom_TDWVDAAccountEntryContent(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryContent>.GetConversionActionTo_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAKeyValuePair>> ITypeConverter<TDWVDAAccountEntryContent>.Enumerate_List_TRAKeyValuePair(TDWVDAAccountEntryContent value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryContent ITypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_TDWVDAAccountEntryContent(TDWVDAAccountEntryContent value)
            {
                
                return (TDWVDAAccountEntryContent)value;
                
            }
            TDWVDAAccountEntryContent ITypeConverter<TDWVDAAccountEntryContent>.ConvertTo_TDWVDAAccountEntryContent(TDWVDAAccountEntryContent value)
            {
                return TypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_TDWVDAAccountEntryContent(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryContent>.GetConversionActionTo_TDWVDAAccountEntryContent()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryContent> ITypeConverter<TDWVDAAccountEntryContent>.Enumerate_TDWVDAAccountEntryContent(TDWVDAAccountEntryContent value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryContent ITypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_TDWVDAAccountEntryCore(TDWVDAAccountEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAAccountEntryCore' to 'TDWVDAAccountEntryContent'.");
                
            }
            TDWVDAAccountEntryCore ITypeConverter<TDWVDAAccountEntryContent>.ConvertTo_TDWVDAAccountEntryCore(TDWVDAAccountEntryContent value)
            {
                return TypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_TDWVDAAccountEntryContent(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryContent>.GetConversionActionTo_TDWVDAAccountEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryCore> ITypeConverter<TDWVDAAccountEntryContent>.Enumerate_TDWVDAAccountEntryCore(TDWVDAAccountEntryContent value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryContent ITypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_TDWVDAIdentityRegistryEntry(TDWVDAIdentityRegistryEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAIdentityRegistryEntry' to 'TDWVDAAccountEntryContent'.");
                
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<TDWVDAAccountEntryContent>.ConvertTo_TDWVDAIdentityRegistryEntry(TDWVDAAccountEntryContent value)
            {
                return TypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_TDWVDAAccountEntryContent(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryContent>.GetConversionActionTo_TDWVDAIdentityRegistryEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAIdentityRegistryEntry> ITypeConverter<TDWVDAAccountEntryContent>.Enumerate_TDWVDAIdentityRegistryEntry(TDWVDAAccountEntryContent value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryContent ITypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_TDWVDAPostInvocationParameters(TDWVDAPostInvocationParameters value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAPostInvocationParameters' to 'TDWVDAAccountEntryContent'.");
                
            }
            TDWVDAPostInvocationParameters ITypeConverter<TDWVDAAccountEntryContent>.ConvertTo_TDWVDAPostInvocationParameters(TDWVDAAccountEntryContent value)
            {
                return TypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_TDWVDAAccountEntryContent(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryContent>.GetConversionActionTo_TDWVDAPostInvocationParameters()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAPostInvocationParameters> ITypeConverter<TDWVDAAccountEntryContent>.Enumerate_TDWVDAPostInvocationParameters(TDWVDAAccountEntryContent value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryContent ITypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_TDWVDARevocationListEntry(TDWVDARevocationListEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDARevocationListEntry' to 'TDWVDAAccountEntryContent'.");
                
            }
            TDWVDARevocationListEntry ITypeConverter<TDWVDAAccountEntryContent>.ConvertTo_TDWVDARevocationListEntry(TDWVDAAccountEntryContent value)
            {
                return TypeConverter<TDWVDARevocationListEntry>.ConvertFrom_TDWVDAAccountEntryContent(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryContent>.GetConversionActionTo_TDWVDARevocationListEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDARevocationListEntry> ITypeConverter<TDWVDAAccountEntryContent>.Enumerate_TDWVDARevocationListEntry(TDWVDAAccountEntryContent value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryContent ITypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_TDWVDAServiceEndpointEntry(TDWVDAServiceEndpointEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAServiceEndpointEntry' to 'TDWVDAAccountEntryContent'.");
                
            }
            TDWVDAServiceEndpointEntry ITypeConverter<TDWVDAAccountEntryContent>.ConvertTo_TDWVDAServiceEndpointEntry(TDWVDAAccountEntryContent value)
            {
                return TypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_TDWVDAAccountEntryContent(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryContent>.GetConversionActionTo_TDWVDAServiceEndpointEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAServiceEndpointEntry> ITypeConverter<TDWVDAAccountEntryContent>.Enumerate_TDWVDAServiceEndpointEntry(TDWVDAAccountEntryContent value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryContent ITypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_TDWVDASmartContractEntryCore(TDWVDASmartContractEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDASmartContractEntryCore' to 'TDWVDAAccountEntryContent'.");
                
            }
            TDWVDASmartContractEntryCore ITypeConverter<TDWVDAAccountEntryContent>.ConvertTo_TDWVDASmartContractEntryCore(TDWVDAAccountEntryContent value)
            {
                return TypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_TDWVDAAccountEntryContent(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryContent>.GetConversionActionTo_TDWVDASmartContractEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDASmartContractEntryCore> ITypeConverter<TDWVDAAccountEntryContent>.Enumerate_TDWVDASmartContractEntryCore(TDWVDAAccountEntryContent value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryContent ITypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_TRAClaim(TRAClaim value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAClaim' to 'TDWVDAAccountEntryContent'.");
                
            }
            TRAClaim ITypeConverter<TDWVDAAccountEntryContent>.ConvertTo_TRAClaim(TDWVDAAccountEntryContent value)
            {
                return TypeConverter<TRAClaim>.ConvertFrom_TDWVDAAccountEntryContent(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryContent>.GetConversionActionTo_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAClaim> ITypeConverter<TDWVDAAccountEntryContent>.Enumerate_TRAClaim(TDWVDAAccountEntryContent value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryContent ITypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_TRACredentialContent(TRACredentialContent value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialContent' to 'TDWVDAAccountEntryContent'.");
                
            }
            TRACredentialContent ITypeConverter<TDWVDAAccountEntryContent>.ConvertTo_TRACredentialContent(TDWVDAAccountEntryContent value)
            {
                return TypeConverter<TRACredentialContent>.ConvertFrom_TDWVDAAccountEntryContent(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryContent>.GetConversionActionTo_TRACredentialContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialContent> ITypeConverter<TDWVDAAccountEntryContent>.Enumerate_TRACredentialContent(TDWVDAAccountEntryContent value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryContent ITypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_TRACredentialCore(TRACredentialCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialCore' to 'TDWVDAAccountEntryContent'.");
                
            }
            TRACredentialCore ITypeConverter<TDWVDAAccountEntryContent>.ConvertTo_TRACredentialCore(TDWVDAAccountEntryContent value)
            {
                return TypeConverter<TRACredentialCore>.ConvertFrom_TDWVDAAccountEntryContent(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryContent>.GetConversionActionTo_TRACredentialCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialCore> ITypeConverter<TDWVDAAccountEntryContent>.Enumerate_TRACredentialCore(TDWVDAAccountEntryContent value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryContent ITypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_TRACredentialEnvelope(TRACredentialEnvelope value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialEnvelope' to 'TDWVDAAccountEntryContent'.");
                
            }
            TRACredentialEnvelope ITypeConverter<TDWVDAAccountEntryContent>.ConvertTo_TRACredentialEnvelope(TDWVDAAccountEntryContent value)
            {
                return TypeConverter<TRACredentialEnvelope>.ConvertFrom_TDWVDAAccountEntryContent(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryContent>.GetConversionActionTo_TRACredentialEnvelope()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialEnvelope> ITypeConverter<TDWVDAAccountEntryContent>.Enumerate_TRACredentialEnvelope(TDWVDAAccountEntryContent value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryContent ITypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_TRACredentialWrapper(TRACredentialWrapper value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialWrapper' to 'TDWVDAAccountEntryContent'.");
                
            }
            TRACredentialWrapper ITypeConverter<TDWVDAAccountEntryContent>.ConvertTo_TRACredentialWrapper(TDWVDAAccountEntryContent value)
            {
                return TypeConverter<TRACredentialWrapper>.ConvertFrom_TDWVDAAccountEntryContent(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryContent>.GetConversionActionTo_TRACredentialWrapper()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialWrapper> ITypeConverter<TDWVDAAccountEntryContent>.Enumerate_TRACredentialWrapper(TDWVDAAccountEntryContent value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryContent ITypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_TRAKeyValuePair(TRAKeyValuePair value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAKeyValuePair' to 'TDWVDAAccountEntryContent'.");
                
            }
            TRAKeyValuePair ITypeConverter<TDWVDAAccountEntryContent>.ConvertTo_TRAKeyValuePair(TDWVDAAccountEntryContent value)
            {
                return TypeConverter<TRAKeyValuePair>.ConvertFrom_TDWVDAAccountEntryContent(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryContent>.GetConversionActionTo_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAKeyValuePair> ITypeConverter<TDWVDAAccountEntryContent>.Enumerate_TRAKeyValuePair(TDWVDAAccountEntryContent value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryContent ITypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_TRACredentialType(TRACredentialType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialType' to 'TDWVDAAccountEntryContent'.");
                
            }
            TRACredentialType ITypeConverter<TDWVDAAccountEntryContent>.ConvertTo_TRACredentialType(TDWVDAAccountEntryContent value)
            {
                return TypeConverter<TRACredentialType>.ConvertFrom_TDWVDAAccountEntryContent(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryContent>.GetConversionActionTo_TRACredentialType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialType> ITypeConverter<TDWVDAAccountEntryContent>.Enumerate_TRACredentialType(TDWVDAAccountEntryContent value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryContent ITypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_TRAEncryptionFlag(TRAEncryptionFlag value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAEncryptionFlag' to 'TDWVDAAccountEntryContent'.");
                
            }
            TRAEncryptionFlag ITypeConverter<TDWVDAAccountEntryContent>.ConvertTo_TRAEncryptionFlag(TDWVDAAccountEntryContent value)
            {
                return TypeConverter<TRAEncryptionFlag>.ConvertFrom_TDWVDAAccountEntryContent(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryContent>.GetConversionActionTo_TRAEncryptionFlag()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEncryptionFlag> ITypeConverter<TDWVDAAccountEntryContent>.Enumerate_TRAEncryptionFlag(TDWVDAAccountEntryContent value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryContent ITypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_TRAServiceType(TRAServiceType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAServiceType' to 'TDWVDAAccountEntryContent'.");
                
            }
            TRAServiceType ITypeConverter<TDWVDAAccountEntryContent>.ConvertTo_TRAServiceType(TDWVDAAccountEntryContent value)
            {
                return TypeConverter<TRAServiceType>.ConvertFrom_TDWVDAAccountEntryContent(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryContent>.GetConversionActionTo_TRAServiceType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAServiceType> ITypeConverter<TDWVDAAccountEntryContent>.Enumerate_TRAServiceType(TDWVDAAccountEntryContent value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryContent ITypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_TRATrustLevel(TRATrustLevel value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRATrustLevel' to 'TDWVDAAccountEntryContent'.");
                
            }
            TRATrustLevel ITypeConverter<TDWVDAAccountEntryContent>.ConvertTo_TRATrustLevel(TDWVDAAccountEntryContent value)
            {
                return TypeConverter<TRATrustLevel>.ConvertFrom_TDWVDAAccountEntryContent(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryContent>.GetConversionActionTo_TRATrustLevel()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRATrustLevel> ITypeConverter<TDWVDAAccountEntryContent>.Enumerate_TRATrustLevel(TDWVDAAccountEntryContent value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryContent ITypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_List_List_TRAKeyValuePair(List<List<TRAKeyValuePair>> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<List<TRAKeyValuePair>>' to 'TDWVDAAccountEntryContent'.");
                
            }
            List<List<TRAKeyValuePair>> ITypeConverter<TDWVDAAccountEntryContent>.ConvertTo_List_List_TRAKeyValuePair(TDWVDAAccountEntryContent value)
            {
                return TypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_TDWVDAAccountEntryContent(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryContent>.GetConversionActionTo_List_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<List<TRAKeyValuePair>>> ITypeConverter<TDWVDAAccountEntryContent>.Enumerate_List_List_TRAKeyValuePair(TDWVDAAccountEntryContent value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryCore ITypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_bool(bool value)
            {
                
                throw new InvalidCastException("Invalid cast from 'bool' to 'TDWVDAAccountEntryCore'.");
                
            }
            bool ITypeConverter<TDWVDAAccountEntryCore>.ConvertTo_bool(TDWVDAAccountEntryCore value)
            {
                return TypeConverter<bool>.ConvertFrom_TDWVDAAccountEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryCore>.GetConversionActionTo_bool()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<bool> ITypeConverter<TDWVDAAccountEntryCore>.Enumerate_bool(TDWVDAAccountEntryCore value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryCore ITypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_long(long value)
            {
                
                throw new InvalidCastException("Invalid cast from 'long' to 'TDWVDAAccountEntryCore'.");
                
            }
            long ITypeConverter<TDWVDAAccountEntryCore>.ConvertTo_long(TDWVDAAccountEntryCore value)
            {
                return TypeConverter<long>.ConvertFrom_TDWVDAAccountEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryCore>.GetConversionActionTo_long()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long> ITypeConverter<TDWVDAAccountEntryCore>.Enumerate_long(TDWVDAAccountEntryCore value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryCore ITypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    TDWVDAAccountEntryCore intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = TDWVDAAccountEntryCore.TryParse(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        Throw.cannot_parse(value, "TDWVDAAccountEntryCore");
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<TDWVDAAccountEntryCore>.ConvertTo_string(TDWVDAAccountEntryCore value)
            {
                return TypeConverter<string>.ConvertFrom_TDWVDAAccountEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryCore>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<TDWVDAAccountEntryCore>.Enumerate_string(TDWVDAAccountEntryCore value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryCore ITypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_List_string(List<string> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<string>' to 'TDWVDAAccountEntryCore'.");
                
            }
            List<string> ITypeConverter<TDWVDAAccountEntryCore>.ConvertTo_List_string(TDWVDAAccountEntryCore value)
            {
                return TypeConverter<List<string>>.ConvertFrom_TDWVDAAccountEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryCore>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_WRAPINLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<TDWVDAAccountEntryCore>.Enumerate_List_string(TDWVDAAccountEntryCore value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryCore ITypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_List_TRAClaim(List<TRAClaim> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<TRAClaim>' to 'TDWVDAAccountEntryCore'.");
                
            }
            List<TRAClaim> ITypeConverter<TDWVDAAccountEntryCore>.ConvertTo_List_TRAClaim(TDWVDAAccountEntryCore value)
            {
                return TypeConverter<List<TRAClaim>>.ConvertFrom_TDWVDAAccountEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryCore>.GetConversionActionTo_List_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAClaim>> ITypeConverter<TDWVDAAccountEntryCore>.Enumerate_List_TRAClaim(TDWVDAAccountEntryCore value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryCore ITypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_List_TRAKeyValuePair(List<TRAKeyValuePair> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<TRAKeyValuePair>' to 'TDWVDAAccountEntryCore'.");
                
            }
            List<TRAKeyValuePair> ITypeConverter<TDWVDAAccountEntryCore>.ConvertTo_List_TRAKeyValuePair(TDWVDAAccountEntryCore value)
            {
                return TypeConverter<List<TRAKeyValuePair>>.ConvertFrom_TDWVDAAccountEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryCore>.GetConversionActionTo_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAKeyValuePair>> ITypeConverter<TDWVDAAccountEntryCore>.Enumerate_List_TRAKeyValuePair(TDWVDAAccountEntryCore value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryCore ITypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_TDWVDAAccountEntryContent(TDWVDAAccountEntryContent value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAAccountEntryContent' to 'TDWVDAAccountEntryCore'.");
                
            }
            TDWVDAAccountEntryContent ITypeConverter<TDWVDAAccountEntryCore>.ConvertTo_TDWVDAAccountEntryContent(TDWVDAAccountEntryCore value)
            {
                return TypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_TDWVDAAccountEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryCore>.GetConversionActionTo_TDWVDAAccountEntryContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryContent> ITypeConverter<TDWVDAAccountEntryCore>.Enumerate_TDWVDAAccountEntryContent(TDWVDAAccountEntryCore value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryCore ITypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_TDWVDAAccountEntryCore(TDWVDAAccountEntryCore value)
            {
                
                return (TDWVDAAccountEntryCore)value;
                
            }
            TDWVDAAccountEntryCore ITypeConverter<TDWVDAAccountEntryCore>.ConvertTo_TDWVDAAccountEntryCore(TDWVDAAccountEntryCore value)
            {
                return TypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_TDWVDAAccountEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryCore>.GetConversionActionTo_TDWVDAAccountEntryCore()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryCore> ITypeConverter<TDWVDAAccountEntryCore>.Enumerate_TDWVDAAccountEntryCore(TDWVDAAccountEntryCore value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryCore ITypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_TDWVDAIdentityRegistryEntry(TDWVDAIdentityRegistryEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAIdentityRegistryEntry' to 'TDWVDAAccountEntryCore'.");
                
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<TDWVDAAccountEntryCore>.ConvertTo_TDWVDAIdentityRegistryEntry(TDWVDAAccountEntryCore value)
            {
                return TypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_TDWVDAAccountEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryCore>.GetConversionActionTo_TDWVDAIdentityRegistryEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAIdentityRegistryEntry> ITypeConverter<TDWVDAAccountEntryCore>.Enumerate_TDWVDAIdentityRegistryEntry(TDWVDAAccountEntryCore value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryCore ITypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_TDWVDAPostInvocationParameters(TDWVDAPostInvocationParameters value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAPostInvocationParameters' to 'TDWVDAAccountEntryCore'.");
                
            }
            TDWVDAPostInvocationParameters ITypeConverter<TDWVDAAccountEntryCore>.ConvertTo_TDWVDAPostInvocationParameters(TDWVDAAccountEntryCore value)
            {
                return TypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_TDWVDAAccountEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryCore>.GetConversionActionTo_TDWVDAPostInvocationParameters()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAPostInvocationParameters> ITypeConverter<TDWVDAAccountEntryCore>.Enumerate_TDWVDAPostInvocationParameters(TDWVDAAccountEntryCore value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryCore ITypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_TDWVDARevocationListEntry(TDWVDARevocationListEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDARevocationListEntry' to 'TDWVDAAccountEntryCore'.");
                
            }
            TDWVDARevocationListEntry ITypeConverter<TDWVDAAccountEntryCore>.ConvertTo_TDWVDARevocationListEntry(TDWVDAAccountEntryCore value)
            {
                return TypeConverter<TDWVDARevocationListEntry>.ConvertFrom_TDWVDAAccountEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryCore>.GetConversionActionTo_TDWVDARevocationListEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDARevocationListEntry> ITypeConverter<TDWVDAAccountEntryCore>.Enumerate_TDWVDARevocationListEntry(TDWVDAAccountEntryCore value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryCore ITypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_TDWVDAServiceEndpointEntry(TDWVDAServiceEndpointEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAServiceEndpointEntry' to 'TDWVDAAccountEntryCore'.");
                
            }
            TDWVDAServiceEndpointEntry ITypeConverter<TDWVDAAccountEntryCore>.ConvertTo_TDWVDAServiceEndpointEntry(TDWVDAAccountEntryCore value)
            {
                return TypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_TDWVDAAccountEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryCore>.GetConversionActionTo_TDWVDAServiceEndpointEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAServiceEndpointEntry> ITypeConverter<TDWVDAAccountEntryCore>.Enumerate_TDWVDAServiceEndpointEntry(TDWVDAAccountEntryCore value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryCore ITypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_TDWVDASmartContractEntryCore(TDWVDASmartContractEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDASmartContractEntryCore' to 'TDWVDAAccountEntryCore'.");
                
            }
            TDWVDASmartContractEntryCore ITypeConverter<TDWVDAAccountEntryCore>.ConvertTo_TDWVDASmartContractEntryCore(TDWVDAAccountEntryCore value)
            {
                return TypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_TDWVDAAccountEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryCore>.GetConversionActionTo_TDWVDASmartContractEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDASmartContractEntryCore> ITypeConverter<TDWVDAAccountEntryCore>.Enumerate_TDWVDASmartContractEntryCore(TDWVDAAccountEntryCore value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryCore ITypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_TRAClaim(TRAClaim value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAClaim' to 'TDWVDAAccountEntryCore'.");
                
            }
            TRAClaim ITypeConverter<TDWVDAAccountEntryCore>.ConvertTo_TRAClaim(TDWVDAAccountEntryCore value)
            {
                return TypeConverter<TRAClaim>.ConvertFrom_TDWVDAAccountEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryCore>.GetConversionActionTo_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAClaim> ITypeConverter<TDWVDAAccountEntryCore>.Enumerate_TRAClaim(TDWVDAAccountEntryCore value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryCore ITypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_TRACredentialContent(TRACredentialContent value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialContent' to 'TDWVDAAccountEntryCore'.");
                
            }
            TRACredentialContent ITypeConverter<TDWVDAAccountEntryCore>.ConvertTo_TRACredentialContent(TDWVDAAccountEntryCore value)
            {
                return TypeConverter<TRACredentialContent>.ConvertFrom_TDWVDAAccountEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryCore>.GetConversionActionTo_TRACredentialContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialContent> ITypeConverter<TDWVDAAccountEntryCore>.Enumerate_TRACredentialContent(TDWVDAAccountEntryCore value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryCore ITypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_TRACredentialCore(TRACredentialCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialCore' to 'TDWVDAAccountEntryCore'.");
                
            }
            TRACredentialCore ITypeConverter<TDWVDAAccountEntryCore>.ConvertTo_TRACredentialCore(TDWVDAAccountEntryCore value)
            {
                return TypeConverter<TRACredentialCore>.ConvertFrom_TDWVDAAccountEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryCore>.GetConversionActionTo_TRACredentialCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialCore> ITypeConverter<TDWVDAAccountEntryCore>.Enumerate_TRACredentialCore(TDWVDAAccountEntryCore value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryCore ITypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_TRACredentialEnvelope(TRACredentialEnvelope value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialEnvelope' to 'TDWVDAAccountEntryCore'.");
                
            }
            TRACredentialEnvelope ITypeConverter<TDWVDAAccountEntryCore>.ConvertTo_TRACredentialEnvelope(TDWVDAAccountEntryCore value)
            {
                return TypeConverter<TRACredentialEnvelope>.ConvertFrom_TDWVDAAccountEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryCore>.GetConversionActionTo_TRACredentialEnvelope()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialEnvelope> ITypeConverter<TDWVDAAccountEntryCore>.Enumerate_TRACredentialEnvelope(TDWVDAAccountEntryCore value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryCore ITypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_TRACredentialWrapper(TRACredentialWrapper value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialWrapper' to 'TDWVDAAccountEntryCore'.");
                
            }
            TRACredentialWrapper ITypeConverter<TDWVDAAccountEntryCore>.ConvertTo_TRACredentialWrapper(TDWVDAAccountEntryCore value)
            {
                return TypeConverter<TRACredentialWrapper>.ConvertFrom_TDWVDAAccountEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryCore>.GetConversionActionTo_TRACredentialWrapper()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialWrapper> ITypeConverter<TDWVDAAccountEntryCore>.Enumerate_TRACredentialWrapper(TDWVDAAccountEntryCore value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryCore ITypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_TRAKeyValuePair(TRAKeyValuePair value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAKeyValuePair' to 'TDWVDAAccountEntryCore'.");
                
            }
            TRAKeyValuePair ITypeConverter<TDWVDAAccountEntryCore>.ConvertTo_TRAKeyValuePair(TDWVDAAccountEntryCore value)
            {
                return TypeConverter<TRAKeyValuePair>.ConvertFrom_TDWVDAAccountEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryCore>.GetConversionActionTo_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAKeyValuePair> ITypeConverter<TDWVDAAccountEntryCore>.Enumerate_TRAKeyValuePair(TDWVDAAccountEntryCore value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryCore ITypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_TRACredentialType(TRACredentialType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialType' to 'TDWVDAAccountEntryCore'.");
                
            }
            TRACredentialType ITypeConverter<TDWVDAAccountEntryCore>.ConvertTo_TRACredentialType(TDWVDAAccountEntryCore value)
            {
                return TypeConverter<TRACredentialType>.ConvertFrom_TDWVDAAccountEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryCore>.GetConversionActionTo_TRACredentialType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialType> ITypeConverter<TDWVDAAccountEntryCore>.Enumerate_TRACredentialType(TDWVDAAccountEntryCore value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryCore ITypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_TRAEncryptionFlag(TRAEncryptionFlag value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAEncryptionFlag' to 'TDWVDAAccountEntryCore'.");
                
            }
            TRAEncryptionFlag ITypeConverter<TDWVDAAccountEntryCore>.ConvertTo_TRAEncryptionFlag(TDWVDAAccountEntryCore value)
            {
                return TypeConverter<TRAEncryptionFlag>.ConvertFrom_TDWVDAAccountEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryCore>.GetConversionActionTo_TRAEncryptionFlag()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEncryptionFlag> ITypeConverter<TDWVDAAccountEntryCore>.Enumerate_TRAEncryptionFlag(TDWVDAAccountEntryCore value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryCore ITypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_TRAServiceType(TRAServiceType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAServiceType' to 'TDWVDAAccountEntryCore'.");
                
            }
            TRAServiceType ITypeConverter<TDWVDAAccountEntryCore>.ConvertTo_TRAServiceType(TDWVDAAccountEntryCore value)
            {
                return TypeConverter<TRAServiceType>.ConvertFrom_TDWVDAAccountEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryCore>.GetConversionActionTo_TRAServiceType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAServiceType> ITypeConverter<TDWVDAAccountEntryCore>.Enumerate_TRAServiceType(TDWVDAAccountEntryCore value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryCore ITypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_TRATrustLevel(TRATrustLevel value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRATrustLevel' to 'TDWVDAAccountEntryCore'.");
                
            }
            TRATrustLevel ITypeConverter<TDWVDAAccountEntryCore>.ConvertTo_TRATrustLevel(TDWVDAAccountEntryCore value)
            {
                return TypeConverter<TRATrustLevel>.ConvertFrom_TDWVDAAccountEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryCore>.GetConversionActionTo_TRATrustLevel()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRATrustLevel> ITypeConverter<TDWVDAAccountEntryCore>.Enumerate_TRATrustLevel(TDWVDAAccountEntryCore value)
            {
                
                yield break;
            }
            TDWVDAAccountEntryCore ITypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_List_List_TRAKeyValuePair(List<List<TRAKeyValuePair>> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<List<TRAKeyValuePair>>' to 'TDWVDAAccountEntryCore'.");
                
            }
            List<List<TRAKeyValuePair>> ITypeConverter<TDWVDAAccountEntryCore>.ConvertTo_List_List_TRAKeyValuePair(TDWVDAAccountEntryCore value)
            {
                return TypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_TDWVDAAccountEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryCore>.GetConversionActionTo_List_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<List<TRAKeyValuePair>>> ITypeConverter<TDWVDAAccountEntryCore>.Enumerate_List_List_TRAKeyValuePair(TDWVDAAccountEntryCore value)
            {
                
                yield break;
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_bool(bool value)
            {
                
                throw new InvalidCastException("Invalid cast from 'bool' to 'TDWVDAIdentityRegistryEntry'.");
                
            }
            bool ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertTo_bool(TDWVDAIdentityRegistryEntry value)
            {
                return TypeConverter<bool>.ConvertFrom_TDWVDAIdentityRegistryEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAIdentityRegistryEntry>.GetConversionActionTo_bool()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<bool> ITypeConverter<TDWVDAIdentityRegistryEntry>.Enumerate_bool(TDWVDAIdentityRegistryEntry value)
            {
                
                yield break;
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_long(long value)
            {
                
                throw new InvalidCastException("Invalid cast from 'long' to 'TDWVDAIdentityRegistryEntry'.");
                
            }
            long ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertTo_long(TDWVDAIdentityRegistryEntry value)
            {
                return TypeConverter<long>.ConvertFrom_TDWVDAIdentityRegistryEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAIdentityRegistryEntry>.GetConversionActionTo_long()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long> ITypeConverter<TDWVDAIdentityRegistryEntry>.Enumerate_long(TDWVDAIdentityRegistryEntry value)
            {
                
                yield break;
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    TDWVDAIdentityRegistryEntry intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = TDWVDAIdentityRegistryEntry.TryParse(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        Throw.cannot_parse(value, "TDWVDAIdentityRegistryEntry");
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertTo_string(TDWVDAIdentityRegistryEntry value)
            {
                return TypeConverter<string>.ConvertFrom_TDWVDAIdentityRegistryEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAIdentityRegistryEntry>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<TDWVDAIdentityRegistryEntry>.Enumerate_string(TDWVDAIdentityRegistryEntry value)
            {
                
                yield break;
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_List_string(List<string> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<string>' to 'TDWVDAIdentityRegistryEntry'.");
                
            }
            List<string> ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertTo_List_string(TDWVDAIdentityRegistryEntry value)
            {
                return TypeConverter<List<string>>.ConvertFrom_TDWVDAIdentityRegistryEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAIdentityRegistryEntry>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_WRAPINLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<TDWVDAIdentityRegistryEntry>.Enumerate_List_string(TDWVDAIdentityRegistryEntry value)
            {
                
                yield break;
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_List_TRAClaim(List<TRAClaim> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<TRAClaim>' to 'TDWVDAIdentityRegistryEntry'.");
                
            }
            List<TRAClaim> ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertTo_List_TRAClaim(TDWVDAIdentityRegistryEntry value)
            {
                return TypeConverter<List<TRAClaim>>.ConvertFrom_TDWVDAIdentityRegistryEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAIdentityRegistryEntry>.GetConversionActionTo_List_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAClaim>> ITypeConverter<TDWVDAIdentityRegistryEntry>.Enumerate_List_TRAClaim(TDWVDAIdentityRegistryEntry value)
            {
                
                yield break;
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_List_TRAKeyValuePair(List<TRAKeyValuePair> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<TRAKeyValuePair>' to 'TDWVDAIdentityRegistryEntry'.");
                
            }
            List<TRAKeyValuePair> ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertTo_List_TRAKeyValuePair(TDWVDAIdentityRegistryEntry value)
            {
                return TypeConverter<List<TRAKeyValuePair>>.ConvertFrom_TDWVDAIdentityRegistryEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAIdentityRegistryEntry>.GetConversionActionTo_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAKeyValuePair>> ITypeConverter<TDWVDAIdentityRegistryEntry>.Enumerate_List_TRAKeyValuePair(TDWVDAIdentityRegistryEntry value)
            {
                
                yield break;
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_TDWVDAAccountEntryContent(TDWVDAAccountEntryContent value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAAccountEntryContent' to 'TDWVDAIdentityRegistryEntry'.");
                
            }
            TDWVDAAccountEntryContent ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertTo_TDWVDAAccountEntryContent(TDWVDAIdentityRegistryEntry value)
            {
                return TypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_TDWVDAIdentityRegistryEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAIdentityRegistryEntry>.GetConversionActionTo_TDWVDAAccountEntryContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryContent> ITypeConverter<TDWVDAIdentityRegistryEntry>.Enumerate_TDWVDAAccountEntryContent(TDWVDAIdentityRegistryEntry value)
            {
                
                yield break;
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_TDWVDAAccountEntryCore(TDWVDAAccountEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAAccountEntryCore' to 'TDWVDAIdentityRegistryEntry'.");
                
            }
            TDWVDAAccountEntryCore ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertTo_TDWVDAAccountEntryCore(TDWVDAIdentityRegistryEntry value)
            {
                return TypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_TDWVDAIdentityRegistryEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAIdentityRegistryEntry>.GetConversionActionTo_TDWVDAAccountEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryCore> ITypeConverter<TDWVDAIdentityRegistryEntry>.Enumerate_TDWVDAAccountEntryCore(TDWVDAIdentityRegistryEntry value)
            {
                
                yield break;
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_TDWVDAIdentityRegistryEntry(TDWVDAIdentityRegistryEntry value)
            {
                
                return (TDWVDAIdentityRegistryEntry)value;
                
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertTo_TDWVDAIdentityRegistryEntry(TDWVDAIdentityRegistryEntry value)
            {
                return TypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_TDWVDAIdentityRegistryEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAIdentityRegistryEntry>.GetConversionActionTo_TDWVDAIdentityRegistryEntry()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAIdentityRegistryEntry> ITypeConverter<TDWVDAIdentityRegistryEntry>.Enumerate_TDWVDAIdentityRegistryEntry(TDWVDAIdentityRegistryEntry value)
            {
                
                yield break;
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_TDWVDAPostInvocationParameters(TDWVDAPostInvocationParameters value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAPostInvocationParameters' to 'TDWVDAIdentityRegistryEntry'.");
                
            }
            TDWVDAPostInvocationParameters ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertTo_TDWVDAPostInvocationParameters(TDWVDAIdentityRegistryEntry value)
            {
                return TypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_TDWVDAIdentityRegistryEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAIdentityRegistryEntry>.GetConversionActionTo_TDWVDAPostInvocationParameters()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAPostInvocationParameters> ITypeConverter<TDWVDAIdentityRegistryEntry>.Enumerate_TDWVDAPostInvocationParameters(TDWVDAIdentityRegistryEntry value)
            {
                
                yield break;
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_TDWVDARevocationListEntry(TDWVDARevocationListEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDARevocationListEntry' to 'TDWVDAIdentityRegistryEntry'.");
                
            }
            TDWVDARevocationListEntry ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertTo_TDWVDARevocationListEntry(TDWVDAIdentityRegistryEntry value)
            {
                return TypeConverter<TDWVDARevocationListEntry>.ConvertFrom_TDWVDAIdentityRegistryEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAIdentityRegistryEntry>.GetConversionActionTo_TDWVDARevocationListEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDARevocationListEntry> ITypeConverter<TDWVDAIdentityRegistryEntry>.Enumerate_TDWVDARevocationListEntry(TDWVDAIdentityRegistryEntry value)
            {
                
                yield break;
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_TDWVDAServiceEndpointEntry(TDWVDAServiceEndpointEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAServiceEndpointEntry' to 'TDWVDAIdentityRegistryEntry'.");
                
            }
            TDWVDAServiceEndpointEntry ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertTo_TDWVDAServiceEndpointEntry(TDWVDAIdentityRegistryEntry value)
            {
                return TypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_TDWVDAIdentityRegistryEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAIdentityRegistryEntry>.GetConversionActionTo_TDWVDAServiceEndpointEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAServiceEndpointEntry> ITypeConverter<TDWVDAIdentityRegistryEntry>.Enumerate_TDWVDAServiceEndpointEntry(TDWVDAIdentityRegistryEntry value)
            {
                
                yield break;
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_TDWVDASmartContractEntryCore(TDWVDASmartContractEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDASmartContractEntryCore' to 'TDWVDAIdentityRegistryEntry'.");
                
            }
            TDWVDASmartContractEntryCore ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertTo_TDWVDASmartContractEntryCore(TDWVDAIdentityRegistryEntry value)
            {
                return TypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_TDWVDAIdentityRegistryEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAIdentityRegistryEntry>.GetConversionActionTo_TDWVDASmartContractEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDASmartContractEntryCore> ITypeConverter<TDWVDAIdentityRegistryEntry>.Enumerate_TDWVDASmartContractEntryCore(TDWVDAIdentityRegistryEntry value)
            {
                
                yield break;
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_TRAClaim(TRAClaim value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAClaim' to 'TDWVDAIdentityRegistryEntry'.");
                
            }
            TRAClaim ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertTo_TRAClaim(TDWVDAIdentityRegistryEntry value)
            {
                return TypeConverter<TRAClaim>.ConvertFrom_TDWVDAIdentityRegistryEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAIdentityRegistryEntry>.GetConversionActionTo_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAClaim> ITypeConverter<TDWVDAIdentityRegistryEntry>.Enumerate_TRAClaim(TDWVDAIdentityRegistryEntry value)
            {
                
                yield break;
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_TRACredentialContent(TRACredentialContent value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialContent' to 'TDWVDAIdentityRegistryEntry'.");
                
            }
            TRACredentialContent ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertTo_TRACredentialContent(TDWVDAIdentityRegistryEntry value)
            {
                return TypeConverter<TRACredentialContent>.ConvertFrom_TDWVDAIdentityRegistryEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAIdentityRegistryEntry>.GetConversionActionTo_TRACredentialContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialContent> ITypeConverter<TDWVDAIdentityRegistryEntry>.Enumerate_TRACredentialContent(TDWVDAIdentityRegistryEntry value)
            {
                
                yield break;
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_TRACredentialCore(TRACredentialCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialCore' to 'TDWVDAIdentityRegistryEntry'.");
                
            }
            TRACredentialCore ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertTo_TRACredentialCore(TDWVDAIdentityRegistryEntry value)
            {
                return TypeConverter<TRACredentialCore>.ConvertFrom_TDWVDAIdentityRegistryEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAIdentityRegistryEntry>.GetConversionActionTo_TRACredentialCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialCore> ITypeConverter<TDWVDAIdentityRegistryEntry>.Enumerate_TRACredentialCore(TDWVDAIdentityRegistryEntry value)
            {
                
                yield break;
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_TRACredentialEnvelope(TRACredentialEnvelope value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialEnvelope' to 'TDWVDAIdentityRegistryEntry'.");
                
            }
            TRACredentialEnvelope ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertTo_TRACredentialEnvelope(TDWVDAIdentityRegistryEntry value)
            {
                return TypeConverter<TRACredentialEnvelope>.ConvertFrom_TDWVDAIdentityRegistryEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAIdentityRegistryEntry>.GetConversionActionTo_TRACredentialEnvelope()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialEnvelope> ITypeConverter<TDWVDAIdentityRegistryEntry>.Enumerate_TRACredentialEnvelope(TDWVDAIdentityRegistryEntry value)
            {
                
                yield break;
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_TRACredentialWrapper(TRACredentialWrapper value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialWrapper' to 'TDWVDAIdentityRegistryEntry'.");
                
            }
            TRACredentialWrapper ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertTo_TRACredentialWrapper(TDWVDAIdentityRegistryEntry value)
            {
                return TypeConverter<TRACredentialWrapper>.ConvertFrom_TDWVDAIdentityRegistryEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAIdentityRegistryEntry>.GetConversionActionTo_TRACredentialWrapper()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialWrapper> ITypeConverter<TDWVDAIdentityRegistryEntry>.Enumerate_TRACredentialWrapper(TDWVDAIdentityRegistryEntry value)
            {
                
                yield break;
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_TRAKeyValuePair(TRAKeyValuePair value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAKeyValuePair' to 'TDWVDAIdentityRegistryEntry'.");
                
            }
            TRAKeyValuePair ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertTo_TRAKeyValuePair(TDWVDAIdentityRegistryEntry value)
            {
                return TypeConverter<TRAKeyValuePair>.ConvertFrom_TDWVDAIdentityRegistryEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAIdentityRegistryEntry>.GetConversionActionTo_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAKeyValuePair> ITypeConverter<TDWVDAIdentityRegistryEntry>.Enumerate_TRAKeyValuePair(TDWVDAIdentityRegistryEntry value)
            {
                
                yield break;
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_TRACredentialType(TRACredentialType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialType' to 'TDWVDAIdentityRegistryEntry'.");
                
            }
            TRACredentialType ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertTo_TRACredentialType(TDWVDAIdentityRegistryEntry value)
            {
                return TypeConverter<TRACredentialType>.ConvertFrom_TDWVDAIdentityRegistryEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAIdentityRegistryEntry>.GetConversionActionTo_TRACredentialType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialType> ITypeConverter<TDWVDAIdentityRegistryEntry>.Enumerate_TRACredentialType(TDWVDAIdentityRegistryEntry value)
            {
                
                yield break;
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_TRAEncryptionFlag(TRAEncryptionFlag value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAEncryptionFlag' to 'TDWVDAIdentityRegistryEntry'.");
                
            }
            TRAEncryptionFlag ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertTo_TRAEncryptionFlag(TDWVDAIdentityRegistryEntry value)
            {
                return TypeConverter<TRAEncryptionFlag>.ConvertFrom_TDWVDAIdentityRegistryEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAIdentityRegistryEntry>.GetConversionActionTo_TRAEncryptionFlag()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEncryptionFlag> ITypeConverter<TDWVDAIdentityRegistryEntry>.Enumerate_TRAEncryptionFlag(TDWVDAIdentityRegistryEntry value)
            {
                
                yield break;
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_TRAServiceType(TRAServiceType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAServiceType' to 'TDWVDAIdentityRegistryEntry'.");
                
            }
            TRAServiceType ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertTo_TRAServiceType(TDWVDAIdentityRegistryEntry value)
            {
                return TypeConverter<TRAServiceType>.ConvertFrom_TDWVDAIdentityRegistryEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAIdentityRegistryEntry>.GetConversionActionTo_TRAServiceType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAServiceType> ITypeConverter<TDWVDAIdentityRegistryEntry>.Enumerate_TRAServiceType(TDWVDAIdentityRegistryEntry value)
            {
                
                yield break;
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_TRATrustLevel(TRATrustLevel value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRATrustLevel' to 'TDWVDAIdentityRegistryEntry'.");
                
            }
            TRATrustLevel ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertTo_TRATrustLevel(TDWVDAIdentityRegistryEntry value)
            {
                return TypeConverter<TRATrustLevel>.ConvertFrom_TDWVDAIdentityRegistryEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAIdentityRegistryEntry>.GetConversionActionTo_TRATrustLevel()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRATrustLevel> ITypeConverter<TDWVDAIdentityRegistryEntry>.Enumerate_TRATrustLevel(TDWVDAIdentityRegistryEntry value)
            {
                
                yield break;
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_List_List_TRAKeyValuePair(List<List<TRAKeyValuePair>> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<List<TRAKeyValuePair>>' to 'TDWVDAIdentityRegistryEntry'.");
                
            }
            List<List<TRAKeyValuePair>> ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertTo_List_List_TRAKeyValuePair(TDWVDAIdentityRegistryEntry value)
            {
                return TypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_TDWVDAIdentityRegistryEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAIdentityRegistryEntry>.GetConversionActionTo_List_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<List<TRAKeyValuePair>>> ITypeConverter<TDWVDAIdentityRegistryEntry>.Enumerate_List_List_TRAKeyValuePair(TDWVDAIdentityRegistryEntry value)
            {
                
                yield break;
            }
            TDWVDAPostInvocationParameters ITypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_bool(bool value)
            {
                
                throw new InvalidCastException("Invalid cast from 'bool' to 'TDWVDAPostInvocationParameters'.");
                
            }
            bool ITypeConverter<TDWVDAPostInvocationParameters>.ConvertTo_bool(TDWVDAPostInvocationParameters value)
            {
                return TypeConverter<bool>.ConvertFrom_TDWVDAPostInvocationParameters(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAPostInvocationParameters>.GetConversionActionTo_bool()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<bool> ITypeConverter<TDWVDAPostInvocationParameters>.Enumerate_bool(TDWVDAPostInvocationParameters value)
            {
                
                yield break;
            }
            TDWVDAPostInvocationParameters ITypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_long(long value)
            {
                
                throw new InvalidCastException("Invalid cast from 'long' to 'TDWVDAPostInvocationParameters'.");
                
            }
            long ITypeConverter<TDWVDAPostInvocationParameters>.ConvertTo_long(TDWVDAPostInvocationParameters value)
            {
                return TypeConverter<long>.ConvertFrom_TDWVDAPostInvocationParameters(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAPostInvocationParameters>.GetConversionActionTo_long()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long> ITypeConverter<TDWVDAPostInvocationParameters>.Enumerate_long(TDWVDAPostInvocationParameters value)
            {
                
                yield break;
            }
            TDWVDAPostInvocationParameters ITypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    TDWVDAPostInvocationParameters intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = TDWVDAPostInvocationParameters.TryParse(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        Throw.cannot_parse(value, "TDWVDAPostInvocationParameters");
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<TDWVDAPostInvocationParameters>.ConvertTo_string(TDWVDAPostInvocationParameters value)
            {
                return TypeConverter<string>.ConvertFrom_TDWVDAPostInvocationParameters(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAPostInvocationParameters>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<TDWVDAPostInvocationParameters>.Enumerate_string(TDWVDAPostInvocationParameters value)
            {
                
                yield break;
            }
            TDWVDAPostInvocationParameters ITypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_List_string(List<string> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<string>' to 'TDWVDAPostInvocationParameters'.");
                
            }
            List<string> ITypeConverter<TDWVDAPostInvocationParameters>.ConvertTo_List_string(TDWVDAPostInvocationParameters value)
            {
                return TypeConverter<List<string>>.ConvertFrom_TDWVDAPostInvocationParameters(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAPostInvocationParameters>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_WRAPINLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<TDWVDAPostInvocationParameters>.Enumerate_List_string(TDWVDAPostInvocationParameters value)
            {
                
                yield break;
            }
            TDWVDAPostInvocationParameters ITypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_List_TRAClaim(List<TRAClaim> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<TRAClaim>' to 'TDWVDAPostInvocationParameters'.");
                
            }
            List<TRAClaim> ITypeConverter<TDWVDAPostInvocationParameters>.ConvertTo_List_TRAClaim(TDWVDAPostInvocationParameters value)
            {
                return TypeConverter<List<TRAClaim>>.ConvertFrom_TDWVDAPostInvocationParameters(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAPostInvocationParameters>.GetConversionActionTo_List_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAClaim>> ITypeConverter<TDWVDAPostInvocationParameters>.Enumerate_List_TRAClaim(TDWVDAPostInvocationParameters value)
            {
                
                yield break;
            }
            TDWVDAPostInvocationParameters ITypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_List_TRAKeyValuePair(List<TRAKeyValuePair> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<TRAKeyValuePair>' to 'TDWVDAPostInvocationParameters'.");
                
            }
            List<TRAKeyValuePair> ITypeConverter<TDWVDAPostInvocationParameters>.ConvertTo_List_TRAKeyValuePair(TDWVDAPostInvocationParameters value)
            {
                return TypeConverter<List<TRAKeyValuePair>>.ConvertFrom_TDWVDAPostInvocationParameters(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAPostInvocationParameters>.GetConversionActionTo_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAKeyValuePair>> ITypeConverter<TDWVDAPostInvocationParameters>.Enumerate_List_TRAKeyValuePair(TDWVDAPostInvocationParameters value)
            {
                
                yield break;
            }
            TDWVDAPostInvocationParameters ITypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_TDWVDAAccountEntryContent(TDWVDAAccountEntryContent value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAAccountEntryContent' to 'TDWVDAPostInvocationParameters'.");
                
            }
            TDWVDAAccountEntryContent ITypeConverter<TDWVDAPostInvocationParameters>.ConvertTo_TDWVDAAccountEntryContent(TDWVDAPostInvocationParameters value)
            {
                return TypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_TDWVDAPostInvocationParameters(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAPostInvocationParameters>.GetConversionActionTo_TDWVDAAccountEntryContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryContent> ITypeConverter<TDWVDAPostInvocationParameters>.Enumerate_TDWVDAAccountEntryContent(TDWVDAPostInvocationParameters value)
            {
                
                yield break;
            }
            TDWVDAPostInvocationParameters ITypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_TDWVDAAccountEntryCore(TDWVDAAccountEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAAccountEntryCore' to 'TDWVDAPostInvocationParameters'.");
                
            }
            TDWVDAAccountEntryCore ITypeConverter<TDWVDAPostInvocationParameters>.ConvertTo_TDWVDAAccountEntryCore(TDWVDAPostInvocationParameters value)
            {
                return TypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_TDWVDAPostInvocationParameters(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAPostInvocationParameters>.GetConversionActionTo_TDWVDAAccountEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryCore> ITypeConverter<TDWVDAPostInvocationParameters>.Enumerate_TDWVDAAccountEntryCore(TDWVDAPostInvocationParameters value)
            {
                
                yield break;
            }
            TDWVDAPostInvocationParameters ITypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_TDWVDAIdentityRegistryEntry(TDWVDAIdentityRegistryEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAIdentityRegistryEntry' to 'TDWVDAPostInvocationParameters'.");
                
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<TDWVDAPostInvocationParameters>.ConvertTo_TDWVDAIdentityRegistryEntry(TDWVDAPostInvocationParameters value)
            {
                return TypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_TDWVDAPostInvocationParameters(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAPostInvocationParameters>.GetConversionActionTo_TDWVDAIdentityRegistryEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAIdentityRegistryEntry> ITypeConverter<TDWVDAPostInvocationParameters>.Enumerate_TDWVDAIdentityRegistryEntry(TDWVDAPostInvocationParameters value)
            {
                
                yield break;
            }
            TDWVDAPostInvocationParameters ITypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_TDWVDAPostInvocationParameters(TDWVDAPostInvocationParameters value)
            {
                
                return (TDWVDAPostInvocationParameters)value;
                
            }
            TDWVDAPostInvocationParameters ITypeConverter<TDWVDAPostInvocationParameters>.ConvertTo_TDWVDAPostInvocationParameters(TDWVDAPostInvocationParameters value)
            {
                return TypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_TDWVDAPostInvocationParameters(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAPostInvocationParameters>.GetConversionActionTo_TDWVDAPostInvocationParameters()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAPostInvocationParameters> ITypeConverter<TDWVDAPostInvocationParameters>.Enumerate_TDWVDAPostInvocationParameters(TDWVDAPostInvocationParameters value)
            {
                
                yield break;
            }
            TDWVDAPostInvocationParameters ITypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_TDWVDARevocationListEntry(TDWVDARevocationListEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDARevocationListEntry' to 'TDWVDAPostInvocationParameters'.");
                
            }
            TDWVDARevocationListEntry ITypeConverter<TDWVDAPostInvocationParameters>.ConvertTo_TDWVDARevocationListEntry(TDWVDAPostInvocationParameters value)
            {
                return TypeConverter<TDWVDARevocationListEntry>.ConvertFrom_TDWVDAPostInvocationParameters(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAPostInvocationParameters>.GetConversionActionTo_TDWVDARevocationListEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDARevocationListEntry> ITypeConverter<TDWVDAPostInvocationParameters>.Enumerate_TDWVDARevocationListEntry(TDWVDAPostInvocationParameters value)
            {
                
                yield break;
            }
            TDWVDAPostInvocationParameters ITypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_TDWVDAServiceEndpointEntry(TDWVDAServiceEndpointEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAServiceEndpointEntry' to 'TDWVDAPostInvocationParameters'.");
                
            }
            TDWVDAServiceEndpointEntry ITypeConverter<TDWVDAPostInvocationParameters>.ConvertTo_TDWVDAServiceEndpointEntry(TDWVDAPostInvocationParameters value)
            {
                return TypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_TDWVDAPostInvocationParameters(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAPostInvocationParameters>.GetConversionActionTo_TDWVDAServiceEndpointEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAServiceEndpointEntry> ITypeConverter<TDWVDAPostInvocationParameters>.Enumerate_TDWVDAServiceEndpointEntry(TDWVDAPostInvocationParameters value)
            {
                
                yield break;
            }
            TDWVDAPostInvocationParameters ITypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_TDWVDASmartContractEntryCore(TDWVDASmartContractEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDASmartContractEntryCore' to 'TDWVDAPostInvocationParameters'.");
                
            }
            TDWVDASmartContractEntryCore ITypeConverter<TDWVDAPostInvocationParameters>.ConvertTo_TDWVDASmartContractEntryCore(TDWVDAPostInvocationParameters value)
            {
                return TypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_TDWVDAPostInvocationParameters(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAPostInvocationParameters>.GetConversionActionTo_TDWVDASmartContractEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDASmartContractEntryCore> ITypeConverter<TDWVDAPostInvocationParameters>.Enumerate_TDWVDASmartContractEntryCore(TDWVDAPostInvocationParameters value)
            {
                
                yield break;
            }
            TDWVDAPostInvocationParameters ITypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_TRAClaim(TRAClaim value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAClaim' to 'TDWVDAPostInvocationParameters'.");
                
            }
            TRAClaim ITypeConverter<TDWVDAPostInvocationParameters>.ConvertTo_TRAClaim(TDWVDAPostInvocationParameters value)
            {
                return TypeConverter<TRAClaim>.ConvertFrom_TDWVDAPostInvocationParameters(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAPostInvocationParameters>.GetConversionActionTo_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAClaim> ITypeConverter<TDWVDAPostInvocationParameters>.Enumerate_TRAClaim(TDWVDAPostInvocationParameters value)
            {
                
                yield break;
            }
            TDWVDAPostInvocationParameters ITypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_TRACredentialContent(TRACredentialContent value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialContent' to 'TDWVDAPostInvocationParameters'.");
                
            }
            TRACredentialContent ITypeConverter<TDWVDAPostInvocationParameters>.ConvertTo_TRACredentialContent(TDWVDAPostInvocationParameters value)
            {
                return TypeConverter<TRACredentialContent>.ConvertFrom_TDWVDAPostInvocationParameters(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAPostInvocationParameters>.GetConversionActionTo_TRACredentialContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialContent> ITypeConverter<TDWVDAPostInvocationParameters>.Enumerate_TRACredentialContent(TDWVDAPostInvocationParameters value)
            {
                
                yield break;
            }
            TDWVDAPostInvocationParameters ITypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_TRACredentialCore(TRACredentialCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialCore' to 'TDWVDAPostInvocationParameters'.");
                
            }
            TRACredentialCore ITypeConverter<TDWVDAPostInvocationParameters>.ConvertTo_TRACredentialCore(TDWVDAPostInvocationParameters value)
            {
                return TypeConverter<TRACredentialCore>.ConvertFrom_TDWVDAPostInvocationParameters(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAPostInvocationParameters>.GetConversionActionTo_TRACredentialCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialCore> ITypeConverter<TDWVDAPostInvocationParameters>.Enumerate_TRACredentialCore(TDWVDAPostInvocationParameters value)
            {
                
                yield break;
            }
            TDWVDAPostInvocationParameters ITypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_TRACredentialEnvelope(TRACredentialEnvelope value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialEnvelope' to 'TDWVDAPostInvocationParameters'.");
                
            }
            TRACredentialEnvelope ITypeConverter<TDWVDAPostInvocationParameters>.ConvertTo_TRACredentialEnvelope(TDWVDAPostInvocationParameters value)
            {
                return TypeConverter<TRACredentialEnvelope>.ConvertFrom_TDWVDAPostInvocationParameters(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAPostInvocationParameters>.GetConversionActionTo_TRACredentialEnvelope()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialEnvelope> ITypeConverter<TDWVDAPostInvocationParameters>.Enumerate_TRACredentialEnvelope(TDWVDAPostInvocationParameters value)
            {
                
                yield break;
            }
            TDWVDAPostInvocationParameters ITypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_TRACredentialWrapper(TRACredentialWrapper value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialWrapper' to 'TDWVDAPostInvocationParameters'.");
                
            }
            TRACredentialWrapper ITypeConverter<TDWVDAPostInvocationParameters>.ConvertTo_TRACredentialWrapper(TDWVDAPostInvocationParameters value)
            {
                return TypeConverter<TRACredentialWrapper>.ConvertFrom_TDWVDAPostInvocationParameters(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAPostInvocationParameters>.GetConversionActionTo_TRACredentialWrapper()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialWrapper> ITypeConverter<TDWVDAPostInvocationParameters>.Enumerate_TRACredentialWrapper(TDWVDAPostInvocationParameters value)
            {
                
                yield break;
            }
            TDWVDAPostInvocationParameters ITypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_TRAKeyValuePair(TRAKeyValuePair value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAKeyValuePair' to 'TDWVDAPostInvocationParameters'.");
                
            }
            TRAKeyValuePair ITypeConverter<TDWVDAPostInvocationParameters>.ConvertTo_TRAKeyValuePair(TDWVDAPostInvocationParameters value)
            {
                return TypeConverter<TRAKeyValuePair>.ConvertFrom_TDWVDAPostInvocationParameters(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAPostInvocationParameters>.GetConversionActionTo_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAKeyValuePair> ITypeConverter<TDWVDAPostInvocationParameters>.Enumerate_TRAKeyValuePair(TDWVDAPostInvocationParameters value)
            {
                
                yield break;
            }
            TDWVDAPostInvocationParameters ITypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_TRACredentialType(TRACredentialType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialType' to 'TDWVDAPostInvocationParameters'.");
                
            }
            TRACredentialType ITypeConverter<TDWVDAPostInvocationParameters>.ConvertTo_TRACredentialType(TDWVDAPostInvocationParameters value)
            {
                return TypeConverter<TRACredentialType>.ConvertFrom_TDWVDAPostInvocationParameters(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAPostInvocationParameters>.GetConversionActionTo_TRACredentialType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialType> ITypeConverter<TDWVDAPostInvocationParameters>.Enumerate_TRACredentialType(TDWVDAPostInvocationParameters value)
            {
                
                yield break;
            }
            TDWVDAPostInvocationParameters ITypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_TRAEncryptionFlag(TRAEncryptionFlag value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAEncryptionFlag' to 'TDWVDAPostInvocationParameters'.");
                
            }
            TRAEncryptionFlag ITypeConverter<TDWVDAPostInvocationParameters>.ConvertTo_TRAEncryptionFlag(TDWVDAPostInvocationParameters value)
            {
                return TypeConverter<TRAEncryptionFlag>.ConvertFrom_TDWVDAPostInvocationParameters(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAPostInvocationParameters>.GetConversionActionTo_TRAEncryptionFlag()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEncryptionFlag> ITypeConverter<TDWVDAPostInvocationParameters>.Enumerate_TRAEncryptionFlag(TDWVDAPostInvocationParameters value)
            {
                
                yield break;
            }
            TDWVDAPostInvocationParameters ITypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_TRAServiceType(TRAServiceType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAServiceType' to 'TDWVDAPostInvocationParameters'.");
                
            }
            TRAServiceType ITypeConverter<TDWVDAPostInvocationParameters>.ConvertTo_TRAServiceType(TDWVDAPostInvocationParameters value)
            {
                return TypeConverter<TRAServiceType>.ConvertFrom_TDWVDAPostInvocationParameters(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAPostInvocationParameters>.GetConversionActionTo_TRAServiceType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAServiceType> ITypeConverter<TDWVDAPostInvocationParameters>.Enumerate_TRAServiceType(TDWVDAPostInvocationParameters value)
            {
                
                yield break;
            }
            TDWVDAPostInvocationParameters ITypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_TRATrustLevel(TRATrustLevel value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRATrustLevel' to 'TDWVDAPostInvocationParameters'.");
                
            }
            TRATrustLevel ITypeConverter<TDWVDAPostInvocationParameters>.ConvertTo_TRATrustLevel(TDWVDAPostInvocationParameters value)
            {
                return TypeConverter<TRATrustLevel>.ConvertFrom_TDWVDAPostInvocationParameters(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAPostInvocationParameters>.GetConversionActionTo_TRATrustLevel()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRATrustLevel> ITypeConverter<TDWVDAPostInvocationParameters>.Enumerate_TRATrustLevel(TDWVDAPostInvocationParameters value)
            {
                
                yield break;
            }
            TDWVDAPostInvocationParameters ITypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_List_List_TRAKeyValuePair(List<List<TRAKeyValuePair>> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<List<TRAKeyValuePair>>' to 'TDWVDAPostInvocationParameters'.");
                
            }
            List<List<TRAKeyValuePair>> ITypeConverter<TDWVDAPostInvocationParameters>.ConvertTo_List_List_TRAKeyValuePair(TDWVDAPostInvocationParameters value)
            {
                return TypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_TDWVDAPostInvocationParameters(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAPostInvocationParameters>.GetConversionActionTo_List_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<List<TRAKeyValuePair>>> ITypeConverter<TDWVDAPostInvocationParameters>.Enumerate_List_List_TRAKeyValuePair(TDWVDAPostInvocationParameters value)
            {
                
                yield break;
            }
            TDWVDARevocationListEntry ITypeConverter<TDWVDARevocationListEntry>.ConvertFrom_bool(bool value)
            {
                
                throw new InvalidCastException("Invalid cast from 'bool' to 'TDWVDARevocationListEntry'.");
                
            }
            bool ITypeConverter<TDWVDARevocationListEntry>.ConvertTo_bool(TDWVDARevocationListEntry value)
            {
                return TypeConverter<bool>.ConvertFrom_TDWVDARevocationListEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDARevocationListEntry>.GetConversionActionTo_bool()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<bool> ITypeConverter<TDWVDARevocationListEntry>.Enumerate_bool(TDWVDARevocationListEntry value)
            {
                
                yield break;
            }
            TDWVDARevocationListEntry ITypeConverter<TDWVDARevocationListEntry>.ConvertFrom_long(long value)
            {
                
                throw new InvalidCastException("Invalid cast from 'long' to 'TDWVDARevocationListEntry'.");
                
            }
            long ITypeConverter<TDWVDARevocationListEntry>.ConvertTo_long(TDWVDARevocationListEntry value)
            {
                return TypeConverter<long>.ConvertFrom_TDWVDARevocationListEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDARevocationListEntry>.GetConversionActionTo_long()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long> ITypeConverter<TDWVDARevocationListEntry>.Enumerate_long(TDWVDARevocationListEntry value)
            {
                
                yield break;
            }
            TDWVDARevocationListEntry ITypeConverter<TDWVDARevocationListEntry>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    TDWVDARevocationListEntry intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = TDWVDARevocationListEntry.TryParse(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        Throw.cannot_parse(value, "TDWVDARevocationListEntry");
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<TDWVDARevocationListEntry>.ConvertTo_string(TDWVDARevocationListEntry value)
            {
                return TypeConverter<string>.ConvertFrom_TDWVDARevocationListEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDARevocationListEntry>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<TDWVDARevocationListEntry>.Enumerate_string(TDWVDARevocationListEntry value)
            {
                
                yield break;
            }
            TDWVDARevocationListEntry ITypeConverter<TDWVDARevocationListEntry>.ConvertFrom_List_string(List<string> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<string>' to 'TDWVDARevocationListEntry'.");
                
            }
            List<string> ITypeConverter<TDWVDARevocationListEntry>.ConvertTo_List_string(TDWVDARevocationListEntry value)
            {
                return TypeConverter<List<string>>.ConvertFrom_TDWVDARevocationListEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDARevocationListEntry>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_WRAPINLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<TDWVDARevocationListEntry>.Enumerate_List_string(TDWVDARevocationListEntry value)
            {
                
                yield break;
            }
            TDWVDARevocationListEntry ITypeConverter<TDWVDARevocationListEntry>.ConvertFrom_List_TRAClaim(List<TRAClaim> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<TRAClaim>' to 'TDWVDARevocationListEntry'.");
                
            }
            List<TRAClaim> ITypeConverter<TDWVDARevocationListEntry>.ConvertTo_List_TRAClaim(TDWVDARevocationListEntry value)
            {
                return TypeConverter<List<TRAClaim>>.ConvertFrom_TDWVDARevocationListEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDARevocationListEntry>.GetConversionActionTo_List_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAClaim>> ITypeConverter<TDWVDARevocationListEntry>.Enumerate_List_TRAClaim(TDWVDARevocationListEntry value)
            {
                
                yield break;
            }
            TDWVDARevocationListEntry ITypeConverter<TDWVDARevocationListEntry>.ConvertFrom_List_TRAKeyValuePair(List<TRAKeyValuePair> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<TRAKeyValuePair>' to 'TDWVDARevocationListEntry'.");
                
            }
            List<TRAKeyValuePair> ITypeConverter<TDWVDARevocationListEntry>.ConvertTo_List_TRAKeyValuePair(TDWVDARevocationListEntry value)
            {
                return TypeConverter<List<TRAKeyValuePair>>.ConvertFrom_TDWVDARevocationListEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDARevocationListEntry>.GetConversionActionTo_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAKeyValuePair>> ITypeConverter<TDWVDARevocationListEntry>.Enumerate_List_TRAKeyValuePair(TDWVDARevocationListEntry value)
            {
                
                yield break;
            }
            TDWVDARevocationListEntry ITypeConverter<TDWVDARevocationListEntry>.ConvertFrom_TDWVDAAccountEntryContent(TDWVDAAccountEntryContent value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAAccountEntryContent' to 'TDWVDARevocationListEntry'.");
                
            }
            TDWVDAAccountEntryContent ITypeConverter<TDWVDARevocationListEntry>.ConvertTo_TDWVDAAccountEntryContent(TDWVDARevocationListEntry value)
            {
                return TypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_TDWVDARevocationListEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDARevocationListEntry>.GetConversionActionTo_TDWVDAAccountEntryContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryContent> ITypeConverter<TDWVDARevocationListEntry>.Enumerate_TDWVDAAccountEntryContent(TDWVDARevocationListEntry value)
            {
                
                yield break;
            }
            TDWVDARevocationListEntry ITypeConverter<TDWVDARevocationListEntry>.ConvertFrom_TDWVDAAccountEntryCore(TDWVDAAccountEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAAccountEntryCore' to 'TDWVDARevocationListEntry'.");
                
            }
            TDWVDAAccountEntryCore ITypeConverter<TDWVDARevocationListEntry>.ConvertTo_TDWVDAAccountEntryCore(TDWVDARevocationListEntry value)
            {
                return TypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_TDWVDARevocationListEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDARevocationListEntry>.GetConversionActionTo_TDWVDAAccountEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryCore> ITypeConverter<TDWVDARevocationListEntry>.Enumerate_TDWVDAAccountEntryCore(TDWVDARevocationListEntry value)
            {
                
                yield break;
            }
            TDWVDARevocationListEntry ITypeConverter<TDWVDARevocationListEntry>.ConvertFrom_TDWVDAIdentityRegistryEntry(TDWVDAIdentityRegistryEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAIdentityRegistryEntry' to 'TDWVDARevocationListEntry'.");
                
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<TDWVDARevocationListEntry>.ConvertTo_TDWVDAIdentityRegistryEntry(TDWVDARevocationListEntry value)
            {
                return TypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_TDWVDARevocationListEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDARevocationListEntry>.GetConversionActionTo_TDWVDAIdentityRegistryEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAIdentityRegistryEntry> ITypeConverter<TDWVDARevocationListEntry>.Enumerate_TDWVDAIdentityRegistryEntry(TDWVDARevocationListEntry value)
            {
                
                yield break;
            }
            TDWVDARevocationListEntry ITypeConverter<TDWVDARevocationListEntry>.ConvertFrom_TDWVDAPostInvocationParameters(TDWVDAPostInvocationParameters value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAPostInvocationParameters' to 'TDWVDARevocationListEntry'.");
                
            }
            TDWVDAPostInvocationParameters ITypeConverter<TDWVDARevocationListEntry>.ConvertTo_TDWVDAPostInvocationParameters(TDWVDARevocationListEntry value)
            {
                return TypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_TDWVDARevocationListEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDARevocationListEntry>.GetConversionActionTo_TDWVDAPostInvocationParameters()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAPostInvocationParameters> ITypeConverter<TDWVDARevocationListEntry>.Enumerate_TDWVDAPostInvocationParameters(TDWVDARevocationListEntry value)
            {
                
                yield break;
            }
            TDWVDARevocationListEntry ITypeConverter<TDWVDARevocationListEntry>.ConvertFrom_TDWVDARevocationListEntry(TDWVDARevocationListEntry value)
            {
                
                return (TDWVDARevocationListEntry)value;
                
            }
            TDWVDARevocationListEntry ITypeConverter<TDWVDARevocationListEntry>.ConvertTo_TDWVDARevocationListEntry(TDWVDARevocationListEntry value)
            {
                return TypeConverter<TDWVDARevocationListEntry>.ConvertFrom_TDWVDARevocationListEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDARevocationListEntry>.GetConversionActionTo_TDWVDARevocationListEntry()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDARevocationListEntry> ITypeConverter<TDWVDARevocationListEntry>.Enumerate_TDWVDARevocationListEntry(TDWVDARevocationListEntry value)
            {
                
                yield break;
            }
            TDWVDARevocationListEntry ITypeConverter<TDWVDARevocationListEntry>.ConvertFrom_TDWVDAServiceEndpointEntry(TDWVDAServiceEndpointEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAServiceEndpointEntry' to 'TDWVDARevocationListEntry'.");
                
            }
            TDWVDAServiceEndpointEntry ITypeConverter<TDWVDARevocationListEntry>.ConvertTo_TDWVDAServiceEndpointEntry(TDWVDARevocationListEntry value)
            {
                return TypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_TDWVDARevocationListEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDARevocationListEntry>.GetConversionActionTo_TDWVDAServiceEndpointEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAServiceEndpointEntry> ITypeConverter<TDWVDARevocationListEntry>.Enumerate_TDWVDAServiceEndpointEntry(TDWVDARevocationListEntry value)
            {
                
                yield break;
            }
            TDWVDARevocationListEntry ITypeConverter<TDWVDARevocationListEntry>.ConvertFrom_TDWVDASmartContractEntryCore(TDWVDASmartContractEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDASmartContractEntryCore' to 'TDWVDARevocationListEntry'.");
                
            }
            TDWVDASmartContractEntryCore ITypeConverter<TDWVDARevocationListEntry>.ConvertTo_TDWVDASmartContractEntryCore(TDWVDARevocationListEntry value)
            {
                return TypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_TDWVDARevocationListEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDARevocationListEntry>.GetConversionActionTo_TDWVDASmartContractEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDASmartContractEntryCore> ITypeConverter<TDWVDARevocationListEntry>.Enumerate_TDWVDASmartContractEntryCore(TDWVDARevocationListEntry value)
            {
                
                yield break;
            }
            TDWVDARevocationListEntry ITypeConverter<TDWVDARevocationListEntry>.ConvertFrom_TRAClaim(TRAClaim value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAClaim' to 'TDWVDARevocationListEntry'.");
                
            }
            TRAClaim ITypeConverter<TDWVDARevocationListEntry>.ConvertTo_TRAClaim(TDWVDARevocationListEntry value)
            {
                return TypeConverter<TRAClaim>.ConvertFrom_TDWVDARevocationListEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDARevocationListEntry>.GetConversionActionTo_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAClaim> ITypeConverter<TDWVDARevocationListEntry>.Enumerate_TRAClaim(TDWVDARevocationListEntry value)
            {
                
                yield break;
            }
            TDWVDARevocationListEntry ITypeConverter<TDWVDARevocationListEntry>.ConvertFrom_TRACredentialContent(TRACredentialContent value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialContent' to 'TDWVDARevocationListEntry'.");
                
            }
            TRACredentialContent ITypeConverter<TDWVDARevocationListEntry>.ConvertTo_TRACredentialContent(TDWVDARevocationListEntry value)
            {
                return TypeConverter<TRACredentialContent>.ConvertFrom_TDWVDARevocationListEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDARevocationListEntry>.GetConversionActionTo_TRACredentialContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialContent> ITypeConverter<TDWVDARevocationListEntry>.Enumerate_TRACredentialContent(TDWVDARevocationListEntry value)
            {
                
                yield break;
            }
            TDWVDARevocationListEntry ITypeConverter<TDWVDARevocationListEntry>.ConvertFrom_TRACredentialCore(TRACredentialCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialCore' to 'TDWVDARevocationListEntry'.");
                
            }
            TRACredentialCore ITypeConverter<TDWVDARevocationListEntry>.ConvertTo_TRACredentialCore(TDWVDARevocationListEntry value)
            {
                return TypeConverter<TRACredentialCore>.ConvertFrom_TDWVDARevocationListEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDARevocationListEntry>.GetConversionActionTo_TRACredentialCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialCore> ITypeConverter<TDWVDARevocationListEntry>.Enumerate_TRACredentialCore(TDWVDARevocationListEntry value)
            {
                
                yield break;
            }
            TDWVDARevocationListEntry ITypeConverter<TDWVDARevocationListEntry>.ConvertFrom_TRACredentialEnvelope(TRACredentialEnvelope value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialEnvelope' to 'TDWVDARevocationListEntry'.");
                
            }
            TRACredentialEnvelope ITypeConverter<TDWVDARevocationListEntry>.ConvertTo_TRACredentialEnvelope(TDWVDARevocationListEntry value)
            {
                return TypeConverter<TRACredentialEnvelope>.ConvertFrom_TDWVDARevocationListEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDARevocationListEntry>.GetConversionActionTo_TRACredentialEnvelope()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialEnvelope> ITypeConverter<TDWVDARevocationListEntry>.Enumerate_TRACredentialEnvelope(TDWVDARevocationListEntry value)
            {
                
                yield break;
            }
            TDWVDARevocationListEntry ITypeConverter<TDWVDARevocationListEntry>.ConvertFrom_TRACredentialWrapper(TRACredentialWrapper value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialWrapper' to 'TDWVDARevocationListEntry'.");
                
            }
            TRACredentialWrapper ITypeConverter<TDWVDARevocationListEntry>.ConvertTo_TRACredentialWrapper(TDWVDARevocationListEntry value)
            {
                return TypeConverter<TRACredentialWrapper>.ConvertFrom_TDWVDARevocationListEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDARevocationListEntry>.GetConversionActionTo_TRACredentialWrapper()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialWrapper> ITypeConverter<TDWVDARevocationListEntry>.Enumerate_TRACredentialWrapper(TDWVDARevocationListEntry value)
            {
                
                yield break;
            }
            TDWVDARevocationListEntry ITypeConverter<TDWVDARevocationListEntry>.ConvertFrom_TRAKeyValuePair(TRAKeyValuePair value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAKeyValuePair' to 'TDWVDARevocationListEntry'.");
                
            }
            TRAKeyValuePair ITypeConverter<TDWVDARevocationListEntry>.ConvertTo_TRAKeyValuePair(TDWVDARevocationListEntry value)
            {
                return TypeConverter<TRAKeyValuePair>.ConvertFrom_TDWVDARevocationListEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDARevocationListEntry>.GetConversionActionTo_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAKeyValuePair> ITypeConverter<TDWVDARevocationListEntry>.Enumerate_TRAKeyValuePair(TDWVDARevocationListEntry value)
            {
                
                yield break;
            }
            TDWVDARevocationListEntry ITypeConverter<TDWVDARevocationListEntry>.ConvertFrom_TRACredentialType(TRACredentialType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialType' to 'TDWVDARevocationListEntry'.");
                
            }
            TRACredentialType ITypeConverter<TDWVDARevocationListEntry>.ConvertTo_TRACredentialType(TDWVDARevocationListEntry value)
            {
                return TypeConverter<TRACredentialType>.ConvertFrom_TDWVDARevocationListEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDARevocationListEntry>.GetConversionActionTo_TRACredentialType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialType> ITypeConverter<TDWVDARevocationListEntry>.Enumerate_TRACredentialType(TDWVDARevocationListEntry value)
            {
                
                yield break;
            }
            TDWVDARevocationListEntry ITypeConverter<TDWVDARevocationListEntry>.ConvertFrom_TRAEncryptionFlag(TRAEncryptionFlag value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAEncryptionFlag' to 'TDWVDARevocationListEntry'.");
                
            }
            TRAEncryptionFlag ITypeConverter<TDWVDARevocationListEntry>.ConvertTo_TRAEncryptionFlag(TDWVDARevocationListEntry value)
            {
                return TypeConverter<TRAEncryptionFlag>.ConvertFrom_TDWVDARevocationListEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDARevocationListEntry>.GetConversionActionTo_TRAEncryptionFlag()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEncryptionFlag> ITypeConverter<TDWVDARevocationListEntry>.Enumerate_TRAEncryptionFlag(TDWVDARevocationListEntry value)
            {
                
                yield break;
            }
            TDWVDARevocationListEntry ITypeConverter<TDWVDARevocationListEntry>.ConvertFrom_TRAServiceType(TRAServiceType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAServiceType' to 'TDWVDARevocationListEntry'.");
                
            }
            TRAServiceType ITypeConverter<TDWVDARevocationListEntry>.ConvertTo_TRAServiceType(TDWVDARevocationListEntry value)
            {
                return TypeConverter<TRAServiceType>.ConvertFrom_TDWVDARevocationListEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDARevocationListEntry>.GetConversionActionTo_TRAServiceType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAServiceType> ITypeConverter<TDWVDARevocationListEntry>.Enumerate_TRAServiceType(TDWVDARevocationListEntry value)
            {
                
                yield break;
            }
            TDWVDARevocationListEntry ITypeConverter<TDWVDARevocationListEntry>.ConvertFrom_TRATrustLevel(TRATrustLevel value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRATrustLevel' to 'TDWVDARevocationListEntry'.");
                
            }
            TRATrustLevel ITypeConverter<TDWVDARevocationListEntry>.ConvertTo_TRATrustLevel(TDWVDARevocationListEntry value)
            {
                return TypeConverter<TRATrustLevel>.ConvertFrom_TDWVDARevocationListEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDARevocationListEntry>.GetConversionActionTo_TRATrustLevel()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRATrustLevel> ITypeConverter<TDWVDARevocationListEntry>.Enumerate_TRATrustLevel(TDWVDARevocationListEntry value)
            {
                
                yield break;
            }
            TDWVDARevocationListEntry ITypeConverter<TDWVDARevocationListEntry>.ConvertFrom_List_List_TRAKeyValuePair(List<List<TRAKeyValuePair>> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<List<TRAKeyValuePair>>' to 'TDWVDARevocationListEntry'.");
                
            }
            List<List<TRAKeyValuePair>> ITypeConverter<TDWVDARevocationListEntry>.ConvertTo_List_List_TRAKeyValuePair(TDWVDARevocationListEntry value)
            {
                return TypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_TDWVDARevocationListEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDARevocationListEntry>.GetConversionActionTo_List_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<List<TRAKeyValuePair>>> ITypeConverter<TDWVDARevocationListEntry>.Enumerate_List_List_TRAKeyValuePair(TDWVDARevocationListEntry value)
            {
                
                yield break;
            }
            TDWVDAServiceEndpointEntry ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_bool(bool value)
            {
                
                throw new InvalidCastException("Invalid cast from 'bool' to 'TDWVDAServiceEndpointEntry'.");
                
            }
            bool ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertTo_bool(TDWVDAServiceEndpointEntry value)
            {
                return TypeConverter<bool>.ConvertFrom_TDWVDAServiceEndpointEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAServiceEndpointEntry>.GetConversionActionTo_bool()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<bool> ITypeConverter<TDWVDAServiceEndpointEntry>.Enumerate_bool(TDWVDAServiceEndpointEntry value)
            {
                
                yield break;
            }
            TDWVDAServiceEndpointEntry ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_long(long value)
            {
                
                throw new InvalidCastException("Invalid cast from 'long' to 'TDWVDAServiceEndpointEntry'.");
                
            }
            long ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertTo_long(TDWVDAServiceEndpointEntry value)
            {
                return TypeConverter<long>.ConvertFrom_TDWVDAServiceEndpointEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAServiceEndpointEntry>.GetConversionActionTo_long()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long> ITypeConverter<TDWVDAServiceEndpointEntry>.Enumerate_long(TDWVDAServiceEndpointEntry value)
            {
                
                yield break;
            }
            TDWVDAServiceEndpointEntry ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    TDWVDAServiceEndpointEntry intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = TDWVDAServiceEndpointEntry.TryParse(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        Throw.cannot_parse(value, "TDWVDAServiceEndpointEntry");
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertTo_string(TDWVDAServiceEndpointEntry value)
            {
                return TypeConverter<string>.ConvertFrom_TDWVDAServiceEndpointEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAServiceEndpointEntry>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<TDWVDAServiceEndpointEntry>.Enumerate_string(TDWVDAServiceEndpointEntry value)
            {
                
                yield break;
            }
            TDWVDAServiceEndpointEntry ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_List_string(List<string> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<string>' to 'TDWVDAServiceEndpointEntry'.");
                
            }
            List<string> ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertTo_List_string(TDWVDAServiceEndpointEntry value)
            {
                return TypeConverter<List<string>>.ConvertFrom_TDWVDAServiceEndpointEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAServiceEndpointEntry>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_WRAPINLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<TDWVDAServiceEndpointEntry>.Enumerate_List_string(TDWVDAServiceEndpointEntry value)
            {
                
                yield break;
            }
            TDWVDAServiceEndpointEntry ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_List_TRAClaim(List<TRAClaim> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<TRAClaim>' to 'TDWVDAServiceEndpointEntry'.");
                
            }
            List<TRAClaim> ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertTo_List_TRAClaim(TDWVDAServiceEndpointEntry value)
            {
                return TypeConverter<List<TRAClaim>>.ConvertFrom_TDWVDAServiceEndpointEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAServiceEndpointEntry>.GetConversionActionTo_List_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAClaim>> ITypeConverter<TDWVDAServiceEndpointEntry>.Enumerate_List_TRAClaim(TDWVDAServiceEndpointEntry value)
            {
                
                yield break;
            }
            TDWVDAServiceEndpointEntry ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_List_TRAKeyValuePair(List<TRAKeyValuePair> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<TRAKeyValuePair>' to 'TDWVDAServiceEndpointEntry'.");
                
            }
            List<TRAKeyValuePair> ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertTo_List_TRAKeyValuePair(TDWVDAServiceEndpointEntry value)
            {
                return TypeConverter<List<TRAKeyValuePair>>.ConvertFrom_TDWVDAServiceEndpointEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAServiceEndpointEntry>.GetConversionActionTo_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAKeyValuePair>> ITypeConverter<TDWVDAServiceEndpointEntry>.Enumerate_List_TRAKeyValuePair(TDWVDAServiceEndpointEntry value)
            {
                
                yield break;
            }
            TDWVDAServiceEndpointEntry ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_TDWVDAAccountEntryContent(TDWVDAAccountEntryContent value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAAccountEntryContent' to 'TDWVDAServiceEndpointEntry'.");
                
            }
            TDWVDAAccountEntryContent ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertTo_TDWVDAAccountEntryContent(TDWVDAServiceEndpointEntry value)
            {
                return TypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_TDWVDAServiceEndpointEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAServiceEndpointEntry>.GetConversionActionTo_TDWVDAAccountEntryContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryContent> ITypeConverter<TDWVDAServiceEndpointEntry>.Enumerate_TDWVDAAccountEntryContent(TDWVDAServiceEndpointEntry value)
            {
                
                yield break;
            }
            TDWVDAServiceEndpointEntry ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_TDWVDAAccountEntryCore(TDWVDAAccountEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAAccountEntryCore' to 'TDWVDAServiceEndpointEntry'.");
                
            }
            TDWVDAAccountEntryCore ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertTo_TDWVDAAccountEntryCore(TDWVDAServiceEndpointEntry value)
            {
                return TypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_TDWVDAServiceEndpointEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAServiceEndpointEntry>.GetConversionActionTo_TDWVDAAccountEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryCore> ITypeConverter<TDWVDAServiceEndpointEntry>.Enumerate_TDWVDAAccountEntryCore(TDWVDAServiceEndpointEntry value)
            {
                
                yield break;
            }
            TDWVDAServiceEndpointEntry ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_TDWVDAIdentityRegistryEntry(TDWVDAIdentityRegistryEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAIdentityRegistryEntry' to 'TDWVDAServiceEndpointEntry'.");
                
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertTo_TDWVDAIdentityRegistryEntry(TDWVDAServiceEndpointEntry value)
            {
                return TypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_TDWVDAServiceEndpointEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAServiceEndpointEntry>.GetConversionActionTo_TDWVDAIdentityRegistryEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAIdentityRegistryEntry> ITypeConverter<TDWVDAServiceEndpointEntry>.Enumerate_TDWVDAIdentityRegistryEntry(TDWVDAServiceEndpointEntry value)
            {
                
                yield break;
            }
            TDWVDAServiceEndpointEntry ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_TDWVDAPostInvocationParameters(TDWVDAPostInvocationParameters value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAPostInvocationParameters' to 'TDWVDAServiceEndpointEntry'.");
                
            }
            TDWVDAPostInvocationParameters ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertTo_TDWVDAPostInvocationParameters(TDWVDAServiceEndpointEntry value)
            {
                return TypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_TDWVDAServiceEndpointEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAServiceEndpointEntry>.GetConversionActionTo_TDWVDAPostInvocationParameters()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAPostInvocationParameters> ITypeConverter<TDWVDAServiceEndpointEntry>.Enumerate_TDWVDAPostInvocationParameters(TDWVDAServiceEndpointEntry value)
            {
                
                yield break;
            }
            TDWVDAServiceEndpointEntry ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_TDWVDARevocationListEntry(TDWVDARevocationListEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDARevocationListEntry' to 'TDWVDAServiceEndpointEntry'.");
                
            }
            TDWVDARevocationListEntry ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertTo_TDWVDARevocationListEntry(TDWVDAServiceEndpointEntry value)
            {
                return TypeConverter<TDWVDARevocationListEntry>.ConvertFrom_TDWVDAServiceEndpointEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAServiceEndpointEntry>.GetConversionActionTo_TDWVDARevocationListEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDARevocationListEntry> ITypeConverter<TDWVDAServiceEndpointEntry>.Enumerate_TDWVDARevocationListEntry(TDWVDAServiceEndpointEntry value)
            {
                
                yield break;
            }
            TDWVDAServiceEndpointEntry ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_TDWVDAServiceEndpointEntry(TDWVDAServiceEndpointEntry value)
            {
                
                return (TDWVDAServiceEndpointEntry)value;
                
            }
            TDWVDAServiceEndpointEntry ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertTo_TDWVDAServiceEndpointEntry(TDWVDAServiceEndpointEntry value)
            {
                return TypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_TDWVDAServiceEndpointEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAServiceEndpointEntry>.GetConversionActionTo_TDWVDAServiceEndpointEntry()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAServiceEndpointEntry> ITypeConverter<TDWVDAServiceEndpointEntry>.Enumerate_TDWVDAServiceEndpointEntry(TDWVDAServiceEndpointEntry value)
            {
                
                yield break;
            }
            TDWVDAServiceEndpointEntry ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_TDWVDASmartContractEntryCore(TDWVDASmartContractEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDASmartContractEntryCore' to 'TDWVDAServiceEndpointEntry'.");
                
            }
            TDWVDASmartContractEntryCore ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertTo_TDWVDASmartContractEntryCore(TDWVDAServiceEndpointEntry value)
            {
                return TypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_TDWVDAServiceEndpointEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAServiceEndpointEntry>.GetConversionActionTo_TDWVDASmartContractEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDASmartContractEntryCore> ITypeConverter<TDWVDAServiceEndpointEntry>.Enumerate_TDWVDASmartContractEntryCore(TDWVDAServiceEndpointEntry value)
            {
                
                yield break;
            }
            TDWVDAServiceEndpointEntry ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_TRAClaim(TRAClaim value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAClaim' to 'TDWVDAServiceEndpointEntry'.");
                
            }
            TRAClaim ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertTo_TRAClaim(TDWVDAServiceEndpointEntry value)
            {
                return TypeConverter<TRAClaim>.ConvertFrom_TDWVDAServiceEndpointEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAServiceEndpointEntry>.GetConversionActionTo_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAClaim> ITypeConverter<TDWVDAServiceEndpointEntry>.Enumerate_TRAClaim(TDWVDAServiceEndpointEntry value)
            {
                
                yield break;
            }
            TDWVDAServiceEndpointEntry ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_TRACredentialContent(TRACredentialContent value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialContent' to 'TDWVDAServiceEndpointEntry'.");
                
            }
            TRACredentialContent ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertTo_TRACredentialContent(TDWVDAServiceEndpointEntry value)
            {
                return TypeConverter<TRACredentialContent>.ConvertFrom_TDWVDAServiceEndpointEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAServiceEndpointEntry>.GetConversionActionTo_TRACredentialContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialContent> ITypeConverter<TDWVDAServiceEndpointEntry>.Enumerate_TRACredentialContent(TDWVDAServiceEndpointEntry value)
            {
                
                yield break;
            }
            TDWVDAServiceEndpointEntry ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_TRACredentialCore(TRACredentialCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialCore' to 'TDWVDAServiceEndpointEntry'.");
                
            }
            TRACredentialCore ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertTo_TRACredentialCore(TDWVDAServiceEndpointEntry value)
            {
                return TypeConverter<TRACredentialCore>.ConvertFrom_TDWVDAServiceEndpointEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAServiceEndpointEntry>.GetConversionActionTo_TRACredentialCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialCore> ITypeConverter<TDWVDAServiceEndpointEntry>.Enumerate_TRACredentialCore(TDWVDAServiceEndpointEntry value)
            {
                
                yield break;
            }
            TDWVDAServiceEndpointEntry ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_TRACredentialEnvelope(TRACredentialEnvelope value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialEnvelope' to 'TDWVDAServiceEndpointEntry'.");
                
            }
            TRACredentialEnvelope ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertTo_TRACredentialEnvelope(TDWVDAServiceEndpointEntry value)
            {
                return TypeConverter<TRACredentialEnvelope>.ConvertFrom_TDWVDAServiceEndpointEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAServiceEndpointEntry>.GetConversionActionTo_TRACredentialEnvelope()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialEnvelope> ITypeConverter<TDWVDAServiceEndpointEntry>.Enumerate_TRACredentialEnvelope(TDWVDAServiceEndpointEntry value)
            {
                
                yield break;
            }
            TDWVDAServiceEndpointEntry ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_TRACredentialWrapper(TRACredentialWrapper value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialWrapper' to 'TDWVDAServiceEndpointEntry'.");
                
            }
            TRACredentialWrapper ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertTo_TRACredentialWrapper(TDWVDAServiceEndpointEntry value)
            {
                return TypeConverter<TRACredentialWrapper>.ConvertFrom_TDWVDAServiceEndpointEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAServiceEndpointEntry>.GetConversionActionTo_TRACredentialWrapper()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialWrapper> ITypeConverter<TDWVDAServiceEndpointEntry>.Enumerate_TRACredentialWrapper(TDWVDAServiceEndpointEntry value)
            {
                
                yield break;
            }
            TDWVDAServiceEndpointEntry ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_TRAKeyValuePair(TRAKeyValuePair value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAKeyValuePair' to 'TDWVDAServiceEndpointEntry'.");
                
            }
            TRAKeyValuePair ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertTo_TRAKeyValuePair(TDWVDAServiceEndpointEntry value)
            {
                return TypeConverter<TRAKeyValuePair>.ConvertFrom_TDWVDAServiceEndpointEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAServiceEndpointEntry>.GetConversionActionTo_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAKeyValuePair> ITypeConverter<TDWVDAServiceEndpointEntry>.Enumerate_TRAKeyValuePair(TDWVDAServiceEndpointEntry value)
            {
                
                yield break;
            }
            TDWVDAServiceEndpointEntry ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_TRACredentialType(TRACredentialType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialType' to 'TDWVDAServiceEndpointEntry'.");
                
            }
            TRACredentialType ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertTo_TRACredentialType(TDWVDAServiceEndpointEntry value)
            {
                return TypeConverter<TRACredentialType>.ConvertFrom_TDWVDAServiceEndpointEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAServiceEndpointEntry>.GetConversionActionTo_TRACredentialType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialType> ITypeConverter<TDWVDAServiceEndpointEntry>.Enumerate_TRACredentialType(TDWVDAServiceEndpointEntry value)
            {
                
                yield break;
            }
            TDWVDAServiceEndpointEntry ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_TRAEncryptionFlag(TRAEncryptionFlag value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAEncryptionFlag' to 'TDWVDAServiceEndpointEntry'.");
                
            }
            TRAEncryptionFlag ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertTo_TRAEncryptionFlag(TDWVDAServiceEndpointEntry value)
            {
                return TypeConverter<TRAEncryptionFlag>.ConvertFrom_TDWVDAServiceEndpointEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAServiceEndpointEntry>.GetConversionActionTo_TRAEncryptionFlag()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEncryptionFlag> ITypeConverter<TDWVDAServiceEndpointEntry>.Enumerate_TRAEncryptionFlag(TDWVDAServiceEndpointEntry value)
            {
                
                yield break;
            }
            TDWVDAServiceEndpointEntry ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_TRAServiceType(TRAServiceType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAServiceType' to 'TDWVDAServiceEndpointEntry'.");
                
            }
            TRAServiceType ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertTo_TRAServiceType(TDWVDAServiceEndpointEntry value)
            {
                return TypeConverter<TRAServiceType>.ConvertFrom_TDWVDAServiceEndpointEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAServiceEndpointEntry>.GetConversionActionTo_TRAServiceType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAServiceType> ITypeConverter<TDWVDAServiceEndpointEntry>.Enumerate_TRAServiceType(TDWVDAServiceEndpointEntry value)
            {
                
                yield break;
            }
            TDWVDAServiceEndpointEntry ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_TRATrustLevel(TRATrustLevel value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRATrustLevel' to 'TDWVDAServiceEndpointEntry'.");
                
            }
            TRATrustLevel ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertTo_TRATrustLevel(TDWVDAServiceEndpointEntry value)
            {
                return TypeConverter<TRATrustLevel>.ConvertFrom_TDWVDAServiceEndpointEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAServiceEndpointEntry>.GetConversionActionTo_TRATrustLevel()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRATrustLevel> ITypeConverter<TDWVDAServiceEndpointEntry>.Enumerate_TRATrustLevel(TDWVDAServiceEndpointEntry value)
            {
                
                yield break;
            }
            TDWVDAServiceEndpointEntry ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_List_List_TRAKeyValuePair(List<List<TRAKeyValuePair>> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<List<TRAKeyValuePair>>' to 'TDWVDAServiceEndpointEntry'.");
                
            }
            List<List<TRAKeyValuePair>> ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertTo_List_List_TRAKeyValuePair(TDWVDAServiceEndpointEntry value)
            {
                return TypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_TDWVDAServiceEndpointEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAServiceEndpointEntry>.GetConversionActionTo_List_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<List<TRAKeyValuePair>>> ITypeConverter<TDWVDAServiceEndpointEntry>.Enumerate_List_List_TRAKeyValuePair(TDWVDAServiceEndpointEntry value)
            {
                
                yield break;
            }
            TDWVDASmartContractEntryCore ITypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_bool(bool value)
            {
                
                throw new InvalidCastException("Invalid cast from 'bool' to 'TDWVDASmartContractEntryCore'.");
                
            }
            bool ITypeConverter<TDWVDASmartContractEntryCore>.ConvertTo_bool(TDWVDASmartContractEntryCore value)
            {
                return TypeConverter<bool>.ConvertFrom_TDWVDASmartContractEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDASmartContractEntryCore>.GetConversionActionTo_bool()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<bool> ITypeConverter<TDWVDASmartContractEntryCore>.Enumerate_bool(TDWVDASmartContractEntryCore value)
            {
                
                yield break;
            }
            TDWVDASmartContractEntryCore ITypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_long(long value)
            {
                
                throw new InvalidCastException("Invalid cast from 'long' to 'TDWVDASmartContractEntryCore'.");
                
            }
            long ITypeConverter<TDWVDASmartContractEntryCore>.ConvertTo_long(TDWVDASmartContractEntryCore value)
            {
                return TypeConverter<long>.ConvertFrom_TDWVDASmartContractEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDASmartContractEntryCore>.GetConversionActionTo_long()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long> ITypeConverter<TDWVDASmartContractEntryCore>.Enumerate_long(TDWVDASmartContractEntryCore value)
            {
                
                yield break;
            }
            TDWVDASmartContractEntryCore ITypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    TDWVDASmartContractEntryCore intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = TDWVDASmartContractEntryCore.TryParse(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        Throw.cannot_parse(value, "TDWVDASmartContractEntryCore");
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<TDWVDASmartContractEntryCore>.ConvertTo_string(TDWVDASmartContractEntryCore value)
            {
                return TypeConverter<string>.ConvertFrom_TDWVDASmartContractEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDASmartContractEntryCore>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<TDWVDASmartContractEntryCore>.Enumerate_string(TDWVDASmartContractEntryCore value)
            {
                
                yield break;
            }
            TDWVDASmartContractEntryCore ITypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_List_string(List<string> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<string>' to 'TDWVDASmartContractEntryCore'.");
                
            }
            List<string> ITypeConverter<TDWVDASmartContractEntryCore>.ConvertTo_List_string(TDWVDASmartContractEntryCore value)
            {
                return TypeConverter<List<string>>.ConvertFrom_TDWVDASmartContractEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDASmartContractEntryCore>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_WRAPINLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<TDWVDASmartContractEntryCore>.Enumerate_List_string(TDWVDASmartContractEntryCore value)
            {
                
                yield break;
            }
            TDWVDASmartContractEntryCore ITypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_List_TRAClaim(List<TRAClaim> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<TRAClaim>' to 'TDWVDASmartContractEntryCore'.");
                
            }
            List<TRAClaim> ITypeConverter<TDWVDASmartContractEntryCore>.ConvertTo_List_TRAClaim(TDWVDASmartContractEntryCore value)
            {
                return TypeConverter<List<TRAClaim>>.ConvertFrom_TDWVDASmartContractEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDASmartContractEntryCore>.GetConversionActionTo_List_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAClaim>> ITypeConverter<TDWVDASmartContractEntryCore>.Enumerate_List_TRAClaim(TDWVDASmartContractEntryCore value)
            {
                
                yield break;
            }
            TDWVDASmartContractEntryCore ITypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_List_TRAKeyValuePair(List<TRAKeyValuePair> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<TRAKeyValuePair>' to 'TDWVDASmartContractEntryCore'.");
                
            }
            List<TRAKeyValuePair> ITypeConverter<TDWVDASmartContractEntryCore>.ConvertTo_List_TRAKeyValuePair(TDWVDASmartContractEntryCore value)
            {
                return TypeConverter<List<TRAKeyValuePair>>.ConvertFrom_TDWVDASmartContractEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDASmartContractEntryCore>.GetConversionActionTo_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAKeyValuePair>> ITypeConverter<TDWVDASmartContractEntryCore>.Enumerate_List_TRAKeyValuePair(TDWVDASmartContractEntryCore value)
            {
                
                yield break;
            }
            TDWVDASmartContractEntryCore ITypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_TDWVDAAccountEntryContent(TDWVDAAccountEntryContent value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAAccountEntryContent' to 'TDWVDASmartContractEntryCore'.");
                
            }
            TDWVDAAccountEntryContent ITypeConverter<TDWVDASmartContractEntryCore>.ConvertTo_TDWVDAAccountEntryContent(TDWVDASmartContractEntryCore value)
            {
                return TypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_TDWVDASmartContractEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDASmartContractEntryCore>.GetConversionActionTo_TDWVDAAccountEntryContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryContent> ITypeConverter<TDWVDASmartContractEntryCore>.Enumerate_TDWVDAAccountEntryContent(TDWVDASmartContractEntryCore value)
            {
                
                yield break;
            }
            TDWVDASmartContractEntryCore ITypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_TDWVDAAccountEntryCore(TDWVDAAccountEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAAccountEntryCore' to 'TDWVDASmartContractEntryCore'.");
                
            }
            TDWVDAAccountEntryCore ITypeConverter<TDWVDASmartContractEntryCore>.ConvertTo_TDWVDAAccountEntryCore(TDWVDASmartContractEntryCore value)
            {
                return TypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_TDWVDASmartContractEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDASmartContractEntryCore>.GetConversionActionTo_TDWVDAAccountEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryCore> ITypeConverter<TDWVDASmartContractEntryCore>.Enumerate_TDWVDAAccountEntryCore(TDWVDASmartContractEntryCore value)
            {
                
                yield break;
            }
            TDWVDASmartContractEntryCore ITypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_TDWVDAIdentityRegistryEntry(TDWVDAIdentityRegistryEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAIdentityRegistryEntry' to 'TDWVDASmartContractEntryCore'.");
                
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<TDWVDASmartContractEntryCore>.ConvertTo_TDWVDAIdentityRegistryEntry(TDWVDASmartContractEntryCore value)
            {
                return TypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_TDWVDASmartContractEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDASmartContractEntryCore>.GetConversionActionTo_TDWVDAIdentityRegistryEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAIdentityRegistryEntry> ITypeConverter<TDWVDASmartContractEntryCore>.Enumerate_TDWVDAIdentityRegistryEntry(TDWVDASmartContractEntryCore value)
            {
                
                yield break;
            }
            TDWVDASmartContractEntryCore ITypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_TDWVDAPostInvocationParameters(TDWVDAPostInvocationParameters value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAPostInvocationParameters' to 'TDWVDASmartContractEntryCore'.");
                
            }
            TDWVDAPostInvocationParameters ITypeConverter<TDWVDASmartContractEntryCore>.ConvertTo_TDWVDAPostInvocationParameters(TDWVDASmartContractEntryCore value)
            {
                return TypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_TDWVDASmartContractEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDASmartContractEntryCore>.GetConversionActionTo_TDWVDAPostInvocationParameters()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAPostInvocationParameters> ITypeConverter<TDWVDASmartContractEntryCore>.Enumerate_TDWVDAPostInvocationParameters(TDWVDASmartContractEntryCore value)
            {
                
                yield break;
            }
            TDWVDASmartContractEntryCore ITypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_TDWVDARevocationListEntry(TDWVDARevocationListEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDARevocationListEntry' to 'TDWVDASmartContractEntryCore'.");
                
            }
            TDWVDARevocationListEntry ITypeConverter<TDWVDASmartContractEntryCore>.ConvertTo_TDWVDARevocationListEntry(TDWVDASmartContractEntryCore value)
            {
                return TypeConverter<TDWVDARevocationListEntry>.ConvertFrom_TDWVDASmartContractEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDASmartContractEntryCore>.GetConversionActionTo_TDWVDARevocationListEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDARevocationListEntry> ITypeConverter<TDWVDASmartContractEntryCore>.Enumerate_TDWVDARevocationListEntry(TDWVDASmartContractEntryCore value)
            {
                
                yield break;
            }
            TDWVDASmartContractEntryCore ITypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_TDWVDAServiceEndpointEntry(TDWVDAServiceEndpointEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAServiceEndpointEntry' to 'TDWVDASmartContractEntryCore'.");
                
            }
            TDWVDAServiceEndpointEntry ITypeConverter<TDWVDASmartContractEntryCore>.ConvertTo_TDWVDAServiceEndpointEntry(TDWVDASmartContractEntryCore value)
            {
                return TypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_TDWVDASmartContractEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDASmartContractEntryCore>.GetConversionActionTo_TDWVDAServiceEndpointEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAServiceEndpointEntry> ITypeConverter<TDWVDASmartContractEntryCore>.Enumerate_TDWVDAServiceEndpointEntry(TDWVDASmartContractEntryCore value)
            {
                
                yield break;
            }
            TDWVDASmartContractEntryCore ITypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_TDWVDASmartContractEntryCore(TDWVDASmartContractEntryCore value)
            {
                
                return (TDWVDASmartContractEntryCore)value;
                
            }
            TDWVDASmartContractEntryCore ITypeConverter<TDWVDASmartContractEntryCore>.ConvertTo_TDWVDASmartContractEntryCore(TDWVDASmartContractEntryCore value)
            {
                return TypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_TDWVDASmartContractEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDASmartContractEntryCore>.GetConversionActionTo_TDWVDASmartContractEntryCore()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDASmartContractEntryCore> ITypeConverter<TDWVDASmartContractEntryCore>.Enumerate_TDWVDASmartContractEntryCore(TDWVDASmartContractEntryCore value)
            {
                
                yield break;
            }
            TDWVDASmartContractEntryCore ITypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_TRAClaim(TRAClaim value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAClaim' to 'TDWVDASmartContractEntryCore'.");
                
            }
            TRAClaim ITypeConverter<TDWVDASmartContractEntryCore>.ConvertTo_TRAClaim(TDWVDASmartContractEntryCore value)
            {
                return TypeConverter<TRAClaim>.ConvertFrom_TDWVDASmartContractEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDASmartContractEntryCore>.GetConversionActionTo_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAClaim> ITypeConverter<TDWVDASmartContractEntryCore>.Enumerate_TRAClaim(TDWVDASmartContractEntryCore value)
            {
                
                yield break;
            }
            TDWVDASmartContractEntryCore ITypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_TRACredentialContent(TRACredentialContent value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialContent' to 'TDWVDASmartContractEntryCore'.");
                
            }
            TRACredentialContent ITypeConverter<TDWVDASmartContractEntryCore>.ConvertTo_TRACredentialContent(TDWVDASmartContractEntryCore value)
            {
                return TypeConverter<TRACredentialContent>.ConvertFrom_TDWVDASmartContractEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDASmartContractEntryCore>.GetConversionActionTo_TRACredentialContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialContent> ITypeConverter<TDWVDASmartContractEntryCore>.Enumerate_TRACredentialContent(TDWVDASmartContractEntryCore value)
            {
                
                yield break;
            }
            TDWVDASmartContractEntryCore ITypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_TRACredentialCore(TRACredentialCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialCore' to 'TDWVDASmartContractEntryCore'.");
                
            }
            TRACredentialCore ITypeConverter<TDWVDASmartContractEntryCore>.ConvertTo_TRACredentialCore(TDWVDASmartContractEntryCore value)
            {
                return TypeConverter<TRACredentialCore>.ConvertFrom_TDWVDASmartContractEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDASmartContractEntryCore>.GetConversionActionTo_TRACredentialCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialCore> ITypeConverter<TDWVDASmartContractEntryCore>.Enumerate_TRACredentialCore(TDWVDASmartContractEntryCore value)
            {
                
                yield break;
            }
            TDWVDASmartContractEntryCore ITypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_TRACredentialEnvelope(TRACredentialEnvelope value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialEnvelope' to 'TDWVDASmartContractEntryCore'.");
                
            }
            TRACredentialEnvelope ITypeConverter<TDWVDASmartContractEntryCore>.ConvertTo_TRACredentialEnvelope(TDWVDASmartContractEntryCore value)
            {
                return TypeConverter<TRACredentialEnvelope>.ConvertFrom_TDWVDASmartContractEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDASmartContractEntryCore>.GetConversionActionTo_TRACredentialEnvelope()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialEnvelope> ITypeConverter<TDWVDASmartContractEntryCore>.Enumerate_TRACredentialEnvelope(TDWVDASmartContractEntryCore value)
            {
                
                yield break;
            }
            TDWVDASmartContractEntryCore ITypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_TRACredentialWrapper(TRACredentialWrapper value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialWrapper' to 'TDWVDASmartContractEntryCore'.");
                
            }
            TRACredentialWrapper ITypeConverter<TDWVDASmartContractEntryCore>.ConvertTo_TRACredentialWrapper(TDWVDASmartContractEntryCore value)
            {
                return TypeConverter<TRACredentialWrapper>.ConvertFrom_TDWVDASmartContractEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDASmartContractEntryCore>.GetConversionActionTo_TRACredentialWrapper()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialWrapper> ITypeConverter<TDWVDASmartContractEntryCore>.Enumerate_TRACredentialWrapper(TDWVDASmartContractEntryCore value)
            {
                
                yield break;
            }
            TDWVDASmartContractEntryCore ITypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_TRAKeyValuePair(TRAKeyValuePair value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAKeyValuePair' to 'TDWVDASmartContractEntryCore'.");
                
            }
            TRAKeyValuePair ITypeConverter<TDWVDASmartContractEntryCore>.ConvertTo_TRAKeyValuePair(TDWVDASmartContractEntryCore value)
            {
                return TypeConverter<TRAKeyValuePair>.ConvertFrom_TDWVDASmartContractEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDASmartContractEntryCore>.GetConversionActionTo_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAKeyValuePair> ITypeConverter<TDWVDASmartContractEntryCore>.Enumerate_TRAKeyValuePair(TDWVDASmartContractEntryCore value)
            {
                
                yield break;
            }
            TDWVDASmartContractEntryCore ITypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_TRACredentialType(TRACredentialType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialType' to 'TDWVDASmartContractEntryCore'.");
                
            }
            TRACredentialType ITypeConverter<TDWVDASmartContractEntryCore>.ConvertTo_TRACredentialType(TDWVDASmartContractEntryCore value)
            {
                return TypeConverter<TRACredentialType>.ConvertFrom_TDWVDASmartContractEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDASmartContractEntryCore>.GetConversionActionTo_TRACredentialType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialType> ITypeConverter<TDWVDASmartContractEntryCore>.Enumerate_TRACredentialType(TDWVDASmartContractEntryCore value)
            {
                
                yield break;
            }
            TDWVDASmartContractEntryCore ITypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_TRAEncryptionFlag(TRAEncryptionFlag value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAEncryptionFlag' to 'TDWVDASmartContractEntryCore'.");
                
            }
            TRAEncryptionFlag ITypeConverter<TDWVDASmartContractEntryCore>.ConvertTo_TRAEncryptionFlag(TDWVDASmartContractEntryCore value)
            {
                return TypeConverter<TRAEncryptionFlag>.ConvertFrom_TDWVDASmartContractEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDASmartContractEntryCore>.GetConversionActionTo_TRAEncryptionFlag()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEncryptionFlag> ITypeConverter<TDWVDASmartContractEntryCore>.Enumerate_TRAEncryptionFlag(TDWVDASmartContractEntryCore value)
            {
                
                yield break;
            }
            TDWVDASmartContractEntryCore ITypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_TRAServiceType(TRAServiceType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAServiceType' to 'TDWVDASmartContractEntryCore'.");
                
            }
            TRAServiceType ITypeConverter<TDWVDASmartContractEntryCore>.ConvertTo_TRAServiceType(TDWVDASmartContractEntryCore value)
            {
                return TypeConverter<TRAServiceType>.ConvertFrom_TDWVDASmartContractEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDASmartContractEntryCore>.GetConversionActionTo_TRAServiceType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAServiceType> ITypeConverter<TDWVDASmartContractEntryCore>.Enumerate_TRAServiceType(TDWVDASmartContractEntryCore value)
            {
                
                yield break;
            }
            TDWVDASmartContractEntryCore ITypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_TRATrustLevel(TRATrustLevel value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRATrustLevel' to 'TDWVDASmartContractEntryCore'.");
                
            }
            TRATrustLevel ITypeConverter<TDWVDASmartContractEntryCore>.ConvertTo_TRATrustLevel(TDWVDASmartContractEntryCore value)
            {
                return TypeConverter<TRATrustLevel>.ConvertFrom_TDWVDASmartContractEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDASmartContractEntryCore>.GetConversionActionTo_TRATrustLevel()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRATrustLevel> ITypeConverter<TDWVDASmartContractEntryCore>.Enumerate_TRATrustLevel(TDWVDASmartContractEntryCore value)
            {
                
                yield break;
            }
            TDWVDASmartContractEntryCore ITypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_List_List_TRAKeyValuePair(List<List<TRAKeyValuePair>> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<List<TRAKeyValuePair>>' to 'TDWVDASmartContractEntryCore'.");
                
            }
            List<List<TRAKeyValuePair>> ITypeConverter<TDWVDASmartContractEntryCore>.ConvertTo_List_List_TRAKeyValuePair(TDWVDASmartContractEntryCore value)
            {
                return TypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_TDWVDASmartContractEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDASmartContractEntryCore>.GetConversionActionTo_List_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<List<TRAKeyValuePair>>> ITypeConverter<TDWVDASmartContractEntryCore>.Enumerate_List_List_TRAKeyValuePair(TDWVDASmartContractEntryCore value)
            {
                
                yield break;
            }
            TRAClaim ITypeConverter<TRAClaim>.ConvertFrom_bool(bool value)
            {
                
                throw new InvalidCastException("Invalid cast from 'bool' to 'TRAClaim'.");
                
            }
            bool ITypeConverter<TRAClaim>.ConvertTo_bool(TRAClaim value)
            {
                return TypeConverter<bool>.ConvertFrom_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<TRAClaim>.GetConversionActionTo_bool()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<bool> ITypeConverter<TRAClaim>.Enumerate_bool(TRAClaim value)
            {
                
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
            TRAClaim ITypeConverter<TRAClaim>.ConvertFrom_TDWVDAAccountEntryContent(TDWVDAAccountEntryContent value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAAccountEntryContent' to 'TRAClaim'.");
                
            }
            TDWVDAAccountEntryContent ITypeConverter<TRAClaim>.ConvertTo_TDWVDAAccountEntryContent(TRAClaim value)
            {
                return TypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<TRAClaim>.GetConversionActionTo_TDWVDAAccountEntryContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryContent> ITypeConverter<TRAClaim>.Enumerate_TDWVDAAccountEntryContent(TRAClaim value)
            {
                
                yield break;
            }
            TRAClaim ITypeConverter<TRAClaim>.ConvertFrom_TDWVDAAccountEntryCore(TDWVDAAccountEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAAccountEntryCore' to 'TRAClaim'.");
                
            }
            TDWVDAAccountEntryCore ITypeConverter<TRAClaim>.ConvertTo_TDWVDAAccountEntryCore(TRAClaim value)
            {
                return TypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<TRAClaim>.GetConversionActionTo_TDWVDAAccountEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryCore> ITypeConverter<TRAClaim>.Enumerate_TDWVDAAccountEntryCore(TRAClaim value)
            {
                
                yield break;
            }
            TRAClaim ITypeConverter<TRAClaim>.ConvertFrom_TDWVDAIdentityRegistryEntry(TDWVDAIdentityRegistryEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAIdentityRegistryEntry' to 'TRAClaim'.");
                
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<TRAClaim>.ConvertTo_TDWVDAIdentityRegistryEntry(TRAClaim value)
            {
                return TypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<TRAClaim>.GetConversionActionTo_TDWVDAIdentityRegistryEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAIdentityRegistryEntry> ITypeConverter<TRAClaim>.Enumerate_TDWVDAIdentityRegistryEntry(TRAClaim value)
            {
                
                yield break;
            }
            TRAClaim ITypeConverter<TRAClaim>.ConvertFrom_TDWVDAPostInvocationParameters(TDWVDAPostInvocationParameters value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAPostInvocationParameters' to 'TRAClaim'.");
                
            }
            TDWVDAPostInvocationParameters ITypeConverter<TRAClaim>.ConvertTo_TDWVDAPostInvocationParameters(TRAClaim value)
            {
                return TypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<TRAClaim>.GetConversionActionTo_TDWVDAPostInvocationParameters()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAPostInvocationParameters> ITypeConverter<TRAClaim>.Enumerate_TDWVDAPostInvocationParameters(TRAClaim value)
            {
                
                yield break;
            }
            TRAClaim ITypeConverter<TRAClaim>.ConvertFrom_TDWVDARevocationListEntry(TDWVDARevocationListEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDARevocationListEntry' to 'TRAClaim'.");
                
            }
            TDWVDARevocationListEntry ITypeConverter<TRAClaim>.ConvertTo_TDWVDARevocationListEntry(TRAClaim value)
            {
                return TypeConverter<TDWVDARevocationListEntry>.ConvertFrom_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<TRAClaim>.GetConversionActionTo_TDWVDARevocationListEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDARevocationListEntry> ITypeConverter<TRAClaim>.Enumerate_TDWVDARevocationListEntry(TRAClaim value)
            {
                
                yield break;
            }
            TRAClaim ITypeConverter<TRAClaim>.ConvertFrom_TDWVDAServiceEndpointEntry(TDWVDAServiceEndpointEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAServiceEndpointEntry' to 'TRAClaim'.");
                
            }
            TDWVDAServiceEndpointEntry ITypeConverter<TRAClaim>.ConvertTo_TDWVDAServiceEndpointEntry(TRAClaim value)
            {
                return TypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<TRAClaim>.GetConversionActionTo_TDWVDAServiceEndpointEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAServiceEndpointEntry> ITypeConverter<TRAClaim>.Enumerate_TDWVDAServiceEndpointEntry(TRAClaim value)
            {
                
                yield break;
            }
            TRAClaim ITypeConverter<TRAClaim>.ConvertFrom_TDWVDASmartContractEntryCore(TDWVDASmartContractEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDASmartContractEntryCore' to 'TRAClaim'.");
                
            }
            TDWVDASmartContractEntryCore ITypeConverter<TRAClaim>.ConvertTo_TDWVDASmartContractEntryCore(TRAClaim value)
            {
                return TypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<TRAClaim>.GetConversionActionTo_TDWVDASmartContractEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDASmartContractEntryCore> ITypeConverter<TRAClaim>.Enumerate_TDWVDASmartContractEntryCore(TRAClaim value)
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
            TRAClaim ITypeConverter<TRAClaim>.ConvertFrom_TRAServiceType(TRAServiceType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAServiceType' to 'TRAClaim'.");
                
            }
            TRAServiceType ITypeConverter<TRAClaim>.ConvertTo_TRAServiceType(TRAClaim value)
            {
                return TypeConverter<TRAServiceType>.ConvertFrom_TRAClaim(value);
            }
            TypeConversionAction ITypeConverter<TRAClaim>.GetConversionActionTo_TRAServiceType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAServiceType> ITypeConverter<TRAClaim>.Enumerate_TRAServiceType(TRAClaim value)
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
            TRACredentialContent ITypeConverter<TRACredentialContent>.ConvertFrom_bool(bool value)
            {
                
                throw new InvalidCastException("Invalid cast from 'bool' to 'TRACredentialContent'.");
                
            }
            bool ITypeConverter<TRACredentialContent>.ConvertTo_bool(TRACredentialContent value)
            {
                return TypeConverter<bool>.ConvertFrom_TRACredentialContent(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialContent>.GetConversionActionTo_bool()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<bool> ITypeConverter<TRACredentialContent>.Enumerate_bool(TRACredentialContent value)
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
            TRACredentialContent ITypeConverter<TRACredentialContent>.ConvertFrom_TDWVDAAccountEntryContent(TDWVDAAccountEntryContent value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAAccountEntryContent' to 'TRACredentialContent'.");
                
            }
            TDWVDAAccountEntryContent ITypeConverter<TRACredentialContent>.ConvertTo_TDWVDAAccountEntryContent(TRACredentialContent value)
            {
                return TypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_TRACredentialContent(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialContent>.GetConversionActionTo_TDWVDAAccountEntryContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryContent> ITypeConverter<TRACredentialContent>.Enumerate_TDWVDAAccountEntryContent(TRACredentialContent value)
            {
                
                yield break;
            }
            TRACredentialContent ITypeConverter<TRACredentialContent>.ConvertFrom_TDWVDAAccountEntryCore(TDWVDAAccountEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAAccountEntryCore' to 'TRACredentialContent'.");
                
            }
            TDWVDAAccountEntryCore ITypeConverter<TRACredentialContent>.ConvertTo_TDWVDAAccountEntryCore(TRACredentialContent value)
            {
                return TypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_TRACredentialContent(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialContent>.GetConversionActionTo_TDWVDAAccountEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryCore> ITypeConverter<TRACredentialContent>.Enumerate_TDWVDAAccountEntryCore(TRACredentialContent value)
            {
                
                yield break;
            }
            TRACredentialContent ITypeConverter<TRACredentialContent>.ConvertFrom_TDWVDAIdentityRegistryEntry(TDWVDAIdentityRegistryEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAIdentityRegistryEntry' to 'TRACredentialContent'.");
                
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<TRACredentialContent>.ConvertTo_TDWVDAIdentityRegistryEntry(TRACredentialContent value)
            {
                return TypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_TRACredentialContent(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialContent>.GetConversionActionTo_TDWVDAIdentityRegistryEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAIdentityRegistryEntry> ITypeConverter<TRACredentialContent>.Enumerate_TDWVDAIdentityRegistryEntry(TRACredentialContent value)
            {
                
                yield break;
            }
            TRACredentialContent ITypeConverter<TRACredentialContent>.ConvertFrom_TDWVDAPostInvocationParameters(TDWVDAPostInvocationParameters value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAPostInvocationParameters' to 'TRACredentialContent'.");
                
            }
            TDWVDAPostInvocationParameters ITypeConverter<TRACredentialContent>.ConvertTo_TDWVDAPostInvocationParameters(TRACredentialContent value)
            {
                return TypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_TRACredentialContent(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialContent>.GetConversionActionTo_TDWVDAPostInvocationParameters()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAPostInvocationParameters> ITypeConverter<TRACredentialContent>.Enumerate_TDWVDAPostInvocationParameters(TRACredentialContent value)
            {
                
                yield break;
            }
            TRACredentialContent ITypeConverter<TRACredentialContent>.ConvertFrom_TDWVDARevocationListEntry(TDWVDARevocationListEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDARevocationListEntry' to 'TRACredentialContent'.");
                
            }
            TDWVDARevocationListEntry ITypeConverter<TRACredentialContent>.ConvertTo_TDWVDARevocationListEntry(TRACredentialContent value)
            {
                return TypeConverter<TDWVDARevocationListEntry>.ConvertFrom_TRACredentialContent(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialContent>.GetConversionActionTo_TDWVDARevocationListEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDARevocationListEntry> ITypeConverter<TRACredentialContent>.Enumerate_TDWVDARevocationListEntry(TRACredentialContent value)
            {
                
                yield break;
            }
            TRACredentialContent ITypeConverter<TRACredentialContent>.ConvertFrom_TDWVDAServiceEndpointEntry(TDWVDAServiceEndpointEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAServiceEndpointEntry' to 'TRACredentialContent'.");
                
            }
            TDWVDAServiceEndpointEntry ITypeConverter<TRACredentialContent>.ConvertTo_TDWVDAServiceEndpointEntry(TRACredentialContent value)
            {
                return TypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_TRACredentialContent(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialContent>.GetConversionActionTo_TDWVDAServiceEndpointEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAServiceEndpointEntry> ITypeConverter<TRACredentialContent>.Enumerate_TDWVDAServiceEndpointEntry(TRACredentialContent value)
            {
                
                yield break;
            }
            TRACredentialContent ITypeConverter<TRACredentialContent>.ConvertFrom_TDWVDASmartContractEntryCore(TDWVDASmartContractEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDASmartContractEntryCore' to 'TRACredentialContent'.");
                
            }
            TDWVDASmartContractEntryCore ITypeConverter<TRACredentialContent>.ConvertTo_TDWVDASmartContractEntryCore(TRACredentialContent value)
            {
                return TypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_TRACredentialContent(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialContent>.GetConversionActionTo_TDWVDASmartContractEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDASmartContractEntryCore> ITypeConverter<TRACredentialContent>.Enumerate_TDWVDASmartContractEntryCore(TRACredentialContent value)
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
            TRACredentialContent ITypeConverter<TRACredentialContent>.ConvertFrom_TRAServiceType(TRAServiceType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAServiceType' to 'TRACredentialContent'.");
                
            }
            TRAServiceType ITypeConverter<TRACredentialContent>.ConvertTo_TRAServiceType(TRACredentialContent value)
            {
                return TypeConverter<TRAServiceType>.ConvertFrom_TRACredentialContent(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialContent>.GetConversionActionTo_TRAServiceType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAServiceType> ITypeConverter<TRACredentialContent>.Enumerate_TRAServiceType(TRACredentialContent value)
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
            TRACredentialCore ITypeConverter<TRACredentialCore>.ConvertFrom_bool(bool value)
            {
                
                throw new InvalidCastException("Invalid cast from 'bool' to 'TRACredentialCore'.");
                
            }
            bool ITypeConverter<TRACredentialCore>.ConvertTo_bool(TRACredentialCore value)
            {
                return TypeConverter<bool>.ConvertFrom_TRACredentialCore(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialCore>.GetConversionActionTo_bool()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<bool> ITypeConverter<TRACredentialCore>.Enumerate_bool(TRACredentialCore value)
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
            TRACredentialCore ITypeConverter<TRACredentialCore>.ConvertFrom_TDWVDAAccountEntryContent(TDWVDAAccountEntryContent value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAAccountEntryContent' to 'TRACredentialCore'.");
                
            }
            TDWVDAAccountEntryContent ITypeConverter<TRACredentialCore>.ConvertTo_TDWVDAAccountEntryContent(TRACredentialCore value)
            {
                return TypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_TRACredentialCore(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialCore>.GetConversionActionTo_TDWVDAAccountEntryContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryContent> ITypeConverter<TRACredentialCore>.Enumerate_TDWVDAAccountEntryContent(TRACredentialCore value)
            {
                
                yield break;
            }
            TRACredentialCore ITypeConverter<TRACredentialCore>.ConvertFrom_TDWVDAAccountEntryCore(TDWVDAAccountEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAAccountEntryCore' to 'TRACredentialCore'.");
                
            }
            TDWVDAAccountEntryCore ITypeConverter<TRACredentialCore>.ConvertTo_TDWVDAAccountEntryCore(TRACredentialCore value)
            {
                return TypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_TRACredentialCore(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialCore>.GetConversionActionTo_TDWVDAAccountEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryCore> ITypeConverter<TRACredentialCore>.Enumerate_TDWVDAAccountEntryCore(TRACredentialCore value)
            {
                
                yield break;
            }
            TRACredentialCore ITypeConverter<TRACredentialCore>.ConvertFrom_TDWVDAIdentityRegistryEntry(TDWVDAIdentityRegistryEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAIdentityRegistryEntry' to 'TRACredentialCore'.");
                
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<TRACredentialCore>.ConvertTo_TDWVDAIdentityRegistryEntry(TRACredentialCore value)
            {
                return TypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_TRACredentialCore(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialCore>.GetConversionActionTo_TDWVDAIdentityRegistryEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAIdentityRegistryEntry> ITypeConverter<TRACredentialCore>.Enumerate_TDWVDAIdentityRegistryEntry(TRACredentialCore value)
            {
                
                yield break;
            }
            TRACredentialCore ITypeConverter<TRACredentialCore>.ConvertFrom_TDWVDAPostInvocationParameters(TDWVDAPostInvocationParameters value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAPostInvocationParameters' to 'TRACredentialCore'.");
                
            }
            TDWVDAPostInvocationParameters ITypeConverter<TRACredentialCore>.ConvertTo_TDWVDAPostInvocationParameters(TRACredentialCore value)
            {
                return TypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_TRACredentialCore(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialCore>.GetConversionActionTo_TDWVDAPostInvocationParameters()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAPostInvocationParameters> ITypeConverter<TRACredentialCore>.Enumerate_TDWVDAPostInvocationParameters(TRACredentialCore value)
            {
                
                yield break;
            }
            TRACredentialCore ITypeConverter<TRACredentialCore>.ConvertFrom_TDWVDARevocationListEntry(TDWVDARevocationListEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDARevocationListEntry' to 'TRACredentialCore'.");
                
            }
            TDWVDARevocationListEntry ITypeConverter<TRACredentialCore>.ConvertTo_TDWVDARevocationListEntry(TRACredentialCore value)
            {
                return TypeConverter<TDWVDARevocationListEntry>.ConvertFrom_TRACredentialCore(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialCore>.GetConversionActionTo_TDWVDARevocationListEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDARevocationListEntry> ITypeConverter<TRACredentialCore>.Enumerate_TDWVDARevocationListEntry(TRACredentialCore value)
            {
                
                yield break;
            }
            TRACredentialCore ITypeConverter<TRACredentialCore>.ConvertFrom_TDWVDAServiceEndpointEntry(TDWVDAServiceEndpointEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAServiceEndpointEntry' to 'TRACredentialCore'.");
                
            }
            TDWVDAServiceEndpointEntry ITypeConverter<TRACredentialCore>.ConvertTo_TDWVDAServiceEndpointEntry(TRACredentialCore value)
            {
                return TypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_TRACredentialCore(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialCore>.GetConversionActionTo_TDWVDAServiceEndpointEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAServiceEndpointEntry> ITypeConverter<TRACredentialCore>.Enumerate_TDWVDAServiceEndpointEntry(TRACredentialCore value)
            {
                
                yield break;
            }
            TRACredentialCore ITypeConverter<TRACredentialCore>.ConvertFrom_TDWVDASmartContractEntryCore(TDWVDASmartContractEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDASmartContractEntryCore' to 'TRACredentialCore'.");
                
            }
            TDWVDASmartContractEntryCore ITypeConverter<TRACredentialCore>.ConvertTo_TDWVDASmartContractEntryCore(TRACredentialCore value)
            {
                return TypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_TRACredentialCore(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialCore>.GetConversionActionTo_TDWVDASmartContractEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDASmartContractEntryCore> ITypeConverter<TRACredentialCore>.Enumerate_TDWVDASmartContractEntryCore(TRACredentialCore value)
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
            TRACredentialCore ITypeConverter<TRACredentialCore>.ConvertFrom_TRAServiceType(TRAServiceType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAServiceType' to 'TRACredentialCore'.");
                
            }
            TRAServiceType ITypeConverter<TRACredentialCore>.ConvertTo_TRAServiceType(TRACredentialCore value)
            {
                return TypeConverter<TRAServiceType>.ConvertFrom_TRACredentialCore(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialCore>.GetConversionActionTo_TRAServiceType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAServiceType> ITypeConverter<TRACredentialCore>.Enumerate_TRAServiceType(TRACredentialCore value)
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
            TRACredentialEnvelope ITypeConverter<TRACredentialEnvelope>.ConvertFrom_bool(bool value)
            {
                
                throw new InvalidCastException("Invalid cast from 'bool' to 'TRACredentialEnvelope'.");
                
            }
            bool ITypeConverter<TRACredentialEnvelope>.ConvertTo_bool(TRACredentialEnvelope value)
            {
                return TypeConverter<bool>.ConvertFrom_TRACredentialEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialEnvelope>.GetConversionActionTo_bool()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<bool> ITypeConverter<TRACredentialEnvelope>.Enumerate_bool(TRACredentialEnvelope value)
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
            TRACredentialEnvelope ITypeConverter<TRACredentialEnvelope>.ConvertFrom_TDWVDAAccountEntryContent(TDWVDAAccountEntryContent value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAAccountEntryContent' to 'TRACredentialEnvelope'.");
                
            }
            TDWVDAAccountEntryContent ITypeConverter<TRACredentialEnvelope>.ConvertTo_TDWVDAAccountEntryContent(TRACredentialEnvelope value)
            {
                return TypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_TRACredentialEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialEnvelope>.GetConversionActionTo_TDWVDAAccountEntryContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryContent> ITypeConverter<TRACredentialEnvelope>.Enumerate_TDWVDAAccountEntryContent(TRACredentialEnvelope value)
            {
                
                yield break;
            }
            TRACredentialEnvelope ITypeConverter<TRACredentialEnvelope>.ConvertFrom_TDWVDAAccountEntryCore(TDWVDAAccountEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAAccountEntryCore' to 'TRACredentialEnvelope'.");
                
            }
            TDWVDAAccountEntryCore ITypeConverter<TRACredentialEnvelope>.ConvertTo_TDWVDAAccountEntryCore(TRACredentialEnvelope value)
            {
                return TypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_TRACredentialEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialEnvelope>.GetConversionActionTo_TDWVDAAccountEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryCore> ITypeConverter<TRACredentialEnvelope>.Enumerate_TDWVDAAccountEntryCore(TRACredentialEnvelope value)
            {
                
                yield break;
            }
            TRACredentialEnvelope ITypeConverter<TRACredentialEnvelope>.ConvertFrom_TDWVDAIdentityRegistryEntry(TDWVDAIdentityRegistryEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAIdentityRegistryEntry' to 'TRACredentialEnvelope'.");
                
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<TRACredentialEnvelope>.ConvertTo_TDWVDAIdentityRegistryEntry(TRACredentialEnvelope value)
            {
                return TypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_TRACredentialEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialEnvelope>.GetConversionActionTo_TDWVDAIdentityRegistryEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAIdentityRegistryEntry> ITypeConverter<TRACredentialEnvelope>.Enumerate_TDWVDAIdentityRegistryEntry(TRACredentialEnvelope value)
            {
                
                yield break;
            }
            TRACredentialEnvelope ITypeConverter<TRACredentialEnvelope>.ConvertFrom_TDWVDAPostInvocationParameters(TDWVDAPostInvocationParameters value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAPostInvocationParameters' to 'TRACredentialEnvelope'.");
                
            }
            TDWVDAPostInvocationParameters ITypeConverter<TRACredentialEnvelope>.ConvertTo_TDWVDAPostInvocationParameters(TRACredentialEnvelope value)
            {
                return TypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_TRACredentialEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialEnvelope>.GetConversionActionTo_TDWVDAPostInvocationParameters()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAPostInvocationParameters> ITypeConverter<TRACredentialEnvelope>.Enumerate_TDWVDAPostInvocationParameters(TRACredentialEnvelope value)
            {
                
                yield break;
            }
            TRACredentialEnvelope ITypeConverter<TRACredentialEnvelope>.ConvertFrom_TDWVDARevocationListEntry(TDWVDARevocationListEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDARevocationListEntry' to 'TRACredentialEnvelope'.");
                
            }
            TDWVDARevocationListEntry ITypeConverter<TRACredentialEnvelope>.ConvertTo_TDWVDARevocationListEntry(TRACredentialEnvelope value)
            {
                return TypeConverter<TDWVDARevocationListEntry>.ConvertFrom_TRACredentialEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialEnvelope>.GetConversionActionTo_TDWVDARevocationListEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDARevocationListEntry> ITypeConverter<TRACredentialEnvelope>.Enumerate_TDWVDARevocationListEntry(TRACredentialEnvelope value)
            {
                
                yield break;
            }
            TRACredentialEnvelope ITypeConverter<TRACredentialEnvelope>.ConvertFrom_TDWVDAServiceEndpointEntry(TDWVDAServiceEndpointEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAServiceEndpointEntry' to 'TRACredentialEnvelope'.");
                
            }
            TDWVDAServiceEndpointEntry ITypeConverter<TRACredentialEnvelope>.ConvertTo_TDWVDAServiceEndpointEntry(TRACredentialEnvelope value)
            {
                return TypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_TRACredentialEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialEnvelope>.GetConversionActionTo_TDWVDAServiceEndpointEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAServiceEndpointEntry> ITypeConverter<TRACredentialEnvelope>.Enumerate_TDWVDAServiceEndpointEntry(TRACredentialEnvelope value)
            {
                
                yield break;
            }
            TRACredentialEnvelope ITypeConverter<TRACredentialEnvelope>.ConvertFrom_TDWVDASmartContractEntryCore(TDWVDASmartContractEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDASmartContractEntryCore' to 'TRACredentialEnvelope'.");
                
            }
            TDWVDASmartContractEntryCore ITypeConverter<TRACredentialEnvelope>.ConvertTo_TDWVDASmartContractEntryCore(TRACredentialEnvelope value)
            {
                return TypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_TRACredentialEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialEnvelope>.GetConversionActionTo_TDWVDASmartContractEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDASmartContractEntryCore> ITypeConverter<TRACredentialEnvelope>.Enumerate_TDWVDASmartContractEntryCore(TRACredentialEnvelope value)
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
            TRACredentialEnvelope ITypeConverter<TRACredentialEnvelope>.ConvertFrom_TRAServiceType(TRAServiceType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAServiceType' to 'TRACredentialEnvelope'.");
                
            }
            TRAServiceType ITypeConverter<TRACredentialEnvelope>.ConvertTo_TRAServiceType(TRACredentialEnvelope value)
            {
                return TypeConverter<TRAServiceType>.ConvertFrom_TRACredentialEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialEnvelope>.GetConversionActionTo_TRAServiceType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAServiceType> ITypeConverter<TRACredentialEnvelope>.Enumerate_TRAServiceType(TRACredentialEnvelope value)
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
            TRACredentialWrapper ITypeConverter<TRACredentialWrapper>.ConvertFrom_bool(bool value)
            {
                
                throw new InvalidCastException("Invalid cast from 'bool' to 'TRACredentialWrapper'.");
                
            }
            bool ITypeConverter<TRACredentialWrapper>.ConvertTo_bool(TRACredentialWrapper value)
            {
                return TypeConverter<bool>.ConvertFrom_TRACredentialWrapper(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialWrapper>.GetConversionActionTo_bool()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<bool> ITypeConverter<TRACredentialWrapper>.Enumerate_bool(TRACredentialWrapper value)
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
            TRACredentialWrapper ITypeConverter<TRACredentialWrapper>.ConvertFrom_TDWVDAAccountEntryContent(TDWVDAAccountEntryContent value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAAccountEntryContent' to 'TRACredentialWrapper'.");
                
            }
            TDWVDAAccountEntryContent ITypeConverter<TRACredentialWrapper>.ConvertTo_TDWVDAAccountEntryContent(TRACredentialWrapper value)
            {
                return TypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_TRACredentialWrapper(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialWrapper>.GetConversionActionTo_TDWVDAAccountEntryContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryContent> ITypeConverter<TRACredentialWrapper>.Enumerate_TDWVDAAccountEntryContent(TRACredentialWrapper value)
            {
                
                yield break;
            }
            TRACredentialWrapper ITypeConverter<TRACredentialWrapper>.ConvertFrom_TDWVDAAccountEntryCore(TDWVDAAccountEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAAccountEntryCore' to 'TRACredentialWrapper'.");
                
            }
            TDWVDAAccountEntryCore ITypeConverter<TRACredentialWrapper>.ConvertTo_TDWVDAAccountEntryCore(TRACredentialWrapper value)
            {
                return TypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_TRACredentialWrapper(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialWrapper>.GetConversionActionTo_TDWVDAAccountEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryCore> ITypeConverter<TRACredentialWrapper>.Enumerate_TDWVDAAccountEntryCore(TRACredentialWrapper value)
            {
                
                yield break;
            }
            TRACredentialWrapper ITypeConverter<TRACredentialWrapper>.ConvertFrom_TDWVDAIdentityRegistryEntry(TDWVDAIdentityRegistryEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAIdentityRegistryEntry' to 'TRACredentialWrapper'.");
                
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<TRACredentialWrapper>.ConvertTo_TDWVDAIdentityRegistryEntry(TRACredentialWrapper value)
            {
                return TypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_TRACredentialWrapper(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialWrapper>.GetConversionActionTo_TDWVDAIdentityRegistryEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAIdentityRegistryEntry> ITypeConverter<TRACredentialWrapper>.Enumerate_TDWVDAIdentityRegistryEntry(TRACredentialWrapper value)
            {
                
                yield break;
            }
            TRACredentialWrapper ITypeConverter<TRACredentialWrapper>.ConvertFrom_TDWVDAPostInvocationParameters(TDWVDAPostInvocationParameters value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAPostInvocationParameters' to 'TRACredentialWrapper'.");
                
            }
            TDWVDAPostInvocationParameters ITypeConverter<TRACredentialWrapper>.ConvertTo_TDWVDAPostInvocationParameters(TRACredentialWrapper value)
            {
                return TypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_TRACredentialWrapper(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialWrapper>.GetConversionActionTo_TDWVDAPostInvocationParameters()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAPostInvocationParameters> ITypeConverter<TRACredentialWrapper>.Enumerate_TDWVDAPostInvocationParameters(TRACredentialWrapper value)
            {
                
                yield break;
            }
            TRACredentialWrapper ITypeConverter<TRACredentialWrapper>.ConvertFrom_TDWVDARevocationListEntry(TDWVDARevocationListEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDARevocationListEntry' to 'TRACredentialWrapper'.");
                
            }
            TDWVDARevocationListEntry ITypeConverter<TRACredentialWrapper>.ConvertTo_TDWVDARevocationListEntry(TRACredentialWrapper value)
            {
                return TypeConverter<TDWVDARevocationListEntry>.ConvertFrom_TRACredentialWrapper(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialWrapper>.GetConversionActionTo_TDWVDARevocationListEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDARevocationListEntry> ITypeConverter<TRACredentialWrapper>.Enumerate_TDWVDARevocationListEntry(TRACredentialWrapper value)
            {
                
                yield break;
            }
            TRACredentialWrapper ITypeConverter<TRACredentialWrapper>.ConvertFrom_TDWVDAServiceEndpointEntry(TDWVDAServiceEndpointEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAServiceEndpointEntry' to 'TRACredentialWrapper'.");
                
            }
            TDWVDAServiceEndpointEntry ITypeConverter<TRACredentialWrapper>.ConvertTo_TDWVDAServiceEndpointEntry(TRACredentialWrapper value)
            {
                return TypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_TRACredentialWrapper(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialWrapper>.GetConversionActionTo_TDWVDAServiceEndpointEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAServiceEndpointEntry> ITypeConverter<TRACredentialWrapper>.Enumerate_TDWVDAServiceEndpointEntry(TRACredentialWrapper value)
            {
                
                yield break;
            }
            TRACredentialWrapper ITypeConverter<TRACredentialWrapper>.ConvertFrom_TDWVDASmartContractEntryCore(TDWVDASmartContractEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDASmartContractEntryCore' to 'TRACredentialWrapper'.");
                
            }
            TDWVDASmartContractEntryCore ITypeConverter<TRACredentialWrapper>.ConvertTo_TDWVDASmartContractEntryCore(TRACredentialWrapper value)
            {
                return TypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_TRACredentialWrapper(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialWrapper>.GetConversionActionTo_TDWVDASmartContractEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDASmartContractEntryCore> ITypeConverter<TRACredentialWrapper>.Enumerate_TDWVDASmartContractEntryCore(TRACredentialWrapper value)
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
            TRACredentialWrapper ITypeConverter<TRACredentialWrapper>.ConvertFrom_TRAServiceType(TRAServiceType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAServiceType' to 'TRACredentialWrapper'.");
                
            }
            TRAServiceType ITypeConverter<TRACredentialWrapper>.ConvertTo_TRAServiceType(TRACredentialWrapper value)
            {
                return TypeConverter<TRAServiceType>.ConvertFrom_TRACredentialWrapper(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialWrapper>.GetConversionActionTo_TRAServiceType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAServiceType> ITypeConverter<TRACredentialWrapper>.Enumerate_TRAServiceType(TRACredentialWrapper value)
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
            TRAKeyValuePair ITypeConverter<TRAKeyValuePair>.ConvertFrom_bool(bool value)
            {
                
                throw new InvalidCastException("Invalid cast from 'bool' to 'TRAKeyValuePair'.");
                
            }
            bool ITypeConverter<TRAKeyValuePair>.ConvertTo_bool(TRAKeyValuePair value)
            {
                return TypeConverter<bool>.ConvertFrom_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<TRAKeyValuePair>.GetConversionActionTo_bool()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<bool> ITypeConverter<TRAKeyValuePair>.Enumerate_bool(TRAKeyValuePair value)
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
            TRAKeyValuePair ITypeConverter<TRAKeyValuePair>.ConvertFrom_TDWVDAAccountEntryContent(TDWVDAAccountEntryContent value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAAccountEntryContent' to 'TRAKeyValuePair'.");
                
            }
            TDWVDAAccountEntryContent ITypeConverter<TRAKeyValuePair>.ConvertTo_TDWVDAAccountEntryContent(TRAKeyValuePair value)
            {
                return TypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<TRAKeyValuePair>.GetConversionActionTo_TDWVDAAccountEntryContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryContent> ITypeConverter<TRAKeyValuePair>.Enumerate_TDWVDAAccountEntryContent(TRAKeyValuePair value)
            {
                
                yield break;
            }
            TRAKeyValuePair ITypeConverter<TRAKeyValuePair>.ConvertFrom_TDWVDAAccountEntryCore(TDWVDAAccountEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAAccountEntryCore' to 'TRAKeyValuePair'.");
                
            }
            TDWVDAAccountEntryCore ITypeConverter<TRAKeyValuePair>.ConvertTo_TDWVDAAccountEntryCore(TRAKeyValuePair value)
            {
                return TypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<TRAKeyValuePair>.GetConversionActionTo_TDWVDAAccountEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryCore> ITypeConverter<TRAKeyValuePair>.Enumerate_TDWVDAAccountEntryCore(TRAKeyValuePair value)
            {
                
                yield break;
            }
            TRAKeyValuePair ITypeConverter<TRAKeyValuePair>.ConvertFrom_TDWVDAIdentityRegistryEntry(TDWVDAIdentityRegistryEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAIdentityRegistryEntry' to 'TRAKeyValuePair'.");
                
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<TRAKeyValuePair>.ConvertTo_TDWVDAIdentityRegistryEntry(TRAKeyValuePair value)
            {
                return TypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<TRAKeyValuePair>.GetConversionActionTo_TDWVDAIdentityRegistryEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAIdentityRegistryEntry> ITypeConverter<TRAKeyValuePair>.Enumerate_TDWVDAIdentityRegistryEntry(TRAKeyValuePair value)
            {
                
                yield break;
            }
            TRAKeyValuePair ITypeConverter<TRAKeyValuePair>.ConvertFrom_TDWVDAPostInvocationParameters(TDWVDAPostInvocationParameters value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAPostInvocationParameters' to 'TRAKeyValuePair'.");
                
            }
            TDWVDAPostInvocationParameters ITypeConverter<TRAKeyValuePair>.ConvertTo_TDWVDAPostInvocationParameters(TRAKeyValuePair value)
            {
                return TypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<TRAKeyValuePair>.GetConversionActionTo_TDWVDAPostInvocationParameters()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAPostInvocationParameters> ITypeConverter<TRAKeyValuePair>.Enumerate_TDWVDAPostInvocationParameters(TRAKeyValuePair value)
            {
                
                yield break;
            }
            TRAKeyValuePair ITypeConverter<TRAKeyValuePair>.ConvertFrom_TDWVDARevocationListEntry(TDWVDARevocationListEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDARevocationListEntry' to 'TRAKeyValuePair'.");
                
            }
            TDWVDARevocationListEntry ITypeConverter<TRAKeyValuePair>.ConvertTo_TDWVDARevocationListEntry(TRAKeyValuePair value)
            {
                return TypeConverter<TDWVDARevocationListEntry>.ConvertFrom_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<TRAKeyValuePair>.GetConversionActionTo_TDWVDARevocationListEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDARevocationListEntry> ITypeConverter<TRAKeyValuePair>.Enumerate_TDWVDARevocationListEntry(TRAKeyValuePair value)
            {
                
                yield break;
            }
            TRAKeyValuePair ITypeConverter<TRAKeyValuePair>.ConvertFrom_TDWVDAServiceEndpointEntry(TDWVDAServiceEndpointEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAServiceEndpointEntry' to 'TRAKeyValuePair'.");
                
            }
            TDWVDAServiceEndpointEntry ITypeConverter<TRAKeyValuePair>.ConvertTo_TDWVDAServiceEndpointEntry(TRAKeyValuePair value)
            {
                return TypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<TRAKeyValuePair>.GetConversionActionTo_TDWVDAServiceEndpointEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAServiceEndpointEntry> ITypeConverter<TRAKeyValuePair>.Enumerate_TDWVDAServiceEndpointEntry(TRAKeyValuePair value)
            {
                
                yield break;
            }
            TRAKeyValuePair ITypeConverter<TRAKeyValuePair>.ConvertFrom_TDWVDASmartContractEntryCore(TDWVDASmartContractEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDASmartContractEntryCore' to 'TRAKeyValuePair'.");
                
            }
            TDWVDASmartContractEntryCore ITypeConverter<TRAKeyValuePair>.ConvertTo_TDWVDASmartContractEntryCore(TRAKeyValuePair value)
            {
                return TypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<TRAKeyValuePair>.GetConversionActionTo_TDWVDASmartContractEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDASmartContractEntryCore> ITypeConverter<TRAKeyValuePair>.Enumerate_TDWVDASmartContractEntryCore(TRAKeyValuePair value)
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
            TRAKeyValuePair ITypeConverter<TRAKeyValuePair>.ConvertFrom_TRAServiceType(TRAServiceType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAServiceType' to 'TRAKeyValuePair'.");
                
            }
            TRAServiceType ITypeConverter<TRAKeyValuePair>.ConvertTo_TRAServiceType(TRAKeyValuePair value)
            {
                return TypeConverter<TRAServiceType>.ConvertFrom_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<TRAKeyValuePair>.GetConversionActionTo_TRAServiceType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAServiceType> ITypeConverter<TRAKeyValuePair>.Enumerate_TRAServiceType(TRAKeyValuePair value)
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
            TRACredentialType ITypeConverter<TRACredentialType>.ConvertFrom_bool(bool value)
            {
                
                throw new InvalidCastException("Invalid cast from 'bool' to 'TRACredentialType'.");
                
            }
            bool ITypeConverter<TRACredentialType>.ConvertTo_bool(TRACredentialType value)
            {
                return TypeConverter<bool>.ConvertFrom_TRACredentialType(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialType>.GetConversionActionTo_bool()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<bool> ITypeConverter<TRACredentialType>.Enumerate_bool(TRACredentialType value)
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
            TRACredentialType ITypeConverter<TRACredentialType>.ConvertFrom_TDWVDAAccountEntryContent(TDWVDAAccountEntryContent value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAAccountEntryContent' to 'TRACredentialType'.");
                
            }
            TDWVDAAccountEntryContent ITypeConverter<TRACredentialType>.ConvertTo_TDWVDAAccountEntryContent(TRACredentialType value)
            {
                return TypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_TRACredentialType(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialType>.GetConversionActionTo_TDWVDAAccountEntryContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryContent> ITypeConverter<TRACredentialType>.Enumerate_TDWVDAAccountEntryContent(TRACredentialType value)
            {
                
                yield break;
            }
            TRACredentialType ITypeConverter<TRACredentialType>.ConvertFrom_TDWVDAAccountEntryCore(TDWVDAAccountEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAAccountEntryCore' to 'TRACredentialType'.");
                
            }
            TDWVDAAccountEntryCore ITypeConverter<TRACredentialType>.ConvertTo_TDWVDAAccountEntryCore(TRACredentialType value)
            {
                return TypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_TRACredentialType(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialType>.GetConversionActionTo_TDWVDAAccountEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryCore> ITypeConverter<TRACredentialType>.Enumerate_TDWVDAAccountEntryCore(TRACredentialType value)
            {
                
                yield break;
            }
            TRACredentialType ITypeConverter<TRACredentialType>.ConvertFrom_TDWVDAIdentityRegistryEntry(TDWVDAIdentityRegistryEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAIdentityRegistryEntry' to 'TRACredentialType'.");
                
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<TRACredentialType>.ConvertTo_TDWVDAIdentityRegistryEntry(TRACredentialType value)
            {
                return TypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_TRACredentialType(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialType>.GetConversionActionTo_TDWVDAIdentityRegistryEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAIdentityRegistryEntry> ITypeConverter<TRACredentialType>.Enumerate_TDWVDAIdentityRegistryEntry(TRACredentialType value)
            {
                
                yield break;
            }
            TRACredentialType ITypeConverter<TRACredentialType>.ConvertFrom_TDWVDAPostInvocationParameters(TDWVDAPostInvocationParameters value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAPostInvocationParameters' to 'TRACredentialType'.");
                
            }
            TDWVDAPostInvocationParameters ITypeConverter<TRACredentialType>.ConvertTo_TDWVDAPostInvocationParameters(TRACredentialType value)
            {
                return TypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_TRACredentialType(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialType>.GetConversionActionTo_TDWVDAPostInvocationParameters()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAPostInvocationParameters> ITypeConverter<TRACredentialType>.Enumerate_TDWVDAPostInvocationParameters(TRACredentialType value)
            {
                
                yield break;
            }
            TRACredentialType ITypeConverter<TRACredentialType>.ConvertFrom_TDWVDARevocationListEntry(TDWVDARevocationListEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDARevocationListEntry' to 'TRACredentialType'.");
                
            }
            TDWVDARevocationListEntry ITypeConverter<TRACredentialType>.ConvertTo_TDWVDARevocationListEntry(TRACredentialType value)
            {
                return TypeConverter<TDWVDARevocationListEntry>.ConvertFrom_TRACredentialType(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialType>.GetConversionActionTo_TDWVDARevocationListEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDARevocationListEntry> ITypeConverter<TRACredentialType>.Enumerate_TDWVDARevocationListEntry(TRACredentialType value)
            {
                
                yield break;
            }
            TRACredentialType ITypeConverter<TRACredentialType>.ConvertFrom_TDWVDAServiceEndpointEntry(TDWVDAServiceEndpointEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAServiceEndpointEntry' to 'TRACredentialType'.");
                
            }
            TDWVDAServiceEndpointEntry ITypeConverter<TRACredentialType>.ConvertTo_TDWVDAServiceEndpointEntry(TRACredentialType value)
            {
                return TypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_TRACredentialType(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialType>.GetConversionActionTo_TDWVDAServiceEndpointEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAServiceEndpointEntry> ITypeConverter<TRACredentialType>.Enumerate_TDWVDAServiceEndpointEntry(TRACredentialType value)
            {
                
                yield break;
            }
            TRACredentialType ITypeConverter<TRACredentialType>.ConvertFrom_TDWVDASmartContractEntryCore(TDWVDASmartContractEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDASmartContractEntryCore' to 'TRACredentialType'.");
                
            }
            TDWVDASmartContractEntryCore ITypeConverter<TRACredentialType>.ConvertTo_TDWVDASmartContractEntryCore(TRACredentialType value)
            {
                return TypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_TRACredentialType(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialType>.GetConversionActionTo_TDWVDASmartContractEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDASmartContractEntryCore> ITypeConverter<TRACredentialType>.Enumerate_TDWVDASmartContractEntryCore(TRACredentialType value)
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
            TRACredentialType ITypeConverter<TRACredentialType>.ConvertFrom_TRAServiceType(TRAServiceType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAServiceType' to 'TRACredentialType'.");
                
            }
            TRAServiceType ITypeConverter<TRACredentialType>.ConvertTo_TRAServiceType(TRACredentialType value)
            {
                return TypeConverter<TRAServiceType>.ConvertFrom_TRACredentialType(value);
            }
            TypeConversionAction ITypeConverter<TRACredentialType>.GetConversionActionTo_TRAServiceType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAServiceType> ITypeConverter<TRACredentialType>.Enumerate_TRAServiceType(TRACredentialType value)
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
            TRAEncryptionFlag ITypeConverter<TRAEncryptionFlag>.ConvertFrom_bool(bool value)
            {
                
                throw new InvalidCastException("Invalid cast from 'bool' to 'TRAEncryptionFlag'.");
                
            }
            bool ITypeConverter<TRAEncryptionFlag>.ConvertTo_bool(TRAEncryptionFlag value)
            {
                return TypeConverter<bool>.ConvertFrom_TRAEncryptionFlag(value);
            }
            TypeConversionAction ITypeConverter<TRAEncryptionFlag>.GetConversionActionTo_bool()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<bool> ITypeConverter<TRAEncryptionFlag>.Enumerate_bool(TRAEncryptionFlag value)
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
            TRAEncryptionFlag ITypeConverter<TRAEncryptionFlag>.ConvertFrom_TDWVDAAccountEntryContent(TDWVDAAccountEntryContent value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAAccountEntryContent' to 'TRAEncryptionFlag'.");
                
            }
            TDWVDAAccountEntryContent ITypeConverter<TRAEncryptionFlag>.ConvertTo_TDWVDAAccountEntryContent(TRAEncryptionFlag value)
            {
                return TypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_TRAEncryptionFlag(value);
            }
            TypeConversionAction ITypeConverter<TRAEncryptionFlag>.GetConversionActionTo_TDWVDAAccountEntryContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryContent> ITypeConverter<TRAEncryptionFlag>.Enumerate_TDWVDAAccountEntryContent(TRAEncryptionFlag value)
            {
                
                yield break;
            }
            TRAEncryptionFlag ITypeConverter<TRAEncryptionFlag>.ConvertFrom_TDWVDAAccountEntryCore(TDWVDAAccountEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAAccountEntryCore' to 'TRAEncryptionFlag'.");
                
            }
            TDWVDAAccountEntryCore ITypeConverter<TRAEncryptionFlag>.ConvertTo_TDWVDAAccountEntryCore(TRAEncryptionFlag value)
            {
                return TypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_TRAEncryptionFlag(value);
            }
            TypeConversionAction ITypeConverter<TRAEncryptionFlag>.GetConversionActionTo_TDWVDAAccountEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryCore> ITypeConverter<TRAEncryptionFlag>.Enumerate_TDWVDAAccountEntryCore(TRAEncryptionFlag value)
            {
                
                yield break;
            }
            TRAEncryptionFlag ITypeConverter<TRAEncryptionFlag>.ConvertFrom_TDWVDAIdentityRegistryEntry(TDWVDAIdentityRegistryEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAIdentityRegistryEntry' to 'TRAEncryptionFlag'.");
                
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<TRAEncryptionFlag>.ConvertTo_TDWVDAIdentityRegistryEntry(TRAEncryptionFlag value)
            {
                return TypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_TRAEncryptionFlag(value);
            }
            TypeConversionAction ITypeConverter<TRAEncryptionFlag>.GetConversionActionTo_TDWVDAIdentityRegistryEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAIdentityRegistryEntry> ITypeConverter<TRAEncryptionFlag>.Enumerate_TDWVDAIdentityRegistryEntry(TRAEncryptionFlag value)
            {
                
                yield break;
            }
            TRAEncryptionFlag ITypeConverter<TRAEncryptionFlag>.ConvertFrom_TDWVDAPostInvocationParameters(TDWVDAPostInvocationParameters value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAPostInvocationParameters' to 'TRAEncryptionFlag'.");
                
            }
            TDWVDAPostInvocationParameters ITypeConverter<TRAEncryptionFlag>.ConvertTo_TDWVDAPostInvocationParameters(TRAEncryptionFlag value)
            {
                return TypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_TRAEncryptionFlag(value);
            }
            TypeConversionAction ITypeConverter<TRAEncryptionFlag>.GetConversionActionTo_TDWVDAPostInvocationParameters()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAPostInvocationParameters> ITypeConverter<TRAEncryptionFlag>.Enumerate_TDWVDAPostInvocationParameters(TRAEncryptionFlag value)
            {
                
                yield break;
            }
            TRAEncryptionFlag ITypeConverter<TRAEncryptionFlag>.ConvertFrom_TDWVDARevocationListEntry(TDWVDARevocationListEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDARevocationListEntry' to 'TRAEncryptionFlag'.");
                
            }
            TDWVDARevocationListEntry ITypeConverter<TRAEncryptionFlag>.ConvertTo_TDWVDARevocationListEntry(TRAEncryptionFlag value)
            {
                return TypeConverter<TDWVDARevocationListEntry>.ConvertFrom_TRAEncryptionFlag(value);
            }
            TypeConversionAction ITypeConverter<TRAEncryptionFlag>.GetConversionActionTo_TDWVDARevocationListEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDARevocationListEntry> ITypeConverter<TRAEncryptionFlag>.Enumerate_TDWVDARevocationListEntry(TRAEncryptionFlag value)
            {
                
                yield break;
            }
            TRAEncryptionFlag ITypeConverter<TRAEncryptionFlag>.ConvertFrom_TDWVDAServiceEndpointEntry(TDWVDAServiceEndpointEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAServiceEndpointEntry' to 'TRAEncryptionFlag'.");
                
            }
            TDWVDAServiceEndpointEntry ITypeConverter<TRAEncryptionFlag>.ConvertTo_TDWVDAServiceEndpointEntry(TRAEncryptionFlag value)
            {
                return TypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_TRAEncryptionFlag(value);
            }
            TypeConversionAction ITypeConverter<TRAEncryptionFlag>.GetConversionActionTo_TDWVDAServiceEndpointEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAServiceEndpointEntry> ITypeConverter<TRAEncryptionFlag>.Enumerate_TDWVDAServiceEndpointEntry(TRAEncryptionFlag value)
            {
                
                yield break;
            }
            TRAEncryptionFlag ITypeConverter<TRAEncryptionFlag>.ConvertFrom_TDWVDASmartContractEntryCore(TDWVDASmartContractEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDASmartContractEntryCore' to 'TRAEncryptionFlag'.");
                
            }
            TDWVDASmartContractEntryCore ITypeConverter<TRAEncryptionFlag>.ConvertTo_TDWVDASmartContractEntryCore(TRAEncryptionFlag value)
            {
                return TypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_TRAEncryptionFlag(value);
            }
            TypeConversionAction ITypeConverter<TRAEncryptionFlag>.GetConversionActionTo_TDWVDASmartContractEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDASmartContractEntryCore> ITypeConverter<TRAEncryptionFlag>.Enumerate_TDWVDASmartContractEntryCore(TRAEncryptionFlag value)
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
            TRAEncryptionFlag ITypeConverter<TRAEncryptionFlag>.ConvertFrom_TRAServiceType(TRAServiceType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAServiceType' to 'TRAEncryptionFlag'.");
                
            }
            TRAServiceType ITypeConverter<TRAEncryptionFlag>.ConvertTo_TRAServiceType(TRAEncryptionFlag value)
            {
                return TypeConverter<TRAServiceType>.ConvertFrom_TRAEncryptionFlag(value);
            }
            TypeConversionAction ITypeConverter<TRAEncryptionFlag>.GetConversionActionTo_TRAServiceType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAServiceType> ITypeConverter<TRAEncryptionFlag>.Enumerate_TRAServiceType(TRAEncryptionFlag value)
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
            TRAServiceType ITypeConverter<TRAServiceType>.ConvertFrom_bool(bool value)
            {
                
                throw new InvalidCastException("Invalid cast from 'bool' to 'TRAServiceType'.");
                
            }
            bool ITypeConverter<TRAServiceType>.ConvertTo_bool(TRAServiceType value)
            {
                return TypeConverter<bool>.ConvertFrom_TRAServiceType(value);
            }
            TypeConversionAction ITypeConverter<TRAServiceType>.GetConversionActionTo_bool()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<bool> ITypeConverter<TRAServiceType>.Enumerate_bool(TRAServiceType value)
            {
                
                yield break;
            }
            TRAServiceType ITypeConverter<TRAServiceType>.ConvertFrom_long(long value)
            {
                
                throw new InvalidCastException("Invalid cast from 'long' to 'TRAServiceType'.");
                
            }
            long ITypeConverter<TRAServiceType>.ConvertTo_long(TRAServiceType value)
            {
                return TypeConverter<long>.ConvertFrom_TRAServiceType(value);
            }
            TypeConversionAction ITypeConverter<TRAServiceType>.GetConversionActionTo_long()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long> ITypeConverter<TRAServiceType>.Enumerate_long(TRAServiceType value)
            {
                
                yield break;
            }
            TRAServiceType ITypeConverter<TRAServiceType>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    TRAServiceType intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = TRAServiceType.TryParse(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        Throw.cannot_parse(value, "TRAServiceType");
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<TRAServiceType>.ConvertTo_string(TRAServiceType value)
            {
                return TypeConverter<string>.ConvertFrom_TRAServiceType(value);
            }
            TypeConversionAction ITypeConverter<TRAServiceType>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<TRAServiceType>.Enumerate_string(TRAServiceType value)
            {
                
                yield break;
            }
            TRAServiceType ITypeConverter<TRAServiceType>.ConvertFrom_List_string(List<string> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<string>' to 'TRAServiceType'.");
                
            }
            List<string> ITypeConverter<TRAServiceType>.ConvertTo_List_string(TRAServiceType value)
            {
                return TypeConverter<List<string>>.ConvertFrom_TRAServiceType(value);
            }
            TypeConversionAction ITypeConverter<TRAServiceType>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_WRAPINLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<TRAServiceType>.Enumerate_List_string(TRAServiceType value)
            {
                
                yield break;
            }
            TRAServiceType ITypeConverter<TRAServiceType>.ConvertFrom_List_TRAClaim(List<TRAClaim> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<TRAClaim>' to 'TRAServiceType'.");
                
            }
            List<TRAClaim> ITypeConverter<TRAServiceType>.ConvertTo_List_TRAClaim(TRAServiceType value)
            {
                return TypeConverter<List<TRAClaim>>.ConvertFrom_TRAServiceType(value);
            }
            TypeConversionAction ITypeConverter<TRAServiceType>.GetConversionActionTo_List_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAClaim>> ITypeConverter<TRAServiceType>.Enumerate_List_TRAClaim(TRAServiceType value)
            {
                
                yield break;
            }
            TRAServiceType ITypeConverter<TRAServiceType>.ConvertFrom_List_TRAKeyValuePair(List<TRAKeyValuePair> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<TRAKeyValuePair>' to 'TRAServiceType'.");
                
            }
            List<TRAKeyValuePair> ITypeConverter<TRAServiceType>.ConvertTo_List_TRAKeyValuePair(TRAServiceType value)
            {
                return TypeConverter<List<TRAKeyValuePair>>.ConvertFrom_TRAServiceType(value);
            }
            TypeConversionAction ITypeConverter<TRAServiceType>.GetConversionActionTo_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<TRAKeyValuePair>> ITypeConverter<TRAServiceType>.Enumerate_List_TRAKeyValuePair(TRAServiceType value)
            {
                
                yield break;
            }
            TRAServiceType ITypeConverter<TRAServiceType>.ConvertFrom_TDWVDAAccountEntryContent(TDWVDAAccountEntryContent value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAAccountEntryContent' to 'TRAServiceType'.");
                
            }
            TDWVDAAccountEntryContent ITypeConverter<TRAServiceType>.ConvertTo_TDWVDAAccountEntryContent(TRAServiceType value)
            {
                return TypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_TRAServiceType(value);
            }
            TypeConversionAction ITypeConverter<TRAServiceType>.GetConversionActionTo_TDWVDAAccountEntryContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryContent> ITypeConverter<TRAServiceType>.Enumerate_TDWVDAAccountEntryContent(TRAServiceType value)
            {
                
                yield break;
            }
            TRAServiceType ITypeConverter<TRAServiceType>.ConvertFrom_TDWVDAAccountEntryCore(TDWVDAAccountEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAAccountEntryCore' to 'TRAServiceType'.");
                
            }
            TDWVDAAccountEntryCore ITypeConverter<TRAServiceType>.ConvertTo_TDWVDAAccountEntryCore(TRAServiceType value)
            {
                return TypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_TRAServiceType(value);
            }
            TypeConversionAction ITypeConverter<TRAServiceType>.GetConversionActionTo_TDWVDAAccountEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryCore> ITypeConverter<TRAServiceType>.Enumerate_TDWVDAAccountEntryCore(TRAServiceType value)
            {
                
                yield break;
            }
            TRAServiceType ITypeConverter<TRAServiceType>.ConvertFrom_TDWVDAIdentityRegistryEntry(TDWVDAIdentityRegistryEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAIdentityRegistryEntry' to 'TRAServiceType'.");
                
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<TRAServiceType>.ConvertTo_TDWVDAIdentityRegistryEntry(TRAServiceType value)
            {
                return TypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_TRAServiceType(value);
            }
            TypeConversionAction ITypeConverter<TRAServiceType>.GetConversionActionTo_TDWVDAIdentityRegistryEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAIdentityRegistryEntry> ITypeConverter<TRAServiceType>.Enumerate_TDWVDAIdentityRegistryEntry(TRAServiceType value)
            {
                
                yield break;
            }
            TRAServiceType ITypeConverter<TRAServiceType>.ConvertFrom_TDWVDAPostInvocationParameters(TDWVDAPostInvocationParameters value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAPostInvocationParameters' to 'TRAServiceType'.");
                
            }
            TDWVDAPostInvocationParameters ITypeConverter<TRAServiceType>.ConvertTo_TDWVDAPostInvocationParameters(TRAServiceType value)
            {
                return TypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_TRAServiceType(value);
            }
            TypeConversionAction ITypeConverter<TRAServiceType>.GetConversionActionTo_TDWVDAPostInvocationParameters()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAPostInvocationParameters> ITypeConverter<TRAServiceType>.Enumerate_TDWVDAPostInvocationParameters(TRAServiceType value)
            {
                
                yield break;
            }
            TRAServiceType ITypeConverter<TRAServiceType>.ConvertFrom_TDWVDARevocationListEntry(TDWVDARevocationListEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDARevocationListEntry' to 'TRAServiceType'.");
                
            }
            TDWVDARevocationListEntry ITypeConverter<TRAServiceType>.ConvertTo_TDWVDARevocationListEntry(TRAServiceType value)
            {
                return TypeConverter<TDWVDARevocationListEntry>.ConvertFrom_TRAServiceType(value);
            }
            TypeConversionAction ITypeConverter<TRAServiceType>.GetConversionActionTo_TDWVDARevocationListEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDARevocationListEntry> ITypeConverter<TRAServiceType>.Enumerate_TDWVDARevocationListEntry(TRAServiceType value)
            {
                
                yield break;
            }
            TRAServiceType ITypeConverter<TRAServiceType>.ConvertFrom_TDWVDAServiceEndpointEntry(TDWVDAServiceEndpointEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAServiceEndpointEntry' to 'TRAServiceType'.");
                
            }
            TDWVDAServiceEndpointEntry ITypeConverter<TRAServiceType>.ConvertTo_TDWVDAServiceEndpointEntry(TRAServiceType value)
            {
                return TypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_TRAServiceType(value);
            }
            TypeConversionAction ITypeConverter<TRAServiceType>.GetConversionActionTo_TDWVDAServiceEndpointEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAServiceEndpointEntry> ITypeConverter<TRAServiceType>.Enumerate_TDWVDAServiceEndpointEntry(TRAServiceType value)
            {
                
                yield break;
            }
            TRAServiceType ITypeConverter<TRAServiceType>.ConvertFrom_TDWVDASmartContractEntryCore(TDWVDASmartContractEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDASmartContractEntryCore' to 'TRAServiceType'.");
                
            }
            TDWVDASmartContractEntryCore ITypeConverter<TRAServiceType>.ConvertTo_TDWVDASmartContractEntryCore(TRAServiceType value)
            {
                return TypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_TRAServiceType(value);
            }
            TypeConversionAction ITypeConverter<TRAServiceType>.GetConversionActionTo_TDWVDASmartContractEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDASmartContractEntryCore> ITypeConverter<TRAServiceType>.Enumerate_TDWVDASmartContractEntryCore(TRAServiceType value)
            {
                
                yield break;
            }
            TRAServiceType ITypeConverter<TRAServiceType>.ConvertFrom_TRAClaim(TRAClaim value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAClaim' to 'TRAServiceType'.");
                
            }
            TRAClaim ITypeConverter<TRAServiceType>.ConvertTo_TRAClaim(TRAServiceType value)
            {
                return TypeConverter<TRAClaim>.ConvertFrom_TRAServiceType(value);
            }
            TypeConversionAction ITypeConverter<TRAServiceType>.GetConversionActionTo_TRAClaim()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAClaim> ITypeConverter<TRAServiceType>.Enumerate_TRAClaim(TRAServiceType value)
            {
                
                yield break;
            }
            TRAServiceType ITypeConverter<TRAServiceType>.ConvertFrom_TRACredentialContent(TRACredentialContent value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialContent' to 'TRAServiceType'.");
                
            }
            TRACredentialContent ITypeConverter<TRAServiceType>.ConvertTo_TRACredentialContent(TRAServiceType value)
            {
                return TypeConverter<TRACredentialContent>.ConvertFrom_TRAServiceType(value);
            }
            TypeConversionAction ITypeConverter<TRAServiceType>.GetConversionActionTo_TRACredentialContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialContent> ITypeConverter<TRAServiceType>.Enumerate_TRACredentialContent(TRAServiceType value)
            {
                
                yield break;
            }
            TRAServiceType ITypeConverter<TRAServiceType>.ConvertFrom_TRACredentialCore(TRACredentialCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialCore' to 'TRAServiceType'.");
                
            }
            TRACredentialCore ITypeConverter<TRAServiceType>.ConvertTo_TRACredentialCore(TRAServiceType value)
            {
                return TypeConverter<TRACredentialCore>.ConvertFrom_TRAServiceType(value);
            }
            TypeConversionAction ITypeConverter<TRAServiceType>.GetConversionActionTo_TRACredentialCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialCore> ITypeConverter<TRAServiceType>.Enumerate_TRACredentialCore(TRAServiceType value)
            {
                
                yield break;
            }
            TRAServiceType ITypeConverter<TRAServiceType>.ConvertFrom_TRACredentialEnvelope(TRACredentialEnvelope value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialEnvelope' to 'TRAServiceType'.");
                
            }
            TRACredentialEnvelope ITypeConverter<TRAServiceType>.ConvertTo_TRACredentialEnvelope(TRAServiceType value)
            {
                return TypeConverter<TRACredentialEnvelope>.ConvertFrom_TRAServiceType(value);
            }
            TypeConversionAction ITypeConverter<TRAServiceType>.GetConversionActionTo_TRACredentialEnvelope()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialEnvelope> ITypeConverter<TRAServiceType>.Enumerate_TRACredentialEnvelope(TRAServiceType value)
            {
                
                yield break;
            }
            TRAServiceType ITypeConverter<TRAServiceType>.ConvertFrom_TRACredentialWrapper(TRACredentialWrapper value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialWrapper' to 'TRAServiceType'.");
                
            }
            TRACredentialWrapper ITypeConverter<TRAServiceType>.ConvertTo_TRACredentialWrapper(TRAServiceType value)
            {
                return TypeConverter<TRACredentialWrapper>.ConvertFrom_TRAServiceType(value);
            }
            TypeConversionAction ITypeConverter<TRAServiceType>.GetConversionActionTo_TRACredentialWrapper()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialWrapper> ITypeConverter<TRAServiceType>.Enumerate_TRACredentialWrapper(TRAServiceType value)
            {
                
                yield break;
            }
            TRAServiceType ITypeConverter<TRAServiceType>.ConvertFrom_TRAKeyValuePair(TRAKeyValuePair value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAKeyValuePair' to 'TRAServiceType'.");
                
            }
            TRAKeyValuePair ITypeConverter<TRAServiceType>.ConvertTo_TRAKeyValuePair(TRAServiceType value)
            {
                return TypeConverter<TRAKeyValuePair>.ConvertFrom_TRAServiceType(value);
            }
            TypeConversionAction ITypeConverter<TRAServiceType>.GetConversionActionTo_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAKeyValuePair> ITypeConverter<TRAServiceType>.Enumerate_TRAKeyValuePair(TRAServiceType value)
            {
                
                yield break;
            }
            TRAServiceType ITypeConverter<TRAServiceType>.ConvertFrom_TRACredentialType(TRACredentialType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRACredentialType' to 'TRAServiceType'.");
                
            }
            TRACredentialType ITypeConverter<TRAServiceType>.ConvertTo_TRACredentialType(TRAServiceType value)
            {
                return TypeConverter<TRACredentialType>.ConvertFrom_TRAServiceType(value);
            }
            TypeConversionAction ITypeConverter<TRAServiceType>.GetConversionActionTo_TRACredentialType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRACredentialType> ITypeConverter<TRAServiceType>.Enumerate_TRACredentialType(TRAServiceType value)
            {
                
                yield break;
            }
            TRAServiceType ITypeConverter<TRAServiceType>.ConvertFrom_TRAEncryptionFlag(TRAEncryptionFlag value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAEncryptionFlag' to 'TRAServiceType'.");
                
            }
            TRAEncryptionFlag ITypeConverter<TRAServiceType>.ConvertTo_TRAEncryptionFlag(TRAServiceType value)
            {
                return TypeConverter<TRAEncryptionFlag>.ConvertFrom_TRAServiceType(value);
            }
            TypeConversionAction ITypeConverter<TRAServiceType>.GetConversionActionTo_TRAEncryptionFlag()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEncryptionFlag> ITypeConverter<TRAServiceType>.Enumerate_TRAEncryptionFlag(TRAServiceType value)
            {
                
                yield break;
            }
            TRAServiceType ITypeConverter<TRAServiceType>.ConvertFrom_TRAServiceType(TRAServiceType value)
            {
                
                return (TRAServiceType)value;
                
            }
            TRAServiceType ITypeConverter<TRAServiceType>.ConvertTo_TRAServiceType(TRAServiceType value)
            {
                return TypeConverter<TRAServiceType>.ConvertFrom_TRAServiceType(value);
            }
            TypeConversionAction ITypeConverter<TRAServiceType>.GetConversionActionTo_TRAServiceType()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAServiceType> ITypeConverter<TRAServiceType>.Enumerate_TRAServiceType(TRAServiceType value)
            {
                
                yield break;
            }
            TRAServiceType ITypeConverter<TRAServiceType>.ConvertFrom_TRATrustLevel(TRATrustLevel value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRATrustLevel' to 'TRAServiceType'.");
                
            }
            TRATrustLevel ITypeConverter<TRAServiceType>.ConvertTo_TRATrustLevel(TRAServiceType value)
            {
                return TypeConverter<TRATrustLevel>.ConvertFrom_TRAServiceType(value);
            }
            TypeConversionAction ITypeConverter<TRAServiceType>.GetConversionActionTo_TRATrustLevel()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRATrustLevel> ITypeConverter<TRAServiceType>.Enumerate_TRATrustLevel(TRAServiceType value)
            {
                
                yield break;
            }
            TRAServiceType ITypeConverter<TRAServiceType>.ConvertFrom_List_List_TRAKeyValuePair(List<List<TRAKeyValuePair>> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<List<TRAKeyValuePair>>' to 'TRAServiceType'.");
                
            }
            List<List<TRAKeyValuePair>> ITypeConverter<TRAServiceType>.ConvertTo_List_List_TRAKeyValuePair(TRAServiceType value)
            {
                return TypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_TRAServiceType(value);
            }
            TypeConversionAction ITypeConverter<TRAServiceType>.GetConversionActionTo_List_List_TRAKeyValuePair()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<List<TRAKeyValuePair>>> ITypeConverter<TRAServiceType>.Enumerate_List_List_TRAKeyValuePair(TRAServiceType value)
            {
                
                yield break;
            }
            TRATrustLevel ITypeConverter<TRATrustLevel>.ConvertFrom_bool(bool value)
            {
                
                throw new InvalidCastException("Invalid cast from 'bool' to 'TRATrustLevel'.");
                
            }
            bool ITypeConverter<TRATrustLevel>.ConvertTo_bool(TRATrustLevel value)
            {
                return TypeConverter<bool>.ConvertFrom_TRATrustLevel(value);
            }
            TypeConversionAction ITypeConverter<TRATrustLevel>.GetConversionActionTo_bool()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<bool> ITypeConverter<TRATrustLevel>.Enumerate_bool(TRATrustLevel value)
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
            TRATrustLevel ITypeConverter<TRATrustLevel>.ConvertFrom_TDWVDAAccountEntryContent(TDWVDAAccountEntryContent value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAAccountEntryContent' to 'TRATrustLevel'.");
                
            }
            TDWVDAAccountEntryContent ITypeConverter<TRATrustLevel>.ConvertTo_TDWVDAAccountEntryContent(TRATrustLevel value)
            {
                return TypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_TRATrustLevel(value);
            }
            TypeConversionAction ITypeConverter<TRATrustLevel>.GetConversionActionTo_TDWVDAAccountEntryContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryContent> ITypeConverter<TRATrustLevel>.Enumerate_TDWVDAAccountEntryContent(TRATrustLevel value)
            {
                
                yield break;
            }
            TRATrustLevel ITypeConverter<TRATrustLevel>.ConvertFrom_TDWVDAAccountEntryCore(TDWVDAAccountEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAAccountEntryCore' to 'TRATrustLevel'.");
                
            }
            TDWVDAAccountEntryCore ITypeConverter<TRATrustLevel>.ConvertTo_TDWVDAAccountEntryCore(TRATrustLevel value)
            {
                return TypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_TRATrustLevel(value);
            }
            TypeConversionAction ITypeConverter<TRATrustLevel>.GetConversionActionTo_TDWVDAAccountEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryCore> ITypeConverter<TRATrustLevel>.Enumerate_TDWVDAAccountEntryCore(TRATrustLevel value)
            {
                
                yield break;
            }
            TRATrustLevel ITypeConverter<TRATrustLevel>.ConvertFrom_TDWVDAIdentityRegistryEntry(TDWVDAIdentityRegistryEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAIdentityRegistryEntry' to 'TRATrustLevel'.");
                
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<TRATrustLevel>.ConvertTo_TDWVDAIdentityRegistryEntry(TRATrustLevel value)
            {
                return TypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_TRATrustLevel(value);
            }
            TypeConversionAction ITypeConverter<TRATrustLevel>.GetConversionActionTo_TDWVDAIdentityRegistryEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAIdentityRegistryEntry> ITypeConverter<TRATrustLevel>.Enumerate_TDWVDAIdentityRegistryEntry(TRATrustLevel value)
            {
                
                yield break;
            }
            TRATrustLevel ITypeConverter<TRATrustLevel>.ConvertFrom_TDWVDAPostInvocationParameters(TDWVDAPostInvocationParameters value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAPostInvocationParameters' to 'TRATrustLevel'.");
                
            }
            TDWVDAPostInvocationParameters ITypeConverter<TRATrustLevel>.ConvertTo_TDWVDAPostInvocationParameters(TRATrustLevel value)
            {
                return TypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_TRATrustLevel(value);
            }
            TypeConversionAction ITypeConverter<TRATrustLevel>.GetConversionActionTo_TDWVDAPostInvocationParameters()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAPostInvocationParameters> ITypeConverter<TRATrustLevel>.Enumerate_TDWVDAPostInvocationParameters(TRATrustLevel value)
            {
                
                yield break;
            }
            TRATrustLevel ITypeConverter<TRATrustLevel>.ConvertFrom_TDWVDARevocationListEntry(TDWVDARevocationListEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDARevocationListEntry' to 'TRATrustLevel'.");
                
            }
            TDWVDARevocationListEntry ITypeConverter<TRATrustLevel>.ConvertTo_TDWVDARevocationListEntry(TRATrustLevel value)
            {
                return TypeConverter<TDWVDARevocationListEntry>.ConvertFrom_TRATrustLevel(value);
            }
            TypeConversionAction ITypeConverter<TRATrustLevel>.GetConversionActionTo_TDWVDARevocationListEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDARevocationListEntry> ITypeConverter<TRATrustLevel>.Enumerate_TDWVDARevocationListEntry(TRATrustLevel value)
            {
                
                yield break;
            }
            TRATrustLevel ITypeConverter<TRATrustLevel>.ConvertFrom_TDWVDAServiceEndpointEntry(TDWVDAServiceEndpointEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAServiceEndpointEntry' to 'TRATrustLevel'.");
                
            }
            TDWVDAServiceEndpointEntry ITypeConverter<TRATrustLevel>.ConvertTo_TDWVDAServiceEndpointEntry(TRATrustLevel value)
            {
                return TypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_TRATrustLevel(value);
            }
            TypeConversionAction ITypeConverter<TRATrustLevel>.GetConversionActionTo_TDWVDAServiceEndpointEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAServiceEndpointEntry> ITypeConverter<TRATrustLevel>.Enumerate_TDWVDAServiceEndpointEntry(TRATrustLevel value)
            {
                
                yield break;
            }
            TRATrustLevel ITypeConverter<TRATrustLevel>.ConvertFrom_TDWVDASmartContractEntryCore(TDWVDASmartContractEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDASmartContractEntryCore' to 'TRATrustLevel'.");
                
            }
            TDWVDASmartContractEntryCore ITypeConverter<TRATrustLevel>.ConvertTo_TDWVDASmartContractEntryCore(TRATrustLevel value)
            {
                return TypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_TRATrustLevel(value);
            }
            TypeConversionAction ITypeConverter<TRATrustLevel>.GetConversionActionTo_TDWVDASmartContractEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDASmartContractEntryCore> ITypeConverter<TRATrustLevel>.Enumerate_TDWVDASmartContractEntryCore(TRATrustLevel value)
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
            TRATrustLevel ITypeConverter<TRATrustLevel>.ConvertFrom_TRAServiceType(TRAServiceType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAServiceType' to 'TRATrustLevel'.");
                
            }
            TRAServiceType ITypeConverter<TRATrustLevel>.ConvertTo_TRAServiceType(TRATrustLevel value)
            {
                return TypeConverter<TRAServiceType>.ConvertFrom_TRATrustLevel(value);
            }
            TypeConversionAction ITypeConverter<TRATrustLevel>.GetConversionActionTo_TRAServiceType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAServiceType> ITypeConverter<TRATrustLevel>.Enumerate_TRAServiceType(TRATrustLevel value)
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
            List<List<TRAKeyValuePair>> ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_bool(bool value)
            {
                
                throw new InvalidCastException("Invalid cast from 'bool' to 'List<List<TRAKeyValuePair>>'.");
                
            }
            bool ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertTo_bool(List<List<TRAKeyValuePair>> value)
            {
                return TypeConverter<bool>.ConvertFrom_List_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<List<TRAKeyValuePair>>>.GetConversionActionTo_bool()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<bool> ITypeConverter<List<List<TRAKeyValuePair>>>.Enumerate_bool(List<List<TRAKeyValuePair>> value)
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
            List<List<TRAKeyValuePair>> ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_TDWVDAAccountEntryContent(TDWVDAAccountEntryContent value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAAccountEntryContent' to 'List<List<TRAKeyValuePair>>'.");
                
            }
            TDWVDAAccountEntryContent ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertTo_TDWVDAAccountEntryContent(List<List<TRAKeyValuePair>> value)
            {
                return TypeConverter<TDWVDAAccountEntryContent>.ConvertFrom_List_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<List<TRAKeyValuePair>>>.GetConversionActionTo_TDWVDAAccountEntryContent()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryContent> ITypeConverter<List<List<TRAKeyValuePair>>>.Enumerate_TDWVDAAccountEntryContent(List<List<TRAKeyValuePair>> value)
            {
                
                yield break;
            }
            List<List<TRAKeyValuePair>> ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_TDWVDAAccountEntryCore(TDWVDAAccountEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAAccountEntryCore' to 'List<List<TRAKeyValuePair>>'.");
                
            }
            TDWVDAAccountEntryCore ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertTo_TDWVDAAccountEntryCore(List<List<TRAKeyValuePair>> value)
            {
                return TypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_List_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<List<TRAKeyValuePair>>>.GetConversionActionTo_TDWVDAAccountEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryCore> ITypeConverter<List<List<TRAKeyValuePair>>>.Enumerate_TDWVDAAccountEntryCore(List<List<TRAKeyValuePair>> value)
            {
                
                yield break;
            }
            List<List<TRAKeyValuePair>> ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_TDWVDAIdentityRegistryEntry(TDWVDAIdentityRegistryEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAIdentityRegistryEntry' to 'List<List<TRAKeyValuePair>>'.");
                
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertTo_TDWVDAIdentityRegistryEntry(List<List<TRAKeyValuePair>> value)
            {
                return TypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_List_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<List<TRAKeyValuePair>>>.GetConversionActionTo_TDWVDAIdentityRegistryEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAIdentityRegistryEntry> ITypeConverter<List<List<TRAKeyValuePair>>>.Enumerate_TDWVDAIdentityRegistryEntry(List<List<TRAKeyValuePair>> value)
            {
                
                yield break;
            }
            List<List<TRAKeyValuePair>> ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_TDWVDAPostInvocationParameters(TDWVDAPostInvocationParameters value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAPostInvocationParameters' to 'List<List<TRAKeyValuePair>>'.");
                
            }
            TDWVDAPostInvocationParameters ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertTo_TDWVDAPostInvocationParameters(List<List<TRAKeyValuePair>> value)
            {
                return TypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_List_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<List<TRAKeyValuePair>>>.GetConversionActionTo_TDWVDAPostInvocationParameters()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAPostInvocationParameters> ITypeConverter<List<List<TRAKeyValuePair>>>.Enumerate_TDWVDAPostInvocationParameters(List<List<TRAKeyValuePair>> value)
            {
                
                yield break;
            }
            List<List<TRAKeyValuePair>> ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_TDWVDARevocationListEntry(TDWVDARevocationListEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDARevocationListEntry' to 'List<List<TRAKeyValuePair>>'.");
                
            }
            TDWVDARevocationListEntry ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertTo_TDWVDARevocationListEntry(List<List<TRAKeyValuePair>> value)
            {
                return TypeConverter<TDWVDARevocationListEntry>.ConvertFrom_List_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<List<TRAKeyValuePair>>>.GetConversionActionTo_TDWVDARevocationListEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDARevocationListEntry> ITypeConverter<List<List<TRAKeyValuePair>>>.Enumerate_TDWVDARevocationListEntry(List<List<TRAKeyValuePair>> value)
            {
                
                yield break;
            }
            List<List<TRAKeyValuePair>> ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_TDWVDAServiceEndpointEntry(TDWVDAServiceEndpointEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAServiceEndpointEntry' to 'List<List<TRAKeyValuePair>>'.");
                
            }
            TDWVDAServiceEndpointEntry ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertTo_TDWVDAServiceEndpointEntry(List<List<TRAKeyValuePair>> value)
            {
                return TypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_List_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<List<TRAKeyValuePair>>>.GetConversionActionTo_TDWVDAServiceEndpointEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAServiceEndpointEntry> ITypeConverter<List<List<TRAKeyValuePair>>>.Enumerate_TDWVDAServiceEndpointEntry(List<List<TRAKeyValuePair>> value)
            {
                
                yield break;
            }
            List<List<TRAKeyValuePair>> ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_TDWVDASmartContractEntryCore(TDWVDASmartContractEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDASmartContractEntryCore' to 'List<List<TRAKeyValuePair>>'.");
                
            }
            TDWVDASmartContractEntryCore ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertTo_TDWVDASmartContractEntryCore(List<List<TRAKeyValuePair>> value)
            {
                return TypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_List_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<List<TRAKeyValuePair>>>.GetConversionActionTo_TDWVDASmartContractEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDASmartContractEntryCore> ITypeConverter<List<List<TRAKeyValuePair>>>.Enumerate_TDWVDASmartContractEntryCore(List<List<TRAKeyValuePair>> value)
            {
                
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
            List<List<TRAKeyValuePair>> ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertFrom_TRAServiceType(TRAServiceType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAServiceType' to 'List<List<TRAKeyValuePair>>'.");
                
            }
            TRAServiceType ITypeConverter<List<List<TRAKeyValuePair>>>.ConvertTo_TRAServiceType(List<List<TRAKeyValuePair>> value)
            {
                return TypeConverter<TRAServiceType>.ConvertFrom_List_List_TRAKeyValuePair(value);
            }
            TypeConversionAction ITypeConverter<List<List<TRAKeyValuePair>>>.GetConversionActionTo_TRAServiceType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAServiceType> ITypeConverter<List<List<TRAKeyValuePair>>>.Enumerate_TRAServiceType(List<List<TRAKeyValuePair>> value)
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
            
            object ITypeConverter<object>.ConvertFrom_TDWVDAAccountEntryContent(TDWVDAAccountEntryContent value)
            {
                return value;
            }
            TDWVDAAccountEntryContent ITypeConverter<object>.ConvertTo_TDWVDAAccountEntryContent(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_TDWVDAAccountEntryContent()
            {
                throw new NotImplementedException();
            }
            IEnumerable<TDWVDAAccountEntryContent> ITypeConverter<object>.Enumerate_TDWVDAAccountEntryContent(object value)
            {
                throw new NotImplementedException();
            }
            
            object ITypeConverter<object>.ConvertFrom_TDWVDAAccountEntryCore(TDWVDAAccountEntryCore value)
            {
                return value;
            }
            TDWVDAAccountEntryCore ITypeConverter<object>.ConvertTo_TDWVDAAccountEntryCore(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_TDWVDAAccountEntryCore()
            {
                throw new NotImplementedException();
            }
            IEnumerable<TDWVDAAccountEntryCore> ITypeConverter<object>.Enumerate_TDWVDAAccountEntryCore(object value)
            {
                throw new NotImplementedException();
            }
            
            object ITypeConverter<object>.ConvertFrom_TDWVDAIdentityRegistryEntry(TDWVDAIdentityRegistryEntry value)
            {
                return value;
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<object>.ConvertTo_TDWVDAIdentityRegistryEntry(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_TDWVDAIdentityRegistryEntry()
            {
                throw new NotImplementedException();
            }
            IEnumerable<TDWVDAIdentityRegistryEntry> ITypeConverter<object>.Enumerate_TDWVDAIdentityRegistryEntry(object value)
            {
                throw new NotImplementedException();
            }
            
            object ITypeConverter<object>.ConvertFrom_TDWVDAPostInvocationParameters(TDWVDAPostInvocationParameters value)
            {
                return value;
            }
            TDWVDAPostInvocationParameters ITypeConverter<object>.ConvertTo_TDWVDAPostInvocationParameters(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_TDWVDAPostInvocationParameters()
            {
                throw new NotImplementedException();
            }
            IEnumerable<TDWVDAPostInvocationParameters> ITypeConverter<object>.Enumerate_TDWVDAPostInvocationParameters(object value)
            {
                throw new NotImplementedException();
            }
            
            object ITypeConverter<object>.ConvertFrom_TDWVDARevocationListEntry(TDWVDARevocationListEntry value)
            {
                return value;
            }
            TDWVDARevocationListEntry ITypeConverter<object>.ConvertTo_TDWVDARevocationListEntry(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_TDWVDARevocationListEntry()
            {
                throw new NotImplementedException();
            }
            IEnumerable<TDWVDARevocationListEntry> ITypeConverter<object>.Enumerate_TDWVDARevocationListEntry(object value)
            {
                throw new NotImplementedException();
            }
            
            object ITypeConverter<object>.ConvertFrom_TDWVDAServiceEndpointEntry(TDWVDAServiceEndpointEntry value)
            {
                return value;
            }
            TDWVDAServiceEndpointEntry ITypeConverter<object>.ConvertTo_TDWVDAServiceEndpointEntry(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_TDWVDAServiceEndpointEntry()
            {
                throw new NotImplementedException();
            }
            IEnumerable<TDWVDAServiceEndpointEntry> ITypeConverter<object>.Enumerate_TDWVDAServiceEndpointEntry(object value)
            {
                throw new NotImplementedException();
            }
            
            object ITypeConverter<object>.ConvertFrom_TDWVDASmartContractEntryCore(TDWVDASmartContractEntryCore value)
            {
                return value;
            }
            TDWVDASmartContractEntryCore ITypeConverter<object>.ConvertTo_TDWVDASmartContractEntryCore(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_TDWVDASmartContractEntryCore()
            {
                throw new NotImplementedException();
            }
            IEnumerable<TDWVDASmartContractEntryCore> ITypeConverter<object>.Enumerate_TDWVDASmartContractEntryCore(object value)
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
            
            object ITypeConverter<object>.ConvertFrom_TRAServiceType(TRAServiceType value)
            {
                return value;
            }
            TRAServiceType ITypeConverter<object>.ConvertTo_TRAServiceType(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_TRAServiceType()
            {
                throw new NotImplementedException();
            }
            IEnumerable<TRAServiceType> ITypeConverter<object>.Enumerate_TRAServiceType(object value)
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
        
        T ITypeConverter<T>.ConvertFrom_TDWVDAAccountEntryContent(TDWVDAAccountEntryContent value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TDWVDAAccountEntryContent ITypeConverter<T>.ConvertTo_TDWVDAAccountEntryContent(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_TDWVDAAccountEntryContent()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<TDWVDAAccountEntryContent> ITypeConverter<T>.Enumerate_TDWVDAAccountEntryContent(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        
        T ITypeConverter<T>.ConvertFrom_TDWVDAAccountEntryCore(TDWVDAAccountEntryCore value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TDWVDAAccountEntryCore ITypeConverter<T>.ConvertTo_TDWVDAAccountEntryCore(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_TDWVDAAccountEntryCore()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<TDWVDAAccountEntryCore> ITypeConverter<T>.Enumerate_TDWVDAAccountEntryCore(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        
        T ITypeConverter<T>.ConvertFrom_TDWVDAIdentityRegistryEntry(TDWVDAIdentityRegistryEntry value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TDWVDAIdentityRegistryEntry ITypeConverter<T>.ConvertTo_TDWVDAIdentityRegistryEntry(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_TDWVDAIdentityRegistryEntry()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<TDWVDAIdentityRegistryEntry> ITypeConverter<T>.Enumerate_TDWVDAIdentityRegistryEntry(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        
        T ITypeConverter<T>.ConvertFrom_TDWVDAPostInvocationParameters(TDWVDAPostInvocationParameters value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TDWVDAPostInvocationParameters ITypeConverter<T>.ConvertTo_TDWVDAPostInvocationParameters(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_TDWVDAPostInvocationParameters()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<TDWVDAPostInvocationParameters> ITypeConverter<T>.Enumerate_TDWVDAPostInvocationParameters(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        
        T ITypeConverter<T>.ConvertFrom_TDWVDARevocationListEntry(TDWVDARevocationListEntry value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TDWVDARevocationListEntry ITypeConverter<T>.ConvertTo_TDWVDARevocationListEntry(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_TDWVDARevocationListEntry()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<TDWVDARevocationListEntry> ITypeConverter<T>.Enumerate_TDWVDARevocationListEntry(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        
        T ITypeConverter<T>.ConvertFrom_TDWVDAServiceEndpointEntry(TDWVDAServiceEndpointEntry value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TDWVDAServiceEndpointEntry ITypeConverter<T>.ConvertTo_TDWVDAServiceEndpointEntry(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_TDWVDAServiceEndpointEntry()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<TDWVDAServiceEndpointEntry> ITypeConverter<T>.Enumerate_TDWVDAServiceEndpointEntry(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        
        T ITypeConverter<T>.ConvertFrom_TDWVDASmartContractEntryCore(TDWVDASmartContractEntryCore value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TDWVDASmartContractEntryCore ITypeConverter<T>.ConvertTo_TDWVDASmartContractEntryCore(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_TDWVDASmartContractEntryCore()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<TDWVDASmartContractEntryCore> ITypeConverter<T>.Enumerate_TDWVDASmartContractEntryCore(T value)
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
        
        T ITypeConverter<T>.ConvertFrom_TRAServiceType(TRAServiceType value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TRAServiceType ITypeConverter<T>.ConvertTo_TRAServiceType(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_TRAServiceType()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<TRAServiceType> ITypeConverter<T>.Enumerate_TRAServiceType(T value)
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
        
        internal static T ConvertFrom_TDWVDAAccountEntryContent(TDWVDAAccountEntryContent value)
        {
            return s_type_converter.ConvertFrom_TDWVDAAccountEntryContent(value);
        }
        internal static TDWVDAAccountEntryContent ConvertTo_TDWVDAAccountEntryContent(T value)
        {
            return s_type_converter.ConvertTo_TDWVDAAccountEntryContent(value);
        }
        internal static TypeConversionAction GetConversionActionTo_TDWVDAAccountEntryContent()
        {
            return s_type_converter.GetConversionActionTo_TDWVDAAccountEntryContent();
        }
        internal static IEnumerable<TDWVDAAccountEntryContent> Enumerate_TDWVDAAccountEntryContent(T value)
        {
            return s_type_converter.Enumerate_TDWVDAAccountEntryContent(value);
        }
        
        internal static T ConvertFrom_TDWVDAAccountEntryCore(TDWVDAAccountEntryCore value)
        {
            return s_type_converter.ConvertFrom_TDWVDAAccountEntryCore(value);
        }
        internal static TDWVDAAccountEntryCore ConvertTo_TDWVDAAccountEntryCore(T value)
        {
            return s_type_converter.ConvertTo_TDWVDAAccountEntryCore(value);
        }
        internal static TypeConversionAction GetConversionActionTo_TDWVDAAccountEntryCore()
        {
            return s_type_converter.GetConversionActionTo_TDWVDAAccountEntryCore();
        }
        internal static IEnumerable<TDWVDAAccountEntryCore> Enumerate_TDWVDAAccountEntryCore(T value)
        {
            return s_type_converter.Enumerate_TDWVDAAccountEntryCore(value);
        }
        
        internal static T ConvertFrom_TDWVDAIdentityRegistryEntry(TDWVDAIdentityRegistryEntry value)
        {
            return s_type_converter.ConvertFrom_TDWVDAIdentityRegistryEntry(value);
        }
        internal static TDWVDAIdentityRegistryEntry ConvertTo_TDWVDAIdentityRegistryEntry(T value)
        {
            return s_type_converter.ConvertTo_TDWVDAIdentityRegistryEntry(value);
        }
        internal static TypeConversionAction GetConversionActionTo_TDWVDAIdentityRegistryEntry()
        {
            return s_type_converter.GetConversionActionTo_TDWVDAIdentityRegistryEntry();
        }
        internal static IEnumerable<TDWVDAIdentityRegistryEntry> Enumerate_TDWVDAIdentityRegistryEntry(T value)
        {
            return s_type_converter.Enumerate_TDWVDAIdentityRegistryEntry(value);
        }
        
        internal static T ConvertFrom_TDWVDAPostInvocationParameters(TDWVDAPostInvocationParameters value)
        {
            return s_type_converter.ConvertFrom_TDWVDAPostInvocationParameters(value);
        }
        internal static TDWVDAPostInvocationParameters ConvertTo_TDWVDAPostInvocationParameters(T value)
        {
            return s_type_converter.ConvertTo_TDWVDAPostInvocationParameters(value);
        }
        internal static TypeConversionAction GetConversionActionTo_TDWVDAPostInvocationParameters()
        {
            return s_type_converter.GetConversionActionTo_TDWVDAPostInvocationParameters();
        }
        internal static IEnumerable<TDWVDAPostInvocationParameters> Enumerate_TDWVDAPostInvocationParameters(T value)
        {
            return s_type_converter.Enumerate_TDWVDAPostInvocationParameters(value);
        }
        
        internal static T ConvertFrom_TDWVDARevocationListEntry(TDWVDARevocationListEntry value)
        {
            return s_type_converter.ConvertFrom_TDWVDARevocationListEntry(value);
        }
        internal static TDWVDARevocationListEntry ConvertTo_TDWVDARevocationListEntry(T value)
        {
            return s_type_converter.ConvertTo_TDWVDARevocationListEntry(value);
        }
        internal static TypeConversionAction GetConversionActionTo_TDWVDARevocationListEntry()
        {
            return s_type_converter.GetConversionActionTo_TDWVDARevocationListEntry();
        }
        internal static IEnumerable<TDWVDARevocationListEntry> Enumerate_TDWVDARevocationListEntry(T value)
        {
            return s_type_converter.Enumerate_TDWVDARevocationListEntry(value);
        }
        
        internal static T ConvertFrom_TDWVDAServiceEndpointEntry(TDWVDAServiceEndpointEntry value)
        {
            return s_type_converter.ConvertFrom_TDWVDAServiceEndpointEntry(value);
        }
        internal static TDWVDAServiceEndpointEntry ConvertTo_TDWVDAServiceEndpointEntry(T value)
        {
            return s_type_converter.ConvertTo_TDWVDAServiceEndpointEntry(value);
        }
        internal static TypeConversionAction GetConversionActionTo_TDWVDAServiceEndpointEntry()
        {
            return s_type_converter.GetConversionActionTo_TDWVDAServiceEndpointEntry();
        }
        internal static IEnumerable<TDWVDAServiceEndpointEntry> Enumerate_TDWVDAServiceEndpointEntry(T value)
        {
            return s_type_converter.Enumerate_TDWVDAServiceEndpointEntry(value);
        }
        
        internal static T ConvertFrom_TDWVDASmartContractEntryCore(TDWVDASmartContractEntryCore value)
        {
            return s_type_converter.ConvertFrom_TDWVDASmartContractEntryCore(value);
        }
        internal static TDWVDASmartContractEntryCore ConvertTo_TDWVDASmartContractEntryCore(T value)
        {
            return s_type_converter.ConvertTo_TDWVDASmartContractEntryCore(value);
        }
        internal static TypeConversionAction GetConversionActionTo_TDWVDASmartContractEntryCore()
        {
            return s_type_converter.GetConversionActionTo_TDWVDASmartContractEntryCore();
        }
        internal static IEnumerable<TDWVDASmartContractEntryCore> Enumerate_TDWVDASmartContractEntryCore(T value)
        {
            return s_type_converter.Enumerate_TDWVDASmartContractEntryCore(value);
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
        
        internal static T ConvertFrom_TRAServiceType(TRAServiceType value)
        {
            return s_type_converter.ConvertFrom_TRAServiceType(value);
        }
        internal static TRAServiceType ConvertTo_TRAServiceType(T value)
        {
            return s_type_converter.ConvertTo_TRAServiceType(value);
        }
        internal static TypeConversionAction GetConversionActionTo_TRAServiceType()
        {
            return s_type_converter.GetConversionActionTo_TRAServiceType();
        }
        internal static IEnumerable<TRAServiceType> Enumerate_TRAServiceType(T value)
        {
            return s_type_converter.Enumerate_TRAServiceType(value);
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
