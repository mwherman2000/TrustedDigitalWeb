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
namespace TDW.TRAServer
{
    class Throw
    {
        
        internal static void parse_long(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into long.");
        }
        internal static void incompatible_with_long()
        {
            throw new DataTypeIncompatibleException("Data type 'long' not compatible with the target field.");
        }
        
        internal static void parse_double(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into double.");
        }
        internal static void incompatible_with_double()
        {
            throw new DataTypeIncompatibleException("Data type 'double' not compatible with the target field.");
        }
        
        internal static void parse_DateTime(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into DateTime.");
        }
        internal static void incompatible_with_DateTime()
        {
            throw new DataTypeIncompatibleException("Data type 'DateTime' not compatible with the target field.");
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
        
        internal static void parse_List_TRAClaim(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into List<TRAClaim>.");
        }
        internal static void incompatible_with_List_TRAClaim()
        {
            throw new DataTypeIncompatibleException("Data type 'List<TRAClaim>' not compatible with the target field.");
        }
        
        internal static void parse_List_TRAKeyValuePair(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into List<TRAKeyValuePair>.");
        }
        internal static void incompatible_with_List_TRAKeyValuePair()
        {
            throw new DataTypeIncompatibleException("Data type 'List<TRAKeyValuePair>' not compatible with the target field.");
        }
        
        internal static void parse_TRAClaim(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRAClaim.");
        }
        internal static void incompatible_with_TRAClaim()
        {
            throw new DataTypeIncompatibleException("Data type 'TRAClaim' not compatible with the target field.");
        }
        
        internal static void parse_TRACredentialContent(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRACredentialContent.");
        }
        internal static void incompatible_with_TRACredentialContent()
        {
            throw new DataTypeIncompatibleException("Data type 'TRACredentialContent' not compatible with the target field.");
        }
        
        internal static void parse_TRACredentialEnvelope(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRACredentialEnvelope.");
        }
        internal static void incompatible_with_TRACredentialEnvelope()
        {
            throw new DataTypeIncompatibleException("Data type 'TRACredentialEnvelope' not compatible with the target field.");
        }
        
        internal static void parse_TRACredentialEnvelopeSeal(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRACredentialEnvelopeSeal.");
        }
        internal static void incompatible_with_TRACredentialEnvelopeSeal()
        {
            throw new DataTypeIncompatibleException("Data type 'TRACredentialEnvelopeSeal' not compatible with the target field.");
        }
        
        internal static void parse_TRACredentialMetadata(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRACredentialMetadata.");
        }
        internal static void incompatible_with_TRACredentialMetadata()
        {
            throw new DataTypeIncompatibleException("Data type 'TRACredentialMetadata' not compatible with the target field.");
        }
        
        internal static void parse_TRAGeoLocationClaims(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRAGeoLocationClaims.");
        }
        internal static void incompatible_with_TRAGeoLocationClaims()
        {
            throw new DataTypeIncompatibleException("Data type 'TRAGeoLocationClaims' not compatible with the target field.");
        }
        
        internal static void parse_TRAGeoLocationContent(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRAGeoLocationContent.");
        }
        internal static void incompatible_with_TRAGeoLocationContent()
        {
            throw new DataTypeIncompatibleException("Data type 'TRAGeoLocationContent' not compatible with the target field.");
        }
        
        internal static void parse_TRAGeoLocationEnvelope(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRAGeoLocationEnvelope.");
        }
        internal static void incompatible_with_TRAGeoLocationEnvelope()
        {
            throw new DataTypeIncompatibleException("Data type 'TRAGeoLocationEnvelope' not compatible with the target field.");
        }
        
        internal static void parse_TRAKeyValuePair(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRAKeyValuePair.");
        }
        internal static void incompatible_with_TRAKeyValuePair()
        {
            throw new DataTypeIncompatibleException("Data type 'TRAKeyValuePair' not compatible with the target field.");
        }
        
        internal static void parse_TRAPostalAddressClaims(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRAPostalAddressClaims.");
        }
        internal static void incompatible_with_TRAPostalAddressClaims()
        {
            throw new DataTypeIncompatibleException("Data type 'TRAPostalAddressClaims' not compatible with the target field.");
        }
        
        internal static void parse_TRAPostalAddressContent(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRAPostalAddressContent.");
        }
        internal static void incompatible_with_TRAPostalAddressContent()
        {
            throw new DataTypeIncompatibleException("Data type 'TRAPostalAddressContent' not compatible with the target field.");
        }
        
        internal static void parse_TRAPostalAddressEnvelope(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRAPostalAddressEnvelope.");
        }
        internal static void incompatible_with_TRAPostalAddressEnvelope()
        {
            throw new DataTypeIncompatibleException("Data type 'TRAPostalAddressEnvelope' not compatible with the target field.");
        }
        
        internal static void parse_TRATimestampClaims(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRATimestampClaims.");
        }
        internal static void incompatible_with_TRATimestampClaims()
        {
            throw new DataTypeIncompatibleException("Data type 'TRATimestampClaims' not compatible with the target field.");
        }
        
        internal static void parse_TRATimestampContent(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRATimestampContent.");
        }
        internal static void incompatible_with_TRATimestampContent()
        {
            throw new DataTypeIncompatibleException("Data type 'TRATimestampContent' not compatible with the target field.");
        }
        
        internal static void parse_TRATimestampEnvelope(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRATimestampEnvelope.");
        }
        internal static void incompatible_with_TRATimestampEnvelope()
        {
            throw new DataTypeIncompatibleException("Data type 'TRATimestampEnvelope' not compatible with the target field.");
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
        
        internal static void parse_TRACredentialContent_nullable(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRACredentialContent?.");
        }
        internal static void incompatible_with_TRACredentialContent_nullable()
        {
            throw new DataTypeIncompatibleException("Data type 'TRACredentialContent?' not compatible with the target field.");
        }
        
        internal static void parse_TRAGeoLocationContent_nullable(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRAGeoLocationContent?.");
        }
        internal static void incompatible_with_TRAGeoLocationContent_nullable()
        {
            throw new DataTypeIncompatibleException("Data type 'TRAGeoLocationContent?' not compatible with the target field.");
        }
        
        internal static void parse_TRAPostalAddressContent_nullable(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRAPostalAddressContent?.");
        }
        internal static void incompatible_with_TRAPostalAddressContent_nullable()
        {
            throw new DataTypeIncompatibleException("Data type 'TRAPostalAddressContent?' not compatible with the target field.");
        }
        
        internal static void parse_TRATimestampContent_nullable(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRATimestampContent?.");
        }
        internal static void incompatible_with_TRATimestampContent_nullable()
        {
            throw new DataTypeIncompatibleException("Data type 'TRATimestampContent?' not compatible with the target field.");
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
