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
namespace TDW.TDACommon
{
    internal class ExternalParser
    {
        
        internal static unsafe bool TryParse_long_Array_4(string s, out long[] value)
        {
            long[] value_type_value;
            JArray jarray;
            
            try
            {
                jarray = JArray.Parse(s);
                value = new  long[4] ;long  element;
                int long_offset = 0;
                
                for (int long_0 = 0; long_0 < 4; ++long_0)
                
                {
                    
                    {
                        if (!long.TryParse((string)jarray[long_offset++], out element))
                            continue;
                        value[long_0] = element;
                    }
                    
                }
                return true;
            }
            catch
            {
                value = default(long[]);
                return false;
            }
            
        }
        
        internal static unsafe bool TryParse_List_long(string s, out List<long> value)
        {
            List<long> value_type_value;
            JArray jarray;
            
            try
            {
                value = new List<long>();
                jarray = JArray.Parse(s);
                foreach (var jarray_element in jarray)
                {
                    long element;
                    
                    if (!long.TryParse((string)jarray_element, out element))
                    {
                        continue;
                    }
                    value.Add(element);
                    
                }
                return true;
            }
            catch
            {
                value = default(List<long>);
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
        
        #region Mute
        
        #endregion
    }
}

#pragma warning restore 162,168,649,660,661,1522
