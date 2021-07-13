#pragma warning disable 162,168,649,660,661,1522

using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Trinity;
using Trinity.TSL;
using Trinity.TSL.Lib;
namespace TDW.TRAServer
{
    internal class ExternalParser
    {
        
        internal static unsafe bool TryParse_bool(string s, out bool value)
        {
            bool value_type_value;
            JArray jarray;
            
            {
                
                double double_val;
                if (bool.TryParse(s, out value_type_value))
                {
                    value = value_type_value;
                    return true;
                }
                else if (double.TryParse(s, out double_val))
                {
                    value = (double_val != 0);
                    return true;
                }
                else
                {
                    value = default(bool);
                    return false;
                }
            }
            
        }
        
        internal static unsafe bool TryParse_DateTime(string s, out DateTime value)
        {
            DateTime value_type_value;
            JArray jarray;
            
            {
                
                if (DateTime.TryParse(s, null, System.Globalization.DateTimeStyles.RoundtripKind, out value_type_value))
                {
                    value = value_type_value;
                    return true;
                }
                if (s.EndsWith(" UTC", StringComparison.Ordinal) && DateTime.TryParse(s.Substring(0, s.Length - 4) + 'Z', null, System.Globalization.DateTimeStyles.RoundtripKind, out value_type_value))
                {
                    value = value_type_value;
                    return true;
                }
                value  = default(DateTime);
                return false;
            }
            
        }
        
        internal static unsafe bool TryParse_List_string(string s, out List<string> value)
        {
            List<string> value_type_value;
            JArray jarray;
            
            try
            {
                value = new List<string>();
                jarray = JArray.Parse(s);
                foreach (var jarray_element in jarray)
                {
                    string element;
                    
                    value.Add((string)jarray_element);
                    
                }
                return true;
            }
            catch
            {
                value = default(List<string>);
                return false;
            }
            
        }
        
        internal static unsafe bool TryParse_List_Cac_AllowanceCharge(string s, out List<Cac_AllowanceCharge> value)
        {
            List<Cac_AllowanceCharge> value_type_value;
            JArray jarray;
            
            try
            {
                value = new List<Cac_AllowanceCharge>();
                jarray = JArray.Parse(s);
                foreach (var jarray_element in jarray)
                {
                    Cac_AllowanceCharge element;
                    
                    if (!Cac_AllowanceCharge.TryParse((string)jarray_element, out element))
                    {
                        continue;
                    }
                    value.Add(element);
                    
                }
                return true;
            }
            catch
            {
                value = default(List<Cac_AllowanceCharge>);
                return false;
            }
            
        }
        
        internal static unsafe bool TryParse_List_Cac_DocumentReference(string s, out List<Cac_DocumentReference> value)
        {
            List<Cac_DocumentReference> value_type_value;
            JArray jarray;
            
            try
            {
                value = new List<Cac_DocumentReference>();
                jarray = JArray.Parse(s);
                foreach (var jarray_element in jarray)
                {
                    Cac_DocumentReference element;
                    
                    if (!Cac_DocumentReference.TryParse((string)jarray_element, out element))
                    {
                        continue;
                    }
                    value.Add(element);
                    
                }
                return true;
            }
            catch
            {
                value = default(List<Cac_DocumentReference>);
                return false;
            }
            
        }
        
        internal static unsafe bool TryParse_List_Cac_InvoiceLine(string s, out List<Cac_InvoiceLine> value)
        {
            List<Cac_InvoiceLine> value_type_value;
            JArray jarray;
            
            try
            {
                value = new List<Cac_InvoiceLine>();
                jarray = JArray.Parse(s);
                foreach (var jarray_element in jarray)
                {
                    Cac_InvoiceLine element;
                    
                    if (!Cac_InvoiceLine.TryParse((string)jarray_element, out element))
                    {
                        continue;
                    }
                    value.Add(element);
                    
                }
                return true;
            }
            catch
            {
                value = default(List<Cac_InvoiceLine>);
                return false;
            }
            
        }
        
        internal static unsafe bool TryParse_List_Cac_TaxSubtotal(string s, out List<Cac_TaxSubtotal> value)
        {
            List<Cac_TaxSubtotal> value_type_value;
            JArray jarray;
            
            try
            {
                value = new List<Cac_TaxSubtotal>();
                jarray = JArray.Parse(s);
                foreach (var jarray_element in jarray)
                {
                    Cac_TaxSubtotal element;
                    
                    if (!Cac_TaxSubtotal.TryParse((string)jarray_element, out element))
                    {
                        continue;
                    }
                    value.Add(element);
                    
                }
                return true;
            }
            catch
            {
                value = default(List<Cac_TaxSubtotal>);
                return false;
            }
            
        }
        
        internal static unsafe bool TryParse_List_Cbc_ListCode(string s, out List<Cbc_ListCode> value)
        {
            List<Cbc_ListCode> value_type_value;
            JArray jarray;
            
            try
            {
                value = new List<Cbc_ListCode>();
                jarray = JArray.Parse(s);
                foreach (var jarray_element in jarray)
                {
                    Cbc_ListCode element;
                    
                    if (!Cbc_ListCode.TryParse((string)jarray_element, out element))
                    {
                        continue;
                    }
                    value.Add(element);
                    
                }
                return true;
            }
            catch
            {
                value = default(List<Cbc_ListCode>);
                return false;
            }
            
        }
        
        internal static unsafe bool TryParse_List_TRAClaim(string s, out List<TRAClaim> value)
        {
            List<TRAClaim> value_type_value;
            JArray jarray;
            
            try
            {
                value = new List<TRAClaim>();
                jarray = JArray.Parse(s);
                foreach (var jarray_element in jarray)
                {
                    TRAClaim element;
                    
                    if (!TRAClaim.TryParse((string)jarray_element, out element))
                    {
                        continue;
                    }
                    value.Add(element);
                    
                }
                return true;
            }
            catch
            {
                value = default(List<TRAClaim>);
                return false;
            }
            
        }
        
        internal static unsafe bool TryParse_List_TRAKeyValuePair(string s, out List<TRAKeyValuePair> value)
        {
            List<TRAKeyValuePair> value_type_value;
            JArray jarray;
            
            try
            {
                value = new List<TRAKeyValuePair>();
                jarray = JArray.Parse(s);
                foreach (var jarray_element in jarray)
                {
                    TRAKeyValuePair element;
                    
                    if (!TRAKeyValuePair.TryParse((string)jarray_element, out element))
                    {
                        continue;
                    }
                    value.Add(element);
                    
                }
                return true;
            }
            catch
            {
                value = default(List<TRAKeyValuePair>);
                return false;
            }
            
        }
        
        internal static unsafe bool TryParse_List_List_TRAKeyValuePair(string s, out List<List<TRAKeyValuePair>> value)
        {
            List<List<TRAKeyValuePair>> value_type_value;
            JArray jarray;
            
            try
            {
                value = new List<List<TRAKeyValuePair>>();
                jarray = JArray.Parse(s);
                foreach (var jarray_element in jarray)
                {
                    List<TRAKeyValuePair> element;
                    
                    if (!ExternalParser.TryParse_List_TRAKeyValuePair((string)jarray_element, out element))
                    {
                        continue;
                    }
                    value.Add(element);
                    
                }
                return true;
            }
            catch
            {
                value = default(List<List<TRAKeyValuePair>>);
                return false;
            }
            
        }
        
        internal static unsafe bool TryParse_Cac_Address_Content_nullable(string s, out Cac_Address_Content? value)
        {
            Cac_Address_Content value_type_value;
            JArray jarray;
            
            if (string.IsNullOrEmpty(s) || string.Compare(s, "null", ignoreCase: true) == 0)
            {
                value = default(Cac_Address_Content?);
                return true;
            }
            else if (Cac_Address_Content.TryParse(s, out value_type_value))
            {
                value = value_type_value;
                return true;
            }
            else
            {
                value = default(Cac_Address_Content?);
                return false;
            }
            
        }
        
        internal static unsafe bool TryParse_Cac_Attachment_nullable(string s, out Cac_Attachment? value)
        {
            Cac_Attachment value_type_value;
            JArray jarray;
            
            if (string.IsNullOrEmpty(s) || string.Compare(s, "null", ignoreCase: true) == 0)
            {
                value = default(Cac_Attachment?);
                return true;
            }
            else if (Cac_Attachment.TryParse(s, out value_type_value))
            {
                value = value_type_value;
                return true;
            }
            else
            {
                value = default(Cac_Attachment?);
                return false;
            }
            
        }
        
        internal static unsafe bool TryParse_Cac_Contact_Content_nullable(string s, out Cac_Contact_Content? value)
        {
            Cac_Contact_Content value_type_value;
            JArray jarray;
            
            if (string.IsNullOrEmpty(s) || string.Compare(s, "null", ignoreCase: true) == 0)
            {
                value = default(Cac_Contact_Content?);
                return true;
            }
            else if (Cac_Contact_Content.TryParse(s, out value_type_value))
            {
                value = value_type_value;
                return true;
            }
            else
            {
                value = default(Cac_Contact_Content?);
                return false;
            }
            
        }
        
        internal static unsafe bool TryParse_Cac_ExternalReference_Content_nullable(string s, out Cac_ExternalReference_Content? value)
        {
            Cac_ExternalReference_Content value_type_value;
            JArray jarray;
            
            if (string.IsNullOrEmpty(s) || string.Compare(s, "null", ignoreCase: true) == 0)
            {
                value = default(Cac_ExternalReference_Content?);
                return true;
            }
            else if (Cac_ExternalReference_Content.TryParse(s, out value_type_value))
            {
                value = value_type_value;
                return true;
            }
            else
            {
                value = default(Cac_ExternalReference_Content?);
                return false;
            }
            
        }
        
        internal static unsafe bool TryParse_Cac_Item_Content_nullable(string s, out Cac_Item_Content? value)
        {
            Cac_Item_Content value_type_value;
            JArray jarray;
            
            if (string.IsNullOrEmpty(s) || string.Compare(s, "null", ignoreCase: true) == 0)
            {
                value = default(Cac_Item_Content?);
                return true;
            }
            else if (Cac_Item_Content.TryParse(s, out value_type_value))
            {
                value = value_type_value;
                return true;
            }
            else
            {
                value = default(Cac_Item_Content?);
                return false;
            }
            
        }
        
        internal static unsafe bool TryParse_Cac_PartyLegalEntity_Content_nullable(string s, out Cac_PartyLegalEntity_Content? value)
        {
            Cac_PartyLegalEntity_Content value_type_value;
            JArray jarray;
            
            if (string.IsNullOrEmpty(s) || string.Compare(s, "null", ignoreCase: true) == 0)
            {
                value = default(Cac_PartyLegalEntity_Content?);
                return true;
            }
            else if (Cac_PartyLegalEntity_Content.TryParse(s, out value_type_value))
            {
                value = value_type_value;
                return true;
            }
            else
            {
                value = default(Cac_PartyLegalEntity_Content?);
                return false;
            }
            
        }
        
        internal static unsafe bool TryParse_Cac_Party_Content_nullable(string s, out Cac_Party_Content? value)
        {
            Cac_Party_Content value_type_value;
            JArray jarray;
            
            if (string.IsNullOrEmpty(s) || string.Compare(s, "null", ignoreCase: true) == 0)
            {
                value = default(Cac_Party_Content?);
                return true;
            }
            else if (Cac_Party_Content.TryParse(s, out value_type_value))
            {
                value = value_type_value;
                return true;
            }
            else
            {
                value = default(Cac_Party_Content?);
                return false;
            }
            
        }
        
        internal static unsafe bool TryParse_Cac_PayeeFinancialAccount_Content_nullable(string s, out Cac_PayeeFinancialAccount_Content? value)
        {
            Cac_PayeeFinancialAccount_Content value_type_value;
            JArray jarray;
            
            if (string.IsNullOrEmpty(s) || string.Compare(s, "null", ignoreCase: true) == 0)
            {
                value = default(Cac_PayeeFinancialAccount_Content?);
                return true;
            }
            else if (Cac_PayeeFinancialAccount_Content.TryParse(s, out value_type_value))
            {
                value = value_type_value;
                return true;
            }
            else
            {
                value = default(Cac_PayeeFinancialAccount_Content?);
                return false;
            }
            
        }
        
        internal static unsafe bool TryParse_Cac_PaymentMeans_Content_nullable(string s, out Cac_PaymentMeans_Content? value)
        {
            Cac_PaymentMeans_Content value_type_value;
            JArray jarray;
            
            if (string.IsNullOrEmpty(s) || string.Compare(s, "null", ignoreCase: true) == 0)
            {
                value = default(Cac_PaymentMeans_Content?);
                return true;
            }
            else if (Cac_PaymentMeans_Content.TryParse(s, out value_type_value))
            {
                value = value_type_value;
                return true;
            }
            else
            {
                value = default(Cac_PaymentMeans_Content?);
                return false;
            }
            
        }
        
        internal static unsafe bool TryParse_Cac_Person_Content_nullable(string s, out Cac_Person_Content? value)
        {
            Cac_Person_Content value_type_value;
            JArray jarray;
            
            if (string.IsNullOrEmpty(s) || string.Compare(s, "null", ignoreCase: true) == 0)
            {
                value = default(Cac_Person_Content?);
                return true;
            }
            else if (Cac_Person_Content.TryParse(s, out value_type_value))
            {
                value = value_type_value;
                return true;
            }
            else
            {
                value = default(Cac_Person_Content?);
                return false;
            }
            
        }
        
        internal static unsafe bool TryParse_Cbc_EmbeddedDocumentBinaryObject_nullable(string s, out Cbc_EmbeddedDocumentBinaryObject? value)
        {
            Cbc_EmbeddedDocumentBinaryObject value_type_value;
            JArray jarray;
            
            if (string.IsNullOrEmpty(s) || string.Compare(s, "null", ignoreCase: true) == 0)
            {
                value = default(Cbc_EmbeddedDocumentBinaryObject?);
                return true;
            }
            else if (Cbc_EmbeddedDocumentBinaryObject.TryParse(s, out value_type_value))
            {
                value = value_type_value;
                return true;
            }
            else
            {
                value = default(Cbc_EmbeddedDocumentBinaryObject?);
                return false;
            }
            
        }
        
        internal static unsafe bool TryParse_TRACredential_Content_nullable(string s, out TRACredential_Content? value)
        {
            TRACredential_Content value_type_value;
            JArray jarray;
            
            if (string.IsNullOrEmpty(s) || string.Compare(s, "null", ignoreCase: true) == 0)
            {
                value = default(TRACredential_Content?);
                return true;
            }
            else if (TRACredential_Content.TryParse(s, out value_type_value))
            {
                value = value_type_value;
                return true;
            }
            else
            {
                value = default(TRACredential_Content?);
                return false;
            }
            
        }
        
        internal static unsafe bool TryParse_TRAGeoLocationContent_nullable(string s, out TRAGeoLocationContent? value)
        {
            TRAGeoLocationContent value_type_value;
            JArray jarray;
            
            if (string.IsNullOrEmpty(s) || string.Compare(s, "null", ignoreCase: true) == 0)
            {
                value = default(TRAGeoLocationContent?);
                return true;
            }
            else if (TRAGeoLocationContent.TryParse(s, out value_type_value))
            {
                value = value_type_value;
                return true;
            }
            else
            {
                value = default(TRAGeoLocationContent?);
                return false;
            }
            
        }
        
        internal static unsafe bool TryParse_TRAPostalAddressContent_nullable(string s, out TRAPostalAddressContent? value)
        {
            TRAPostalAddressContent value_type_value;
            JArray jarray;
            
            if (string.IsNullOrEmpty(s) || string.Compare(s, "null", ignoreCase: true) == 0)
            {
                value = default(TRAPostalAddressContent?);
                return true;
            }
            else if (TRAPostalAddressContent.TryParse(s, out value_type_value))
            {
                value = value_type_value;
                return true;
            }
            else
            {
                value = default(TRAPostalAddressContent?);
                return false;
            }
            
        }
        
        internal static unsafe bool TryParse_TRATimestampContent_nullable(string s, out TRATimestampContent? value)
        {
            TRATimestampContent value_type_value;
            JArray jarray;
            
            if (string.IsNullOrEmpty(s) || string.Compare(s, "null", ignoreCase: true) == 0)
            {
                value = default(TRATimestampContent?);
                return true;
            }
            else if (TRATimestampContent.TryParse(s, out value_type_value))
            {
                value = value_type_value;
                return true;
            }
            else
            {
                value = default(TRATimestampContent?);
                return false;
            }
            
        }
        
        #region Mute
        
        #endregion
    }
}

#pragma warning restore 162,168,649,660,661,1522
