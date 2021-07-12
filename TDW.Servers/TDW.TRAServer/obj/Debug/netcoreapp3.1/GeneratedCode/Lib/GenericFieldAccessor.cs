#pragma warning disable 162,168,649,660,661,1522

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trinity;
using Trinity.TSL;
using Trinity.TSL.Lib;
namespace TDW.TRAServer
{
    internal struct GenericFieldAccessor
    {
        #region FieldID lookup table
        
        static Dictionary<string, uint> FieldLookupTable_TRAKeyValuePair = new Dictionary<string, uint>()
        {
            
            {"key" , 0}
            ,
            {"value" , 1}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TRAClaim = new Dictionary<string, uint>()
        {
            
            {"key" , 0}
            ,
            {"value" , 1}
            ,
            {"attribute" , 2}
            ,
            {"attributes" , 3}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TRACredentialContent = new Dictionary<string, uint>()
        {
            
            {"udid" , 0}
            ,
            {"context" , 1}
            ,
            {"claims" , 2}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TRACredentialMetadata = new Dictionary<string, uint>()
        {
            
            {"credtype" , 0}
            ,
            {"version" , 1}
            ,
            {"trustLevel" , 2}
            ,
            {"encryptionFlag" , 3}
            ,
            {"notaryudid" , 4}
            ,
            {"name" , 5}
            ,
            {"comment" , 6}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TRACredentialEnvelope = new Dictionary<string, uint>()
        {
            
            {"content" , 0}
            ,
            {"encryptedcontent" , 1}
            ,
            {"metadata" , 2}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TRACredentialEnvelopeSeal = new Dictionary<string, uint>()
        {
            
            {"hashedThumbprint64" , 0}
            ,
            {"signedHashSignature64" , 1}
            ,
            {"notaryStamp" , 2}
            ,
            {"comments" , 3}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TRATimestampClaims = new Dictionary<string, uint>()
        {
            
            {"ticks" , 0}
            ,
            {"datetime" , 1}
            ,
            {"timestamp" , 2}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TRATimestampContent = new Dictionary<string, uint>()
        {
            
            {"udid" , 0}
            ,
            {"context" , 1}
            ,
            {"claims" , 2}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TRATimestampEnvelope = new Dictionary<string, uint>()
        {
            
            {"content" , 0}
            ,
            {"encryptedcontent" , 1}
            ,
            {"metadata" , 2}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TRAGeoLocationClaims = new Dictionary<string, uint>()
        {
            
            {"latitude" , 0}
            ,
            {"longitude" , 1}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TRAGeoLocationContent = new Dictionary<string, uint>()
        {
            
            {"udid" , 0}
            ,
            {"context" , 1}
            ,
            {"claims" , 2}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TRAGeoLocationEnvelope = new Dictionary<string, uint>()
        {
            
            {"content" , 0}
            ,
            {"encryptedcontent" , 1}
            ,
            {"metadata" , 2}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TRAPostalAddressClaims = new Dictionary<string, uint>()
        {
            
            {"streetAddress" , 0}
            ,
            {"postOfficeBoxNumber" , 1}
            ,
            {"addressLocality" , 2}
            ,
            {"addressRegion" , 3}
            ,
            {"addressCountry" , 4}
            ,
            {"postalCode" , 5}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TRAPostalAddressContent = new Dictionary<string, uint>()
        {
            
            {"udid" , 0}
            ,
            {"context" , 1}
            ,
            {"claims" , 2}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TRAPostalAddressEnvelope = new Dictionary<string, uint>()
        {
            
            {"content" , 0}
            ,
            {"encryptedcontent" , 1}
            ,
            {"metadata" , 2}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TDWCreateTDWCredentialRequest = new Dictionary<string, uint>()
        {
            
            {"credtype" , 0}
            ,
            {"context" , 1}
            ,
            {"claims" , 2}
            ,
            {"trustlevel" , 3}
            ,
            {"encryptionFlag" , 4}
            ,
            {"comments" , 5}
            ,
            {"keypairsalt" , 6}
            ,
            {"mvcaudid" , 7}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TDWProcessCredentialRequest = new Dictionary<string, uint>()
        {
            
            {"id" , 0}
            ,
            {"mvcaudid" , 1}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TDWCredentialResponse = new Dictionary<string, uint>()
        {
            
            {"id" , 0}
            ,
            {"udid" , 1}
            ,
            {"rc" , 2}
            ,
            {"messages" , 3}
            
        };
        
        #endregion
        
        internal static void SetField<T>(TRAKeyValuePair_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRAKeyValuePair.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRAKeyValuePair.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.key = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.value = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TRAKeyValuePair_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRAKeyValuePair.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRAKeyValuePair.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.key);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_string(accessor.value);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TRAClaim_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRAClaim.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRAClaim.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.key = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                if (conversion_result != default(string))
                    accessor.value = conversion_result;
                else
                    accessor.Remove_value();
            }
            
                        break;
                    }
                
                case 2:
                    {
                        List<TRAKeyValuePair> conversion_result = TypeConverter<T>.ConvertTo_List_TRAKeyValuePair(value);
                        
            {
                if (conversion_result != default(List<TRAKeyValuePair>))
                    accessor.attribute = conversion_result;
                else
                    accessor.Remove_attribute();
            }
            
                        break;
                    }
                
                case 3:
                    {
                        List<List<TRAKeyValuePair>> conversion_result = TypeConverter<T>.ConvertTo_List_List_TRAKeyValuePair(value);
                        
            {
                if (conversion_result != default(List<List<TRAKeyValuePair>>))
                    accessor.attributes = conversion_result;
                else
                    accessor.Remove_attributes();
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TRAClaim_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRAClaim.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRAClaim.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.key);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_string(accessor.value);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_List_TRAKeyValuePair(accessor.attribute);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_List_List_TRAKeyValuePair(accessor.attributes);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TRACredentialContent_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRACredentialContent.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRACredentialContent.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.udid = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        List<string> conversion_result = TypeConverter<T>.ConvertTo_List_string(value);
                        
            {
                accessor.context = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        List<TRAClaim> conversion_result = TypeConverter<T>.ConvertTo_List_TRAClaim(value);
                        
            {
                accessor.claims = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TRACredentialContent_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRACredentialContent.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRACredentialContent.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.udid);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_List_string(accessor.context);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_List_TRAClaim(accessor.claims);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TRACredentialMetadata_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRACredentialMetadata.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRACredentialMetadata.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        TRACredentialType conversion_result = TypeConverter<T>.ConvertTo_TRACredentialType(value);
                        
            {
                accessor.credtype = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        long conversion_result = TypeConverter<T>.ConvertTo_long(value);
                        
            {
                accessor.version = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        TRATrustLevel conversion_result = TypeConverter<T>.ConvertTo_TRATrustLevel(value);
                        
            {
                accessor.trustLevel = conversion_result;
            }
            
                        break;
                    }
                
                case 3:
                    {
                        TRAEncryptionFlag conversion_result = TypeConverter<T>.ConvertTo_TRAEncryptionFlag(value);
                        
            {
                accessor.encryptionFlag = conversion_result;
            }
            
                        break;
                    }
                
                case 4:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.notaryudid = conversion_result;
            }
            
                        break;
                    }
                
                case 5:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                if (conversion_result != default(string))
                    accessor.name = conversion_result;
                else
                    accessor.Remove_name();
            }
            
                        break;
                    }
                
                case 6:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                if (conversion_result != default(string))
                    accessor.comment = conversion_result;
                else
                    accessor.Remove_comment();
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TRACredentialMetadata_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRACredentialMetadata.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRACredentialMetadata.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_TRACredentialType(accessor.credtype);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_long(accessor.version);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_TRATrustLevel(accessor.trustLevel);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_TRAEncryptionFlag(accessor.encryptionFlag);
                    break;
                
                case 4:
                    return TypeConverter<T>.ConvertFrom_string(accessor.notaryudid);
                    break;
                
                case 5:
                    return TypeConverter<T>.ConvertFrom_string(accessor.name);
                    break;
                
                case 6:
                    return TypeConverter<T>.ConvertFrom_string(accessor.comment);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TRACredentialEnvelope_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRACredentialEnvelope.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.content, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 2:
                        GenericFieldAccessor.SetField(accessor.metadata, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRACredentialEnvelope.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        TRACredentialContent? conversion_result = TypeConverter<T>.ConvertTo_TRACredentialContent_nullable(value);
                        
            {
                if (conversion_result.HasValue)
                    accessor.content = conversion_result.Value;
                else
                    accessor.Remove_content();
            }
            
                        break;
                    }
                
                case 1:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                if (conversion_result != default(string))
                    accessor.encryptedcontent = conversion_result;
                else
                    accessor.Remove_encryptedcontent();
            }
            
                        break;
                    }
                
                case 2:
                    {
                        TRACredentialMetadata conversion_result = TypeConverter<T>.ConvertTo_TRACredentialMetadata(value);
                        
            {
                accessor.metadata = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TRACredentialEnvelope_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRACredentialEnvelope.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.content, fieldName, field_divider_idx + 1);
                    
                    case 2:
                        return GenericFieldAccessor.GetField<T>(accessor.metadata, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRACredentialEnvelope.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_TRACredentialContent_nullable(accessor.content);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_string(accessor.encryptedcontent);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_TRACredentialMetadata(accessor.metadata);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TRACredentialEnvelopeSeal_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRACredentialEnvelopeSeal.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRACredentialEnvelopeSeal.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                if (conversion_result != default(string))
                    accessor.hashedThumbprint64 = conversion_result;
                else
                    accessor.Remove_hashedThumbprint64();
            }
            
                        break;
                    }
                
                case 1:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                if (conversion_result != default(string))
                    accessor.signedHashSignature64 = conversion_result;
                else
                    accessor.Remove_signedHashSignature64();
            }
            
                        break;
                    }
                
                case 2:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                if (conversion_result != default(string))
                    accessor.notaryStamp = conversion_result;
                else
                    accessor.Remove_notaryStamp();
            }
            
                        break;
                    }
                
                case 3:
                    {
                        List<string> conversion_result = TypeConverter<T>.ConvertTo_List_string(value);
                        
            {
                if (conversion_result != default(List<string>))
                    accessor.comments = conversion_result;
                else
                    accessor.Remove_comments();
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TRACredentialEnvelopeSeal_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRACredentialEnvelopeSeal.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRACredentialEnvelopeSeal.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.hashedThumbprint64);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_string(accessor.signedHashSignature64);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.notaryStamp);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_List_string(accessor.comments);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TRATimestampClaims_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRATimestampClaims.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRATimestampClaims.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        long conversion_result = TypeConverter<T>.ConvertTo_long(value);
                        
            {
                accessor.ticks = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        DateTime conversion_result = TypeConverter<T>.ConvertTo_DateTime(value);
                        
            {
                accessor.datetime = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.timestamp = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TRATimestampClaims_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRATimestampClaims.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRATimestampClaims.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_long(accessor.ticks);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_DateTime(accessor.datetime);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.timestamp);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TRATimestampContent_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRATimestampContent.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 2:
                        GenericFieldAccessor.SetField(accessor.claims, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRATimestampContent.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.udid = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        List<string> conversion_result = TypeConverter<T>.ConvertTo_List_string(value);
                        
            {
                accessor.context = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        TRATimestampClaims conversion_result = TypeConverter<T>.ConvertTo_TRATimestampClaims(value);
                        
            {
                accessor.claims = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TRATimestampContent_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRATimestampContent.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 2:
                        return GenericFieldAccessor.GetField<T>(accessor.claims, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRATimestampContent.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.udid);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_List_string(accessor.context);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_TRATimestampClaims(accessor.claims);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TRATimestampEnvelope_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRATimestampEnvelope.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.content, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 2:
                        GenericFieldAccessor.SetField(accessor.metadata, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRATimestampEnvelope.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        TRATimestampContent? conversion_result = TypeConverter<T>.ConvertTo_TRATimestampContent_nullable(value);
                        
            {
                if (conversion_result.HasValue)
                    accessor.content = conversion_result.Value;
                else
                    accessor.Remove_content();
            }
            
                        break;
                    }
                
                case 1:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                if (conversion_result != default(string))
                    accessor.encryptedcontent = conversion_result;
                else
                    accessor.Remove_encryptedcontent();
            }
            
                        break;
                    }
                
                case 2:
                    {
                        TRACredentialMetadata conversion_result = TypeConverter<T>.ConvertTo_TRACredentialMetadata(value);
                        
            {
                accessor.metadata = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TRATimestampEnvelope_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRATimestampEnvelope.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.content, fieldName, field_divider_idx + 1);
                    
                    case 2:
                        return GenericFieldAccessor.GetField<T>(accessor.metadata, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRATimestampEnvelope.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_TRATimestampContent_nullable(accessor.content);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_string(accessor.encryptedcontent);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_TRACredentialMetadata(accessor.metadata);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TRAGeoLocationClaims_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRAGeoLocationClaims.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRAGeoLocationClaims.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        double conversion_result = TypeConverter<T>.ConvertTo_double(value);
                        
            {
                accessor.latitude = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        double conversion_result = TypeConverter<T>.ConvertTo_double(value);
                        
            {
                accessor.longitude = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TRAGeoLocationClaims_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRAGeoLocationClaims.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRAGeoLocationClaims.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_double(accessor.latitude);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_double(accessor.longitude);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TRAGeoLocationContent_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRAGeoLocationContent.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 2:
                        GenericFieldAccessor.SetField(accessor.claims, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRAGeoLocationContent.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.udid = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        List<string> conversion_result = TypeConverter<T>.ConvertTo_List_string(value);
                        
            {
                accessor.context = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        TRAGeoLocationClaims conversion_result = TypeConverter<T>.ConvertTo_TRAGeoLocationClaims(value);
                        
            {
                accessor.claims = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TRAGeoLocationContent_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRAGeoLocationContent.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 2:
                        return GenericFieldAccessor.GetField<T>(accessor.claims, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRAGeoLocationContent.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.udid);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_List_string(accessor.context);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_TRAGeoLocationClaims(accessor.claims);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TRAGeoLocationEnvelope_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRAGeoLocationEnvelope.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.content, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 2:
                        GenericFieldAccessor.SetField(accessor.metadata, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRAGeoLocationEnvelope.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        TRAGeoLocationContent? conversion_result = TypeConverter<T>.ConvertTo_TRAGeoLocationContent_nullable(value);
                        
            {
                if (conversion_result.HasValue)
                    accessor.content = conversion_result.Value;
                else
                    accessor.Remove_content();
            }
            
                        break;
                    }
                
                case 1:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                if (conversion_result != default(string))
                    accessor.encryptedcontent = conversion_result;
                else
                    accessor.Remove_encryptedcontent();
            }
            
                        break;
                    }
                
                case 2:
                    {
                        TRACredentialMetadata conversion_result = TypeConverter<T>.ConvertTo_TRACredentialMetadata(value);
                        
            {
                accessor.metadata = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TRAGeoLocationEnvelope_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRAGeoLocationEnvelope.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.content, fieldName, field_divider_idx + 1);
                    
                    case 2:
                        return GenericFieldAccessor.GetField<T>(accessor.metadata, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRAGeoLocationEnvelope.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_TRAGeoLocationContent_nullable(accessor.content);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_string(accessor.encryptedcontent);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_TRACredentialMetadata(accessor.metadata);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TRAPostalAddressClaims_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRAPostalAddressClaims.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRAPostalAddressClaims.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.streetAddress = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.postOfficeBoxNumber = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.addressLocality = conversion_result;
            }
            
                        break;
                    }
                
                case 3:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.addressRegion = conversion_result;
            }
            
                        break;
                    }
                
                case 4:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.addressCountry = conversion_result;
            }
            
                        break;
                    }
                
                case 5:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.postalCode = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TRAPostalAddressClaims_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRAPostalAddressClaims.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRAPostalAddressClaims.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.streetAddress);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_string(accessor.postOfficeBoxNumber);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.addressLocality);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_string(accessor.addressRegion);
                    break;
                
                case 4:
                    return TypeConverter<T>.ConvertFrom_string(accessor.addressCountry);
                    break;
                
                case 5:
                    return TypeConverter<T>.ConvertFrom_string(accessor.postalCode);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TRAPostalAddressContent_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRAPostalAddressContent.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 2:
                        GenericFieldAccessor.SetField(accessor.claims, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRAPostalAddressContent.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.udid = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        List<string> conversion_result = TypeConverter<T>.ConvertTo_List_string(value);
                        
            {
                accessor.context = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        TRAPostalAddressClaims conversion_result = TypeConverter<T>.ConvertTo_TRAPostalAddressClaims(value);
                        
            {
                accessor.claims = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TRAPostalAddressContent_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRAPostalAddressContent.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 2:
                        return GenericFieldAccessor.GetField<T>(accessor.claims, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRAPostalAddressContent.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.udid);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_List_string(accessor.context);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_TRAPostalAddressClaims(accessor.claims);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TRAPostalAddressEnvelope_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRAPostalAddressEnvelope.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.content, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 2:
                        GenericFieldAccessor.SetField(accessor.metadata, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRAPostalAddressEnvelope.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        TRAPostalAddressContent? conversion_result = TypeConverter<T>.ConvertTo_TRAPostalAddressContent_nullable(value);
                        
            {
                if (conversion_result.HasValue)
                    accessor.content = conversion_result.Value;
                else
                    accessor.Remove_content();
            }
            
                        break;
                    }
                
                case 1:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                if (conversion_result != default(string))
                    accessor.encryptedcontent = conversion_result;
                else
                    accessor.Remove_encryptedcontent();
            }
            
                        break;
                    }
                
                case 2:
                    {
                        TRACredentialMetadata conversion_result = TypeConverter<T>.ConvertTo_TRACredentialMetadata(value);
                        
            {
                accessor.metadata = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TRAPostalAddressEnvelope_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRAPostalAddressEnvelope.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.content, fieldName, field_divider_idx + 1);
                    
                    case 2:
                        return GenericFieldAccessor.GetField<T>(accessor.metadata, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRAPostalAddressEnvelope.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_TRAPostalAddressContent_nullable(accessor.content);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_string(accessor.encryptedcontent);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_TRACredentialMetadata(accessor.metadata);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TDWCreateTDWCredentialRequest_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWCreateTDWCredentialRequest.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWCreateTDWCredentialRequest.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        TRACredentialType conversion_result = TypeConverter<T>.ConvertTo_TRACredentialType(value);
                        
            {
                accessor.credtype = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        List<string> conversion_result = TypeConverter<T>.ConvertTo_List_string(value);
                        
            {
                accessor.context = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        List<TRAClaim> conversion_result = TypeConverter<T>.ConvertTo_List_TRAClaim(value);
                        
            {
                accessor.claims = conversion_result;
            }
            
                        break;
                    }
                
                case 3:
                    {
                        TRATrustLevel conversion_result = TypeConverter<T>.ConvertTo_TRATrustLevel(value);
                        
            {
                accessor.trustlevel = conversion_result;
            }
            
                        break;
                    }
                
                case 4:
                    {
                        TRAEncryptionFlag conversion_result = TypeConverter<T>.ConvertTo_TRAEncryptionFlag(value);
                        
            {
                accessor.encryptionFlag = conversion_result;
            }
            
                        break;
                    }
                
                case 5:
                    {
                        List<string> conversion_result = TypeConverter<T>.ConvertTo_List_string(value);
                        
            {
                if (conversion_result != default(List<string>))
                    accessor.comments = conversion_result;
                else
                    accessor.Remove_comments();
            }
            
                        break;
                    }
                
                case 6:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.keypairsalt = conversion_result;
            }
            
                        break;
                    }
                
                case 7:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.mvcaudid = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TDWCreateTDWCredentialRequest_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWCreateTDWCredentialRequest.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWCreateTDWCredentialRequest.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_TRACredentialType(accessor.credtype);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_List_string(accessor.context);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_List_TRAClaim(accessor.claims);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_TRATrustLevel(accessor.trustlevel);
                    break;
                
                case 4:
                    return TypeConverter<T>.ConvertFrom_TRAEncryptionFlag(accessor.encryptionFlag);
                    break;
                
                case 5:
                    return TypeConverter<T>.ConvertFrom_List_string(accessor.comments);
                    break;
                
                case 6:
                    return TypeConverter<T>.ConvertFrom_string(accessor.keypairsalt);
                    break;
                
                case 7:
                    return TypeConverter<T>.ConvertFrom_string(accessor.mvcaudid);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TDWProcessCredentialRequest_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWProcessCredentialRequest.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWProcessCredentialRequest.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        long conversion_result = TypeConverter<T>.ConvertTo_long(value);
                        
            {
                accessor.id = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.mvcaudid = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TDWProcessCredentialRequest_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWProcessCredentialRequest.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWProcessCredentialRequest.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_long(accessor.id);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_string(accessor.mvcaudid);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TDWCredentialResponse_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWCredentialResponse.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWCredentialResponse.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        long conversion_result = TypeConverter<T>.ConvertTo_long(value);
                        
            {
                accessor.id = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.udid = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        long conversion_result = TypeConverter<T>.ConvertTo_long(value);
                        
            {
                accessor.rc = conversion_result;
            }
            
                        break;
                    }
                
                case 3:
                    {
                        List<string> conversion_result = TypeConverter<T>.ConvertTo_List_string(value);
                        
            {
                accessor.messages = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TDWCredentialResponse_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWCredentialResponse.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWCredentialResponse.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_long(accessor.id);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_string(accessor.udid);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_long(accessor.rc);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_List_string(accessor.messages);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
    }
}

#pragma warning restore 162,168,649,660,661,1522
