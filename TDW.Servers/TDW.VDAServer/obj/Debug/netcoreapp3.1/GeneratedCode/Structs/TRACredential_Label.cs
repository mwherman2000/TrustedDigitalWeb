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
    /// A .NET runtime object representation of TRACredential_Label defined in TSL.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct TRACredential_Label
    {
        
        ///<summary>
        ///Initializes a new instance of TRACredential_Label with the specified parameters.
        ///</summary>
        public TRACredential_Label(TRACredentialType credtype = default(TRACredentialType),long version = default(long),TRATrustLevel trustLevel = default(TRATrustLevel),TRAEncryptionFlag encryptionFlag = default(TRAEncryptionFlag),string notaryudid = default(string),string name = default(string),string comment = default(string))
        {
            
            this.credtype = credtype;
            
            this.version = version;
            
            this.trustLevel = trustLevel;
            
            this.encryptionFlag = encryptionFlag;
            
            this.notaryudid = notaryudid;
            
            this.name = name;
            
            this.comment = comment;
            
        }
        
        public static bool operator ==(TRACredential_Label a, TRACredential_Label b)
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
                
                (a.credtype == b.credtype)
                &&
                (a.version == b.version)
                &&
                (a.trustLevel == b.trustLevel)
                &&
                (a.encryptionFlag == b.encryptionFlag)
                &&
                (a.notaryudid == b.notaryudid)
                &&
                (a.name == b.name)
                &&
                (a.comment == b.comment)
                
                ;
            
        }
        public static bool operator !=(TRACredential_Label a, TRACredential_Label b)
        {
            return !(a == b);
        }
        
        public TRACredentialType credtype;
        
        public long version;
        
        public TRATrustLevel trustLevel;
        
        public TRAEncryptionFlag encryptionFlag;
        
        public string notaryudid;
        
        public string name;
        
        public string comment;
        
        /// <summary>
        /// Converts the string representation of a TRACredential_Label to its
        /// struct equivalent. A return value indicates whether the 
        /// operation succeeded.
        /// </summary>
        /// <param name="input">A string to convert.</param>
        /// <param name="value">
        /// When this method returns, contains the struct equivalent of the value contained 
        /// in input, if the conversion succeeded, or default(TRACredential_Label) if the conversion
        /// failed. The conversion fails if the input parameter is null or String.Empty, or is 
        /// not of the correct format. This parameter is passed uninitialized. 
        /// </param>
        /// <returns>True if input was converted successfully; otherwise, false.</returns>
        public unsafe static bool TryParse(string input, out TRACredential_Label value)
        {
            try
            {
                value = Newtonsoft.Json.JsonConvert.DeserializeObject<TRACredential_Label>(input);
                return true;
            }
            catch { value = default(TRACredential_Label); return false; }
        }
        public static TRACredential_Label Parse(string input)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TRACredential_Label>(input);
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
    /// Provides in-place operations of TRACredential_Label defined in TSL.
    /// </summary>
    public unsafe partial class TRACredential_Label_Accessor : IAccessor
    {
        ///<summary>
        ///The pointer to the content of the object.
        ///</summary>
        internal byte* m_ptr;
        internal long m_cellId;
        internal unsafe TRACredential_Label_Accessor(byte* _CellPtr
            
            , ResizeFunctionDelegate func
            )
        {
            m_ptr = _CellPtr;
            
            ResizeFunction = func;
                    notaryudid_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        name_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        comment_Accessor_Field = new StringAccessor(null,
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
                    
                    "name"
                    ,
                    "comment"
                    
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
            targetPtr += 11;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_0 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_0 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
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
            targetPtr += 11;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_0 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_0 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
            int size = (int)(targetPtr - m_ptr);
            return size;
        }
        public ResizeFunctionDelegate ResizeFunction { get; set; }
        #endregion
        
        ///<summary>
        ///Provides in-place access to the object field credtype.
        ///</summary>
        public unsafe TRACredentialType credtype
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
}
                return *(TRACredentialType*)(targetPtr);
                
            }
            set
            {
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
}                *(TRACredentialType*)targetPtr = value;
            }
        }
        
        ///<summary>
        ///Provides in-place access to the object field version.
        ///</summary>
        public unsafe long version
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
            targetPtr += 1;
}
                return *(long*)(targetPtr);
                
            }
            set
            {
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
            targetPtr += 1;
}                *(long*)targetPtr = value;
            }
        }
        
        ///<summary>
        ///Provides in-place access to the object field trustLevel.
        ///</summary>
        public unsafe TRATrustLevel trustLevel
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
            targetPtr += 9;
}
                return *(TRATrustLevel*)(targetPtr);
                
            }
            set
            {
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
            targetPtr += 9;
}                *(TRATrustLevel*)targetPtr = value;
            }
        }
        
        ///<summary>
        ///Provides in-place access to the object field encryptionFlag.
        ///</summary>
        public unsafe TRAEncryptionFlag encryptionFlag
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
            targetPtr += 10;
}
                return *(TRAEncryptionFlag*)(targetPtr);
                
            }
            set
            {
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
            targetPtr += 10;
}                *(TRAEncryptionFlag*)targetPtr = value;
            }
        }
        StringAccessor notaryudid_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field notaryudid.
        ///</summary>
        public unsafe StringAccessor notaryudid
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
            targetPtr += 11;
}notaryudid_Accessor_Field.m_ptr = targetPtr + 4;
                notaryudid_Accessor_Field.m_cellId = this.m_cellId;
                return notaryudid_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                notaryudid_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
            targetPtr += 11;
}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != notaryudid_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    notaryudid_Accessor_Field.m_ptr = notaryudid_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, notaryudid_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        notaryudid_Accessor_Field.m_ptr = notaryudid_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, notaryudid_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        StringAccessor name_Accessor_Field;
        
        ///<summary>
        ///Represents the presence of the optional field name.
        ///</summary>
        public bool Contains_name
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
        ///Removes the optional field name from the object being operated.
        ///</summary>
        public unsafe void Remove_name()
        {
            if (!this.Contains_name)
            {
                throw new Exception("Optional field name doesn't exist for current cell.");
            }
            this.Contains_name = false;
            byte* targetPtr = m_ptr;
            {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
            targetPtr += 11;
targetPtr += *(int*)targetPtr + sizeof(int);}
            byte* startPtr = targetPtr;
            targetPtr += *(int*)targetPtr + sizeof(int);
            this.ResizeFunction(startPtr, 0, (int)(startPtr - targetPtr));
        }
        
        ///<summary>
        ///Provides in-place access to the object field name.
        ///</summary>
        public unsafe StringAccessor name
        {
            get
            {
                
                if (!this.Contains_name)
                {
                    throw new Exception("Optional field name doesn't exist for current cell.");
                }
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
            targetPtr += 11;
targetPtr += *(int*)targetPtr + sizeof(int);}name_Accessor_Field.m_ptr = targetPtr + 4;
                name_Accessor_Field.m_cellId = this.m_cellId;
                return name_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                name_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
            targetPtr += 11;
targetPtr += *(int*)targetPtr + sizeof(int);}
                bool creatingOptionalField = (!this.Contains_name);
                if (creatingOptionalField)
                {
                    this.Contains_name = true;
                    
                int length = *(int*)(value.m_ptr - 4);
                if (value.m_cellId != name_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    name_Accessor_Field.m_ptr = name_Accessor_Field.ResizeFunction(targetPtr, 0, length + sizeof(int));
                    Memory.Copy(value.m_ptr - 4, name_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        name_Accessor_Field.m_ptr = name_Accessor_Field.ResizeFunction(targetPtr, 0, length + sizeof(int));
                        Memory.Copy(tmpcellptr, name_Accessor_Field.m_ptr, length + 4);
                    }
                }

                }
                else
                {
                    
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != name_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    name_Accessor_Field.m_ptr = name_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, name_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        name_Accessor_Field.m_ptr = name_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, name_Accessor_Field.m_ptr, length + 4);
                    }
                }

                }
                
            }
        }
        StringAccessor comment_Accessor_Field;
        
        ///<summary>
        ///Represents the presence of the optional field comment.
        ///</summary>
        public bool Contains_comment
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
        ///Removes the optional field comment from the object being operated.
        ///</summary>
        public unsafe void Remove_comment()
        {
            if (!this.Contains_comment)
            {
                throw new Exception("Optional field comment doesn't exist for current cell.");
            }
            this.Contains_comment = false;
            byte* targetPtr = m_ptr;
            {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
            targetPtr += 11;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
            byte* startPtr = targetPtr;
            targetPtr += *(int*)targetPtr + sizeof(int);
            this.ResizeFunction(startPtr, 0, (int)(startPtr - targetPtr));
        }
        
        ///<summary>
        ///Provides in-place access to the object field comment.
        ///</summary>
        public unsafe StringAccessor comment
        {
            get
            {
                
                if (!this.Contains_comment)
                {
                    throw new Exception("Optional field comment doesn't exist for current cell.");
                }
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
            targetPtr += 11;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}comment_Accessor_Field.m_ptr = targetPtr + 4;
                comment_Accessor_Field.m_cellId = this.m_cellId;
                return comment_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                comment_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
            targetPtr += 11;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
                bool creatingOptionalField = (!this.Contains_comment);
                if (creatingOptionalField)
                {
                    this.Contains_comment = true;
                    
                int length = *(int*)(value.m_ptr - 4);
                if (value.m_cellId != comment_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    comment_Accessor_Field.m_ptr = comment_Accessor_Field.ResizeFunction(targetPtr, 0, length + sizeof(int));
                    Memory.Copy(value.m_ptr - 4, comment_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        comment_Accessor_Field.m_ptr = comment_Accessor_Field.ResizeFunction(targetPtr, 0, length + sizeof(int));
                        Memory.Copy(tmpcellptr, comment_Accessor_Field.m_ptr, length + 4);
                    }
                }

                }
                else
                {
                    
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != comment_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    comment_Accessor_Field.m_ptr = comment_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, comment_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        comment_Accessor_Field.m_ptr = comment_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, comment_Accessor_Field.m_ptr, length + 4);
                    }
                }

                }
                
            }
        }
        
        public static unsafe implicit operator TRACredential_Label(TRACredential_Label_Accessor accessor)
        {
            string _name = default(string);
            if (accessor.Contains_name)
            {
                
                _name = accessor.name;
                
            }
            string _comment = default(string);
            if (accessor.Contains_comment)
            {
                
                _comment = accessor.comment;
                
            }
            
            return new TRACredential_Label(
                
                        accessor.credtype,
                        accessor.version,
                        accessor.trustLevel,
                        accessor.encryptionFlag,
                        accessor.notaryudid,
                        _name ,
                        _comment 
                );
        }
        
        public unsafe static implicit operator TRACredential_Label_Accessor(TRACredential_Label field)
        {
            byte* targetPtr = null;
            
            {
            targetPtr += 1;
            targetPtr += 1;
            targetPtr += 8;
            targetPtr += 1;
            targetPtr += 1;

        if(field.notaryudid!= null)
        {
            int strlen_2 = field.notaryudid.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( field.name!= null)
            {

        if(field.name!= null)
        {
            int strlen_2 = field.name.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( field.comment!= null)
            {

        if(field.comment!= null)
        {
            int strlen_2 = field.comment.Length * 2;
            targetPtr += strlen_2+sizeof(int);
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
            byte* optheader_1 = targetPtr;
            *(optheader_1 + 0) = 0x00;            targetPtr += 1;
            *(TRACredentialType*)targetPtr = field.credtype;
            targetPtr += 1;
            *(long*)targetPtr = field.version;
            targetPtr += 8;
            *(TRATrustLevel*)targetPtr = field.trustLevel;
            targetPtr += 1;
            *(TRAEncryptionFlag*)targetPtr = field.encryptionFlag;
            targetPtr += 1;

        if(field.notaryudid!= null)
        {
            int strlen_2 = field.notaryudid.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.notaryudid)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( field.name!= null)
            {

        if(field.name!= null)
        {
            int strlen_2 = field.name.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.name)
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
            if( field.comment!= null)
            {

        if(field.comment!= null)
        {
            int strlen_2 = field.comment.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.comment)
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

            }TRACredential_Label_Accessor ret;
            
            ret = new TRACredential_Label_Accessor(tmpcellptr, null);
            
            return ret;
        }
        
        public static bool operator ==(TRACredential_Label_Accessor a, TRACredential_Label_Accessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            byte* targetPtr = a.m_ptr;
            {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
            targetPtr += 11;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
            int lengthA = (int)(targetPtr - a.m_ptr);
            targetPtr = b.m_ptr;
            {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
            targetPtr += 11;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
            int lengthB = (int)(targetPtr - b.m_ptr);
            if(lengthA != lengthB) return false;
            return Memory.Compare(a.m_ptr,b.m_ptr,lengthA);
        }
        public static bool operator != (TRACredential_Label_Accessor a, TRACredential_Label_Accessor b)
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
