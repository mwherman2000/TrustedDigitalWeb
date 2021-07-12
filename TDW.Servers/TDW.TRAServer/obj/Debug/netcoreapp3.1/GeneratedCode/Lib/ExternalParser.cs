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
        
        internal static unsafe bool TryParse_TRACredentialContent_nullable(string s, out TRACredentialContent? value)
        {
            TRACredentialContent value_type_value;
            JArray jarray;
            
            if (string.IsNullOrEmpty(s) || string.Compare(s, "null", ignoreCase: true) == 0)
            {
                value = default(TRACredentialContent?);
                return true;
            }
            else if (TRACredentialContent.TryParse(s, out value_type_value))
            {
                value = value_type_value;
                return true;
            }
            else
            {
                value = default(TRACredentialContent?);
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
