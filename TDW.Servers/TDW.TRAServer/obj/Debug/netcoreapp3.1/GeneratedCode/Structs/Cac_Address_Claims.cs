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
    /// A .NET runtime object representation of Cac_Address_Claims defined in TSL.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct Cac_Address_Claims
    {
        
        ///<summary>
        ///Initializes a new instance of Cac_Address_Claims with the specified parameters.
        ///</summary>
        public Cac_Address_Claims(string cbc_ID = default(string),string cbc_PostBox = default(string),string cbc_StreetName = default(string),string cbc_AdditionalStreetName = default(string),string cbc_BuildingNumber = default(string),string cbc_Department = default(string),string cbc_CityName = default(string),string cbc_CountrySubentityCode = default(string),Cac_Country cbc_Country = default(Cac_Country))
        {
            
            this.cbc_ID = cbc_ID;
            
            this.cbc_PostBox = cbc_PostBox;
            
            this.cbc_StreetName = cbc_StreetName;
            
            this.cbc_AdditionalStreetName = cbc_AdditionalStreetName;
            
            this.cbc_BuildingNumber = cbc_BuildingNumber;
            
            this.cbc_Department = cbc_Department;
            
            this.cbc_CityName = cbc_CityName;
            
            this.cbc_CountrySubentityCode = cbc_CountrySubentityCode;
            
            this.cbc_Country = cbc_Country;
            
        }
        
        public static bool operator ==(Cac_Address_Claims a, Cac_Address_Claims b)
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
                
                (a.cbc_ID == b.cbc_ID)
                &&
                (a.cbc_PostBox == b.cbc_PostBox)
                &&
                (a.cbc_StreetName == b.cbc_StreetName)
                &&
                (a.cbc_AdditionalStreetName == b.cbc_AdditionalStreetName)
                &&
                (a.cbc_BuildingNumber == b.cbc_BuildingNumber)
                &&
                (a.cbc_Department == b.cbc_Department)
                &&
                (a.cbc_CityName == b.cbc_CityName)
                &&
                (a.cbc_CountrySubentityCode == b.cbc_CountrySubentityCode)
                &&
                (a.cbc_Country == b.cbc_Country)
                
                ;
            
        }
        public static bool operator !=(Cac_Address_Claims a, Cac_Address_Claims b)
        {
            return !(a == b);
        }
        
        public string cbc_ID;
        
        public string cbc_PostBox;
        
        public string cbc_StreetName;
        
        public string cbc_AdditionalStreetName;
        
        public string cbc_BuildingNumber;
        
        public string cbc_Department;
        
        public string cbc_CityName;
        
        public string cbc_CountrySubentityCode;
        
        public Cac_Country cbc_Country;
        
        /// <summary>
        /// Converts the string representation of a Cac_Address_Claims to its
        /// struct equivalent. A return value indicates whether the 
        /// operation succeeded.
        /// </summary>
        /// <param name="input">A string to convert.</param>
        /// <param name="value">
        /// When this method returns, contains the struct equivalent of the value contained 
        /// in input, if the conversion succeeded, or default(Cac_Address_Claims) if the conversion
        /// failed. The conversion fails if the input parameter is null or String.Empty, or is 
        /// not of the correct format. This parameter is passed uninitialized. 
        /// </param>
        /// <returns>True if input was converted successfully; otherwise, false.</returns>
        public unsafe static bool TryParse(string input, out Cac_Address_Claims value)
        {
            try
            {
                value = Newtonsoft.Json.JsonConvert.DeserializeObject<Cac_Address_Claims>(input);
                return true;
            }
            catch { value = default(Cac_Address_Claims); return false; }
        }
        public static Cac_Address_Claims Parse(string input)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Cac_Address_Claims>(input);
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
    /// Provides in-place operations of Cac_Address_Claims defined in TSL.
    /// </summary>
    public unsafe partial class Cac_Address_Claims_Accessor : IAccessor
    {
        ///<summary>
        ///The pointer to the content of the object.
        ///</summary>
        internal byte* m_ptr;
        internal long m_cellId;
        internal unsafe Cac_Address_Claims_Accessor(byte* _CellPtr
            
            , ResizeFunctionDelegate func
            )
        {
            m_ptr = _CellPtr;
            
            ResizeFunction = func;
                    cbc_ID_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        cbc_PostBox_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        cbc_StreetName_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        cbc_AdditionalStreetName_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        cbc_BuildingNumber_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        cbc_Department_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        cbc_CityName_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        cbc_CountrySubentityCode_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        cbc_Country_Accessor_Field = new Cac_Country_Accessor(null,
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
            {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}}}
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
            {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}}}
            int size = (int)(targetPtr - m_ptr);
            return size;
        }
        public ResizeFunctionDelegate ResizeFunction { get; set; }
        #endregion
        StringAccessor cbc_ID_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cbc_ID.
        ///</summary>
        public unsafe StringAccessor cbc_ID
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {}cbc_ID_Accessor_Field.m_ptr = targetPtr + 4;
                cbc_ID_Accessor_Field.m_cellId = this.m_cellId;
                return cbc_ID_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cbc_ID_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != cbc_ID_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    cbc_ID_Accessor_Field.m_ptr = cbc_ID_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, cbc_ID_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        cbc_ID_Accessor_Field.m_ptr = cbc_ID_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, cbc_ID_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        StringAccessor cbc_PostBox_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cbc_PostBox.
        ///</summary>
        public unsafe StringAccessor cbc_PostBox
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);}cbc_PostBox_Accessor_Field.m_ptr = targetPtr + 4;
                cbc_PostBox_Accessor_Field.m_cellId = this.m_cellId;
                return cbc_PostBox_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cbc_PostBox_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != cbc_PostBox_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    cbc_PostBox_Accessor_Field.m_ptr = cbc_PostBox_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, cbc_PostBox_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        cbc_PostBox_Accessor_Field.m_ptr = cbc_PostBox_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, cbc_PostBox_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        StringAccessor cbc_StreetName_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cbc_StreetName.
        ///</summary>
        public unsafe StringAccessor cbc_StreetName
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}cbc_StreetName_Accessor_Field.m_ptr = targetPtr + 4;
                cbc_StreetName_Accessor_Field.m_cellId = this.m_cellId;
                return cbc_StreetName_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cbc_StreetName_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != cbc_StreetName_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    cbc_StreetName_Accessor_Field.m_ptr = cbc_StreetName_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, cbc_StreetName_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        cbc_StreetName_Accessor_Field.m_ptr = cbc_StreetName_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, cbc_StreetName_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        StringAccessor cbc_AdditionalStreetName_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cbc_AdditionalStreetName.
        ///</summary>
        public unsafe StringAccessor cbc_AdditionalStreetName
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}cbc_AdditionalStreetName_Accessor_Field.m_ptr = targetPtr + 4;
                cbc_AdditionalStreetName_Accessor_Field.m_cellId = this.m_cellId;
                return cbc_AdditionalStreetName_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cbc_AdditionalStreetName_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != cbc_AdditionalStreetName_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    cbc_AdditionalStreetName_Accessor_Field.m_ptr = cbc_AdditionalStreetName_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, cbc_AdditionalStreetName_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        cbc_AdditionalStreetName_Accessor_Field.m_ptr = cbc_AdditionalStreetName_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, cbc_AdditionalStreetName_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        StringAccessor cbc_BuildingNumber_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cbc_BuildingNumber.
        ///</summary>
        public unsafe StringAccessor cbc_BuildingNumber
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}cbc_BuildingNumber_Accessor_Field.m_ptr = targetPtr + 4;
                cbc_BuildingNumber_Accessor_Field.m_cellId = this.m_cellId;
                return cbc_BuildingNumber_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cbc_BuildingNumber_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != cbc_BuildingNumber_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    cbc_BuildingNumber_Accessor_Field.m_ptr = cbc_BuildingNumber_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, cbc_BuildingNumber_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        cbc_BuildingNumber_Accessor_Field.m_ptr = cbc_BuildingNumber_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, cbc_BuildingNumber_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        StringAccessor cbc_Department_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cbc_Department.
        ///</summary>
        public unsafe StringAccessor cbc_Department
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}cbc_Department_Accessor_Field.m_ptr = targetPtr + 4;
                cbc_Department_Accessor_Field.m_cellId = this.m_cellId;
                return cbc_Department_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cbc_Department_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != cbc_Department_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    cbc_Department_Accessor_Field.m_ptr = cbc_Department_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, cbc_Department_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        cbc_Department_Accessor_Field.m_ptr = cbc_Department_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, cbc_Department_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        StringAccessor cbc_CityName_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cbc_CityName.
        ///</summary>
        public unsafe StringAccessor cbc_CityName
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}cbc_CityName_Accessor_Field.m_ptr = targetPtr + 4;
                cbc_CityName_Accessor_Field.m_cellId = this.m_cellId;
                return cbc_CityName_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cbc_CityName_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != cbc_CityName_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    cbc_CityName_Accessor_Field.m_ptr = cbc_CityName_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, cbc_CityName_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        cbc_CityName_Accessor_Field.m_ptr = cbc_CityName_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, cbc_CityName_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        StringAccessor cbc_CountrySubentityCode_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cbc_CountrySubentityCode.
        ///</summary>
        public unsafe StringAccessor cbc_CountrySubentityCode
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}cbc_CountrySubentityCode_Accessor_Field.m_ptr = targetPtr + 4;
                cbc_CountrySubentityCode_Accessor_Field.m_cellId = this.m_cellId;
                return cbc_CountrySubentityCode_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cbc_CountrySubentityCode_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != cbc_CountrySubentityCode_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    cbc_CountrySubentityCode_Accessor_Field.m_ptr = cbc_CountrySubentityCode_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, cbc_CountrySubentityCode_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        cbc_CountrySubentityCode_Accessor_Field.m_ptr = cbc_CountrySubentityCode_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, cbc_CountrySubentityCode_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        Cac_Country_Accessor cbc_Country_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cbc_Country.
        ///</summary>
        public unsafe Cac_Country_Accessor cbc_Country
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}cbc_Country_Accessor_Field.m_ptr = targetPtr;
                cbc_Country_Accessor_Field.m_cellId = this.m_cellId;
                return cbc_Country_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cbc_Country_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
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
        
        public static unsafe implicit operator Cac_Address_Claims(Cac_Address_Claims_Accessor accessor)
        {
            
            return new Cac_Address_Claims(
                
                        accessor.cbc_ID,
                        accessor.cbc_PostBox,
                        accessor.cbc_StreetName,
                        accessor.cbc_AdditionalStreetName,
                        accessor.cbc_BuildingNumber,
                        accessor.cbc_Department,
                        accessor.cbc_CityName,
                        accessor.cbc_CountrySubentityCode,
                        accessor.cbc_Country
                );
        }
        
        public unsafe static implicit operator Cac_Address_Claims_Accessor(Cac_Address_Claims field)
        {
            byte* targetPtr = null;
            
            {

        if(field.cbc_ID!= null)
        {
            int strlen_2 = field.cbc_ID.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.cbc_PostBox!= null)
        {
            int strlen_2 = field.cbc_PostBox.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.cbc_StreetName!= null)
        {
            int strlen_2 = field.cbc_StreetName.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.cbc_AdditionalStreetName!= null)
        {
            int strlen_2 = field.cbc_AdditionalStreetName.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.cbc_BuildingNumber!= null)
        {
            int strlen_2 = field.cbc_BuildingNumber.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.cbc_Department!= null)
        {
            int strlen_2 = field.cbc_Department.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.cbc_CityName!= null)
        {
            int strlen_2 = field.cbc_CityName.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.cbc_CountrySubentityCode!= null)
        {
            int strlen_2 = field.cbc_CountrySubentityCode.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            {

            {

        if(field.cbc_Country.cbc_IdentificationCode._listID!= null)
        {
            int strlen_4 = field.cbc_Country.cbc_IdentificationCode._listID.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.cbc_Country.cbc_IdentificationCode._listAgencyID!= null)
        {
            int strlen_4 = field.cbc_Country.cbc_IdentificationCode._listAgencyID.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.cbc_Country.cbc_IdentificationCode.code!= null)
        {
            int strlen_4 = field.cbc_Country.cbc_IdentificationCode.code.Length * 2;
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

        if(field.cbc_ID!= null)
        {
            int strlen_2 = field.cbc_ID.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.cbc_ID)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.cbc_PostBox!= null)
        {
            int strlen_2 = field.cbc_PostBox.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.cbc_PostBox)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.cbc_StreetName!= null)
        {
            int strlen_2 = field.cbc_StreetName.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.cbc_StreetName)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.cbc_AdditionalStreetName!= null)
        {
            int strlen_2 = field.cbc_AdditionalStreetName.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.cbc_AdditionalStreetName)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.cbc_BuildingNumber!= null)
        {
            int strlen_2 = field.cbc_BuildingNumber.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.cbc_BuildingNumber)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.cbc_Department!= null)
        {
            int strlen_2 = field.cbc_Department.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.cbc_Department)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.cbc_CityName!= null)
        {
            int strlen_2 = field.cbc_CityName.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.cbc_CityName)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.cbc_CountrySubentityCode!= null)
        {
            int strlen_2 = field.cbc_CountrySubentityCode.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.cbc_CountrySubentityCode)
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

            {

        if(field.cbc_Country.cbc_IdentificationCode._listID!= null)
        {
            int strlen_4 = field.cbc_Country.cbc_IdentificationCode._listID.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.cbc_Country.cbc_IdentificationCode._listID)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.cbc_Country.cbc_IdentificationCode._listAgencyID!= null)
        {
            int strlen_4 = field.cbc_Country.cbc_IdentificationCode._listAgencyID.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.cbc_Country.cbc_IdentificationCode._listAgencyID)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.cbc_Country.cbc_IdentificationCode.code!= null)
        {
            int strlen_4 = field.cbc_Country.cbc_IdentificationCode.code.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.cbc_Country.cbc_IdentificationCode.code)
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
            }Cac_Address_Claims_Accessor ret;
            
            ret = new Cac_Address_Claims_Accessor(tmpcellptr, null);
            
            return ret;
        }
        
        public static bool operator ==(Cac_Address_Claims_Accessor a, Cac_Address_Claims_Accessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            byte* targetPtr = a.m_ptr;
            {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}}}
            int lengthA = (int)(targetPtr - a.m_ptr);
            targetPtr = b.m_ptr;
            {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}}}
            int lengthB = (int)(targetPtr - b.m_ptr);
            if(lengthA != lengthB) return false;
            return Memory.Compare(a.m_ptr,b.m_ptr,lengthA);
        }
        public static bool operator != (Cac_Address_Claims_Accessor a, Cac_Address_Claims_Accessor b)
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
