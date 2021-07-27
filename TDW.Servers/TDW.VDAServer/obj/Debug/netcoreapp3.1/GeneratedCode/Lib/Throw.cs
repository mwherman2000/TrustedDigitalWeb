#pragma warning disable 162,168,649,660,661,1522

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Trinity;
using Trinity.Storage;
using Trinity.TSL;
using Trinity.TSL.Lib;
namespace TDW.VDAServer
{
    class Throw
    {
        
        internal static void parse_bool(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into bool.");
        }
        internal static void incompatible_with_bool()
        {
            throw new DataTypeIncompatibleException("Data type 'bool' not compatible with the target field.");
        }
        
        internal static void parse_long(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into long.");
        }
        internal static void incompatible_with_long()
        {
            throw new DataTypeIncompatibleException("Data type 'long' not compatible with the target field.");
        }
        
        internal static void parse_string(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into string.");
        }
        internal static void incompatible_with_string()
        {
            throw new DataTypeIncompatibleException("Data type 'string' not compatible with the target field.");
        }
        
        internal static void parse_List_string(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into List<string>.");
        }
        internal static void incompatible_with_List_string()
        {
            throw new DataTypeIncompatibleException("Data type 'List<string>' not compatible with the target field.");
        }
        
        internal static void parse_List_TRAKeyValuePair(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into List<TRAKeyValuePair>.");
        }
        internal static void incompatible_with_List_TRAKeyValuePair()
        {
            throw new DataTypeIncompatibleException("Data type 'List<TRAKeyValuePair>' not compatible with the target field.");
        }
        
        internal static void parse_TDWVDAAccountEntry_Claims(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TDWVDAAccountEntry_Claims.");
        }
        internal static void incompatible_with_TDWVDAAccountEntry_Claims()
        {
            throw new DataTypeIncompatibleException("Data type 'TDWVDAAccountEntry_Claims' not compatible with the target field.");
        }
        
        internal static void parse_TDWVDAAccountEntry_Envelope(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TDWVDAAccountEntry_Envelope.");
        }
        internal static void incompatible_with_TDWVDAAccountEntry_Envelope()
        {
            throw new DataTypeIncompatibleException("Data type 'TDWVDAAccountEntry_Envelope' not compatible with the target field.");
        }
        
        internal static void parse_TDWVDAAccountEntry_EnvelopeContent(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TDWVDAAccountEntry_EnvelopeContent.");
        }
        internal static void incompatible_with_TDWVDAAccountEntry_EnvelopeContent()
        {
            throw new DataTypeIncompatibleException("Data type 'TDWVDAAccountEntry_EnvelopeContent' not compatible with the target field.");
        }
        
        internal static void parse_TDWVDAIdentityRegistryEntryParm(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TDWVDAIdentityRegistryEntryParm.");
        }
        internal static void incompatible_with_TDWVDAIdentityRegistryEntryParm()
        {
            throw new DataTypeIncompatibleException("Data type 'TDWVDAIdentityRegistryEntryParm' not compatible with the target field.");
        }
        
        internal static void parse_TDWVDAPostInvocationParameters(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TDWVDAPostInvocationParameters.");
        }
        internal static void incompatible_with_TDWVDAPostInvocationParameters()
        {
            throw new DataTypeIncompatibleException("Data type 'TDWVDAPostInvocationParameters' not compatible with the target field.");
        }
        
        internal static void parse_TDWVDARevocationListEntryParm(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TDWVDARevocationListEntryParm.");
        }
        internal static void incompatible_with_TDWVDARevocationListEntryParm()
        {
            throw new DataTypeIncompatibleException("Data type 'TDWVDARevocationListEntryParm' not compatible with the target field.");
        }
        
        internal static void parse_TDWVDAServiceEndpointEntryParm(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TDWVDAServiceEndpointEntryParm.");
        }
        internal static void incompatible_with_TDWVDAServiceEndpointEntryParm()
        {
            throw new DataTypeIncompatibleException("Data type 'TDWVDAServiceEndpointEntryParm' not compatible with the target field.");
        }
        
        internal static void parse_TDWVDASmartContractEntry_Claims(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TDWVDASmartContractEntry_Claims.");
        }
        internal static void incompatible_with_TDWVDASmartContractEntry_Claims()
        {
            throw new DataTypeIncompatibleException("Data type 'TDWVDASmartContractEntry_Claims' not compatible with the target field.");
        }
        
        internal static void parse_TDWVDASmartContractEntry_Envelope(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TDWVDASmartContractEntry_Envelope.");
        }
        internal static void incompatible_with_TDWVDASmartContractEntry_Envelope()
        {
            throw new DataTypeIncompatibleException("Data type 'TDWVDASmartContractEntry_Envelope' not compatible with the target field.");
        }
        
        internal static void parse_TDWVDASmartContractEntry_EnvelopeContent(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TDWVDASmartContractEntry_EnvelopeContent.");
        }
        internal static void incompatible_with_TDWVDASmartContractEntry_EnvelopeContent()
        {
            throw new DataTypeIncompatibleException("Data type 'TDWVDASmartContractEntry_EnvelopeContent' not compatible with the target field.");
        }
        
        internal static void parse_TRAClaim(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRAClaim.");
        }
        internal static void incompatible_with_TRAClaim()
        {
            throw new DataTypeIncompatibleException("Data type 'TRAClaim' not compatible with the target field.");
        }
        
        internal static void parse_TRACredential_Envelope(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRACredential_Envelope.");
        }
        internal static void incompatible_with_TRACredential_Envelope()
        {
            throw new DataTypeIncompatibleException("Data type 'TRACredential_Envelope' not compatible with the target field.");
        }
        
        internal static void parse_TRACredential_EnvelopeContent(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRACredential_EnvelopeContent.");
        }
        internal static void incompatible_with_TRACredential_EnvelopeContent()
        {
            throw new DataTypeIncompatibleException("Data type 'TRACredential_EnvelopeContent' not compatible with the target field.");
        }
        
        internal static void parse_TRACredential_EnvelopeSeal(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRACredential_EnvelopeSeal.");
        }
        internal static void incompatible_with_TRACredential_EnvelopeSeal()
        {
            throw new DataTypeIncompatibleException("Data type 'TRACredential_EnvelopeSeal' not compatible with the target field.");
        }
        
        internal static void parse_TRACredential_PackingLabel(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRACredential_PackingLabel.");
        }
        internal static void incompatible_with_TRACredential_PackingLabel()
        {
            throw new DataTypeIncompatibleException("Data type 'TRACredential_PackingLabel' not compatible with the target field.");
        }
        
        internal static void parse_TRAEncryptedClaims(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRAEncryptedClaims.");
        }
        internal static void incompatible_with_TRAEncryptedClaims()
        {
            throw new DataTypeIncompatibleException("Data type 'TRAEncryptedClaims' not compatible with the target field.");
        }
        
        internal static void parse_TRAKeyValuePair(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRAKeyValuePair.");
        }
        internal static void incompatible_with_TRAKeyValuePair()
        {
            throw new DataTypeIncompatibleException("Data type 'TRAKeyValuePair' not compatible with the target field.");
        }
        
        internal static void parse_TRACredentialType(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRACredentialType.");
        }
        internal static void incompatible_with_TRACredentialType()
        {
            throw new DataTypeIncompatibleException("Data type 'TRACredentialType' not compatible with the target field.");
        }
        
        internal static void parse_TRAEncryptionFlag(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRAEncryptionFlag.");
        }
        internal static void incompatible_with_TRAEncryptionFlag()
        {
            throw new DataTypeIncompatibleException("Data type 'TRAEncryptionFlag' not compatible with the target field.");
        }
        
        internal static void parse_TRAServiceType(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRAServiceType.");
        }
        internal static void incompatible_with_TRAServiceType()
        {
            throw new DataTypeIncompatibleException("Data type 'TRAServiceType' not compatible with the target field.");
        }
        
        internal static void parse_TRATrustLevel(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRATrustLevel.");
        }
        internal static void incompatible_with_TRATrustLevel()
        {
            throw new DataTypeIncompatibleException("Data type 'TRATrustLevel' not compatible with the target field.");
        }
        
        internal static void parse_List_List_TRAKeyValuePair(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into List<List<TRAKeyValuePair>>.");
        }
        internal static void incompatible_with_List_List_TRAKeyValuePair()
        {
            throw new DataTypeIncompatibleException("Data type 'List<List<TRAKeyValuePair>>' not compatible with the target field.");
        }
        
        internal static void parse_List_TRAClaim(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into List<TRAClaim>.");
        }
        internal static void incompatible_with_List_TRAClaim()
        {
            throw new DataTypeIncompatibleException("Data type 'List<TRAClaim>' not compatible with the target field.");
        }
        
        internal static void parse_TDWVDAAccountEntry_Claims_nullable(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TDWVDAAccountEntry_Claims?.");
        }
        internal static void incompatible_with_TDWVDAAccountEntry_Claims_nullable()
        {
            throw new DataTypeIncompatibleException("Data type 'TDWVDAAccountEntry_Claims?' not compatible with the target field.");
        }
        
        internal static void parse_TDWVDAAccountEntry_EnvelopeContent_nullable(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TDWVDAAccountEntry_EnvelopeContent?.");
        }
        internal static void incompatible_with_TDWVDAAccountEntry_EnvelopeContent_nullable()
        {
            throw new DataTypeIncompatibleException("Data type 'TDWVDAAccountEntry_EnvelopeContent?' not compatible with the target field.");
        }
        
        internal static void parse_TDWVDASmartContractEntry_Claims_nullable(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TDWVDASmartContractEntry_Claims?.");
        }
        internal static void incompatible_with_TDWVDASmartContractEntry_Claims_nullable()
        {
            throw new DataTypeIncompatibleException("Data type 'TDWVDASmartContractEntry_Claims?' not compatible with the target field.");
        }
        
        internal static void parse_TDWVDASmartContractEntry_EnvelopeContent_nullable(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TDWVDASmartContractEntry_EnvelopeContent?.");
        }
        internal static void incompatible_with_TDWVDASmartContractEntry_EnvelopeContent_nullable()
        {
            throw new DataTypeIncompatibleException("Data type 'TDWVDASmartContractEntry_EnvelopeContent?' not compatible with the target field.");
        }
        
        internal static void parse_TRAEncryptedClaims_nullable(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRAEncryptedClaims?.");
        }
        internal static void incompatible_with_TRAEncryptedClaims_nullable()
        {
            throw new DataTypeIncompatibleException("Data type 'TRAEncryptedClaims?' not compatible with the target field.");
        }
        
        internal static void data_type_incompatible_with_list(string type)
        {
            throw new DataTypeIncompatibleException("Data type '" + type + "' not compatible with the target list.");
        }
        internal static void data_type_incompatible_with_field(string type)
        {
            throw new DataTypeIncompatibleException("Data type '" + type + "' not compatible with the target field.");
        }
        internal static void target__field_not_list()
        {
            throw new DataTypeIncompatibleException("Target field is not a List, value or a string, cannot perform append operation.");
        }
        internal static void list_incompatible_list(string type)
        {
            throw new DataTypeIncompatibleException("List type '" + type + "' not compatible with the target list.");
        }
        internal static void incompatible_with_cell()
        {
            throw new DataTypeIncompatibleException("Data type incompatible with the cell.");
        }
        internal static void array_dimension_size_mismatch(string type)
        {
            throw new ArgumentException(type + ": Array dimension size mismatch.");
        }
        internal static void invalid_cell_type()
        {
            throw new ArgumentException("Invalid cell type name. If you want a new cell type, please define it in your TSL.");
        }
        internal static void undefined_field()
        {
            throw new ArgumentException("Undefined field.");
        }
        
        internal static void member_access_on_non_struct__field(string field_name_string)
        {
            throw new DataTypeIncompatibleException("Cannot apply member access method on a non-struct field'" + field_name_string + "'.");
        }
        internal static void cell_not_found()
        {
            throw new CellNotFoundException("The cell is not found.");
        }
        internal static void cell_not_found(long cellId)
        {
            throw new CellNotFoundException("The cell with id = " + cellId + " not found.");
        }
        internal static void wrong_cell_type()
        {
            throw new CellTypeNotMatchException("Cell type mismatched.");
        }
        internal static unsafe void cannot_parse(string value, string type_str)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into " + type_str + ".");
        }
        internal static unsafe byte* invalid_resize_on_fixed_struct()
        {
            throw new InvalidOperationException("Invalid resize operation on a fixed struct.");
        }
    }
}

#pragma warning restore 162,168,649,660,661,1522
