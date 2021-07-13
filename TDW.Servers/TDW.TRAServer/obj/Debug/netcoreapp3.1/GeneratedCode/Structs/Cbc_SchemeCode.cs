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
    /// A .NET runtime object representation of Cbc_SchemeCode defined in TSL.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct Cbc_SchemeCode
    {
        
        ///<summary>
        ///Initializes a new instance of Cbc_SchemeCode with the specified parameters.
        ///</summary>
        public Cbc_SchemeCode(string _schemeID = default(string),string _schemeAgencyID = default(string),string code = default(string))
        {
            
            this._schemeID = _schemeID;
            
            this._schemeAgencyID = _schemeAgencyID;
            
            this.code = code;
            
        }
        
        public static bool operator ==(Cbc_SchemeCode a, Cbc_SchemeCode b)
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
                
                (a._schemeID == b._schemeID)
                &&
                (a._schemeAgencyID == b._schemeAgencyID)
                &&
                (a.code == b.code)
                
                ;
            
        }
        public static bool operator !=(Cbc_SchemeCode a, Cbc_SchemeCode b)
        {
            return !(a == b);
        }
        
        public string _schemeID;
        
        public string _schemeAgencyID;
        
        public string code;
        
        /// <summary>
        /// Converts the string representation of a Cbc_SchemeCode to its
        /// struct equivalent. A return value indicates whether the 
        /// operation succeeded.
        /// </summary>
        /// <param name="input">A string to convert.</param>
        /// <param name="value">
        /// When this method returns, contains the struct equivalent of the value contained 
        /// in input, if the conversion succeeded, or default(Cbc_SchemeCode) if the conversion
        /// failed. The conversion fails if the input parameter is null or String.Empty, or is 
        /// not of the correct format. This parameter is passed uninitialized. 
        /// </param>
        /// <returns>True if input was converted successfully; otherwise, false.</returns>
        public unsafe static bool TryParse(string input, out Cbc_SchemeCode value)
        {
            try
            {
                value = Newtonsoft.Json.JsonConvert.DeserializeObject<Cbc_SchemeCode>(input);
                return true;
            }
            catch { value = default(Cbc_SchemeCode); return false; }
        }
        public static Cbc_SchemeCode Parse(string input)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Cbc_SchemeCode>(input);
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
    /// Provides in-place operations of Cbc_SchemeCode defined in TSL.
    /// </summary>
    public unsafe partial class Cbc_SchemeCode_Accessor : IAccessor
    {
        ///<summary>
        ///The pointer to the content of the object.
        ///</summary>
        internal byte* m_ptr;
        internal long m_cellId;
        internal unsafe Cbc_SchemeCode_Accessor(byte* _CellPtr
            
            , ResizeFunctionDelegate func
            )
        {
            m_ptr = _CellPtr;
            
            ResizeFunction = func;
                    _schemeID_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        _schemeAgencyID_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        code_Accessor_Field = new StringAccessor(null,
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
                    
                    "_schemeAgencyID"
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
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_0 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
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
            {            byte* optheader_0 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_0 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}
            int size = (int)(targetPtr - m_ptr);
            return size;
        }
        public ResizeFunctionDelegate ResizeFunction { get; set; }
        #endregion
        StringAccessor _schemeID_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field _schemeID.
        ///</summary>
        public unsafe StringAccessor _schemeID
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
}_schemeID_Accessor_Field.m_ptr = targetPtr + 4;
                _schemeID_Accessor_Field.m_cellId = this.m_cellId;
                return _schemeID_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                _schemeID_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != _schemeID_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    _schemeID_Accessor_Field.m_ptr = _schemeID_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, _schemeID_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        _schemeID_Accessor_Field.m_ptr = _schemeID_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, _schemeID_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        StringAccessor _schemeAgencyID_Accessor_Field;
        
        ///<summary>
        ///Represents the presence of the optional field _schemeAgencyID.
        ///</summary>
        public bool Contains__schemeAgencyID
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
        ///Removes the optional field _schemeAgencyID from the object being operated.
        ///</summary>
        public unsafe void Remove__schemeAgencyID()
        {
            if (!this.Contains__schemeAgencyID)
            {
                throw new Exception("Optional field _schemeAgencyID doesn't exist for current cell.");
            }
            this.Contains__schemeAgencyID = false;
            byte* targetPtr = m_ptr;
            {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}
            byte* startPtr = targetPtr;
            targetPtr += *(int*)targetPtr + sizeof(int);
            this.ResizeFunction(startPtr, 0, (int)(startPtr - targetPtr));
        }
        
        ///<summary>
        ///Provides in-place access to the object field _schemeAgencyID.
        ///</summary>
        public unsafe StringAccessor _schemeAgencyID
        {
            get
            {
                
                if (!this.Contains__schemeAgencyID)
                {
                    throw new Exception("Optional field _schemeAgencyID doesn't exist for current cell.");
                }
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}_schemeAgencyID_Accessor_Field.m_ptr = targetPtr + 4;
                _schemeAgencyID_Accessor_Field.m_cellId = this.m_cellId;
                return _schemeAgencyID_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                _schemeAgencyID_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}
                bool creatingOptionalField = (!this.Contains__schemeAgencyID);
                if (creatingOptionalField)
                {
                    this.Contains__schemeAgencyID = true;
                    
                int length = *(int*)(value.m_ptr - 4);
                if (value.m_cellId != _schemeAgencyID_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    _schemeAgencyID_Accessor_Field.m_ptr = _schemeAgencyID_Accessor_Field.ResizeFunction(targetPtr, 0, length + sizeof(int));
                    Memory.Copy(value.m_ptr - 4, _schemeAgencyID_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        _schemeAgencyID_Accessor_Field.m_ptr = _schemeAgencyID_Accessor_Field.ResizeFunction(targetPtr, 0, length + sizeof(int));
                        Memory.Copy(tmpcellptr, _schemeAgencyID_Accessor_Field.m_ptr, length + 4);
                    }
                }

                }
                else
                {
                    
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != _schemeAgencyID_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    _schemeAgencyID_Accessor_Field.m_ptr = _schemeAgencyID_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, _schemeAgencyID_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        _schemeAgencyID_Accessor_Field.m_ptr = _schemeAgencyID_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, _schemeAgencyID_Accessor_Field.m_ptr, length + 4);
                    }
                }

                }
                
            }
        }
        StringAccessor code_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field code.
        ///</summary>
        public unsafe StringAccessor code
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}code_Accessor_Field.m_ptr = targetPtr + 4;
                code_Accessor_Field.m_cellId = this.m_cellId;
                return code_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                code_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != code_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    code_Accessor_Field.m_ptr = code_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, code_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        code_Accessor_Field.m_ptr = code_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, code_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        
        public static unsafe implicit operator Cbc_SchemeCode(Cbc_SchemeCode_Accessor accessor)
        {
            string __schemeAgencyID = default(string);
            if (accessor.Contains__schemeAgencyID)
            {
                
                __schemeAgencyID = accessor._schemeAgencyID;
                
            }
            
            return new Cbc_SchemeCode(
                
                        accessor._schemeID,
                        __schemeAgencyID ,
                        accessor.code
                );
        }
        
        public unsafe static implicit operator Cbc_SchemeCode_Accessor(Cbc_SchemeCode field)
        {
            byte* targetPtr = null;
            
            {
            targetPtr += 1;

        if(field._schemeID!= null)
        {
            int strlen_2 = field._schemeID.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( field._schemeAgencyID!= null)
            {

        if(field._schemeAgencyID!= null)
        {
            int strlen_2 = field._schemeAgencyID.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

        if(field.code!= null)
        {
            int strlen_2 = field.code.Length * 2;
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
            byte* optheader_1 = targetPtr;
            *(optheader_1 + 0) = 0x00;            targetPtr += 1;

        if(field._schemeID!= null)
        {
            int strlen_2 = field._schemeID.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field._schemeID)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( field._schemeAgencyID!= null)
            {

        if(field._schemeAgencyID!= null)
        {
            int strlen_2 = field._schemeAgencyID.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field._schemeAgencyID)
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

        if(field.code!= null)
        {
            int strlen_2 = field.code.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.code)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }Cbc_SchemeCode_Accessor ret;
            
            ret = new Cbc_SchemeCode_Accessor(tmpcellptr, null);
            
            return ret;
        }
        
        public static bool operator ==(Cbc_SchemeCode_Accessor a, Cbc_SchemeCode_Accessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            byte* targetPtr = a.m_ptr;
            {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}
            int lengthA = (int)(targetPtr - a.m_ptr);
            targetPtr = b.m_ptr;
            {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}
            int lengthB = (int)(targetPtr - b.m_ptr);
            if(lengthA != lengthB) return false;
            return Memory.Compare(a.m_ptr,b.m_ptr,lengthA);
        }
        public static bool operator != (Cbc_SchemeCode_Accessor a, Cbc_SchemeCode_Accessor b)
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
