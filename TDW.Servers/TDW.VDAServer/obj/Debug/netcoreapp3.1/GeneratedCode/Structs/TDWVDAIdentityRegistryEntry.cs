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
    /// A .NET runtime object representation of TDWVDAIdentityRegistryEntry defined in TSL.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct TDWVDAIdentityRegistryEntry
    {
        
        ///<summary>
        ///Initializes a new instance of TDWVDAIdentityRegistryEntry with the specified parameters.
        ///</summary>
        public TDWVDAIdentityRegistryEntry(long id = default(long),string udid = default(string),long credid = default(long),string credudid = default(string),string credpublickey = default(string),string serviceEndpointUdid = default(string),string issuerudid = default(string),string controllerudid = default(string))
        {
            
            this.id = id;
            
            this.udid = udid;
            
            this.credid = credid;
            
            this.credudid = credudid;
            
            this.credpublickey = credpublickey;
            
            this.serviceEndpointUdid = serviceEndpointUdid;
            
            this.issuerudid = issuerudid;
            
            this.controllerudid = controllerudid;
            
        }
        
        public static bool operator ==(TDWVDAIdentityRegistryEntry a, TDWVDAIdentityRegistryEntry b)
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
                (a.credid == b.credid)
                &&
                (a.credudid == b.credudid)
                &&
                (a.credpublickey == b.credpublickey)
                &&
                (a.serviceEndpointUdid == b.serviceEndpointUdid)
                &&
                (a.issuerudid == b.issuerudid)
                &&
                (a.controllerudid == b.controllerudid)
                
                ;
            
        }
        public static bool operator !=(TDWVDAIdentityRegistryEntry a, TDWVDAIdentityRegistryEntry b)
        {
            return !(a == b);
        }
        
        public long id;
        
        public string udid;
        
        public long credid;
        
        public string credudid;
        
        public string credpublickey;
        
        public string serviceEndpointUdid;
        
        public string issuerudid;
        
        public string controllerudid;
        
        /// <summary>
        /// Converts the string representation of a TDWVDAIdentityRegistryEntry to its
        /// struct equivalent. A return value indicates whether the 
        /// operation succeeded.
        /// </summary>
        /// <param name="input">A string to convert.</param>
        /// <param name="value">
        /// When this method returns, contains the struct equivalent of the value contained 
        /// in input, if the conversion succeeded, or default(TDWVDAIdentityRegistryEntry) if the conversion
        /// failed. The conversion fails if the input parameter is null or String.Empty, or is 
        /// not of the correct format. This parameter is passed uninitialized. 
        /// </param>
        /// <returns>True if input was converted successfully; otherwise, false.</returns>
        public unsafe static bool TryParse(string input, out TDWVDAIdentityRegistryEntry value)
        {
            try
            {
                value = Newtonsoft.Json.JsonConvert.DeserializeObject<TDWVDAIdentityRegistryEntry>(input);
                return true;
            }
            catch { value = default(TDWVDAIdentityRegistryEntry); return false; }
        }
        public static TDWVDAIdentityRegistryEntry Parse(string input)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TDWVDAIdentityRegistryEntry>(input);
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
    /// Provides in-place operations of TDWVDAIdentityRegistryEntry defined in TSL.
    /// </summary>
    public unsafe partial class TDWVDAIdentityRegistryEntry_Accessor : IAccessor
    {
        ///<summary>
        ///The pointer to the content of the object.
        ///</summary>
        internal byte* m_ptr;
        internal long m_cellId;
        internal unsafe TDWVDAIdentityRegistryEntry_Accessor(byte* _CellPtr
            
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
                });        credudid_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        credpublickey_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        serviceEndpointUdid_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        issuerudid_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        controllerudid_Accessor_Field = new StringAccessor(null,
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
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
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
        
        ///<summary>
        ///Provides in-place access to the object field credid.
        ///</summary>
        public unsafe long credid
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
        StringAccessor credudid_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field credudid.
        ///</summary>
        public unsafe StringAccessor credudid
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}credudid_Accessor_Field.m_ptr = targetPtr + 4;
                credudid_Accessor_Field.m_cellId = this.m_cellId;
                return credudid_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                credudid_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != credudid_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    credudid_Accessor_Field.m_ptr = credudid_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, credudid_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        credudid_Accessor_Field.m_ptr = credudid_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, credudid_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        StringAccessor credpublickey_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field credpublickey.
        ///</summary>
        public unsafe StringAccessor credpublickey
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);}credpublickey_Accessor_Field.m_ptr = targetPtr + 4;
                credpublickey_Accessor_Field.m_cellId = this.m_cellId;
                return credpublickey_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                credpublickey_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != credpublickey_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    credpublickey_Accessor_Field.m_ptr = credpublickey_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, credpublickey_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        credpublickey_Accessor_Field.m_ptr = credpublickey_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, credpublickey_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        StringAccessor serviceEndpointUdid_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field serviceEndpointUdid.
        ///</summary>
        public unsafe StringAccessor serviceEndpointUdid
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}serviceEndpointUdid_Accessor_Field.m_ptr = targetPtr + 4;
                serviceEndpointUdid_Accessor_Field.m_cellId = this.m_cellId;
                return serviceEndpointUdid_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                serviceEndpointUdid_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != serviceEndpointUdid_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    serviceEndpointUdid_Accessor_Field.m_ptr = serviceEndpointUdid_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, serviceEndpointUdid_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        serviceEndpointUdid_Accessor_Field.m_ptr = serviceEndpointUdid_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, serviceEndpointUdid_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        StringAccessor issuerudid_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field issuerudid.
        ///</summary>
        public unsafe StringAccessor issuerudid
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}issuerudid_Accessor_Field.m_ptr = targetPtr + 4;
                issuerudid_Accessor_Field.m_cellId = this.m_cellId;
                return issuerudid_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                issuerudid_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != issuerudid_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    issuerudid_Accessor_Field.m_ptr = issuerudid_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, issuerudid_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        issuerudid_Accessor_Field.m_ptr = issuerudid_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, issuerudid_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        StringAccessor controllerudid_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field controllerudid.
        ///</summary>
        public unsafe StringAccessor controllerudid
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}controllerudid_Accessor_Field.m_ptr = targetPtr + 4;
                controllerudid_Accessor_Field.m_cellId = this.m_cellId;
                return controllerudid_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                controllerudid_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != controllerudid_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    controllerudid_Accessor_Field.m_ptr = controllerudid_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, controllerudid_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        controllerudid_Accessor_Field.m_ptr = controllerudid_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, controllerudid_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        
        public static unsafe implicit operator TDWVDAIdentityRegistryEntry(TDWVDAIdentityRegistryEntry_Accessor accessor)
        {
            
            return new TDWVDAIdentityRegistryEntry(
                
                        accessor.id,
                        accessor.udid,
                        accessor.credid,
                        accessor.credudid,
                        accessor.credpublickey,
                        accessor.serviceEndpointUdid,
                        accessor.issuerudid,
                        accessor.controllerudid
                );
        }
        
        public unsafe static implicit operator TDWVDAIdentityRegistryEntry_Accessor(TDWVDAIdentityRegistryEntry field)
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

        if(field.credudid!= null)
        {
            int strlen_2 = field.credudid.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.credpublickey!= null)
        {
            int strlen_2 = field.credpublickey.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.serviceEndpointUdid!= null)
        {
            int strlen_2 = field.serviceEndpointUdid.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.issuerudid!= null)
        {
            int strlen_2 = field.issuerudid.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.controllerudid!= null)
        {
            int strlen_2 = field.controllerudid.Length * 2;
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
            *(long*)targetPtr = field.credid;
            targetPtr += 8;

        if(field.credudid!= null)
        {
            int strlen_2 = field.credudid.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.credudid)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.credpublickey!= null)
        {
            int strlen_2 = field.credpublickey.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.credpublickey)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.serviceEndpointUdid!= null)
        {
            int strlen_2 = field.serviceEndpointUdid.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.serviceEndpointUdid)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.issuerudid!= null)
        {
            int strlen_2 = field.issuerudid.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.issuerudid)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.controllerudid!= null)
        {
            int strlen_2 = field.controllerudid.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.controllerudid)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }TDWVDAIdentityRegistryEntry_Accessor ret;
            
            ret = new TDWVDAIdentityRegistryEntry_Accessor(tmpcellptr, null);
            
            return ret;
        }
        
        public static bool operator ==(TDWVDAIdentityRegistryEntry_Accessor a, TDWVDAIdentityRegistryEntry_Accessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            byte* targetPtr = a.m_ptr;
            {            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            int lengthA = (int)(targetPtr - a.m_ptr);
            targetPtr = b.m_ptr;
            {            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            int lengthB = (int)(targetPtr - b.m_ptr);
            if(lengthA != lengthB) return false;
            return Memory.Compare(a.m_ptr,b.m_ptr,lengthA);
        }
        public static bool operator != (TDWVDAIdentityRegistryEntry_Accessor a, TDWVDAIdentityRegistryEntry_Accessor b)
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
