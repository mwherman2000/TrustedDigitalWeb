#pragma warning disable 162,168,649,660,661,1522

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Trinity;
using Trinity.Storage;
using Trinity.TSL;
using Trinity.TSL.Lib;
namespace TDW.TRAServer
{
    class Throw
    {
        
        internal static void parse_bool(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into bool.");
        }
        internal static void incompatible_with_bool()
        {
            throw new DataTypeIncompatibleException("Data type 'bool' not compatible with the target field.");
        }
        
        internal static void parse_long(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into long.");
        }
        internal static void incompatible_with_long()
        {
            throw new DataTypeIncompatibleException("Data type 'long' not compatible with the target field.");
        }
        
        internal static void parse_double(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into double.");
        }
        internal static void incompatible_with_double()
        {
            throw new DataTypeIncompatibleException("Data type 'double' not compatible with the target field.");
        }
        
        internal static void parse_DateTime(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into DateTime.");
        }
        internal static void incompatible_with_DateTime()
        {
            throw new DataTypeIncompatibleException("Data type 'DateTime' not compatible with the target field.");
        }
        
        internal static void parse_string(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into string.");
        }
        internal static void incompatible_with_string()
        {
            throw new DataTypeIncompatibleException("Data type 'string' not compatible with the target field.");
        }
        
        internal static void parse_List_string(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into List<string>.");
        }
        internal static void incompatible_with_List_string()
        {
            throw new DataTypeIncompatibleException("Data type 'List<string>' not compatible with the target field.");
        }
        
        internal static void parse_List_Cac_AllowanceCharge(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into List<Cac_AllowanceCharge>.");
        }
        internal static void incompatible_with_List_Cac_AllowanceCharge()
        {
            throw new DataTypeIncompatibleException("Data type 'List<Cac_AllowanceCharge>' not compatible with the target field.");
        }
        
        internal static void parse_List_Cac_DocumentReference(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into List<Cac_DocumentReference>.");
        }
        internal static void incompatible_with_List_Cac_DocumentReference()
        {
            throw new DataTypeIncompatibleException("Data type 'List<Cac_DocumentReference>' not compatible with the target field.");
        }
        
        internal static void parse_List_Cac_InvoiceLine(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into List<Cac_InvoiceLine>.");
        }
        internal static void incompatible_with_List_Cac_InvoiceLine()
        {
            throw new DataTypeIncompatibleException("Data type 'List<Cac_InvoiceLine>' not compatible with the target field.");
        }
        
        internal static void parse_List_Cac_TaxSubtotal(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into List<Cac_TaxSubtotal>.");
        }
        internal static void incompatible_with_List_Cac_TaxSubtotal()
        {
            throw new DataTypeIncompatibleException("Data type 'List<Cac_TaxSubtotal>' not compatible with the target field.");
        }
        
        internal static void parse_List_Cbc_ListCode(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into List<Cbc_ListCode>.");
        }
        internal static void incompatible_with_List_Cbc_ListCode()
        {
            throw new DataTypeIncompatibleException("Data type 'List<Cbc_ListCode>' not compatible with the target field.");
        }
        
        internal static void parse_List_TRAClaim(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into List<TRAClaim>.");
        }
        internal static void incompatible_with_List_TRAClaim()
        {
            throw new DataTypeIncompatibleException("Data type 'List<TRAClaim>' not compatible with the target field.");
        }
        
        internal static void parse_List_TRAKeyValuePair(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into List<TRAKeyValuePair>.");
        }
        internal static void incompatible_with_List_TRAKeyValuePair()
        {
            throw new DataTypeIncompatibleException("Data type 'List<TRAKeyValuePair>' not compatible with the target field.");
        }
        
        internal static void parse_Cac_AccountingCustomerParty(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_AccountingCustomerParty.");
        }
        internal static void incompatible_with_Cac_AccountingCustomerParty()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_AccountingCustomerParty' not compatible with the target field.");
        }
        
        internal static void parse_Cac_AccountingSupplierParty(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_AccountingSupplierParty.");
        }
        internal static void incompatible_with_Cac_AccountingSupplierParty()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_AccountingSupplierParty' not compatible with the target field.");
        }
        
        internal static void parse_Cac_Address_Claims(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_Address_Claims.");
        }
        internal static void incompatible_with_Cac_Address_Claims()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_Address_Claims' not compatible with the target field.");
        }
        
        internal static void parse_Cac_Address_Envelope(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_Address_Envelope.");
        }
        internal static void incompatible_with_Cac_Address_Envelope()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_Address_Envelope' not compatible with the target field.");
        }
        
        internal static void parse_Cac_Address_EnvelopeContent(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_Address_EnvelopeContent.");
        }
        internal static void incompatible_with_Cac_Address_EnvelopeContent()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_Address_EnvelopeContent' not compatible with the target field.");
        }
        
        internal static void parse_Cac_AllowanceCharge(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_AllowanceCharge.");
        }
        internal static void incompatible_with_Cac_AllowanceCharge()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_AllowanceCharge' not compatible with the target field.");
        }
        
        internal static void parse_Cac_Attachment(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_Attachment.");
        }
        internal static void incompatible_with_Cac_Attachment()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_Attachment' not compatible with the target field.");
        }
        
        internal static void parse_Cac_ClassifiedTaxCategory(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_ClassifiedTaxCategory.");
        }
        internal static void incompatible_with_Cac_ClassifiedTaxCategory()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_ClassifiedTaxCategory' not compatible with the target field.");
        }
        
        internal static void parse_Cac_Contact_Claims(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_Contact_Claims.");
        }
        internal static void incompatible_with_Cac_Contact_Claims()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_Contact_Claims' not compatible with the target field.");
        }
        
        internal static void parse_Cac_Contact_Envelope(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_Contact_Envelope.");
        }
        internal static void incompatible_with_Cac_Contact_Envelope()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_Contact_Envelope' not compatible with the target field.");
        }
        
        internal static void parse_Cac_Contact_EnvelopeContent(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_Contact_EnvelopeContent.");
        }
        internal static void incompatible_with_Cac_Contact_EnvelopeContent()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_Contact_EnvelopeContent' not compatible with the target field.");
        }
        
        internal static void parse_Cac_Country(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_Country.");
        }
        internal static void incompatible_with_Cac_Country()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_Country' not compatible with the target field.");
        }
        
        internal static void parse_Cac_Delivery(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_Delivery.");
        }
        internal static void incompatible_with_Cac_Delivery()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_Delivery' not compatible with the target field.");
        }
        
        internal static void parse_Cac_DeliveryLocation(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_DeliveryLocation.");
        }
        internal static void incompatible_with_Cac_DeliveryLocation()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_DeliveryLocation' not compatible with the target field.");
        }
        
        internal static void parse_Cac_DocumentReference(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_DocumentReference.");
        }
        internal static void incompatible_with_Cac_DocumentReference()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_DocumentReference' not compatible with the target field.");
        }
        
        internal static void parse_Cac_ExternalReference_Claims(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_ExternalReference_Claims.");
        }
        internal static void incompatible_with_Cac_ExternalReference_Claims()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_ExternalReference_Claims' not compatible with the target field.");
        }
        
        internal static void parse_Cac_ExternalReference_Envelope(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_ExternalReference_Envelope.");
        }
        internal static void incompatible_with_Cac_ExternalReference_Envelope()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_ExternalReference_Envelope' not compatible with the target field.");
        }
        
        internal static void parse_Cac_ExternalReference_EnvelopeContent(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_ExternalReference_EnvelopeContent.");
        }
        internal static void incompatible_with_Cac_ExternalReference_EnvelopeContent()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_ExternalReference_EnvelopeContent' not compatible with the target field.");
        }
        
        internal static void parse_Cac_FinancialInstitution(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_FinancialInstitution.");
        }
        internal static void incompatible_with_Cac_FinancialInstitution()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_FinancialInstitution' not compatible with the target field.");
        }
        
        internal static void parse_Cac_FinancialInstitutionBranch(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_FinancialInstitutionBranch.");
        }
        internal static void incompatible_with_Cac_FinancialInstitutionBranch()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_FinancialInstitutionBranch' not compatible with the target field.");
        }
        
        internal static void parse_Cac_InvoiceLine(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_InvoiceLine.");
        }
        internal static void incompatible_with_Cac_InvoiceLine()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_InvoiceLine' not compatible with the target field.");
        }
        
        internal static void parse_Cac_Item_Claims(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_Item_Claims.");
        }
        internal static void incompatible_with_Cac_Item_Claims()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_Item_Claims' not compatible with the target field.");
        }
        
        internal static void parse_Cac_Item_Envelope(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_Item_Envelope.");
        }
        internal static void incompatible_with_Cac_Item_Envelope()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_Item_Envelope' not compatible with the target field.");
        }
        
        internal static void parse_Cac_Item_EnvelopeContent(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_Item_EnvelopeContent.");
        }
        internal static void incompatible_with_Cac_Item_EnvelopeContent()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_Item_EnvelopeContent' not compatible with the target field.");
        }
        
        internal static void parse_Cac_LegalMonetaryTotal(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_LegalMonetaryTotal.");
        }
        internal static void incompatible_with_Cac_LegalMonetaryTotal()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_LegalMonetaryTotal' not compatible with the target field.");
        }
        
        internal static void parse_Cac_OrderLineReference(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_OrderLineReference.");
        }
        internal static void incompatible_with_Cac_OrderLineReference()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_OrderLineReference' not compatible with the target field.");
        }
        
        internal static void parse_Cac_PartyIdentification(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_PartyIdentification.");
        }
        internal static void incompatible_with_Cac_PartyIdentification()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_PartyIdentification' not compatible with the target field.");
        }
        
        internal static void parse_Cac_PartyLegalEntity_Claims(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_PartyLegalEntity_Claims.");
        }
        internal static void incompatible_with_Cac_PartyLegalEntity_Claims()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_PartyLegalEntity_Claims' not compatible with the target field.");
        }
        
        internal static void parse_Cac_PartyLegalEntity_Envelope(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_PartyLegalEntity_Envelope.");
        }
        internal static void incompatible_with_Cac_PartyLegalEntity_Envelope()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_PartyLegalEntity_Envelope' not compatible with the target field.");
        }
        
        internal static void parse_Cac_PartyLegalEntity_EnvelopeContent(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_PartyLegalEntity_EnvelopeContent.");
        }
        internal static void incompatible_with_Cac_PartyLegalEntity_EnvelopeContent()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_PartyLegalEntity_EnvelopeContent' not compatible with the target field.");
        }
        
        internal static void parse_Cac_PartyName(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_PartyName.");
        }
        internal static void incompatible_with_Cac_PartyName()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_PartyName' not compatible with the target field.");
        }
        
        internal static void parse_Cac_PartyTaxScheme(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_PartyTaxScheme.");
        }
        internal static void incompatible_with_Cac_PartyTaxScheme()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_PartyTaxScheme' not compatible with the target field.");
        }
        
        internal static void parse_Cac_Party_Claims(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_Party_Claims.");
        }
        internal static void incompatible_with_Cac_Party_Claims()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_Party_Claims' not compatible with the target field.");
        }
        
        internal static void parse_Cac_Party_Envelope(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_Party_Envelope.");
        }
        internal static void incompatible_with_Cac_Party_Envelope()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_Party_Envelope' not compatible with the target field.");
        }
        
        internal static void parse_Cac_Party_EnvelopeContent(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_Party_EnvelopeContent.");
        }
        internal static void incompatible_with_Cac_Party_EnvelopeContent()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_Party_EnvelopeContent' not compatible with the target field.");
        }
        
        internal static void parse_Cac_PayeeFinancialAccount_Claims(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_PayeeFinancialAccount_Claims.");
        }
        internal static void incompatible_with_Cac_PayeeFinancialAccount_Claims()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_PayeeFinancialAccount_Claims' not compatible with the target field.");
        }
        
        internal static void parse_Cac_PayeeFinancialAccount_Envelope(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_PayeeFinancialAccount_Envelope.");
        }
        internal static void incompatible_with_Cac_PayeeFinancialAccount_Envelope()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_PayeeFinancialAccount_Envelope' not compatible with the target field.");
        }
        
        internal static void parse_Cac_PayeeFinancialAccount_EnvelopeContent(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_PayeeFinancialAccount_EnvelopeContent.");
        }
        internal static void incompatible_with_Cac_PayeeFinancialAccount_EnvelopeContent()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_PayeeFinancialAccount_EnvelopeContent' not compatible with the target field.");
        }
        
        internal static void parse_Cac_PayeeParty(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_PayeeParty.");
        }
        internal static void incompatible_with_Cac_PayeeParty()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_PayeeParty' not compatible with the target field.");
        }
        
        internal static void parse_Cac_PaymentMeans_Claims(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_PaymentMeans_Claims.");
        }
        internal static void incompatible_with_Cac_PaymentMeans_Claims()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_PaymentMeans_Claims' not compatible with the target field.");
        }
        
        internal static void parse_Cac_PaymentMeans_Envelope(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_PaymentMeans_Envelope.");
        }
        internal static void incompatible_with_Cac_PaymentMeans_Envelope()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_PaymentMeans_Envelope' not compatible with the target field.");
        }
        
        internal static void parse_Cac_PaymentMeans_EnvelopeContent(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_PaymentMeans_EnvelopeContent.");
        }
        internal static void incompatible_with_Cac_PaymentMeans_EnvelopeContent()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_PaymentMeans_EnvelopeContent' not compatible with the target field.");
        }
        
        internal static void parse_Cac_PaymentTerms(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_PaymentTerms.");
        }
        internal static void incompatible_with_Cac_PaymentTerms()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_PaymentTerms' not compatible with the target field.");
        }
        
        internal static void parse_Cac_Person_Claims(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_Person_Claims.");
        }
        internal static void incompatible_with_Cac_Person_Claims()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_Person_Claims' not compatible with the target field.");
        }
        
        internal static void parse_Cac_Person_Envelope(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_Person_Envelope.");
        }
        internal static void incompatible_with_Cac_Person_Envelope()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_Person_Envelope' not compatible with the target field.");
        }
        
        internal static void parse_Cac_Person_EnvelopeContent(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_Person_EnvelopeContent.");
        }
        internal static void incompatible_with_Cac_Person_EnvelopeContent()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_Person_EnvelopeContent' not compatible with the target field.");
        }
        
        internal static void parse_Cac_Price(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_Price.");
        }
        internal static void incompatible_with_Cac_Price()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_Price' not compatible with the target field.");
        }
        
        internal static void parse_Cac_SellersItemIdentification(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_SellersItemIdentification.");
        }
        internal static void incompatible_with_Cac_SellersItemIdentification()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_SellersItemIdentification' not compatible with the target field.");
        }
        
        internal static void parse_Cac_TaxCategory(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_TaxCategory.");
        }
        internal static void incompatible_with_Cac_TaxCategory()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_TaxCategory' not compatible with the target field.");
        }
        
        internal static void parse_Cac_TaxScheme(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_TaxScheme.");
        }
        internal static void incompatible_with_Cac_TaxScheme()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_TaxScheme' not compatible with the target field.");
        }
        
        internal static void parse_Cac_TaxSubtotal(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_TaxSubtotal.");
        }
        internal static void incompatible_with_Cac_TaxSubtotal()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_TaxSubtotal' not compatible with the target field.");
        }
        
        internal static void parse_Cac_TaxTotal(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_TaxTotal.");
        }
        internal static void incompatible_with_Cac_TaxTotal()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_TaxTotal' not compatible with the target field.");
        }
        
        internal static void parse_Cbc_Amount(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cbc_Amount.");
        }
        internal static void incompatible_with_Cbc_Amount()
        {
            throw new DataTypeIncompatibleException("Data type 'Cbc_Amount' not compatible with the target field.");
        }
        
        internal static void parse_Cbc_EmbeddedDocumentBinaryObject(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cbc_EmbeddedDocumentBinaryObject.");
        }
        internal static void incompatible_with_Cbc_EmbeddedDocumentBinaryObject()
        {
            throw new DataTypeIncompatibleException("Data type 'Cbc_EmbeddedDocumentBinaryObject' not compatible with the target field.");
        }
        
        internal static void parse_Cbc_ListCode(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cbc_ListCode.");
        }
        internal static void incompatible_with_Cbc_ListCode()
        {
            throw new DataTypeIncompatibleException("Data type 'Cbc_ListCode' not compatible with the target field.");
        }
        
        internal static void parse_Cbc_Note(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cbc_Note.");
        }
        internal static void incompatible_with_Cbc_Note()
        {
            throw new DataTypeIncompatibleException("Data type 'Cbc_Note' not compatible with the target field.");
        }
        
        internal static void parse_Cbc_OrderReference(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cbc_OrderReference.");
        }
        internal static void incompatible_with_Cbc_OrderReference()
        {
            throw new DataTypeIncompatibleException("Data type 'Cbc_OrderReference' not compatible with the target field.");
        }
        
        internal static void parse_Cbc_Quantity(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cbc_Quantity.");
        }
        internal static void incompatible_with_Cbc_Quantity()
        {
            throw new DataTypeIncompatibleException("Data type 'Cbc_Quantity' not compatible with the target field.");
        }
        
        internal static void parse_Cbc_SchemeCode(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cbc_SchemeCode.");
        }
        internal static void incompatible_with_Cbc_SchemeCode()
        {
            throw new DataTypeIncompatibleException("Data type 'Cbc_SchemeCode' not compatible with the target field.");
        }
        
        internal static void parse_Cbc_TimePeriod(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cbc_TimePeriod.");
        }
        internal static void incompatible_with_Cbc_TimePeriod()
        {
            throw new DataTypeIncompatibleException("Data type 'Cbc_TimePeriod' not compatible with the target field.");
        }
        
        internal static void parse_TRAClaim(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRAClaim.");
        }
        internal static void incompatible_with_TRAClaim()
        {
            throw new DataTypeIncompatibleException("Data type 'TRAClaim' not compatible with the target field.");
        }
        
        internal static void parse_TRACredential_Envelope(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRACredential_Envelope.");
        }
        internal static void incompatible_with_TRACredential_Envelope()
        {
            throw new DataTypeIncompatibleException("Data type 'TRACredential_Envelope' not compatible with the target field.");
        }
        
        internal static void parse_TRACredential_EnvelopeContent(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRACredential_EnvelopeContent.");
        }
        internal static void incompatible_with_TRACredential_EnvelopeContent()
        {
            throw new DataTypeIncompatibleException("Data type 'TRACredential_EnvelopeContent' not compatible with the target field.");
        }
        
        internal static void parse_TRACredential_EnvelopeSeal(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRACredential_EnvelopeSeal.");
        }
        internal static void incompatible_with_TRACredential_EnvelopeSeal()
        {
            throw new DataTypeIncompatibleException("Data type 'TRACredential_EnvelopeSeal' not compatible with the target field.");
        }
        
        internal static void parse_TRACredential_PackingLabel(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRACredential_PackingLabel.");
        }
        internal static void incompatible_with_TRACredential_PackingLabel()
        {
            throw new DataTypeIncompatibleException("Data type 'TRACredential_PackingLabel' not compatible with the target field.");
        }
        
        internal static void parse_TRAEncryptedClaims(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRAEncryptedClaims.");
        }
        internal static void incompatible_with_TRAEncryptedClaims()
        {
            throw new DataTypeIncompatibleException("Data type 'TRAEncryptedClaims' not compatible with the target field.");
        }
        
        internal static void parse_TRAGeoLocation_Claims(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRAGeoLocation_Claims.");
        }
        internal static void incompatible_with_TRAGeoLocation_Claims()
        {
            throw new DataTypeIncompatibleException("Data type 'TRAGeoLocation_Claims' not compatible with the target field.");
        }
        
        internal static void parse_TRAGeoLocation_Envelope(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRAGeoLocation_Envelope.");
        }
        internal static void incompatible_with_TRAGeoLocation_Envelope()
        {
            throw new DataTypeIncompatibleException("Data type 'TRAGeoLocation_Envelope' not compatible with the target field.");
        }
        
        internal static void parse_TRAGeoLocation_EnvelopeContent(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRAGeoLocation_EnvelopeContent.");
        }
        internal static void incompatible_with_TRAGeoLocation_EnvelopeContent()
        {
            throw new DataTypeIncompatibleException("Data type 'TRAGeoLocation_EnvelopeContent' not compatible with the target field.");
        }
        
        internal static void parse_TRAKeyValuePair(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRAKeyValuePair.");
        }
        internal static void incompatible_with_TRAKeyValuePair()
        {
            throw new DataTypeIncompatibleException("Data type 'TRAKeyValuePair' not compatible with the target field.");
        }
        
        internal static void parse_TRAPostalAddress_Claims(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRAPostalAddress_Claims.");
        }
        internal static void incompatible_with_TRAPostalAddress_Claims()
        {
            throw new DataTypeIncompatibleException("Data type 'TRAPostalAddress_Claims' not compatible with the target field.");
        }
        
        internal static void parse_TRAPostalAddress_Envelope(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRAPostalAddress_Envelope.");
        }
        internal static void incompatible_with_TRAPostalAddress_Envelope()
        {
            throw new DataTypeIncompatibleException("Data type 'TRAPostalAddress_Envelope' not compatible with the target field.");
        }
        
        internal static void parse_TRAPostalAddress_EnvelopeContent(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRAPostalAddress_EnvelopeContent.");
        }
        internal static void incompatible_with_TRAPostalAddress_EnvelopeContent()
        {
            throw new DataTypeIncompatibleException("Data type 'TRAPostalAddress_EnvelopeContent' not compatible with the target field.");
        }
        
        internal static void parse_TRATimestamp_Claims(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRATimestamp_Claims.");
        }
        internal static void incompatible_with_TRATimestamp_Claims()
        {
            throw new DataTypeIncompatibleException("Data type 'TRATimestamp_Claims' not compatible with the target field.");
        }
        
        internal static void parse_TRATimestamp_Envelope(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRATimestamp_Envelope.");
        }
        internal static void incompatible_with_TRATimestamp_Envelope()
        {
            throw new DataTypeIncompatibleException("Data type 'TRATimestamp_Envelope' not compatible with the target field.");
        }
        
        internal static void parse_TRATimestamp_EnvelopeContent(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRATimestamp_EnvelopeContent.");
        }
        internal static void incompatible_with_TRATimestamp_EnvelopeContent()
        {
            throw new DataTypeIncompatibleException("Data type 'TRATimestamp_EnvelopeContent' not compatible with the target field.");
        }
        
        internal static void parse_UBL21_Invoice2_Claims(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into UBL21_Invoice2_Claims.");
        }
        internal static void incompatible_with_UBL21_Invoice2_Claims()
        {
            throw new DataTypeIncompatibleException("Data type 'UBL21_Invoice2_Claims' not compatible with the target field.");
        }
        
        internal static void parse_UBL21_Invoice2_Envelope(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into UBL21_Invoice2_Envelope.");
        }
        internal static void incompatible_with_UBL21_Invoice2_Envelope()
        {
            throw new DataTypeIncompatibleException("Data type 'UBL21_Invoice2_Envelope' not compatible with the target field.");
        }
        
        internal static void parse_UBL21_Invoice2_EnvelopeContent(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into UBL21_Invoice2_EnvelopeContent.");
        }
        internal static void incompatible_with_UBL21_Invoice2_EnvelopeContent()
        {
            throw new DataTypeIncompatibleException("Data type 'UBL21_Invoice2_EnvelopeContent' not compatible with the target field.");
        }
        
        internal static void parse_ISO639_1_LanguageCodes(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into ISO639_1_LanguageCodes.");
        }
        internal static void incompatible_with_ISO639_1_LanguageCodes()
        {
            throw new DataTypeIncompatibleException("Data type 'ISO639_1_LanguageCodes' not compatible with the target field.");
        }
        
        internal static void parse_TRACredentialType(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRACredentialType.");
        }
        internal static void incompatible_with_TRACredentialType()
        {
            throw new DataTypeIncompatibleException("Data type 'TRACredentialType' not compatible with the target field.");
        }
        
        internal static void parse_TRAEncryptionFlag(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRAEncryptionFlag.");
        }
        internal static void incompatible_with_TRAEncryptionFlag()
        {
            throw new DataTypeIncompatibleException("Data type 'TRAEncryptionFlag' not compatible with the target field.");
        }
        
        internal static void parse_TRATrustLevel(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRATrustLevel.");
        }
        internal static void incompatible_with_TRATrustLevel()
        {
            throw new DataTypeIncompatibleException("Data type 'TRATrustLevel' not compatible with the target field.");
        }
        
        internal static void parse_List_List_TRAKeyValuePair(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into List<List<TRAKeyValuePair>>.");
        }
        internal static void incompatible_with_List_List_TRAKeyValuePair()
        {
            throw new DataTypeIncompatibleException("Data type 'List<List<TRAKeyValuePair>>' not compatible with the target field.");
        }
        
        internal static void parse_Cac_Address_Claims_nullable(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_Address_Claims?.");
        }
        internal static void incompatible_with_Cac_Address_Claims_nullable()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_Address_Claims?' not compatible with the target field.");
        }
        
        internal static void parse_Cac_Attachment_nullable(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_Attachment?.");
        }
        internal static void incompatible_with_Cac_Attachment_nullable()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_Attachment?' not compatible with the target field.");
        }
        
        internal static void parse_Cac_Contact_Claims_nullable(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_Contact_Claims?.");
        }
        internal static void incompatible_with_Cac_Contact_Claims_nullable()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_Contact_Claims?' not compatible with the target field.");
        }
        
        internal static void parse_Cac_ExternalReference_Claims_nullable(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_ExternalReference_Claims?.");
        }
        internal static void incompatible_with_Cac_ExternalReference_Claims_nullable()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_ExternalReference_Claims?' not compatible with the target field.");
        }
        
        internal static void parse_Cac_Item_Claims_nullable(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_Item_Claims?.");
        }
        internal static void incompatible_with_Cac_Item_Claims_nullable()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_Item_Claims?' not compatible with the target field.");
        }
        
        internal static void parse_Cac_PartyLegalEntity_Claims_nullable(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_PartyLegalEntity_Claims?.");
        }
        internal static void incompatible_with_Cac_PartyLegalEntity_Claims_nullable()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_PartyLegalEntity_Claims?' not compatible with the target field.");
        }
        
        internal static void parse_Cac_Party_Claims_nullable(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_Party_Claims?.");
        }
        internal static void incompatible_with_Cac_Party_Claims_nullable()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_Party_Claims?' not compatible with the target field.");
        }
        
        internal static void parse_Cac_PayeeFinancialAccount_Claims_nullable(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_PayeeFinancialAccount_Claims?.");
        }
        internal static void incompatible_with_Cac_PayeeFinancialAccount_Claims_nullable()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_PayeeFinancialAccount_Claims?' not compatible with the target field.");
        }
        
        internal static void parse_Cac_PaymentMeans_Claims_nullable(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_PaymentMeans_Claims?.");
        }
        internal static void incompatible_with_Cac_PaymentMeans_Claims_nullable()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_PaymentMeans_Claims?' not compatible with the target field.");
        }
        
        internal static void parse_Cac_Person_Claims_nullable(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cac_Person_Claims?.");
        }
        internal static void incompatible_with_Cac_Person_Claims_nullable()
        {
            throw new DataTypeIncompatibleException("Data type 'Cac_Person_Claims?' not compatible with the target field.");
        }
        
        internal static void parse_Cbc_EmbeddedDocumentBinaryObject_nullable(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Cbc_EmbeddedDocumentBinaryObject?.");
        }
        internal static void incompatible_with_Cbc_EmbeddedDocumentBinaryObject_nullable()
        {
            throw new DataTypeIncompatibleException("Data type 'Cbc_EmbeddedDocumentBinaryObject?' not compatible with the target field.");
        }
        
        internal static void parse_TRAEncryptedClaims_nullable(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRAEncryptedClaims?.");
        }
        internal static void incompatible_with_TRAEncryptedClaims_nullable()
        {
            throw new DataTypeIncompatibleException("Data type 'TRAEncryptedClaims?' not compatible with the target field.");
        }
        
        internal static void parse_TRAGeoLocation_Claims_nullable(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRAGeoLocation_Claims?.");
        }
        internal static void incompatible_with_TRAGeoLocation_Claims_nullable()
        {
            throw new DataTypeIncompatibleException("Data type 'TRAGeoLocation_Claims?' not compatible with the target field.");
        }
        
        internal static void parse_TRAGeoLocation_EnvelopeContent_nullable(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRAGeoLocation_EnvelopeContent?.");
        }
        internal static void incompatible_with_TRAGeoLocation_EnvelopeContent_nullable()
        {
            throw new DataTypeIncompatibleException("Data type 'TRAGeoLocation_EnvelopeContent?' not compatible with the target field.");
        }
        
        internal static void parse_TRAPostalAddress_Claims_nullable(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRAPostalAddress_Claims?.");
        }
        internal static void incompatible_with_TRAPostalAddress_Claims_nullable()
        {
            throw new DataTypeIncompatibleException("Data type 'TRAPostalAddress_Claims?' not compatible with the target field.");
        }
        
        internal static void parse_TRATimestamp_Claims_nullable(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TRATimestamp_Claims?.");
        }
        internal static void incompatible_with_TRATimestamp_Claims_nullable()
        {
            throw new DataTypeIncompatibleException("Data type 'TRATimestamp_Claims?' not compatible with the target field.");
        }
        
        internal static void parse_UBL21_Invoice2_Claims_nullable(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into UBL21_Invoice2_Claims?.");
        }
        internal static void incompatible_with_UBL21_Invoice2_Claims_nullable()
        {
            throw new DataTypeIncompatibleException("Data type 'UBL21_Invoice2_Claims?' not compatible with the target field.");
        }
        
        internal static void data_type_incompatible_with_list(string type)
        {
            throw new DataTypeIncompatibleException("Data type '" + type + "' not compatible with the target list.");
        }
        internal static void data_type_incompatible_with_field(string type)
        {
            throw new DataTypeIncompatibleException("Data type '" + type + "' not compatible with the target field.");
        }
        internal static void target__field_not_list()
        {
            throw new DataTypeIncompatibleException("Target field is not a List, value or a string, cannot perform append operation.");
        }
        internal static void list_incompatible_list(string type)
        {
            throw new DataTypeIncompatibleException("List type '" + type + "' not compatible with the target list.");
        }
        internal static void incompatible_with_cell()
        {
            throw new DataTypeIncompatibleException("Data type incompatible with the cell.");
        }
        internal static void array_dimension_size_mismatch(string type)
        {
            throw new ArgumentException(type + ": Array dimension size mismatch.");
        }
        internal static void invalid_cell_type()
        {
            throw new ArgumentException("Invalid cell type name. If you want a new cell type, please define it in your TSL.");
        }
        internal static void undefined_field()
        {
            throw new ArgumentException("Undefined field.");
        }
        
        internal static void member_access_on_non_struct__field(string field_name_string)
        {
            throw new DataTypeIncompatibleException("Cannot apply member access method on a non-struct field'" + field_name_string + "'.");
        }
        internal static void cell_not_found()
        {
            throw new CellNotFoundException("The cell is not found.");
        }
        internal static void cell_not_found(long cellId)
        {
            throw new CellNotFoundException("The cell with id = " + cellId + " not found.");
        }
        internal static void wrong_cell_type()
        {
            throw new CellTypeNotMatchException("Cell type mismatched.");
        }
        internal static unsafe void cannot_parse(string value, string type_str)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into " + type_str + ".");
        }
        internal static unsafe byte* invalid_resize_on_fixed_struct()
        {
            throw new InvalidOperationException("Invalid resize operation on a fixed struct.");
        }
    }
}

#pragma warning restore 162,168,649,660,661,1522
