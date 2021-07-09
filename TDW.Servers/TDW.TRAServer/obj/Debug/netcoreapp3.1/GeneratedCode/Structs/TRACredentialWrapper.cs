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
    /// A .NET runtime object representation of TRACredentialWrapper defined in TSL.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct TRACredentialWrapper
    {
        
        ///<summary>
        ///Initializes a new instance of TRACredentialWrapper with the specified parameters.
        ///</summary>
        public TRACredentialWrapper(TRACredentialType credtype = default(TRACredentialType),TRATrustLevel trustLevel = default(TRATrustLevel),TRAEncryptionFlag encryptionFlag = default(TRAEncryptionFlag),long version = default(long),string notaryudid = default(string))
        {
            
            this.credtype = credtype;
            
            this.trustLevel = trustLevel;
            
            this.encryptionFlag = encryptionFlag;
            
            this.version = version;
            
            this.notaryudid = notaryudid;
            
        }
        
        public static bool operator ==(TRACredentialWrapper a, TRACredentialWrapper b)
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
                (a.trustLevel == b.trustLevel)
                &&
                (a.encryptionFlag == b.encryptionFlag)
                &&
                (a.version == b.version)
                &&
                (a.notaryudid == b.notaryudid)
                
                ;
            
        }
        public static bool operator !=(TRACredentialWrapper a, TRACredentialWrapper b)
        {
            return !(a == b);
        }
        
        public TRACredentialType credtype;
        
        public TRATrustLevel trustLevel;
        
        public TRAEncryptionFlag encryptionFlag;
        
        public long version;
        
        public string notaryudid;
        
        /// <summary>
        /// Converts the string representation of a TRACredentialWrapper to its
        /// struct equivalent. A return value indicates whether the 
        /// operation succeeded.
        /// </summary>
        /// <param name="input">A string to convert.</param>
        /// <param name="value">
        /// When this method returns, contains the struct equivalent of the value contained 
        /// in input, if the conversion succeeded, or default(TRACredentialWrapper) if the conversion
        /// failed. The conversion fails if the input parameter is null or String.Empty, or is 
        /// not of the correct format. This parameter is passed uninitialized. 
        /// </param>
        /// <returns>True if input was converted successfully; otherwise, false.</returns>
        public unsafe static bool TryParse(string input, out TRACredentialWrapper value)
        {
            try
            {
                value = Newtonsoft.Json.JsonConvert.DeserializeObject<TRACredentialWrapper>(input);
                return true;
            }
            catch { value = default(TRACredentialWrapper); return false; }
        }
        public static TRACredentialWrapper Parse(string input)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TRACredentialWrapper>(input);
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
    /// Provides in-place operations of TRACredentialWrapper defined in TSL.
    /// </summary>
    public unsafe partial class TRACredentialWrapper_Accessor : IAccessor
    {
        ///<summary>
        ///The pointer to the content of the object.
        ///</summary>
        internal byte* m_ptr;
        internal long m_cellId;
        internal unsafe TRACredentialWrapper_Accessor(byte* _CellPtr
            
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
            {            targetPtr += 11;
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
            {            targetPtr += 11;
targetPtr += *(int*)targetPtr + sizeof(int);}
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
                {}
                return *(TRACredentialType*)(targetPtr);
                
            }
            set
            {
                
                byte* targetPtr = m_ptr;
                {}                *(TRACredentialType*)targetPtr = value;
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
                {            targetPtr += 1;
}
                return *(TRATrustLevel*)(targetPtr);
                
            }
            set
            {
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 1;
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
                {            targetPtr += 2;
}
                return *(TRAEncryptionFlag*)(targetPtr);
                
            }
            set
            {
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 2;
}                *(TRAEncryptionFlag*)targetPtr = value;
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
                {            targetPtr += 3;
}
                return *(long*)(targetPtr);
                
            }
            set
            {
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 3;
}                *(long*)targetPtr = value;
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
                {            targetPtr += 11;
}notaryudid_Accessor_Field.m_ptr = targetPtr + 4;
                notaryudid_Accessor_Field.m_cellId = this.m_cellId;
                return notaryudid_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                notaryudid_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 11;
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
        
        public static unsafe implicit operator TRACredentialWrapper(TRACredentialWrapper_Accessor accessor)
        {
            
            return new TRACredentialWrapper(
                
                        accessor.credtype,
                        accessor.trustLevel,
                        accessor.encryptionFlag,
                        accessor.version,
                        accessor.notaryudid
                );
        }
        
        public unsafe static implicit operator TRACredentialWrapper_Accessor(TRACredentialWrapper field)
        {
            byte* targetPtr = null;
            
            {
            targetPtr += 1;
            targetPtr += 1;
            targetPtr += 1;
            targetPtr += 8;

        if(field.notaryudid!= null)
        {
            int strlen_2 = field.notaryudid.Length * 2;
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
            *(TRACredentialType*)targetPtr = field.credtype;
            targetPtr += 1;
            *(TRATrustLevel*)targetPtr = field.trustLevel;
            targetPtr += 1;
            *(TRAEncryptionFlag*)targetPtr = field.encryptionFlag;
            targetPtr += 1;
            *(long*)targetPtr = field.version;
            targetPtr += 8;

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

            }TRACredentialWrapper_Accessor ret;
            
            ret = new TRACredentialWrapper_Accessor(tmpcellptr, null);
            
            return ret;
        }
        
        public static bool operator ==(TRACredentialWrapper_Accessor a, TRACredentialWrapper_Accessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            byte* targetPtr = a.m_ptr;
            {            targetPtr += 11;
targetPtr += *(int*)targetPtr + sizeof(int);}
            int lengthA = (int)(targetPtr - a.m_ptr);
            targetPtr = b.m_ptr;
            {            targetPtr += 11;
targetPtr += *(int*)targetPtr + sizeof(int);}
            int lengthB = (int)(targetPtr - b.m_ptr);
            if(lengthA != lengthB) return false;
            return Memory.Compare(a.m_ptr,b.m_ptr,lengthA);
        }
        public static bool operator != (TRACredentialWrapper_Accessor a, TRACredentialWrapper_Accessor b)
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
