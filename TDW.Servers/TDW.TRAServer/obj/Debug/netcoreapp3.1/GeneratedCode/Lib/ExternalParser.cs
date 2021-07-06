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
        
        #region Mute
        
        #endregion
    }
}

#pragma warning restore 162,168,649,660,661,1522
