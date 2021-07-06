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
namespace TDW.KMAServer
{
    internal struct GenericFieldAccessor
    {
        #region FieldID lookup table
        
        static Dictionary<string, uint> FieldLookupTable_KMAInitializeMasterKeyVaultRequest = new Dictionary<string, uint>()
        {
            
            {"reserved" , 0}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_KMACreateKeyPairRequest = new Dictionary<string, uint>()
        {
            
            {"keypairsalt" , 0}
            ,
            {"keyringudid" , 1}
            ,
            {"keypairtype" , 2}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_KMAGetBestKeyPairRequest = new Dictionary<string, uint>()
        {
            
            {"keyringudid" , 0}
            ,
            {"keypairtype" , 1}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_KMAKeyPairResponse = new Dictionary<string, uint>()
        {
            
            {"id" , 0}
            ,
            {"udid" , 1}
            ,
            {"rc" , 2}
            ,
            {"messages" , 3}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_KMAComputePayloadHashRequest = new Dictionary<string, uint>()
        {
            
            {"payload64" , 0}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_KMAPayloadHashResponse = new Dictionary<string, uint>()
        {
            
            {"rc" , 0}
            ,
            {"messages" , 1}
            ,
            {"hash64" , 2}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_KMAComputeHashKeyPairSignatureRequest = new Dictionary<string, uint>()
        {
            
            {"keypairid" , 0}
            ,
            {"keypairsalt" , 1}
            ,
            {"hash64" , 2}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_KMAHashKeyPairSignatureResponse = new Dictionary<string, uint>()
        {
            
            {"rc" , 0}
            ,
            {"messages" , 1}
            ,
            {"signature64" , 2}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_KMAValidateHashKeyPairSignatureRequest = new Dictionary<string, uint>()
        {
            
            {"keypairid" , 0}
            ,
            {"keypairsalt" , 1}
            ,
            {"hash64" , 2}
            ,
            {"signature64" , 3}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_KMAValidateHashKeyPairSignatureResponse = new Dictionary<string, uint>()
        {
            
            {"rc" , 0}
            ,
            {"messages" , 1}
            ,
            {"valid" , 2}
            
        };
        
        #endregion
        
        internal static void SetField<T>(KMAInitializeMasterKeyVaultRequest_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_KMAInitializeMasterKeyVaultRequest.TryGetValue(member_name_string, out member_id))
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
            if (!FieldLookupTable_KMAInitializeMasterKeyVaultRequest.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.reserved = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(KMAInitializeMasterKeyVaultRequest_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_KMAInitializeMasterKeyVaultRequest.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_KMAInitializeMasterKeyVaultRequest.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.reserved);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(KMACreateKeyPairRequest_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_KMACreateKeyPairRequest.TryGetValue(member_name_string, out member_id))
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
            if (!FieldLookupTable_KMACreateKeyPairRequest.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.keypairsalt = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.keyringudid = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        KMAKeyPairType conversion_result = TypeConverter<T>.ConvertTo_KMAKeyPairType(value);
                        
            {
                accessor.keypairtype = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(KMACreateKeyPairRequest_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_KMACreateKeyPairRequest.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_KMACreateKeyPairRequest.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.keypairsalt);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_string(accessor.keyringudid);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_KMAKeyPairType(accessor.keypairtype);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(KMAGetBestKeyPairRequest_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_KMAGetBestKeyPairRequest.TryGetValue(member_name_string, out member_id))
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
            if (!FieldLookupTable_KMAGetBestKeyPairRequest.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.keyringudid = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        KMAKeyPairType conversion_result = TypeConverter<T>.ConvertTo_KMAKeyPairType(value);
                        
            {
                accessor.keypairtype = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(KMAGetBestKeyPairRequest_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_KMAGetBestKeyPairRequest.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_KMAGetBestKeyPairRequest.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.keyringudid);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_KMAKeyPairType(accessor.keypairtype);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(KMAKeyPairResponse_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_KMAKeyPairResponse.TryGetValue(member_name_string, out member_id))
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
            if (!FieldLookupTable_KMAKeyPairResponse.TryGetValue(fieldName, out member_id))
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
        internal static T GetField<T>(KMAKeyPairResponse_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_KMAKeyPairResponse.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_KMAKeyPairResponse.TryGetValue(fieldName, out member_id))
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
        
        internal static void SetField<T>(KMAComputePayloadHashRequest_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_KMAComputePayloadHashRequest.TryGetValue(member_name_string, out member_id))
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
            if (!FieldLookupTable_KMAComputePayloadHashRequest.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.payload64 = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(KMAComputePayloadHashRequest_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_KMAComputePayloadHashRequest.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_KMAComputePayloadHashRequest.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.payload64);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(KMAPayloadHashResponse_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_KMAPayloadHashResponse.TryGetValue(member_name_string, out member_id))
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
            if (!FieldLookupTable_KMAPayloadHashResponse.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        long conversion_result = TypeConverter<T>.ConvertTo_long(value);
                        
            {
                accessor.rc = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        List<string> conversion_result = TypeConverter<T>.ConvertTo_List_string(value);
                        
            {
                accessor.messages = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.hash64 = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(KMAPayloadHashResponse_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_KMAPayloadHashResponse.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_KMAPayloadHashResponse.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_long(accessor.rc);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_List_string(accessor.messages);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.hash64);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(KMAComputeHashKeyPairSignatureRequest_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_KMAComputeHashKeyPairSignatureRequest.TryGetValue(member_name_string, out member_id))
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
            if (!FieldLookupTable_KMAComputeHashKeyPairSignatureRequest.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        long conversion_result = TypeConverter<T>.ConvertTo_long(value);
                        
            {
                accessor.keypairid = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.keypairsalt = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.hash64 = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(KMAComputeHashKeyPairSignatureRequest_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_KMAComputeHashKeyPairSignatureRequest.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_KMAComputeHashKeyPairSignatureRequest.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_long(accessor.keypairid);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_string(accessor.keypairsalt);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.hash64);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(KMAHashKeyPairSignatureResponse_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_KMAHashKeyPairSignatureResponse.TryGetValue(member_name_string, out member_id))
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
            if (!FieldLookupTable_KMAHashKeyPairSignatureResponse.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        long conversion_result = TypeConverter<T>.ConvertTo_long(value);
                        
            {
                accessor.rc = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        List<string> conversion_result = TypeConverter<T>.ConvertTo_List_string(value);
                        
            {
                accessor.messages = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.signature64 = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(KMAHashKeyPairSignatureResponse_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_KMAHashKeyPairSignatureResponse.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_KMAHashKeyPairSignatureResponse.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_long(accessor.rc);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_List_string(accessor.messages);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.signature64);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(KMAValidateHashKeyPairSignatureRequest_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_KMAValidateHashKeyPairSignatureRequest.TryGetValue(member_name_string, out member_id))
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
            if (!FieldLookupTable_KMAValidateHashKeyPairSignatureRequest.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        long conversion_result = TypeConverter<T>.ConvertTo_long(value);
                        
            {
                accessor.keypairid = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.keypairsalt = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.hash64 = conversion_result;
            }
            
                        break;
                    }
                
                case 3:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.signature64 = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(KMAValidateHashKeyPairSignatureRequest_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_KMAValidateHashKeyPairSignatureRequest.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_KMAValidateHashKeyPairSignatureRequest.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_long(accessor.keypairid);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_string(accessor.keypairsalt);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.hash64);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_string(accessor.signature64);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(KMAValidateHashKeyPairSignatureResponse_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_KMAValidateHashKeyPairSignatureResponse.TryGetValue(member_name_string, out member_id))
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
            if (!FieldLookupTable_KMAValidateHashKeyPairSignatureResponse.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        long conversion_result = TypeConverter<T>.ConvertTo_long(value);
                        
            {
                accessor.rc = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        List<string> conversion_result = TypeConverter<T>.ConvertTo_List_string(value);
                        
            {
                accessor.messages = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        bool conversion_result = TypeConverter<T>.ConvertTo_bool(value);
                        
            {
                accessor.valid = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(KMAValidateHashKeyPairSignatureResponse_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_KMAValidateHashKeyPairSignatureResponse.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_KMAValidateHashKeyPairSignatureResponse.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_long(accessor.rc);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_List_string(accessor.messages);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_bool(accessor.valid);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
    }
}

#pragma warning restore 162,168,649,660,661,1522
