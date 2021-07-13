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
namespace TDW.VDAServer
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
        
        internal static unsafe bool TryParse_TDWVDAAccountEntryContent_nullable(string s, out TDWVDAAccountEntryContent? value)
        {
            TDWVDAAccountEntryContent value_type_value;
            JArray jarray;
            
            if (string.IsNullOrEmpty(s) || string.Compare(s, "null", ignoreCase: true) == 0)
            {
                value = default(TDWVDAAccountEntryContent?);
                return true;
            }
            else if (TDWVDAAccountEntryContent.TryParse(s, out value_type_value))
            {
                value = value_type_value;
                return true;
            }
            else
            {
                value = default(TDWVDAAccountEntryContent?);
                return false;
            }
            
        }
        
        internal static unsafe bool TryParse_TDWVDASmartContractEntryContent_nullable(string s, out TDWVDASmartContractEntryContent? value)
        {
            TDWVDASmartContractEntryContent value_type_value;
            JArray jarray;
            
            if (string.IsNullOrEmpty(s) || string.Compare(s, "null", ignoreCase: true) == 0)
            {
                value = default(TDWVDASmartContractEntryContent?);
                return true;
            }
            else if (TDWVDASmartContractEntryContent.TryParse(s, out value_type_value))
            {
                value = value_type_value;
                return true;
            }
            else
            {
                value = default(TDWVDASmartContractEntryContent?);
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
        
        #region Mute
        
        #endregion
    }
}

#pragma warning restore 162,168,649,660,661,1522
