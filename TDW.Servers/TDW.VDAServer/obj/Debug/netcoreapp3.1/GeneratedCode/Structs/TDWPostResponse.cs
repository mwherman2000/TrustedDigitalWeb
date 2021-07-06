#pragma warning disable 162,168,649,660,661,1522
using System;
using System.Text;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Data;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.ExceptionServices;
using System.Security;
using Trinity;
using Trinity.Storage;
using Trinity.Utilities;
using Trinity.TSL.Lib;
using Trinity.Network;
using Trinity.Network.Sockets;
using Trinity.Network.Messaging;
using Trinity.TSL;
using System.Text.RegularExpressions;
using Trinity.Core.Lib;
namespace TDW.VDAServer
{
    
    /// <summary>
    /// A .NET runtime object representation of TDWPostResponse defined in TSL.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct TDWPostResponse
    {
        
        ///<summary>
        ///Initializes a new instance of TDWPostResponse with the specified parameters.
        ///</summary>
        public TDWPostResponse(string result = default(string))
        {
            
            this.result = result;
            
        }
        
        public static bool operator ==(TDWPostResponse a, TDWPostResponse b)
        {
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }
            
            return
                
                (a.result == b.result)
                
                ;
            
        }
        public static bool operator !=(TDWPostResponse a, TDWPostResponse b)
        {
            return !(a == b);
        }
        
        public string result;
        
        /// <summary>
        /// Converts the string representation of a TDWPostResponse to its
        /// struct equivalent. A return value indicates whether the 
        /// operation succeeded.
        /// </summary>
        /// <param name="input">A string to convert.</param>
        /// <param name="value">
        /// When this method returns, contains the struct equivalent of the value contained 
        /// in input, if the conversion succeeded, or default(TDWPostResponse) if the conversion
        /// failed. The conversion fails if the input parameter is null or String.Empty, or is 
        /// not of the correct format. This parameter is passed uninitialized. 
        /// </param>
        /// <returns>True if input was converted successfully; otherwise, false.</returns>
        public unsafe static bool TryParse(string input, out TDWPostResponse value)
        {
            try
            {
                value = Newtonsoft.Json.JsonConvert.DeserializeObject<TDWPostResponse>(input);
                return true;
            }
            catch { value = default(TDWPostResponse); return false; }
        }
        public static TDWPostResponse Parse(string input)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TDWPostResponse>(input);
        }
        /// <summary>
        /// Serializes this object to a Json string.
        /// </summary>
        /// <returns>The Json string serialized.</returns>
        public override string ToString()
        {
            return Serializer.ToString(this);
        }
    }
    /// <summary>
    /// Provides in-place operations of TDWPostResponse defined in TSL.
    /// </summary>
    public unsafe partial class TDWPostResponse_Accessor : IAccessor
    {
        ///<summary>
        ///The pointer to the content of the object.
        ///</summary>
        internal byte* m_ptr;
        internal long m_cellId;
        internal unsafe TDWPostResponse_Accessor(byte* _CellPtr
            
            , ResizeFunctionDelegate func
            )
        {
            m_ptr = _CellPtr;
            
            ResizeFunction = func;
                    result_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });
        }
        
        internal static string[] optional_field_names = null;
        ///<summary>
        ///Get an array of the names of all optional fields for object type t_struct_name.
        ///</summary>
        public static string[] GetOptionalFieldNames()
        {
            if (optional_field_names == null)
                optional_field_names = new string[]
                {
                    
                };
            return optional_field_names;
        }
        ///<summary>
        ///Get a list of the names of available optional fields in the object being operated by this accessor.
        ///</summary>
        internal List<string> GetNotNullOptionalFields()
        {
            List<string> list = new List<string>();
            BitArray ba = new BitArray(GetOptionalFieldMap());
            string[] optional_fields = GetOptionalFieldNames();
            for (int i = 0; i < ba.Count; i++)
            {
                if (ba[i])
                    list.Add(optional_fields[i]);
            }
            return list;
        }
        internal unsafe byte[] GetOptionalFieldMap()
        {
            
            return new byte[0];
            
        }
        
        ///<summary>
        ///Copies the struct content into a byte array.
        ///</summary>
        public byte[] ToByteArray()
        {
            byte* targetPtr = m_ptr;
            {targetPtr += *(int*)targetPtr + sizeof(int);}
            int size = (int)(targetPtr - m_ptr);
            byte[] ret = new byte[size];
            Memory.Copy(m_ptr, 0, ret, 0, size);
            return ret;
        }
        #region IAccessor
        public unsafe byte* GetUnderlyingBufferPointer()
        {
            return m_ptr;
        }
        public unsafe int GetBufferLength()
        {
            byte* targetPtr = m_ptr;
            {targetPtr += *(int*)targetPtr + sizeof(int);}
            int size = (int)(targetPtr - m_ptr);
            return size;
        }
        public ResizeFunctionDelegate ResizeFunction { get; set; }
        #endregion
        StringAccessor result_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field result.
        ///</summary>
        public unsafe StringAccessor result
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {}result_Accessor_Field.m_ptr = targetPtr + 4;
                result_Accessor_Field.m_cellId = this.m_cellId;
                return result_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                result_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != result_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    result_Accessor_Field.m_ptr = result_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, result_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        result_Accessor_Field.m_ptr = result_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, result_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        
        public static unsafe implicit operator TDWPostResponse(TDWPostResponse_Accessor accessor)
        {
            
            return new TDWPostResponse(
                
                        accessor.result
                );
        }
        
        public unsafe static implicit operator TDWPostResponse_Accessor(TDWPostResponse field)
        {
            byte* targetPtr = null;
            
            {

        if(field.result!= null)
        {
            int strlen_2 = field.result.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            byte* tmpcellptr = BufferAllocator.AllocBuffer((int)targetPtr);
            Memory.memset(tmpcellptr, 0, (ulong)targetPtr);
            targetPtr = tmpcellptr;
            
            {

        if(field.result!= null)
        {
            int strlen_2 = field.result.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.result)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }TDWPostResponse_Accessor ret;
            
            ret = new TDWPostResponse_Accessor(tmpcellptr, null);
            
            return ret;
        }
        
        public static bool operator ==(TDWPostResponse_Accessor a, TDWPostResponse_Accessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            byte* targetPtr = a.m_ptr;
            {targetPtr += *(int*)targetPtr + sizeof(int);}
            int lengthA = (int)(targetPtr - a.m_ptr);
            targetPtr = b.m_ptr;
            {targetPtr += *(int*)targetPtr + sizeof(int);}
            int lengthB = (int)(targetPtr - b.m_ptr);
            if(lengthA != lengthB) return false;
            return Memory.Compare(a.m_ptr,b.m_ptr,lengthA);
        }
        public static bool operator != (TDWPostResponse_Accessor a, TDWPostResponse_Accessor b)
        {
            return !(a == b);
        }
        
        /// <summary>
        /// Serializes this object to a Json string.
        /// </summary>
        /// <returns>The Json string serialized.</returns>
        public override string ToString()
        {
            return Serializer.ToString(this);
        }
        
    }
}

#pragma warning restore 162,168,649,660,661,1522
