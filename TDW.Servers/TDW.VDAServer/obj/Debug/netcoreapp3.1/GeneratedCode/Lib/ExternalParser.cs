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
        
        internal static unsafe bool TryParse_TDWVDAAccountEntry_Claims_nullable(string s, out TDWVDAAccountEntry_Claims? value)
        {
            TDWVDAAccountEntry_Claims value_type_value;
            JArray jarray;
            
            if (string.IsNullOrEmpty(s) || string.Compare(s, "null", ignoreCase: true) == 0)
            {
                value = default(TDWVDAAccountEntry_Claims?);
                return true;
            }
            else if (TDWVDAAccountEntry_Claims.TryParse(s, out value_type_value))
            {
                value = value_type_value;
                return true;
            }
            else
            {
                value = default(TDWVDAAccountEntry_Claims?);
                return false;
            }
            
        }
        
        internal static unsafe bool TryParse_TDWVDAAccountEntry_EnvelopeContent_nullable(string s, out TDWVDAAccountEntry_EnvelopeContent? value)
        {
            TDWVDAAccountEntry_EnvelopeContent value_type_value;
            JArray jarray;
            
            if (string.IsNullOrEmpty(s) || string.Compare(s, "null", ignoreCase: true) == 0)
            {
                value = default(TDWVDAAccountEntry_EnvelopeContent?);
                return true;
            }
            else if (TDWVDAAccountEntry_EnvelopeContent.TryParse(s, out value_type_value))
            {
                value = value_type_value;
                return true;
            }
            else
            {
                value = default(TDWVDAAccountEntry_EnvelopeContent?);
                return false;
            }
            
        }
        
        internal static unsafe bool TryParse_TDWVDASmartContractEntry_Claims_nullable(string s, out TDWVDASmartContractEntry_Claims? value)
        {
            TDWVDASmartContractEntry_Claims value_type_value;
            JArray jarray;
            
            if (string.IsNullOrEmpty(s) || string.Compare(s, "null", ignoreCase: true) == 0)
            {
                value = default(TDWVDASmartContractEntry_Claims?);
                return true;
            }
            else if (TDWVDASmartContractEntry_Claims.TryParse(s, out value_type_value))
            {
                value = value_type_value;
                return true;
            }
            else
            {
                value = default(TDWVDASmartContractEntry_Claims?);
                return false;
            }
            
        }
        
        internal static unsafe bool TryParse_TDWVDASmartContractEntry_EnvelopeContent_nullable(string s, out TDWVDASmartContractEntry_EnvelopeContent? value)
        {
            TDWVDASmartContractEntry_EnvelopeContent value_type_value;
            JArray jarray;
            
            if (string.IsNullOrEmpty(s) || string.Compare(s, "null", ignoreCase: true) == 0)
            {
                value = default(TDWVDASmartContractEntry_EnvelopeContent?);
                return true;
            }
            else if (TDWVDASmartContractEntry_EnvelopeContent.TryParse(s, out value_type_value))
            {
                value = value_type_value;
                return true;
            }
            else
            {
                value = default(TDWVDASmartContractEntry_EnvelopeContent?);
                return false;
            }
            
        }
        
        internal static unsafe bool TryParse_TRAEncryptedClaims_nullable(string s, out TRAEncryptedClaims? value)
        {
            TRAEncryptedClaims value_type_value;
            JArray jarray;
            
            if (string.IsNullOrEmpty(s) || string.Compare(s, "null", ignoreCase: true) == 0)
            {
                value = default(TRAEncryptedClaims?);
                return true;
            }
            else if (TRAEncryptedClaims.TryParse(s, out value_type_value))
            {
                value = value_type_value;
                return true;
            }
            else
            {
                value = default(TRAEncryptedClaims?);
                return false;
            }
            
        }
        
        #region Mute
        
        #endregion
    }
}

#pragma warning restore 162,168,649,660,661,1522
