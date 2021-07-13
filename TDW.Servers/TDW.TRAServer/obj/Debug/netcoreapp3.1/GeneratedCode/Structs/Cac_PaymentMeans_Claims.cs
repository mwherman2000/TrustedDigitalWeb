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
    /// A .NET runtime object representation of Cac_PaymentMeans_Claims defined in TSL.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct Cac_PaymentMeans_Claims
    {
        
        ///<summary>
        ///Initializes a new instance of Cac_PaymentMeans_Claims with the specified parameters.
        ///</summary>
        public Cac_PaymentMeans_Claims(Cbc_ListCode cbc_PaymentMeansCode = default(Cbc_ListCode),DateTime cbc_PaymentDueDate = default(DateTime),string cbc_PaymentChannel = default(string),string cbc_PaymentID = default(string),string cac_PayeeFinancialAccountUdid = default(string))
        {
            
            this.cbc_PaymentMeansCode = cbc_PaymentMeansCode;
            
            this.cbc_PaymentDueDate = cbc_PaymentDueDate;
            
            this.cbc_PaymentChannel = cbc_PaymentChannel;
            
            this.cbc_PaymentID = cbc_PaymentID;
            
            this.cac_PayeeFinancialAccountUdid = cac_PayeeFinancialAccountUdid;
            
        }
        
        public static bool operator ==(Cac_PaymentMeans_Claims a, Cac_PaymentMeans_Claims b)
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
                
                (a.cbc_PaymentMeansCode == b.cbc_PaymentMeansCode)
                &&
                (a.cbc_PaymentDueDate == b.cbc_PaymentDueDate)
                &&
                (a.cbc_PaymentChannel == b.cbc_PaymentChannel)
                &&
                (a.cbc_PaymentID == b.cbc_PaymentID)
                &&
                (a.cac_PayeeFinancialAccountUdid == b.cac_PayeeFinancialAccountUdid)
                
                ;
            
        }
        public static bool operator !=(Cac_PaymentMeans_Claims a, Cac_PaymentMeans_Claims b)
        {
            return !(a == b);
        }
        
        public Cbc_ListCode cbc_PaymentMeansCode;
        
        public DateTime cbc_PaymentDueDate;
        
        public string cbc_PaymentChannel;
        
        public string cbc_PaymentID;
        
        public string cac_PayeeFinancialAccountUdid;
        
        /// <summary>
        /// Converts the string representation of a Cac_PaymentMeans_Claims to its
        /// struct equivalent. A return value indicates whether the 
        /// operation succeeded.
        /// </summary>
        /// <param name="input">A string to convert.</param>
        /// <param name="value">
        /// When this method returns, contains the struct equivalent of the value contained 
        /// in input, if the conversion succeeded, or default(Cac_PaymentMeans_Claims) if the conversion
        /// failed. The conversion fails if the input parameter is null or String.Empty, or is 
        /// not of the correct format. This parameter is passed uninitialized. 
        /// </param>
        /// <returns>True if input was converted successfully; otherwise, false.</returns>
        public unsafe static bool TryParse(string input, out Cac_PaymentMeans_Claims value)
        {
            try
            {
                value = Newtonsoft.Json.JsonConvert.DeserializeObject<Cac_PaymentMeans_Claims>(input);
                return true;
            }
            catch { value = default(Cac_PaymentMeans_Claims); return false; }
        }
        public static Cac_PaymentMeans_Claims Parse(string input)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Cac_PaymentMeans_Claims>(input);
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
    /// Provides in-place operations of Cac_PaymentMeans_Claims defined in TSL.
    /// </summary>
    public unsafe partial class Cac_PaymentMeans_Claims_Accessor : IAccessor
    {
        ///<summary>
        ///The pointer to the content of the object.
        ///</summary>
        internal byte* m_ptr;
        internal long m_cellId;
        internal unsafe Cac_PaymentMeans_Claims_Accessor(byte* _CellPtr
            
            , ResizeFunctionDelegate func
            )
        {
            m_ptr = _CellPtr;
            
            ResizeFunction = func;
                    cbc_PaymentMeansCode_Accessor_Field = new Cbc_ListCode_Accessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        cbc_PaymentDueDate_Accessor_Field = new DateTimeAccessor(null);        cbc_PaymentChannel_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        cbc_PaymentID_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        cac_PayeeFinancialAccountUdid_Accessor_Field = new StringAccessor(null,
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
            {{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
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
            {{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            int size = (int)(targetPtr - m_ptr);
            return size;
        }
        public ResizeFunctionDelegate ResizeFunction { get; set; }
        #endregion
        Cbc_ListCode_Accessor cbc_PaymentMeansCode_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cbc_PaymentMeansCode.
        ///</summary>
        public unsafe Cbc_ListCode_Accessor cbc_PaymentMeansCode
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {}cbc_PaymentMeansCode_Accessor_Field.m_ptr = targetPtr;
                cbc_PaymentMeansCode_Accessor_Field.m_cellId = this.m_cellId;
                return cbc_PaymentMeansCode_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cbc_PaymentMeansCode_Accessor_Field.m_cellId = this.m_cellId;
                
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
        DateTimeAccessor cbc_PaymentDueDate_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cbc_PaymentDueDate.
        ///</summary>
        public unsafe DateTimeAccessor cbc_PaymentDueDate
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}}cbc_PaymentDueDate_Accessor_Field.m_ptr = targetPtr;
                cbc_PaymentDueDate_Accessor_Field.m_cellId = this.m_cellId;
                return cbc_PaymentDueDate_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cbc_PaymentDueDate_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}}                Memory.Copy(value.m_ptr, targetPtr, 8); 
            }
        }
        StringAccessor cbc_PaymentChannel_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cbc_PaymentChannel.
        ///</summary>
        public unsafe StringAccessor cbc_PaymentChannel
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
}cbc_PaymentChannel_Accessor_Field.m_ptr = targetPtr + 4;
                cbc_PaymentChannel_Accessor_Field.m_cellId = this.m_cellId;
                return cbc_PaymentChannel_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cbc_PaymentChannel_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != cbc_PaymentChannel_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    cbc_PaymentChannel_Accessor_Field.m_ptr = cbc_PaymentChannel_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, cbc_PaymentChannel_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        cbc_PaymentChannel_Accessor_Field.m_ptr = cbc_PaymentChannel_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, cbc_PaymentChannel_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        StringAccessor cbc_PaymentID_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cbc_PaymentID.
        ///</summary>
        public unsafe StringAccessor cbc_PaymentID
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);}cbc_PaymentID_Accessor_Field.m_ptr = targetPtr + 4;
                cbc_PaymentID_Accessor_Field.m_cellId = this.m_cellId;
                return cbc_PaymentID_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cbc_PaymentID_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != cbc_PaymentID_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    cbc_PaymentID_Accessor_Field.m_ptr = cbc_PaymentID_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, cbc_PaymentID_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        cbc_PaymentID_Accessor_Field.m_ptr = cbc_PaymentID_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, cbc_PaymentID_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        StringAccessor cac_PayeeFinancialAccountUdid_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cac_PayeeFinancialAccountUdid.
        ///</summary>
        public unsafe StringAccessor cac_PayeeFinancialAccountUdid
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}cac_PayeeFinancialAccountUdid_Accessor_Field.m_ptr = targetPtr + 4;
                cac_PayeeFinancialAccountUdid_Accessor_Field.m_cellId = this.m_cellId;
                return cac_PayeeFinancialAccountUdid_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cac_PayeeFinancialAccountUdid_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != cac_PayeeFinancialAccountUdid_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    cac_PayeeFinancialAccountUdid_Accessor_Field.m_ptr = cac_PayeeFinancialAccountUdid_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, cac_PayeeFinancialAccountUdid_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        cac_PayeeFinancialAccountUdid_Accessor_Field.m_ptr = cac_PayeeFinancialAccountUdid_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, cac_PayeeFinancialAccountUdid_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        
        public static unsafe implicit operator Cac_PaymentMeans_Claims(Cac_PaymentMeans_Claims_Accessor accessor)
        {
            
            return new Cac_PaymentMeans_Claims(
                
                        accessor.cbc_PaymentMeansCode,
                        accessor.cbc_PaymentDueDate,
                        accessor.cbc_PaymentChannel,
                        accessor.cbc_PaymentID,
                        accessor.cac_PayeeFinancialAccountUdid
                );
        }
        
        public unsafe static implicit operator Cac_PaymentMeans_Claims_Accessor(Cac_PaymentMeans_Claims field)
        {
            byte* targetPtr = null;
            
            {

            {

        if(field.cbc_PaymentMeansCode._listID!= null)
        {
            int strlen_3 = field.cbc_PaymentMeansCode._listID.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.cbc_PaymentMeansCode._listAgencyID!= null)
        {
            int strlen_3 = field.cbc_PaymentMeansCode._listAgencyID.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.cbc_PaymentMeansCode.code!= null)
        {
            int strlen_3 = field.cbc_PaymentMeansCode.code.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }targetPtr += 8;
        if(field.cbc_PaymentChannel!= null)
        {
            int strlen_2 = field.cbc_PaymentChannel.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.cbc_PaymentID!= null)
        {
            int strlen_2 = field.cbc_PaymentID.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.cac_PayeeFinancialAccountUdid!= null)
        {
            int strlen_2 = field.cac_PayeeFinancialAccountUdid.Length * 2;
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

            {

        if(field.cbc_PaymentMeansCode._listID!= null)
        {
            int strlen_3 = field.cbc_PaymentMeansCode._listID.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.cbc_PaymentMeansCode._listID)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.cbc_PaymentMeansCode._listAgencyID!= null)
        {
            int strlen_3 = field.cbc_PaymentMeansCode._listAgencyID.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.cbc_PaymentMeansCode._listAgencyID)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.cbc_PaymentMeansCode.code!= null)
        {
            int strlen_3 = field.cbc_PaymentMeansCode.code.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.cbc_PaymentMeansCode.code)
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
        {
            *(long*)targetPtr = field.cbc_PaymentDueDate.ToBinary();
            targetPtr += 8;
        }

        if(field.cbc_PaymentChannel!= null)
        {
            int strlen_2 = field.cbc_PaymentChannel.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.cbc_PaymentChannel)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.cbc_PaymentID!= null)
        {
            int strlen_2 = field.cbc_PaymentID.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.cbc_PaymentID)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.cac_PayeeFinancialAccountUdid!= null)
        {
            int strlen_2 = field.cac_PayeeFinancialAccountUdid.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.cac_PayeeFinancialAccountUdid)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }Cac_PaymentMeans_Claims_Accessor ret;
            
            ret = new Cac_PaymentMeans_Claims_Accessor(tmpcellptr, null);
            
            return ret;
        }
        
        public static bool operator ==(Cac_PaymentMeans_Claims_Accessor a, Cac_PaymentMeans_Claims_Accessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            byte* targetPtr = a.m_ptr;
            {{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            int lengthA = (int)(targetPtr - a.m_ptr);
            targetPtr = b.m_ptr;
            {{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            int lengthB = (int)(targetPtr - b.m_ptr);
            if(lengthA != lengthB) return false;
            return Memory.Compare(a.m_ptr,b.m_ptr,lengthA);
        }
        public static bool operator != (Cac_PaymentMeans_Claims_Accessor a, Cac_PaymentMeans_Claims_Accessor b)
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
