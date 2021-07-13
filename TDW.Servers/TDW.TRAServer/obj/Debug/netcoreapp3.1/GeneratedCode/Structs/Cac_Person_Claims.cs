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
    /// A .NET runtime object representation of Cac_Person_Claims defined in TSL.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct Cac_Person_Claims
    {
        
        ///<summary>
        ///Initializes a new instance of Cac_Person_Claims with the specified parameters.
        ///</summary>
        public Cac_Person_Claims(string cbc_FirstName = default(string),string cbc_MiddleName = default(string),string cbc_FamilyName = default(string),string cbc_JobTitle = default(string))
        {
            
            this.cbc_FirstName = cbc_FirstName;
            
            this.cbc_MiddleName = cbc_MiddleName;
            
            this.cbc_FamilyName = cbc_FamilyName;
            
            this.cbc_JobTitle = cbc_JobTitle;
            
        }
        
        public static bool operator ==(Cac_Person_Claims a, Cac_Person_Claims b)
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
                
                (a.cbc_FirstName == b.cbc_FirstName)
                &&
                (a.cbc_MiddleName == b.cbc_MiddleName)
                &&
                (a.cbc_FamilyName == b.cbc_FamilyName)
                &&
                (a.cbc_JobTitle == b.cbc_JobTitle)
                
                ;
            
        }
        public static bool operator !=(Cac_Person_Claims a, Cac_Person_Claims b)
        {
            return !(a == b);
        }
        
        public string cbc_FirstName;
        
        public string cbc_MiddleName;
        
        public string cbc_FamilyName;
        
        public string cbc_JobTitle;
        
        /// <summary>
        /// Converts the string representation of a Cac_Person_Claims to its
        /// struct equivalent. A return value indicates whether the 
        /// operation succeeded.
        /// </summary>
        /// <param name="input">A string to convert.</param>
        /// <param name="value">
        /// When this method returns, contains the struct equivalent of the value contained 
        /// in input, if the conversion succeeded, or default(Cac_Person_Claims) if the conversion
        /// failed. The conversion fails if the input parameter is null or String.Empty, or is 
        /// not of the correct format. This parameter is passed uninitialized. 
        /// </param>
        /// <returns>True if input was converted successfully; otherwise, false.</returns>
        public unsafe static bool TryParse(string input, out Cac_Person_Claims value)
        {
            try
            {
                value = Newtonsoft.Json.JsonConvert.DeserializeObject<Cac_Person_Claims>(input);
                return true;
            }
            catch { value = default(Cac_Person_Claims); return false; }
        }
        public static Cac_Person_Claims Parse(string input)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Cac_Person_Claims>(input);
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
    /// Provides in-place operations of Cac_Person_Claims defined in TSL.
    /// </summary>
    public unsafe partial class Cac_Person_Claims_Accessor : IAccessor
    {
        ///<summary>
        ///The pointer to the content of the object.
        ///</summary>
        internal byte* m_ptr;
        internal long m_cellId;
        internal unsafe Cac_Person_Claims_Accessor(byte* _CellPtr
            
            , ResizeFunctionDelegate func
            )
        {
            m_ptr = _CellPtr;
            
            ResizeFunction = func;
                    cbc_FirstName_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        cbc_MiddleName_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        cbc_FamilyName_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        cbc_JobTitle_Accessor_Field = new StringAccessor(null,
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
            {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
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
            {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            int size = (int)(targetPtr - m_ptr);
            return size;
        }
        public ResizeFunctionDelegate ResizeFunction { get; set; }
        #endregion
        StringAccessor cbc_FirstName_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cbc_FirstName.
        ///</summary>
        public unsafe StringAccessor cbc_FirstName
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {}cbc_FirstName_Accessor_Field.m_ptr = targetPtr + 4;
                cbc_FirstName_Accessor_Field.m_cellId = this.m_cellId;
                return cbc_FirstName_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cbc_FirstName_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != cbc_FirstName_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    cbc_FirstName_Accessor_Field.m_ptr = cbc_FirstName_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, cbc_FirstName_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        cbc_FirstName_Accessor_Field.m_ptr = cbc_FirstName_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, cbc_FirstName_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        StringAccessor cbc_MiddleName_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cbc_MiddleName.
        ///</summary>
        public unsafe StringAccessor cbc_MiddleName
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);}cbc_MiddleName_Accessor_Field.m_ptr = targetPtr + 4;
                cbc_MiddleName_Accessor_Field.m_cellId = this.m_cellId;
                return cbc_MiddleName_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cbc_MiddleName_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != cbc_MiddleName_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    cbc_MiddleName_Accessor_Field.m_ptr = cbc_MiddleName_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, cbc_MiddleName_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        cbc_MiddleName_Accessor_Field.m_ptr = cbc_MiddleName_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, cbc_MiddleName_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        StringAccessor cbc_FamilyName_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cbc_FamilyName.
        ///</summary>
        public unsafe StringAccessor cbc_FamilyName
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}cbc_FamilyName_Accessor_Field.m_ptr = targetPtr + 4;
                cbc_FamilyName_Accessor_Field.m_cellId = this.m_cellId;
                return cbc_FamilyName_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cbc_FamilyName_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != cbc_FamilyName_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    cbc_FamilyName_Accessor_Field.m_ptr = cbc_FamilyName_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, cbc_FamilyName_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        cbc_FamilyName_Accessor_Field.m_ptr = cbc_FamilyName_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, cbc_FamilyName_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        StringAccessor cbc_JobTitle_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cbc_JobTitle.
        ///</summary>
        public unsafe StringAccessor cbc_JobTitle
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}cbc_JobTitle_Accessor_Field.m_ptr = targetPtr + 4;
                cbc_JobTitle_Accessor_Field.m_cellId = this.m_cellId;
                return cbc_JobTitle_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cbc_JobTitle_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != cbc_JobTitle_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    cbc_JobTitle_Accessor_Field.m_ptr = cbc_JobTitle_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, cbc_JobTitle_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        cbc_JobTitle_Accessor_Field.m_ptr = cbc_JobTitle_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, cbc_JobTitle_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        
        public static unsafe implicit operator Cac_Person_Claims(Cac_Person_Claims_Accessor accessor)
        {
            
            return new Cac_Person_Claims(
                
                        accessor.cbc_FirstName,
                        accessor.cbc_MiddleName,
                        accessor.cbc_FamilyName,
                        accessor.cbc_JobTitle
                );
        }
        
        public unsafe static implicit operator Cac_Person_Claims_Accessor(Cac_Person_Claims field)
        {
            byte* targetPtr = null;
            
            {

        if(field.cbc_FirstName!= null)
        {
            int strlen_2 = field.cbc_FirstName.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.cbc_MiddleName!= null)
        {
            int strlen_2 = field.cbc_MiddleName.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.cbc_FamilyName!= null)
        {
            int strlen_2 = field.cbc_FamilyName.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.cbc_JobTitle!= null)
        {
            int strlen_2 = field.cbc_JobTitle.Length * 2;
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

        if(field.cbc_FirstName!= null)
        {
            int strlen_2 = field.cbc_FirstName.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.cbc_FirstName)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.cbc_MiddleName!= null)
        {
            int strlen_2 = field.cbc_MiddleName.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.cbc_MiddleName)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.cbc_FamilyName!= null)
        {
            int strlen_2 = field.cbc_FamilyName.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.cbc_FamilyName)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.cbc_JobTitle!= null)
        {
            int strlen_2 = field.cbc_JobTitle.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.cbc_JobTitle)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }Cac_Person_Claims_Accessor ret;
            
            ret = new Cac_Person_Claims_Accessor(tmpcellptr, null);
            
            return ret;
        }
        
        public static bool operator ==(Cac_Person_Claims_Accessor a, Cac_Person_Claims_Accessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            byte* targetPtr = a.m_ptr;
            {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            int lengthA = (int)(targetPtr - a.m_ptr);
            targetPtr = b.m_ptr;
            {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            int lengthB = (int)(targetPtr - b.m_ptr);
            if(lengthA != lengthB) return false;
            return Memory.Compare(a.m_ptr,b.m_ptr,lengthA);
        }
        public static bool operator != (Cac_Person_Claims_Accessor a, Cac_Person_Claims_Accessor b)
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
