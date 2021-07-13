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
    /// A .NET runtime object representation of Cac_InvoiceLine defined in TSL.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct Cac_InvoiceLine
    {
        
        ///<summary>
        ///Initializes a new instance of Cac_InvoiceLine with the specified parameters.
        ///</summary>
        public Cac_InvoiceLine(string cbc_ID = default(string),Cbc_Note cbc_Note = default(Cbc_Note),Cbc_Quantity cbc_InvoicedQuantity = default(Cbc_Quantity),Cbc_Amount cbc_LineExtensionAmount = default(Cbc_Amount),string cbc_AccountingCost = default(string),Cac_OrderLineReference cac_OrderLineReference = default(Cac_OrderLineReference),List<Cac_AllowanceCharge> cac_AllowanceCharges = default(List<Cac_AllowanceCharge>),Cac_TaxTotal cac_TaxTotal = default(Cac_TaxTotal),string cac_ItemUdid = default(string),Cac_Price cac_Price = default(Cac_Price))
        {
            
            this.cbc_ID = cbc_ID;
            
            this.cbc_Note = cbc_Note;
            
            this.cbc_InvoicedQuantity = cbc_InvoicedQuantity;
            
            this.cbc_LineExtensionAmount = cbc_LineExtensionAmount;
            
            this.cbc_AccountingCost = cbc_AccountingCost;
            
            this.cac_OrderLineReference = cac_OrderLineReference;
            
            this.cac_AllowanceCharges = cac_AllowanceCharges;
            
            this.cac_TaxTotal = cac_TaxTotal;
            
            this.cac_ItemUdid = cac_ItemUdid;
            
            this.cac_Price = cac_Price;
            
        }
        
        public static bool operator ==(Cac_InvoiceLine a, Cac_InvoiceLine b)
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
                (a.cbc_Note == b.cbc_Note)
                &&
                (a.cbc_InvoicedQuantity == b.cbc_InvoicedQuantity)
                &&
                (a.cbc_LineExtensionAmount == b.cbc_LineExtensionAmount)
                &&
                (a.cbc_AccountingCost == b.cbc_AccountingCost)
                &&
                (a.cac_OrderLineReference == b.cac_OrderLineReference)
                &&
                (a.cac_AllowanceCharges == b.cac_AllowanceCharges)
                &&
                (a.cac_TaxTotal == b.cac_TaxTotal)
                &&
                (a.cac_ItemUdid == b.cac_ItemUdid)
                &&
                (a.cac_Price == b.cac_Price)
                
                ;
            
        }
        public static bool operator !=(Cac_InvoiceLine a, Cac_InvoiceLine b)
        {
            return !(a == b);
        }
        
        public string cbc_ID;
        
        public Cbc_Note cbc_Note;
        
        public Cbc_Quantity cbc_InvoicedQuantity;
        
        public Cbc_Amount cbc_LineExtensionAmount;
        
        public string cbc_AccountingCost;
        
        public Cac_OrderLineReference cac_OrderLineReference;
        
        public List<Cac_AllowanceCharge> cac_AllowanceCharges;
        
        public Cac_TaxTotal cac_TaxTotal;
        
        public string cac_ItemUdid;
        
        public Cac_Price cac_Price;
        
        /// <summary>
        /// Converts the string representation of a Cac_InvoiceLine to its
        /// struct equivalent. A return value indicates whether the 
        /// operation succeeded.
        /// </summary>
        /// <param name="input">A string to convert.</param>
        /// <param name="value">
        /// When this method returns, contains the struct equivalent of the value contained 
        /// in input, if the conversion succeeded, or default(Cac_InvoiceLine) if the conversion
        /// failed. The conversion fails if the input parameter is null or String.Empty, or is 
        /// not of the correct format. This parameter is passed uninitialized. 
        /// </param>
        /// <returns>True if input was converted successfully; otherwise, false.</returns>
        public unsafe static bool TryParse(string input, out Cac_InvoiceLine value)
        {
            try
            {
                value = Newtonsoft.Json.JsonConvert.DeserializeObject<Cac_InvoiceLine>(input);
                return true;
            }
            catch { value = default(Cac_InvoiceLine); return false; }
        }
        public static Cac_InvoiceLine Parse(string input)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Cac_InvoiceLine>(input);
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
    /// Provides in-place operations of Cac_InvoiceLine defined in TSL.
    /// </summary>
    public unsafe partial class Cac_InvoiceLine_Accessor : IAccessor
    {
        ///<summary>
        ///The pointer to the content of the object.
        ///</summary>
        internal byte* m_ptr;
        internal long m_cellId;
        internal unsafe Cac_InvoiceLine_Accessor(byte* _CellPtr
            
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
                });        cbc_Note_Accessor_Field = new Cbc_Note_Accessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        cbc_InvoicedQuantity_Accessor_Field = new Cbc_Quantity_Accessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        cbc_LineExtensionAmount_Accessor_Field = new Cbc_Amount_Accessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        cbc_AccountingCost_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        cac_OrderLineReference_Accessor_Field = new Cac_OrderLineReference_Accessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        cac_AllowanceCharges_Accessor_Field = new Cac_AllowanceCharge_AccessorListAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        cac_TaxTotal_Accessor_Field = new Cac_TaxTotal_Accessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        cac_ItemUdid_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        cac_Price_Accessor_Field = new Cac_Price_Accessor(null,
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
            {targetPtr += *(int*)targetPtr + sizeof(int);{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}}}
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
            {targetPtr += *(int*)targetPtr + sizeof(int);{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}}}
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
        Cbc_Note_Accessor cbc_Note_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cbc_Note.
        ///</summary>
        public unsafe Cbc_Note_Accessor cbc_Note
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);}cbc_Note_Accessor_Field.m_ptr = targetPtr;
                cbc_Note_Accessor_Field.m_cellId = this.m_cellId;
                return cbc_Note_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cbc_Note_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);}
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
        Cbc_Quantity_Accessor cbc_InvoicedQuantity_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cbc_InvoicedQuantity.
        ///</summary>
        public unsafe Cbc_Quantity_Accessor cbc_InvoicedQuantity
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}}cbc_InvoicedQuantity_Accessor_Field.m_ptr = targetPtr;
                cbc_InvoicedQuantity_Accessor_Field.m_cellId = this.m_cellId;
                return cbc_InvoicedQuantity_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cbc_InvoicedQuantity_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);{            targetPtr += 1;
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
        Cbc_Amount_Accessor cbc_LineExtensionAmount_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cbc_LineExtensionAmount.
        ///</summary>
        public unsafe Cbc_Amount_Accessor cbc_LineExtensionAmount
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}cbc_LineExtensionAmount_Accessor_Field.m_ptr = targetPtr;
                cbc_LineExtensionAmount_Accessor_Field.m_cellId = this.m_cellId;
                return cbc_LineExtensionAmount_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cbc_LineExtensionAmount_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}
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
        StringAccessor cbc_AccountingCost_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cbc_AccountingCost.
        ///</summary>
        public unsafe StringAccessor cbc_AccountingCost
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}cbc_AccountingCost_Accessor_Field.m_ptr = targetPtr + 4;
                cbc_AccountingCost_Accessor_Field.m_cellId = this.m_cellId;
                return cbc_AccountingCost_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cbc_AccountingCost_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != cbc_AccountingCost_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    cbc_AccountingCost_Accessor_Field.m_ptr = cbc_AccountingCost_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, cbc_AccountingCost_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        cbc_AccountingCost_Accessor_Field.m_ptr = cbc_AccountingCost_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, cbc_AccountingCost_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        Cac_OrderLineReference_Accessor cac_OrderLineReference_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cac_OrderLineReference.
        ///</summary>
        public unsafe Cac_OrderLineReference_Accessor cac_OrderLineReference
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);}cac_OrderLineReference_Accessor_Field.m_ptr = targetPtr;
                cac_OrderLineReference_Accessor_Field.m_cellId = this.m_cellId;
                return cac_OrderLineReference_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cac_OrderLineReference_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);}
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
        Cac_AllowanceCharge_AccessorListAccessor cac_AllowanceCharges_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cac_AllowanceCharges.
        ///</summary>
        public unsafe Cac_AllowanceCharge_AccessorListAccessor cac_AllowanceCharges
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}}cac_AllowanceCharges_Accessor_Field.m_ptr = targetPtr + 4;
                cac_AllowanceCharges_Accessor_Field.m_cellId = this.m_cellId;
                return cac_AllowanceCharges_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cac_AllowanceCharges_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != cac_AllowanceCharges_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    cac_AllowanceCharges_Accessor_Field.m_ptr = cac_AllowanceCharges_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, cac_AllowanceCharges_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        cac_AllowanceCharges_Accessor_Field.m_ptr = cac_AllowanceCharges_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, cac_AllowanceCharges_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        Cac_TaxTotal_Accessor cac_TaxTotal_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cac_TaxTotal.
        ///</summary>
        public unsafe Cac_TaxTotal_Accessor cac_TaxTotal
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);}cac_TaxTotal_Accessor_Field.m_ptr = targetPtr;
                cac_TaxTotal_Accessor_Field.m_cellId = this.m_cellId;
                return cac_TaxTotal_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cac_TaxTotal_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);}
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
        StringAccessor cac_ItemUdid_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cac_ItemUdid.
        ///</summary>
        public unsafe StringAccessor cac_ItemUdid
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);}}cac_ItemUdid_Accessor_Field.m_ptr = targetPtr + 4;
                cac_ItemUdid_Accessor_Field.m_cellId = this.m_cellId;
                return cac_ItemUdid_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cac_ItemUdid_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);}}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != cac_ItemUdid_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    cac_ItemUdid_Accessor_Field.m_ptr = cac_ItemUdid_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, cac_ItemUdid_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        cac_ItemUdid_Accessor_Field.m_ptr = cac_ItemUdid_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, cac_ItemUdid_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        Cac_Price_Accessor cac_Price_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cac_Price.
        ///</summary>
        public unsafe Cac_Price_Accessor cac_Price
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);}cac_Price_Accessor_Field.m_ptr = targetPtr;
                cac_Price_Accessor_Field.m_cellId = this.m_cellId;
                return cac_Price_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cac_Price_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);}
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
        
        public static unsafe implicit operator Cac_InvoiceLine(Cac_InvoiceLine_Accessor accessor)
        {
            
            return new Cac_InvoiceLine(
                
                        accessor.cbc_ID,
                        accessor.cbc_Note,
                        accessor.cbc_InvoicedQuantity,
                        accessor.cbc_LineExtensionAmount,
                        accessor.cbc_AccountingCost,
                        accessor.cac_OrderLineReference,
                        accessor.cac_AllowanceCharges,
                        accessor.cac_TaxTotal,
                        accessor.cac_ItemUdid,
                        accessor.cac_Price
                );
        }
        
        public unsafe static implicit operator Cac_InvoiceLine_Accessor(Cac_InvoiceLine field)
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

            {
            targetPtr += 1;

        if(field.cbc_Note.note!= null)
        {
            int strlen_3 = field.cbc_Note.note.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            {

        if(field.cbc_InvoicedQuantity._unitCode!= null)
        {
            int strlen_3 = field.cbc_InvoicedQuantity._unitCode.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

        if(field.cbc_LineExtensionAmount._CurrencyID!= null)
        {
            int strlen_3 = field.cbc_LineExtensionAmount._CurrencyID.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
        if(field.cbc_AccountingCost!= null)
        {
            int strlen_2 = field.cbc_AccountingCost.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            {

        if(field.cac_OrderLineReference.cbc_LineID!= null)
        {
            int strlen_3 = field.cac_OrderLineReference.cbc_LineID.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
{

    targetPtr += sizeof(int);
    if(field.cac_AllowanceCharges!= null)
    {
        for(int iterator_2 = 0;iterator_2<field.cac_AllowanceCharges.Count;++iterator_2)
        {

            {
            targetPtr += 1;

        if(field.cac_AllowanceCharges[iterator_2].cbc_AllowanceChargeReason!= null)
        {
            int strlen_4 = field.cac_AllowanceCharges[iterator_2].cbc_AllowanceChargeReason.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            {

        if(field.cac_AllowanceCharges[iterator_2].cbc_Amount._CurrencyID!= null)
        {
            int strlen_5 = field.cac_AllowanceCharges[iterator_2].cbc_Amount._CurrencyID.Length * 2;
            targetPtr += strlen_5+sizeof(int);
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

        if(field.cac_TaxTotal.cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_4 = field.cac_TaxTotal.cbc_TaxAmount._CurrencyID.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
{

    targetPtr += sizeof(int);
    if(field.cac_TaxTotal.cac_TaxSubtotals!= null)
    {
        for(int iterator_3 = 0;iterator_3<field.cac_TaxTotal.cac_TaxSubtotals.Count;++iterator_3)
        {

            {

            {

        if(field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cbc_TaxableAmount._CurrencyID!= null)
        {
            int strlen_6 = field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cbc_TaxableAmount._CurrencyID.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

        if(field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_6 = field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cbc_TaxAmount._CurrencyID.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

            {
            targetPtr += 1;

        if(field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cac_TaxCategory.cbc_ID._schemeID!= null)
        {
            int strlen_7 = field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cac_TaxCategory.cbc_ID._schemeID.Length * 2;
            targetPtr += strlen_7+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
            {

        if(field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_7 = field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cac_TaxCategory.cbc_ID._schemeAgencyID.Length * 2;
            targetPtr += strlen_7+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

        if(field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cac_TaxCategory.cbc_ID.code!= null)
        {
            int strlen_7 = field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cac_TaxCategory.cbc_ID.code.Length * 2;
            targetPtr += strlen_7+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }            targetPtr += 8;

            {

            {
            targetPtr += 1;

        if(field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID!= null)
        {
            int strlen_8 = field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID.Length * 2;
            targetPtr += strlen_8+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
            {

        if(field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_8 = field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID.Length * 2;
            targetPtr += strlen_8+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

        if(field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cac_TaxCategory.cac_TaxScheme.cbc_ID.code!= null)
        {
            int strlen_8 = field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cac_TaxCategory.cac_TaxScheme.cbc_ID.code.Length * 2;
            targetPtr += strlen_8+sizeof(int);
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
        if(field.cac_ItemUdid!= null)
        {
            int strlen_2 = field.cac_ItemUdid.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            {

            {

        if(field.cac_Price.cbc_PriceAmount._CurrencyID!= null)
        {
            int strlen_4 = field.cac_Price.cbc_PriceAmount._CurrencyID.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

        if(field.cac_Price.cbc_BaseQuantity._unitCode!= null)
        {
            int strlen_4 = field.cac_Price.cbc_BaseQuantity._unitCode.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {
            targetPtr += 1;

        if(field.cac_Price.cac_AllowanceCharge.cbc_AllowanceChargeReason!= null)
        {
            int strlen_4 = field.cac_Price.cac_AllowanceCharge.cbc_AllowanceChargeReason.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            {

        if(field.cac_Price.cac_AllowanceCharge.cbc_Amount._CurrencyID!= null)
        {
            int strlen_5 = field.cac_Price.cac_AllowanceCharge.cbc_Amount._CurrencyID.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

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

            {
            *(ISO639_1_LanguageCodes*)targetPtr = field.cbc_Note._languageID;
            targetPtr += 1;

        if(field.cbc_Note.note!= null)
        {
            int strlen_3 = field.cbc_Note.note.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.cbc_Note.note)
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

        if(field.cbc_InvoicedQuantity._unitCode!= null)
        {
            int strlen_3 = field.cbc_InvoicedQuantity._unitCode.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.cbc_InvoicedQuantity._unitCode)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = field.cbc_InvoicedQuantity.quantity;
            targetPtr += 8;

            }
            {

        if(field.cbc_LineExtensionAmount._CurrencyID!= null)
        {
            int strlen_3 = field.cbc_LineExtensionAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.cbc_LineExtensionAmount._CurrencyID)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.cbc_LineExtensionAmount.amount;
            targetPtr += 8;

            }
        if(field.cbc_AccountingCost!= null)
        {
            int strlen_2 = field.cbc_AccountingCost.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.cbc_AccountingCost)
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

        if(field.cac_OrderLineReference.cbc_LineID!= null)
        {
            int strlen_3 = field.cac_OrderLineReference.cbc_LineID.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.cac_OrderLineReference.cbc_LineID)
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
byte *storedPtr_2 = targetPtr;

    targetPtr += sizeof(int);
    if(field.cac_AllowanceCharges!= null)
    {
        for(int iterator_2 = 0;iterator_2<field.cac_AllowanceCharges.Count;++iterator_2)
        {

            {
            *(bool*)targetPtr = field.cac_AllowanceCharges[iterator_2].cbc_ChargeIndicator;
            targetPtr += 1;

        if(field.cac_AllowanceCharges[iterator_2].cbc_AllowanceChargeReason!= null)
        {
            int strlen_4 = field.cac_AllowanceCharges[iterator_2].cbc_AllowanceChargeReason.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.cac_AllowanceCharges[iterator_2].cbc_AllowanceChargeReason)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            {

        if(field.cac_AllowanceCharges[iterator_2].cbc_Amount._CurrencyID!= null)
        {
            int strlen_5 = field.cac_AllowanceCharges[iterator_2].cbc_Amount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.cac_AllowanceCharges[iterator_2].cbc_Amount._CurrencyID)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.cac_AllowanceCharges[iterator_2].cbc_Amount.amount;
            targetPtr += 8;

            }
            }
        }
    }
*(int*)storedPtr_2 = (int)(targetPtr - storedPtr_2 - 4);

}

            {

            {

        if(field.cac_TaxTotal.cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_4 = field.cac_TaxTotal.cbc_TaxAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.cac_TaxTotal.cbc_TaxAmount._CurrencyID)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.cac_TaxTotal.cbc_TaxAmount.amount;
            targetPtr += 8;

            }
{
byte *storedPtr_3 = targetPtr;

    targetPtr += sizeof(int);
    if(field.cac_TaxTotal.cac_TaxSubtotals!= null)
    {
        for(int iterator_3 = 0;iterator_3<field.cac_TaxTotal.cac_TaxSubtotals.Count;++iterator_3)
        {

            {

            {

        if(field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cbc_TaxableAmount._CurrencyID!= null)
        {
            int strlen_6 = field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cbc_TaxableAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cbc_TaxableAmount._CurrencyID)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cbc_TaxableAmount.amount;
            targetPtr += 8;

            }
            {

        if(field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_6 = field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cbc_TaxAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cbc_TaxAmount._CurrencyID)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cbc_TaxAmount.amount;
            targetPtr += 8;

            }
            {

            {
            byte* optheader_6 = targetPtr;
            *(optheader_6 + 0) = 0x00;            targetPtr += 1;

        if(field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cac_TaxCategory.cbc_ID._schemeID!= null)
        {
            int strlen_7 = field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cac_TaxCategory.cbc_ID._schemeID.Length * 2;
            *(int*)targetPtr = strlen_7;
            targetPtr += sizeof(int);
            fixed(char* pstr_7 = field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cac_TaxCategory.cbc_ID._schemeID)
            {
                Memory.Copy(pstr_7, targetPtr, strlen_7);
                targetPtr += strlen_7;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
            {

        if(field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_7 = field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cac_TaxCategory.cbc_ID._schemeAgencyID.Length * 2;
            *(int*)targetPtr = strlen_7;
            targetPtr += sizeof(int);
            fixed(char* pstr_7 = field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cac_TaxCategory.cbc_ID._schemeAgencyID)
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

        if(field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cac_TaxCategory.cbc_ID.code!= null)
        {
            int strlen_7 = field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cac_TaxCategory.cbc_ID.code.Length * 2;
            *(int*)targetPtr = strlen_7;
            targetPtr += sizeof(int);
            fixed(char* pstr_7 = field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cac_TaxCategory.cbc_ID.code)
            {
                Memory.Copy(pstr_7, targetPtr, strlen_7);
                targetPtr += strlen_7;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }            *(double*)targetPtr = field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cac_TaxCategory.cbc_Percent;
            targetPtr += 8;

            {

            {
            byte* optheader_7 = targetPtr;
            *(optheader_7 + 0) = 0x00;            targetPtr += 1;

        if(field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID!= null)
        {
            int strlen_8 = field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID.Length * 2;
            *(int*)targetPtr = strlen_8;
            targetPtr += sizeof(int);
            fixed(char* pstr_8 = field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID)
            {
                Memory.Copy(pstr_8, targetPtr, strlen_8);
                targetPtr += strlen_8;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
            {

        if(field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_8 = field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID.Length * 2;
            *(int*)targetPtr = strlen_8;
            targetPtr += sizeof(int);
            fixed(char* pstr_8 = field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID)
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

        if(field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cac_TaxCategory.cac_TaxScheme.cbc_ID.code!= null)
        {
            int strlen_8 = field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cac_TaxCategory.cac_TaxScheme.cbc_ID.code.Length * 2;
            *(int*)targetPtr = strlen_8;
            targetPtr += sizeof(int);
            fixed(char* pstr_8 = field.cac_TaxTotal.cac_TaxSubtotals[iterator_3].cac_TaxCategory.cac_TaxScheme.cbc_ID.code)
            {
                Memory.Copy(pstr_8, targetPtr, strlen_8);
                targetPtr += strlen_8;
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
*(int*)storedPtr_3 = (int)(targetPtr - storedPtr_3 - 4);

}

            }
        if(field.cac_ItemUdid!= null)
        {
            int strlen_2 = field.cac_ItemUdid.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.cac_ItemUdid)
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

        if(field.cac_Price.cbc_PriceAmount._CurrencyID!= null)
        {
            int strlen_4 = field.cac_Price.cbc_PriceAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.cac_Price.cbc_PriceAmount._CurrencyID)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.cac_Price.cbc_PriceAmount.amount;
            targetPtr += 8;

            }
            {

        if(field.cac_Price.cbc_BaseQuantity._unitCode!= null)
        {
            int strlen_4 = field.cac_Price.cbc_BaseQuantity._unitCode.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.cac_Price.cbc_BaseQuantity._unitCode)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = field.cac_Price.cbc_BaseQuantity.quantity;
            targetPtr += 8;

            }
            {
            *(bool*)targetPtr = field.cac_Price.cac_AllowanceCharge.cbc_ChargeIndicator;
            targetPtr += 1;

        if(field.cac_Price.cac_AllowanceCharge.cbc_AllowanceChargeReason!= null)
        {
            int strlen_4 = field.cac_Price.cac_AllowanceCharge.cbc_AllowanceChargeReason.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.cac_Price.cac_AllowanceCharge.cbc_AllowanceChargeReason)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            {

        if(field.cac_Price.cac_AllowanceCharge.cbc_Amount._CurrencyID!= null)
        {
            int strlen_5 = field.cac_Price.cac_AllowanceCharge.cbc_Amount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.cac_Price.cac_AllowanceCharge.cbc_Amount._CurrencyID)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.cac_Price.cac_AllowanceCharge.cbc_Amount.amount;
            targetPtr += 8;

            }
            }
            }
            }Cac_InvoiceLine_Accessor ret;
            
            ret = new Cac_InvoiceLine_Accessor(tmpcellptr, null);
            
            return ret;
        }
        
        public static bool operator ==(Cac_InvoiceLine_Accessor a, Cac_InvoiceLine_Accessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            byte* targetPtr = a.m_ptr;
            {targetPtr += *(int*)targetPtr + sizeof(int);{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}}}
            int lengthA = (int)(targetPtr - a.m_ptr);
            targetPtr = b.m_ptr;
            {targetPtr += *(int*)targetPtr + sizeof(int);{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}}}
            int lengthB = (int)(targetPtr - b.m_ptr);
            if(lengthA != lengthB) return false;
            return Memory.Compare(a.m_ptr,b.m_ptr,lengthA);
        }
        public static bool operator != (Cac_InvoiceLine_Accessor a, Cac_InvoiceLine_Accessor b)
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
