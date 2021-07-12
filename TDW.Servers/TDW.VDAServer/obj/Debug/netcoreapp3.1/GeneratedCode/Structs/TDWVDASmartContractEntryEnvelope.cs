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
    /// A .NET runtime object representation of TDWVDASmartContractEntryEnvelope defined in TSL.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct TDWVDASmartContractEntryEnvelope
    {
        
        ///<summary>
        ///Initializes a new instance of TDWVDASmartContractEntryEnvelope with the specified parameters.
        ///</summary>
        public TDWVDASmartContractEntryEnvelope(TDWVDASmartContractEntryContent? content = default(TDWVDASmartContractEntryContent?),string encryptedcontent = default(string),TRACredentialMetadata metadata = default(TRACredentialMetadata))
        {
            
            this.content = content;
            
            this.encryptedcontent = encryptedcontent;
            
            this.metadata = metadata;
            
        }
        
        public static bool operator ==(TDWVDASmartContractEntryEnvelope a, TDWVDASmartContractEntryEnvelope b)
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
                
                (a.content == b.content)
                &&
                (a.encryptedcontent == b.encryptedcontent)
                &&
                (a.metadata == b.metadata)
                
                ;
            
        }
        public static bool operator !=(TDWVDASmartContractEntryEnvelope a, TDWVDASmartContractEntryEnvelope b)
        {
            return !(a == b);
        }
        
        public TDWVDASmartContractEntryContent? content;
        
        public string encryptedcontent;
        
        public TRACredentialMetadata metadata;
        
        /// <summary>
        /// Converts the string representation of a TDWVDASmartContractEntryEnvelope to its
        /// struct equivalent. A return value indicates whether the 
        /// operation succeeded.
        /// </summary>
        /// <param name="input">A string to convert.</param>
        /// <param name="value">
        /// When this method returns, contains the struct equivalent of the value contained 
        /// in input, if the conversion succeeded, or default(TDWVDASmartContractEntryEnvelope) if the conversion
        /// failed. The conversion fails if the input parameter is null or String.Empty, or is 
        /// not of the correct format. This parameter is passed uninitialized. 
        /// </param>
        /// <returns>True if input was converted successfully; otherwise, false.</returns>
        public unsafe static bool TryParse(string input, out TDWVDASmartContractEntryEnvelope value)
        {
            try
            {
                value = Newtonsoft.Json.JsonConvert.DeserializeObject<TDWVDASmartContractEntryEnvelope>(input);
                return true;
            }
            catch { value = default(TDWVDASmartContractEntryEnvelope); return false; }
        }
        public static TDWVDASmartContractEntryEnvelope Parse(string input)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TDWVDASmartContractEntryEnvelope>(input);
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
    /// Provides in-place operations of TDWVDASmartContractEntryEnvelope defined in TSL.
    /// </summary>
    public unsafe partial class TDWVDASmartContractEntryEnvelope_Accessor : IAccessor
    {
        ///<summary>
        ///The pointer to the content of the object.
        ///</summary>
        internal byte* m_ptr;
        internal long m_cellId;
        internal unsafe TDWVDASmartContractEntryEnvelope_Accessor(byte* _CellPtr
            
            , ResizeFunctionDelegate func
            )
        {
            m_ptr = _CellPtr;
            
            ResizeFunction = func;
                    content_Accessor_Field = new TDWVDASmartContractEntryContent_Accessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        encryptedcontent_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        metadata_Accessor_Field = new TRACredentialMetadata_Accessor(null,
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
                    
                    "content"
                    ,
                    "encryptedcontent"
                    ,
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
            
            byte [] bytes = new byte[1];
            Memory.Copy(m_ptr, 0, bytes, 0, 1);
            return bytes;
            
        }
        
        ///<summary>
        ///Copies the struct content into a byte array.
        ///</summary>
        public byte[] ToByteArray()
        {
            byte* targetPtr = m_ptr;
            {            byte* optheader_0 = targetPtr;
            targetPtr += 1;

                if ((0 != (*(optheader_0 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}}
                }

                if ((0 != (*(optheader_0 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
{            byte* optheader_2 = targetPtr;
            targetPtr += 1;
            targetPtr += 11;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_2 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_2 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}}
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
            {            byte* optheader_0 = targetPtr;
            targetPtr += 1;

                if ((0 != (*(optheader_0 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}}
                }

                if ((0 != (*(optheader_0 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
{            byte* optheader_2 = targetPtr;
            targetPtr += 1;
            targetPtr += 11;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_2 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_2 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}}
            int size = (int)(targetPtr - m_ptr);
            return size;
        }
        public ResizeFunctionDelegate ResizeFunction { get; set; }
        #endregion
        TDWVDASmartContractEntryContent_Accessor content_Accessor_Field;
        
        ///<summary>
        ///Represents the presence of the optional field content.
        ///</summary>
        public bool Contains_content
        {
            get
            {
                unchecked
                {
                    return (0 != (*(this.m_ptr + 0) & 0x01)) ;
                }
            }
            internal set
            {
                unchecked
                {
                    if (value)
                    {
                        *(this.m_ptr + 0) |= 0x01;
                    }
                    else
                    {
                        *(this.m_ptr + 0) &= 0xFE;
                    }
                }
            }
        }
        ///<summary>
        ///Removes the optional field content from the object being operated.
        ///</summary>
        public unsafe void Remove_content()
        {
            if (!this.Contains_content)
            {
                throw new Exception("Optional field content doesn't exist for current cell.");
            }
            this.Contains_content = false;
            byte* targetPtr = m_ptr;
            {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
}
            byte* startPtr = targetPtr;
            {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}}
            this.ResizeFunction(startPtr, 0, (int)(startPtr - targetPtr));
        }
        
        ///<summary>
        ///Provides in-place access to the object field content.
        ///</summary>
        public unsafe TDWVDASmartContractEntryContent_Accessor content
        {
            get
            {
                
                if (!this.Contains_content)
                {
                    throw new Exception("Optional field content doesn't exist for current cell.");
                }
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
}content_Accessor_Field.m_ptr = targetPtr;
                content_Accessor_Field.m_cellId = this.m_cellId;
                return content_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                content_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
}
                bool creatingOptionalField = (!this.Contains_content);
                if (creatingOptionalField)
                {
                    this.Contains_content = true;
                    
                int offset = (int)(targetPtr - m_ptr);
                byte* oldtargetPtr = targetPtr;
                int oldlength = 0;
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
                else
                {
                    
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
        }
        StringAccessor encryptedcontent_Accessor_Field;
        
        ///<summary>
        ///Represents the presence of the optional field encryptedcontent.
        ///</summary>
        public bool Contains_encryptedcontent
        {
            get
            {
                unchecked
                {
                    return (0 != (*(this.m_ptr + 0) & 0x02)) ;
                }
            }
            internal set
            {
                unchecked
                {
                    if (value)
                    {
                        *(this.m_ptr + 0) |= 0x02;
                    }
                    else
                    {
                        *(this.m_ptr + 0) &= 0xFD;
                    }
                }
            }
        }
        ///<summary>
        ///Removes the optional field encryptedcontent from the object being operated.
        ///</summary>
        public unsafe void Remove_encryptedcontent()
        {
            if (!this.Contains_encryptedcontent)
            {
                throw new Exception("Optional field encryptedcontent doesn't exist for current cell.");
            }
            this.Contains_encryptedcontent = false;
            byte* targetPtr = m_ptr;
            {            byte* optheader_1 = targetPtr;
            targetPtr += 1;

                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}}
                }
}
            byte* startPtr = targetPtr;
            targetPtr += *(int*)targetPtr + sizeof(int);
            this.ResizeFunction(startPtr, 0, (int)(startPtr - targetPtr));
        }
        
        ///<summary>
        ///Provides in-place access to the object field encryptedcontent.
        ///</summary>
        public unsafe StringAccessor encryptedcontent
        {
            get
            {
                
                if (!this.Contains_encryptedcontent)
                {
                    throw new Exception("Optional field encryptedcontent doesn't exist for current cell.");
                }
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;

                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}}
                }
}encryptedcontent_Accessor_Field.m_ptr = targetPtr + 4;
                encryptedcontent_Accessor_Field.m_cellId = this.m_cellId;
                return encryptedcontent_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                encryptedcontent_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;

                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}}
                }
}
                bool creatingOptionalField = (!this.Contains_encryptedcontent);
                if (creatingOptionalField)
                {
                    this.Contains_encryptedcontent = true;
                    
                int length = *(int*)(value.m_ptr - 4);
                if (value.m_cellId != encryptedcontent_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    encryptedcontent_Accessor_Field.m_ptr = encryptedcontent_Accessor_Field.ResizeFunction(targetPtr, 0, length + sizeof(int));
                    Memory.Copy(value.m_ptr - 4, encryptedcontent_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        encryptedcontent_Accessor_Field.m_ptr = encryptedcontent_Accessor_Field.ResizeFunction(targetPtr, 0, length + sizeof(int));
                        Memory.Copy(tmpcellptr, encryptedcontent_Accessor_Field.m_ptr, length + 4);
                    }
                }

                }
                else
                {
                    
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != encryptedcontent_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    encryptedcontent_Accessor_Field.m_ptr = encryptedcontent_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, encryptedcontent_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        encryptedcontent_Accessor_Field.m_ptr = encryptedcontent_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, encryptedcontent_Accessor_Field.m_ptr, length + 4);
                    }
                }

                }
                
            }
        }
        TRACredentialMetadata_Accessor metadata_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field metadata.
        ///</summary>
        public unsafe TRACredentialMetadata_Accessor metadata
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;

                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}}
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}metadata_Accessor_Field.m_ptr = targetPtr;
                metadata_Accessor_Field.m_cellId = this.m_cellId;
                return metadata_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                metadata_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;

                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}}
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
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
        
        public static unsafe implicit operator TDWVDASmartContractEntryEnvelope(TDWVDASmartContractEntryEnvelope_Accessor accessor)
        {
            TDWVDASmartContractEntryContent? _content = default(TDWVDASmartContractEntryContent?);
            if (accessor.Contains_content)
            {
                
                _content = (TDWVDASmartContractEntryContent)accessor.content;
                
            }
            string _encryptedcontent = default(string);
            if (accessor.Contains_encryptedcontent)
            {
                
                _encryptedcontent = accessor.encryptedcontent;
                
            }
            
            return new TDWVDASmartContractEntryEnvelope(
                
                        _content ,
                        _encryptedcontent ,
                        accessor.metadata
                );
        }
        
        public unsafe static implicit operator TDWVDASmartContractEntryEnvelope_Accessor(TDWVDASmartContractEntryEnvelope field)
        {
            byte* targetPtr = null;
            
            {
            targetPtr += 1;
            if( field.content!= null)
            {

            {

        if(field.content.Value.udid!= null)
        {
            int strlen_3 = field.content.Value.udid.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

{

    targetPtr += sizeof(int);
    if(field.content.Value.context!= null)
    {
        for(int iterator_3 = 0;iterator_3<field.content.Value.context.Count;++iterator_3)
        {

        if(field.content.Value.context[iterator_3]!= null)
        {
            int strlen_4 = field.content.Value.context[iterator_3].Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        }
    }

}

            {

        if(field.content.Value.claims.smartcontractledgeraddress!= null)
        {
            int strlen_4 = field.content.Value.claims.smartcontractledgeraddress.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.content.Value.claims.vdaserviceendpointudid!= null)
        {
            int strlen_4 = field.content.Value.claims.vdaserviceendpointudid.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
            }
            if( field.encryptedcontent!= null)
            {

        if(field.encryptedcontent!= null)
        {
            int strlen_2 = field.encryptedcontent.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

            {
            targetPtr += 1;
            targetPtr += 1;
            targetPtr += 8;
            targetPtr += 1;
            targetPtr += 1;

        if(field.metadata.notaryudid!= null)
        {
            int strlen_3 = field.metadata.notaryudid.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( field.metadata.name!= null)
            {

        if(field.metadata.name!= null)
        {
            int strlen_3 = field.metadata.name.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( field.metadata.comment!= null)
            {

        if(field.metadata.comment!= null)
        {
            int strlen_3 = field.metadata.comment.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

            }
            }
            byte* tmpcellptr = BufferAllocator.AllocBuffer((int)targetPtr);
            Memory.memset(tmpcellptr, 0, (ulong)targetPtr);
            targetPtr = tmpcellptr;
            
            {
            byte* optheader_1 = targetPtr;
            *(optheader_1 + 0) = 0x00;            targetPtr += 1;
            if( field.content!= null)
            {

            {

        if(field.content.Value.udid!= null)
        {
            int strlen_3 = field.content.Value.udid.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.content.Value.udid)
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
    if(field.content.Value.context!= null)
    {
        for(int iterator_3 = 0;iterator_3<field.content.Value.context.Count;++iterator_3)
        {

        if(field.content.Value.context[iterator_3]!= null)
        {
            int strlen_4 = field.content.Value.context[iterator_3].Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.content.Value.context[iterator_3])
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

        if(field.content.Value.claims.smartcontractledgeraddress!= null)
        {
            int strlen_4 = field.content.Value.claims.smartcontractledgeraddress.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.content.Value.claims.smartcontractledgeraddress)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.content.Value.claims.vdaserviceendpointudid!= null)
        {
            int strlen_4 = field.content.Value.claims.vdaserviceendpointudid.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.content.Value.claims.vdaserviceendpointudid)
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
            }*(optheader_1 + 0) |= 0x01;
            }
            if( field.encryptedcontent!= null)
            {

        if(field.encryptedcontent!= null)
        {
            int strlen_2 = field.encryptedcontent.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.encryptedcontent)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_1 + 0) |= 0x02;
            }

            {
            byte* optheader_2 = targetPtr;
            *(optheader_2 + 0) = 0x00;            targetPtr += 1;
            *(TRACredentialType*)targetPtr = field.metadata.credtype;
            targetPtr += 1;
            *(long*)targetPtr = field.metadata.version;
            targetPtr += 8;
            *(TRATrustLevel*)targetPtr = field.metadata.trustLevel;
            targetPtr += 1;
            *(TRAEncryptionFlag*)targetPtr = field.metadata.encryptionFlag;
            targetPtr += 1;

        if(field.metadata.notaryudid!= null)
        {
            int strlen_3 = field.metadata.notaryudid.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.metadata.notaryudid)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( field.metadata.name!= null)
            {

        if(field.metadata.name!= null)
        {
            int strlen_3 = field.metadata.name.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.metadata.name)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_2 + 0) |= 0x01;
            }
            if( field.metadata.comment!= null)
            {

        if(field.metadata.comment!= null)
        {
            int strlen_3 = field.metadata.comment.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.metadata.comment)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_2 + 0) |= 0x02;
            }

            }
            }TDWVDASmartContractEntryEnvelope_Accessor ret;
            
            ret = new TDWVDASmartContractEntryEnvelope_Accessor(tmpcellptr, null);
            
            return ret;
        }
        
        public static bool operator ==(TDWVDASmartContractEntryEnvelope_Accessor a, TDWVDASmartContractEntryEnvelope_Accessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            byte* targetPtr = a.m_ptr;
            {            byte* optheader_1 = targetPtr;
            targetPtr += 1;

                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}}
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
{            byte* optheader_3 = targetPtr;
            targetPtr += 1;
            targetPtr += 11;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_3 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_3 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}}
            int lengthA = (int)(targetPtr - a.m_ptr);
            targetPtr = b.m_ptr;
            {            byte* optheader_1 = targetPtr;
            targetPtr += 1;

                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}}
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
{            byte* optheader_3 = targetPtr;
            targetPtr += 1;
            targetPtr += 11;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_3 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_3 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}}
            int lengthB = (int)(targetPtr - b.m_ptr);
            if(lengthA != lengthB) return false;
            return Memory.Compare(a.m_ptr,b.m_ptr,lengthA);
        }
        public static bool operator != (TDWVDASmartContractEntryEnvelope_Accessor a, TDWVDASmartContractEntryEnvelope_Accessor b)
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
