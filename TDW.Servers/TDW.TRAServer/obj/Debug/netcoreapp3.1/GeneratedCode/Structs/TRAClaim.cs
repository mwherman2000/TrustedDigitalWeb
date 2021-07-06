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
    /// A .NET runtime object representation of TRAClaim defined in TSL.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct TRAClaim
    {
        
        ///<summary>
        ///Initializes a new instance of TRAClaim with the specified parameters.
        ///</summary>
        public TRAClaim(string key = default(string),string value = default(string),List<TRAKeyValuePair> attribute = default(List<TRAKeyValuePair>),List<List<TRAKeyValuePair>> attributes = default(List<List<TRAKeyValuePair>>))
        {
            
            this.key = key;
            
            this.value = value;
            
            this.attribute = attribute;
            
            this.attributes = attributes;
            
        }
        
        public static bool operator ==(TRAClaim a, TRAClaim b)
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
                
                (a.key == b.key)
                &&
                (a.value == b.value)
                &&
                (a.attribute == b.attribute)
                &&
                (a.attributes == b.attributes)
                
                ;
            
        }
        public static bool operator !=(TRAClaim a, TRAClaim b)
        {
            return !(a == b);
        }
        
        public string key;
        
        public string value;
        
        public List<TRAKeyValuePair> attribute;
        
        public List<List<TRAKeyValuePair>> attributes;
        
        /// <summary>
        /// Converts the string representation of a TRAClaim to its
        /// struct equivalent. A return value indicates whether the 
        /// operation succeeded.
        /// </summary>
        /// <param name="input">A string to convert.</param>
        /// <param name="value">
        /// When this method returns, contains the struct equivalent of the value contained 
        /// in input, if the conversion succeeded, or default(TRAClaim) if the conversion
        /// failed. The conversion fails if the input parameter is null or String.Empty, or is 
        /// not of the correct format. This parameter is passed uninitialized. 
        /// </param>
        /// <returns>True if input was converted successfully; otherwise, false.</returns>
        public unsafe static bool TryParse(string input, out TRAClaim value)
        {
            try
            {
                value = Newtonsoft.Json.JsonConvert.DeserializeObject<TRAClaim>(input);
                return true;
            }
            catch { value = default(TRAClaim); return false; }
        }
        public static TRAClaim Parse(string input)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TRAClaim>(input);
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
    /// Provides in-place operations of TRAClaim defined in TSL.
    /// </summary>
    public unsafe partial class TRAClaim_Accessor : IAccessor
    {
        ///<summary>
        ///The pointer to the content of the object.
        ///</summary>
        internal byte* m_ptr;
        internal long m_cellId;
        internal unsafe TRAClaim_Accessor(byte* _CellPtr
            
            , ResizeFunctionDelegate func
            )
        {
            m_ptr = _CellPtr;
            
            ResizeFunction = func;
                    key_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        value_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        attribute_Accessor_Field = new TRAKeyValuePair_AccessorListAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        attributes_Accessor_Field = new TRAKeyValuePair_AccessorListAccessorListAccessor(null,
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
                    
                    "value"
                    ,
                    "attribute"
                    ,
                    "attributes"
                    
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
targetPtr += *(int*)targetPtr + sizeof(int);
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
targetPtr += *(int*)targetPtr + sizeof(int);
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
}
            int size = (int)(targetPtr - m_ptr);
            return size;
        }
        public ResizeFunctionDelegate ResizeFunction { get; set; }
        #endregion
        StringAccessor key_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field key.
        ///</summary>
        public unsafe StringAccessor key
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
}key_Accessor_Field.m_ptr = targetPtr + 4;
                key_Accessor_Field.m_cellId = this.m_cellId;
                return key_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                key_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != key_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    key_Accessor_Field.m_ptr = key_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, key_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        key_Accessor_Field.m_ptr = key_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, key_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        StringAccessor value_Accessor_Field;
        
        ///<summary>
        ///Represents the presence of the optional field value.
        ///</summary>
        public bool Contains_value
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
        ///Removes the optional field value from the object being operated.
        ///</summary>
        public unsafe void Remove_value()
        {
            if (!this.Contains_value)
            {
                throw new Exception("Optional field value doesn't exist for current cell.");
            }
            this.Contains_value = false;
            byte* targetPtr = m_ptr;
            {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}
            byte* startPtr = targetPtr;
            targetPtr += *(int*)targetPtr + sizeof(int);
            this.ResizeFunction(startPtr, 0, (int)(startPtr - targetPtr));
        }
        
        ///<summary>
        ///Provides in-place access to the object field value.
        ///</summary>
        public unsafe StringAccessor value
        {
            get
            {
                
                if (!this.Contains_value)
                {
                    throw new Exception("Optional field value doesn't exist for current cell.");
                }
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}value_Accessor_Field.m_ptr = targetPtr + 4;
                value_Accessor_Field.m_cellId = this.m_cellId;
                return value_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                value_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}
                bool creatingOptionalField = (!this.Contains_value);
                if (creatingOptionalField)
                {
                    this.Contains_value = true;
                    
                int length = *(int*)(value.m_ptr - 4);
                if (value.m_cellId != value_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    value_Accessor_Field.m_ptr = value_Accessor_Field.ResizeFunction(targetPtr, 0, length + sizeof(int));
                    Memory.Copy(value.m_ptr - 4, value_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        value_Accessor_Field.m_ptr = value_Accessor_Field.ResizeFunction(targetPtr, 0, length + sizeof(int));
                        Memory.Copy(tmpcellptr, value_Accessor_Field.m_ptr, length + 4);
                    }
                }

                }
                else
                {
                    
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != value_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    value_Accessor_Field.m_ptr = value_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, value_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        value_Accessor_Field.m_ptr = value_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, value_Accessor_Field.m_ptr, length + 4);
                    }
                }

                }
                
            }
        }
        TRAKeyValuePair_AccessorListAccessor attribute_Accessor_Field;
        
        ///<summary>
        ///Represents the presence of the optional field attribute.
        ///</summary>
        public bool Contains_attribute
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
        ///Removes the optional field attribute from the object being operated.
        ///</summary>
        public unsafe void Remove_attribute()
        {
            if (!this.Contains_attribute)
            {
                throw new Exception("Optional field attribute doesn't exist for current cell.");
            }
            this.Contains_attribute = false;
            byte* targetPtr = m_ptr;
            {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
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
        ///Provides in-place access to the object field attribute.
        ///</summary>
        public unsafe TRAKeyValuePair_AccessorListAccessor attribute
        {
            get
            {
                
                if (!this.Contains_attribute)
                {
                    throw new Exception("Optional field attribute doesn't exist for current cell.");
                }
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}attribute_Accessor_Field.m_ptr = targetPtr + 4;
                attribute_Accessor_Field.m_cellId = this.m_cellId;
                return attribute_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                attribute_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
                bool creatingOptionalField = (!this.Contains_attribute);
                if (creatingOptionalField)
                {
                    this.Contains_attribute = true;
                    
                int length = *(int*)(value.m_ptr - 4);
                if (value.m_cellId != attribute_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    attribute_Accessor_Field.m_ptr = attribute_Accessor_Field.ResizeFunction(targetPtr, 0, length + sizeof(int));
                    Memory.Copy(value.m_ptr - 4, attribute_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        attribute_Accessor_Field.m_ptr = attribute_Accessor_Field.ResizeFunction(targetPtr, 0, length + sizeof(int));
                        Memory.Copy(tmpcellptr, attribute_Accessor_Field.m_ptr, length + 4);
                    }
                }

                }
                else
                {
                    
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != attribute_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    attribute_Accessor_Field.m_ptr = attribute_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, attribute_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        attribute_Accessor_Field.m_ptr = attribute_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, attribute_Accessor_Field.m_ptr, length + 4);
                    }
                }

                }
                
            }
        }
        TRAKeyValuePair_AccessorListAccessorListAccessor attributes_Accessor_Field;
        
        ///<summary>
        ///Represents the presence of the optional field attributes.
        ///</summary>
        public bool Contains_attributes
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
        ///Removes the optional field attributes from the object being operated.
        ///</summary>
        public unsafe void Remove_attributes()
        {
            if (!this.Contains_attributes)
            {
                throw new Exception("Optional field attributes doesn't exist for current cell.");
            }
            this.Contains_attributes = false;
            byte* targetPtr = m_ptr;
            {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
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
        ///Provides in-place access to the object field attributes.
        ///</summary>
        public unsafe TRAKeyValuePair_AccessorListAccessorListAccessor attributes
        {
            get
            {
                
                if (!this.Contains_attributes)
                {
                    throw new Exception("Optional field attributes doesn't exist for current cell.");
                }
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}attributes_Accessor_Field.m_ptr = targetPtr + 4;
                attributes_Accessor_Field.m_cellId = this.m_cellId;
                return attributes_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                attributes_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
                bool creatingOptionalField = (!this.Contains_attributes);
                if (creatingOptionalField)
                {
                    this.Contains_attributes = true;
                    
                int length = *(int*)(value.m_ptr - 4);
                if (value.m_cellId != attributes_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    attributes_Accessor_Field.m_ptr = attributes_Accessor_Field.ResizeFunction(targetPtr, 0, length + sizeof(int));
                    Memory.Copy(value.m_ptr - 4, attributes_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        attributes_Accessor_Field.m_ptr = attributes_Accessor_Field.ResizeFunction(targetPtr, 0, length + sizeof(int));
                        Memory.Copy(tmpcellptr, attributes_Accessor_Field.m_ptr, length + 4);
                    }
                }

                }
                else
                {
                    
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != attributes_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    attributes_Accessor_Field.m_ptr = attributes_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, attributes_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        attributes_Accessor_Field.m_ptr = attributes_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, attributes_Accessor_Field.m_ptr, length + 4);
                    }
                }

                }
                
            }
        }
        
        public static unsafe implicit operator TRAClaim(TRAClaim_Accessor accessor)
        {
            string _value = default(string);
            if (accessor.Contains_value)
            {
                
                _value = accessor.value;
                
            }
            List<TRAKeyValuePair> _attribute = default(List<TRAKeyValuePair>);
            if (accessor.Contains_attribute)
            {
                
                _attribute = accessor.attribute;
                
            }
            List<List<TRAKeyValuePair>> _attributes = default(List<List<TRAKeyValuePair>>);
            if (accessor.Contains_attributes)
            {
                
                _attributes = accessor.attributes;
                
            }
            
            return new TRAClaim(
                
                        accessor.key,
                        _value ,
                        _attribute ,
                        _attributes 
                );
        }
        
        public unsafe static implicit operator TRAClaim_Accessor(TRAClaim field)
        {
            byte* targetPtr = null;
            
            {
            targetPtr += 1;

        if(field.key!= null)
        {
            int strlen_2 = field.key.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( field.value!= null)
            {

        if(field.value!= null)
        {
            int strlen_2 = field.value.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( field.attribute!= null)
            {

{

    targetPtr += sizeof(int);
    if(field.attribute!= null)
    {
        for(int iterator_2 = 0;iterator_2<field.attribute.Count;++iterator_2)
        {

            {

        if(field.attribute[iterator_2].key!= null)
        {
            int strlen_4 = field.attribute[iterator_2].key.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.attribute[iterator_2].value!= null)
        {
            int strlen_4 = field.attribute[iterator_2].value.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
        }
    }

}

            }
            if( field.attributes!= null)
            {

{

    targetPtr += sizeof(int);
    if(field.attributes!= null)
    {
        for(int iterator_2 = 0;iterator_2<field.attributes.Count;++iterator_2)
        {

{

    targetPtr += sizeof(int);
    if(field.attributes[iterator_2]!= null)
    {
        for(int iterator_3 = 0;iterator_3<field.attributes[iterator_2].Count;++iterator_3)
        {

            {

        if(field.attributes[iterator_2][iterator_3].key!= null)
        {
            int strlen_5 = field.attributes[iterator_2][iterator_3].key.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.attributes[iterator_2][iterator_3].value!= null)
        {
            int strlen_5 = field.attributes[iterator_2][iterator_3].value.Length * 2;
            targetPtr += strlen_5+sizeof(int);
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

            }
            byte* tmpcellptr = BufferAllocator.AllocBuffer((int)targetPtr);
            Memory.memset(tmpcellptr, 0, (ulong)targetPtr);
            targetPtr = tmpcellptr;
            
            {
            byte* optheader_1 = targetPtr;
            *(optheader_1 + 0) = 0x00;            targetPtr += 1;

        if(field.key!= null)
        {
            int strlen_2 = field.key.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.key)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( field.value!= null)
            {

        if(field.value!= null)
        {
            int strlen_2 = field.value.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.value)
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
            if( field.attribute!= null)
            {

{
byte *storedPtr_2 = targetPtr;

    targetPtr += sizeof(int);
    if(field.attribute!= null)
    {
        for(int iterator_2 = 0;iterator_2<field.attribute.Count;++iterator_2)
        {

            {

        if(field.attribute[iterator_2].key!= null)
        {
            int strlen_4 = field.attribute[iterator_2].key.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.attribute[iterator_2].key)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.attribute[iterator_2].value!= null)
        {
            int strlen_4 = field.attribute[iterator_2].value.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.attribute[iterator_2].value)
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
    }
*(int*)storedPtr_2 = (int)(targetPtr - storedPtr_2 - 4);

}
*(optheader_1 + 0) |= 0x02;
            }
            if( field.attributes!= null)
            {

{
byte *storedPtr_2 = targetPtr;

    targetPtr += sizeof(int);
    if(field.attributes!= null)
    {
        for(int iterator_2 = 0;iterator_2<field.attributes.Count;++iterator_2)
        {

{
byte *storedPtr_3 = targetPtr;

    targetPtr += sizeof(int);
    if(field.attributes[iterator_2]!= null)
    {
        for(int iterator_3 = 0;iterator_3<field.attributes[iterator_2].Count;++iterator_3)
        {

            {

        if(field.attributes[iterator_2][iterator_3].key!= null)
        {
            int strlen_5 = field.attributes[iterator_2][iterator_3].key.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.attributes[iterator_2][iterator_3].key)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.attributes[iterator_2][iterator_3].value!= null)
        {
            int strlen_5 = field.attributes[iterator_2][iterator_3].value.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.attributes[iterator_2][iterator_3].value)
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
    }
*(int*)storedPtr_3 = (int)(targetPtr - storedPtr_3 - 4);

}

        }
    }
*(int*)storedPtr_2 = (int)(targetPtr - storedPtr_2 - 4);

}
*(optheader_1 + 0) |= 0x04;
            }

            }TRAClaim_Accessor ret;
            
            ret = new TRAClaim_Accessor(tmpcellptr, null);
            
            return ret;
        }
        
        public static bool operator ==(TRAClaim_Accessor a, TRAClaim_Accessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            byte* targetPtr = a.m_ptr;
            {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
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
            int lengthA = (int)(targetPtr - a.m_ptr);
            targetPtr = b.m_ptr;
            {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
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
            int lengthB = (int)(targetPtr - b.m_ptr);
            if(lengthA != lengthB) return false;
            return Memory.Compare(a.m_ptr,b.m_ptr,lengthA);
        }
        public static bool operator != (TRAClaim_Accessor a, TRAClaim_Accessor b)
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
