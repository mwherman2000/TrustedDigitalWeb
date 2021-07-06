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
namespace TDW.TRAServer
{
    
    /// <summary>
    /// A .NET runtime object representation of TDWCredentialResponse defined in TSL.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct TDWCredentialResponse
    {
        
        ///<summary>
        ///Initializes a new instance of TDWCredentialResponse with the specified parameters.
        ///</summary>
        public TDWCredentialResponse(long id = default(long),string udid = default(string),long rc = default(long),List<string> messages = default(List<string>))
        {
            
            this.id = id;
            
            this.udid = udid;
            
            this.rc = rc;
            
            this.messages = messages;
            
        }
        
        public static bool operator ==(TDWCredentialResponse a, TDWCredentialResponse b)
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
                
                (a.id == b.id)
                &&
                (a.udid == b.udid)
                &&
                (a.rc == b.rc)
                &&
                (a.messages == b.messages)
                
                ;
            
        }
        public static bool operator !=(TDWCredentialResponse a, TDWCredentialResponse b)
        {
            return !(a == b);
        }
        
        public long id;
        
        public string udid;
        
        public long rc;
        
        public List<string> messages;
        
        /// <summary>
        /// Converts the string representation of a TDWCredentialResponse to its
        /// struct equivalent. A return value indicates whether the 
        /// operation succeeded.
        /// </summary>
        /// <param name="input">A string to convert.</param>
        /// <param name="value">
        /// When this method returns, contains the struct equivalent of the value contained 
        /// in input, if the conversion succeeded, or default(TDWCredentialResponse) if the conversion
        /// failed. The conversion fails if the input parameter is null or String.Empty, or is 
        /// not of the correct format. This parameter is passed uninitialized. 
        /// </param>
        /// <returns>True if input was converted successfully; otherwise, false.</returns>
        public unsafe static bool TryParse(string input, out TDWCredentialResponse value)
        {
            try
            {
                value = Newtonsoft.Json.JsonConvert.DeserializeObject<TDWCredentialResponse>(input);
                return true;
            }
            catch { value = default(TDWCredentialResponse); return false; }
        }
        public static TDWCredentialResponse Parse(string input)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TDWCredentialResponse>(input);
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
    /// Provides in-place operations of TDWCredentialResponse defined in TSL.
    /// </summary>
    public unsafe partial class TDWCredentialResponse_Accessor : IAccessor
    {
        ///<summary>
        ///The pointer to the content of the object.
        ///</summary>
        internal byte* m_ptr;
        internal long m_cellId;
        internal unsafe TDWCredentialResponse_Accessor(byte* _CellPtr
            
            , ResizeFunctionDelegate func
            )
        {
            m_ptr = _CellPtr;
            
            ResizeFunction = func;
                    udid_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        messages_Accessor_Field = new StringAccessorListAccessor(null,
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
            {            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);}
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
            {            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);}
            int size = (int)(targetPtr - m_ptr);
            return size;
        }
        public ResizeFunctionDelegate ResizeFunction { get; set; }
        #endregion
        
        ///<summary>
        ///Provides in-place access to the object field id.
        ///</summary>
        public unsafe long id
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {}
                return *(long*)(targetPtr);
                
            }
            set
            {
                
                byte* targetPtr = m_ptr;
                {}                *(long*)targetPtr = value;
            }
        }
        StringAccessor udid_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field udid.
        ///</summary>
        public unsafe StringAccessor udid
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 8;
}udid_Accessor_Field.m_ptr = targetPtr + 4;
                udid_Accessor_Field.m_cellId = this.m_cellId;
                return udid_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                udid_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 8;
}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != udid_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    udid_Accessor_Field.m_ptr = udid_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, udid_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        udid_Accessor_Field.m_ptr = udid_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, udid_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        
        ///<summary>
        ///Provides in-place access to the object field rc.
        ///</summary>
        public unsafe long rc
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);}
                return *(long*)(targetPtr);
                
            }
            set
            {
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);}                *(long*)targetPtr = value;
            }
        }
        StringAccessorListAccessor messages_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field messages.
        ///</summary>
        public unsafe StringAccessorListAccessor messages
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}messages_Accessor_Field.m_ptr = targetPtr + 4;
                messages_Accessor_Field.m_cellId = this.m_cellId;
                return messages_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                messages_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != messages_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    messages_Accessor_Field.m_ptr = messages_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, messages_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        messages_Accessor_Field.m_ptr = messages_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, messages_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        
        public static unsafe implicit operator TDWCredentialResponse(TDWCredentialResponse_Accessor accessor)
        {
            
            return new TDWCredentialResponse(
                
                        accessor.id,
                        accessor.udid,
                        accessor.rc,
                        accessor.messages
                );
        }
        
        public unsafe static implicit operator TDWCredentialResponse_Accessor(TDWCredentialResponse field)
        {
            byte* targetPtr = null;
            
            {
            targetPtr += 8;

        if(field.udid!= null)
        {
            int strlen_2 = field.udid.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

{

    targetPtr += sizeof(int);
    if(field.messages!= null)
    {
        for(int iterator_2 = 0;iterator_2<field.messages.Count;++iterator_2)
        {

        if(field.messages[iterator_2]!= null)
        {
            int strlen_3 = field.messages[iterator_2].Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        }
    }

}

            }
            byte* tmpcellptr = BufferAllocator.AllocBuffer((int)targetPtr);
            Memory.memset(tmpcellptr, 0, (ulong)targetPtr);
            targetPtr = tmpcellptr;
            
            {
            *(long*)targetPtr = field.id;
            targetPtr += 8;

        if(field.udid!= null)
        {
            int strlen_2 = field.udid.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.udid)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = field.rc;
            targetPtr += 8;

{
byte *storedPtr_2 = targetPtr;

    targetPtr += sizeof(int);
    if(field.messages!= null)
    {
        for(int iterator_2 = 0;iterator_2<field.messages.Count;++iterator_2)
        {

        if(field.messages[iterator_2]!= null)
        {
            int strlen_3 = field.messages[iterator_2].Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.messages[iterator_2])
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        }
    }
*(int*)storedPtr_2 = (int)(targetPtr - storedPtr_2 - 4);

}

            }TDWCredentialResponse_Accessor ret;
            
            ret = new TDWCredentialResponse_Accessor(tmpcellptr, null);
            
            return ret;
        }
        
        public static bool operator ==(TDWCredentialResponse_Accessor a, TDWCredentialResponse_Accessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            byte* targetPtr = a.m_ptr;
            {            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);}
            int lengthA = (int)(targetPtr - a.m_ptr);
            targetPtr = b.m_ptr;
            {            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);}
            int lengthB = (int)(targetPtr - b.m_ptr);
            if(lengthA != lengthB) return false;
            return Memory.Compare(a.m_ptr,b.m_ptr,lengthA);
        }
        public static bool operator != (TDWCredentialResponse_Accessor a, TDWCredentialResponse_Accessor b)
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
