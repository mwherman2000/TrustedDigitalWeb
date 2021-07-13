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
    /// A .NET runtime object representation of Cac_Delivery defined in TSL.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct Cac_Delivery
    {
        
        ///<summary>
        ///Initializes a new instance of Cac_Delivery with the specified parameters.
        ///</summary>
        public Cac_Delivery(DateTime cbc_ActualDeliveryDate = default(DateTime),Cac_DeliveryLocation cac_DeliveryLocation = default(Cac_DeliveryLocation))
        {
            
            this.cbc_ActualDeliveryDate = cbc_ActualDeliveryDate;
            
            this.cac_DeliveryLocation = cac_DeliveryLocation;
            
        }
        
        public static bool operator ==(Cac_Delivery a, Cac_Delivery b)
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
                
                (a.cbc_ActualDeliveryDate == b.cbc_ActualDeliveryDate)
                &&
                (a.cac_DeliveryLocation == b.cac_DeliveryLocation)
                
                ;
            
        }
        public static bool operator !=(Cac_Delivery a, Cac_Delivery b)
        {
            return !(a == b);
        }
        
        public DateTime cbc_ActualDeliveryDate;
        
        public Cac_DeliveryLocation cac_DeliveryLocation;
        
        /// <summary>
        /// Converts the string representation of a Cac_Delivery to its
        /// struct equivalent. A return value indicates whether the 
        /// operation succeeded.
        /// </summary>
        /// <param name="input">A string to convert.</param>
        /// <param name="value">
        /// When this method returns, contains the struct equivalent of the value contained 
        /// in input, if the conversion succeeded, or default(Cac_Delivery) if the conversion
        /// failed. The conversion fails if the input parameter is null or String.Empty, or is 
        /// not of the correct format. This parameter is passed uninitialized. 
        /// </param>
        /// <returns>True if input was converted successfully; otherwise, false.</returns>
        public unsafe static bool TryParse(string input, out Cac_Delivery value)
        {
            try
            {
                value = Newtonsoft.Json.JsonConvert.DeserializeObject<Cac_Delivery>(input);
                return true;
            }
            catch { value = default(Cac_Delivery); return false; }
        }
        public static Cac_Delivery Parse(string input)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Cac_Delivery>(input);
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
    /// Provides in-place operations of Cac_Delivery defined in TSL.
    /// </summary>
    public unsafe partial class Cac_Delivery_Accessor : IAccessor
    {
        ///<summary>
        ///The pointer to the content of the object.
        ///</summary>
        internal byte* m_ptr;
        internal long m_cellId;
        internal unsafe Cac_Delivery_Accessor(byte* _CellPtr
            
            , ResizeFunctionDelegate func
            )
        {
            m_ptr = _CellPtr;
            
            ResizeFunction = func;
                    cbc_ActualDeliveryDate_Accessor_Field = new DateTimeAccessor(null);        cac_DeliveryLocation_Accessor_Field = new Cac_DeliveryLocation_Accessor(null,
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
{{            byte* optheader_4 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_4 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);}}
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
{{            byte* optheader_4 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_4 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);}}
            int size = (int)(targetPtr - m_ptr);
            return size;
        }
        public ResizeFunctionDelegate ResizeFunction { get; set; }
        #endregion
        DateTimeAccessor cbc_ActualDeliveryDate_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cbc_ActualDeliveryDate.
        ///</summary>
        public unsafe DateTimeAccessor cbc_ActualDeliveryDate
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {}cbc_ActualDeliveryDate_Accessor_Field.m_ptr = targetPtr;
                cbc_ActualDeliveryDate_Accessor_Field.m_cellId = this.m_cellId;
                return cbc_ActualDeliveryDate_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cbc_ActualDeliveryDate_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {}                Memory.Copy(value.m_ptr, targetPtr, 8); 
            }
        }
        Cac_DeliveryLocation_Accessor cac_DeliveryLocation_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cac_DeliveryLocation.
        ///</summary>
        public unsafe Cac_DeliveryLocation_Accessor cac_DeliveryLocation
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 8;
}cac_DeliveryLocation_Accessor_Field.m_ptr = targetPtr;
                cac_DeliveryLocation_Accessor_Field.m_cellId = this.m_cellId;
                return cac_DeliveryLocation_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cac_DeliveryLocation_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 8;
}
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
        
        public static unsafe implicit operator Cac_Delivery(Cac_Delivery_Accessor accessor)
        {
            
            return new Cac_Delivery(
                
                        accessor.cbc_ActualDeliveryDate,
                        accessor.cac_DeliveryLocation
                );
        }
        
        public unsafe static implicit operator Cac_Delivery_Accessor(Cac_Delivery field)
        {
            byte* targetPtr = null;
            
            {
targetPtr += 8;
            {

            {
            targetPtr += 1;

        if(field.cac_DeliveryLocation.cbc_ID._schemeID!= null)
        {
            int strlen_4 = field.cac_DeliveryLocation.cbc_ID._schemeID.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( field.cac_DeliveryLocation.cbc_ID._schemeAgencyID!= null)
            {

        if(field.cac_DeliveryLocation.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_4 = field.cac_DeliveryLocation.cbc_ID._schemeAgencyID.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

        if(field.cac_DeliveryLocation.cbc_ID.code!= null)
        {
            int strlen_4 = field.cac_DeliveryLocation.cbc_ID.code.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
        if(field.cac_DeliveryLocation.cac_AddressUdid!= null)
        {
            int strlen_3 = field.cac_DeliveryLocation.cac_AddressUdid.Length * 2;
            targetPtr += strlen_3+sizeof(int);
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

        {
            *(long*)targetPtr = field.cbc_ActualDeliveryDate.ToBinary();
            targetPtr += 8;
        }

            {

            {
            byte* optheader_3 = targetPtr;
            *(optheader_3 + 0) = 0x00;            targetPtr += 1;

        if(field.cac_DeliveryLocation.cbc_ID._schemeID!= null)
        {
            int strlen_4 = field.cac_DeliveryLocation.cbc_ID._schemeID.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.cac_DeliveryLocation.cbc_ID._schemeID)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( field.cac_DeliveryLocation.cbc_ID._schemeAgencyID!= null)
            {

        if(field.cac_DeliveryLocation.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_4 = field.cac_DeliveryLocation.cbc_ID._schemeAgencyID.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.cac_DeliveryLocation.cbc_ID._schemeAgencyID)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_3 + 0) |= 0x01;
            }

        if(field.cac_DeliveryLocation.cbc_ID.code!= null)
        {
            int strlen_4 = field.cac_DeliveryLocation.cbc_ID.code.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.cac_DeliveryLocation.cbc_ID.code)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
        if(field.cac_DeliveryLocation.cac_AddressUdid!= null)
        {
            int strlen_3 = field.cac_DeliveryLocation.cac_AddressUdid.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.cac_DeliveryLocation.cac_AddressUdid)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
            }Cac_Delivery_Accessor ret;
            
            ret = new Cac_Delivery_Accessor(tmpcellptr, null);
            
            return ret;
        }
        
        public static bool operator ==(Cac_Delivery_Accessor a, Cac_Delivery_Accessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            byte* targetPtr = a.m_ptr;
            {            targetPtr += 8;
{{            byte* optheader_5 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_5 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);}}
            int lengthA = (int)(targetPtr - a.m_ptr);
            targetPtr = b.m_ptr;
            {            targetPtr += 8;
{{            byte* optheader_5 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_5 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);}}
            int lengthB = (int)(targetPtr - b.m_ptr);
            if(lengthA != lengthB) return false;
            return Memory.Compare(a.m_ptr,b.m_ptr,lengthA);
        }
        public static bool operator != (Cac_Delivery_Accessor a, Cac_Delivery_Accessor b)
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
