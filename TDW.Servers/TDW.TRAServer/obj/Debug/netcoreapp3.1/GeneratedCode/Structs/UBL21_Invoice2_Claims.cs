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
    /// A .NET runtime object representation of UBL21_Invoice2_Claims defined in TSL.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct UBL21_Invoice2_Claims
    {
        
        ///<summary>
        ///Initializes a new instance of UBL21_Invoice2_Claims with the specified parameters.
        ///</summary>
        public UBL21_Invoice2_Claims(string cbc_UBLVersionID = default(string),string cbc_ID = default(string),DateTime cbc_IssueDate = default(DateTime),Cbc_ListCode cbc_InvoiceTypeCode = default(Cbc_ListCode),Cbc_Note cbc_Note = default(Cbc_Note),DateTime cbc_TaxPointDate = default(DateTime),Cbc_ListCode cbc_DocumentCurrencyCode = default(Cbc_ListCode),string cbc_AccountingCost = default(string),Cbc_TimePeriod cbc_InvoicePeriod = default(Cbc_TimePeriod),Cbc_OrderReference cbc_OrderReference = default(Cbc_OrderReference),Cac_DocumentReference cac_ContractDocumentReference = default(Cac_DocumentReference),List<Cac_DocumentReference> cac_AdditionalDocumentReferences = default(List<Cac_DocumentReference>),Cac_AccountingSupplierParty cac_AccountingSupplierParty = default(Cac_AccountingSupplierParty),Cac_AccountingCustomerParty cac_AccountingCustomerParty = default(Cac_AccountingCustomerParty),Cac_PayeeParty cac_PayeeParty = default(Cac_PayeeParty),Cac_Delivery cac_Delivery = default(Cac_Delivery),string cac_PaymentMeansUdid = default(string),Cac_PaymentTerms cac_PaymentTerms = default(Cac_PaymentTerms),List<Cac_AllowanceCharge> cac_AllowanceCharges = default(List<Cac_AllowanceCharge>),Cac_TaxTotal cac_TaxTotal = default(Cac_TaxTotal),Cac_LegalMonetaryTotal cac_LegalMonetaryTotal = default(Cac_LegalMonetaryTotal),List<Cac_InvoiceLine> cac_InvoiceLine = default(List<Cac_InvoiceLine>))
        {
            
            this.cbc_UBLVersionID = cbc_UBLVersionID;
            
            this.cbc_ID = cbc_ID;
            
            this.cbc_IssueDate = cbc_IssueDate;
            
            this.cbc_InvoiceTypeCode = cbc_InvoiceTypeCode;
            
            this.cbc_Note = cbc_Note;
            
            this.cbc_TaxPointDate = cbc_TaxPointDate;
            
            this.cbc_DocumentCurrencyCode = cbc_DocumentCurrencyCode;
            
            this.cbc_AccountingCost = cbc_AccountingCost;
            
            this.cbc_InvoicePeriod = cbc_InvoicePeriod;
            
            this.cbc_OrderReference = cbc_OrderReference;
            
            this.cac_ContractDocumentReference = cac_ContractDocumentReference;
            
            this.cac_AdditionalDocumentReferences = cac_AdditionalDocumentReferences;
            
            this.cac_AccountingSupplierParty = cac_AccountingSupplierParty;
            
            this.cac_AccountingCustomerParty = cac_AccountingCustomerParty;
            
            this.cac_PayeeParty = cac_PayeeParty;
            
            this.cac_Delivery = cac_Delivery;
            
            this.cac_PaymentMeansUdid = cac_PaymentMeansUdid;
            
            this.cac_PaymentTerms = cac_PaymentTerms;
            
            this.cac_AllowanceCharges = cac_AllowanceCharges;
            
            this.cac_TaxTotal = cac_TaxTotal;
            
            this.cac_LegalMonetaryTotal = cac_LegalMonetaryTotal;
            
            this.cac_InvoiceLine = cac_InvoiceLine;
            
        }
        
        public static bool operator ==(UBL21_Invoice2_Claims a, UBL21_Invoice2_Claims b)
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
                
                (a.cbc_UBLVersionID == b.cbc_UBLVersionID)
                &&
                (a.cbc_ID == b.cbc_ID)
                &&
                (a.cbc_IssueDate == b.cbc_IssueDate)
                &&
                (a.cbc_InvoiceTypeCode == b.cbc_InvoiceTypeCode)
                &&
                (a.cbc_Note == b.cbc_Note)
                &&
                (a.cbc_TaxPointDate == b.cbc_TaxPointDate)
                &&
                (a.cbc_DocumentCurrencyCode == b.cbc_DocumentCurrencyCode)
                &&
                (a.cbc_AccountingCost == b.cbc_AccountingCost)
                &&
                (a.cbc_InvoicePeriod == b.cbc_InvoicePeriod)
                &&
                (a.cbc_OrderReference == b.cbc_OrderReference)
                &&
                (a.cac_ContractDocumentReference == b.cac_ContractDocumentReference)
                &&
                (a.cac_AdditionalDocumentReferences == b.cac_AdditionalDocumentReferences)
                &&
                (a.cac_AccountingSupplierParty == b.cac_AccountingSupplierParty)
                &&
                (a.cac_AccountingCustomerParty == b.cac_AccountingCustomerParty)
                &&
                (a.cac_PayeeParty == b.cac_PayeeParty)
                &&
                (a.cac_Delivery == b.cac_Delivery)
                &&
                (a.cac_PaymentMeansUdid == b.cac_PaymentMeansUdid)
                &&
                (a.cac_PaymentTerms == b.cac_PaymentTerms)
                &&
                (a.cac_AllowanceCharges == b.cac_AllowanceCharges)
                &&
                (a.cac_TaxTotal == b.cac_TaxTotal)
                &&
                (a.cac_LegalMonetaryTotal == b.cac_LegalMonetaryTotal)
                &&
                (a.cac_InvoiceLine == b.cac_InvoiceLine)
                
                ;
            
        }
        public static bool operator !=(UBL21_Invoice2_Claims a, UBL21_Invoice2_Claims b)
        {
            return !(a == b);
        }
        
        public string cbc_UBLVersionID;
        
        public string cbc_ID;
        
        public DateTime cbc_IssueDate;
        
        public Cbc_ListCode cbc_InvoiceTypeCode;
        
        public Cbc_Note cbc_Note;
        
        public DateTime cbc_TaxPointDate;
        
        public Cbc_ListCode cbc_DocumentCurrencyCode;
        
        public string cbc_AccountingCost;
        
        public Cbc_TimePeriod cbc_InvoicePeriod;
        
        public Cbc_OrderReference cbc_OrderReference;
        
        public Cac_DocumentReference cac_ContractDocumentReference;
        
        public List<Cac_DocumentReference> cac_AdditionalDocumentReferences;
        
        public Cac_AccountingSupplierParty cac_AccountingSupplierParty;
        
        public Cac_AccountingCustomerParty cac_AccountingCustomerParty;
        
        public Cac_PayeeParty cac_PayeeParty;
        
        public Cac_Delivery cac_Delivery;
        
        public string cac_PaymentMeansUdid;
        
        public Cac_PaymentTerms cac_PaymentTerms;
        
        public List<Cac_AllowanceCharge> cac_AllowanceCharges;
        
        public Cac_TaxTotal cac_TaxTotal;
        
        public Cac_LegalMonetaryTotal cac_LegalMonetaryTotal;
        
        public List<Cac_InvoiceLine> cac_InvoiceLine;
        
        /// <summary>
        /// Converts the string representation of a UBL21_Invoice2_Claims to its
        /// struct equivalent. A return value indicates whether the 
        /// operation succeeded.
        /// </summary>
        /// <param name="input">A string to convert.</param>
        /// <param name="value">
        /// When this method returns, contains the struct equivalent of the value contained 
        /// in input, if the conversion succeeded, or default(UBL21_Invoice2_Claims) if the conversion
        /// failed. The conversion fails if the input parameter is null or String.Empty, or is 
        /// not of the correct format. This parameter is passed uninitialized. 
        /// </param>
        /// <returns>True if input was converted successfully; otherwise, false.</returns>
        public unsafe static bool TryParse(string input, out UBL21_Invoice2_Claims value)
        {
            try
            {
                value = Newtonsoft.Json.JsonConvert.DeserializeObject<UBL21_Invoice2_Claims>(input);
                return true;
            }
            catch { value = default(UBL21_Invoice2_Claims); return false; }
        }
        public static UBL21_Invoice2_Claims Parse(string input)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<UBL21_Invoice2_Claims>(input);
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
    /// Provides in-place operations of UBL21_Invoice2_Claims defined in TSL.
    /// </summary>
    public unsafe partial class UBL21_Invoice2_Claims_Accessor : IAccessor
    {
        ///<summary>
        ///The pointer to the content of the object.
        ///</summary>
        internal byte* m_ptr;
        internal long m_cellId;
        internal unsafe UBL21_Invoice2_Claims_Accessor(byte* _CellPtr
            
            , ResizeFunctionDelegate func
            )
        {
            m_ptr = _CellPtr;
            
            ResizeFunction = func;
                    cbc_UBLVersionID_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        cbc_ID_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        cbc_IssueDate_Accessor_Field = new DateTimeAccessor(null);        cbc_InvoiceTypeCode_Accessor_Field = new Cbc_ListCode_Accessor(null,
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
                });        cbc_TaxPointDate_Accessor_Field = new DateTimeAccessor(null);        cbc_DocumentCurrencyCode_Accessor_Field = new Cbc_ListCode_Accessor(null,
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
                });        cbc_InvoicePeriod_Accessor_Field = new Cbc_TimePeriod_Accessor(null);        cbc_OrderReference_Accessor_Field = new Cbc_OrderReference_Accessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        cac_ContractDocumentReference_Accessor_Field = new Cac_DocumentReference_Accessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        cac_AdditionalDocumentReferences_Accessor_Field = new Cac_DocumentReference_AccessorListAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        cac_AccountingSupplierParty_Accessor_Field = new Cac_AccountingSupplierParty_Accessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        cac_AccountingCustomerParty_Accessor_Field = new Cac_AccountingCustomerParty_Accessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        cac_PayeeParty_Accessor_Field = new Cac_PayeeParty_Accessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        cac_Delivery_Accessor_Field = new Cac_Delivery_Accessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        cac_PaymentMeansUdid_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        cac_PaymentTerms_Accessor_Field = new Cac_PaymentTerms_Accessor(null,
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
                });        cac_LegalMonetaryTotal_Accessor_Field = new Cac_LegalMonetaryTotal_Accessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        cac_InvoiceLine_Accessor_Field = new Cac_InvoiceLine_AccessorListAccessor(null,
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
            {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
{targetPtr += *(int*)targetPtr + sizeof(int);}{            byte* optheader_2 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_2 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 8;
{{            byte* optheader_6 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_6 + 0) & 0x01)))
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
            {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
{targetPtr += *(int*)targetPtr + sizeof(int);}{            byte* optheader_2 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_2 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 8;
{{            byte* optheader_6 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_6 + 0) & 0x01)))
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
            int size = (int)(targetPtr - m_ptr);
            return size;
        }
        public ResizeFunctionDelegate ResizeFunction { get; set; }
        #endregion
        StringAccessor cbc_UBLVersionID_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cbc_UBLVersionID.
        ///</summary>
        public unsafe StringAccessor cbc_UBLVersionID
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {}cbc_UBLVersionID_Accessor_Field.m_ptr = targetPtr + 4;
                cbc_UBLVersionID_Accessor_Field.m_cellId = this.m_cellId;
                return cbc_UBLVersionID_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cbc_UBLVersionID_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != cbc_UBLVersionID_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    cbc_UBLVersionID_Accessor_Field.m_ptr = cbc_UBLVersionID_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, cbc_UBLVersionID_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        cbc_UBLVersionID_Accessor_Field.m_ptr = cbc_UBLVersionID_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, cbc_UBLVersionID_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        StringAccessor cbc_ID_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cbc_ID.
        ///</summary>
        public unsafe StringAccessor cbc_ID
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);}cbc_ID_Accessor_Field.m_ptr = targetPtr + 4;
                cbc_ID_Accessor_Field.m_cellId = this.m_cellId;
                return cbc_ID_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cbc_ID_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);}
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
        DateTimeAccessor cbc_IssueDate_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cbc_IssueDate.
        ///</summary>
        public unsafe DateTimeAccessor cbc_IssueDate
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}cbc_IssueDate_Accessor_Field.m_ptr = targetPtr;
                cbc_IssueDate_Accessor_Field.m_cellId = this.m_cellId;
                return cbc_IssueDate_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cbc_IssueDate_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}                Memory.Copy(value.m_ptr, targetPtr, 8); 
            }
        }
        Cbc_ListCode_Accessor cbc_InvoiceTypeCode_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cbc_InvoiceTypeCode.
        ///</summary>
        public unsafe Cbc_ListCode_Accessor cbc_InvoiceTypeCode
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}cbc_InvoiceTypeCode_Accessor_Field.m_ptr = targetPtr;
                cbc_InvoiceTypeCode_Accessor_Field.m_cellId = this.m_cellId;
                return cbc_InvoiceTypeCode_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cbc_InvoiceTypeCode_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
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
        Cbc_Note_Accessor cbc_Note_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cbc_Note.
        ///</summary>
        public unsafe Cbc_Note_Accessor cbc_Note
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}}cbc_Note_Accessor_Field.m_ptr = targetPtr;
                cbc_Note_Accessor_Field.m_cellId = this.m_cellId;
                return cbc_Note_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cbc_Note_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}}
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
        DateTimeAccessor cbc_TaxPointDate_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cbc_TaxPointDate.
        ///</summary>
        public unsafe DateTimeAccessor cbc_TaxPointDate
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}}cbc_TaxPointDate_Accessor_Field.m_ptr = targetPtr;
                cbc_TaxPointDate_Accessor_Field.m_cellId = this.m_cellId;
                return cbc_TaxPointDate_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cbc_TaxPointDate_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}}                Memory.Copy(value.m_ptr, targetPtr, 8); 
            }
        }
        Cbc_ListCode_Accessor cbc_DocumentCurrencyCode_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cbc_DocumentCurrencyCode.
        ///</summary>
        public unsafe Cbc_ListCode_Accessor cbc_DocumentCurrencyCode
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
}cbc_DocumentCurrencyCode_Accessor_Field.m_ptr = targetPtr;
                cbc_DocumentCurrencyCode_Accessor_Field.m_cellId = this.m_cellId;
                return cbc_DocumentCurrencyCode_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cbc_DocumentCurrencyCode_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
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
        StringAccessor cbc_AccountingCost_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cbc_AccountingCost.
        ///</summary>
        public unsafe StringAccessor cbc_AccountingCost
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}}cbc_AccountingCost_Accessor_Field.m_ptr = targetPtr + 4;
                cbc_AccountingCost_Accessor_Field.m_cellId = this.m_cellId;
                return cbc_AccountingCost_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cbc_AccountingCost_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}}
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
        Cbc_TimePeriod_Accessor cbc_InvoicePeriod_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cbc_InvoicePeriod.
        ///</summary>
        public unsafe Cbc_TimePeriod_Accessor cbc_InvoicePeriod
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);}cbc_InvoicePeriod_Accessor_Field.m_ptr = targetPtr;
                cbc_InvoicePeriod_Accessor_Field.m_cellId = this.m_cellId;
                return cbc_InvoicePeriod_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cbc_InvoicePeriod_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);}                Memory.Copy(value.m_ptr, targetPtr, 16); 
            }
        }
        Cbc_OrderReference_Accessor cbc_OrderReference_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cbc_OrderReference.
        ///</summary>
        public unsafe Cbc_OrderReference_Accessor cbc_OrderReference
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
}cbc_OrderReference_Accessor_Field.m_ptr = targetPtr;
                cbc_OrderReference_Accessor_Field.m_cellId = this.m_cellId;
                return cbc_OrderReference_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cbc_OrderReference_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
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
        Cac_DocumentReference_Accessor cac_ContractDocumentReference_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cac_ContractDocumentReference.
        ///</summary>
        public unsafe Cac_DocumentReference_Accessor cac_ContractDocumentReference
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
{targetPtr += *(int*)targetPtr + sizeof(int);}}cac_ContractDocumentReference_Accessor_Field.m_ptr = targetPtr;
                cac_ContractDocumentReference_Accessor_Field.m_cellId = this.m_cellId;
                return cac_ContractDocumentReference_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cac_ContractDocumentReference_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
{targetPtr += *(int*)targetPtr + sizeof(int);}}
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
        Cac_DocumentReference_AccessorListAccessor cac_AdditionalDocumentReferences_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cac_AdditionalDocumentReferences.
        ///</summary>
        public unsafe Cac_DocumentReference_AccessorListAccessor cac_AdditionalDocumentReferences
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
{targetPtr += *(int*)targetPtr + sizeof(int);}{            byte* optheader_3 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_3 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}}cac_AdditionalDocumentReferences_Accessor_Field.m_ptr = targetPtr + 4;
                cac_AdditionalDocumentReferences_Accessor_Field.m_cellId = this.m_cellId;
                return cac_AdditionalDocumentReferences_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cac_AdditionalDocumentReferences_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
{targetPtr += *(int*)targetPtr + sizeof(int);}{            byte* optheader_3 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_3 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != cac_AdditionalDocumentReferences_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    cac_AdditionalDocumentReferences_Accessor_Field.m_ptr = cac_AdditionalDocumentReferences_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, cac_AdditionalDocumentReferences_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        cac_AdditionalDocumentReferences_Accessor_Field.m_ptr = cac_AdditionalDocumentReferences_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, cac_AdditionalDocumentReferences_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        Cac_AccountingSupplierParty_Accessor cac_AccountingSupplierParty_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cac_AccountingSupplierParty.
        ///</summary>
        public unsafe Cac_AccountingSupplierParty_Accessor cac_AccountingSupplierParty
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
{targetPtr += *(int*)targetPtr + sizeof(int);}{            byte* optheader_3 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_3 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}targetPtr += *(int*)targetPtr + sizeof(int);}cac_AccountingSupplierParty_Accessor_Field.m_ptr = targetPtr;
                cac_AccountingSupplierParty_Accessor_Field.m_cellId = this.m_cellId;
                return cac_AccountingSupplierParty_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cac_AccountingSupplierParty_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
{targetPtr += *(int*)targetPtr + sizeof(int);}{            byte* optheader_3 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_3 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
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
        Cac_AccountingCustomerParty_Accessor cac_AccountingCustomerParty_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cac_AccountingCustomerParty.
        ///</summary>
        public unsafe Cac_AccountingCustomerParty_Accessor cac_AccountingCustomerParty
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
{targetPtr += *(int*)targetPtr + sizeof(int);}{            byte* optheader_3 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_3 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}}cac_AccountingCustomerParty_Accessor_Field.m_ptr = targetPtr;
                cac_AccountingCustomerParty_Accessor_Field.m_cellId = this.m_cellId;
                return cac_AccountingCustomerParty_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cac_AccountingCustomerParty_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
{targetPtr += *(int*)targetPtr + sizeof(int);}{            byte* optheader_3 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_3 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}}
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
        Cac_PayeeParty_Accessor cac_PayeeParty_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cac_PayeeParty.
        ///</summary>
        public unsafe Cac_PayeeParty_Accessor cac_PayeeParty
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
{targetPtr += *(int*)targetPtr + sizeof(int);}{            byte* optheader_3 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_3 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}}cac_PayeeParty_Accessor_Field.m_ptr = targetPtr;
                cac_PayeeParty_Accessor_Field.m_cellId = this.m_cellId;
                return cac_PayeeParty_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cac_PayeeParty_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
{targetPtr += *(int*)targetPtr + sizeof(int);}{            byte* optheader_3 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_3 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}}
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
        Cac_Delivery_Accessor cac_Delivery_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cac_Delivery.
        ///</summary>
        public unsafe Cac_Delivery_Accessor cac_Delivery
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
{targetPtr += *(int*)targetPtr + sizeof(int);}{            byte* optheader_3 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_3 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}}cac_Delivery_Accessor_Field.m_ptr = targetPtr;
                cac_Delivery_Accessor_Field.m_cellId = this.m_cellId;
                return cac_Delivery_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cac_Delivery_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
{targetPtr += *(int*)targetPtr + sizeof(int);}{            byte* optheader_3 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_3 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}}
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
        StringAccessor cac_PaymentMeansUdid_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cac_PaymentMeansUdid.
        ///</summary>
        public unsafe StringAccessor cac_PaymentMeansUdid
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
{targetPtr += *(int*)targetPtr + sizeof(int);}{            byte* optheader_3 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_3 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 8;
{{            byte* optheader_7 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_7 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);}}}cac_PaymentMeansUdid_Accessor_Field.m_ptr = targetPtr + 4;
                cac_PaymentMeansUdid_Accessor_Field.m_cellId = this.m_cellId;
                return cac_PaymentMeansUdid_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cac_PaymentMeansUdid_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
{targetPtr += *(int*)targetPtr + sizeof(int);}{            byte* optheader_3 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_3 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 8;
{{            byte* optheader_7 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_7 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);}}}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != cac_PaymentMeansUdid_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    cac_PaymentMeansUdid_Accessor_Field.m_ptr = cac_PaymentMeansUdid_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, cac_PaymentMeansUdid_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        cac_PaymentMeansUdid_Accessor_Field.m_ptr = cac_PaymentMeansUdid_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, cac_PaymentMeansUdid_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        Cac_PaymentTerms_Accessor cac_PaymentTerms_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cac_PaymentTerms.
        ///</summary>
        public unsafe Cac_PaymentTerms_Accessor cac_PaymentTerms
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
{targetPtr += *(int*)targetPtr + sizeof(int);}{            byte* optheader_3 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_3 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 8;
{{            byte* optheader_7 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_7 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);}}targetPtr += *(int*)targetPtr + sizeof(int);}cac_PaymentTerms_Accessor_Field.m_ptr = targetPtr;
                cac_PaymentTerms_Accessor_Field.m_cellId = this.m_cellId;
                return cac_PaymentTerms_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cac_PaymentTerms_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
{targetPtr += *(int*)targetPtr + sizeof(int);}{            byte* optheader_3 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_3 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 8;
{{            byte* optheader_7 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_7 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);}}targetPtr += *(int*)targetPtr + sizeof(int);}
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
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
{targetPtr += *(int*)targetPtr + sizeof(int);}{            byte* optheader_3 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_3 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 8;
{{            byte* optheader_7 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_7 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);}}targetPtr += *(int*)targetPtr + sizeof(int);{{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}}}cac_AllowanceCharges_Accessor_Field.m_ptr = targetPtr + 4;
                cac_AllowanceCharges_Accessor_Field.m_cellId = this.m_cellId;
                return cac_AllowanceCharges_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cac_AllowanceCharges_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
{targetPtr += *(int*)targetPtr + sizeof(int);}{            byte* optheader_3 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_3 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 8;
{{            byte* optheader_7 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_7 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);}}targetPtr += *(int*)targetPtr + sizeof(int);{{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}}}
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
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
{targetPtr += *(int*)targetPtr + sizeof(int);}{            byte* optheader_3 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_3 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 8;
{{            byte* optheader_7 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_7 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);}}targetPtr += *(int*)targetPtr + sizeof(int);{{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}}targetPtr += *(int*)targetPtr + sizeof(int);}cac_TaxTotal_Accessor_Field.m_ptr = targetPtr;
                cac_TaxTotal_Accessor_Field.m_cellId = this.m_cellId;
                return cac_TaxTotal_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cac_TaxTotal_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
{targetPtr += *(int*)targetPtr + sizeof(int);}{            byte* optheader_3 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_3 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 8;
{{            byte* optheader_7 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_7 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);}}targetPtr += *(int*)targetPtr + sizeof(int);{{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}}targetPtr += *(int*)targetPtr + sizeof(int);}
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
        Cac_LegalMonetaryTotal_Accessor cac_LegalMonetaryTotal_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cac_LegalMonetaryTotal.
        ///</summary>
        public unsafe Cac_LegalMonetaryTotal_Accessor cac_LegalMonetaryTotal
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
{targetPtr += *(int*)targetPtr + sizeof(int);}{            byte* optheader_3 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_3 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 8;
{{            byte* optheader_7 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_7 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);}}targetPtr += *(int*)targetPtr + sizeof(int);{{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);}}cac_LegalMonetaryTotal_Accessor_Field.m_ptr = targetPtr;
                cac_LegalMonetaryTotal_Accessor_Field.m_cellId = this.m_cellId;
                return cac_LegalMonetaryTotal_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cac_LegalMonetaryTotal_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
{targetPtr += *(int*)targetPtr + sizeof(int);}{            byte* optheader_3 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_3 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 8;
{{            byte* optheader_7 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_7 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);}}targetPtr += *(int*)targetPtr + sizeof(int);{{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);}}
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
        Cac_InvoiceLine_AccessorListAccessor cac_InvoiceLine_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field cac_InvoiceLine.
        ///</summary>
        public unsafe Cac_InvoiceLine_AccessorListAccessor cac_InvoiceLine
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
{targetPtr += *(int*)targetPtr + sizeof(int);}{            byte* optheader_3 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_3 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 8;
{{            byte* optheader_7 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_7 + 0) & 0x01)))
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
}}}cac_InvoiceLine_Accessor_Field.m_ptr = targetPtr + 4;
                cac_InvoiceLine_Accessor_Field.m_cellId = this.m_cellId;
                return cac_InvoiceLine_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                cac_InvoiceLine_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
{targetPtr += *(int*)targetPtr + sizeof(int);}{            byte* optheader_3 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_3 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 8;
{{            byte* optheader_7 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_7 + 0) & 0x01)))
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
}}}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != cac_InvoiceLine_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    cac_InvoiceLine_Accessor_Field.m_ptr = cac_InvoiceLine_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, cac_InvoiceLine_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        cac_InvoiceLine_Accessor_Field.m_ptr = cac_InvoiceLine_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, cac_InvoiceLine_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        
        public static unsafe implicit operator UBL21_Invoice2_Claims(UBL21_Invoice2_Claims_Accessor accessor)
        {
            
            return new UBL21_Invoice2_Claims(
                
                        accessor.cbc_UBLVersionID,
                        accessor.cbc_ID,
                        accessor.cbc_IssueDate,
                        accessor.cbc_InvoiceTypeCode,
                        accessor.cbc_Note,
                        accessor.cbc_TaxPointDate,
                        accessor.cbc_DocumentCurrencyCode,
                        accessor.cbc_AccountingCost,
                        accessor.cbc_InvoicePeriod,
                        accessor.cbc_OrderReference,
                        accessor.cac_ContractDocumentReference,
                        accessor.cac_AdditionalDocumentReferences,
                        accessor.cac_AccountingSupplierParty,
                        accessor.cac_AccountingCustomerParty,
                        accessor.cac_PayeeParty,
                        accessor.cac_Delivery,
                        accessor.cac_PaymentMeansUdid,
                        accessor.cac_PaymentTerms,
                        accessor.cac_AllowanceCharges,
                        accessor.cac_TaxTotal,
                        accessor.cac_LegalMonetaryTotal,
                        accessor.cac_InvoiceLine
                );
        }
        
        public unsafe static implicit operator UBL21_Invoice2_Claims_Accessor(UBL21_Invoice2_Claims field)
        {
            byte* targetPtr = null;
            
            {

        if(field.cbc_UBLVersionID!= null)
        {
            int strlen_2 = field.cbc_UBLVersionID.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.cbc_ID!= null)
        {
            int strlen_2 = field.cbc_ID.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
targetPtr += 8;
            {

        if(field.cbc_InvoiceTypeCode._listID!= null)
        {
            int strlen_3 = field.cbc_InvoiceTypeCode._listID.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.cbc_InvoiceTypeCode._listAgencyID!= null)
        {
            int strlen_3 = field.cbc_InvoiceTypeCode._listAgencyID.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.cbc_InvoiceTypeCode.code!= null)
        {
            int strlen_3 = field.cbc_InvoiceTypeCode.code.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

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

            }targetPtr += 8;
            {

        if(field.cbc_DocumentCurrencyCode._listID!= null)
        {
            int strlen_3 = field.cbc_DocumentCurrencyCode._listID.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.cbc_DocumentCurrencyCode._listAgencyID!= null)
        {
            int strlen_3 = field.cbc_DocumentCurrencyCode._listAgencyID.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.cbc_DocumentCurrencyCode.code!= null)
        {
            int strlen_3 = field.cbc_DocumentCurrencyCode.code.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
        if(field.cbc_AccountingCost!= null)
        {
            int strlen_2 = field.cbc_AccountingCost.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
targetPtr += 16;

            {

        if(field.cbc_OrderReference.cbc_ID!= null)
        {
            int strlen_3 = field.cbc_OrderReference.cbc_ID.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            {
            targetPtr += 1;

        if(field.cac_ContractDocumentReference.ID!= null)
        {
            int strlen_3 = field.cac_ContractDocumentReference.ID.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.cac_ContractDocumentReference.DocumentType!= null)
        {
            int strlen_3 = field.cac_ContractDocumentReference.DocumentType.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( field.cac_ContractDocumentReference.cac_Attachment!= null)
            {

            {

        if(field.cac_ContractDocumentReference.cac_Attachment.Value.cac_ExternalReferenceUdid!= null)
        {
            int strlen_4 = field.cac_ContractDocumentReference.cac_Attachment.Value.cac_ExternalReferenceUdid.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }

            }
{

    targetPtr += sizeof(int);
    if(field.cac_AdditionalDocumentReferences!= null)
    {
        for(int iterator_2 = 0;iterator_2<field.cac_AdditionalDocumentReferences.Count;++iterator_2)
        {

            {
            targetPtr += 1;

        if(field.cac_AdditionalDocumentReferences[iterator_2].ID!= null)
        {
            int strlen_4 = field.cac_AdditionalDocumentReferences[iterator_2].ID.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.cac_AdditionalDocumentReferences[iterator_2].DocumentType!= null)
        {
            int strlen_4 = field.cac_AdditionalDocumentReferences[iterator_2].DocumentType.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( field.cac_AdditionalDocumentReferences[iterator_2].cac_Attachment!= null)
            {

            {

        if(field.cac_AdditionalDocumentReferences[iterator_2].cac_Attachment.Value.cac_ExternalReferenceUdid!= null)
        {
            int strlen_5 = field.cac_AdditionalDocumentReferences[iterator_2].cac_Attachment.Value.cac_ExternalReferenceUdid.Length * 2;
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

            {

        if(field.cac_AccountingSupplierParty.cac_PartyUdid!= null)
        {
            int strlen_3 = field.cac_AccountingSupplierParty.cac_PartyUdid.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            {

        if(field.cac_AccountingCustomerParty.cac_PartyUdid!= null)
        {
            int strlen_3 = field.cac_AccountingCustomerParty.cac_PartyUdid.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            {

        if(field.cac_PayeeParty.cac_PartyUdid!= null)
        {
            int strlen_3 = field.cac_PayeeParty.cac_PartyUdid.Length * 2;
            targetPtr += strlen_3+sizeof(int);
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

        if(field.cac_Delivery.cac_DeliveryLocation.cbc_ID._schemeID!= null)
        {
            int strlen_5 = field.cac_Delivery.cac_DeliveryLocation.cbc_ID._schemeID.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( field.cac_Delivery.cac_DeliveryLocation.cbc_ID._schemeAgencyID!= null)
            {

        if(field.cac_Delivery.cac_DeliveryLocation.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_5 = field.cac_Delivery.cac_DeliveryLocation.cbc_ID._schemeAgencyID.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

        if(field.cac_Delivery.cac_DeliveryLocation.cbc_ID.code!= null)
        {
            int strlen_5 = field.cac_Delivery.cac_DeliveryLocation.cbc_ID.code.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
        if(field.cac_Delivery.cac_DeliveryLocation.cac_AddressUdid!= null)
        {
            int strlen_4 = field.cac_Delivery.cac_DeliveryLocation.cac_AddressUdid.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
        if(field.cac_PaymentMeansUdid!= null)
        {
            int strlen_2 = field.cac_PaymentMeansUdid.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            {

            {
            targetPtr += 1;

        if(field.cac_PaymentTerms.cbc_Note.note!= null)
        {
            int strlen_4 = field.cac_PaymentTerms.cbc_Note.note.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

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
            {

            {

        if(field.cac_LegalMonetaryTotal.cbc_LineExtensionAmount._CurrencyID!= null)
        {
            int strlen_4 = field.cac_LegalMonetaryTotal.cbc_LineExtensionAmount._CurrencyID.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

        if(field.cac_LegalMonetaryTotal.cbc_TaxExclusiveAmount._CurrencyID!= null)
        {
            int strlen_4 = field.cac_LegalMonetaryTotal.cbc_TaxExclusiveAmount._CurrencyID.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

        if(field.cac_LegalMonetaryTotal.cbc_TaxInclusiveAmount._CurrencyID!= null)
        {
            int strlen_4 = field.cac_LegalMonetaryTotal.cbc_TaxInclusiveAmount._CurrencyID.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

        if(field.cac_LegalMonetaryTotal.cbc_AllowanceTotalAmount._CurrencyID!= null)
        {
            int strlen_4 = field.cac_LegalMonetaryTotal.cbc_AllowanceTotalAmount._CurrencyID.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

        if(field.cac_LegalMonetaryTotal.cbc_ChargeTotalAmount._CurrencyID!= null)
        {
            int strlen_4 = field.cac_LegalMonetaryTotal.cbc_ChargeTotalAmount._CurrencyID.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

        if(field.cac_LegalMonetaryTotal.cbc_PrepaidAmount._CurrencyID!= null)
        {
            int strlen_4 = field.cac_LegalMonetaryTotal.cbc_PrepaidAmount._CurrencyID.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

        if(field.cac_LegalMonetaryTotal.cbc_PayableRoundingAmount._CurrencyID!= null)
        {
            int strlen_4 = field.cac_LegalMonetaryTotal.cbc_PayableRoundingAmount._CurrencyID.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

        if(field.cac_LegalMonetaryTotal.cbc_PayableAmount._CurrencyID!= null)
        {
            int strlen_4 = field.cac_LegalMonetaryTotal.cbc_PayableAmount._CurrencyID.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            }
{

    targetPtr += sizeof(int);
    if(field.cac_InvoiceLine!= null)
    {
        for(int iterator_2 = 0;iterator_2<field.cac_InvoiceLine.Count;++iterator_2)
        {

            {

        if(field.cac_InvoiceLine[iterator_2].cbc_ID!= null)
        {
            int strlen_4 = field.cac_InvoiceLine[iterator_2].cbc_ID.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            {
            targetPtr += 1;

        if(field.cac_InvoiceLine[iterator_2].cbc_Note.note!= null)
        {
            int strlen_5 = field.cac_InvoiceLine[iterator_2].cbc_Note.note.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            {

        if(field.cac_InvoiceLine[iterator_2].cbc_InvoicedQuantity._unitCode!= null)
        {
            int strlen_5 = field.cac_InvoiceLine[iterator_2].cbc_InvoicedQuantity._unitCode.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

        if(field.cac_InvoiceLine[iterator_2].cbc_LineExtensionAmount._CurrencyID!= null)
        {
            int strlen_5 = field.cac_InvoiceLine[iterator_2].cbc_LineExtensionAmount._CurrencyID.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
        if(field.cac_InvoiceLine[iterator_2].cbc_AccountingCost!= null)
        {
            int strlen_4 = field.cac_InvoiceLine[iterator_2].cbc_AccountingCost.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            {

        if(field.cac_InvoiceLine[iterator_2].cac_OrderLineReference.cbc_LineID!= null)
        {
            int strlen_5 = field.cac_InvoiceLine[iterator_2].cac_OrderLineReference.cbc_LineID.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
{

    targetPtr += sizeof(int);
    if(field.cac_InvoiceLine[iterator_2].cac_AllowanceCharges!= null)
    {
        for(int iterator_4 = 0;iterator_4<field.cac_InvoiceLine[iterator_2].cac_AllowanceCharges.Count;++iterator_4)
        {

            {
            targetPtr += 1;

        if(field.cac_InvoiceLine[iterator_2].cac_AllowanceCharges[iterator_4].cbc_AllowanceChargeReason!= null)
        {
            int strlen_6 = field.cac_InvoiceLine[iterator_2].cac_AllowanceCharges[iterator_4].cbc_AllowanceChargeReason.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            {

        if(field.cac_InvoiceLine[iterator_2].cac_AllowanceCharges[iterator_4].cbc_Amount._CurrencyID!= null)
        {
            int strlen_7 = field.cac_InvoiceLine[iterator_2].cac_AllowanceCharges[iterator_4].cbc_Amount._CurrencyID.Length * 2;
            targetPtr += strlen_7+sizeof(int);
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

        if(field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_6 = field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cbc_TaxAmount._CurrencyID.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
{

    targetPtr += sizeof(int);
    if(field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals!= null)
    {
        for(int iterator_5 = 0;iterator_5<field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals.Count;++iterator_5)
        {

            {

            {

        if(field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cbc_TaxableAmount._CurrencyID!= null)
        {
            int strlen_8 = field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cbc_TaxableAmount._CurrencyID.Length * 2;
            targetPtr += strlen_8+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

        if(field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_8 = field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cbc_TaxAmount._CurrencyID.Length * 2;
            targetPtr += strlen_8+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

            {
            targetPtr += 1;

        if(field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cac_TaxCategory.cbc_ID._schemeID!= null)
        {
            int strlen_9 = field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cac_TaxCategory.cbc_ID._schemeID.Length * 2;
            targetPtr += strlen_9+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
            {

        if(field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_9 = field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cac_TaxCategory.cbc_ID._schemeAgencyID.Length * 2;
            targetPtr += strlen_9+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

        if(field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cac_TaxCategory.cbc_ID.code!= null)
        {
            int strlen_9 = field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cac_TaxCategory.cbc_ID.code.Length * 2;
            targetPtr += strlen_9+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }            targetPtr += 8;

            {

            {
            targetPtr += 1;

        if(field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID!= null)
        {
            int strlen_10 = field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID.Length * 2;
            targetPtr += strlen_10+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
            {

        if(field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_10 = field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID.Length * 2;
            targetPtr += strlen_10+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

        if(field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cac_TaxCategory.cac_TaxScheme.cbc_ID.code!= null)
        {
            int strlen_10 = field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cac_TaxCategory.cac_TaxScheme.cbc_ID.code.Length * 2;
            targetPtr += strlen_10+sizeof(int);
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
        if(field.cac_InvoiceLine[iterator_2].cac_ItemUdid!= null)
        {
            int strlen_4 = field.cac_InvoiceLine[iterator_2].cac_ItemUdid.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            {

            {

        if(field.cac_InvoiceLine[iterator_2].cac_Price.cbc_PriceAmount._CurrencyID!= null)
        {
            int strlen_6 = field.cac_InvoiceLine[iterator_2].cac_Price.cbc_PriceAmount._CurrencyID.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

        if(field.cac_InvoiceLine[iterator_2].cac_Price.cbc_BaseQuantity._unitCode!= null)
        {
            int strlen_6 = field.cac_InvoiceLine[iterator_2].cac_Price.cbc_BaseQuantity._unitCode.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {
            targetPtr += 1;

        if(field.cac_InvoiceLine[iterator_2].cac_Price.cac_AllowanceCharge.cbc_AllowanceChargeReason!= null)
        {
            int strlen_6 = field.cac_InvoiceLine[iterator_2].cac_Price.cac_AllowanceCharge.cbc_AllowanceChargeReason.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            {

        if(field.cac_InvoiceLine[iterator_2].cac_Price.cac_AllowanceCharge.cbc_Amount._CurrencyID!= null)
        {
            int strlen_7 = field.cac_InvoiceLine[iterator_2].cac_Price.cac_AllowanceCharge.cbc_Amount._CurrencyID.Length * 2;
            targetPtr += strlen_7+sizeof(int);
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
            byte* tmpcellptr = BufferAllocator.AllocBuffer((int)targetPtr);
            Memory.memset(tmpcellptr, 0, (ulong)targetPtr);
            targetPtr = tmpcellptr;
            
            {

        if(field.cbc_UBLVersionID!= null)
        {
            int strlen_2 = field.cbc_UBLVersionID.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.cbc_UBLVersionID)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

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
            *(long*)targetPtr = field.cbc_IssueDate.ToBinary();
            targetPtr += 8;
        }

            {

        if(field.cbc_InvoiceTypeCode._listID!= null)
        {
            int strlen_3 = field.cbc_InvoiceTypeCode._listID.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.cbc_InvoiceTypeCode._listID)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.cbc_InvoiceTypeCode._listAgencyID!= null)
        {
            int strlen_3 = field.cbc_InvoiceTypeCode._listAgencyID.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.cbc_InvoiceTypeCode._listAgencyID)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.cbc_InvoiceTypeCode.code!= null)
        {
            int strlen_3 = field.cbc_InvoiceTypeCode.code.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.cbc_InvoiceTypeCode.code)
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
            *(long*)targetPtr = field.cbc_TaxPointDate.ToBinary();
            targetPtr += 8;
        }

            {

        if(field.cbc_DocumentCurrencyCode._listID!= null)
        {
            int strlen_3 = field.cbc_DocumentCurrencyCode._listID.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.cbc_DocumentCurrencyCode._listID)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.cbc_DocumentCurrencyCode._listAgencyID!= null)
        {
            int strlen_3 = field.cbc_DocumentCurrencyCode._listAgencyID.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.cbc_DocumentCurrencyCode._listAgencyID)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.cbc_DocumentCurrencyCode.code!= null)
        {
            int strlen_3 = field.cbc_DocumentCurrencyCode.code.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.cbc_DocumentCurrencyCode.code)
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

        {
            *(long*)targetPtr = field.cbc_InvoicePeriod.cbc_StartDate.ToBinary();
            targetPtr += 8;
        }

        {
            *(long*)targetPtr = field.cbc_InvoicePeriod.cbc_EndDate.ToBinary();
            targetPtr += 8;
        }

            }
            {

        if(field.cbc_OrderReference.cbc_ID!= null)
        {
            int strlen_3 = field.cbc_OrderReference.cbc_ID.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.cbc_OrderReference.cbc_ID)
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
            byte* optheader_2 = targetPtr;
            *(optheader_2 + 0) = 0x00;            targetPtr += 1;

        if(field.cac_ContractDocumentReference.ID!= null)
        {
            int strlen_3 = field.cac_ContractDocumentReference.ID.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.cac_ContractDocumentReference.ID)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.cac_ContractDocumentReference.DocumentType!= null)
        {
            int strlen_3 = field.cac_ContractDocumentReference.DocumentType.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.cac_ContractDocumentReference.DocumentType)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( field.cac_ContractDocumentReference.cac_Attachment!= null)
            {

            {

        if(field.cac_ContractDocumentReference.cac_Attachment.Value.cac_ExternalReferenceUdid!= null)
        {
            int strlen_4 = field.cac_ContractDocumentReference.cac_Attachment.Value.cac_ExternalReferenceUdid.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.cac_ContractDocumentReference.cac_Attachment.Value.cac_ExternalReferenceUdid)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }*(optheader_2 + 0) |= 0x01;
            }

            }
{
byte *storedPtr_2 = targetPtr;

    targetPtr += sizeof(int);
    if(field.cac_AdditionalDocumentReferences!= null)
    {
        for(int iterator_2 = 0;iterator_2<field.cac_AdditionalDocumentReferences.Count;++iterator_2)
        {

            {
            byte* optheader_3 = targetPtr;
            *(optheader_3 + 0) = 0x00;            targetPtr += 1;

        if(field.cac_AdditionalDocumentReferences[iterator_2].ID!= null)
        {
            int strlen_4 = field.cac_AdditionalDocumentReferences[iterator_2].ID.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.cac_AdditionalDocumentReferences[iterator_2].ID)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.cac_AdditionalDocumentReferences[iterator_2].DocumentType!= null)
        {
            int strlen_4 = field.cac_AdditionalDocumentReferences[iterator_2].DocumentType.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.cac_AdditionalDocumentReferences[iterator_2].DocumentType)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( field.cac_AdditionalDocumentReferences[iterator_2].cac_Attachment!= null)
            {

            {

        if(field.cac_AdditionalDocumentReferences[iterator_2].cac_Attachment.Value.cac_ExternalReferenceUdid!= null)
        {
            int strlen_5 = field.cac_AdditionalDocumentReferences[iterator_2].cac_Attachment.Value.cac_ExternalReferenceUdid.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.cac_AdditionalDocumentReferences[iterator_2].cac_Attachment.Value.cac_ExternalReferenceUdid)
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
        }
    }
*(int*)storedPtr_2 = (int)(targetPtr - storedPtr_2 - 4);

}

            {

        if(field.cac_AccountingSupplierParty.cac_PartyUdid!= null)
        {
            int strlen_3 = field.cac_AccountingSupplierParty.cac_PartyUdid.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.cac_AccountingSupplierParty.cac_PartyUdid)
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

        if(field.cac_AccountingCustomerParty.cac_PartyUdid!= null)
        {
            int strlen_3 = field.cac_AccountingCustomerParty.cac_PartyUdid.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.cac_AccountingCustomerParty.cac_PartyUdid)
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

        if(field.cac_PayeeParty.cac_PartyUdid!= null)
        {
            int strlen_3 = field.cac_PayeeParty.cac_PartyUdid.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.cac_PayeeParty.cac_PartyUdid)
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
            *(long*)targetPtr = field.cac_Delivery.cbc_ActualDeliveryDate.ToBinary();
            targetPtr += 8;
        }

            {

            {
            byte* optheader_4 = targetPtr;
            *(optheader_4 + 0) = 0x00;            targetPtr += 1;

        if(field.cac_Delivery.cac_DeliveryLocation.cbc_ID._schemeID!= null)
        {
            int strlen_5 = field.cac_Delivery.cac_DeliveryLocation.cbc_ID._schemeID.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.cac_Delivery.cac_DeliveryLocation.cbc_ID._schemeID)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( field.cac_Delivery.cac_DeliveryLocation.cbc_ID._schemeAgencyID!= null)
            {

        if(field.cac_Delivery.cac_DeliveryLocation.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_5 = field.cac_Delivery.cac_DeliveryLocation.cbc_ID._schemeAgencyID.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.cac_Delivery.cac_DeliveryLocation.cbc_ID._schemeAgencyID)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_4 + 0) |= 0x01;
            }

        if(field.cac_Delivery.cac_DeliveryLocation.cbc_ID.code!= null)
        {
            int strlen_5 = field.cac_Delivery.cac_DeliveryLocation.cbc_ID.code.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.cac_Delivery.cac_DeliveryLocation.cbc_ID.code)
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
        if(field.cac_Delivery.cac_DeliveryLocation.cac_AddressUdid!= null)
        {
            int strlen_4 = field.cac_Delivery.cac_DeliveryLocation.cac_AddressUdid.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.cac_Delivery.cac_DeliveryLocation.cac_AddressUdid)
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
        if(field.cac_PaymentMeansUdid!= null)
        {
            int strlen_2 = field.cac_PaymentMeansUdid.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.cac_PaymentMeansUdid)
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
            *(ISO639_1_LanguageCodes*)targetPtr = field.cac_PaymentTerms.cbc_Note._languageID;
            targetPtr += 1;

        if(field.cac_PaymentTerms.cbc_Note.note!= null)
        {
            int strlen_4 = field.cac_PaymentTerms.cbc_Note.note.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.cac_PaymentTerms.cbc_Note.note)
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
            {

            {

        if(field.cac_LegalMonetaryTotal.cbc_LineExtensionAmount._CurrencyID!= null)
        {
            int strlen_4 = field.cac_LegalMonetaryTotal.cbc_LineExtensionAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.cac_LegalMonetaryTotal.cbc_LineExtensionAmount._CurrencyID)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.cac_LegalMonetaryTotal.cbc_LineExtensionAmount.amount;
            targetPtr += 8;

            }
            {

        if(field.cac_LegalMonetaryTotal.cbc_TaxExclusiveAmount._CurrencyID!= null)
        {
            int strlen_4 = field.cac_LegalMonetaryTotal.cbc_TaxExclusiveAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.cac_LegalMonetaryTotal.cbc_TaxExclusiveAmount._CurrencyID)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.cac_LegalMonetaryTotal.cbc_TaxExclusiveAmount.amount;
            targetPtr += 8;

            }
            {

        if(field.cac_LegalMonetaryTotal.cbc_TaxInclusiveAmount._CurrencyID!= null)
        {
            int strlen_4 = field.cac_LegalMonetaryTotal.cbc_TaxInclusiveAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.cac_LegalMonetaryTotal.cbc_TaxInclusiveAmount._CurrencyID)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.cac_LegalMonetaryTotal.cbc_TaxInclusiveAmount.amount;
            targetPtr += 8;

            }
            {

        if(field.cac_LegalMonetaryTotal.cbc_AllowanceTotalAmount._CurrencyID!= null)
        {
            int strlen_4 = field.cac_LegalMonetaryTotal.cbc_AllowanceTotalAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.cac_LegalMonetaryTotal.cbc_AllowanceTotalAmount._CurrencyID)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.cac_LegalMonetaryTotal.cbc_AllowanceTotalAmount.amount;
            targetPtr += 8;

            }
            {

        if(field.cac_LegalMonetaryTotal.cbc_ChargeTotalAmount._CurrencyID!= null)
        {
            int strlen_4 = field.cac_LegalMonetaryTotal.cbc_ChargeTotalAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.cac_LegalMonetaryTotal.cbc_ChargeTotalAmount._CurrencyID)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.cac_LegalMonetaryTotal.cbc_ChargeTotalAmount.amount;
            targetPtr += 8;

            }
            {

        if(field.cac_LegalMonetaryTotal.cbc_PrepaidAmount._CurrencyID!= null)
        {
            int strlen_4 = field.cac_LegalMonetaryTotal.cbc_PrepaidAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.cac_LegalMonetaryTotal.cbc_PrepaidAmount._CurrencyID)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.cac_LegalMonetaryTotal.cbc_PrepaidAmount.amount;
            targetPtr += 8;

            }
            {

        if(field.cac_LegalMonetaryTotal.cbc_PayableRoundingAmount._CurrencyID!= null)
        {
            int strlen_4 = field.cac_LegalMonetaryTotal.cbc_PayableRoundingAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.cac_LegalMonetaryTotal.cbc_PayableRoundingAmount._CurrencyID)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.cac_LegalMonetaryTotal.cbc_PayableRoundingAmount.amount;
            targetPtr += 8;

            }
            {

        if(field.cac_LegalMonetaryTotal.cbc_PayableAmount._CurrencyID!= null)
        {
            int strlen_4 = field.cac_LegalMonetaryTotal.cbc_PayableAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.cac_LegalMonetaryTotal.cbc_PayableAmount._CurrencyID)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.cac_LegalMonetaryTotal.cbc_PayableAmount.amount;
            targetPtr += 8;

            }
            }
{
byte *storedPtr_2 = targetPtr;

    targetPtr += sizeof(int);
    if(field.cac_InvoiceLine!= null)
    {
        for(int iterator_2 = 0;iterator_2<field.cac_InvoiceLine.Count;++iterator_2)
        {

            {

        if(field.cac_InvoiceLine[iterator_2].cbc_ID!= null)
        {
            int strlen_4 = field.cac_InvoiceLine[iterator_2].cbc_ID.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.cac_InvoiceLine[iterator_2].cbc_ID)
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
            *(ISO639_1_LanguageCodes*)targetPtr = field.cac_InvoiceLine[iterator_2].cbc_Note._languageID;
            targetPtr += 1;

        if(field.cac_InvoiceLine[iterator_2].cbc_Note.note!= null)
        {
            int strlen_5 = field.cac_InvoiceLine[iterator_2].cbc_Note.note.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.cac_InvoiceLine[iterator_2].cbc_Note.note)
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
            {

        if(field.cac_InvoiceLine[iterator_2].cbc_InvoicedQuantity._unitCode!= null)
        {
            int strlen_5 = field.cac_InvoiceLine[iterator_2].cbc_InvoicedQuantity._unitCode.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.cac_InvoiceLine[iterator_2].cbc_InvoicedQuantity._unitCode)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = field.cac_InvoiceLine[iterator_2].cbc_InvoicedQuantity.quantity;
            targetPtr += 8;

            }
            {

        if(field.cac_InvoiceLine[iterator_2].cbc_LineExtensionAmount._CurrencyID!= null)
        {
            int strlen_5 = field.cac_InvoiceLine[iterator_2].cbc_LineExtensionAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.cac_InvoiceLine[iterator_2].cbc_LineExtensionAmount._CurrencyID)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.cac_InvoiceLine[iterator_2].cbc_LineExtensionAmount.amount;
            targetPtr += 8;

            }
        if(field.cac_InvoiceLine[iterator_2].cbc_AccountingCost!= null)
        {
            int strlen_4 = field.cac_InvoiceLine[iterator_2].cbc_AccountingCost.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.cac_InvoiceLine[iterator_2].cbc_AccountingCost)
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

        if(field.cac_InvoiceLine[iterator_2].cac_OrderLineReference.cbc_LineID!= null)
        {
            int strlen_5 = field.cac_InvoiceLine[iterator_2].cac_OrderLineReference.cbc_LineID.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.cac_InvoiceLine[iterator_2].cac_OrderLineReference.cbc_LineID)
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
{
byte *storedPtr_4 = targetPtr;

    targetPtr += sizeof(int);
    if(field.cac_InvoiceLine[iterator_2].cac_AllowanceCharges!= null)
    {
        for(int iterator_4 = 0;iterator_4<field.cac_InvoiceLine[iterator_2].cac_AllowanceCharges.Count;++iterator_4)
        {

            {
            *(bool*)targetPtr = field.cac_InvoiceLine[iterator_2].cac_AllowanceCharges[iterator_4].cbc_ChargeIndicator;
            targetPtr += 1;

        if(field.cac_InvoiceLine[iterator_2].cac_AllowanceCharges[iterator_4].cbc_AllowanceChargeReason!= null)
        {
            int strlen_6 = field.cac_InvoiceLine[iterator_2].cac_AllowanceCharges[iterator_4].cbc_AllowanceChargeReason.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = field.cac_InvoiceLine[iterator_2].cac_AllowanceCharges[iterator_4].cbc_AllowanceChargeReason)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            {

        if(field.cac_InvoiceLine[iterator_2].cac_AllowanceCharges[iterator_4].cbc_Amount._CurrencyID!= null)
        {
            int strlen_7 = field.cac_InvoiceLine[iterator_2].cac_AllowanceCharges[iterator_4].cbc_Amount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_7;
            targetPtr += sizeof(int);
            fixed(char* pstr_7 = field.cac_InvoiceLine[iterator_2].cac_AllowanceCharges[iterator_4].cbc_Amount._CurrencyID)
            {
                Memory.Copy(pstr_7, targetPtr, strlen_7);
                targetPtr += strlen_7;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.cac_InvoiceLine[iterator_2].cac_AllowanceCharges[iterator_4].cbc_Amount.amount;
            targetPtr += 8;

            }
            }
        }
    }
*(int*)storedPtr_4 = (int)(targetPtr - storedPtr_4 - 4);

}

            {

            {

        if(field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_6 = field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cbc_TaxAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cbc_TaxAmount._CurrencyID)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cbc_TaxAmount.amount;
            targetPtr += 8;

            }
{
byte *storedPtr_5 = targetPtr;

    targetPtr += sizeof(int);
    if(field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals!= null)
    {
        for(int iterator_5 = 0;iterator_5<field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals.Count;++iterator_5)
        {

            {

            {

        if(field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cbc_TaxableAmount._CurrencyID!= null)
        {
            int strlen_8 = field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cbc_TaxableAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_8;
            targetPtr += sizeof(int);
            fixed(char* pstr_8 = field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cbc_TaxableAmount._CurrencyID)
            {
                Memory.Copy(pstr_8, targetPtr, strlen_8);
                targetPtr += strlen_8;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cbc_TaxableAmount.amount;
            targetPtr += 8;

            }
            {

        if(field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_8 = field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cbc_TaxAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_8;
            targetPtr += sizeof(int);
            fixed(char* pstr_8 = field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cbc_TaxAmount._CurrencyID)
            {
                Memory.Copy(pstr_8, targetPtr, strlen_8);
                targetPtr += strlen_8;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cbc_TaxAmount.amount;
            targetPtr += 8;

            }
            {

            {
            byte* optheader_8 = targetPtr;
            *(optheader_8 + 0) = 0x00;            targetPtr += 1;

        if(field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cac_TaxCategory.cbc_ID._schemeID!= null)
        {
            int strlen_9 = field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cac_TaxCategory.cbc_ID._schemeID.Length * 2;
            *(int*)targetPtr = strlen_9;
            targetPtr += sizeof(int);
            fixed(char* pstr_9 = field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cac_TaxCategory.cbc_ID._schemeID)
            {
                Memory.Copy(pstr_9, targetPtr, strlen_9);
                targetPtr += strlen_9;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
            {

        if(field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_9 = field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cac_TaxCategory.cbc_ID._schemeAgencyID.Length * 2;
            *(int*)targetPtr = strlen_9;
            targetPtr += sizeof(int);
            fixed(char* pstr_9 = field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cac_TaxCategory.cbc_ID._schemeAgencyID)
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

        if(field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cac_TaxCategory.cbc_ID.code!= null)
        {
            int strlen_9 = field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cac_TaxCategory.cbc_ID.code.Length * 2;
            *(int*)targetPtr = strlen_9;
            targetPtr += sizeof(int);
            fixed(char* pstr_9 = field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cac_TaxCategory.cbc_ID.code)
            {
                Memory.Copy(pstr_9, targetPtr, strlen_9);
                targetPtr += strlen_9;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }            *(double*)targetPtr = field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cac_TaxCategory.cbc_Percent;
            targetPtr += 8;

            {

            {
            byte* optheader_9 = targetPtr;
            *(optheader_9 + 0) = 0x00;            targetPtr += 1;

        if(field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID!= null)
        {
            int strlen_10 = field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID.Length * 2;
            *(int*)targetPtr = strlen_10;
            targetPtr += sizeof(int);
            fixed(char* pstr_10 = field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID)
            {
                Memory.Copy(pstr_10, targetPtr, strlen_10);
                targetPtr += strlen_10;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
            {

        if(field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_10 = field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID.Length * 2;
            *(int*)targetPtr = strlen_10;
            targetPtr += sizeof(int);
            fixed(char* pstr_10 = field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID)
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

        if(field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cac_TaxCategory.cac_TaxScheme.cbc_ID.code!= null)
        {
            int strlen_10 = field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cac_TaxCategory.cac_TaxScheme.cbc_ID.code.Length * 2;
            *(int*)targetPtr = strlen_10;
            targetPtr += sizeof(int);
            fixed(char* pstr_10 = field.cac_InvoiceLine[iterator_2].cac_TaxTotal.cac_TaxSubtotals[iterator_5].cac_TaxCategory.cac_TaxScheme.cbc_ID.code)
            {
                Memory.Copy(pstr_10, targetPtr, strlen_10);
                targetPtr += strlen_10;
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
*(int*)storedPtr_5 = (int)(targetPtr - storedPtr_5 - 4);

}

            }
        if(field.cac_InvoiceLine[iterator_2].cac_ItemUdid!= null)
        {
            int strlen_4 = field.cac_InvoiceLine[iterator_2].cac_ItemUdid.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.cac_InvoiceLine[iterator_2].cac_ItemUdid)
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

            {

        if(field.cac_InvoiceLine[iterator_2].cac_Price.cbc_PriceAmount._CurrencyID!= null)
        {
            int strlen_6 = field.cac_InvoiceLine[iterator_2].cac_Price.cbc_PriceAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = field.cac_InvoiceLine[iterator_2].cac_Price.cbc_PriceAmount._CurrencyID)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.cac_InvoiceLine[iterator_2].cac_Price.cbc_PriceAmount.amount;
            targetPtr += 8;

            }
            {

        if(field.cac_InvoiceLine[iterator_2].cac_Price.cbc_BaseQuantity._unitCode!= null)
        {
            int strlen_6 = field.cac_InvoiceLine[iterator_2].cac_Price.cbc_BaseQuantity._unitCode.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = field.cac_InvoiceLine[iterator_2].cac_Price.cbc_BaseQuantity._unitCode)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = field.cac_InvoiceLine[iterator_2].cac_Price.cbc_BaseQuantity.quantity;
            targetPtr += 8;

            }
            {
            *(bool*)targetPtr = field.cac_InvoiceLine[iterator_2].cac_Price.cac_AllowanceCharge.cbc_ChargeIndicator;
            targetPtr += 1;

        if(field.cac_InvoiceLine[iterator_2].cac_Price.cac_AllowanceCharge.cbc_AllowanceChargeReason!= null)
        {
            int strlen_6 = field.cac_InvoiceLine[iterator_2].cac_Price.cac_AllowanceCharge.cbc_AllowanceChargeReason.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = field.cac_InvoiceLine[iterator_2].cac_Price.cac_AllowanceCharge.cbc_AllowanceChargeReason)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            {

        if(field.cac_InvoiceLine[iterator_2].cac_Price.cac_AllowanceCharge.cbc_Amount._CurrencyID!= null)
        {
            int strlen_7 = field.cac_InvoiceLine[iterator_2].cac_Price.cac_AllowanceCharge.cbc_Amount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_7;
            targetPtr += sizeof(int);
            fixed(char* pstr_7 = field.cac_InvoiceLine[iterator_2].cac_Price.cac_AllowanceCharge.cbc_Amount._CurrencyID)
            {
                Memory.Copy(pstr_7, targetPtr, strlen_7);
                targetPtr += strlen_7;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field.cac_InvoiceLine[iterator_2].cac_Price.cac_AllowanceCharge.cbc_Amount.amount;
            targetPtr += 8;

            }
            }
            }
            }
        }
    }
*(int*)storedPtr_2 = (int)(targetPtr - storedPtr_2 - 4);

}

            }UBL21_Invoice2_Claims_Accessor ret;
            
            ret = new UBL21_Invoice2_Claims_Accessor(tmpcellptr, null);
            
            return ret;
        }
        
        public static bool operator ==(UBL21_Invoice2_Claims_Accessor a, UBL21_Invoice2_Claims_Accessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            byte* targetPtr = a.m_ptr;
            {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
{targetPtr += *(int*)targetPtr + sizeof(int);}{            byte* optheader_3 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_3 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 8;
{{            byte* optheader_7 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_7 + 0) & 0x01)))
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
            int lengthA = (int)(targetPtr - a.m_ptr);
            targetPtr = b.m_ptr;
            {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
{targetPtr += *(int*)targetPtr + sizeof(int);}{            byte* optheader_3 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_3 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);}{            targetPtr += 8;
{{            byte* optheader_7 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_7 + 0) & 0x01)))
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
            int lengthB = (int)(targetPtr - b.m_ptr);
            if(lengthA != lengthB) return false;
            return Memory.Compare(a.m_ptr,b.m_ptr,lengthA);
        }
        public static bool operator != (UBL21_Invoice2_Claims_Accessor a, UBL21_Invoice2_Claims_Accessor b)
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
