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
    /// A .NET runtime object representation of TRAPostalAddressClaims defined in TSL.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct TRAPostalAddressClaims
    {
        
        ///<summary>
        ///Initializes a new instance of TRAPostalAddressClaims with the specified parameters.
        ///</summary>
        public TRAPostalAddressClaims(string streetAddress = default(string),string postOfficeBoxNumber = default(string),string addressLocality = default(string),string addressRegion = default(string),string addressCountry = default(string),string postalCode = default(string))
        {
            
            this.streetAddress = streetAddress;
            
            this.postOfficeBoxNumber = postOfficeBoxNumber;
            
            this.addressLocality = addressLocality;
            
            this.addressRegion = addressRegion;
            
            this.addressCountry = addressCountry;
            
            this.postalCode = postalCode;
            
        }
        
        public static bool operator ==(TRAPostalAddressClaims a, TRAPostalAddressClaims b)
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
                
                (a.streetAddress == b.streetAddress)
                &&
                (a.postOfficeBoxNumber == b.postOfficeBoxNumber)
                &&
                (a.addressLocality == b.addressLocality)
                &&
                (a.addressRegion == b.addressRegion)
                &&
                (a.addressCountry == b.addressCountry)
                &&
                (a.postalCode == b.postalCode)
                
                ;
            
        }
        public static bool operator !=(TRAPostalAddressClaims a, TRAPostalAddressClaims b)
        {
            return !(a == b);
        }
        
        public string streetAddress;
        
        public string postOfficeBoxNumber;
        
        public string addressLocality;
        
        public string addressRegion;
        
        public string addressCountry;
        
        public string postalCode;
        
        /// <summary>
        /// Converts the string representation of a TRAPostalAddressClaims to its
        /// struct equivalent. A return value indicates whether the 
        /// operation succeeded.
        /// </summary>
        /// <param name="input">A string to convert.</param>
        /// <param name="value">
        /// When this method returns, contains the struct equivalent of the value contained 
        /// in input, if the conversion succeeded, or default(TRAPostalAddressClaims) if the conversion
        /// failed. The conversion fails if the input parameter is null or String.Empty, or is 
        /// not of the correct format. This parameter is passed uninitialized. 
        /// </param>
        /// <returns>True if input was converted successfully; otherwise, false.</returns>
        public unsafe static bool TryParse(string input, out TRAPostalAddressClaims value)
        {
            try
            {
                value = Newtonsoft.Json.JsonConvert.DeserializeObject<TRAPostalAddressClaims>(input);
                return true;
            }
            catch { value = default(TRAPostalAddressClaims); return false; }
        }
        public static TRAPostalAddressClaims Parse(string input)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TRAPostalAddressClaims>(input);
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
    /// Provides in-place operations of TRAPostalAddressClaims defined in TSL.
    /// </summary>
    public unsafe partial class TRAPostalAddressClaims_Accessor : IAccessor
    {
        ///<summary>
        ///The pointer to the content of the object.
        ///</summary>
        internal byte* m_ptr;
        internal long m_cellId;
        internal unsafe TRAPostalAddressClaims_Accessor(byte* _CellPtr
            
            , ResizeFunctionDelegate func
            )
        {
            m_ptr = _CellPtr;
            
            ResizeFunction = func;
                    streetAddress_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        postOfficeBoxNumber_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        addressLocality_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        addressRegion_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        addressCountry_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        postalCode_Accessor_Field = new StringAccessor(null,
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
            {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
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
            {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            int size = (int)(targetPtr - m_ptr);
            return size;
        }
        public ResizeFunctionDelegate ResizeFunction { get; set; }
        #endregion
        StringAccessor streetAddress_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field streetAddress.
        ///</summary>
        public unsafe StringAccessor streetAddress
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {}streetAddress_Accessor_Field.m_ptr = targetPtr + 4;
                streetAddress_Accessor_Field.m_cellId = this.m_cellId;
                return streetAddress_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                streetAddress_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != streetAddress_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    streetAddress_Accessor_Field.m_ptr = streetAddress_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, streetAddress_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        streetAddress_Accessor_Field.m_ptr = streetAddress_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, streetAddress_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        StringAccessor postOfficeBoxNumber_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field postOfficeBoxNumber.
        ///</summary>
        public unsafe StringAccessor postOfficeBoxNumber
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);}postOfficeBoxNumber_Accessor_Field.m_ptr = targetPtr + 4;
                postOfficeBoxNumber_Accessor_Field.m_cellId = this.m_cellId;
                return postOfficeBoxNumber_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                postOfficeBoxNumber_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != postOfficeBoxNumber_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    postOfficeBoxNumber_Accessor_Field.m_ptr = postOfficeBoxNumber_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, postOfficeBoxNumber_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        postOfficeBoxNumber_Accessor_Field.m_ptr = postOfficeBoxNumber_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, postOfficeBoxNumber_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        StringAccessor addressLocality_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field addressLocality.
        ///</summary>
        public unsafe StringAccessor addressLocality
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}addressLocality_Accessor_Field.m_ptr = targetPtr + 4;
                addressLocality_Accessor_Field.m_cellId = this.m_cellId;
                return addressLocality_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                addressLocality_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != addressLocality_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    addressLocality_Accessor_Field.m_ptr = addressLocality_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, addressLocality_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        addressLocality_Accessor_Field.m_ptr = addressLocality_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, addressLocality_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        StringAccessor addressRegion_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field addressRegion.
        ///</summary>
        public unsafe StringAccessor addressRegion
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}addressRegion_Accessor_Field.m_ptr = targetPtr + 4;
                addressRegion_Accessor_Field.m_cellId = this.m_cellId;
                return addressRegion_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                addressRegion_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != addressRegion_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    addressRegion_Accessor_Field.m_ptr = addressRegion_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, addressRegion_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        addressRegion_Accessor_Field.m_ptr = addressRegion_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, addressRegion_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        StringAccessor addressCountry_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field addressCountry.
        ///</summary>
        public unsafe StringAccessor addressCountry
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}addressCountry_Accessor_Field.m_ptr = targetPtr + 4;
                addressCountry_Accessor_Field.m_cellId = this.m_cellId;
                return addressCountry_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                addressCountry_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != addressCountry_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    addressCountry_Accessor_Field.m_ptr = addressCountry_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, addressCountry_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        addressCountry_Accessor_Field.m_ptr = addressCountry_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, addressCountry_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        StringAccessor postalCode_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field postalCode.
        ///</summary>
        public unsafe StringAccessor postalCode
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}postalCode_Accessor_Field.m_ptr = targetPtr + 4;
                postalCode_Accessor_Field.m_cellId = this.m_cellId;
                return postalCode_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                postalCode_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != postalCode_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    postalCode_Accessor_Field.m_ptr = postalCode_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, postalCode_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        postalCode_Accessor_Field.m_ptr = postalCode_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, postalCode_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        
        public static unsafe implicit operator TRAPostalAddressClaims(TRAPostalAddressClaims_Accessor accessor)
        {
            
            return new TRAPostalAddressClaims(
                
                        accessor.streetAddress,
                        accessor.postOfficeBoxNumber,
                        accessor.addressLocality,
                        accessor.addressRegion,
                        accessor.addressCountry,
                        accessor.postalCode
                );
        }
        
        public unsafe static implicit operator TRAPostalAddressClaims_Accessor(TRAPostalAddressClaims field)
        {
            byte* targetPtr = null;
            
            {

        if(field.streetAddress!= null)
        {
            int strlen_2 = field.streetAddress.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.postOfficeBoxNumber!= null)
        {
            int strlen_2 = field.postOfficeBoxNumber.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.addressLocality!= null)
        {
            int strlen_2 = field.addressLocality.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.addressRegion!= null)
        {
            int strlen_2 = field.addressRegion.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.addressCountry!= null)
        {
            int strlen_2 = field.addressCountry.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.postalCode!= null)
        {
            int strlen_2 = field.postalCode.Length * 2;
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

        if(field.streetAddress!= null)
        {
            int strlen_2 = field.streetAddress.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.streetAddress)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.postOfficeBoxNumber!= null)
        {
            int strlen_2 = field.postOfficeBoxNumber.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.postOfficeBoxNumber)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.addressLocality!= null)
        {
            int strlen_2 = field.addressLocality.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.addressLocality)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.addressRegion!= null)
        {
            int strlen_2 = field.addressRegion.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.addressRegion)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.addressCountry!= null)
        {
            int strlen_2 = field.addressCountry.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.addressCountry)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.postalCode!= null)
        {
            int strlen_2 = field.postalCode.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.postalCode)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }TRAPostalAddressClaims_Accessor ret;
            
            ret = new TRAPostalAddressClaims_Accessor(tmpcellptr, null);
            
            return ret;
        }
        
        public static bool operator ==(TRAPostalAddressClaims_Accessor a, TRAPostalAddressClaims_Accessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            byte* targetPtr = a.m_ptr;
            {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            int lengthA = (int)(targetPtr - a.m_ptr);
            targetPtr = b.m_ptr;
            {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            int lengthB = (int)(targetPtr - b.m_ptr);
            if(lengthA != lengthB) return false;
            return Memory.Compare(a.m_ptr,b.m_ptr,lengthA);
        }
        public static bool operator != (TRAPostalAddressClaims_Accessor a, TRAPostalAddressClaims_Accessor b)
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
