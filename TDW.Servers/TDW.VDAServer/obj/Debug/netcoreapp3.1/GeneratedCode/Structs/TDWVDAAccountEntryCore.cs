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
    /// A .NET runtime object representation of TDWVDAAccountEntryCore defined in TSL.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct TDWVDAAccountEntryCore
    {
        
        ///<summary>
        ///Initializes a new instance of TDWVDAAccountEntryCore with the specified parameters.
        ///</summary>
        public TDWVDAAccountEntryCore(long id = default(long),string udid = default(string),string walletname = default(string),string walletpassword = default(string),string walletaccountname = default(string),string ledgeraddress = default(string))
        {
            
            this.id = id;
            
            this.udid = udid;
            
            this.walletname = walletname;
            
            this.walletpassword = walletpassword;
            
            this.walletaccountname = walletaccountname;
            
            this.ledgeraddress = ledgeraddress;
            
        }
        
        public static bool operator ==(TDWVDAAccountEntryCore a, TDWVDAAccountEntryCore b)
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
                (a.walletname == b.walletname)
                &&
                (a.walletpassword == b.walletpassword)
                &&
                (a.walletaccountname == b.walletaccountname)
                &&
                (a.ledgeraddress == b.ledgeraddress)
                
                ;
            
        }
        public static bool operator !=(TDWVDAAccountEntryCore a, TDWVDAAccountEntryCore b)
        {
            return !(a == b);
        }
        
        public long id;
        
        public string udid;
        
        public string walletname;
        
        public string walletpassword;
        
        public string walletaccountname;
        
        public string ledgeraddress;
        
        /// <summary>
        /// Converts the string representation of a TDWVDAAccountEntryCore to its
        /// struct equivalent. A return value indicates whether the 
        /// operation succeeded.
        /// </summary>
        /// <param name="input">A string to convert.</param>
        /// <param name="value">
        /// When this method returns, contains the struct equivalent of the value contained 
        /// in input, if the conversion succeeded, or default(TDWVDAAccountEntryCore) if the conversion
        /// failed. The conversion fails if the input parameter is null or String.Empty, or is 
        /// not of the correct format. This parameter is passed uninitialized. 
        /// </param>
        /// <returns>True if input was converted successfully; otherwise, false.</returns>
        public unsafe static bool TryParse(string input, out TDWVDAAccountEntryCore value)
        {
            try
            {
                value = Newtonsoft.Json.JsonConvert.DeserializeObject<TDWVDAAccountEntryCore>(input);
                return true;
            }
            catch { value = default(TDWVDAAccountEntryCore); return false; }
        }
        public static TDWVDAAccountEntryCore Parse(string input)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TDWVDAAccountEntryCore>(input);
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
    /// Provides in-place operations of TDWVDAAccountEntryCore defined in TSL.
    /// </summary>
    public unsafe partial class TDWVDAAccountEntryCore_Accessor : IAccessor
    {
        ///<summary>
        ///The pointer to the content of the object.
        ///</summary>
        internal byte* m_ptr;
        internal long m_cellId;
        internal unsafe TDWVDAAccountEntryCore_Accessor(byte* _CellPtr
            
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
                });        walletname_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        walletpassword_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        walletaccountname_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        ledgeraddress_Accessor_Field = new StringAccessor(null,
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
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
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
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
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
        StringAccessor walletname_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field walletname.
        ///</summary>
        public unsafe StringAccessor walletname
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);}walletname_Accessor_Field.m_ptr = targetPtr + 4;
                walletname_Accessor_Field.m_cellId = this.m_cellId;
                return walletname_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                walletname_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != walletname_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    walletname_Accessor_Field.m_ptr = walletname_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, walletname_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        walletname_Accessor_Field.m_ptr = walletname_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, walletname_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        StringAccessor walletpassword_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field walletpassword.
        ///</summary>
        public unsafe StringAccessor walletpassword
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}walletpassword_Accessor_Field.m_ptr = targetPtr + 4;
                walletpassword_Accessor_Field.m_cellId = this.m_cellId;
                return walletpassword_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                walletpassword_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != walletpassword_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    walletpassword_Accessor_Field.m_ptr = walletpassword_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, walletpassword_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        walletpassword_Accessor_Field.m_ptr = walletpassword_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, walletpassword_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        StringAccessor walletaccountname_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field walletaccountname.
        ///</summary>
        public unsafe StringAccessor walletaccountname
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}walletaccountname_Accessor_Field.m_ptr = targetPtr + 4;
                walletaccountname_Accessor_Field.m_cellId = this.m_cellId;
                return walletaccountname_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                walletaccountname_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != walletaccountname_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    walletaccountname_Accessor_Field.m_ptr = walletaccountname_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, walletaccountname_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        walletaccountname_Accessor_Field.m_ptr = walletaccountname_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, walletaccountname_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        StringAccessor ledgeraddress_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field ledgeraddress.
        ///</summary>
        public unsafe StringAccessor ledgeraddress
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}ledgeraddress_Accessor_Field.m_ptr = targetPtr + 4;
                ledgeraddress_Accessor_Field.m_cellId = this.m_cellId;
                return ledgeraddress_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                ledgeraddress_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != ledgeraddress_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    ledgeraddress_Accessor_Field.m_ptr = ledgeraddress_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, ledgeraddress_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        ledgeraddress_Accessor_Field.m_ptr = ledgeraddress_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, ledgeraddress_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        
        public static unsafe implicit operator TDWVDAAccountEntryCore(TDWVDAAccountEntryCore_Accessor accessor)
        {
            
            return new TDWVDAAccountEntryCore(
                
                        accessor.id,
                        accessor.udid,
                        accessor.walletname,
                        accessor.walletpassword,
                        accessor.walletaccountname,
                        accessor.ledgeraddress
                );
        }
        
        public unsafe static implicit operator TDWVDAAccountEntryCore_Accessor(TDWVDAAccountEntryCore field)
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

        if(field.walletname!= null)
        {
            int strlen_2 = field.walletname.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.walletpassword!= null)
        {
            int strlen_2 = field.walletpassword.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.walletaccountname!= null)
        {
            int strlen_2 = field.walletaccountname.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.ledgeraddress!= null)
        {
            int strlen_2 = field.ledgeraddress.Length * 2;
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

        if(field.walletname!= null)
        {
            int strlen_2 = field.walletname.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.walletname)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.walletpassword!= null)
        {
            int strlen_2 = field.walletpassword.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.walletpassword)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.walletaccountname!= null)
        {
            int strlen_2 = field.walletaccountname.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.walletaccountname)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.ledgeraddress!= null)
        {
            int strlen_2 = field.ledgeraddress.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.ledgeraddress)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }TDWVDAAccountEntryCore_Accessor ret;
            
            ret = new TDWVDAAccountEntryCore_Accessor(tmpcellptr, null);
            
            return ret;
        }
        
        public static bool operator ==(TDWVDAAccountEntryCore_Accessor a, TDWVDAAccountEntryCore_Accessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            byte* targetPtr = a.m_ptr;
            {            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            int lengthA = (int)(targetPtr - a.m_ptr);
            targetPtr = b.m_ptr;
            {            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            int lengthB = (int)(targetPtr - b.m_ptr);
            if(lengthA != lengthB) return false;
            return Memory.Compare(a.m_ptr,b.m_ptr,lengthA);
        }
        public static bool operator != (TDWVDAAccountEntryCore_Accessor a, TDWVDAAccountEntryCore_Accessor b)
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
