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
    /// A .NET runtime object representation of UBL21_Invoice2_Content defined in TSL.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct UBL21_Invoice2_Content
    {
        
        ///<summary>
        ///Initializes a new instance of UBL21_Invoice2_Content with the specified parameters.
        ///</summary>
        public UBL21_Invoice2_Content(string udid = default(string),List<string> context = default(List<string>),UBL21_Invoice2_Claims? claims = default(UBL21_Invoice2_Claims?),TRAEncryptedClaims? encryptedclaims = default(TRAEncryptedClaims?))
        {
            
            this.udid = udid;
            
            this.context = context;
            
            this.claims = claims;
            
            this.encryptedclaims = encryptedclaims;
            
        }
        
        public static bool operator ==(UBL21_Invoice2_Content a, UBL21_Invoice2_Content b)
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
                
                (a.udid == b.udid)
                &&
                (a.context == b.context)
                &&
                (a.claims == b.claims)
                &&
                (a.encryptedclaims == b.encryptedclaims)
                
                ;
            
        }
        public static bool operator !=(UBL21_Invoice2_Content a, UBL21_Invoice2_Content b)
        {
            return !(a == b);
        }
        
        public string udid;
        
        public List<string> context;
        
        public UBL21_Invoice2_Claims? claims;
        
        public TRAEncryptedClaims? encryptedclaims;
        
        /// <summary>
        /// Converts the string representation of a UBL21_Invoice2_Content to its
        /// struct equivalent. A return value indicates whether the 
        /// operation succeeded.
        /// </summary>
        /// <param name="input">A string to convert.</param>
        /// <param name="value">
        /// When this method returns, contains the struct equivalent of the value contained 
        /// in input, if the conversion succeeded, or default(UBL21_Invoice2_Content) if the conversion
        /// failed. The conversion fails if the input parameter is null or String.Empty, or is 
        /// not of the correct format. This parameter is passed uninitialized. 
        /// </param>
        /// <returns>True if input was converted successfully; otherwise, false.</returns>
        public unsafe static bool TryParse(string input, out UBL21_Invoice2_Content value)
        {
            try
            {
                value = Newtonsoft.Json.JsonConvert.DeserializeObject<UBL21_Invoice2_Content>(input);
                return true;
            }
            catch { value = default(UBL21_Invoice2_Content); return false; }
        }
        public static UBL21_Invoice2_Content Parse(string input)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<UBL21_Invoice2_Content>(input);
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
    /// Provides in-place operations of UBL21_Invoice2_Content defined in TSL.
    /// </summary>
    public unsafe partial class UBL21_Invoice2_Content_Accessor : IAccessor
    {
        ///<summary>
        ///The pointer to the content of the object.
        ///</summary>
        internal byte* m_ptr;
        internal long m_cellId;
        internal unsafe UBL21_Invoice2_Content_Accessor(byte* _CellPtr
            
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
                });        context_Accessor_Field = new StringAccessorListAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        claims_Accessor_Field = new UBL21_Invoice2_Claims_Accessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        encryptedclaims_Accessor_Field = new TRAEncryptedClaims_Accessor(null,
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
                    
                    "claims"
                    ,
                    "encryptedclaims"
                    
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
            
            byte [] bytes = new byte[1];
            Memory.Copy(m_ptr, 0, bytes, 0, 1);
            return bytes;
            
        }
        
        ///<summary>
        ///Copies the struct content into a byte array.
        ///</summary>
        public byte[] ToByteArray()
        {
            byte* targetPtr = m_ptr;
            {            byte* optheader_0 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_0 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
{targetPtr += *(int*)targetPtr + sizeof(int);}{            byte* optheader_4 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_4 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 8;
{{            byte* optheader_8 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_8 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);}}targetPtr += *(int*)targetPtr + sizeof(int);{{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);}{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}targetPtr += *(int*)targetPtr + sizeof(int);}
                }

                if ((0 != (*(optheader_0 + 0) & 0x02)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}
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
            {            byte* optheader_0 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_0 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
{targetPtr += *(int*)targetPtr + sizeof(int);}{            byte* optheader_4 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_4 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 8;
{{            byte* optheader_8 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_8 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);}}targetPtr += *(int*)targetPtr + sizeof(int);{{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);}{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}targetPtr += *(int*)targetPtr + sizeof(int);}
                }

                if ((0 != (*(optheader_0 + 0) & 0x02)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}
            int size = (int)(targetPtr - m_ptr);
            return size;
        }
        public ResizeFunctionDelegate ResizeFunction { get; set; }
        #endregion
        StringAccessor udid_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field udid.
        ///</summary>
        public unsafe StringAccessor udid
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
}udid_Accessor_Field.m_ptr = targetPtr + 4;
                udid_Accessor_Field.m_cellId = this.m_cellId;
                return udid_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                udid_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
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
        StringAccessorListAccessor context_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field context.
        ///</summary>
        public unsafe StringAccessorListAccessor context
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}context_Accessor_Field.m_ptr = targetPtr + 4;
                context_Accessor_Field.m_cellId = this.m_cellId;
                return context_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                context_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != context_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    context_Accessor_Field.m_ptr = context_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, context_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        context_Accessor_Field.m_ptr = context_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, context_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        UBL21_Invoice2_Claims_Accessor claims_Accessor_Field;
        
        ///<summary>
        ///Represents the presence of the optional field claims.
        ///</summary>
        public bool Contains_claims
        {
            get
            {
                unchecked
                {
                    return (0 != (*(this.m_ptr + 0) & 0x01)) ;
                }
            }
            internal set
            {
                unchecked
                {
                    if (value)
                    {
                        *(this.m_ptr + 0) |= 0x01;
                    }
                    else
                    {
                        *(this.m_ptr + 0) &= 0xFE;
                    }
                }
            }
        }
        ///<summary>
        ///Removes the optional field claims from the object being operated.
        ///</summary>
        public unsafe void Remove_claims()
        {
            if (!this.Contains_claims)
            {
                throw new Exception("Optional field claims doesn't exist for current cell.");
            }
            this.Contains_claims = false;
            byte* targetPtr = m_ptr;
            {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            byte* startPtr = targetPtr;
            {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
{targetPtr += *(int*)targetPtr + sizeof(int);}{            byte* optheader_4 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_4 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 8;
{{            byte* optheader_8 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_8 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);}}targetPtr += *(int*)targetPtr + sizeof(int);{{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);}{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}targetPtr += *(int*)targetPtr + sizeof(int);}
            this.ResizeFunction(startPtr, 0, (int)(startPtr - targetPtr));
        }
        
        ///<summary>
        ///Provides in-place access to the object field claims.
        ///</summary>
        public unsafe UBL21_Invoice2_Claims_Accessor claims
        {
            get
            {
                
                if (!this.Contains_claims)
                {
                    throw new Exception("Optional field claims doesn't exist for current cell.");
                }
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}claims_Accessor_Field.m_ptr = targetPtr;
                claims_Accessor_Field.m_cellId = this.m_cellId;
                return claims_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                claims_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                bool creatingOptionalField = (!this.Contains_claims);
                if (creatingOptionalField)
                {
                    this.Contains_claims = true;
                    
                int offset = (int)(targetPtr - m_ptr);
                byte* oldtargetPtr = targetPtr;
                int oldlength = 0;
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
                else
                {
                    
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
        }
        TRAEncryptedClaims_Accessor encryptedclaims_Accessor_Field;
        
        ///<summary>
        ///Represents the presence of the optional field encryptedclaims.
        ///</summary>
        public bool Contains_encryptedclaims
        {
            get
            {
                unchecked
                {
                    return (0 != (*(this.m_ptr + 0) & 0x02)) ;
                }
            }
            internal set
            {
                unchecked
                {
                    if (value)
                    {
                        *(this.m_ptr + 0) |= 0x02;
                    }
                    else
                    {
                        *(this.m_ptr + 0) &= 0xFD;
                    }
                }
            }
        }
        ///<summary>
        ///Removes the optional field encryptedclaims from the object being operated.
        ///</summary>
        public unsafe void Remove_encryptedclaims()
        {
            if (!this.Contains_encryptedclaims)
            {
                throw new Exception("Optional field encryptedclaims doesn't exist for current cell.");
            }
            this.Contains_encryptedclaims = false;
            byte* targetPtr = m_ptr;
            {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
{targetPtr += *(int*)targetPtr + sizeof(int);}{            byte* optheader_5 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_5 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 8;
{{            byte* optheader_9 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_9 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);}}targetPtr += *(int*)targetPtr + sizeof(int);{{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);}{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}
            byte* startPtr = targetPtr;
            {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            this.ResizeFunction(startPtr, 0, (int)(startPtr - targetPtr));
        }
        
        ///<summary>
        ///Provides in-place access to the object field encryptedclaims.
        ///</summary>
        public unsafe TRAEncryptedClaims_Accessor encryptedclaims
        {
            get
            {
                
                if (!this.Contains_encryptedclaims)
                {
                    throw new Exception("Optional field encryptedclaims doesn't exist for current cell.");
                }
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
{targetPtr += *(int*)targetPtr + sizeof(int);}{            byte* optheader_5 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_5 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 8;
{{            byte* optheader_9 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_9 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);}}targetPtr += *(int*)targetPtr + sizeof(int);{{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);}{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}encryptedclaims_Accessor_Field.m_ptr = targetPtr;
                encryptedclaims_Accessor_Field.m_cellId = this.m_cellId;
                return encryptedclaims_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                encryptedclaims_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
{targetPtr += *(int*)targetPtr + sizeof(int);}{            byte* optheader_5 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_5 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 8;
{{            byte* optheader_9 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_9 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);}}targetPtr += *(int*)targetPtr + sizeof(int);{{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);}{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}
                bool creatingOptionalField = (!this.Contains_encryptedclaims);
                if (creatingOptionalField)
                {
                    this.Contains_encryptedclaims = true;
                    
                int offset = (int)(targetPtr - m_ptr);
                byte* oldtargetPtr = targetPtr;
                int oldlength = 0;
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
                else
                {
                    
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
        }
        
        public static unsafe implicit operator UBL21_Invoice2_Content(UBL21_Invoice2_Content_Accessor accessor)
        {
            UBL21_Invoice2_Claims? _claims = default(UBL21_Invoice2_Claims?);
            if (accessor.Contains_claims)
            {
                
                _claims = (UBL21_Invoice2_Claims)accessor.claims;
                
            }
            TRAEncryptedClaims? _encryptedclaims = default(TRAEncryptedClaims?);
            if (accessor.Contains_encryptedclaims)
            {
                
                _encryptedclaims = (TRAEncryptedClaims)accessor.encryptedclaims;
                
            }
            
            return new UBL21_Invoice2_Content(
                
                        accessor.udid,
                        accessor.context,
                        _claims ,
                        _encryptedclaims 
                );
        }
        
        public unsafe static implicit operator UBL21_Invoice2_Content_Accessor(UBL21_Invoice2_Content field)
        {
            byte* targetPtr = null;
            
            {
            targetPtr += 1;

        if(field.udid!= null)
        {
            int strlen_2 = field.udid.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

{

    targetPtr += sizeof(int);
    if(field.context!= null)
    {
        for(int iterator_2 = 0;iterator_2<field.context.Count;++iterator_2)
        {

        if(field.context[iterator_2]!= null)
        {
            int strlen_3 = field.context[iterator_2].Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        }
    }

}
            if( field.claims!= null)
            {

            {

        if(field.claims.Value.cbc_UBLVersionID!= null)
        {
            int strlen_3 = field.claims.Value.cbc_UBLVersionID.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.claims.Value.cbc_ID!= null)
        {
            int strlen_3 = field.claims.Value.cbc_ID.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
targetPtr += 8;
            {

        if(field.claims.Value.cbc_InvoiceTypeCode._listID!= null)
        {
            int strlen_4 = field.claims.Value.cbc_InvoiceTypeCode._listID.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.claims.Value.cbc_InvoiceTypeCode._listAgencyID!= null)
        {
            int strlen_4 = field.claims.Value.cbc_InvoiceTypeCode._listAgencyID.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.claims.Value.cbc_InvoiceTypeCode.code!= null)
        {
            int strlen_4 = field.claims.Value.cbc_InvoiceTypeCode.code.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            {
            targetPtr += 1;

        if(field.claims.Value.cbc_Note.note!= null)
        {
            int strlen_4 = field.claims.Value.cbc_Note.note.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }targetPtr += 8;
            {

        if(field.claims.Value.cbc_DocumentCurrencyCode._listID!= null)
        {
            int strlen_4 = field.claims.Value.cbc_DocumentCurrencyCode._listID.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.claims.Value.cbc_DocumentCurrencyCode._listAgencyID!= null)
        {
            int strlen_4 = field.claims.Value.cbc_DocumentCurrencyCode._listAgencyID.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.claims.Value.cbc_DocumentCurrencyCode.code!= null)
        {
            int strlen_4 = field.claims.Value.cbc_DocumentCurrencyCode.code.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
        if(field.claims.Value.cbc_AccountingCost!= null)
        {
            int strlen_3 = field.claims.Value.cbc_AccountingCost.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
targetPtr += 16;

            {

        if(field.claims.Value.cbc_OrderReference.cbc_ID!= null)
        {
            int strlen_4 = field.claims.Value.cbc_OrderReference.cbc_ID.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            {
            targetPtr += 1;

        if(field.claims.Value.cac_ContractDocumentReference.ID!= null)
        {
            int strlen_4 = field.claims.Value.cac_ContractDocumentReference.ID.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.claims.Value.cac_ContractDocumentReference.DocumentType!= null)
        {
            int strlen_4 = field.claims.Value.cac_ContractDocumentReference.DocumentType.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( field.claims.Value.cac_ContractDocumentReference.cac_Attachment!= null)
            {

            {

        if(field.claims.Value.cac_ContractDocumentReference.cac_Attachment.Value.cac_ExternalReferenceUdid!= null)
        {
            int strlen_5 = field.claims.Value.cac_ContractDocumentReference.cac_Attachment.Value.cac_ExternalReferenceUdid.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }

            }
{

    targetPtr += sizeof(int);
    if(field.claims.Value.cac_AdditionalDocumentReferences!= null)
    {
        for(int iterator_3 = 0;iterator_3<field.claims.Value.cac_AdditionalDocumentReferences.Count;++iterator_3)
        {

            {
            targetPtr += 1;

        if(field.claims.Value.cac_AdditionalDocumentReferences[iterator_3].ID!= null)
        {
            int strlen_5 = field.claims.Value.cac_AdditionalDocumentReferences[iterator_3].ID.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.claims.Value.cac_AdditionalDocumentReferences[iterator_3].DocumentType!= null)
        {
            int strlen_5 = field.claims.Value.cac_AdditionalDocumentReferences[iterator_3].DocumentType.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( field.claims.Value.cac_AdditionalDocumentReferences[iterator_3].cac_Attachment!= null)
            {

            {

        if(field.claims.Value.cac_AdditionalDocumentReferences[iterator_3].cac_Attachment.Value.cac_ExternalReferenceUdid!= null)
        {
            int strlen_6 = field.claims.Value.cac_AdditionalDocumentReferences[iterator_3].cac_Attachment.Value.cac_ExternalReferenceUdid.Length * 2;
            targetPtr += strlen_6+sizeof(int);
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

            {

        if(field.claims.Value.cac_AccountingSupplierParty.cac_PartyUdid!= null)
        {
            int strlen_4 = field.claims.Value.cac_AccountingSupplierParty.cac_PartyUdid.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            {

        if(field.claims.Value.cac_AccountingCustomerParty.cac_PartyUdid!= null)
        {
            int strlen_4 = field.claims.Value.cac_AccountingCustomerParty.cac_PartyUdid.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            {

        if(field.claims.Value.cac_PayeeParty.cac_PartyUdid!= null)
        {
            int strlen_4 = field.claims.Value.cac_PayeeParty.cac_PartyUdid.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            {
targetPtr += 8;
            {

            {
            targetPtr += 1;

        if(field.claims.Value.cac_Delivery.cac_DeliveryLocation.cbc_ID._schemeID!= null)
        {
            int strlen_6 = field.claims.Value.cac_Delivery.cac_DeliveryLocation.cbc_ID._schemeID.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( field.claims.Value.cac_Delivery.cac_DeliveryLocation.cbc_ID._schemeAgencyID!= null)
            {

        if(field.claims.Value.cac_Delivery.cac_DeliveryLocation.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_6 = field.claims.Value.cac_Delivery.cac_DeliveryLocation.cbc_ID._schemeAgencyID.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

        if(field.claims.Value.cac_Delivery.cac_DeliveryLocation.cbc_ID.code!= null)
        {
            int strlen_6 = field.claims.Value.cac_Delivery.cac_DeliveryLocation.cbc_ID.code.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
        if(field.claims.Value.cac_Delivery.cac_DeliveryLocation.cac_AddressUdid!= null)
        {
            int strlen_5 = field.claims.Value.cac_Delivery.cac_DeliveryLocation.cac_AddressUdid.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
        if(field.claims.Value.cac_PaymentMeansUdid!= null)
        {
            int strlen_3 = field.claims.Value.cac_PaymentMeansUdid.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            {

            {
            targetPtr += 1;

        if(field.claims.Value.cac_PaymentTerms.cbc_Note.note!= null)
        {
            int strlen_5 = field.claims.Value.cac_PaymentTerms.cbc_Note.note.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
{

    targetPtr += sizeof(int);
    if(field.claims.Value.cac_AllowanceCharges!= null)
    {
        for(int iterator_3 = 0;iterator_3<field.claims.Value.cac_AllowanceCharges.Count;++iterator_3)
        {

            {
            targetPtr += 1;

        if(field.claims.Value.cac_AllowanceCharges[iterator_3].cbc_AllowanceChargeReason!= null)
        {
            int strlen_5 = field.claims.Value.cac_AllowanceCharges[iterator_3].cbc_AllowanceChargeReason.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            {

        if(field.claims.Value.cac_AllowanceCharges[iterator_3].cbc_Amount._CurrencyID!= null)
        {
            int strlen_6 = field.claims.Value.cac_AllowanceCharges[iterator_3].cbc_Amount._CurrencyID.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            }
        }
    }

}

            {

            {

        if(field.claims.Value.cac_TaxTotal.cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_5 = field.claims.Value.cac_TaxTotal.cbc_TaxAmount._CurrencyID.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
{

    targetPtr += sizeof(int);
    if(field.claims.Value.cac_TaxTotal.cac_TaxSubtotals!= null)
    {
        for(int iterator_4 = 0;iterator_4<field.claims.Value.cac_TaxTotal.cac_TaxSubtotals.Count;++iterator_4)
        {

            {

            {

        if(field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cbc_TaxableAmount._CurrencyID!= null)
        {
            int strlen_7 = field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cbc_TaxableAmount._CurrencyID.Length * 2;
            targetPtr += strlen_7+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

        if(field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_7 = field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cbc_TaxAmount._CurrencyID.Length * 2;
            targetPtr += strlen_7+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

            {
            targetPtr += 1;

        if(field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cbc_ID._schemeID!= null)
        {
            int strlen_8 = field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cbc_ID._schemeID.Length * 2;
            targetPtr += strlen_8+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
            {

        if(field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_8 = field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cbc_ID._schemeAgencyID.Length * 2;
            targetPtr += strlen_8+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

        if(field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cbc_ID.code!= null)
        {
            int strlen_8 = field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cbc_ID.code.Length * 2;
            targetPtr += strlen_8+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }            targetPtr += 8;

            {

            {
            targetPtr += 1;

        if(field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID!= null)
        {
            int strlen_9 = field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID.Length * 2;
            targetPtr += strlen_9+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
            {

        if(field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_9 = field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID.Length * 2;
            targetPtr += strlen_9+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

        if(field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cac_TaxScheme.cbc_ID.code!= null)
        {
            int strlen_9 = field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cac_TaxScheme.cbc_ID.code.Length * 2;
            targetPtr += strlen_9+sizeof(int);
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
            {

            {

        if(field.claims.Value.cac_LegalMonetaryTotal.cbc_LineExtensionAmount._CurrencyID!= null)
        {
            int strlen_5 = field.claims.Value.cac_LegalMonetaryTotal.cbc_LineExtensionAmount._CurrencyID.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

        if(field.claims.Value.cac_LegalMonetaryTotal.cbc_TaxExclusiveAmount._CurrencyID!= null)
        {
            int strlen_5 = field.claims.Value.cac_LegalMonetaryTotal.cbc_TaxExclusiveAmount._CurrencyID.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

        if(field.claims.Value.cac_LegalMonetaryTotal.cbc_TaxInclusiveAmount._CurrencyID!= null)
        {
            int strlen_5 = field.claims.Value.cac_LegalMonetaryTotal.cbc_TaxInclusiveAmount._CurrencyID.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

        if(field.claims.Value.cac_LegalMonetaryTotal.cbc_AllowanceTotalAmount._CurrencyID!= null)
        {
            int strlen_5 = field.claims.Value.cac_LegalMonetaryTotal.cbc_AllowanceTotalAmount._CurrencyID.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

        if(field.claims.Value.cac_LegalMonetaryTotal.cbc_ChargeTotalAmount._CurrencyID!= null)
        {
            int strlen_5 = field.claims.Value.cac_LegalMonetaryTotal.cbc_ChargeTotalAmount._CurrencyID.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

        if(field.claims.Value.cac_LegalMonetaryTotal.cbc_PrepaidAmount._CurrencyID!= null)
        {
            int strlen_5 = field.claims.Value.cac_LegalMonetaryTotal.cbc_PrepaidAmount._CurrencyID.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

        if(field.claims.Value.cac_LegalMonetaryTotal.cbc_PayableRoundingAmount._CurrencyID!= null)
        {
            int strlen_5 = field.claims.Value.cac_LegalMonetaryTotal.cbc_PayableRoundingAmount._CurrencyID.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

        if(field.claims.Value.cac_LegalMonetaryTotal.cbc_PayableAmount._CurrencyID!= null)
        {
            int strlen_5 = field.claims.Value.cac_LegalMonetaryTotal.cbc_PayableAmount._CurrencyID.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            }
{

    targetPtr += sizeof(int);
    if(field.claims.Value.cac_InvoiceLine!= null)
    {
        for(int iterator_3 = 0;iterator_3<field.claims.Value.cac_InvoiceLine.Count;++iterator_3)
        {

            {

        if(field.claims.Value.cac_InvoiceLine[iterator_3].cbc_ID!= null)
        {
            int strlen_5 = field.claims.Value.cac_InvoiceLine[iterator_3].cbc_ID.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            {
            targetPtr += 1;

        if(field.claims.Value.cac_InvoiceLine[iterator_3].cbc_Note.note!= null)
        {
            int strlen_6 = field.claims.Value.cac_InvoiceLine[iterator_3].cbc_Note.note.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            {

        if(field.claims.Value.cac_InvoiceLine[iterator_3].cbc_InvoicedQuantity._unitCode!= null)
        {
            int strlen_6 = field.claims.Value.cac_InvoiceLine[iterator_3].cbc_InvoicedQuantity._unitCode.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

        if(field.claims.Value.cac_InvoiceLine[iterator_3].cbc_LineExtensionAmount._CurrencyID!= null)
        {
            int strlen_6 = field.claims.Value.cac_InvoiceLine[iterator_3].cbc_LineExtensionAmount._CurrencyID.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
        if(field.claims.Value.cac_InvoiceLine[iterator_3].cbc_AccountingCost!= null)
        {
            int strlen_5 = field.claims.Value.cac_InvoiceLine[iterator_3].cbc_AccountingCost.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            {

        if(field.claims.Value.cac_InvoiceLine[iterator_3].cac_OrderLineReference.cbc_LineID!= null)
        {
            int strlen_6 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_OrderLineReference.cbc_LineID.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
{

    targetPtr += sizeof(int);
    if(field.claims.Value.cac_InvoiceLine[iterator_3].cac_AllowanceCharges!= null)
    {
        for(int iterator_5 = 0;iterator_5<field.claims.Value.cac_InvoiceLine[iterator_3].cac_AllowanceCharges.Count;++iterator_5)
        {

            {
            targetPtr += 1;

        if(field.claims.Value.cac_InvoiceLine[iterator_3].cac_AllowanceCharges[iterator_5].cbc_AllowanceChargeReason!= null)
        {
            int strlen_7 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_AllowanceCharges[iterator_5].cbc_AllowanceChargeReason.Length * 2;
            targetPtr += strlen_7+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            {

        if(field.claims.Value.cac_InvoiceLine[iterator_3].cac_AllowanceCharges[iterator_5].cbc_Amount._CurrencyID!= null)
        {
            int strlen_8 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_AllowanceCharges[iterator_5].cbc_Amount._CurrencyID.Length * 2;
            targetPtr += strlen_8+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            }
        }
    }

}

            {

            {

        if(field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_7 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cbc_TaxAmount._CurrencyID.Length * 2;
            targetPtr += strlen_7+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
{

    targetPtr += sizeof(int);
    if(field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals!= null)
    {
        for(int iterator_6 = 0;iterator_6<field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals.Count;++iterator_6)
        {

            {

            {

        if(field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cbc_TaxableAmount._CurrencyID!= null)
        {
            int strlen_9 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cbc_TaxableAmount._CurrencyID.Length * 2;
            targetPtr += strlen_9+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

        if(field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_9 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cbc_TaxAmount._CurrencyID.Length * 2;
            targetPtr += strlen_9+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

            {
            targetPtr += 1;

        if(field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cac_TaxCategory.cbc_ID._schemeID!= null)
        {
            int strlen_10 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cac_TaxCategory.cbc_ID._schemeID.Length * 2;
            targetPtr += strlen_10+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
            {

        if(field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_10 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cac_TaxCategory.cbc_ID._schemeAgencyID.Length * 2;
            targetPtr += strlen_10+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

        if(field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cac_TaxCategory.cbc_ID.code!= null)
        {
            int strlen_10 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cac_TaxCategory.cbc_ID.code.Length * 2;
            targetPtr += strlen_10+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }            targetPtr += 8;

            {

            {
            targetPtr += 1;

        if(field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID!= null)
        {
            int strlen_11 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID.Length * 2;
            targetPtr += strlen_11+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
            {

        if(field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_11 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID.Length * 2;
            targetPtr += strlen_11+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

        if(field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cac_TaxCategory.cac_TaxScheme.cbc_ID.code!= null)
        {
            int strlen_11 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cac_TaxCategory.cac_TaxScheme.cbc_ID.code.Length * 2;
            targetPtr += strlen_11+sizeof(int);
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
        if(field.claims.Value.cac_InvoiceLine[iterator_3].cac_ItemUdid!= null)
        {
            int strlen_5 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_ItemUdid.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            {

            {

        if(field.claims.Value.cac_InvoiceLine[iterator_3].cac_Price.cbc_PriceAmount._CurrencyID!= null)
        {
            int strlen_7 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_Price.cbc_PriceAmount._CurrencyID.Length * 2;
            targetPtr += strlen_7+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

        if(field.claims.Value.cac_InvoiceLine[iterator_3].cac_Price.cbc_BaseQuantity._unitCode!= null)
        {
            int strlen_7 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_Price.cbc_BaseQuantity._unitCode.Length * 2;
            targetPtr += strlen_7+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {
            targetPtr += 1;

        if(field.claims.Value.cac_InvoiceLine[iterator_3].cac_Price.cac_AllowanceCharge.cbc_AllowanceChargeReason!= null)
        {
            int strlen_7 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_Price.cac_AllowanceCharge.cbc_AllowanceChargeReason.Length * 2;
            targetPtr += strlen_7+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            {

        if(field.claims.Value.cac_InvoiceLine[iterator_3].cac_Price.cac_AllowanceCharge.cbc_Amount._CurrencyID!= null)
        {
            int strlen_8 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_Price.cac_AllowanceCharge.cbc_Amount._CurrencyID.Length * 2;
            targetPtr += strlen_8+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            }
            }
            }
        }
    }

}

            }
            }
            if( field.encryptedclaims!= null)
            {

            {

        if(field.encryptedclaims.Value.ciphertext16!= null)
        {
            int strlen_3 = field.encryptedclaims.Value.ciphertext16.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.encryptedclaims.Value.alg!= null)
        {
            int strlen_3 = field.encryptedclaims.Value.alg.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.encryptedclaims.Value.key!= null)
        {
            int strlen_3 = field.encryptedclaims.Value.key.Length * 2;
            targetPtr += strlen_3+sizeof(int);
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
            byte* optheader_1 = targetPtr;
            *(optheader_1 + 0) = 0x00;            targetPtr += 1;

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

{
byte *storedPtr_2 = targetPtr;

    targetPtr += sizeof(int);
    if(field.context!= null)
    {
        for(int iterator_2 = 0;iterator_2<field.context.Count;++iterator_2)
        {

        if(field.context[iterator_2]!= null)
        {
            int strlen_3 = field.context[iterator_2].Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.context[iterator_2])
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
    }
*(int*)storedPtr_2 = (int)(targetPtr - storedPtr_2 - 4);

}
            if( field.claims!= null)
            {

            {

        if(field.claims.Value.cbc_UBLVersionID!= null)
        {
            int strlen_3 = field.claims.Value.cbc_UBLVersionID.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.claims.Value.cbc_UBLVersionID)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.claims.Value.cbc_ID!= null)
        {
            int strlen_3 = field.claims.Value.cbc_ID.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.claims.Value.cbc_ID)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        {
            *(long*)targetPtr = field.claims.Value.cbc_IssueDate.ToBinary();
            targetPtr += 8;
        }

            {

        if(field.claims.Value.cbc_InvoiceTypeCode._listID!= null)
        {
            int strlen_4 = field.claims.Value.cbc_InvoiceTypeCode._listID.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.claims.Value.cbc_InvoiceTypeCode._listID)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.claims.Value.cbc_InvoiceTypeCode._listAgencyID!= null)
        {
            int strlen_4 = field.claims.Value.cbc_InvoiceTypeCode._listAgencyID.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.claims.Value.cbc_InvoiceTypeCode._listAgencyID)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.claims.Value.cbc_InvoiceTypeCode.code!= null)
        {
            int strlen_4 = field.claims.Value.cbc_InvoiceTypeCode.code.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.claims.Value.cbc_InvoiceTypeCode.code)
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
            {
            *(ISO639_1_LanguageCodes*)targetPtr = field.claims.Value.cbc_Note._languageID;
            targetPtr += 1;

        if(field.claims.Value.cbc_Note.note!= null)
        {
            int strlen_4 = field.claims.Value.cbc_Note.note.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.claims.Value.cbc_Note.note)
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
        {
            *(long*)targetPtr = field.claims.Value.cbc_TaxPointDate.ToBinary();
            targetPtr += 8;
        }

            {

        if(field.claims.Value.cbc_DocumentCurrencyCode._listID!= null)
        {
            int strlen_4 = field.claims.Value.cbc_DocumentCurrencyCode._listID.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.claims.Value.cbc_DocumentCurrencyCode._listID)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.claims.Value.cbc_DocumentCurrencyCode._listAgencyID!= null)
        {
            int strlen_4 = field.claims.Value.cbc_DocumentCurrencyCode._listAgencyID.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.claims.Value.cbc_DocumentCurrencyCode._listAgencyID)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.claims.Value.cbc_DocumentCurrencyCode.code!= null)
        {
            int strlen_4 = field.claims.Value.cbc_DocumentCurrencyCode.code.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.claims.Value.cbc_DocumentCurrencyCode.code)
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
        if(field.claims.Value.cbc_AccountingCost!= null)
        {
            int strlen_3 = field.claims.Value.cbc_AccountingCost.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.claims.Value.cbc_AccountingCost)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            {

        {
            *(long*)targetPtr = field.claims.Value.cbc_InvoicePeriod.cbc_StartDate.ToBinary();
            targetPtr += 8;
        }

        {
            *(long*)targetPtr = field.claims.Value.cbc_InvoicePeriod.cbc_EndDate.ToBinary();
            targetPtr += 8;
        }

            }
            {

        if(field.claims.Value.cbc_OrderReference.cbc_ID!= null)
        {
            int strlen_4 = field.claims.Value.cbc_OrderReference.cbc_ID.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.claims.Value.cbc_OrderReference.cbc_ID)
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
            {
            byte* optheader_3 = targetPtr;
            *(optheader_3 + 0) = 0x00;            targetPtr += 1;

        if(field.claims.Value.cac_ContractDocumentReference.ID!= null)
        {
            int strlen_4 = field.claims.Value.cac_ContractDocumentReference.ID.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.claims.Value.cac_ContractDocumentReference.ID)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.claims.Value.cac_ContractDocumentReference.DocumentType!= null)
        {
            int strlen_4 = field.claims.Value.cac_ContractDocumentReference.DocumentType.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.claims.Value.cac_ContractDocumentReference.DocumentType)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( field.claims.Value.cac_ContractDocumentReference.cac_Attachment!= null)
            {

            {

        if(field.claims.Value.cac_ContractDocumentReference.cac_Attachment.Value.cac_ExternalReferenceUdid!= null)
        {
            int strlen_5 = field.claims.Value.cac_ContractDocumentReference.cac_Attachment.Value.cac_ExternalReferenceUdid.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.claims.Value.cac_ContractDocumentReference.cac_Attachment.Value.cac_ExternalReferenceUdid)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }*(optheader_3 + 0) |= 0x01;
            }

            }
{
byte *storedPtr_3 = targetPtr;

    targetPtr += sizeof(int);
    if(field.claims.Value.cac_AdditionalDocumentReferences!= null)
    {
        for(int iterator_3 = 0;iterator_3<field.claims.Value.cac_AdditionalDocumentReferences.Count;++iterator_3)
        {

            {
            byte* optheader_4 = targetPtr;
            *(optheader_4 + 0) = 0x00;            targetPtr += 1;

        if(field.claims.Value.cac_AdditionalDocumentReferences[iterator_3].ID!= null)
        {
            int strlen_5 = field.claims.Value.cac_AdditionalDocumentReferences[iterator_3].ID.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.claims.Value.cac_AdditionalDocumentReferences[iterator_3].ID)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.claims.Value.cac_AdditionalDocumentReferences[iterator_3].DocumentType!= null)
        {
            int strlen_5 = field.claims.Value.cac_AdditionalDocumentReferences[iterator_3].DocumentType.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.claims.Value.cac_AdditionalDocumentReferences[iterator_3].DocumentType)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( field.claims.Value.cac_AdditionalDocumentReferences[iterator_3].cac_Attachment!= null)
            {

            {

        if(field.claims.Value.cac_AdditionalDocumentReferences[iterator_3].cac_Attachment.Value.cac_ExternalReferenceUdid!= null)
        {
            int strlen_6 = field.claims.Value.cac_AdditionalDocumentReferences[iterator_3].cac_Attachment.Value.cac_ExternalReferenceUdid.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = field.claims.Value.cac_AdditionalDocumentReferences[iterator_3].cac_Attachment.Value.cac_ExternalReferenceUdid)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }*(optheader_4 + 0) |= 0x01;
            }

            }
        }
    }
*(int*)storedPtr_3 = (int)(targetPtr - storedPtr_3 - 4);

}

            {

        if(field.claims.Value.cac_AccountingSupplierParty.cac_PartyUdid!= null)
        {
            int strlen_4 = field.claims.Value.cac_AccountingSupplierParty.cac_PartyUdid.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.claims.Value.cac_AccountingSupplierParty.cac_PartyUdid)
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
            {

        if(field.claims.Value.cac_AccountingCustomerParty.cac_PartyUdid!= null)
        {
            int strlen_4 = field.claims.Value.cac_AccountingCustomerParty.cac_PartyUdid.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.claims.Value.cac_AccountingCustomerParty.cac_PartyUdid)
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
            {

        if(field.claims.Value.cac_PayeeParty.cac_PartyUdid!= null)
        {
            int strlen_4 = field.claims.Value.cac_PayeeParty.cac_PartyUdid.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.claims.Value.cac_PayeeParty.cac_PartyUdid)
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
            {

        {
            *(long*)targetPtr = field.claims.Value.cac_Delivery.cbc_ActualDeliveryDate.ToBinary();
            targetPtr += 8;
        }

            {

            {
            byte* optheader_5 = targetPtr;
            *(optheader_5 + 0) = 0x00;            targetPtr += 1;

        if(field.claims.Value.cac_Delivery.cac_DeliveryLocation.cbc_ID._schemeID!= null)
        {
            int strlen_6 = field.claims.Value.cac_Delivery.cac_DeliveryLocation.cbc_ID._schemeID.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = field.claims.Value.cac_Delivery.cac_DeliveryLocation.cbc_ID._schemeID)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( field.claims.Value.cac_Delivery.cac_DeliveryLocation.cbc_ID._schemeAgencyID!= null)
            {

        if(field.claims.Value.cac_Delivery.cac_DeliveryLocation.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_6 = field.claims.Value.cac_Delivery.cac_DeliveryLocation.cbc_ID._schemeAgencyID.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = field.claims.Value.cac_Delivery.cac_DeliveryLocation.cbc_ID._schemeAgencyID)
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

        if(field.claims.Value.cac_Delivery.cac_DeliveryLocation.cbc_ID.code!= null)
        {
            int strlen_6 = field.claims.Value.cac_Delivery.cac_DeliveryLocation.cbc_ID.code.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = field.claims.Value.cac_Delivery.cac_DeliveryLocation.cbc_ID.code)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
        if(field.claims.Value.cac_Delivery.cac_DeliveryLocation.cac_AddressUdid!= null)
        {
            int strlen_5 = field.claims.Value.cac_Delivery.cac_DeliveryLocation.cac_AddressUdid.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.claims.Value.cac_Delivery.cac_DeliveryLocation.cac_AddressUdid)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
            }
        if(field.claims.Value.cac_PaymentMeansUdid!= null)
        {
            int strlen_3 = field.claims.Value.cac_PaymentMeansUdid.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.claims.Value.cac_PaymentMeansUdid)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            {

            {
            *(ISO639_1_LanguageCodes*)targetPtr = field.claims.Value.cac_PaymentTerms.cbc_Note._languageID;
            targetPtr += 1;

        if(field.claims.Value.cac_PaymentTerms.cbc_Note.note!= null)
        {
            int strlen_5 = field.claims.Value.cac_PaymentTerms.cbc_Note.note.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.claims.Value.cac_PaymentTerms.cbc_Note.note)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
            }
{
byte *storedPtr_3 = targetPtr;

    targetPtr += sizeof(int);
    if(field.claims.Value.cac_AllowanceCharges!= null)
    {
        for(int iterator_3 = 0;iterator_3<field.claims.Value.cac_AllowanceCharges.Count;++iterator_3)
        {

            {
            *(bool*)targetPtr = field.claims.Value.cac_AllowanceCharges[iterator_3].cbc_ChargeIndicator;
            targetPtr += 1;

        if(field.claims.Value.cac_AllowanceCharges[iterator_3].cbc_AllowanceChargeReason!= null)
        {
            int strlen_5 = field.claims.Value.cac_AllowanceCharges[iterator_3].cbc_AllowanceChargeReason.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.claims.Value.cac_AllowanceCharges[iterator_3].cbc_AllowanceChargeReason)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            {

        if(field.claims.Value.cac_AllowanceCharges[iterator_3].cbc_Amount._CurrencyID!= null)
        {
            int strlen_6 = field.claims.Value.cac_AllowanceCharges[iterator_3].cbc_Amount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = field.claims.Value.cac_AllowanceCharges[iterator_3].cbc_Amount._CurrencyID)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.claims.Value.cac_AllowanceCharges[iterator_3].cbc_Amount.amount;
            targetPtr += 8;

            }
            }
        }
    }
*(int*)storedPtr_3 = (int)(targetPtr - storedPtr_3 - 4);

}

            {

            {

        if(field.claims.Value.cac_TaxTotal.cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_5 = field.claims.Value.cac_TaxTotal.cbc_TaxAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.claims.Value.cac_TaxTotal.cbc_TaxAmount._CurrencyID)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.claims.Value.cac_TaxTotal.cbc_TaxAmount.amount;
            targetPtr += 8;

            }
{
byte *storedPtr_4 = targetPtr;

    targetPtr += sizeof(int);
    if(field.claims.Value.cac_TaxTotal.cac_TaxSubtotals!= null)
    {
        for(int iterator_4 = 0;iterator_4<field.claims.Value.cac_TaxTotal.cac_TaxSubtotals.Count;++iterator_4)
        {

            {

            {

        if(field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cbc_TaxableAmount._CurrencyID!= null)
        {
            int strlen_7 = field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cbc_TaxableAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_7;
            targetPtr += sizeof(int);
            fixed(char* pstr_7 = field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cbc_TaxableAmount._CurrencyID)
            {
                Memory.Copy(pstr_7, targetPtr, strlen_7);
                targetPtr += strlen_7;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cbc_TaxableAmount.amount;
            targetPtr += 8;

            }
            {

        if(field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_7 = field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cbc_TaxAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_7;
            targetPtr += sizeof(int);
            fixed(char* pstr_7 = field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cbc_TaxAmount._CurrencyID)
            {
                Memory.Copy(pstr_7, targetPtr, strlen_7);
                targetPtr += strlen_7;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cbc_TaxAmount.amount;
            targetPtr += 8;

            }
            {

            {
            byte* optheader_7 = targetPtr;
            *(optheader_7 + 0) = 0x00;            targetPtr += 1;

        if(field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cbc_ID._schemeID!= null)
        {
            int strlen_8 = field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cbc_ID._schemeID.Length * 2;
            *(int*)targetPtr = strlen_8;
            targetPtr += sizeof(int);
            fixed(char* pstr_8 = field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cbc_ID._schemeID)
            {
                Memory.Copy(pstr_8, targetPtr, strlen_8);
                targetPtr += strlen_8;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
            {

        if(field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_8 = field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cbc_ID._schemeAgencyID.Length * 2;
            *(int*)targetPtr = strlen_8;
            targetPtr += sizeof(int);
            fixed(char* pstr_8 = field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cbc_ID._schemeAgencyID)
            {
                Memory.Copy(pstr_8, targetPtr, strlen_8);
                targetPtr += strlen_8;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_7 + 0) |= 0x01;
            }

        if(field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cbc_ID.code!= null)
        {
            int strlen_8 = field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cbc_ID.code.Length * 2;
            *(int*)targetPtr = strlen_8;
            targetPtr += sizeof(int);
            fixed(char* pstr_8 = field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cbc_ID.code)
            {
                Memory.Copy(pstr_8, targetPtr, strlen_8);
                targetPtr += strlen_8;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }            *(double*)targetPtr = field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cbc_Percent;
            targetPtr += 8;

            {

            {
            byte* optheader_8 = targetPtr;
            *(optheader_8 + 0) = 0x00;            targetPtr += 1;

        if(field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID!= null)
        {
            int strlen_9 = field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID.Length * 2;
            *(int*)targetPtr = strlen_9;
            targetPtr += sizeof(int);
            fixed(char* pstr_9 = field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID)
            {
                Memory.Copy(pstr_9, targetPtr, strlen_9);
                targetPtr += strlen_9;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
            {

        if(field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_9 = field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID.Length * 2;
            *(int*)targetPtr = strlen_9;
            targetPtr += sizeof(int);
            fixed(char* pstr_9 = field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID)
            {
                Memory.Copy(pstr_9, targetPtr, strlen_9);
                targetPtr += strlen_9;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_8 + 0) |= 0x01;
            }

        if(field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cac_TaxScheme.cbc_ID.code!= null)
        {
            int strlen_9 = field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cac_TaxScheme.cbc_ID.code.Length * 2;
            *(int*)targetPtr = strlen_9;
            targetPtr += sizeof(int);
            fixed(char* pstr_9 = field.claims.Value.cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cac_TaxScheme.cbc_ID.code)
            {
                Memory.Copy(pstr_9, targetPtr, strlen_9);
                targetPtr += strlen_9;
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
*(int*)storedPtr_4 = (int)(targetPtr - storedPtr_4 - 4);

}

            }
            {

            {

        if(field.claims.Value.cac_LegalMonetaryTotal.cbc_LineExtensionAmount._CurrencyID!= null)
        {
            int strlen_5 = field.claims.Value.cac_LegalMonetaryTotal.cbc_LineExtensionAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.claims.Value.cac_LegalMonetaryTotal.cbc_LineExtensionAmount._CurrencyID)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.claims.Value.cac_LegalMonetaryTotal.cbc_LineExtensionAmount.amount;
            targetPtr += 8;

            }
            {

        if(field.claims.Value.cac_LegalMonetaryTotal.cbc_TaxExclusiveAmount._CurrencyID!= null)
        {
            int strlen_5 = field.claims.Value.cac_LegalMonetaryTotal.cbc_TaxExclusiveAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.claims.Value.cac_LegalMonetaryTotal.cbc_TaxExclusiveAmount._CurrencyID)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.claims.Value.cac_LegalMonetaryTotal.cbc_TaxExclusiveAmount.amount;
            targetPtr += 8;

            }
            {

        if(field.claims.Value.cac_LegalMonetaryTotal.cbc_TaxInclusiveAmount._CurrencyID!= null)
        {
            int strlen_5 = field.claims.Value.cac_LegalMonetaryTotal.cbc_TaxInclusiveAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.claims.Value.cac_LegalMonetaryTotal.cbc_TaxInclusiveAmount._CurrencyID)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.claims.Value.cac_LegalMonetaryTotal.cbc_TaxInclusiveAmount.amount;
            targetPtr += 8;

            }
            {

        if(field.claims.Value.cac_LegalMonetaryTotal.cbc_AllowanceTotalAmount._CurrencyID!= null)
        {
            int strlen_5 = field.claims.Value.cac_LegalMonetaryTotal.cbc_AllowanceTotalAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.claims.Value.cac_LegalMonetaryTotal.cbc_AllowanceTotalAmount._CurrencyID)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.claims.Value.cac_LegalMonetaryTotal.cbc_AllowanceTotalAmount.amount;
            targetPtr += 8;

            }
            {

        if(field.claims.Value.cac_LegalMonetaryTotal.cbc_ChargeTotalAmount._CurrencyID!= null)
        {
            int strlen_5 = field.claims.Value.cac_LegalMonetaryTotal.cbc_ChargeTotalAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.claims.Value.cac_LegalMonetaryTotal.cbc_ChargeTotalAmount._CurrencyID)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.claims.Value.cac_LegalMonetaryTotal.cbc_ChargeTotalAmount.amount;
            targetPtr += 8;

            }
            {

        if(field.claims.Value.cac_LegalMonetaryTotal.cbc_PrepaidAmount._CurrencyID!= null)
        {
            int strlen_5 = field.claims.Value.cac_LegalMonetaryTotal.cbc_PrepaidAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.claims.Value.cac_LegalMonetaryTotal.cbc_PrepaidAmount._CurrencyID)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.claims.Value.cac_LegalMonetaryTotal.cbc_PrepaidAmount.amount;
            targetPtr += 8;

            }
            {

        if(field.claims.Value.cac_LegalMonetaryTotal.cbc_PayableRoundingAmount._CurrencyID!= null)
        {
            int strlen_5 = field.claims.Value.cac_LegalMonetaryTotal.cbc_PayableRoundingAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.claims.Value.cac_LegalMonetaryTotal.cbc_PayableRoundingAmount._CurrencyID)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.claims.Value.cac_LegalMonetaryTotal.cbc_PayableRoundingAmount.amount;
            targetPtr += 8;

            }
            {

        if(field.claims.Value.cac_LegalMonetaryTotal.cbc_PayableAmount._CurrencyID!= null)
        {
            int strlen_5 = field.claims.Value.cac_LegalMonetaryTotal.cbc_PayableAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.claims.Value.cac_LegalMonetaryTotal.cbc_PayableAmount._CurrencyID)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.claims.Value.cac_LegalMonetaryTotal.cbc_PayableAmount.amount;
            targetPtr += 8;

            }
            }
{
byte *storedPtr_3 = targetPtr;

    targetPtr += sizeof(int);
    if(field.claims.Value.cac_InvoiceLine!= null)
    {
        for(int iterator_3 = 0;iterator_3<field.claims.Value.cac_InvoiceLine.Count;++iterator_3)
        {

            {

        if(field.claims.Value.cac_InvoiceLine[iterator_3].cbc_ID!= null)
        {
            int strlen_5 = field.claims.Value.cac_InvoiceLine[iterator_3].cbc_ID.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.claims.Value.cac_InvoiceLine[iterator_3].cbc_ID)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            {
            *(ISO639_1_LanguageCodes*)targetPtr = field.claims.Value.cac_InvoiceLine[iterator_3].cbc_Note._languageID;
            targetPtr += 1;

        if(field.claims.Value.cac_InvoiceLine[iterator_3].cbc_Note.note!= null)
        {
            int strlen_6 = field.claims.Value.cac_InvoiceLine[iterator_3].cbc_Note.note.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = field.claims.Value.cac_InvoiceLine[iterator_3].cbc_Note.note)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
            {

        if(field.claims.Value.cac_InvoiceLine[iterator_3].cbc_InvoicedQuantity._unitCode!= null)
        {
            int strlen_6 = field.claims.Value.cac_InvoiceLine[iterator_3].cbc_InvoicedQuantity._unitCode.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = field.claims.Value.cac_InvoiceLine[iterator_3].cbc_InvoicedQuantity._unitCode)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = field.claims.Value.cac_InvoiceLine[iterator_3].cbc_InvoicedQuantity.quantity;
            targetPtr += 8;

            }
            {

        if(field.claims.Value.cac_InvoiceLine[iterator_3].cbc_LineExtensionAmount._CurrencyID!= null)
        {
            int strlen_6 = field.claims.Value.cac_InvoiceLine[iterator_3].cbc_LineExtensionAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = field.claims.Value.cac_InvoiceLine[iterator_3].cbc_LineExtensionAmount._CurrencyID)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.claims.Value.cac_InvoiceLine[iterator_3].cbc_LineExtensionAmount.amount;
            targetPtr += 8;

            }
        if(field.claims.Value.cac_InvoiceLine[iterator_3].cbc_AccountingCost!= null)
        {
            int strlen_5 = field.claims.Value.cac_InvoiceLine[iterator_3].cbc_AccountingCost.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.claims.Value.cac_InvoiceLine[iterator_3].cbc_AccountingCost)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            {

        if(field.claims.Value.cac_InvoiceLine[iterator_3].cac_OrderLineReference.cbc_LineID!= null)
        {
            int strlen_6 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_OrderLineReference.cbc_LineID.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_OrderLineReference.cbc_LineID)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
{
byte *storedPtr_5 = targetPtr;

    targetPtr += sizeof(int);
    if(field.claims.Value.cac_InvoiceLine[iterator_3].cac_AllowanceCharges!= null)
    {
        for(int iterator_5 = 0;iterator_5<field.claims.Value.cac_InvoiceLine[iterator_3].cac_AllowanceCharges.Count;++iterator_5)
        {

            {
            *(bool*)targetPtr = field.claims.Value.cac_InvoiceLine[iterator_3].cac_AllowanceCharges[iterator_5].cbc_ChargeIndicator;
            targetPtr += 1;

        if(field.claims.Value.cac_InvoiceLine[iterator_3].cac_AllowanceCharges[iterator_5].cbc_AllowanceChargeReason!= null)
        {
            int strlen_7 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_AllowanceCharges[iterator_5].cbc_AllowanceChargeReason.Length * 2;
            *(int*)targetPtr = strlen_7;
            targetPtr += sizeof(int);
            fixed(char* pstr_7 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_AllowanceCharges[iterator_5].cbc_AllowanceChargeReason)
            {
                Memory.Copy(pstr_7, targetPtr, strlen_7);
                targetPtr += strlen_7;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            {

        if(field.claims.Value.cac_InvoiceLine[iterator_3].cac_AllowanceCharges[iterator_5].cbc_Amount._CurrencyID!= null)
        {
            int strlen_8 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_AllowanceCharges[iterator_5].cbc_Amount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_8;
            targetPtr += sizeof(int);
            fixed(char* pstr_8 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_AllowanceCharges[iterator_5].cbc_Amount._CurrencyID)
            {
                Memory.Copy(pstr_8, targetPtr, strlen_8);
                targetPtr += strlen_8;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.claims.Value.cac_InvoiceLine[iterator_3].cac_AllowanceCharges[iterator_5].cbc_Amount.amount;
            targetPtr += 8;

            }
            }
        }
    }
*(int*)storedPtr_5 = (int)(targetPtr - storedPtr_5 - 4);

}

            {

            {

        if(field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_7 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cbc_TaxAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_7;
            targetPtr += sizeof(int);
            fixed(char* pstr_7 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cbc_TaxAmount._CurrencyID)
            {
                Memory.Copy(pstr_7, targetPtr, strlen_7);
                targetPtr += strlen_7;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cbc_TaxAmount.amount;
            targetPtr += 8;

            }
{
byte *storedPtr_6 = targetPtr;

    targetPtr += sizeof(int);
    if(field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals!= null)
    {
        for(int iterator_6 = 0;iterator_6<field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals.Count;++iterator_6)
        {

            {

            {

        if(field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cbc_TaxableAmount._CurrencyID!= null)
        {
            int strlen_9 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cbc_TaxableAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_9;
            targetPtr += sizeof(int);
            fixed(char* pstr_9 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cbc_TaxableAmount._CurrencyID)
            {
                Memory.Copy(pstr_9, targetPtr, strlen_9);
                targetPtr += strlen_9;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cbc_TaxableAmount.amount;
            targetPtr += 8;

            }
            {

        if(field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_9 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cbc_TaxAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_9;
            targetPtr += sizeof(int);
            fixed(char* pstr_9 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cbc_TaxAmount._CurrencyID)
            {
                Memory.Copy(pstr_9, targetPtr, strlen_9);
                targetPtr += strlen_9;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cbc_TaxAmount.amount;
            targetPtr += 8;

            }
            {

            {
            byte* optheader_9 = targetPtr;
            *(optheader_9 + 0) = 0x00;            targetPtr += 1;

        if(field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cac_TaxCategory.cbc_ID._schemeID!= null)
        {
            int strlen_10 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cac_TaxCategory.cbc_ID._schemeID.Length * 2;
            *(int*)targetPtr = strlen_10;
            targetPtr += sizeof(int);
            fixed(char* pstr_10 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cac_TaxCategory.cbc_ID._schemeID)
            {
                Memory.Copy(pstr_10, targetPtr, strlen_10);
                targetPtr += strlen_10;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
            {

        if(field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_10 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cac_TaxCategory.cbc_ID._schemeAgencyID.Length * 2;
            *(int*)targetPtr = strlen_10;
            targetPtr += sizeof(int);
            fixed(char* pstr_10 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cac_TaxCategory.cbc_ID._schemeAgencyID)
            {
                Memory.Copy(pstr_10, targetPtr, strlen_10);
                targetPtr += strlen_10;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_9 + 0) |= 0x01;
            }

        if(field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cac_TaxCategory.cbc_ID.code!= null)
        {
            int strlen_10 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cac_TaxCategory.cbc_ID.code.Length * 2;
            *(int*)targetPtr = strlen_10;
            targetPtr += sizeof(int);
            fixed(char* pstr_10 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cac_TaxCategory.cbc_ID.code)
            {
                Memory.Copy(pstr_10, targetPtr, strlen_10);
                targetPtr += strlen_10;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }            *(double*)targetPtr = field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cac_TaxCategory.cbc_Percent;
            targetPtr += 8;

            {

            {
            byte* optheader_10 = targetPtr;
            *(optheader_10 + 0) = 0x00;            targetPtr += 1;

        if(field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID!= null)
        {
            int strlen_11 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID.Length * 2;
            *(int*)targetPtr = strlen_11;
            targetPtr += sizeof(int);
            fixed(char* pstr_11 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID)
            {
                Memory.Copy(pstr_11, targetPtr, strlen_11);
                targetPtr += strlen_11;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
            {

        if(field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_11 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID.Length * 2;
            *(int*)targetPtr = strlen_11;
            targetPtr += sizeof(int);
            fixed(char* pstr_11 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID)
            {
                Memory.Copy(pstr_11, targetPtr, strlen_11);
                targetPtr += strlen_11;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_10 + 0) |= 0x01;
            }

        if(field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cac_TaxCategory.cac_TaxScheme.cbc_ID.code!= null)
        {
            int strlen_11 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cac_TaxCategory.cac_TaxScheme.cbc_ID.code.Length * 2;
            *(int*)targetPtr = strlen_11;
            targetPtr += sizeof(int);
            fixed(char* pstr_11 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_TaxTotal.cac_TaxSubtotals[iterator_6].cac_TaxCategory.cac_TaxScheme.cbc_ID.code)
            {
                Memory.Copy(pstr_11, targetPtr, strlen_11);
                targetPtr += strlen_11;
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
*(int*)storedPtr_6 = (int)(targetPtr - storedPtr_6 - 4);

}

            }
        if(field.claims.Value.cac_InvoiceLine[iterator_3].cac_ItemUdid!= null)
        {
            int strlen_5 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_ItemUdid.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_ItemUdid)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            {

            {

        if(field.claims.Value.cac_InvoiceLine[iterator_3].cac_Price.cbc_PriceAmount._CurrencyID!= null)
        {
            int strlen_7 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_Price.cbc_PriceAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_7;
            targetPtr += sizeof(int);
            fixed(char* pstr_7 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_Price.cbc_PriceAmount._CurrencyID)
            {
                Memory.Copy(pstr_7, targetPtr, strlen_7);
                targetPtr += strlen_7;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.claims.Value.cac_InvoiceLine[iterator_3].cac_Price.cbc_PriceAmount.amount;
            targetPtr += 8;

            }
            {

        if(field.claims.Value.cac_InvoiceLine[iterator_3].cac_Price.cbc_BaseQuantity._unitCode!= null)
        {
            int strlen_7 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_Price.cbc_BaseQuantity._unitCode.Length * 2;
            *(int*)targetPtr = strlen_7;
            targetPtr += sizeof(int);
            fixed(char* pstr_7 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_Price.cbc_BaseQuantity._unitCode)
            {
                Memory.Copy(pstr_7, targetPtr, strlen_7);
                targetPtr += strlen_7;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = field.claims.Value.cac_InvoiceLine[iterator_3].cac_Price.cbc_BaseQuantity.quantity;
            targetPtr += 8;

            }
            {
            *(bool*)targetPtr = field.claims.Value.cac_InvoiceLine[iterator_3].cac_Price.cac_AllowanceCharge.cbc_ChargeIndicator;
            targetPtr += 1;

        if(field.claims.Value.cac_InvoiceLine[iterator_3].cac_Price.cac_AllowanceCharge.cbc_AllowanceChargeReason!= null)
        {
            int strlen_7 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_Price.cac_AllowanceCharge.cbc_AllowanceChargeReason.Length * 2;
            *(int*)targetPtr = strlen_7;
            targetPtr += sizeof(int);
            fixed(char* pstr_7 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_Price.cac_AllowanceCharge.cbc_AllowanceChargeReason)
            {
                Memory.Copy(pstr_7, targetPtr, strlen_7);
                targetPtr += strlen_7;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            {

        if(field.claims.Value.cac_InvoiceLine[iterator_3].cac_Price.cac_AllowanceCharge.cbc_Amount._CurrencyID!= null)
        {
            int strlen_8 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_Price.cac_AllowanceCharge.cbc_Amount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_8;
            targetPtr += sizeof(int);
            fixed(char* pstr_8 = field.claims.Value.cac_InvoiceLine[iterator_3].cac_Price.cac_AllowanceCharge.cbc_Amount._CurrencyID)
            {
                Memory.Copy(pstr_8, targetPtr, strlen_8);
                targetPtr += strlen_8;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.claims.Value.cac_InvoiceLine[iterator_3].cac_Price.cac_AllowanceCharge.cbc_Amount.amount;
            targetPtr += 8;

            }
            }
            }
            }
        }
    }
*(int*)storedPtr_3 = (int)(targetPtr - storedPtr_3 - 4);

}

            }*(optheader_1 + 0) |= 0x01;
            }
            if( field.encryptedclaims!= null)
            {

            {

        if(field.encryptedclaims.Value.ciphertext16!= null)
        {
            int strlen_3 = field.encryptedclaims.Value.ciphertext16.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.encryptedclaims.Value.ciphertext16)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.encryptedclaims.Value.alg!= null)
        {
            int strlen_3 = field.encryptedclaims.Value.alg.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.encryptedclaims.Value.alg)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.encryptedclaims.Value.key!= null)
        {
            int strlen_3 = field.encryptedclaims.Value.key.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.encryptedclaims.Value.key)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }*(optheader_1 + 0) |= 0x02;
            }

            }UBL21_Invoice2_Content_Accessor ret;
            
            ret = new UBL21_Invoice2_Content_Accessor(tmpcellptr, null);
            
            return ret;
        }
        
        public static bool operator ==(UBL21_Invoice2_Content_Accessor a, UBL21_Invoice2_Content_Accessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            byte* targetPtr = a.m_ptr;
            {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
{targetPtr += *(int*)targetPtr + sizeof(int);}{            byte* optheader_5 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_5 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 8;
{{            byte* optheader_9 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_9 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);}}targetPtr += *(int*)targetPtr + sizeof(int);{{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);}{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}targetPtr += *(int*)targetPtr + sizeof(int);}
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}
            int lengthA = (int)(targetPtr - a.m_ptr);
            targetPtr = b.m_ptr;
            {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
{targetPtr += *(int*)targetPtr + sizeof(int);}{            byte* optheader_5 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_5 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 8;
{{            byte* optheader_9 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_9 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);}}targetPtr += *(int*)targetPtr + sizeof(int);{{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);}{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}targetPtr += *(int*)targetPtr + sizeof(int);}
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}
            int lengthB = (int)(targetPtr - b.m_ptr);
            if(lengthA != lengthB) return false;
            return Memory.Compare(a.m_ptr,b.m_ptr,lengthA);
        }
        public static bool operator != (UBL21_Invoice2_Content_Accessor a, UBL21_Invoice2_Content_Accessor b)
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
