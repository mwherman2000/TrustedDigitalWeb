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
    /// A .NET runtime object representation of TRACredentialContent defined in TSL.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct TRACredentialContent
    {
        
        ///<summary>
        ///Initializes a new instance of TRACredentialContent with the specified parameters.
        ///</summary>
        public TRACredentialContent(TRACredentialCore core = default(TRACredentialCore),TRACredentialWrapper wrapper = default(TRACredentialWrapper))
        {
            
            this.core = core;
            
            this.wrapper = wrapper;
            
        }
        
        public static bool operator ==(TRACredentialContent a, TRACredentialContent b)
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
                
                (a.core == b.core)
                &&
                (a.wrapper == b.wrapper)
                
                ;
            
        }
        public static bool operator !=(TRACredentialContent a, TRACredentialContent b)
        {
            return !(a == b);
        }
        
        public TRACredentialCore core;
        
        public TRACredentialWrapper wrapper;
        
        /// <summary>
        /// Converts the string representation of a TRACredentialContent to its
        /// struct equivalent. A return value indicates whether the 
        /// operation succeeded.
        /// </summary>
        /// <param name="input">A string to convert.</param>
        /// <param name="value">
        /// When this method returns, contains the struct equivalent of the value contained 
        /// in input, if the conversion succeeded, or default(TRACredentialContent) if the conversion
        /// failed. The conversion fails if the input parameter is null or String.Empty, or is 
        /// not of the correct format. This parameter is passed uninitialized. 
        /// </param>
        /// <returns>True if input was converted successfully; otherwise, false.</returns>
        public unsafe static bool TryParse(string input, out TRACredentialContent value)
        {
            try
            {
                value = Newtonsoft.Json.JsonConvert.DeserializeObject<TRACredentialContent>(input);
                return true;
            }
            catch { value = default(TRACredentialContent); return false; }
        }
        public static TRACredentialContent Parse(string input)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TRACredentialContent>(input);
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
    /// Provides in-place operations of TRACredentialContent defined in TSL.
    /// </summary>
    public unsafe partial class TRACredentialContent_Accessor : IAccessor
    {
        ///<summary>
        ///The pointer to the content of the object.
        ///</summary>
        internal byte* m_ptr;
        internal long m_cellId;
        internal unsafe TRACredentialContent_Accessor(byte* _CellPtr
            
            , ResizeFunctionDelegate func
            )
        {
            m_ptr = _CellPtr;
            
            ResizeFunction = func;
                    core_Accessor_Field = new TRACredentialCore_Accessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        wrapper_Accessor_Field = new TRACredentialWrapper_Accessor(null,
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
            {{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 11;
targetPtr += *(int*)targetPtr + sizeof(int);}}
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
            {{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 11;
targetPtr += *(int*)targetPtr + sizeof(int);}}
            int size = (int)(targetPtr - m_ptr);
            return size;
        }
        public ResizeFunctionDelegate ResizeFunction { get; set; }
        #endregion
        TRACredentialCore_Accessor core_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field core.
        ///</summary>
        public unsafe TRACredentialCore_Accessor core
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {}core_Accessor_Field.m_ptr = targetPtr;
                core_Accessor_Field.m_cellId = this.m_cellId;
                return core_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                core_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {}
                int offset = (int)(targetPtr - m_ptr);
                byte* oldtargetPtr = targetPtr;
                int oldlength = (int)(targetPtr - oldtargetPtr);
                targetPtr = value.m_ptr;
                int newlength = (int)(targetPtr - value.m_ptr);
                if (newlength != oldlength)
                {
                    if (value.m_cellId != this.m_cellId)
                    {
                        this.m_ptr = this.ResizeFunction(this.m_ptr, offset, newlength - oldlength);
                        Memory.Copy(value.m_ptr, this.m_ptr + offset, newlength);
                    }
                    else
                    {
                        byte[] tmpcell = new byte[newlength];
                        fixed(byte* tmpcellptr = tmpcell)
                        {
                            Memory.Copy(value.m_ptr, tmpcellptr, newlength);
                            this.m_ptr = this.ResizeFunction(this.m_ptr, offset, newlength - oldlength);
                            Memory.Copy(tmpcellptr, this.m_ptr + offset, newlength);
                        }
                    }
                }
                else
                {
                    Memory.Copy(value.m_ptr, oldtargetPtr, oldlength);
                }
            }
        }
        TRACredentialWrapper_Accessor wrapper_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field wrapper.
        ///</summary>
        public unsafe TRACredentialWrapper_Accessor wrapper
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}}wrapper_Accessor_Field.m_ptr = targetPtr;
                wrapper_Accessor_Field.m_cellId = this.m_cellId;
                return wrapper_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                wrapper_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}}
                int offset = (int)(targetPtr - m_ptr);
                byte* oldtargetPtr = targetPtr;
                int oldlength = (int)(targetPtr - oldtargetPtr);
                targetPtr = value.m_ptr;
                int newlength = (int)(targetPtr - value.m_ptr);
                if (newlength != oldlength)
                {
                    if (value.m_cellId != this.m_cellId)
                    {
                        this.m_ptr = this.ResizeFunction(this.m_ptr, offset, newlength - oldlength);
                        Memory.Copy(value.m_ptr, this.m_ptr + offset, newlength);
                    }
                    else
                    {
                        byte[] tmpcell = new byte[newlength];
                        fixed(byte* tmpcellptr = tmpcell)
                        {
                            Memory.Copy(value.m_ptr, tmpcellptr, newlength);
                            this.m_ptr = this.ResizeFunction(this.m_ptr, offset, newlength - oldlength);
                            Memory.Copy(tmpcellptr, this.m_ptr + offset, newlength);
                        }
                    }
                }
                else
                {
                    Memory.Copy(value.m_ptr, oldtargetPtr, oldlength);
                }
            }
        }
        
        public static unsafe implicit operator TRACredentialContent(TRACredentialContent_Accessor accessor)
        {
            
            return new TRACredentialContent(
                
                        accessor.core,
                        accessor.wrapper
                );
        }
        
        public unsafe static implicit operator TRACredentialContent_Accessor(TRACredentialContent field)
        {
            byte* targetPtr = null;
            
            {

            {

        if(field.core.udid!= null)
        {
            int strlen_3 = field.core.udid.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

{

    targetPtr += sizeof(int);
    if(field.core.context!= null)
    {
        for(int iterator_3 = 0;iterator_3<field.core.context.Count;++iterator_3)
        {

        if(field.core.context[iterator_3]!= null)
        {
            int strlen_4 = field.core.context[iterator_3].Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        }
    }

}

{

    targetPtr += sizeof(int);
    if(field.core.claims!= null)
    {
        for(int iterator_3 = 0;iterator_3<field.core.claims.Count;++iterator_3)
        {

            {
            targetPtr += 1;

        if(field.core.claims[iterator_3].key!= null)
        {
            int strlen_5 = field.core.claims[iterator_3].key.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( field.core.claims[iterator_3].value!= null)
            {

        if(field.core.claims[iterator_3].value!= null)
        {
            int strlen_5 = field.core.claims[iterator_3].value.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( field.core.claims[iterator_3].attribute!= null)
            {

{

    targetPtr += sizeof(int);
    if(field.core.claims[iterator_3].attribute!= null)
    {
        for(int iterator_5 = 0;iterator_5<field.core.claims[iterator_3].attribute.Count;++iterator_5)
        {

            {

        if(field.core.claims[iterator_3].attribute[iterator_5].key!= null)
        {
            int strlen_7 = field.core.claims[iterator_3].attribute[iterator_5].key.Length * 2;
            targetPtr += strlen_7+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.core.claims[iterator_3].attribute[iterator_5].value!= null)
        {
            int strlen_7 = field.core.claims[iterator_3].attribute[iterator_5].value.Length * 2;
            targetPtr += strlen_7+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
        }
    }

}

            }
            if( field.core.claims[iterator_3].attributes!= null)
            {

{

    targetPtr += sizeof(int);
    if(field.core.claims[iterator_3].attributes!= null)
    {
        for(int iterator_5 = 0;iterator_5<field.core.claims[iterator_3].attributes.Count;++iterator_5)
        {

{

    targetPtr += sizeof(int);
    if(field.core.claims[iterator_3].attributes[iterator_5]!= null)
    {
        for(int iterator_6 = 0;iterator_6<field.core.claims[iterator_3].attributes[iterator_5].Count;++iterator_6)
        {

            {

        if(field.core.claims[iterator_3].attributes[iterator_5][iterator_6].key!= null)
        {
            int strlen_8 = field.core.claims[iterator_3].attributes[iterator_5][iterator_6].key.Length * 2;
            targetPtr += strlen_8+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.core.claims[iterator_3].attributes[iterator_5][iterator_6].value!= null)
        {
            int strlen_8 = field.core.claims[iterator_3].attributes[iterator_5][iterator_6].value.Length * 2;
            targetPtr += strlen_8+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
        }
    }

}

        }
    }

}

            }

            }
        }
    }

}

            }
            {
            targetPtr += 1;
            targetPtr += 1;
            targetPtr += 1;
            targetPtr += 8;

        if(field.wrapper.notaryudid!= null)
        {
            int strlen_3 = field.wrapper.notaryudid.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
            byte* tmpcellptr = BufferAllocator.AllocBuffer((int)targetPtr);
            Memory.memset(tmpcellptr, 0, (ulong)targetPtr);
            targetPtr = tmpcellptr;
            
            {

            {

        if(field.core.udid!= null)
        {
            int strlen_3 = field.core.udid.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.core.udid)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

{
byte *storedPtr_3 = targetPtr;

    targetPtr += sizeof(int);
    if(field.core.context!= null)
    {
        for(int iterator_3 = 0;iterator_3<field.core.context.Count;++iterator_3)
        {

        if(field.core.context[iterator_3]!= null)
        {
            int strlen_4 = field.core.context[iterator_3].Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.core.context[iterator_3])
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        }
    }
*(int*)storedPtr_3 = (int)(targetPtr - storedPtr_3 - 4);

}

{
byte *storedPtr_3 = targetPtr;

    targetPtr += sizeof(int);
    if(field.core.claims!= null)
    {
        for(int iterator_3 = 0;iterator_3<field.core.claims.Count;++iterator_3)
        {

            {
            byte* optheader_4 = targetPtr;
            *(optheader_4 + 0) = 0x00;            targetPtr += 1;

        if(field.core.claims[iterator_3].key!= null)
        {
            int strlen_5 = field.core.claims[iterator_3].key.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.core.claims[iterator_3].key)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( field.core.claims[iterator_3].value!= null)
            {

        if(field.core.claims[iterator_3].value!= null)
        {
            int strlen_5 = field.core.claims[iterator_3].value.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.core.claims[iterator_3].value)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_4 + 0) |= 0x01;
            }
            if( field.core.claims[iterator_3].attribute!= null)
            {

{
byte *storedPtr_5 = targetPtr;

    targetPtr += sizeof(int);
    if(field.core.claims[iterator_3].attribute!= null)
    {
        for(int iterator_5 = 0;iterator_5<field.core.claims[iterator_3].attribute.Count;++iterator_5)
        {

            {

        if(field.core.claims[iterator_3].attribute[iterator_5].key!= null)
        {
            int strlen_7 = field.core.claims[iterator_3].attribute[iterator_5].key.Length * 2;
            *(int*)targetPtr = strlen_7;
            targetPtr += sizeof(int);
            fixed(char* pstr_7 = field.core.claims[iterator_3].attribute[iterator_5].key)
            {
                Memory.Copy(pstr_7, targetPtr, strlen_7);
                targetPtr += strlen_7;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.core.claims[iterator_3].attribute[iterator_5].value!= null)
        {
            int strlen_7 = field.core.claims[iterator_3].attribute[iterator_5].value.Length * 2;
            *(int*)targetPtr = strlen_7;
            targetPtr += sizeof(int);
            fixed(char* pstr_7 = field.core.claims[iterator_3].attribute[iterator_5].value)
            {
                Memory.Copy(pstr_7, targetPtr, strlen_7);
                targetPtr += strlen_7;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
        }
    }
*(int*)storedPtr_5 = (int)(targetPtr - storedPtr_5 - 4);

}
*(optheader_4 + 0) |= 0x02;
            }
            if( field.core.claims[iterator_3].attributes!= null)
            {

{
byte *storedPtr_5 = targetPtr;

    targetPtr += sizeof(int);
    if(field.core.claims[iterator_3].attributes!= null)
    {
        for(int iterator_5 = 0;iterator_5<field.core.claims[iterator_3].attributes.Count;++iterator_5)
        {

{
byte *storedPtr_6 = targetPtr;

    targetPtr += sizeof(int);
    if(field.core.claims[iterator_3].attributes[iterator_5]!= null)
    {
        for(int iterator_6 = 0;iterator_6<field.core.claims[iterator_3].attributes[iterator_5].Count;++iterator_6)
        {

            {

        if(field.core.claims[iterator_3].attributes[iterator_5][iterator_6].key!= null)
        {
            int strlen_8 = field.core.claims[iterator_3].attributes[iterator_5][iterator_6].key.Length * 2;
            *(int*)targetPtr = strlen_8;
            targetPtr += sizeof(int);
            fixed(char* pstr_8 = field.core.claims[iterator_3].attributes[iterator_5][iterator_6].key)
            {
                Memory.Copy(pstr_8, targetPtr, strlen_8);
                targetPtr += strlen_8;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.core.claims[iterator_3].attributes[iterator_5][iterator_6].value!= null)
        {
            int strlen_8 = field.core.claims[iterator_3].attributes[iterator_5][iterator_6].value.Length * 2;
            *(int*)targetPtr = strlen_8;
            targetPtr += sizeof(int);
            fixed(char* pstr_8 = field.core.claims[iterator_3].attributes[iterator_5][iterator_6].value)
            {
                Memory.Copy(pstr_8, targetPtr, strlen_8);
                targetPtr += strlen_8;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
        }
    }
*(int*)storedPtr_6 = (int)(targetPtr - storedPtr_6 - 4);

}

        }
    }
*(int*)storedPtr_5 = (int)(targetPtr - storedPtr_5 - 4);

}
*(optheader_4 + 0) |= 0x04;
            }

            }
        }
    }
*(int*)storedPtr_3 = (int)(targetPtr - storedPtr_3 - 4);

}

            }
            {
            *(TRACredentialType*)targetPtr = field.wrapper.credtype;
            targetPtr += 1;
            *(TRATrustLevel*)targetPtr = field.wrapper.trustLevel;
            targetPtr += 1;
            *(TRAEncryptionFlag*)targetPtr = field.wrapper.encryptionFlag;
            targetPtr += 1;
            *(long*)targetPtr = field.wrapper.version;
            targetPtr += 8;

        if(field.wrapper.notaryudid!= null)
        {
            int strlen_3 = field.wrapper.notaryudid.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.wrapper.notaryudid)
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
            }TRACredentialContent_Accessor ret;
            
            ret = new TRACredentialContent_Accessor(tmpcellptr, null);
            
            return ret;
        }
        
        public static bool operator ==(TRACredentialContent_Accessor a, TRACredentialContent_Accessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            byte* targetPtr = a.m_ptr;
            {{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 11;
targetPtr += *(int*)targetPtr + sizeof(int);}}
            int lengthA = (int)(targetPtr - a.m_ptr);
            targetPtr = b.m_ptr;
            {{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 11;
targetPtr += *(int*)targetPtr + sizeof(int);}}
            int lengthB = (int)(targetPtr - b.m_ptr);
            if(lengthA != lengthB) return false;
            return Memory.Compare(a.m_ptr,b.m_ptr,lengthA);
        }
        public static bool operator != (TRACredentialContent_Accessor a, TRACredentialContent_Accessor b)
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
