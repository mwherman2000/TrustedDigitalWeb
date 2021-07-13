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
    /// A .NET runtime object representation of Cbc_TimePeriod defined in TSL.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct Cbc_TimePeriod
    {
        
        ///<summary>
        ///Initializes a new instance of Cbc_TimePeriod with the specified parameters.
        ///</summary>
        public Cbc_TimePeriod(DateTime cbc_StartDate = default(DateTime),DateTime cbc_EndDate = default(DateTime))
        {
            
            this.cbc_StartDate = cbc_StartDate;
            
            this.cbc_EndDate = cbc_EndDate;
            
        }
        
        public static bool operator ==(Cbc_TimePeriod a, Cbc_TimePeriod b)
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
                
                (a.cbc_StartDate == b.cbc_StartDate)
                &&
                (a.cbc_EndDate == b.cbc_EndDate)
                
                ;
            
        }
        public static bool operator !=(Cbc_TimePeriod a, Cbc_TimePeriod b)
        {
            return !(a == b);
        }
        
        public DateTime cbc_StartDate;
        
        public DateTime cbc_EndDate;
        
        /// <summary>
        /// Converts the string representation of a Cbc_TimePeriod to its
        /// struct equivalent. A return value indicates whether the 
        /// operation succeeded.
        /// </summary>
        /// <param name="input">A string to convert.</param>
        /// <param name="value">
        /// When this method returns, contains the struct equivalent of the value contained 
        /// in input, if the conversion succeeded, or default(Cbc_TimePeriod) if the conversion
        /// failed. The conversion fails if the input parameter is null or String.Empty, or is 
        /// not of the correct format. This parameter is passed uninitialized. 
        /// </param>
        /// <returns>True if input was converted successfully; otherwise, false.</returns>
        public unsafe static bool TryParse(string input, out Cbc_TimePeriod value)
        {
            try
            {
                value = Newtonsoft.Json.JsonConvert.DeserializeObject<Cbc_TimePeriod>(input);
                return true;
            }
            catch { value = default(Cbc_TimePeriod); return false; }
        }
        public static Cbc_TimePeriod Parse(string input)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Cbc_TimePeriod>(input);
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
    /// Provides in-place operations of Cbc_TimePeriod defined in TSL.
    /// </summary>
    public unsafe partial class Cbc_TimePeriod_Accessor : IAccessor
    {
        ///<summary>
        ///The pointer to the content of the object.
        ///</summary>
        internal byte* m_ptr;
        internal long m_cellId;
        internal unsafe Cbc_TimePeriod_Accessor(byte* _CellPtr
            )
        {
            m_ptr = _CellPtr;
            
            ResizeFunction = (a,b,c) => { return Throw.invalid_resize_on_fixed_struct(); };
                    cbc_StartDate_Accessor_Field = new DateTimeAccessor(null);        cbc_EndDate_Accessor_Field = new DateTimeAccessor(null);
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
            {            targetPtr += 16;
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
            {            targetPtr += 16;
}
            int size = (int)(targetPtr - m_ptr);
            return size;
        }
        public ResizeFunctionDelegate ResizeFunction { get; set; }
        #endregion
        DateTimeAccessor cbc_StartDate_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cbc_StartDate.
        ///</summary>
        public unsafe DateTimeAccessor cbc_StartDate
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {}cbc_StartDate_Accessor_Field.m_ptr = targetPtr;
                cbc_StartDate_Accessor_Field.m_cellId = this.m_cellId;
                return cbc_StartDate_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cbc_StartDate_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {}                Memory.Copy(value.m_ptr, targetPtr, 8); 
            }
        }
        DateTimeAccessor cbc_EndDate_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cbc_EndDate.
        ///</summary>
        public unsafe DateTimeAccessor cbc_EndDate
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 8;
}cbc_EndDate_Accessor_Field.m_ptr = targetPtr;
                cbc_EndDate_Accessor_Field.m_cellId = this.m_cellId;
                return cbc_EndDate_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cbc_EndDate_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 8;
}                Memory.Copy(value.m_ptr, targetPtr, 8); 
            }
        }
        
        public static unsafe implicit operator Cbc_TimePeriod(Cbc_TimePeriod_Accessor accessor)
        {
            
            return new Cbc_TimePeriod(
                
                        accessor.cbc_StartDate,
                        accessor.cbc_EndDate
                );
        }
        
        public unsafe static implicit operator Cbc_TimePeriod_Accessor(Cbc_TimePeriod field)
        {
            byte* targetPtr = null;
            targetPtr += 16;

            byte* tmpcellptr = BufferAllocator.AllocBuffer((int)targetPtr);
            Memory.memset(tmpcellptr, 0, (ulong)targetPtr);
            targetPtr = tmpcellptr;
            
            {

        {
            *(long*)targetPtr = field.cbc_StartDate.ToBinary();
            targetPtr += 8;
        }

        {
            *(long*)targetPtr = field.cbc_EndDate.ToBinary();
            targetPtr += 8;
        }

            }Cbc_TimePeriod_Accessor ret;
            
            ret = new Cbc_TimePeriod_Accessor(tmpcellptr);
            
            return ret;
        }
        
        public static bool operator ==(Cbc_TimePeriod_Accessor a, Cbc_TimePeriod_Accessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            byte* targetPtr = a.m_ptr;
            {            targetPtr += 16;
}
            int lengthA = (int)(targetPtr - a.m_ptr);
            targetPtr = b.m_ptr;
            {            targetPtr += 16;
}
            int lengthB = (int)(targetPtr - b.m_ptr);
            if(lengthA != lengthB) return false;
            return Memory.Compare(a.m_ptr,b.m_ptr,lengthA);
        }
        public static bool operator != (Cbc_TimePeriod_Accessor a, Cbc_TimePeriod_Accessor b)
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
