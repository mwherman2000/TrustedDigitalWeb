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
    /// A .NET runtime object representation of Cac_AllowanceCharge defined in TSL.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct Cac_AllowanceCharge
    {
        
        ///<summary>
        ///Initializes a new instance of Cac_AllowanceCharge with the specified parameters.
        ///</summary>
        public Cac_AllowanceCharge(bool cbc_ChargeIndicator = default(bool),string cbc_AllowanceChargeReason = default(string),Cbc_Amount cbc_Amount = default(Cbc_Amount))
        {
            
            this.cbc_ChargeIndicator = cbc_ChargeIndicator;
            
            this.cbc_AllowanceChargeReason = cbc_AllowanceChargeReason;
            
            this.cbc_Amount = cbc_Amount;
            
        }
        
        public static bool operator ==(Cac_AllowanceCharge a, Cac_AllowanceCharge b)
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
                
                (a.cbc_ChargeIndicator == b.cbc_ChargeIndicator)
                &&
                (a.cbc_AllowanceChargeReason == b.cbc_AllowanceChargeReason)
                &&
                (a.cbc_Amount == b.cbc_Amount)
                
                ;
            
        }
        public static bool operator !=(Cac_AllowanceCharge a, Cac_AllowanceCharge b)
        {
            return !(a == b);
        }
        
        public bool cbc_ChargeIndicator;
        
        public string cbc_AllowanceChargeReason;
        
        public Cbc_Amount cbc_Amount;
        
        /// <summary>
        /// Converts the string representation of a Cac_AllowanceCharge to its
        /// struct equivalent. A return value indicates whether the 
        /// operation succeeded.
        /// </summary>
        /// <param name="input">A string to convert.</param>
        /// <param name="value">
        /// When this method returns, contains the struct equivalent of the value contained 
        /// in input, if the conversion succeeded, or default(Cac_AllowanceCharge) if the conversion
        /// failed. The conversion fails if the input parameter is null or String.Empty, or is 
        /// not of the correct format. This parameter is passed uninitialized. 
        /// </param>
        /// <returns>True if input was converted successfully; otherwise, false.</returns>
        public unsafe static bool TryParse(string input, out Cac_AllowanceCharge value)
        {
            try
            {
                value = Newtonsoft.Json.JsonConvert.DeserializeObject<Cac_AllowanceCharge>(input);
                return true;
            }
            catch { value = default(Cac_AllowanceCharge); return false; }
        }
        public static Cac_AllowanceCharge Parse(string input)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Cac_AllowanceCharge>(input);
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
    /// Provides in-place operations of Cac_AllowanceCharge defined in TSL.
    /// </summary>
    public unsafe partial class Cac_AllowanceCharge_Accessor : IAccessor
    {
        ///<summary>
        ///The pointer to the content of the object.
        ///</summary>
        internal byte* m_ptr;
        internal long m_cellId;
        internal unsafe Cac_AllowanceCharge_Accessor(byte* _CellPtr
            
            , ResizeFunctionDelegate func
            )
        {
            m_ptr = _CellPtr;
            
            ResizeFunction = func;
                    cbc_AllowanceChargeReason_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        cbc_Amount_Accessor_Field = new Cbc_Amount_Accessor(null,
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
            {            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
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
            {            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}
            int size = (int)(targetPtr - m_ptr);
            return size;
        }
        public ResizeFunctionDelegate ResizeFunction { get; set; }
        #endregion
        
        ///<summary>
        ///Provides in-place access to the object field cbc_ChargeIndicator.
        ///</summary>
        public unsafe bool cbc_ChargeIndicator
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {}
                return *(bool*)(targetPtr);
                
            }
            set
            {
                
                byte* targetPtr = m_ptr;
                {}                *(bool*)targetPtr = value;
            }
        }
        StringAccessor cbc_AllowanceChargeReason_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cbc_AllowanceChargeReason.
        ///</summary>
        public unsafe StringAccessor cbc_AllowanceChargeReason
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 1;
}cbc_AllowanceChargeReason_Accessor_Field.m_ptr = targetPtr + 4;
                cbc_AllowanceChargeReason_Accessor_Field.m_cellId = this.m_cellId;
                return cbc_AllowanceChargeReason_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cbc_AllowanceChargeReason_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 1;
}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != cbc_AllowanceChargeReason_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    cbc_AllowanceChargeReason_Accessor_Field.m_ptr = cbc_AllowanceChargeReason_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, cbc_AllowanceChargeReason_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        cbc_AllowanceChargeReason_Accessor_Field.m_ptr = cbc_AllowanceChargeReason_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, cbc_AllowanceChargeReason_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        Cbc_Amount_Accessor cbc_Amount_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cbc_Amount.
        ///</summary>
        public unsafe Cbc_Amount_Accessor cbc_Amount
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}cbc_Amount_Accessor_Field.m_ptr = targetPtr;
                cbc_Amount_Accessor_Field.m_cellId = this.m_cellId;
                return cbc_Amount_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cbc_Amount_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}
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
        
        public static unsafe implicit operator Cac_AllowanceCharge(Cac_AllowanceCharge_Accessor accessor)
        {
            
            return new Cac_AllowanceCharge(
                
                        accessor.cbc_ChargeIndicator,
                        accessor.cbc_AllowanceChargeReason,
                        accessor.cbc_Amount
                );
        }
        
        public unsafe static implicit operator Cac_AllowanceCharge_Accessor(Cac_AllowanceCharge field)
        {
            byte* targetPtr = null;
            
            {
            targetPtr += 1;

        if(field.cbc_AllowanceChargeReason!= null)
        {
            int strlen_2 = field.cbc_AllowanceChargeReason.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            {

        if(field.cbc_Amount._CurrencyID!= null)
        {
            int strlen_3 = field.cbc_Amount._CurrencyID.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            }
            byte* tmpcellptr = BufferAllocator.AllocBuffer((int)targetPtr);
            Memory.memset(tmpcellptr, 0, (ulong)targetPtr);
            targetPtr = tmpcellptr;
            
            {
            *(bool*)targetPtr = field.cbc_ChargeIndicator;
            targetPtr += 1;

        if(field.cbc_AllowanceChargeReason!= null)
        {
            int strlen_2 = field.cbc_AllowanceChargeReason.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.cbc_AllowanceChargeReason)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            {

        if(field.cbc_Amount._CurrencyID!= null)
        {
            int strlen_3 = field.cbc_Amount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.cbc_Amount._CurrencyID)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.cbc_Amount.amount;
            targetPtr += 8;

            }
            }Cac_AllowanceCharge_Accessor ret;
            
            ret = new Cac_AllowanceCharge_Accessor(tmpcellptr, null);
            
            return ret;
        }
        
        public static bool operator ==(Cac_AllowanceCharge_Accessor a, Cac_AllowanceCharge_Accessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            byte* targetPtr = a.m_ptr;
            {            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}
            int lengthA = (int)(targetPtr - a.m_ptr);
            targetPtr = b.m_ptr;
            {            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}
            int lengthB = (int)(targetPtr - b.m_ptr);
            if(lengthA != lengthB) return false;
            return Memory.Compare(a.m_ptr,b.m_ptr,lengthA);
        }
        public static bool operator != (Cac_AllowanceCharge_Accessor a, Cac_AllowanceCharge_Accessor b)
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
