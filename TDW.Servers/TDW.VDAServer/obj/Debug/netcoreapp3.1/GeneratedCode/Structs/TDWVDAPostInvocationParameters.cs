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
    /// A .NET runtime object representation of TDWVDAPostInvocationParameters defined in TSL.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct TDWVDAPostInvocationParameters
    {
        
        ///<summary>
        ///Initializes a new instance of TDWVDAPostInvocationParameters with the specified parameters.
        ///</summary>
        public TDWVDAPostInvocationParameters(string serviceEndpointUrl = default(string),long servicEndpointPort = default(long),string wallet = default(string),string walletPassword = default(string),string senderAccount = default(string))
        {
            
            this.serviceEndpointUrl = serviceEndpointUrl;
            
            this.servicEndpointPort = servicEndpointPort;
            
            this.wallet = wallet;
            
            this.walletPassword = walletPassword;
            
            this.senderAccount = senderAccount;
            
        }
        
        public static bool operator ==(TDWVDAPostInvocationParameters a, TDWVDAPostInvocationParameters b)
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
                
                (a.serviceEndpointUrl == b.serviceEndpointUrl)
                &&
                (a.servicEndpointPort == b.servicEndpointPort)
                &&
                (a.wallet == b.wallet)
                &&
                (a.walletPassword == b.walletPassword)
                &&
                (a.senderAccount == b.senderAccount)
                
                ;
            
        }
        public static bool operator !=(TDWVDAPostInvocationParameters a, TDWVDAPostInvocationParameters b)
        {
            return !(a == b);
        }
        
        public string serviceEndpointUrl;
        
        public long servicEndpointPort;
        
        public string wallet;
        
        public string walletPassword;
        
        public string senderAccount;
        
        /// <summary>
        /// Converts the string representation of a TDWVDAPostInvocationParameters to its
        /// struct equivalent. A return value indicates whether the 
        /// operation succeeded.
        /// </summary>
        /// <param name="input">A string to convert.</param>
        /// <param name="value">
        /// When this method returns, contains the struct equivalent of the value contained 
        /// in input, if the conversion succeeded, or default(TDWVDAPostInvocationParameters) if the conversion
        /// failed. The conversion fails if the input parameter is null or String.Empty, or is 
        /// not of the correct format. This parameter is passed uninitialized. 
        /// </param>
        /// <returns>True if input was converted successfully; otherwise, false.</returns>
        public unsafe static bool TryParse(string input, out TDWVDAPostInvocationParameters value)
        {
            try
            {
                value = Newtonsoft.Json.JsonConvert.DeserializeObject<TDWVDAPostInvocationParameters>(input);
                return true;
            }
            catch { value = default(TDWVDAPostInvocationParameters); return false; }
        }
        public static TDWVDAPostInvocationParameters Parse(string input)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TDWVDAPostInvocationParameters>(input);
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
    /// Provides in-place operations of TDWVDAPostInvocationParameters defined in TSL.
    /// </summary>
    public unsafe partial class TDWVDAPostInvocationParameters_Accessor : IAccessor
    {
        ///<summary>
        ///The pointer to the content of the object.
        ///</summary>
        internal byte* m_ptr;
        internal long m_cellId;
        internal unsafe TDWVDAPostInvocationParameters_Accessor(byte* _CellPtr
            
            , ResizeFunctionDelegate func
            )
        {
            m_ptr = _CellPtr;
            
            ResizeFunction = func;
                    serviceEndpointUrl_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        wallet_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        walletPassword_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        senderAccount_Accessor_Field = new StringAccessor(null,
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
            {targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
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
            {targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            int size = (int)(targetPtr - m_ptr);
            return size;
        }
        public ResizeFunctionDelegate ResizeFunction { get; set; }
        #endregion
        StringAccessor serviceEndpointUrl_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field serviceEndpointUrl.
        ///</summary>
        public unsafe StringAccessor serviceEndpointUrl
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {}serviceEndpointUrl_Accessor_Field.m_ptr = targetPtr + 4;
                serviceEndpointUrl_Accessor_Field.m_cellId = this.m_cellId;
                return serviceEndpointUrl_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                serviceEndpointUrl_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != serviceEndpointUrl_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    serviceEndpointUrl_Accessor_Field.m_ptr = serviceEndpointUrl_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, serviceEndpointUrl_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        serviceEndpointUrl_Accessor_Field.m_ptr = serviceEndpointUrl_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, serviceEndpointUrl_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        
        ///<summary>
        ///Provides in-place access to the object field servicEndpointPort.
        ///</summary>
        public unsafe long servicEndpointPort
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);}
                return *(long*)(targetPtr);
                
            }
            set
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);}                *(long*)targetPtr = value;
            }
        }
        StringAccessor wallet_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field wallet.
        ///</summary>
        public unsafe StringAccessor wallet
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}wallet_Accessor_Field.m_ptr = targetPtr + 4;
                wallet_Accessor_Field.m_cellId = this.m_cellId;
                return wallet_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                wallet_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != wallet_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    wallet_Accessor_Field.m_ptr = wallet_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, wallet_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        wallet_Accessor_Field.m_ptr = wallet_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, wallet_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        StringAccessor walletPassword_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field walletPassword.
        ///</summary>
        public unsafe StringAccessor walletPassword
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);}walletPassword_Accessor_Field.m_ptr = targetPtr + 4;
                walletPassword_Accessor_Field.m_cellId = this.m_cellId;
                return walletPassword_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                walletPassword_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != walletPassword_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    walletPassword_Accessor_Field.m_ptr = walletPassword_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, walletPassword_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        walletPassword_Accessor_Field.m_ptr = walletPassword_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, walletPassword_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        StringAccessor senderAccount_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field senderAccount.
        ///</summary>
        public unsafe StringAccessor senderAccount
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}senderAccount_Accessor_Field.m_ptr = targetPtr + 4;
                senderAccount_Accessor_Field.m_cellId = this.m_cellId;
                return senderAccount_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                senderAccount_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != senderAccount_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    senderAccount_Accessor_Field.m_ptr = senderAccount_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, senderAccount_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        senderAccount_Accessor_Field.m_ptr = senderAccount_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, senderAccount_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        
        public static unsafe implicit operator TDWVDAPostInvocationParameters(TDWVDAPostInvocationParameters_Accessor accessor)
        {
            
            return new TDWVDAPostInvocationParameters(
                
                        accessor.serviceEndpointUrl,
                        accessor.servicEndpointPort,
                        accessor.wallet,
                        accessor.walletPassword,
                        accessor.senderAccount
                );
        }
        
        public unsafe static implicit operator TDWVDAPostInvocationParameters_Accessor(TDWVDAPostInvocationParameters field)
        {
            byte* targetPtr = null;
            
            {

        if(field.serviceEndpointUrl!= null)
        {
            int strlen_2 = field.serviceEndpointUrl.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

        if(field.wallet!= null)
        {
            int strlen_2 = field.wallet.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.walletPassword!= null)
        {
            int strlen_2 = field.walletPassword.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.senderAccount!= null)
        {
            int strlen_2 = field.senderAccount.Length * 2;
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

        if(field.serviceEndpointUrl!= null)
        {
            int strlen_2 = field.serviceEndpointUrl.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.serviceEndpointUrl)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = field.servicEndpointPort;
            targetPtr += 8;

        if(field.wallet!= null)
        {
            int strlen_2 = field.wallet.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.wallet)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.walletPassword!= null)
        {
            int strlen_2 = field.walletPassword.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.walletPassword)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.senderAccount!= null)
        {
            int strlen_2 = field.senderAccount.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.senderAccount)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }TDWVDAPostInvocationParameters_Accessor ret;
            
            ret = new TDWVDAPostInvocationParameters_Accessor(tmpcellptr, null);
            
            return ret;
        }
        
        public static bool operator ==(TDWVDAPostInvocationParameters_Accessor a, TDWVDAPostInvocationParameters_Accessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            byte* targetPtr = a.m_ptr;
            {targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            int lengthA = (int)(targetPtr - a.m_ptr);
            targetPtr = b.m_ptr;
            {targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            int lengthB = (int)(targetPtr - b.m_ptr);
            if(lengthA != lengthB) return false;
            return Memory.Compare(a.m_ptr,b.m_ptr,lengthA);
        }
        public static bool operator != (TDWVDAPostInvocationParameters_Accessor a, TDWVDAPostInvocationParameters_Accessor b)
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
