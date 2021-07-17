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
namespace TDW.VDAServer
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
        
        static Dictionary<string, uint> FieldLookupTable_TRAEncryptedClaims = new Dictionary<string, uint>()
        {
            
            {"ciphertext16" , 0}
            ,
            {"alg" , 1}
            ,
            {"key" , 2}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TRACredential_Content = new Dictionary<string, uint>()
        {
            
            {"udid" , 0}
            ,
            {"context" , 1}
            ,
            {"claims" , 2}
            ,
            {"encryptedclaims" , 3}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TRACredential_Label = new Dictionary<string, uint>()
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
        
        static Dictionary<string, uint> FieldLookupTable_TRACredential_Envelope = new Dictionary<string, uint>()
        {
            
            {"content" , 0}
            ,
            {"label" , 1}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TRACredential_EnvelopeSeal = new Dictionary<string, uint>()
        {
            
            {"hashedThumbprint64" , 0}
            ,
            {"signedHashSignature64" , 1}
            ,
            {"notaryStamp" , 2}
            ,
            {"comments" , 3}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TDWVDAAccountEntryClaims = new Dictionary<string, uint>()
        {
            
            {"walletname" , 0}
            ,
            {"walletpassword" , 1}
            ,
            {"walletaccountname" , 2}
            ,
            {"ledgeraddress" , 3}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TDWVDAAccountEntryContent = new Dictionary<string, uint>()
        {
            
            {"udid" , 0}
            ,
            {"context" , 1}
            ,
            {"claims" , 2}
            ,
            {"encryptedclaims" , 3}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TDWVDAAccountEntryEnvelope = new Dictionary<string, uint>()
        {
            
            {"content" , 0}
            ,
            {"label" , 1}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TDWVDASmartContractEntryClaims = new Dictionary<string, uint>()
        {
            
            {"smartcontractledgeraddress" , 0}
            ,
            {"vdaserviceendpointudid" , 1}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TDWVDASmartContractEntryContent = new Dictionary<string, uint>()
        {
            
            {"udid" , 0}
            ,
            {"context" , 1}
            ,
            {"claims" , 2}
            ,
            {"encryptedclaims" , 3}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TDWVDASmartContractEntryEnvelope = new Dictionary<string, uint>()
        {
            
            {"content" , 0}
            ,
            {"label" , 1}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TDWVDAServiceEndpointEntryParm = new Dictionary<string, uint>()
        {
            
            {"servicetype" , 0}
            ,
            {"id" , 1}
            ,
            {"udid" , 2}
            ,
            {"url" , 3}
            ,
            {"port" , 4}
            ,
            {"controllerudid" , 5}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TDWVDARevocationListEntryParm = new Dictionary<string, uint>()
        {
            
            {"revokeraddress" , 0}
            ,
            {"id" , 1}
            ,
            {"udid" , 2}
            ,
            {"credid" , 3}
            ,
            {"credudid" , 4}
            ,
            {"serviceEndpointUdid" , 5}
            ,
            {"revokedtocks" , 6}
            ,
            {"revokedbyudid" , 7}
            ,
            {"message" , 8}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TDWVDAIdentityRegistryEntryParm = new Dictionary<string, uint>()
        {
            
            {"id" , 0}
            ,
            {"udid" , 1}
            ,
            {"credid" , 2}
            ,
            {"credudid" , 3}
            ,
            {"credpublickey" , 4}
            ,
            {"serviceEndpointUdid" , 5}
            ,
            {"issuerudid" , 6}
            ,
            {"controllerudid" , 7}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TDWVDAPostInvocationParameters = new Dictionary<string, uint>()
        {
            
            {"serviceEndpointUrl" , 0}
            ,
            {"servicEndpointPort" , 1}
            ,
            {"wallet" , 2}
            ,
            {"walletPassword" , 3}
            ,
            {"senderAccount" , 4}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TDWPostResponse = new Dictionary<string, uint>()
        {
            
            {"result" , 0}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TDWGetVDAPostResultRequest = new Dictionary<string, uint>()
        {
            
            {"parms" , 0}
            ,
            {"txId" , 1}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TDWGetVDAPostResultResponse = new Dictionary<string, uint>()
        {
            
            {"result" , 0}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TDWPostVDAIdentityRegistryEntryRequest = new Dictionary<string, uint>()
        {
            
            {"parms" , 0}
            ,
            {"entry" , 1}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TDWIsCredentialValidRequest = new Dictionary<string, uint>()
        {
            
            {"udid" , 0}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TDWIsCredentialValidResponse = new Dictionary<string, uint>()
        {
            
            {"IsCredentialValid" , 0}
            ,
            {"trustlevel" , 1}
            ,
            {"message" , 2}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TDWIsCredentialRevokedRequest = new Dictionary<string, uint>()
        {
            
            {"udid" , 0}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TDWIsCredentialRevokedResponse = new Dictionary<string, uint>()
        {
            
            {"IsCredentialRevoked" , 0}
            ,
            {"message" , 1}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TDWIsCredentialVerifiedRequest = new Dictionary<string, uint>()
        {
            
            {"udid" , 0}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TDWIsCredentialVerifiedResponse = new Dictionary<string, uint>()
        {
            
            {"IsCredentialVerified" , 0}
            ,
            {"message" , 1}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TDWPostVDAServiceEndpointEntryRequest = new Dictionary<string, uint>()
        {
            
            {"parms" , 0}
            ,
            {"entry" , 1}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TDWGetServiceEndpointEntryRequest = new Dictionary<string, uint>()
        {
            
            {"udid" , 0}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TDWGetServiceEndpointEntryResponse = new Dictionary<string, uint>()
        {
            
            {"entry" , 0}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TDWPostVDARevocationListEntryRequest = new Dictionary<string, uint>()
        {
            
            {"parms" , 0}
            ,
            {"entry" , 1}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TDWGetRevocationListEntryRequest = new Dictionary<string, uint>()
        {
            
            {"udid" , 0}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TDWGetRevocationListEntryResponse = new Dictionary<string, uint>()
        {
            
            {"entry" , 0}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TDWSaveAccountRegistryEntryRequest = new Dictionary<string, uint>()
        {
            
            {"id" , 0}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TDWSaveAccountRegistryEntryResponse = new Dictionary<string, uint>()
        {
            
            {"id" , 0}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TDWGetAccountRegistryEntryRequest = new Dictionary<string, uint>()
        {
            
            {"udid" , 0}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TDWGetAccountRegistryEntryResponse = new Dictionary<string, uint>()
        {
            
            {"entry" , 0}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TDWSaveSmartContractRegistryEntryRequest = new Dictionary<string, uint>()
        {
            
            {"id" , 0}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TDWSaveSmartContractRegistryEntryResponse = new Dictionary<string, uint>()
        {
            
            {"id" , 0}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TDWGetSmartContractRegistryEntryRequest = new Dictionary<string, uint>()
        {
            
            {"udid" , 0}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TDWGetSmartContractRegistryEntryResponse = new Dictionary<string, uint>()
        {
            
            {"entry" , 0}
            
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
        
        internal static void SetField<T>(TRAEncryptedClaims_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRAEncryptedClaims.TryGetValue(member_name_string, out member_id))
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
            if (!FieldLookupTable_TRAEncryptedClaims.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.ciphertext16 = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.alg = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.key = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TRAEncryptedClaims_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRAEncryptedClaims.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRAEncryptedClaims.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.ciphertext16);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_string(accessor.alg);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.key);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TRACredential_Content_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRACredential_Content.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 3:
                        GenericFieldAccessor.SetField(accessor.encryptedclaims, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRACredential_Content.TryGetValue(fieldName, out member_id))
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
                if (conversion_result != default(List<TRAClaim>))
                    accessor.claims = conversion_result;
                else
                    accessor.Remove_claims();
            }
            
                        break;
                    }
                
                case 3:
                    {
                        TRAEncryptedClaims? conversion_result = TypeConverter<T>.ConvertTo_TRAEncryptedClaims_nullable(value);
                        
            {
                if (conversion_result.HasValue)
                    accessor.encryptedclaims = conversion_result.Value;
                else
                    accessor.Remove_encryptedclaims();
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TRACredential_Content_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRACredential_Content.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 3:
                        return GenericFieldAccessor.GetField<T>(accessor.encryptedclaims, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRACredential_Content.TryGetValue(fieldName, out member_id))
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
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_TRAEncryptedClaims_nullable(accessor.encryptedclaims);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TRACredential_Label_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRACredential_Label.TryGetValue(member_name_string, out member_id))
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
            if (!FieldLookupTable_TRACredential_Label.TryGetValue(fieldName, out member_id))
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
        internal static T GetField<T>(TRACredential_Label_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRACredential_Label.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRACredential_Label.TryGetValue(fieldName, out member_id))
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
        
        internal static void SetField<T>(TRACredential_Envelope_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRACredential_Envelope.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.content, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 1:
                        GenericFieldAccessor.SetField(accessor.label, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRACredential_Envelope.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        TRACredential_Content conversion_result = TypeConverter<T>.ConvertTo_TRACredential_Content(value);
                        
            {
                accessor.content = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        TRACredential_Label conversion_result = TypeConverter<T>.ConvertTo_TRACredential_Label(value);
                        
            {
                accessor.label = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TRACredential_Envelope_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRACredential_Envelope.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.content, fieldName, field_divider_idx + 1);
                    
                    case 1:
                        return GenericFieldAccessor.GetField<T>(accessor.label, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRACredential_Envelope.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_TRACredential_Content(accessor.content);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_TRACredential_Label(accessor.label);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TRACredential_EnvelopeSeal_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRACredential_EnvelopeSeal.TryGetValue(member_name_string, out member_id))
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
            if (!FieldLookupTable_TRACredential_EnvelopeSeal.TryGetValue(fieldName, out member_id))
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
        internal static T GetField<T>(TRACredential_EnvelopeSeal_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRACredential_EnvelopeSeal.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRACredential_EnvelopeSeal.TryGetValue(fieldName, out member_id))
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
        
        internal static void SetField<T>(TDWVDAAccountEntryClaims_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWVDAAccountEntryClaims.TryGetValue(member_name_string, out member_id))
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
            if (!FieldLookupTable_TDWVDAAccountEntryClaims.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.walletname = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.walletpassword = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.walletaccountname = conversion_result;
            }
            
                        break;
                    }
                
                case 3:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.ledgeraddress = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TDWVDAAccountEntryClaims_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWVDAAccountEntryClaims.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWVDAAccountEntryClaims.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.walletname);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_string(accessor.walletpassword);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.walletaccountname);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_string(accessor.ledgeraddress);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TDWVDAAccountEntryContent_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWVDAAccountEntryContent.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 2:
                        GenericFieldAccessor.SetField(accessor.claims, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 3:
                        GenericFieldAccessor.SetField(accessor.encryptedclaims, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWVDAAccountEntryContent.TryGetValue(fieldName, out member_id))
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
                        TDWVDAAccountEntryClaims? conversion_result = TypeConverter<T>.ConvertTo_TDWVDAAccountEntryClaims_nullable(value);
                        
            {
                if (conversion_result.HasValue)
                    accessor.claims = conversion_result.Value;
                else
                    accessor.Remove_claims();
            }
            
                        break;
                    }
                
                case 3:
                    {
                        TRAEncryptedClaims? conversion_result = TypeConverter<T>.ConvertTo_TRAEncryptedClaims_nullable(value);
                        
            {
                if (conversion_result.HasValue)
                    accessor.encryptedclaims = conversion_result.Value;
                else
                    accessor.Remove_encryptedclaims();
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TDWVDAAccountEntryContent_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWVDAAccountEntryContent.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 2:
                        return GenericFieldAccessor.GetField<T>(accessor.claims, fieldName, field_divider_idx + 1);
                    
                    case 3:
                        return GenericFieldAccessor.GetField<T>(accessor.encryptedclaims, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWVDAAccountEntryContent.TryGetValue(fieldName, out member_id))
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
                    return TypeConverter<T>.ConvertFrom_TDWVDAAccountEntryClaims_nullable(accessor.claims);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_TRAEncryptedClaims_nullable(accessor.encryptedclaims);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TDWVDAAccountEntryEnvelope_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWVDAAccountEntryEnvelope.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.content, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 1:
                        GenericFieldAccessor.SetField(accessor.label, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWVDAAccountEntryEnvelope.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        TDWVDAAccountEntryContent? conversion_result = TypeConverter<T>.ConvertTo_TDWVDAAccountEntryContent_nullable(value);
                        
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
                        TRACredential_Label conversion_result = TypeConverter<T>.ConvertTo_TRACredential_Label(value);
                        
            {
                accessor.label = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TDWVDAAccountEntryEnvelope_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWVDAAccountEntryEnvelope.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.content, fieldName, field_divider_idx + 1);
                    
                    case 1:
                        return GenericFieldAccessor.GetField<T>(accessor.label, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWVDAAccountEntryEnvelope.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_TDWVDAAccountEntryContent_nullable(accessor.content);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_TRACredential_Label(accessor.label);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TDWVDASmartContractEntryClaims_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWVDASmartContractEntryClaims.TryGetValue(member_name_string, out member_id))
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
            if (!FieldLookupTable_TDWVDASmartContractEntryClaims.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.smartcontractledgeraddress = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.vdaserviceendpointudid = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TDWVDASmartContractEntryClaims_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWVDASmartContractEntryClaims.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWVDASmartContractEntryClaims.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.smartcontractledgeraddress);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_string(accessor.vdaserviceendpointudid);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TDWVDASmartContractEntryContent_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWVDASmartContractEntryContent.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 2:
                        GenericFieldAccessor.SetField(accessor.claims, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 3:
                        GenericFieldAccessor.SetField(accessor.encryptedclaims, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWVDASmartContractEntryContent.TryGetValue(fieldName, out member_id))
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
                        TDWVDASmartContractEntryClaims? conversion_result = TypeConverter<T>.ConvertTo_TDWVDASmartContractEntryClaims_nullable(value);
                        
            {
                if (conversion_result.HasValue)
                    accessor.claims = conversion_result.Value;
                else
                    accessor.Remove_claims();
            }
            
                        break;
                    }
                
                case 3:
                    {
                        TRAEncryptedClaims? conversion_result = TypeConverter<T>.ConvertTo_TRAEncryptedClaims_nullable(value);
                        
            {
                if (conversion_result.HasValue)
                    accessor.encryptedclaims = conversion_result.Value;
                else
                    accessor.Remove_encryptedclaims();
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TDWVDASmartContractEntryContent_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWVDASmartContractEntryContent.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 2:
                        return GenericFieldAccessor.GetField<T>(accessor.claims, fieldName, field_divider_idx + 1);
                    
                    case 3:
                        return GenericFieldAccessor.GetField<T>(accessor.encryptedclaims, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWVDASmartContractEntryContent.TryGetValue(fieldName, out member_id))
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
                    return TypeConverter<T>.ConvertFrom_TDWVDASmartContractEntryClaims_nullable(accessor.claims);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_TRAEncryptedClaims_nullable(accessor.encryptedclaims);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TDWVDASmartContractEntryEnvelope_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWVDASmartContractEntryEnvelope.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.content, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 1:
                        GenericFieldAccessor.SetField(accessor.label, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWVDASmartContractEntryEnvelope.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        TDWVDASmartContractEntryContent? conversion_result = TypeConverter<T>.ConvertTo_TDWVDASmartContractEntryContent_nullable(value);
                        
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
                        TRACredential_Label conversion_result = TypeConverter<T>.ConvertTo_TRACredential_Label(value);
                        
            {
                accessor.label = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TDWVDASmartContractEntryEnvelope_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWVDASmartContractEntryEnvelope.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.content, fieldName, field_divider_idx + 1);
                    
                    case 1:
                        return GenericFieldAccessor.GetField<T>(accessor.label, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWVDASmartContractEntryEnvelope.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_TDWVDASmartContractEntryContent_nullable(accessor.content);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_TRACredential_Label(accessor.label);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TDWVDAServiceEndpointEntryParm_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWVDAServiceEndpointEntryParm.TryGetValue(member_name_string, out member_id))
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
            if (!FieldLookupTable_TDWVDAServiceEndpointEntryParm.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        TRAServiceType conversion_result = TypeConverter<T>.ConvertTo_TRAServiceType(value);
                        
            {
                accessor.servicetype = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        long conversion_result = TypeConverter<T>.ConvertTo_long(value);
                        
            {
                accessor.id = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.udid = conversion_result;
            }
            
                        break;
                    }
                
                case 3:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.url = conversion_result;
            }
            
                        break;
                    }
                
                case 4:
                    {
                        long conversion_result = TypeConverter<T>.ConvertTo_long(value);
                        
            {
                accessor.port = conversion_result;
            }
            
                        break;
                    }
                
                case 5:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.controllerudid = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TDWVDAServiceEndpointEntryParm_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWVDAServiceEndpointEntryParm.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWVDAServiceEndpointEntryParm.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_TRAServiceType(accessor.servicetype);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_long(accessor.id);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.udid);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_string(accessor.url);
                    break;
                
                case 4:
                    return TypeConverter<T>.ConvertFrom_long(accessor.port);
                    break;
                
                case 5:
                    return TypeConverter<T>.ConvertFrom_string(accessor.controllerudid);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TDWVDARevocationListEntryParm_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWVDARevocationListEntryParm.TryGetValue(member_name_string, out member_id))
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
            if (!FieldLookupTable_TDWVDARevocationListEntryParm.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.revokeraddress = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        long conversion_result = TypeConverter<T>.ConvertTo_long(value);
                        
            {
                accessor.id = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.udid = conversion_result;
            }
            
                        break;
                    }
                
                case 3:
                    {
                        long conversion_result = TypeConverter<T>.ConvertTo_long(value);
                        
            {
                accessor.credid = conversion_result;
            }
            
                        break;
                    }
                
                case 4:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.credudid = conversion_result;
            }
            
                        break;
                    }
                
                case 5:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.serviceEndpointUdid = conversion_result;
            }
            
                        break;
                    }
                
                case 6:
                    {
                        long conversion_result = TypeConverter<T>.ConvertTo_long(value);
                        
            {
                accessor.revokedtocks = conversion_result;
            }
            
                        break;
                    }
                
                case 7:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.revokedbyudid = conversion_result;
            }
            
                        break;
                    }
                
                case 8:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.message = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TDWVDARevocationListEntryParm_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWVDARevocationListEntryParm.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWVDARevocationListEntryParm.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.revokeraddress);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_long(accessor.id);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.udid);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_long(accessor.credid);
                    break;
                
                case 4:
                    return TypeConverter<T>.ConvertFrom_string(accessor.credudid);
                    break;
                
                case 5:
                    return TypeConverter<T>.ConvertFrom_string(accessor.serviceEndpointUdid);
                    break;
                
                case 6:
                    return TypeConverter<T>.ConvertFrom_long(accessor.revokedtocks);
                    break;
                
                case 7:
                    return TypeConverter<T>.ConvertFrom_string(accessor.revokedbyudid);
                    break;
                
                case 8:
                    return TypeConverter<T>.ConvertFrom_string(accessor.message);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TDWVDAIdentityRegistryEntryParm_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWVDAIdentityRegistryEntryParm.TryGetValue(member_name_string, out member_id))
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
            if (!FieldLookupTable_TDWVDAIdentityRegistryEntryParm.TryGetValue(fieldName, out member_id))
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
                accessor.credid = conversion_result;
            }
            
                        break;
                    }
                
                case 3:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.credudid = conversion_result;
            }
            
                        break;
                    }
                
                case 4:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.credpublickey = conversion_result;
            }
            
                        break;
                    }
                
                case 5:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.serviceEndpointUdid = conversion_result;
            }
            
                        break;
                    }
                
                case 6:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.issuerudid = conversion_result;
            }
            
                        break;
                    }
                
                case 7:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.controllerudid = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TDWVDAIdentityRegistryEntryParm_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWVDAIdentityRegistryEntryParm.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWVDAIdentityRegistryEntryParm.TryGetValue(fieldName, out member_id))
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
                    return TypeConverter<T>.ConvertFrom_long(accessor.credid);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_string(accessor.credudid);
                    break;
                
                case 4:
                    return TypeConverter<T>.ConvertFrom_string(accessor.credpublickey);
                    break;
                
                case 5:
                    return TypeConverter<T>.ConvertFrom_string(accessor.serviceEndpointUdid);
                    break;
                
                case 6:
                    return TypeConverter<T>.ConvertFrom_string(accessor.issuerudid);
                    break;
                
                case 7:
                    return TypeConverter<T>.ConvertFrom_string(accessor.controllerudid);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TDWVDAPostInvocationParameters_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWVDAPostInvocationParameters.TryGetValue(member_name_string, out member_id))
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
            if (!FieldLookupTable_TDWVDAPostInvocationParameters.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.serviceEndpointUrl = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        long conversion_result = TypeConverter<T>.ConvertTo_long(value);
                        
            {
                accessor.servicEndpointPort = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.wallet = conversion_result;
            }
            
                        break;
                    }
                
                case 3:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.walletPassword = conversion_result;
            }
            
                        break;
                    }
                
                case 4:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.senderAccount = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TDWVDAPostInvocationParameters_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWVDAPostInvocationParameters.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWVDAPostInvocationParameters.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.serviceEndpointUrl);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_long(accessor.servicEndpointPort);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.wallet);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_string(accessor.walletPassword);
                    break;
                
                case 4:
                    return TypeConverter<T>.ConvertFrom_string(accessor.senderAccount);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TDWPostResponse_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWPostResponse.TryGetValue(member_name_string, out member_id))
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
            if (!FieldLookupTable_TDWPostResponse.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.result = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TDWPostResponse_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWPostResponse.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWPostResponse.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.result);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TDWGetVDAPostResultRequest_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWGetVDAPostResultRequest.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.parms, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWGetVDAPostResultRequest.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        TDWVDAPostInvocationParameters conversion_result = TypeConverter<T>.ConvertTo_TDWVDAPostInvocationParameters(value);
                        
            {
                accessor.parms = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.txId = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TDWGetVDAPostResultRequest_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWGetVDAPostResultRequest.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.parms, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWGetVDAPostResultRequest.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_TDWVDAPostInvocationParameters(accessor.parms);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_string(accessor.txId);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TDWGetVDAPostResultResponse_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWGetVDAPostResultResponse.TryGetValue(member_name_string, out member_id))
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
            if (!FieldLookupTable_TDWGetVDAPostResultResponse.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.result = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TDWGetVDAPostResultResponse_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWGetVDAPostResultResponse.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWGetVDAPostResultResponse.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.result);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TDWPostVDAIdentityRegistryEntryRequest_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWPostVDAIdentityRegistryEntryRequest.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.parms, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 1:
                        GenericFieldAccessor.SetField(accessor.entry, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWPostVDAIdentityRegistryEntryRequest.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        TDWVDAPostInvocationParameters conversion_result = TypeConverter<T>.ConvertTo_TDWVDAPostInvocationParameters(value);
                        
            {
                accessor.parms = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        TDWVDAIdentityRegistryEntryParm conversion_result = TypeConverter<T>.ConvertTo_TDWVDAIdentityRegistryEntryParm(value);
                        
            {
                accessor.entry = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TDWPostVDAIdentityRegistryEntryRequest_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWPostVDAIdentityRegistryEntryRequest.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.parms, fieldName, field_divider_idx + 1);
                    
                    case 1:
                        return GenericFieldAccessor.GetField<T>(accessor.entry, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWPostVDAIdentityRegistryEntryRequest.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_TDWVDAPostInvocationParameters(accessor.parms);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_TDWVDAIdentityRegistryEntryParm(accessor.entry);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TDWIsCredentialValidRequest_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWIsCredentialValidRequest.TryGetValue(member_name_string, out member_id))
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
            if (!FieldLookupTable_TDWIsCredentialValidRequest.TryGetValue(fieldName, out member_id))
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
                
            }
        }
        internal static T GetField<T>(TDWIsCredentialValidRequest_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWIsCredentialValidRequest.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWIsCredentialValidRequest.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.udid);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TDWIsCredentialValidResponse_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWIsCredentialValidResponse.TryGetValue(member_name_string, out member_id))
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
            if (!FieldLookupTable_TDWIsCredentialValidResponse.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        bool conversion_result = TypeConverter<T>.ConvertTo_bool(value);
                        
            {
                accessor.IsCredentialValid = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        TRATrustLevel conversion_result = TypeConverter<T>.ConvertTo_TRATrustLevel(value);
                        
            {
                accessor.trustlevel = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.message = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TDWIsCredentialValidResponse_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWIsCredentialValidResponse.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWIsCredentialValidResponse.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_bool(accessor.IsCredentialValid);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_TRATrustLevel(accessor.trustlevel);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.message);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TDWIsCredentialRevokedRequest_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWIsCredentialRevokedRequest.TryGetValue(member_name_string, out member_id))
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
            if (!FieldLookupTable_TDWIsCredentialRevokedRequest.TryGetValue(fieldName, out member_id))
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
                
            }
        }
        internal static T GetField<T>(TDWIsCredentialRevokedRequest_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWIsCredentialRevokedRequest.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWIsCredentialRevokedRequest.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.udid);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TDWIsCredentialRevokedResponse_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWIsCredentialRevokedResponse.TryGetValue(member_name_string, out member_id))
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
            if (!FieldLookupTable_TDWIsCredentialRevokedResponse.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        bool conversion_result = TypeConverter<T>.ConvertTo_bool(value);
                        
            {
                accessor.IsCredentialRevoked = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.message = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TDWIsCredentialRevokedResponse_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWIsCredentialRevokedResponse.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWIsCredentialRevokedResponse.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_bool(accessor.IsCredentialRevoked);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_string(accessor.message);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TDWIsCredentialVerifiedRequest_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWIsCredentialVerifiedRequest.TryGetValue(member_name_string, out member_id))
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
            if (!FieldLookupTable_TDWIsCredentialVerifiedRequest.TryGetValue(fieldName, out member_id))
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
                
            }
        }
        internal static T GetField<T>(TDWIsCredentialVerifiedRequest_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWIsCredentialVerifiedRequest.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWIsCredentialVerifiedRequest.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.udid);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TDWIsCredentialVerifiedResponse_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWIsCredentialVerifiedResponse.TryGetValue(member_name_string, out member_id))
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
            if (!FieldLookupTable_TDWIsCredentialVerifiedResponse.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        bool conversion_result = TypeConverter<T>.ConvertTo_bool(value);
                        
            {
                accessor.IsCredentialVerified = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.message = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TDWIsCredentialVerifiedResponse_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWIsCredentialVerifiedResponse.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWIsCredentialVerifiedResponse.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_bool(accessor.IsCredentialVerified);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_string(accessor.message);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TDWPostVDAServiceEndpointEntryRequest_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWPostVDAServiceEndpointEntryRequest.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.parms, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 1:
                        GenericFieldAccessor.SetField(accessor.entry, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWPostVDAServiceEndpointEntryRequest.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        TDWVDAPostInvocationParameters conversion_result = TypeConverter<T>.ConvertTo_TDWVDAPostInvocationParameters(value);
                        
            {
                accessor.parms = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        TDWVDAServiceEndpointEntryParm conversion_result = TypeConverter<T>.ConvertTo_TDWVDAServiceEndpointEntryParm(value);
                        
            {
                accessor.entry = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TDWPostVDAServiceEndpointEntryRequest_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWPostVDAServiceEndpointEntryRequest.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.parms, fieldName, field_divider_idx + 1);
                    
                    case 1:
                        return GenericFieldAccessor.GetField<T>(accessor.entry, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWPostVDAServiceEndpointEntryRequest.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_TDWVDAPostInvocationParameters(accessor.parms);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_TDWVDAServiceEndpointEntryParm(accessor.entry);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TDWGetServiceEndpointEntryRequest_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWGetServiceEndpointEntryRequest.TryGetValue(member_name_string, out member_id))
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
            if (!FieldLookupTable_TDWGetServiceEndpointEntryRequest.TryGetValue(fieldName, out member_id))
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
                
            }
        }
        internal static T GetField<T>(TDWGetServiceEndpointEntryRequest_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWGetServiceEndpointEntryRequest.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWGetServiceEndpointEntryRequest.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.udid);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TDWGetServiceEndpointEntryResponse_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWGetServiceEndpointEntryResponse.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.entry, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWGetServiceEndpointEntryResponse.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        TDWVDAServiceEndpointEntryParm conversion_result = TypeConverter<T>.ConvertTo_TDWVDAServiceEndpointEntryParm(value);
                        
            {
                accessor.entry = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TDWGetServiceEndpointEntryResponse_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWGetServiceEndpointEntryResponse.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.entry, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWGetServiceEndpointEntryResponse.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_TDWVDAServiceEndpointEntryParm(accessor.entry);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TDWPostVDARevocationListEntryRequest_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWPostVDARevocationListEntryRequest.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.parms, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 1:
                        GenericFieldAccessor.SetField(accessor.entry, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWPostVDARevocationListEntryRequest.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        TDWVDAPostInvocationParameters conversion_result = TypeConverter<T>.ConvertTo_TDWVDAPostInvocationParameters(value);
                        
            {
                accessor.parms = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        TDWVDARevocationListEntryParm conversion_result = TypeConverter<T>.ConvertTo_TDWVDARevocationListEntryParm(value);
                        
            {
                accessor.entry = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TDWPostVDARevocationListEntryRequest_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWPostVDARevocationListEntryRequest.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.parms, fieldName, field_divider_idx + 1);
                    
                    case 1:
                        return GenericFieldAccessor.GetField<T>(accessor.entry, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWPostVDARevocationListEntryRequest.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_TDWVDAPostInvocationParameters(accessor.parms);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_TDWVDARevocationListEntryParm(accessor.entry);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TDWGetRevocationListEntryRequest_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWGetRevocationListEntryRequest.TryGetValue(member_name_string, out member_id))
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
            if (!FieldLookupTable_TDWGetRevocationListEntryRequest.TryGetValue(fieldName, out member_id))
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
                
            }
        }
        internal static T GetField<T>(TDWGetRevocationListEntryRequest_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWGetRevocationListEntryRequest.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWGetRevocationListEntryRequest.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.udid);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TDWGetRevocationListEntryResponse_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWGetRevocationListEntryResponse.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.entry, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWGetRevocationListEntryResponse.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        TDWVDARevocationListEntryParm conversion_result = TypeConverter<T>.ConvertTo_TDWVDARevocationListEntryParm(value);
                        
            {
                accessor.entry = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TDWGetRevocationListEntryResponse_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWGetRevocationListEntryResponse.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.entry, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWGetRevocationListEntryResponse.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_TDWVDARevocationListEntryParm(accessor.entry);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TDWSaveAccountRegistryEntryRequest_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWSaveAccountRegistryEntryRequest.TryGetValue(member_name_string, out member_id))
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
            if (!FieldLookupTable_TDWSaveAccountRegistryEntryRequest.TryGetValue(fieldName, out member_id))
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
                
            }
        }
        internal static T GetField<T>(TDWSaveAccountRegistryEntryRequest_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWSaveAccountRegistryEntryRequest.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWSaveAccountRegistryEntryRequest.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_long(accessor.id);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TDWSaveAccountRegistryEntryResponse_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWSaveAccountRegistryEntryResponse.TryGetValue(member_name_string, out member_id))
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
            if (!FieldLookupTable_TDWSaveAccountRegistryEntryResponse.TryGetValue(fieldName, out member_id))
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
                
            }
        }
        internal static T GetField<T>(TDWSaveAccountRegistryEntryResponse_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWSaveAccountRegistryEntryResponse.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWSaveAccountRegistryEntryResponse.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_long(accessor.id);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TDWGetAccountRegistryEntryRequest_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWGetAccountRegistryEntryRequest.TryGetValue(member_name_string, out member_id))
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
            if (!FieldLookupTable_TDWGetAccountRegistryEntryRequest.TryGetValue(fieldName, out member_id))
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
                
            }
        }
        internal static T GetField<T>(TDWGetAccountRegistryEntryRequest_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWGetAccountRegistryEntryRequest.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWGetAccountRegistryEntryRequest.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.udid);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TDWGetAccountRegistryEntryResponse_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWGetAccountRegistryEntryResponse.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.entry, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWGetAccountRegistryEntryResponse.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        TDWVDAAccountEntryClaims conversion_result = TypeConverter<T>.ConvertTo_TDWVDAAccountEntryClaims(value);
                        
            {
                accessor.entry = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TDWGetAccountRegistryEntryResponse_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWGetAccountRegistryEntryResponse.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.entry, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWGetAccountRegistryEntryResponse.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_TDWVDAAccountEntryClaims(accessor.entry);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TDWSaveSmartContractRegistryEntryRequest_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWSaveSmartContractRegistryEntryRequest.TryGetValue(member_name_string, out member_id))
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
            if (!FieldLookupTable_TDWSaveSmartContractRegistryEntryRequest.TryGetValue(fieldName, out member_id))
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
                
            }
        }
        internal static T GetField<T>(TDWSaveSmartContractRegistryEntryRequest_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWSaveSmartContractRegistryEntryRequest.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWSaveSmartContractRegistryEntryRequest.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_long(accessor.id);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TDWSaveSmartContractRegistryEntryResponse_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWSaveSmartContractRegistryEntryResponse.TryGetValue(member_name_string, out member_id))
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
            if (!FieldLookupTable_TDWSaveSmartContractRegistryEntryResponse.TryGetValue(fieldName, out member_id))
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
                
            }
        }
        internal static T GetField<T>(TDWSaveSmartContractRegistryEntryResponse_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWSaveSmartContractRegistryEntryResponse.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWSaveSmartContractRegistryEntryResponse.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_long(accessor.id);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TDWGetSmartContractRegistryEntryRequest_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWGetSmartContractRegistryEntryRequest.TryGetValue(member_name_string, out member_id))
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
            if (!FieldLookupTable_TDWGetSmartContractRegistryEntryRequest.TryGetValue(fieldName, out member_id))
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
                
            }
        }
        internal static T GetField<T>(TDWGetSmartContractRegistryEntryRequest_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWGetSmartContractRegistryEntryRequest.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWGetSmartContractRegistryEntryRequest.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.udid);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TDWGetSmartContractRegistryEntryResponse_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWGetSmartContractRegistryEntryResponse.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.entry, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWGetSmartContractRegistryEntryResponse.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        TDWVDASmartContractEntryContent conversion_result = TypeConverter<T>.ConvertTo_TDWVDASmartContractEntryContent(value);
                        
            {
                accessor.entry = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TDWGetSmartContractRegistryEntryResponse_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWGetSmartContractRegistryEntryResponse.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.entry, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWGetSmartContractRegistryEntryResponse.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_TDWVDASmartContractEntryContent(accessor.entry);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
    }
}

#pragma warning restore 162,168,649,660,661,1522
