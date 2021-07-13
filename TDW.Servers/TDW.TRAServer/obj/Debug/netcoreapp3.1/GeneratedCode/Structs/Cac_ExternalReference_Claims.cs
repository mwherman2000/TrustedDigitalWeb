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
    /// A .NET runtime object representation of Cac_ExternalReference_Claims defined in TSL.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct Cac_ExternalReference_Claims
    {
        
        ///<summary>
        ///Initializes a new instance of Cac_ExternalReference_Claims with the specified parameters.
        ///</summary>
        public Cac_ExternalReference_Claims(string cbc_URI = default(string),Cbc_EmbeddedDocumentBinaryObject? cbc_EmbeddedDocumentBinaryObject = default(Cbc_EmbeddedDocumentBinaryObject?))
        {
            
            this.cbc_URI = cbc_URI;
            
            this.cbc_EmbeddedDocumentBinaryObject = cbc_EmbeddedDocumentBinaryObject;
            
        }
        
        public static bool operator ==(Cac_ExternalReference_Claims a, Cac_ExternalReference_Claims b)
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
                
                (a.cbc_URI == b.cbc_URI)
                &&
                (a.cbc_EmbeddedDocumentBinaryObject == b.cbc_EmbeddedDocumentBinaryObject)
                
                ;
            
        }
        public static bool operator !=(Cac_ExternalReference_Claims a, Cac_ExternalReference_Claims b)
        {
            return !(a == b);
        }
        
        public string cbc_URI;
        
        public Cbc_EmbeddedDocumentBinaryObject? cbc_EmbeddedDocumentBinaryObject;
        
        /// <summary>
        /// Converts the string representation of a Cac_ExternalReference_Claims to its
        /// struct equivalent. A return value indicates whether the 
        /// operation succeeded.
        /// </summary>
        /// <param name="input">A string to convert.</param>
        /// <param name="value">
        /// When this method returns, contains the struct equivalent of the value contained 
        /// in input, if the conversion succeeded, or default(Cac_ExternalReference_Claims) if the conversion
        /// failed. The conversion fails if the input parameter is null or String.Empty, or is 
        /// not of the correct format. This parameter is passed uninitialized. 
        /// </param>
        /// <returns>True if input was converted successfully; otherwise, false.</returns>
        public unsafe static bool TryParse(string input, out Cac_ExternalReference_Claims value)
        {
            try
            {
                value = Newtonsoft.Json.JsonConvert.DeserializeObject<Cac_ExternalReference_Claims>(input);
                return true;
            }
            catch { value = default(Cac_ExternalReference_Claims); return false; }
        }
        public static Cac_ExternalReference_Claims Parse(string input)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Cac_ExternalReference_Claims>(input);
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
    /// Provides in-place operations of Cac_ExternalReference_Claims defined in TSL.
    /// </summary>
    public unsafe partial class Cac_ExternalReference_Claims_Accessor : IAccessor
    {
        ///<summary>
        ///The pointer to the content of the object.
        ///</summary>
        internal byte* m_ptr;
        internal long m_cellId;
        internal unsafe Cac_ExternalReference_Claims_Accessor(byte* _CellPtr
            
            , ResizeFunctionDelegate func
            )
        {
            m_ptr = _CellPtr;
            
            ResizeFunction = func;
                    cbc_URI_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        cbc_EmbeddedDocumentBinaryObject_Accessor_Field = new Cbc_EmbeddedDocumentBinaryObject_Accessor(null,
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
                    
                    "cbc_URI"
                    ,
                    "cbc_EmbeddedDocumentBinaryObject"
                    
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
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_0 + 0) & 0x02)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}
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
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_0 + 0) & 0x02)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}
            int size = (int)(targetPtr - m_ptr);
            return size;
        }
        public ResizeFunctionDelegate ResizeFunction { get; set; }
        #endregion
        StringAccessor cbc_URI_Accessor_Field;
        
        ///<summary>
        ///Represents the presence of the optional field cbc_URI.
        ///</summary>
        public bool Contains_cbc_URI
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
        ///Removes the optional field cbc_URI from the object being operated.
        ///</summary>
        public unsafe void Remove_cbc_URI()
        {
            if (!this.Contains_cbc_URI)
            {
                throw new Exception("Optional field cbc_URI doesn't exist for current cell.");
            }
            this.Contains_cbc_URI = false;
            byte* targetPtr = m_ptr;
            {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
}
            byte* startPtr = targetPtr;
            targetPtr += *(int*)targetPtr + sizeof(int);
            this.ResizeFunction(startPtr, 0, (int)(startPtr - targetPtr));
        }
        
        ///<summary>
        ///Provides in-place access to the object field cbc_URI.
        ///</summary>
        public unsafe StringAccessor cbc_URI
        {
            get
            {
                
                if (!this.Contains_cbc_URI)
                {
                    throw new Exception("Optional field cbc_URI doesn't exist for current cell.");
                }
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
}cbc_URI_Accessor_Field.m_ptr = targetPtr + 4;
                cbc_URI_Accessor_Field.m_cellId = this.m_cellId;
                return cbc_URI_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cbc_URI_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
}
                bool creatingOptionalField = (!this.Contains_cbc_URI);
                if (creatingOptionalField)
                {
                    this.Contains_cbc_URI = true;
                    
                int length = *(int*)(value.m_ptr - 4);
                if (value.m_cellId != cbc_URI_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    cbc_URI_Accessor_Field.m_ptr = cbc_URI_Accessor_Field.ResizeFunction(targetPtr, 0, length + sizeof(int));
                    Memory.Copy(value.m_ptr - 4, cbc_URI_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        cbc_URI_Accessor_Field.m_ptr = cbc_URI_Accessor_Field.ResizeFunction(targetPtr, 0, length + sizeof(int));
                        Memory.Copy(tmpcellptr, cbc_URI_Accessor_Field.m_ptr, length + 4);
                    }
                }

                }
                else
                {
                    
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != cbc_URI_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    cbc_URI_Accessor_Field.m_ptr = cbc_URI_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, cbc_URI_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        cbc_URI_Accessor_Field.m_ptr = cbc_URI_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, cbc_URI_Accessor_Field.m_ptr, length + 4);
                    }
                }

                }
                
            }
        }
        Cbc_EmbeddedDocumentBinaryObject_Accessor cbc_EmbeddedDocumentBinaryObject_Accessor_Field;
        
        ///<summary>
        ///Represents the presence of the optional field cbc_EmbeddedDocumentBinaryObject.
        ///</summary>
        public bool Contains_cbc_EmbeddedDocumentBinaryObject
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
        ///Removes the optional field cbc_EmbeddedDocumentBinaryObject from the object being operated.
        ///</summary>
        public unsafe void Remove_cbc_EmbeddedDocumentBinaryObject()
        {
            if (!this.Contains_cbc_EmbeddedDocumentBinaryObject)
            {
                throw new Exception("Optional field cbc_EmbeddedDocumentBinaryObject doesn't exist for current cell.");
            }
            this.Contains_cbc_EmbeddedDocumentBinaryObject = false;
            byte* targetPtr = m_ptr;
            {            byte* optheader_1 = targetPtr;
            targetPtr += 1;

                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
            byte* startPtr = targetPtr;
            {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            this.ResizeFunction(startPtr, 0, (int)(startPtr - targetPtr));
        }
        
        ///<summary>
        ///Provides in-place access to the object field cbc_EmbeddedDocumentBinaryObject.
        ///</summary>
        public unsafe Cbc_EmbeddedDocumentBinaryObject_Accessor cbc_EmbeddedDocumentBinaryObject
        {
            get
            {
                
                if (!this.Contains_cbc_EmbeddedDocumentBinaryObject)
                {
                    throw new Exception("Optional field cbc_EmbeddedDocumentBinaryObject doesn't exist for current cell.");
                }
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;

                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}cbc_EmbeddedDocumentBinaryObject_Accessor_Field.m_ptr = targetPtr;
                cbc_EmbeddedDocumentBinaryObject_Accessor_Field.m_cellId = this.m_cellId;
                return cbc_EmbeddedDocumentBinaryObject_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cbc_EmbeddedDocumentBinaryObject_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;

                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
                bool creatingOptionalField = (!this.Contains_cbc_EmbeddedDocumentBinaryObject);
                if (creatingOptionalField)
                {
                    this.Contains_cbc_EmbeddedDocumentBinaryObject = true;
                    
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
        
        public static unsafe implicit operator Cac_ExternalReference_Claims(Cac_ExternalReference_Claims_Accessor accessor)
        {
            string _cbc_URI = default(string);
            if (accessor.Contains_cbc_URI)
            {
                
                _cbc_URI = accessor.cbc_URI;
                
            }
            Cbc_EmbeddedDocumentBinaryObject? _cbc_EmbeddedDocumentBinaryObject = default(Cbc_EmbeddedDocumentBinaryObject?);
            if (accessor.Contains_cbc_EmbeddedDocumentBinaryObject)
            {
                
                _cbc_EmbeddedDocumentBinaryObject = (Cbc_EmbeddedDocumentBinaryObject)accessor.cbc_EmbeddedDocumentBinaryObject;
                
            }
            
            return new Cac_ExternalReference_Claims(
                
                        _cbc_URI ,
                        _cbc_EmbeddedDocumentBinaryObject 
                );
        }
        
        public unsafe static implicit operator Cac_ExternalReference_Claims_Accessor(Cac_ExternalReference_Claims field)
        {
            byte* targetPtr = null;
            
            {
            targetPtr += 1;
            if( field.cbc_URI!= null)
            {

        if(field.cbc_URI!= null)
        {
            int strlen_2 = field.cbc_URI.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( field.cbc_EmbeddedDocumentBinaryObject!= null)
            {

            {

        if(field.cbc_EmbeddedDocumentBinaryObject.Value._mimeCode!= null)
        {
            int strlen_3 = field.cbc_EmbeddedDocumentBinaryObject.Value._mimeCode.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.cbc_EmbeddedDocumentBinaryObject.Value.binary16!= null)
        {
            int strlen_3 = field.cbc_EmbeddedDocumentBinaryObject.Value.binary16.Length * 2;
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
            if( field.cbc_URI!= null)
            {

        if(field.cbc_URI!= null)
        {
            int strlen_2 = field.cbc_URI.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.cbc_URI)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_1 + 0) |= 0x01;
            }
            if( field.cbc_EmbeddedDocumentBinaryObject!= null)
            {

            {

        if(field.cbc_EmbeddedDocumentBinaryObject.Value._mimeCode!= null)
        {
            int strlen_3 = field.cbc_EmbeddedDocumentBinaryObject.Value._mimeCode.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.cbc_EmbeddedDocumentBinaryObject.Value._mimeCode)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.cbc_EmbeddedDocumentBinaryObject.Value.binary16!= null)
        {
            int strlen_3 = field.cbc_EmbeddedDocumentBinaryObject.Value.binary16.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.cbc_EmbeddedDocumentBinaryObject.Value.binary16)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }*(optheader_1 + 0) |= 0x02;
            }

            }Cac_ExternalReference_Claims_Accessor ret;
            
            ret = new Cac_ExternalReference_Claims_Accessor(tmpcellptr, null);
            
            return ret;
        }
        
        public static bool operator ==(Cac_ExternalReference_Claims_Accessor a, Cac_ExternalReference_Claims_Accessor b)
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
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}
            int lengthA = (int)(targetPtr - a.m_ptr);
            targetPtr = b.m_ptr;
            {            byte* optheader_1 = targetPtr;
            targetPtr += 1;

                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}
            int lengthB = (int)(targetPtr - b.m_ptr);
            if(lengthA != lengthB) return false;
            return Memory.Compare(a.m_ptr,b.m_ptr,lengthA);
        }
        public static bool operator != (Cac_ExternalReference_Claims_Accessor a, Cac_ExternalReference_Claims_Accessor b)
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
