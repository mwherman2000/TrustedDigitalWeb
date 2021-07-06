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
        
        static Dictionary<string, uint> FieldLookupTable_TRAEnvelope = new Dictionary<string, uint>()
        {
            
            {"credtype" , 0}
            ,
            {"encryptionFlag" , 1}
            ,
            {"hashedThumbprint64" , 2}
            ,
            {"signedHashSignature64" , 3}
            ,
            {"notaryStamp" , 4}
            ,
            {"comments" , 5}
            
        };
        
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
        
        static Dictionary<string, uint> FieldLookupTable_TRACredentialCore = new Dictionary<string, uint>()
        {
            
            {"udid" , 0}
            ,
            {"context" , 1}
            ,
            {"claims" , 2}
            
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
        
        internal static void SetField<T>(TRAEnvelope_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRAEnvelope.TryGetValue(member_name_string, out member_id))
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
            if (!FieldLookupTable_TRAEnvelope.TryGetValue(fieldName, out member_id))
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
                        TRAEncryptionFlag conversion_result = TypeConverter<T>.ConvertTo_TRAEncryptionFlag(value);
                        
            {
                accessor.encryptionFlag = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
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
                
                case 3:
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
                
                case 4:
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
                
            }
        }
        internal static T GetField<T>(TRAEnvelope_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRAEnvelope.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRAEnvelope.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_TRACredentialType(accessor.credtype);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_TRAEncryptionFlag(accessor.encryptionFlag);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.hashedThumbprint64);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_string(accessor.signedHashSignature64);
                    break;
                
                case 4:
                    return TypeConverter<T>.ConvertFrom_string(accessor.notaryStamp);
                    break;
                
                case 5:
                    return TypeConverter<T>.ConvertFrom_List_string(accessor.comments);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
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
        
        internal static void SetField<T>(TRACredentialCore_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRACredentialCore.TryGetValue(member_name_string, out member_id))
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
            if (!FieldLookupTable_TRACredentialCore.TryGetValue(fieldName, out member_id))
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
        internal static T GetField<T>(TRACredentialCore_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRACredentialCore.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRACredentialCore.TryGetValue(fieldName, out member_id))
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
