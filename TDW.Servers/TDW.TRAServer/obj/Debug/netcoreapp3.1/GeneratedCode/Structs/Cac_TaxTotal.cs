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
    /// A .NET runtime object representation of Cac_TaxTotal defined in TSL.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct Cac_TaxTotal
    {
        
        ///<summary>
        ///Initializes a new instance of Cac_TaxTotal with the specified parameters.
        ///</summary>
        public Cac_TaxTotal(Cbc_Amount cbc_TaxAmount = default(Cbc_Amount),List<Cac_TaxSubtotal> cac_TaxSubtotals = default(List<Cac_TaxSubtotal>))
        {
            
            this.cbc_TaxAmount = cbc_TaxAmount;
            
            this.cac_TaxSubtotals = cac_TaxSubtotals;
            
        }
        
        public static bool operator ==(Cac_TaxTotal a, Cac_TaxTotal b)
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
                
                (a.cbc_TaxAmount == b.cbc_TaxAmount)
                &&
                (a.cac_TaxSubtotals == b.cac_TaxSubtotals)
                
                ;
            
        }
        public static bool operator !=(Cac_TaxTotal a, Cac_TaxTotal b)
        {
            return !(a == b);
        }
        
        public Cbc_Amount cbc_TaxAmount;
        
        public List<Cac_TaxSubtotal> cac_TaxSubtotals;
        
        /// <summary>
        /// Converts the string representation of a Cac_TaxTotal to its
        /// struct equivalent. A return value indicates whether the 
        /// operation succeeded.
        /// </summary>
        /// <param name="input">A string to convert.</param>
        /// <param name="value">
        /// When this method returns, contains the struct equivalent of the value contained 
        /// in input, if the conversion succeeded, or default(Cac_TaxTotal) if the conversion
        /// failed. The conversion fails if the input parameter is null or String.Empty, or is 
        /// not of the correct format. This parameter is passed uninitialized. 
        /// </param>
        /// <returns>True if input was converted successfully; otherwise, false.</returns>
        public unsafe static bool TryParse(string input, out Cac_TaxTotal value)
        {
            try
            {
                value = Newtonsoft.Json.JsonConvert.DeserializeObject<Cac_TaxTotal>(input);
                return true;
            }
            catch { value = default(Cac_TaxTotal); return false; }
        }
        public static Cac_TaxTotal Parse(string input)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Cac_TaxTotal>(input);
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
    /// Provides in-place operations of Cac_TaxTotal defined in TSL.
    /// </summary>
    public unsafe partial class Cac_TaxTotal_Accessor : IAccessor
    {
        ///<summary>
        ///The pointer to the content of the object.
        ///</summary>
        internal byte* m_ptr;
        internal long m_cellId;
        internal unsafe Cac_TaxTotal_Accessor(byte* _CellPtr
            
            , ResizeFunctionDelegate func
            )
        {
            m_ptr = _CellPtr;
            
            ResizeFunction = func;
                    cbc_TaxAmount_Accessor_Field = new Cbc_Amount_Accessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        cac_TaxSubtotals_Accessor_Field = new Cac_TaxSubtotal_AccessorListAccessor(null,
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
            {{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);}
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
            {{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);}
            int size = (int)(targetPtr - m_ptr);
            return size;
        }
        public ResizeFunctionDelegate ResizeFunction { get; set; }
        #endregion
        Cbc_Amount_Accessor cbc_TaxAmount_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cbc_TaxAmount.
        ///</summary>
        public unsafe Cbc_Amount_Accessor cbc_TaxAmount
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {}cbc_TaxAmount_Accessor_Field.m_ptr = targetPtr;
                cbc_TaxAmount_Accessor_Field.m_cellId = this.m_cellId;
                return cbc_TaxAmount_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cbc_TaxAmount_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {}
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
        Cac_TaxSubtotal_AccessorListAccessor cac_TaxSubtotals_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cac_TaxSubtotals.
        ///</summary>
        public unsafe Cac_TaxSubtotal_AccessorListAccessor cac_TaxSubtotals
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}cac_TaxSubtotals_Accessor_Field.m_ptr = targetPtr + 4;
                cac_TaxSubtotals_Accessor_Field.m_cellId = this.m_cellId;
                return cac_TaxSubtotals_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cac_TaxSubtotals_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != cac_TaxSubtotals_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    cac_TaxSubtotals_Accessor_Field.m_ptr = cac_TaxSubtotals_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, cac_TaxSubtotals_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        cac_TaxSubtotals_Accessor_Field.m_ptr = cac_TaxSubtotals_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, cac_TaxSubtotals_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        
        public static unsafe implicit operator Cac_TaxTotal(Cac_TaxTotal_Accessor accessor)
        {
            
            return new Cac_TaxTotal(
                
                        accessor.cbc_TaxAmount,
                        accessor.cac_TaxSubtotals
                );
        }
        
        public unsafe static implicit operator Cac_TaxTotal_Accessor(Cac_TaxTotal field)
        {
            byte* targetPtr = null;
            
            {

            {

        if(field.cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_3 = field.cbc_TaxAmount._CurrencyID.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
{

    targetPtr += sizeof(int);
    if(field.cac_TaxSubtotals!= null)
    {
        for(int iterator_2 = 0;iterator_2<field.cac_TaxSubtotals.Count;++iterator_2)
        {

            {

            {

        if(field.cac_TaxSubtotals[iterator_2].cbc_TaxableAmount._CurrencyID!= null)
        {
            int strlen_5 = field.cac_TaxSubtotals[iterator_2].cbc_TaxableAmount._CurrencyID.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

        if(field.cac_TaxSubtotals[iterator_2].cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_5 = field.cac_TaxSubtotals[iterator_2].cbc_TaxAmount._CurrencyID.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

            {
            targetPtr += 1;

        if(field.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeID!= null)
        {
            int strlen_6 = field.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeID.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( field.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
            {

        if(field.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_6 = field.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeAgencyID.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

        if(field.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID.code!= null)
        {
            int strlen_6 = field.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID.code.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }            targetPtr += 8;

            {

            {
            targetPtr += 1;

        if(field.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID!= null)
        {
            int strlen_7 = field.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID.Length * 2;
            targetPtr += strlen_7+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( field.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
            {

        if(field.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_7 = field.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID.Length * 2;
            targetPtr += strlen_7+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

        if(field.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID.code!= null)
        {
            int strlen_7 = field.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID.code.Length * 2;
            targetPtr += strlen_7+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
            }
            }
        }
    }

}

            }
            byte* tmpcellptr = BufferAllocator.AllocBuffer((int)targetPtr);
            Memory.memset(tmpcellptr, 0, (ulong)targetPtr);
            targetPtr = tmpcellptr;
            
            {

            {

        if(field.cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_3 = field.cbc_TaxAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.cbc_TaxAmount._CurrencyID)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.cbc_TaxAmount.amount;
            targetPtr += 8;

            }
{
byte *storedPtr_2 = targetPtr;

    targetPtr += sizeof(int);
    if(field.cac_TaxSubtotals!= null)
    {
        for(int iterator_2 = 0;iterator_2<field.cac_TaxSubtotals.Count;++iterator_2)
        {

            {

            {

        if(field.cac_TaxSubtotals[iterator_2].cbc_TaxableAmount._CurrencyID!= null)
        {
            int strlen_5 = field.cac_TaxSubtotals[iterator_2].cbc_TaxableAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.cac_TaxSubtotals[iterator_2].cbc_TaxableAmount._CurrencyID)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.cac_TaxSubtotals[iterator_2].cbc_TaxableAmount.amount;
            targetPtr += 8;

            }
            {

        if(field.cac_TaxSubtotals[iterator_2].cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_5 = field.cac_TaxSubtotals[iterator_2].cbc_TaxAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.cac_TaxSubtotals[iterator_2].cbc_TaxAmount._CurrencyID)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.cac_TaxSubtotals[iterator_2].cbc_TaxAmount.amount;
            targetPtr += 8;

            }
            {

            {
            byte* optheader_5 = targetPtr;
            *(optheader_5 + 0) = 0x00;            targetPtr += 1;

        if(field.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeID!= null)
        {
            int strlen_6 = field.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeID.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = field.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeID)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( field.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
            {

        if(field.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_6 = field.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeAgencyID.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = field.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeAgencyID)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_5 + 0) |= 0x01;
            }

        if(field.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID.code!= null)
        {
            int strlen_6 = field.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID.code.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = field.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID.code)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }            *(double*)targetPtr = field.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_Percent;
            targetPtr += 8;

            {

            {
            byte* optheader_6 = targetPtr;
            *(optheader_6 + 0) = 0x00;            targetPtr += 1;

        if(field.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID!= null)
        {
            int strlen_7 = field.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID.Length * 2;
            *(int*)targetPtr = strlen_7;
            targetPtr += sizeof(int);
            fixed(char* pstr_7 = field.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID)
            {
                Memory.Copy(pstr_7, targetPtr, strlen_7);
                targetPtr += strlen_7;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( field.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
            {

        if(field.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_7 = field.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID.Length * 2;
            *(int*)targetPtr = strlen_7;
            targetPtr += sizeof(int);
            fixed(char* pstr_7 = field.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID)
            {
                Memory.Copy(pstr_7, targetPtr, strlen_7);
                targetPtr += strlen_7;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_6 + 0) |= 0x01;
            }

        if(field.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID.code!= null)
        {
            int strlen_7 = field.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID.code.Length * 2;
            *(int*)targetPtr = strlen_7;
            targetPtr += sizeof(int);
            fixed(char* pstr_7 = field.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID.code)
            {
                Memory.Copy(pstr_7, targetPtr, strlen_7);
                targetPtr += strlen_7;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
            }
            }
            }
        }
    }
*(int*)storedPtr_2 = (int)(targetPtr - storedPtr_2 - 4);

}

            }Cac_TaxTotal_Accessor ret;
            
            ret = new Cac_TaxTotal_Accessor(tmpcellptr, null);
            
            return ret;
        }
        
        public static bool operator ==(Cac_TaxTotal_Accessor a, Cac_TaxTotal_Accessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            byte* targetPtr = a.m_ptr;
            {{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);}
            int lengthA = (int)(targetPtr - a.m_ptr);
            targetPtr = b.m_ptr;
            {{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);}
            int lengthB = (int)(targetPtr - b.m_ptr);
            if(lengthA != lengthB) return false;
            return Memory.Compare(a.m_ptr,b.m_ptr,lengthA);
        }
        public static bool operator != (Cac_TaxTotal_Accessor a, Cac_TaxTotal_Accessor b)
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
