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
    /// A .NET runtime object representation of Cac_PartyTaxScheme defined in TSL.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct Cac_PartyTaxScheme
    {
        
        ///<summary>
        ///Initializes a new instance of Cac_PartyTaxScheme with the specified parameters.
        ///</summary>
        public Cac_PartyTaxScheme(Cbc_SchemeCode cbc_CompanyID = default(Cbc_SchemeCode),Cac_TaxScheme cac_TaxScheme = default(Cac_TaxScheme))
        {
            
            this.cbc_CompanyID = cbc_CompanyID;
            
            this.cac_TaxScheme = cac_TaxScheme;
            
        }
        
        public static bool operator ==(Cac_PartyTaxScheme a, Cac_PartyTaxScheme b)
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
                
                (a.cbc_CompanyID == b.cbc_CompanyID)
                &&
                (a.cac_TaxScheme == b.cac_TaxScheme)
                
                ;
            
        }
        public static bool operator !=(Cac_PartyTaxScheme a, Cac_PartyTaxScheme b)
        {
            return !(a == b);
        }
        
        public Cbc_SchemeCode cbc_CompanyID;
        
        public Cac_TaxScheme cac_TaxScheme;
        
        /// <summary>
        /// Converts the string representation of a Cac_PartyTaxScheme to its
        /// struct equivalent. A return value indicates whether the 
        /// operation succeeded.
        /// </summary>
        /// <param name="input">A string to convert.</param>
        /// <param name="value">
        /// When this method returns, contains the struct equivalent of the value contained 
        /// in input, if the conversion succeeded, or default(Cac_PartyTaxScheme) if the conversion
        /// failed. The conversion fails if the input parameter is null or String.Empty, or is 
        /// not of the correct format. This parameter is passed uninitialized. 
        /// </param>
        /// <returns>True if input was converted successfully; otherwise, false.</returns>
        public unsafe static bool TryParse(string input, out Cac_PartyTaxScheme value)
        {
            try
            {
                value = Newtonsoft.Json.JsonConvert.DeserializeObject<Cac_PartyTaxScheme>(input);
                return true;
            }
            catch { value = default(Cac_PartyTaxScheme); return false; }
        }
        public static Cac_PartyTaxScheme Parse(string input)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Cac_PartyTaxScheme>(input);
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
    /// Provides in-place operations of Cac_PartyTaxScheme defined in TSL.
    /// </summary>
    public unsafe partial class Cac_PartyTaxScheme_Accessor : IAccessor
    {
        ///<summary>
        ///The pointer to the content of the object.
        ///</summary>
        internal byte* m_ptr;
        internal long m_cellId;
        internal unsafe Cac_PartyTaxScheme_Accessor(byte* _CellPtr
            
            , ResizeFunctionDelegate func
            )
        {
            m_ptr = _CellPtr;
            
            ResizeFunction = func;
                    cbc_CompanyID_Accessor_Field = new Cbc_SchemeCode_Accessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        cac_TaxScheme_Accessor_Field = new Cac_TaxScheme_Accessor(null,
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
            {{            byte* optheader_2 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_2 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}{{            byte* optheader_4 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_4 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}}}
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
            {{            byte* optheader_2 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_2 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}{{            byte* optheader_4 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_4 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}}}
            int size = (int)(targetPtr - m_ptr);
            return size;
        }
        public ResizeFunctionDelegate ResizeFunction { get; set; }
        #endregion
        Cbc_SchemeCode_Accessor cbc_CompanyID_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cbc_CompanyID.
        ///</summary>
        public unsafe Cbc_SchemeCode_Accessor cbc_CompanyID
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {}cbc_CompanyID_Accessor_Field.m_ptr = targetPtr;
                cbc_CompanyID_Accessor_Field.m_cellId = this.m_cellId;
                return cbc_CompanyID_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cbc_CompanyID_Accessor_Field.m_cellId = this.m_cellId;
                
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
        Cac_TaxScheme_Accessor cac_TaxScheme_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cac_TaxScheme.
        ///</summary>
        public unsafe Cac_TaxScheme_Accessor cac_TaxScheme
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {{            byte* optheader_3 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_3 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}}cac_TaxScheme_Accessor_Field.m_ptr = targetPtr;
                cac_TaxScheme_Accessor_Field.m_cellId = this.m_cellId;
                return cac_TaxScheme_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cac_TaxScheme_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {{            byte* optheader_3 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_3 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}}
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
        
        public static unsafe implicit operator Cac_PartyTaxScheme(Cac_PartyTaxScheme_Accessor accessor)
        {
            
            return new Cac_PartyTaxScheme(
                
                        accessor.cbc_CompanyID,
                        accessor.cac_TaxScheme
                );
        }
        
        public unsafe static implicit operator Cac_PartyTaxScheme_Accessor(Cac_PartyTaxScheme field)
        {
            byte* targetPtr = null;
            
            {

            {
            targetPtr += 1;

        if(field.cbc_CompanyID._schemeID!= null)
        {
            int strlen_3 = field.cbc_CompanyID._schemeID.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( field.cbc_CompanyID._schemeAgencyID!= null)
            {

        if(field.cbc_CompanyID._schemeAgencyID!= null)
        {
            int strlen_3 = field.cbc_CompanyID._schemeAgencyID.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

        if(field.cbc_CompanyID.code!= null)
        {
            int strlen_3 = field.cbc_CompanyID.code.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            {

            {
            targetPtr += 1;

        if(field.cac_TaxScheme.cbc_ID._schemeID!= null)
        {
            int strlen_4 = field.cac_TaxScheme.cbc_ID._schemeID.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( field.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
            {

        if(field.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_4 = field.cac_TaxScheme.cbc_ID._schemeAgencyID.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

        if(field.cac_TaxScheme.cbc_ID.code!= null)
        {
            int strlen_4 = field.cac_TaxScheme.cbc_ID.code.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
            }
            byte* tmpcellptr = BufferAllocator.AllocBuffer((int)targetPtr);
            Memory.memset(tmpcellptr, 0, (ulong)targetPtr);
            targetPtr = tmpcellptr;
            
            {

            {
            byte* optheader_2 = targetPtr;
            *(optheader_2 + 0) = 0x00;            targetPtr += 1;

        if(field.cbc_CompanyID._schemeID!= null)
        {
            int strlen_3 = field.cbc_CompanyID._schemeID.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.cbc_CompanyID._schemeID)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( field.cbc_CompanyID._schemeAgencyID!= null)
            {

        if(field.cbc_CompanyID._schemeAgencyID!= null)
        {
            int strlen_3 = field.cbc_CompanyID._schemeAgencyID.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.cbc_CompanyID._schemeAgencyID)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_2 + 0) |= 0x01;
            }

        if(field.cbc_CompanyID.code!= null)
        {
            int strlen_3 = field.cbc_CompanyID.code.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.cbc_CompanyID.code)
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

            {
            byte* optheader_3 = targetPtr;
            *(optheader_3 + 0) = 0x00;            targetPtr += 1;

        if(field.cac_TaxScheme.cbc_ID._schemeID!= null)
        {
            int strlen_4 = field.cac_TaxScheme.cbc_ID._schemeID.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.cac_TaxScheme.cbc_ID._schemeID)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( field.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
            {

        if(field.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_4 = field.cac_TaxScheme.cbc_ID._schemeAgencyID.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.cac_TaxScheme.cbc_ID._schemeAgencyID)
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

        if(field.cac_TaxScheme.cbc_ID.code!= null)
        {
            int strlen_4 = field.cac_TaxScheme.cbc_ID.code.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.cac_TaxScheme.cbc_ID.code)
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
            }
            }Cac_PartyTaxScheme_Accessor ret;
            
            ret = new Cac_PartyTaxScheme_Accessor(tmpcellptr, null);
            
            return ret;
        }
        
        public static bool operator ==(Cac_PartyTaxScheme_Accessor a, Cac_PartyTaxScheme_Accessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            byte* targetPtr = a.m_ptr;
            {{            byte* optheader_3 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_3 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}{{            byte* optheader_5 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_5 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}}}
            int lengthA = (int)(targetPtr - a.m_ptr);
            targetPtr = b.m_ptr;
            {{            byte* optheader_3 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_3 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}{{            byte* optheader_5 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_5 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}}}
            int lengthB = (int)(targetPtr - b.m_ptr);
            if(lengthA != lengthB) return false;
            return Memory.Compare(a.m_ptr,b.m_ptr,lengthA);
        }
        public static bool operator != (Cac_PartyTaxScheme_Accessor a, Cac_PartyTaxScheme_Accessor b)
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
