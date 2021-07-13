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
    /// A .NET runtime object representation of Cac_Contact_Claims defined in TSL.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct Cac_Contact_Claims
    {
        
        ///<summary>
        ///Initializes a new instance of Cac_Contact_Claims with the specified parameters.
        ///</summary>
        public Cac_Contact_Claims(string cbc_Telephone = default(string),string cbc_Telefax = default(string),string cbc_ElectronicMail = default(string))
        {
            
            this.cbc_Telephone = cbc_Telephone;
            
            this.cbc_Telefax = cbc_Telefax;
            
            this.cbc_ElectronicMail = cbc_ElectronicMail;
            
        }
        
        public static bool operator ==(Cac_Contact_Claims a, Cac_Contact_Claims b)
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
                
                (a.cbc_Telephone == b.cbc_Telephone)
                &&
                (a.cbc_Telefax == b.cbc_Telefax)
                &&
                (a.cbc_ElectronicMail == b.cbc_ElectronicMail)
                
                ;
            
        }
        public static bool operator !=(Cac_Contact_Claims a, Cac_Contact_Claims b)
        {
            return !(a == b);
        }
        
        public string cbc_Telephone;
        
        public string cbc_Telefax;
        
        public string cbc_ElectronicMail;
        
        /// <summary>
        /// Converts the string representation of a Cac_Contact_Claims to its
        /// struct equivalent. A return value indicates whether the 
        /// operation succeeded.
        /// </summary>
        /// <param name="input">A string to convert.</param>
        /// <param name="value">
        /// When this method returns, contains the struct equivalent of the value contained 
        /// in input, if the conversion succeeded, or default(Cac_Contact_Claims) if the conversion
        /// failed. The conversion fails if the input parameter is null or String.Empty, or is 
        /// not of the correct format. This parameter is passed uninitialized. 
        /// </param>
        /// <returns>True if input was converted successfully; otherwise, false.</returns>
        public unsafe static bool TryParse(string input, out Cac_Contact_Claims value)
        {
            try
            {
                value = Newtonsoft.Json.JsonConvert.DeserializeObject<Cac_Contact_Claims>(input);
                return true;
            }
            catch { value = default(Cac_Contact_Claims); return false; }
        }
        public static Cac_Contact_Claims Parse(string input)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Cac_Contact_Claims>(input);
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
    /// Provides in-place operations of Cac_Contact_Claims defined in TSL.
    /// </summary>
    public unsafe partial class Cac_Contact_Claims_Accessor : IAccessor
    {
        ///<summary>
        ///The pointer to the content of the object.
        ///</summary>
        internal byte* m_ptr;
        internal long m_cellId;
        internal unsafe Cac_Contact_Claims_Accessor(byte* _CellPtr
            
            , ResizeFunctionDelegate func
            )
        {
            m_ptr = _CellPtr;
            
            ResizeFunction = func;
                    cbc_Telephone_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        cbc_Telefax_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        cbc_ElectronicMail_Accessor_Field = new StringAccessor(null,
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
            {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
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
            {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            int size = (int)(targetPtr - m_ptr);
            return size;
        }
        public ResizeFunctionDelegate ResizeFunction { get; set; }
        #endregion
        StringAccessor cbc_Telephone_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cbc_Telephone.
        ///</summary>
        public unsafe StringAccessor cbc_Telephone
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {}cbc_Telephone_Accessor_Field.m_ptr = targetPtr + 4;
                cbc_Telephone_Accessor_Field.m_cellId = this.m_cellId;
                return cbc_Telephone_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cbc_Telephone_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != cbc_Telephone_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    cbc_Telephone_Accessor_Field.m_ptr = cbc_Telephone_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, cbc_Telephone_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        cbc_Telephone_Accessor_Field.m_ptr = cbc_Telephone_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, cbc_Telephone_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        StringAccessor cbc_Telefax_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cbc_Telefax.
        ///</summary>
        public unsafe StringAccessor cbc_Telefax
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);}cbc_Telefax_Accessor_Field.m_ptr = targetPtr + 4;
                cbc_Telefax_Accessor_Field.m_cellId = this.m_cellId;
                return cbc_Telefax_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cbc_Telefax_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != cbc_Telefax_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    cbc_Telefax_Accessor_Field.m_ptr = cbc_Telefax_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, cbc_Telefax_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        cbc_Telefax_Accessor_Field.m_ptr = cbc_Telefax_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, cbc_Telefax_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        StringAccessor cbc_ElectronicMail_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cbc_ElectronicMail.
        ///</summary>
        public unsafe StringAccessor cbc_ElectronicMail
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}cbc_ElectronicMail_Accessor_Field.m_ptr = targetPtr + 4;
                cbc_ElectronicMail_Accessor_Field.m_cellId = this.m_cellId;
                return cbc_ElectronicMail_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cbc_ElectronicMail_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != cbc_ElectronicMail_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    cbc_ElectronicMail_Accessor_Field.m_ptr = cbc_ElectronicMail_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, cbc_ElectronicMail_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        cbc_ElectronicMail_Accessor_Field.m_ptr = cbc_ElectronicMail_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, cbc_ElectronicMail_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        
        public static unsafe implicit operator Cac_Contact_Claims(Cac_Contact_Claims_Accessor accessor)
        {
            
            return new Cac_Contact_Claims(
                
                        accessor.cbc_Telephone,
                        accessor.cbc_Telefax,
                        accessor.cbc_ElectronicMail
                );
        }
        
        public unsafe static implicit operator Cac_Contact_Claims_Accessor(Cac_Contact_Claims field)
        {
            byte* targetPtr = null;
            
            {

        if(field.cbc_Telephone!= null)
        {
            int strlen_2 = field.cbc_Telephone.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.cbc_Telefax!= null)
        {
            int strlen_2 = field.cbc_Telefax.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.cbc_ElectronicMail!= null)
        {
            int strlen_2 = field.cbc_ElectronicMail.Length * 2;
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

        if(field.cbc_Telephone!= null)
        {
            int strlen_2 = field.cbc_Telephone.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.cbc_Telephone)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.cbc_Telefax!= null)
        {
            int strlen_2 = field.cbc_Telefax.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.cbc_Telefax)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.cbc_ElectronicMail!= null)
        {
            int strlen_2 = field.cbc_ElectronicMail.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.cbc_ElectronicMail)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }Cac_Contact_Claims_Accessor ret;
            
            ret = new Cac_Contact_Claims_Accessor(tmpcellptr, null);
            
            return ret;
        }
        
        public static bool operator ==(Cac_Contact_Claims_Accessor a, Cac_Contact_Claims_Accessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            byte* targetPtr = a.m_ptr;
            {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            int lengthA = (int)(targetPtr - a.m_ptr);
            targetPtr = b.m_ptr;
            {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            int lengthB = (int)(targetPtr - b.m_ptr);
            if(lengthA != lengthB) return false;
            return Memory.Compare(a.m_ptr,b.m_ptr,lengthA);
        }
        public static bool operator != (Cac_Contact_Claims_Accessor a, Cac_Contact_Claims_Accessor b)
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
