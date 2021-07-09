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
    /// A .NET runtime object representation of TRACredentialEnvelope defined in TSL.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct TRACredentialEnvelope
    {
        
        ///<summary>
        ///Initializes a new instance of TRACredentialEnvelope with the specified parameters.
        ///</summary>
        public TRACredentialEnvelope(string hashedThumbprint64 = default(string),string signedHashSignature64 = default(string),string notaryStamp = default(string),List<string> comments = default(List<string>))
        {
            
            this.hashedThumbprint64 = hashedThumbprint64;
            
            this.signedHashSignature64 = signedHashSignature64;
            
            this.notaryStamp = notaryStamp;
            
            this.comments = comments;
            
        }
        
        public static bool operator ==(TRACredentialEnvelope a, TRACredentialEnvelope b)
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
                
                (a.hashedThumbprint64 == b.hashedThumbprint64)
                &&
                (a.signedHashSignature64 == b.signedHashSignature64)
                &&
                (a.notaryStamp == b.notaryStamp)
                &&
                (a.comments == b.comments)
                
                ;
            
        }
        public static bool operator !=(TRACredentialEnvelope a, TRACredentialEnvelope b)
        {
            return !(a == b);
        }
        
        public string hashedThumbprint64;
        
        public string signedHashSignature64;
        
        public string notaryStamp;
        
        public List<string> comments;
        
        /// <summary>
        /// Converts the string representation of a TRACredentialEnvelope to its
        /// struct equivalent. A return value indicates whether the 
        /// operation succeeded.
        /// </summary>
        /// <param name="input">A string to convert.</param>
        /// <param name="value">
        /// When this method returns, contains the struct equivalent of the value contained 
        /// in input, if the conversion succeeded, or default(TRACredentialEnvelope) if the conversion
        /// failed. The conversion fails if the input parameter is null or String.Empty, or is 
        /// not of the correct format. This parameter is passed uninitialized. 
        /// </param>
        /// <returns>True if input was converted successfully; otherwise, false.</returns>
        public unsafe static bool TryParse(string input, out TRACredentialEnvelope value)
        {
            try
            {
                value = Newtonsoft.Json.JsonConvert.DeserializeObject<TRACredentialEnvelope>(input);
                return true;
            }
            catch { value = default(TRACredentialEnvelope); return false; }
        }
        public static TRACredentialEnvelope Parse(string input)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TRACredentialEnvelope>(input);
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
    /// Provides in-place operations of TRACredentialEnvelope defined in TSL.
    /// </summary>
    public unsafe partial class TRACredentialEnvelope_Accessor : IAccessor
    {
        ///<summary>
        ///The pointer to the content of the object.
        ///</summary>
        internal byte* m_ptr;
        internal long m_cellId;
        internal unsafe TRACredentialEnvelope_Accessor(byte* _CellPtr
            
            , ResizeFunctionDelegate func
            )
        {
            m_ptr = _CellPtr;
            
            ResizeFunction = func;
                    hashedThumbprint64_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        signedHashSignature64_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        notaryStamp_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        comments_Accessor_Field = new StringAccessorListAccessor(null,
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
                    
                    "hashedThumbprint64"
                    ,
                    "signedHashSignature64"
                    ,
                    "notaryStamp"
                    ,
                    "comments"
                    
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

                if ((0 != (*(optheader_0 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_0 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_0 + 0) & 0x04)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_0 + 0) & 0x08)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
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

                if ((0 != (*(optheader_0 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_0 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_0 + 0) & 0x04)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_0 + 0) & 0x08)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
            int size = (int)(targetPtr - m_ptr);
            return size;
        }
        public ResizeFunctionDelegate ResizeFunction { get; set; }
        #endregion
        StringAccessor hashedThumbprint64_Accessor_Field;
        
        ///<summary>
        ///Represents the presence of the optional field hashedThumbprint64.
        ///</summary>
        public bool Contains_hashedThumbprint64
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
        ///Removes the optional field hashedThumbprint64 from the object being operated.
        ///</summary>
        public unsafe void Remove_hashedThumbprint64()
        {
            if (!this.Contains_hashedThumbprint64)
            {
                throw new Exception("Optional field hashedThumbprint64 doesn't exist for current cell.");
            }
            this.Contains_hashedThumbprint64 = false;
            byte* targetPtr = m_ptr;
            {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
}
            byte* startPtr = targetPtr;
            targetPtr += *(int*)targetPtr + sizeof(int);
            this.ResizeFunction(startPtr, 0, (int)(startPtr - targetPtr));
        }
        
        ///<summary>
        ///Provides in-place access to the object field hashedThumbprint64.
        ///</summary>
        public unsafe StringAccessor hashedThumbprint64
        {
            get
            {
                
                if (!this.Contains_hashedThumbprint64)
                {
                    throw new Exception("Optional field hashedThumbprint64 doesn't exist for current cell.");
                }
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
}hashedThumbprint64_Accessor_Field.m_ptr = targetPtr + 4;
                hashedThumbprint64_Accessor_Field.m_cellId = this.m_cellId;
                return hashedThumbprint64_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                hashedThumbprint64_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
}
                bool creatingOptionalField = (!this.Contains_hashedThumbprint64);
                if (creatingOptionalField)
                {
                    this.Contains_hashedThumbprint64 = true;
                    
                int length = *(int*)(value.m_ptr - 4);
                if (value.m_cellId != hashedThumbprint64_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    hashedThumbprint64_Accessor_Field.m_ptr = hashedThumbprint64_Accessor_Field.ResizeFunction(targetPtr, 0, length + sizeof(int));
                    Memory.Copy(value.m_ptr - 4, hashedThumbprint64_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        hashedThumbprint64_Accessor_Field.m_ptr = hashedThumbprint64_Accessor_Field.ResizeFunction(targetPtr, 0, length + sizeof(int));
                        Memory.Copy(tmpcellptr, hashedThumbprint64_Accessor_Field.m_ptr, length + 4);
                    }
                }

                }
                else
                {
                    
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != hashedThumbprint64_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    hashedThumbprint64_Accessor_Field.m_ptr = hashedThumbprint64_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, hashedThumbprint64_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        hashedThumbprint64_Accessor_Field.m_ptr = hashedThumbprint64_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, hashedThumbprint64_Accessor_Field.m_ptr, length + 4);
                    }
                }

                }
                
            }
        }
        StringAccessor signedHashSignature64_Accessor_Field;
        
        ///<summary>
        ///Represents the presence of the optional field signedHashSignature64.
        ///</summary>
        public bool Contains_signedHashSignature64
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
        ///Removes the optional field signedHashSignature64 from the object being operated.
        ///</summary>
        public unsafe void Remove_signedHashSignature64()
        {
            if (!this.Contains_signedHashSignature64)
            {
                throw new Exception("Optional field signedHashSignature64 doesn't exist for current cell.");
            }
            this.Contains_signedHashSignature64 = false;
            byte* targetPtr = m_ptr;
            {            byte* optheader_1 = targetPtr;
            targetPtr += 1;

                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
            byte* startPtr = targetPtr;
            targetPtr += *(int*)targetPtr + sizeof(int);
            this.ResizeFunction(startPtr, 0, (int)(startPtr - targetPtr));
        }
        
        ///<summary>
        ///Provides in-place access to the object field signedHashSignature64.
        ///</summary>
        public unsafe StringAccessor signedHashSignature64
        {
            get
            {
                
                if (!this.Contains_signedHashSignature64)
                {
                    throw new Exception("Optional field signedHashSignature64 doesn't exist for current cell.");
                }
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;

                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}signedHashSignature64_Accessor_Field.m_ptr = targetPtr + 4;
                signedHashSignature64_Accessor_Field.m_cellId = this.m_cellId;
                return signedHashSignature64_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                signedHashSignature64_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;

                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
                bool creatingOptionalField = (!this.Contains_signedHashSignature64);
                if (creatingOptionalField)
                {
                    this.Contains_signedHashSignature64 = true;
                    
                int length = *(int*)(value.m_ptr - 4);
                if (value.m_cellId != signedHashSignature64_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    signedHashSignature64_Accessor_Field.m_ptr = signedHashSignature64_Accessor_Field.ResizeFunction(targetPtr, 0, length + sizeof(int));
                    Memory.Copy(value.m_ptr - 4, signedHashSignature64_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        signedHashSignature64_Accessor_Field.m_ptr = signedHashSignature64_Accessor_Field.ResizeFunction(targetPtr, 0, length + sizeof(int));
                        Memory.Copy(tmpcellptr, signedHashSignature64_Accessor_Field.m_ptr, length + 4);
                    }
                }

                }
                else
                {
                    
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != signedHashSignature64_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    signedHashSignature64_Accessor_Field.m_ptr = signedHashSignature64_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, signedHashSignature64_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        signedHashSignature64_Accessor_Field.m_ptr = signedHashSignature64_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, signedHashSignature64_Accessor_Field.m_ptr, length + 4);
                    }
                }

                }
                
            }
        }
        StringAccessor notaryStamp_Accessor_Field;
        
        ///<summary>
        ///Represents the presence of the optional field notaryStamp.
        ///</summary>
        public bool Contains_notaryStamp
        {
            get
            {
                unchecked
                {
                    return (0 != (*(this.m_ptr + 0) & 0x04)) ;
                }
            }
            internal set
            {
                unchecked
                {
                    if (value)
                    {
                        *(this.m_ptr + 0) |= 0x04;
                    }
                    else
                    {
                        *(this.m_ptr + 0) &= 0xFB;
                    }
                }
            }
        }
        ///<summary>
        ///Removes the optional field notaryStamp from the object being operated.
        ///</summary>
        public unsafe void Remove_notaryStamp()
        {
            if (!this.Contains_notaryStamp)
            {
                throw new Exception("Optional field notaryStamp doesn't exist for current cell.");
            }
            this.Contains_notaryStamp = false;
            byte* targetPtr = m_ptr;
            {            byte* optheader_1 = targetPtr;
            targetPtr += 1;

                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
            byte* startPtr = targetPtr;
            targetPtr += *(int*)targetPtr + sizeof(int);
            this.ResizeFunction(startPtr, 0, (int)(startPtr - targetPtr));
        }
        
        ///<summary>
        ///Provides in-place access to the object field notaryStamp.
        ///</summary>
        public unsafe StringAccessor notaryStamp
        {
            get
            {
                
                if (!this.Contains_notaryStamp)
                {
                    throw new Exception("Optional field notaryStamp doesn't exist for current cell.");
                }
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;

                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}notaryStamp_Accessor_Field.m_ptr = targetPtr + 4;
                notaryStamp_Accessor_Field.m_cellId = this.m_cellId;
                return notaryStamp_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                notaryStamp_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;

                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
                bool creatingOptionalField = (!this.Contains_notaryStamp);
                if (creatingOptionalField)
                {
                    this.Contains_notaryStamp = true;
                    
                int length = *(int*)(value.m_ptr - 4);
                if (value.m_cellId != notaryStamp_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    notaryStamp_Accessor_Field.m_ptr = notaryStamp_Accessor_Field.ResizeFunction(targetPtr, 0, length + sizeof(int));
                    Memory.Copy(value.m_ptr - 4, notaryStamp_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        notaryStamp_Accessor_Field.m_ptr = notaryStamp_Accessor_Field.ResizeFunction(targetPtr, 0, length + sizeof(int));
                        Memory.Copy(tmpcellptr, notaryStamp_Accessor_Field.m_ptr, length + 4);
                    }
                }

                }
                else
                {
                    
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != notaryStamp_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    notaryStamp_Accessor_Field.m_ptr = notaryStamp_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, notaryStamp_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        notaryStamp_Accessor_Field.m_ptr = notaryStamp_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, notaryStamp_Accessor_Field.m_ptr, length + 4);
                    }
                }

                }
                
            }
        }
        StringAccessorListAccessor comments_Accessor_Field;
        
        ///<summary>
        ///Represents the presence of the optional field comments.
        ///</summary>
        public bool Contains_comments
        {
            get
            {
                unchecked
                {
                    return (0 != (*(this.m_ptr + 0) & 0x08)) ;
                }
            }
            internal set
            {
                unchecked
                {
                    if (value)
                    {
                        *(this.m_ptr + 0) |= 0x08;
                    }
                    else
                    {
                        *(this.m_ptr + 0) &= 0xF7;
                    }
                }
            }
        }
        ///<summary>
        ///Removes the optional field comments from the object being operated.
        ///</summary>
        public unsafe void Remove_comments()
        {
            if (!this.Contains_comments)
            {
                throw new Exception("Optional field comments doesn't exist for current cell.");
            }
            this.Contains_comments = false;
            byte* targetPtr = m_ptr;
            {            byte* optheader_1 = targetPtr;
            targetPtr += 1;

                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x04)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
            byte* startPtr = targetPtr;
            targetPtr += *(int*)targetPtr + sizeof(int);
            this.ResizeFunction(startPtr, 0, (int)(startPtr - targetPtr));
        }
        
        ///<summary>
        ///Provides in-place access to the object field comments.
        ///</summary>
        public unsafe StringAccessorListAccessor comments
        {
            get
            {
                
                if (!this.Contains_comments)
                {
                    throw new Exception("Optional field comments doesn't exist for current cell.");
                }
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;

                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x04)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}comments_Accessor_Field.m_ptr = targetPtr + 4;
                comments_Accessor_Field.m_cellId = this.m_cellId;
                return comments_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                comments_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;

                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x04)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
                bool creatingOptionalField = (!this.Contains_comments);
                if (creatingOptionalField)
                {
                    this.Contains_comments = true;
                    
                int length = *(int*)(value.m_ptr - 4);
                if (value.m_cellId != comments_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    comments_Accessor_Field.m_ptr = comments_Accessor_Field.ResizeFunction(targetPtr, 0, length + sizeof(int));
                    Memory.Copy(value.m_ptr - 4, comments_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        comments_Accessor_Field.m_ptr = comments_Accessor_Field.ResizeFunction(targetPtr, 0, length + sizeof(int));
                        Memory.Copy(tmpcellptr, comments_Accessor_Field.m_ptr, length + 4);
                    }
                }

                }
                else
                {
                    
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != comments_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    comments_Accessor_Field.m_ptr = comments_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, comments_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        comments_Accessor_Field.m_ptr = comments_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, comments_Accessor_Field.m_ptr, length + 4);
                    }
                }

                }
                
            }
        }
        
        public static unsafe implicit operator TRACredentialEnvelope(TRACredentialEnvelope_Accessor accessor)
        {
            string _hashedThumbprint64 = default(string);
            if (accessor.Contains_hashedThumbprint64)
            {
                
                _hashedThumbprint64 = accessor.hashedThumbprint64;
                
            }
            string _signedHashSignature64 = default(string);
            if (accessor.Contains_signedHashSignature64)
            {
                
                _signedHashSignature64 = accessor.signedHashSignature64;
                
            }
            string _notaryStamp = default(string);
            if (accessor.Contains_notaryStamp)
            {
                
                _notaryStamp = accessor.notaryStamp;
                
            }
            List<string> _comments = default(List<string>);
            if (accessor.Contains_comments)
            {
                
                _comments = accessor.comments;
                
            }
            
            return new TRACredentialEnvelope(
                
                        _hashedThumbprint64 ,
                        _signedHashSignature64 ,
                        _notaryStamp ,
                        _comments 
                );
        }
        
        public unsafe static implicit operator TRACredentialEnvelope_Accessor(TRACredentialEnvelope field)
        {
            byte* targetPtr = null;
            
            {
            targetPtr += 1;
            if( field.hashedThumbprint64!= null)
            {

        if(field.hashedThumbprint64!= null)
        {
            int strlen_2 = field.hashedThumbprint64.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( field.signedHashSignature64!= null)
            {

        if(field.signedHashSignature64!= null)
        {
            int strlen_2 = field.signedHashSignature64.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( field.notaryStamp!= null)
            {

        if(field.notaryStamp!= null)
        {
            int strlen_2 = field.notaryStamp.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( field.comments!= null)
            {

{

    targetPtr += sizeof(int);
    if(field.comments!= null)
    {
        for(int iterator_2 = 0;iterator_2<field.comments.Count;++iterator_2)
        {

        if(field.comments[iterator_2]!= null)
        {
            int strlen_3 = field.comments[iterator_2].Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
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
            byte* optheader_1 = targetPtr;
            *(optheader_1 + 0) = 0x00;            targetPtr += 1;
            if( field.hashedThumbprint64!= null)
            {

        if(field.hashedThumbprint64!= null)
        {
            int strlen_2 = field.hashedThumbprint64.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.hashedThumbprint64)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_1 + 0) |= 0x01;
            }
            if( field.signedHashSignature64!= null)
            {

        if(field.signedHashSignature64!= null)
        {
            int strlen_2 = field.signedHashSignature64.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.signedHashSignature64)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_1 + 0) |= 0x02;
            }
            if( field.notaryStamp!= null)
            {

        if(field.notaryStamp!= null)
        {
            int strlen_2 = field.notaryStamp.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.notaryStamp)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_1 + 0) |= 0x04;
            }
            if( field.comments!= null)
            {

{
byte *storedPtr_2 = targetPtr;

    targetPtr += sizeof(int);
    if(field.comments!= null)
    {
        for(int iterator_2 = 0;iterator_2<field.comments.Count;++iterator_2)
        {

        if(field.comments[iterator_2]!= null)
        {
            int strlen_3 = field.comments[iterator_2].Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.comments[iterator_2])
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
*(optheader_1 + 0) |= 0x08;
            }

            }TRACredentialEnvelope_Accessor ret;
            
            ret = new TRACredentialEnvelope_Accessor(tmpcellptr, null);
            
            return ret;
        }
        
        public static bool operator ==(TRACredentialEnvelope_Accessor a, TRACredentialEnvelope_Accessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            byte* targetPtr = a.m_ptr;
            {            byte* optheader_1 = targetPtr;
            targetPtr += 1;

                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x04)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x08)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
            int lengthA = (int)(targetPtr - a.m_ptr);
            targetPtr = b.m_ptr;
            {            byte* optheader_1 = targetPtr;
            targetPtr += 1;

                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x04)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x08)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
            int lengthB = (int)(targetPtr - b.m_ptr);
            if(lengthA != lengthB) return false;
            return Memory.Compare(a.m_ptr,b.m_ptr,lengthA);
        }
        public static bool operator != (TRACredentialEnvelope_Accessor a, TRACredentialEnvelope_Accessor b)
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
