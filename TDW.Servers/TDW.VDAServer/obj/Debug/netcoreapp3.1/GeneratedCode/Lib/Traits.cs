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
            { typeof(TDWVDAAccountEntryCore), 4 }
            ,
            { typeof(TDWVDAIdentityRegistryEntry), 5 }
            ,
            { typeof(TDWVDAPostInvocationParameters), 6 }
            ,
            { typeof(TDWVDARevocationListEntry), 7 }
            ,
            { typeof(TDWVDAServiceEndpointEntry), 8 }
            ,
            { typeof(TDWVDASmartContractEntryCore), 9 }
            ,
            { typeof(TRAEnvelope), 10 }
            ,
            { typeof(TRACredentialType), 11 }
            ,
            { typeof(TRAEncryptionFlag), 12 }
            ,
            { typeof(TRAServiceType), 13 }
            ,
            { typeof(TRATrustLevel), 14 }
            ,
        };
        #endregion
        #region CellTypeID lookup table
        private static Dictionary<Type, uint> CellTypeIDLookupTable = new Dictionary<Type, uint>()
        {
            
            { typeof(TDWVDAAccount), 0 }
            ,
            { typeof(TDWVDASmartContract), 1 }
            
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
        
        T ConvertFrom_TRAEnvelope(TRAEnvelope value);
        TRAEnvelope ConvertTo_TRAEnvelope(T value);
        TypeConversionAction GetConversionActionTo_TRAEnvelope();
        IEnumerable<TRAEnvelope> Enumerate_TRAEnvelope(T value);
        
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
        
    }
    internal class TypeConverter<T> : ITypeConverter<T>
    {
        internal class _TypeConverterImpl : ITypeConverter<object>
            
            , ITypeConverter<bool>
        
            , ITypeConverter<long>
        
            , ITypeConverter<string>
        
            , ITypeConverter<List<string>>
        
            , ITypeConverter<TDWVDAAccountEntryCore>
        
            , ITypeConverter<TDWVDAIdentityRegistryEntry>
        
            , ITypeConverter<TDWVDAPostInvocationParameters>
        
            , ITypeConverter<TDWVDARevocationListEntry>
        
            , ITypeConverter<TDWVDAServiceEndpointEntry>
        
            , ITypeConverter<TDWVDASmartContractEntryCore>
        
            , ITypeConverter<TRAEnvelope>
        
            , ITypeConverter<TRACredentialType>
        
            , ITypeConverter<TRAEncryptionFlag>
        
            , ITypeConverter<TRAServiceType>
        
            , ITypeConverter<TRATrustLevel>
        
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
            bool ITypeConverter<bool>.ConvertFrom_TRAEnvelope(TRAEnvelope value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAEnvelope' to 'bool'.");
                
            }
            TRAEnvelope ITypeConverter<bool>.ConvertTo_TRAEnvelope(bool value)
            {
                return TypeConverter<TRAEnvelope>.ConvertFrom_bool(value);
            }
            TypeConversionAction ITypeConverter<bool>.GetConversionActionTo_TRAEnvelope()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEnvelope> ITypeConverter<bool>.Enumerate_TRAEnvelope(bool value)
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
            TDWVDAAccountEntryCore ITypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_TRAEnvelope(TRAEnvelope value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAEnvelope' to 'TDWVDAAccountEntryCore'.");
                
            }
            TRAEnvelope ITypeConverter<TDWVDAAccountEntryCore>.ConvertTo_TRAEnvelope(TDWVDAAccountEntryCore value)
            {
                return TypeConverter<TRAEnvelope>.ConvertFrom_TDWVDAAccountEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAAccountEntryCore>.GetConversionActionTo_TRAEnvelope()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEnvelope> ITypeConverter<TDWVDAAccountEntryCore>.Enumerate_TRAEnvelope(TDWVDAAccountEntryCore value)
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
            TDWVDAIdentityRegistryEntry ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_TRAEnvelope(TRAEnvelope value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAEnvelope' to 'TDWVDAIdentityRegistryEntry'.");
                
            }
            TRAEnvelope ITypeConverter<TDWVDAIdentityRegistryEntry>.ConvertTo_TRAEnvelope(TDWVDAIdentityRegistryEntry value)
            {
                return TypeConverter<TRAEnvelope>.ConvertFrom_TDWVDAIdentityRegistryEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAIdentityRegistryEntry>.GetConversionActionTo_TRAEnvelope()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEnvelope> ITypeConverter<TDWVDAIdentityRegistryEntry>.Enumerate_TRAEnvelope(TDWVDAIdentityRegistryEntry value)
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
            TDWVDAPostInvocationParameters ITypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_TRAEnvelope(TRAEnvelope value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAEnvelope' to 'TDWVDAPostInvocationParameters'.");
                
            }
            TRAEnvelope ITypeConverter<TDWVDAPostInvocationParameters>.ConvertTo_TRAEnvelope(TDWVDAPostInvocationParameters value)
            {
                return TypeConverter<TRAEnvelope>.ConvertFrom_TDWVDAPostInvocationParameters(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAPostInvocationParameters>.GetConversionActionTo_TRAEnvelope()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEnvelope> ITypeConverter<TDWVDAPostInvocationParameters>.Enumerate_TRAEnvelope(TDWVDAPostInvocationParameters value)
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
            TDWVDARevocationListEntry ITypeConverter<TDWVDARevocationListEntry>.ConvertFrom_TRAEnvelope(TRAEnvelope value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAEnvelope' to 'TDWVDARevocationListEntry'.");
                
            }
            TRAEnvelope ITypeConverter<TDWVDARevocationListEntry>.ConvertTo_TRAEnvelope(TDWVDARevocationListEntry value)
            {
                return TypeConverter<TRAEnvelope>.ConvertFrom_TDWVDARevocationListEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDARevocationListEntry>.GetConversionActionTo_TRAEnvelope()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEnvelope> ITypeConverter<TDWVDARevocationListEntry>.Enumerate_TRAEnvelope(TDWVDARevocationListEntry value)
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
            TDWVDAServiceEndpointEntry ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_TRAEnvelope(TRAEnvelope value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAEnvelope' to 'TDWVDAServiceEndpointEntry'.");
                
            }
            TRAEnvelope ITypeConverter<TDWVDAServiceEndpointEntry>.ConvertTo_TRAEnvelope(TDWVDAServiceEndpointEntry value)
            {
                return TypeConverter<TRAEnvelope>.ConvertFrom_TDWVDAServiceEndpointEntry(value);
            }
            TypeConversionAction ITypeConverter<TDWVDAServiceEndpointEntry>.GetConversionActionTo_TRAEnvelope()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEnvelope> ITypeConverter<TDWVDAServiceEndpointEntry>.Enumerate_TRAEnvelope(TDWVDAServiceEndpointEntry value)
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
            TDWVDASmartContractEntryCore ITypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_TRAEnvelope(TRAEnvelope value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAEnvelope' to 'TDWVDASmartContractEntryCore'.");
                
            }
            TRAEnvelope ITypeConverter<TDWVDASmartContractEntryCore>.ConvertTo_TRAEnvelope(TDWVDASmartContractEntryCore value)
            {
                return TypeConverter<TRAEnvelope>.ConvertFrom_TDWVDASmartContractEntryCore(value);
            }
            TypeConversionAction ITypeConverter<TDWVDASmartContractEntryCore>.GetConversionActionTo_TRAEnvelope()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEnvelope> ITypeConverter<TDWVDASmartContractEntryCore>.Enumerate_TRAEnvelope(TDWVDASmartContractEntryCore value)
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
            TRAEnvelope ITypeConverter<TRAEnvelope>.ConvertFrom_bool(bool value)
            {
                
                throw new InvalidCastException("Invalid cast from 'bool' to 'TRAEnvelope'.");
                
            }
            bool ITypeConverter<TRAEnvelope>.ConvertTo_bool(TRAEnvelope value)
            {
                return TypeConverter<bool>.ConvertFrom_TRAEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRAEnvelope>.GetConversionActionTo_bool()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<bool> ITypeConverter<TRAEnvelope>.Enumerate_bool(TRAEnvelope value)
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
            TRAEnvelope ITypeConverter<TRAEnvelope>.ConvertFrom_TDWVDAAccountEntryCore(TDWVDAAccountEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAAccountEntryCore' to 'TRAEnvelope'.");
                
            }
            TDWVDAAccountEntryCore ITypeConverter<TRAEnvelope>.ConvertTo_TDWVDAAccountEntryCore(TRAEnvelope value)
            {
                return TypeConverter<TDWVDAAccountEntryCore>.ConvertFrom_TRAEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRAEnvelope>.GetConversionActionTo_TDWVDAAccountEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAAccountEntryCore> ITypeConverter<TRAEnvelope>.Enumerate_TDWVDAAccountEntryCore(TRAEnvelope value)
            {
                
                yield break;
            }
            TRAEnvelope ITypeConverter<TRAEnvelope>.ConvertFrom_TDWVDAIdentityRegistryEntry(TDWVDAIdentityRegistryEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAIdentityRegistryEntry' to 'TRAEnvelope'.");
                
            }
            TDWVDAIdentityRegistryEntry ITypeConverter<TRAEnvelope>.ConvertTo_TDWVDAIdentityRegistryEntry(TRAEnvelope value)
            {
                return TypeConverter<TDWVDAIdentityRegistryEntry>.ConvertFrom_TRAEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRAEnvelope>.GetConversionActionTo_TDWVDAIdentityRegistryEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAIdentityRegistryEntry> ITypeConverter<TRAEnvelope>.Enumerate_TDWVDAIdentityRegistryEntry(TRAEnvelope value)
            {
                
                yield break;
            }
            TRAEnvelope ITypeConverter<TRAEnvelope>.ConvertFrom_TDWVDAPostInvocationParameters(TDWVDAPostInvocationParameters value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAPostInvocationParameters' to 'TRAEnvelope'.");
                
            }
            TDWVDAPostInvocationParameters ITypeConverter<TRAEnvelope>.ConvertTo_TDWVDAPostInvocationParameters(TRAEnvelope value)
            {
                return TypeConverter<TDWVDAPostInvocationParameters>.ConvertFrom_TRAEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRAEnvelope>.GetConversionActionTo_TDWVDAPostInvocationParameters()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAPostInvocationParameters> ITypeConverter<TRAEnvelope>.Enumerate_TDWVDAPostInvocationParameters(TRAEnvelope value)
            {
                
                yield break;
            }
            TRAEnvelope ITypeConverter<TRAEnvelope>.ConvertFrom_TDWVDARevocationListEntry(TDWVDARevocationListEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDARevocationListEntry' to 'TRAEnvelope'.");
                
            }
            TDWVDARevocationListEntry ITypeConverter<TRAEnvelope>.ConvertTo_TDWVDARevocationListEntry(TRAEnvelope value)
            {
                return TypeConverter<TDWVDARevocationListEntry>.ConvertFrom_TRAEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRAEnvelope>.GetConversionActionTo_TDWVDARevocationListEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDARevocationListEntry> ITypeConverter<TRAEnvelope>.Enumerate_TDWVDARevocationListEntry(TRAEnvelope value)
            {
                
                yield break;
            }
            TRAEnvelope ITypeConverter<TRAEnvelope>.ConvertFrom_TDWVDAServiceEndpointEntry(TDWVDAServiceEndpointEntry value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDAServiceEndpointEntry' to 'TRAEnvelope'.");
                
            }
            TDWVDAServiceEndpointEntry ITypeConverter<TRAEnvelope>.ConvertTo_TDWVDAServiceEndpointEntry(TRAEnvelope value)
            {
                return TypeConverter<TDWVDAServiceEndpointEntry>.ConvertFrom_TRAEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRAEnvelope>.GetConversionActionTo_TDWVDAServiceEndpointEntry()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDAServiceEndpointEntry> ITypeConverter<TRAEnvelope>.Enumerate_TDWVDAServiceEndpointEntry(TRAEnvelope value)
            {
                
                yield break;
            }
            TRAEnvelope ITypeConverter<TRAEnvelope>.ConvertFrom_TDWVDASmartContractEntryCore(TDWVDASmartContractEntryCore value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TDWVDASmartContractEntryCore' to 'TRAEnvelope'.");
                
            }
            TDWVDASmartContractEntryCore ITypeConverter<TRAEnvelope>.ConvertTo_TDWVDASmartContractEntryCore(TRAEnvelope value)
            {
                return TypeConverter<TDWVDASmartContractEntryCore>.ConvertFrom_TRAEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRAEnvelope>.GetConversionActionTo_TDWVDASmartContractEntryCore()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TDWVDASmartContractEntryCore> ITypeConverter<TRAEnvelope>.Enumerate_TDWVDASmartContractEntryCore(TRAEnvelope value)
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
            TRAEnvelope ITypeConverter<TRAEnvelope>.ConvertFrom_TRAServiceType(TRAServiceType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAServiceType' to 'TRAEnvelope'.");
                
            }
            TRAServiceType ITypeConverter<TRAEnvelope>.ConvertTo_TRAServiceType(TRAEnvelope value)
            {
                return TypeConverter<TRAServiceType>.ConvertFrom_TRAEnvelope(value);
            }
            TypeConversionAction ITypeConverter<TRAEnvelope>.GetConversionActionTo_TRAServiceType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAServiceType> ITypeConverter<TRAEnvelope>.Enumerate_TRAServiceType(TRAEnvelope value)
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
            TRAServiceType ITypeConverter<TRAServiceType>.ConvertFrom_TRAEnvelope(TRAEnvelope value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TRAEnvelope' to 'TRAServiceType'.");
                
            }
            TRAEnvelope ITypeConverter<TRAServiceType>.ConvertTo_TRAEnvelope(TRAServiceType value)
            {
                return TypeConverter<TRAEnvelope>.ConvertFrom_TRAServiceType(value);
            }
            TypeConversionAction ITypeConverter<TRAServiceType>.GetConversionActionTo_TRAEnvelope()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TRAEnvelope> ITypeConverter<TRAServiceType>.Enumerate_TRAEnvelope(TRAServiceType value)
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
        
    }
}

#pragma warning restore 162,168,649,660,661,1522
