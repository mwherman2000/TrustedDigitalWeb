#pragma warning disable 162,168,649,660,661,1522

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trinity;
using Trinity.TSL;
using Trinity.TSL.Lib;
namespace TDW.TRAServer
{
    internal struct GenericFieldAccessor
    {
        #region FieldID lookup table
        
        static Dictionary<string, uint> FieldLookupTable_TRAKeyValuePair = new Dictionary<string, uint>()
        {
            
            {"key" , 0}
            ,
            {"value" , 1}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TRAClaim = new Dictionary<string, uint>()
        {
            
            {"key" , 0}
            ,
            {"value" , 1}
            ,
            {"attribute" , 2}
            ,
            {"attributes" , 3}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TRAEncryptedClaims = new Dictionary<string, uint>()
        {
            
            {"ciphertext16" , 0}
            ,
            {"alg" , 1}
            ,
            {"key" , 2}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TRACredential_EnvelopeContent = new Dictionary<string, uint>()
        {
            
            {"udid" , 0}
            ,
            {"context" , 1}
            ,
            {"credentialsubjectudid" , 2}
            ,
            {"claims" , 3}
            ,
            {"encryptedclaims" , 4}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TRACredential_PackingLabel = new Dictionary<string, uint>()
        {
            
            {"credtype" , 0}
            ,
            {"version" , 1}
            ,
            {"trustLevel" , 2}
            ,
            {"encryptionFlag" , 3}
            ,
            {"notaryudid" , 4}
            ,
            {"name" , 5}
            ,
            {"comment" , 6}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TRACredential_Envelope = new Dictionary<string, uint>()
        {
            
            {"content" , 0}
            ,
            {"label" , 1}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TRACredential_EnvelopeSeal = new Dictionary<string, uint>()
        {
            
            {"hashedThumbprint64" , 0}
            ,
            {"signedHashSignature64" , 1}
            ,
            {"notaryStamp" , 2}
            ,
            {"comments" , 3}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TRATimestamp_Claims = new Dictionary<string, uint>()
        {
            
            {"ticks" , 0}
            ,
            {"datetime" , 1}
            ,
            {"timestamp" , 2}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TRATimestamp_EnvelopeContent = new Dictionary<string, uint>()
        {
            
            {"udid" , 0}
            ,
            {"context" , 1}
            ,
            {"credentialsubjectudid" , 2}
            ,
            {"claims" , 3}
            ,
            {"encryptedclaims" , 4}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TRATimestamp_Envelope = new Dictionary<string, uint>()
        {
            
            {"content" , 0}
            ,
            {"label" , 1}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TRAGeoLocation_Claims = new Dictionary<string, uint>()
        {
            
            {"latitude" , 0}
            ,
            {"longitude" , 1}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TRAGeoLocation_EnvelopeContent = new Dictionary<string, uint>()
        {
            
            {"udid" , 0}
            ,
            {"context" , 1}
            ,
            {"credentialsubjectudid" , 2}
            ,
            {"claims" , 3}
            ,
            {"encryptedclaims" , 4}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TRAGeoLocation_Envelope = new Dictionary<string, uint>()
        {
            
            {"content" , 0}
            ,
            {"label" , 1}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TRAPostalAddress_Claims = new Dictionary<string, uint>()
        {
            
            {"streetAddress" , 0}
            ,
            {"postOfficeBoxNumber" , 1}
            ,
            {"addressLocality" , 2}
            ,
            {"addressRegion" , 3}
            ,
            {"addressCountry" , 4}
            ,
            {"postalCode" , 5}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TRAPostalAddress_EnvelopeContent = new Dictionary<string, uint>()
        {
            
            {"udid" , 0}
            ,
            {"context" , 1}
            ,
            {"credentialsubjectudid" , 2}
            ,
            {"claims" , 3}
            ,
            {"encryptedclaims" , 4}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TRAPostalAddress_Envelope = new Dictionary<string, uint>()
        {
            
            {"content" , 0}
            ,
            {"label" , 1}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cbc_Amount = new Dictionary<string, uint>()
        {
            
            {"_CurrencyID" , 0}
            ,
            {"amount" , 1}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cbc_ListCode = new Dictionary<string, uint>()
        {
            
            {"_listID" , 0}
            ,
            {"_listAgencyID" , 1}
            ,
            {"code" , 2}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cbc_Note = new Dictionary<string, uint>()
        {
            
            {"_languageID" , 0}
            ,
            {"note" , 1}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cbc_OrderReference = new Dictionary<string, uint>()
        {
            
            {"cbc_ID" , 0}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cbc_Quantity = new Dictionary<string, uint>()
        {
            
            {"_unitCode" , 0}
            ,
            {"quantity" , 1}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cbc_SchemeCode = new Dictionary<string, uint>()
        {
            
            {"_schemeID" , 0}
            ,
            {"_schemeAgencyID" , 1}
            ,
            {"code" , 2}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cbc_TimePeriod = new Dictionary<string, uint>()
        {
            
            {"cbc_StartDate" , 0}
            ,
            {"cbc_EndDate" , 1}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_AccountingSupplierParty = new Dictionary<string, uint>()
        {
            
            {"cac_PartyUdid" , 0}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_AccountingCustomerParty = new Dictionary<string, uint>()
        {
            
            {"cac_PartyUdid" , 0}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_AllowanceCharge = new Dictionary<string, uint>()
        {
            
            {"cbc_ChargeIndicator" , 0}
            ,
            {"cbc_AllowanceChargeReason" , 1}
            ,
            {"cbc_Amount" , 2}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_Attachment = new Dictionary<string, uint>()
        {
            
            {"cac_ExternalReferenceUdid" , 0}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_ClassifiedTaxCategory = new Dictionary<string, uint>()
        {
            
            {"cbc_ID" , 0}
            ,
            {"cbc_Percent" , 1}
            ,
            {"cac_TaxScheme" , 2}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_Country = new Dictionary<string, uint>()
        {
            
            {"cbc_IdentificationCode" , 0}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_Delivery = new Dictionary<string, uint>()
        {
            
            {"cbc_ActualDeliveryDate" , 0}
            ,
            {"cac_DeliveryLocation" , 1}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_DeliveryLocation = new Dictionary<string, uint>()
        {
            
            {"cbc_ID" , 0}
            ,
            {"cac_AddressUdid" , 1}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_DocumentReference = new Dictionary<string, uint>()
        {
            
            {"ID" , 0}
            ,
            {"DocumentType" , 1}
            ,
            {"cac_Attachment" , 2}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cbc_EmbeddedDocumentBinaryObject = new Dictionary<string, uint>()
        {
            
            {"_mimeCode" , 0}
            ,
            {"binary16" , 1}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_FinancialInstitution = new Dictionary<string, uint>()
        {
            
            {"cbc_ID" , 0}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_FinancialInstitutionBranch = new Dictionary<string, uint>()
        {
            
            {"cac_FinancialInstitution" , 0}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_InvoiceLine = new Dictionary<string, uint>()
        {
            
            {"cbc_ID" , 0}
            ,
            {"cbc_Note" , 1}
            ,
            {"cbc_InvoicedQuantity" , 2}
            ,
            {"cbc_LineExtensionAmount" , 3}
            ,
            {"cbc_AccountingCost" , 4}
            ,
            {"cac_OrderLineReference" , 5}
            ,
            {"cac_AllowanceCharges" , 6}
            ,
            {"cac_TaxTotal" , 7}
            ,
            {"cac_ItemUdid" , 8}
            ,
            {"cac_Price" , 9}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_LegalMonetaryTotal = new Dictionary<string, uint>()
        {
            
            {"cbc_LineExtensionAmount" , 0}
            ,
            {"cbc_TaxExclusiveAmount" , 1}
            ,
            {"cbc_TaxInclusiveAmount" , 2}
            ,
            {"cbc_AllowanceTotalAmount" , 3}
            ,
            {"cbc_ChargeTotalAmount" , 4}
            ,
            {"cbc_PrepaidAmount" , 5}
            ,
            {"cbc_PayableRoundingAmount" , 6}
            ,
            {"cbc_PayableAmount" , 7}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_OrderLineReference = new Dictionary<string, uint>()
        {
            
            {"cbc_LineID" , 0}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_PartyIdentification = new Dictionary<string, uint>()
        {
            
            {"cbc_ID" , 0}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_PartyName = new Dictionary<string, uint>()
        {
            
            {"cbc_Name" , 0}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_PartyTaxScheme = new Dictionary<string, uint>()
        {
            
            {"cbc_CompanyID" , 0}
            ,
            {"cac_TaxScheme" , 1}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_Price = new Dictionary<string, uint>()
        {
            
            {"cbc_PriceAmount" , 0}
            ,
            {"cbc_BaseQuantity" , 1}
            ,
            {"cac_AllowanceCharge" , 2}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_PayeeParty = new Dictionary<string, uint>()
        {
            
            {"cac_PartyUdid" , 0}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_PaymentTerms = new Dictionary<string, uint>()
        {
            
            {"cbc_Note" , 0}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_SellersItemIdentification = new Dictionary<string, uint>()
        {
            
            {"cbc_ID" , 0}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_TaxCategory = new Dictionary<string, uint>()
        {
            
            {"cbc_ID" , 0}
            ,
            {"cbc_Percent" , 1}
            ,
            {"cac_TaxScheme" , 2}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_TaxScheme = new Dictionary<string, uint>()
        {
            
            {"cbc_ID" , 0}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_TaxSubtotal = new Dictionary<string, uint>()
        {
            
            {"cbc_TaxableAmount" , 0}
            ,
            {"cbc_TaxAmount" , 1}
            ,
            {"cac_TaxCategory" , 2}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_TaxTotal = new Dictionary<string, uint>()
        {
            
            {"cbc_TaxAmount" , 0}
            ,
            {"cac_TaxSubtotals" , 1}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_Item_Claims = new Dictionary<string, uint>()
        {
            
            {"cbc_Name" , 0}
            ,
            {"cac_SellersItemIdentification" , 1}
            ,
            {"cac_StandardItemIdentification" , 2}
            ,
            {"cac_CommodityClassification" , 3}
            ,
            {"cac_ClassifiedTaxCategory" , 4}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_Item_EnvelopeContent = new Dictionary<string, uint>()
        {
            
            {"udid" , 0}
            ,
            {"context" , 1}
            ,
            {"credentialsubjectudid" , 2}
            ,
            {"claims" , 3}
            ,
            {"encryptedclaims" , 4}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_Item_Envelope = new Dictionary<string, uint>()
        {
            
            {"content" , 0}
            ,
            {"label" , 1}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_ExternalReference_Claims = new Dictionary<string, uint>()
        {
            
            {"cbc_URI" , 0}
            ,
            {"cbc_EmbeddedDocumentBinaryObject" , 1}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_ExternalReference_EnvelopeContent = new Dictionary<string, uint>()
        {
            
            {"udid" , 0}
            ,
            {"context" , 1}
            ,
            {"credentialsubjectudid" , 2}
            ,
            {"claims" , 3}
            ,
            {"encryptedclaims" , 4}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_ExternalReference_Envelope = new Dictionary<string, uint>()
        {
            
            {"content" , 0}
            ,
            {"label" , 1}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_Address_Claims = new Dictionary<string, uint>()
        {
            
            {"cbc_ID" , 0}
            ,
            {"cbc_PostBox" , 1}
            ,
            {"cbc_StreetName" , 2}
            ,
            {"cbc_AdditionalStreetName" , 3}
            ,
            {"cbc_BuildingNumber" , 4}
            ,
            {"cbc_Department" , 5}
            ,
            {"cbc_CityName" , 6}
            ,
            {"cbc_CountrySubentityCode" , 7}
            ,
            {"cbc_Country" , 8}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_Address_EnvelopeContent = new Dictionary<string, uint>()
        {
            
            {"udid" , 0}
            ,
            {"context" , 1}
            ,
            {"credentialsubjectudid" , 2}
            ,
            {"claims" , 3}
            ,
            {"encryptedclaims" , 4}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_Address_Envelope = new Dictionary<string, uint>()
        {
            
            {"content" , 0}
            ,
            {"label" , 1}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_PartyLegalEntity_Claims = new Dictionary<string, uint>()
        {
            
            {"cbc_RegistrationName" , 0}
            ,
            {"cbc_CompanyID" , 1}
            ,
            {"cbc_RegistrationAddressUdid" , 2}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_PartyLegalEntity_EnvelopeContent = new Dictionary<string, uint>()
        {
            
            {"udid" , 0}
            ,
            {"context" , 1}
            ,
            {"credentialsubjectudid" , 2}
            ,
            {"claims" , 3}
            ,
            {"encryptedclaims" , 4}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_PartyLegalEntity_Envelope = new Dictionary<string, uint>()
        {
            
            {"content" , 0}
            ,
            {"label" , 1}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_Contact_Claims = new Dictionary<string, uint>()
        {
            
            {"cbc_Telephone" , 0}
            ,
            {"cbc_Telefax" , 1}
            ,
            {"cbc_ElectronicMail" , 2}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_Contact_EnvelopeContent = new Dictionary<string, uint>()
        {
            
            {"udid" , 0}
            ,
            {"context" , 1}
            ,
            {"credentialsubjectudid" , 2}
            ,
            {"claims" , 3}
            ,
            {"encryptedclaims" , 4}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_Contact_Envelope = new Dictionary<string, uint>()
        {
            
            {"content" , 0}
            ,
            {"label" , 1}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_Person_Claims = new Dictionary<string, uint>()
        {
            
            {"cbc_FirstName" , 0}
            ,
            {"cbc_MiddleName" , 1}
            ,
            {"cbc_FamilyName" , 2}
            ,
            {"cbc_JobTitle" , 3}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_Person_EnvelopeContent = new Dictionary<string, uint>()
        {
            
            {"udid" , 0}
            ,
            {"context" , 1}
            ,
            {"credentialsubjectudid" , 2}
            ,
            {"claims" , 3}
            ,
            {"encryptedclaims" , 4}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_Person_Envelope = new Dictionary<string, uint>()
        {
            
            {"content" , 0}
            ,
            {"label" , 1}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_PaymentMeans_Claims = new Dictionary<string, uint>()
        {
            
            {"cbc_PaymentMeansCode" , 0}
            ,
            {"cbc_PaymentDueDate" , 1}
            ,
            {"cbc_PaymentChannel" , 2}
            ,
            {"cbc_PaymentID" , 3}
            ,
            {"cac_PayeeFinancialAccountUdid" , 4}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_PaymentMeans_EnvelopeContent = new Dictionary<string, uint>()
        {
            
            {"udid" , 0}
            ,
            {"context" , 1}
            ,
            {"credentialsubjectudid" , 2}
            ,
            {"claims" , 3}
            ,
            {"encryptedclaims" , 4}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_PaymentMeans_Envelope = new Dictionary<string, uint>()
        {
            
            {"content" , 0}
            ,
            {"label" , 1}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_PayeeFinancialAccount_Claims = new Dictionary<string, uint>()
        {
            
            {"cbc_ID" , 0}
            ,
            {"cac_FinancialInstitutionBranch" , 1}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_PayeeFinancialAccount_EnvelopeContent = new Dictionary<string, uint>()
        {
            
            {"udid" , 0}
            ,
            {"context" , 1}
            ,
            {"credentialsubjectudid" , 2}
            ,
            {"claims" , 3}
            ,
            {"encryptedclaims" , 4}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_PayeeFinancialAccount_Envelope = new Dictionary<string, uint>()
        {
            
            {"content" , 0}
            ,
            {"label" , 1}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_Party_Claims = new Dictionary<string, uint>()
        {
            
            {"cbc_EndpointID" , 0}
            ,
            {"cbc_PartyIdentification" , 1}
            ,
            {"cbc_PartyName" , 2}
            ,
            {"cac_PostalAddressUdid" , 3}
            ,
            {"cbc_PartyTaxScheme" , 4}
            ,
            {"cac_PartyLegalEntityUdid" , 5}
            ,
            {"cac_ContactUdid" , 6}
            ,
            {"cac_PersonUdid" , 7}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_Party_EnvelopeContent = new Dictionary<string, uint>()
        {
            
            {"udid" , 0}
            ,
            {"context" , 1}
            ,
            {"credentialsubjectudid" , 2}
            ,
            {"claims" , 3}
            ,
            {"encryptedclaims" , 4}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Cac_Party_Envelope = new Dictionary<string, uint>()
        {
            
            {"content" , 0}
            ,
            {"label" , 1}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_UBL21_Invoice2_Claims = new Dictionary<string, uint>()
        {
            
            {"cbc_UBLVersionID" , 0}
            ,
            {"cbc_ID" , 1}
            ,
            {"cbc_IssueDate" , 2}
            ,
            {"cbc_InvoiceTypeCode" , 3}
            ,
            {"cbc_Note" , 4}
            ,
            {"cbc_TaxPointDate" , 5}
            ,
            {"cbc_DocumentCurrencyCode" , 6}
            ,
            {"cbc_AccountingCost" , 7}
            ,
            {"cbc_InvoicePeriod" , 8}
            ,
            {"cbc_OrderReference" , 9}
            ,
            {"cac_ContractDocumentReference" , 10}
            ,
            {"cac_AdditionalDocumentReferences" , 11}
            ,
            {"cac_AccountingSupplierParty" , 12}
            ,
            {"cac_AccountingCustomerParty" , 13}
            ,
            {"cac_PayeeParty" , 14}
            ,
            {"cac_Delivery" , 15}
            ,
            {"cac_PaymentMeansUdid" , 16}
            ,
            {"cac_PaymentTerms" , 17}
            ,
            {"cac_AllowanceCharges" , 18}
            ,
            {"cac_TaxTotal" , 19}
            ,
            {"cac_LegalMonetaryTotal" , 20}
            ,
            {"cac_InvoiceLine" , 21}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_UBL21_Invoice2_EnvelopeContent = new Dictionary<string, uint>()
        {
            
            {"udid" , 0}
            ,
            {"context" , 1}
            ,
            {"credentialsubjectudid" , 2}
            ,
            {"claims" , 3}
            ,
            {"encryptedclaims" , 4}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_UBL21_Invoice2_Envelope = new Dictionary<string, uint>()
        {
            
            {"content" , 0}
            ,
            {"label" , 1}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TDWCreateTDWCredentialRequest = new Dictionary<string, uint>()
        {
            
            {"credtype" , 0}
            ,
            {"context" , 1}
            ,
            {"credentialsubjectudid" , 2}
            ,
            {"claims" , 3}
            ,
            {"trustlevel" , 4}
            ,
            {"encryptionFlag" , 5}
            ,
            {"comments" , 6}
            ,
            {"keypairsalt" , 7}
            ,
            {"mvcaudid" , 8}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TDWProcessCredentialRequest = new Dictionary<string, uint>()
        {
            
            {"id" , 0}
            ,
            {"mvcaudid" , 1}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TDWCredentialResponse = new Dictionary<string, uint>()
        {
            
            {"id" , 0}
            ,
            {"udid" , 1}
            ,
            {"rc" , 2}
            ,
            {"messages" , 3}
            
        };
        
        #endregion
        
        internal static void SetField<T>(TRAKeyValuePair_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRAKeyValuePair.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRAKeyValuePair.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.key = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.value = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TRAKeyValuePair_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRAKeyValuePair.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRAKeyValuePair.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.key);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_string(accessor.value);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TRAClaim_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRAClaim.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRAClaim.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.key = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                if (conversion_result != default(string))
                    accessor.value = conversion_result;
                else
                    accessor.Remove_value();
            }
            
                        break;
                    }
                
                case 2:
                    {
                        List<TRAKeyValuePair> conversion_result = TypeConverter<T>.ConvertTo_List_TRAKeyValuePair(value);
                        
            {
                if (conversion_result != default(List<TRAKeyValuePair>))
                    accessor.attribute = conversion_result;
                else
                    accessor.Remove_attribute();
            }
            
                        break;
                    }
                
                case 3:
                    {
                        List<List<TRAKeyValuePair>> conversion_result = TypeConverter<T>.ConvertTo_List_List_TRAKeyValuePair(value);
                        
            {
                if (conversion_result != default(List<List<TRAKeyValuePair>>))
                    accessor.attributes = conversion_result;
                else
                    accessor.Remove_attributes();
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TRAClaim_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRAClaim.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRAClaim.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.key);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_string(accessor.value);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_List_TRAKeyValuePair(accessor.attribute);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_List_List_TRAKeyValuePair(accessor.attributes);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TRAEncryptedClaims_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRAEncryptedClaims.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRAEncryptedClaims.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.ciphertext16 = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.alg = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.key = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TRAEncryptedClaims_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRAEncryptedClaims.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRAEncryptedClaims.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.ciphertext16);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_string(accessor.alg);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.key);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TRACredential_EnvelopeContent_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRACredential_EnvelopeContent.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 4:
                        GenericFieldAccessor.SetField(accessor.encryptedclaims, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRACredential_EnvelopeContent.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.udid = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        List<string> conversion_result = TypeConverter<T>.ConvertTo_List_string(value);
                        
            {
                accessor.context = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                if (conversion_result != default(string))
                    accessor.credentialsubjectudid = conversion_result;
                else
                    accessor.Remove_credentialsubjectudid();
            }
            
                        break;
                    }
                
                case 3:
                    {
                        List<TRAClaim> conversion_result = TypeConverter<T>.ConvertTo_List_TRAClaim(value);
                        
            {
                if (conversion_result != default(List<TRAClaim>))
                    accessor.claims = conversion_result;
                else
                    accessor.Remove_claims();
            }
            
                        break;
                    }
                
                case 4:
                    {
                        TRAEncryptedClaims? conversion_result = TypeConverter<T>.ConvertTo_TRAEncryptedClaims_nullable(value);
                        
            {
                if (conversion_result.HasValue)
                    accessor.encryptedclaims = conversion_result.Value;
                else
                    accessor.Remove_encryptedclaims();
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TRACredential_EnvelopeContent_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRACredential_EnvelopeContent.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 4:
                        return GenericFieldAccessor.GetField<T>(accessor.encryptedclaims, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRACredential_EnvelopeContent.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.udid);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_List_string(accessor.context);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.credentialsubjectudid);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_List_TRAClaim(accessor.claims);
                    break;
                
                case 4:
                    return TypeConverter<T>.ConvertFrom_TRAEncryptedClaims_nullable(accessor.encryptedclaims);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TRACredential_PackingLabel_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRACredential_PackingLabel.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRACredential_PackingLabel.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        TRACredentialType conversion_result = TypeConverter<T>.ConvertTo_TRACredentialType(value);
                        
            {
                accessor.credtype = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        long conversion_result = TypeConverter<T>.ConvertTo_long(value);
                        
            {
                accessor.version = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        TRATrustLevel conversion_result = TypeConverter<T>.ConvertTo_TRATrustLevel(value);
                        
            {
                accessor.trustLevel = conversion_result;
            }
            
                        break;
                    }
                
                case 3:
                    {
                        TRAEncryptionFlag conversion_result = TypeConverter<T>.ConvertTo_TRAEncryptionFlag(value);
                        
            {
                accessor.encryptionFlag = conversion_result;
            }
            
                        break;
                    }
                
                case 4:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.notaryudid = conversion_result;
            }
            
                        break;
                    }
                
                case 5:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                if (conversion_result != default(string))
                    accessor.name = conversion_result;
                else
                    accessor.Remove_name();
            }
            
                        break;
                    }
                
                case 6:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                if (conversion_result != default(string))
                    accessor.comment = conversion_result;
                else
                    accessor.Remove_comment();
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TRACredential_PackingLabel_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRACredential_PackingLabel.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRACredential_PackingLabel.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_TRACredentialType(accessor.credtype);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_long(accessor.version);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_TRATrustLevel(accessor.trustLevel);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_TRAEncryptionFlag(accessor.encryptionFlag);
                    break;
                
                case 4:
                    return TypeConverter<T>.ConvertFrom_string(accessor.notaryudid);
                    break;
                
                case 5:
                    return TypeConverter<T>.ConvertFrom_string(accessor.name);
                    break;
                
                case 6:
                    return TypeConverter<T>.ConvertFrom_string(accessor.comment);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TRACredential_Envelope_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRACredential_Envelope.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.content, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 1:
                        GenericFieldAccessor.SetField(accessor.label, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRACredential_Envelope.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        TRACredential_EnvelopeContent conversion_result = TypeConverter<T>.ConvertTo_TRACredential_EnvelopeContent(value);
                        
            {
                accessor.content = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        TRACredential_PackingLabel conversion_result = TypeConverter<T>.ConvertTo_TRACredential_PackingLabel(value);
                        
            {
                accessor.label = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TRACredential_Envelope_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRACredential_Envelope.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.content, fieldName, field_divider_idx + 1);
                    
                    case 1:
                        return GenericFieldAccessor.GetField<T>(accessor.label, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRACredential_Envelope.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_TRACredential_EnvelopeContent(accessor.content);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_TRACredential_PackingLabel(accessor.label);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TRACredential_EnvelopeSeal_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRACredential_EnvelopeSeal.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRACredential_EnvelopeSeal.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                if (conversion_result != default(string))
                    accessor.hashedThumbprint64 = conversion_result;
                else
                    accessor.Remove_hashedThumbprint64();
            }
            
                        break;
                    }
                
                case 1:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                if (conversion_result != default(string))
                    accessor.signedHashSignature64 = conversion_result;
                else
                    accessor.Remove_signedHashSignature64();
            }
            
                        break;
                    }
                
                case 2:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                if (conversion_result != default(string))
                    accessor.notaryStamp = conversion_result;
                else
                    accessor.Remove_notaryStamp();
            }
            
                        break;
                    }
                
                case 3:
                    {
                        List<string> conversion_result = TypeConverter<T>.ConvertTo_List_string(value);
                        
            {
                if (conversion_result != default(List<string>))
                    accessor.comments = conversion_result;
                else
                    accessor.Remove_comments();
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TRACredential_EnvelopeSeal_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRACredential_EnvelopeSeal.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRACredential_EnvelopeSeal.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.hashedThumbprint64);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_string(accessor.signedHashSignature64);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.notaryStamp);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_List_string(accessor.comments);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TRATimestamp_Claims_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRATimestamp_Claims.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRATimestamp_Claims.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        long conversion_result = TypeConverter<T>.ConvertTo_long(value);
                        
            {
                accessor.ticks = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        DateTime conversion_result = TypeConverter<T>.ConvertTo_DateTime(value);
                        
            {
                accessor.datetime = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.timestamp = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TRATimestamp_Claims_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRATimestamp_Claims.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRATimestamp_Claims.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_long(accessor.ticks);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_DateTime(accessor.datetime);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.timestamp);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TRATimestamp_EnvelopeContent_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRATimestamp_EnvelopeContent.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 3:
                        GenericFieldAccessor.SetField(accessor.claims, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 4:
                        GenericFieldAccessor.SetField(accessor.encryptedclaims, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRATimestamp_EnvelopeContent.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.udid = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        List<string> conversion_result = TypeConverter<T>.ConvertTo_List_string(value);
                        
            {
                accessor.context = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                if (conversion_result != default(string))
                    accessor.credentialsubjectudid = conversion_result;
                else
                    accessor.Remove_credentialsubjectudid();
            }
            
                        break;
                    }
                
                case 3:
                    {
                        TRATimestamp_Claims? conversion_result = TypeConverter<T>.ConvertTo_TRATimestamp_Claims_nullable(value);
                        
            {
                if (conversion_result.HasValue)
                    accessor.claims = conversion_result.Value;
                else
                    accessor.Remove_claims();
            }
            
                        break;
                    }
                
                case 4:
                    {
                        TRAEncryptedClaims? conversion_result = TypeConverter<T>.ConvertTo_TRAEncryptedClaims_nullable(value);
                        
            {
                if (conversion_result.HasValue)
                    accessor.encryptedclaims = conversion_result.Value;
                else
                    accessor.Remove_encryptedclaims();
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TRATimestamp_EnvelopeContent_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRATimestamp_EnvelopeContent.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 3:
                        return GenericFieldAccessor.GetField<T>(accessor.claims, fieldName, field_divider_idx + 1);
                    
                    case 4:
                        return GenericFieldAccessor.GetField<T>(accessor.encryptedclaims, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRATimestamp_EnvelopeContent.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.udid);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_List_string(accessor.context);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.credentialsubjectudid);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_TRATimestamp_Claims_nullable(accessor.claims);
                    break;
                
                case 4:
                    return TypeConverter<T>.ConvertFrom_TRAEncryptedClaims_nullable(accessor.encryptedclaims);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TRATimestamp_Envelope_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRATimestamp_Envelope.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.content, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 1:
                        GenericFieldAccessor.SetField(accessor.label, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRATimestamp_Envelope.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        TRATimestamp_EnvelopeContent conversion_result = TypeConverter<T>.ConvertTo_TRATimestamp_EnvelopeContent(value);
                        
            {
                accessor.content = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        TRACredential_PackingLabel conversion_result = TypeConverter<T>.ConvertTo_TRACredential_PackingLabel(value);
                        
            {
                accessor.label = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TRATimestamp_Envelope_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRATimestamp_Envelope.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.content, fieldName, field_divider_idx + 1);
                    
                    case 1:
                        return GenericFieldAccessor.GetField<T>(accessor.label, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRATimestamp_Envelope.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_TRATimestamp_EnvelopeContent(accessor.content);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_TRACredential_PackingLabel(accessor.label);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TRAGeoLocation_Claims_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRAGeoLocation_Claims.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRAGeoLocation_Claims.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        double conversion_result = TypeConverter<T>.ConvertTo_double(value);
                        
            {
                accessor.latitude = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        double conversion_result = TypeConverter<T>.ConvertTo_double(value);
                        
            {
                accessor.longitude = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TRAGeoLocation_Claims_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRAGeoLocation_Claims.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRAGeoLocation_Claims.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_double(accessor.latitude);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_double(accessor.longitude);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TRAGeoLocation_EnvelopeContent_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRAGeoLocation_EnvelopeContent.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 3:
                        GenericFieldAccessor.SetField(accessor.claims, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 4:
                        GenericFieldAccessor.SetField(accessor.encryptedclaims, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRAGeoLocation_EnvelopeContent.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.udid = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        List<string> conversion_result = TypeConverter<T>.ConvertTo_List_string(value);
                        
            {
                accessor.context = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                if (conversion_result != default(string))
                    accessor.credentialsubjectudid = conversion_result;
                else
                    accessor.Remove_credentialsubjectudid();
            }
            
                        break;
                    }
                
                case 3:
                    {
                        TRAGeoLocation_Claims? conversion_result = TypeConverter<T>.ConvertTo_TRAGeoLocation_Claims_nullable(value);
                        
            {
                if (conversion_result.HasValue)
                    accessor.claims = conversion_result.Value;
                else
                    accessor.Remove_claims();
            }
            
                        break;
                    }
                
                case 4:
                    {
                        TRAEncryptedClaims? conversion_result = TypeConverter<T>.ConvertTo_TRAEncryptedClaims_nullable(value);
                        
            {
                if (conversion_result.HasValue)
                    accessor.encryptedclaims = conversion_result.Value;
                else
                    accessor.Remove_encryptedclaims();
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TRAGeoLocation_EnvelopeContent_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRAGeoLocation_EnvelopeContent.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 3:
                        return GenericFieldAccessor.GetField<T>(accessor.claims, fieldName, field_divider_idx + 1);
                    
                    case 4:
                        return GenericFieldAccessor.GetField<T>(accessor.encryptedclaims, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRAGeoLocation_EnvelopeContent.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.udid);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_List_string(accessor.context);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.credentialsubjectudid);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_TRAGeoLocation_Claims_nullable(accessor.claims);
                    break;
                
                case 4:
                    return TypeConverter<T>.ConvertFrom_TRAEncryptedClaims_nullable(accessor.encryptedclaims);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TRAGeoLocation_Envelope_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRAGeoLocation_Envelope.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.content, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 1:
                        GenericFieldAccessor.SetField(accessor.label, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRAGeoLocation_Envelope.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        TRAGeoLocation_EnvelopeContent? conversion_result = TypeConverter<T>.ConvertTo_TRAGeoLocation_EnvelopeContent_nullable(value);
                        
            {
                if (conversion_result.HasValue)
                    accessor.content = conversion_result.Value;
                else
                    accessor.Remove_content();
            }
            
                        break;
                    }
                
                case 1:
                    {
                        TRACredential_PackingLabel conversion_result = TypeConverter<T>.ConvertTo_TRACredential_PackingLabel(value);
                        
            {
                accessor.label = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TRAGeoLocation_Envelope_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRAGeoLocation_Envelope.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.content, fieldName, field_divider_idx + 1);
                    
                    case 1:
                        return GenericFieldAccessor.GetField<T>(accessor.label, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRAGeoLocation_Envelope.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_TRAGeoLocation_EnvelopeContent_nullable(accessor.content);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_TRACredential_PackingLabel(accessor.label);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TRAPostalAddress_Claims_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRAPostalAddress_Claims.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRAPostalAddress_Claims.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.streetAddress = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.postOfficeBoxNumber = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.addressLocality = conversion_result;
            }
            
                        break;
                    }
                
                case 3:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.addressRegion = conversion_result;
            }
            
                        break;
                    }
                
                case 4:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.addressCountry = conversion_result;
            }
            
                        break;
                    }
                
                case 5:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.postalCode = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TRAPostalAddress_Claims_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRAPostalAddress_Claims.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRAPostalAddress_Claims.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.streetAddress);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_string(accessor.postOfficeBoxNumber);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.addressLocality);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_string(accessor.addressRegion);
                    break;
                
                case 4:
                    return TypeConverter<T>.ConvertFrom_string(accessor.addressCountry);
                    break;
                
                case 5:
                    return TypeConverter<T>.ConvertFrom_string(accessor.postalCode);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TRAPostalAddress_EnvelopeContent_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRAPostalAddress_EnvelopeContent.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 3:
                        GenericFieldAccessor.SetField(accessor.claims, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 4:
                        GenericFieldAccessor.SetField(accessor.encryptedclaims, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRAPostalAddress_EnvelopeContent.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.udid = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        List<string> conversion_result = TypeConverter<T>.ConvertTo_List_string(value);
                        
            {
                accessor.context = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                if (conversion_result != default(string))
                    accessor.credentialsubjectudid = conversion_result;
                else
                    accessor.Remove_credentialsubjectudid();
            }
            
                        break;
                    }
                
                case 3:
                    {
                        TRAPostalAddress_Claims? conversion_result = TypeConverter<T>.ConvertTo_TRAPostalAddress_Claims_nullable(value);
                        
            {
                if (conversion_result.HasValue)
                    accessor.claims = conversion_result.Value;
                else
                    accessor.Remove_claims();
            }
            
                        break;
                    }
                
                case 4:
                    {
                        TRAEncryptedClaims? conversion_result = TypeConverter<T>.ConvertTo_TRAEncryptedClaims_nullable(value);
                        
            {
                if (conversion_result.HasValue)
                    accessor.encryptedclaims = conversion_result.Value;
                else
                    accessor.Remove_encryptedclaims();
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TRAPostalAddress_EnvelopeContent_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRAPostalAddress_EnvelopeContent.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 3:
                        return GenericFieldAccessor.GetField<T>(accessor.claims, fieldName, field_divider_idx + 1);
                    
                    case 4:
                        return GenericFieldAccessor.GetField<T>(accessor.encryptedclaims, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRAPostalAddress_EnvelopeContent.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.udid);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_List_string(accessor.context);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.credentialsubjectudid);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_TRAPostalAddress_Claims_nullable(accessor.claims);
                    break;
                
                case 4:
                    return TypeConverter<T>.ConvertFrom_TRAEncryptedClaims_nullable(accessor.encryptedclaims);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TRAPostalAddress_Envelope_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRAPostalAddress_Envelope.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.content, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 1:
                        GenericFieldAccessor.SetField(accessor.label, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRAPostalAddress_Envelope.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        TRAPostalAddress_EnvelopeContent? conversion_result = TypeConverter<T>.ConvertTo_TRAPostalAddress_EnvelopeContent_nullable(value);
                        
            {
                if (conversion_result.HasValue)
                    accessor.content = conversion_result.Value;
                else
                    accessor.Remove_content();
            }
            
                        break;
                    }
                
                case 1:
                    {
                        TRACredential_PackingLabel conversion_result = TypeConverter<T>.ConvertTo_TRACredential_PackingLabel(value);
                        
            {
                accessor.label = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TRAPostalAddress_Envelope_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TRAPostalAddress_Envelope.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.content, fieldName, field_divider_idx + 1);
                    
                    case 1:
                        return GenericFieldAccessor.GetField<T>(accessor.label, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TRAPostalAddress_Envelope.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_TRAPostalAddress_EnvelopeContent_nullable(accessor.content);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_TRACredential_PackingLabel(accessor.label);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cbc_Amount_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cbc_Amount.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cbc_Amount.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor._CurrencyID = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        double conversion_result = TypeConverter<T>.ConvertTo_double(value);
                        
            {
                accessor.amount = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cbc_Amount_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cbc_Amount.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cbc_Amount.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor._CurrencyID);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_double(accessor.amount);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cbc_ListCode_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cbc_ListCode.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cbc_ListCode.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor._listID = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor._listAgencyID = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.code = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cbc_ListCode_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cbc_ListCode.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cbc_ListCode.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor._listID);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_string(accessor._listAgencyID);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.code);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cbc_Note_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cbc_Note.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cbc_Note.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        ISO639_1_LanguageCodes conversion_result = TypeConverter<T>.ConvertTo_ISO639_1_LanguageCodes(value);
                        
            {
                accessor._languageID = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.note = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cbc_Note_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cbc_Note.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cbc_Note.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_ISO639_1_LanguageCodes(accessor._languageID);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_string(accessor.note);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cbc_OrderReference_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cbc_OrderReference.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cbc_OrderReference.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cbc_ID = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cbc_OrderReference_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cbc_OrderReference.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cbc_OrderReference.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cbc_ID);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cbc_Quantity_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cbc_Quantity.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cbc_Quantity.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor._unitCode = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        long conversion_result = TypeConverter<T>.ConvertTo_long(value);
                        
            {
                accessor.quantity = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cbc_Quantity_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cbc_Quantity.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cbc_Quantity.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor._unitCode);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_long(accessor.quantity);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cbc_SchemeCode_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cbc_SchemeCode.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cbc_SchemeCode.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor._schemeID = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                if (conversion_result != default(string))
                    accessor._schemeAgencyID = conversion_result;
                else
                    accessor.Remove__schemeAgencyID();
            }
            
                        break;
                    }
                
                case 2:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.code = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cbc_SchemeCode_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cbc_SchemeCode.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cbc_SchemeCode.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor._schemeID);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_string(accessor._schemeAgencyID);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.code);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cbc_TimePeriod_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cbc_TimePeriod.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cbc_TimePeriod.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        DateTime conversion_result = TypeConverter<T>.ConvertTo_DateTime(value);
                        
            {
                accessor.cbc_StartDate = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        DateTime conversion_result = TypeConverter<T>.ConvertTo_DateTime(value);
                        
            {
                accessor.cbc_EndDate = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cbc_TimePeriod_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cbc_TimePeriod.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cbc_TimePeriod.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_DateTime(accessor.cbc_StartDate);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_DateTime(accessor.cbc_EndDate);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_AccountingSupplierParty_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_AccountingSupplierParty.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_AccountingSupplierParty.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cac_PartyUdid = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_AccountingSupplierParty_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_AccountingSupplierParty.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_AccountingSupplierParty.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cac_PartyUdid);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_AccountingCustomerParty_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_AccountingCustomerParty.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_AccountingCustomerParty.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cac_PartyUdid = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_AccountingCustomerParty_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_AccountingCustomerParty.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_AccountingCustomerParty.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cac_PartyUdid);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_AllowanceCharge_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_AllowanceCharge.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 2:
                        GenericFieldAccessor.SetField(accessor.cbc_Amount, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_AllowanceCharge.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        bool conversion_result = TypeConverter<T>.ConvertTo_bool(value);
                        
            {
                accessor.cbc_ChargeIndicator = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cbc_AllowanceChargeReason = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        Cbc_Amount conversion_result = TypeConverter<T>.ConvertTo_Cbc_Amount(value);
                        
            {
                accessor.cbc_Amount = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_AllowanceCharge_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_AllowanceCharge.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 2:
                        return GenericFieldAccessor.GetField<T>(accessor.cbc_Amount, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_AllowanceCharge.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_bool(accessor.cbc_ChargeIndicator);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cbc_AllowanceChargeReason);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_Cbc_Amount(accessor.cbc_Amount);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_Attachment_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_Attachment.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_Attachment.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cac_ExternalReferenceUdid = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_Attachment_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_Attachment.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_Attachment.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cac_ExternalReferenceUdid);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_ClassifiedTaxCategory_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_ClassifiedTaxCategory.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.cbc_ID, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 2:
                        GenericFieldAccessor.SetField(accessor.cac_TaxScheme, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_ClassifiedTaxCategory.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        Cbc_SchemeCode conversion_result = TypeConverter<T>.ConvertTo_Cbc_SchemeCode(value);
                        
            {
                accessor.cbc_ID = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        double conversion_result = TypeConverter<T>.ConvertTo_double(value);
                        
            {
                accessor.cbc_Percent = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        Cac_TaxScheme conversion_result = TypeConverter<T>.ConvertTo_Cac_TaxScheme(value);
                        
            {
                accessor.cac_TaxScheme = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_ClassifiedTaxCategory_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_ClassifiedTaxCategory.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.cbc_ID, fieldName, field_divider_idx + 1);
                    
                    case 2:
                        return GenericFieldAccessor.GetField<T>(accessor.cac_TaxScheme, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_ClassifiedTaxCategory.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_Cbc_SchemeCode(accessor.cbc_ID);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_double(accessor.cbc_Percent);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_Cac_TaxScheme(accessor.cac_TaxScheme);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_Country_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_Country.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.cbc_IdentificationCode, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_Country.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        Cbc_ListCode conversion_result = TypeConverter<T>.ConvertTo_Cbc_ListCode(value);
                        
            {
                accessor.cbc_IdentificationCode = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_Country_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_Country.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.cbc_IdentificationCode, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_Country.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_Cbc_ListCode(accessor.cbc_IdentificationCode);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_Delivery_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_Delivery.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 1:
                        GenericFieldAccessor.SetField(accessor.cac_DeliveryLocation, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_Delivery.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        DateTime conversion_result = TypeConverter<T>.ConvertTo_DateTime(value);
                        
            {
                accessor.cbc_ActualDeliveryDate = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        Cac_DeliveryLocation conversion_result = TypeConverter<T>.ConvertTo_Cac_DeliveryLocation(value);
                        
            {
                accessor.cac_DeliveryLocation = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_Delivery_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_Delivery.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 1:
                        return GenericFieldAccessor.GetField<T>(accessor.cac_DeliveryLocation, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_Delivery.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_DateTime(accessor.cbc_ActualDeliveryDate);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_Cac_DeliveryLocation(accessor.cac_DeliveryLocation);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_DeliveryLocation_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_DeliveryLocation.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.cbc_ID, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_DeliveryLocation.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        Cbc_SchemeCode conversion_result = TypeConverter<T>.ConvertTo_Cbc_SchemeCode(value);
                        
            {
                accessor.cbc_ID = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cac_AddressUdid = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_DeliveryLocation_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_DeliveryLocation.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.cbc_ID, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_DeliveryLocation.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_Cbc_SchemeCode(accessor.cbc_ID);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cac_AddressUdid);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_DocumentReference_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_DocumentReference.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 2:
                        GenericFieldAccessor.SetField(accessor.cac_Attachment, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_DocumentReference.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.ID = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.DocumentType = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        Cac_Attachment? conversion_result = TypeConverter<T>.ConvertTo_Cac_Attachment_nullable(value);
                        
            {
                if (conversion_result.HasValue)
                    accessor.cac_Attachment = conversion_result.Value;
                else
                    accessor.Remove_cac_Attachment();
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_DocumentReference_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_DocumentReference.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 2:
                        return GenericFieldAccessor.GetField<T>(accessor.cac_Attachment, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_DocumentReference.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.ID);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_string(accessor.DocumentType);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_Cac_Attachment_nullable(accessor.cac_Attachment);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cbc_EmbeddedDocumentBinaryObject_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cbc_EmbeddedDocumentBinaryObject.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cbc_EmbeddedDocumentBinaryObject.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor._mimeCode = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.binary16 = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cbc_EmbeddedDocumentBinaryObject_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cbc_EmbeddedDocumentBinaryObject.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cbc_EmbeddedDocumentBinaryObject.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor._mimeCode);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_string(accessor.binary16);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_FinancialInstitution_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_FinancialInstitution.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_FinancialInstitution.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cbc_ID = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_FinancialInstitution_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_FinancialInstitution.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_FinancialInstitution.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cbc_ID);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_FinancialInstitutionBranch_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_FinancialInstitutionBranch.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.cac_FinancialInstitution, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_FinancialInstitutionBranch.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        Cac_FinancialInstitution conversion_result = TypeConverter<T>.ConvertTo_Cac_FinancialInstitution(value);
                        
            {
                accessor.cac_FinancialInstitution = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_FinancialInstitutionBranch_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_FinancialInstitutionBranch.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.cac_FinancialInstitution, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_FinancialInstitutionBranch.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_Cac_FinancialInstitution(accessor.cac_FinancialInstitution);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_InvoiceLine_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_InvoiceLine.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 1:
                        GenericFieldAccessor.SetField(accessor.cbc_Note, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 2:
                        GenericFieldAccessor.SetField(accessor.cbc_InvoicedQuantity, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 3:
                        GenericFieldAccessor.SetField(accessor.cbc_LineExtensionAmount, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 5:
                        GenericFieldAccessor.SetField(accessor.cac_OrderLineReference, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 7:
                        GenericFieldAccessor.SetField(accessor.cac_TaxTotal, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 9:
                        GenericFieldAccessor.SetField(accessor.cac_Price, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_InvoiceLine.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cbc_ID = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        Cbc_Note conversion_result = TypeConverter<T>.ConvertTo_Cbc_Note(value);
                        
            {
                accessor.cbc_Note = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        Cbc_Quantity conversion_result = TypeConverter<T>.ConvertTo_Cbc_Quantity(value);
                        
            {
                accessor.cbc_InvoicedQuantity = conversion_result;
            }
            
                        break;
                    }
                
                case 3:
                    {
                        Cbc_Amount conversion_result = TypeConverter<T>.ConvertTo_Cbc_Amount(value);
                        
            {
                accessor.cbc_LineExtensionAmount = conversion_result;
            }
            
                        break;
                    }
                
                case 4:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cbc_AccountingCost = conversion_result;
            }
            
                        break;
                    }
                
                case 5:
                    {
                        Cac_OrderLineReference conversion_result = TypeConverter<T>.ConvertTo_Cac_OrderLineReference(value);
                        
            {
                accessor.cac_OrderLineReference = conversion_result;
            }
            
                        break;
                    }
                
                case 6:
                    {
                        List<Cac_AllowanceCharge> conversion_result = TypeConverter<T>.ConvertTo_List_Cac_AllowanceCharge(value);
                        
            {
                accessor.cac_AllowanceCharges = conversion_result;
            }
            
                        break;
                    }
                
                case 7:
                    {
                        Cac_TaxTotal conversion_result = TypeConverter<T>.ConvertTo_Cac_TaxTotal(value);
                        
            {
                accessor.cac_TaxTotal = conversion_result;
            }
            
                        break;
                    }
                
                case 8:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cac_ItemUdid = conversion_result;
            }
            
                        break;
                    }
                
                case 9:
                    {
                        Cac_Price conversion_result = TypeConverter<T>.ConvertTo_Cac_Price(value);
                        
            {
                accessor.cac_Price = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_InvoiceLine_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_InvoiceLine.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 1:
                        return GenericFieldAccessor.GetField<T>(accessor.cbc_Note, fieldName, field_divider_idx + 1);
                    
                    case 2:
                        return GenericFieldAccessor.GetField<T>(accessor.cbc_InvoicedQuantity, fieldName, field_divider_idx + 1);
                    
                    case 3:
                        return GenericFieldAccessor.GetField<T>(accessor.cbc_LineExtensionAmount, fieldName, field_divider_idx + 1);
                    
                    case 5:
                        return GenericFieldAccessor.GetField<T>(accessor.cac_OrderLineReference, fieldName, field_divider_idx + 1);
                    
                    case 7:
                        return GenericFieldAccessor.GetField<T>(accessor.cac_TaxTotal, fieldName, field_divider_idx + 1);
                    
                    case 9:
                        return GenericFieldAccessor.GetField<T>(accessor.cac_Price, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_InvoiceLine.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cbc_ID);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_Cbc_Note(accessor.cbc_Note);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_Cbc_Quantity(accessor.cbc_InvoicedQuantity);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_Cbc_Amount(accessor.cbc_LineExtensionAmount);
                    break;
                
                case 4:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cbc_AccountingCost);
                    break;
                
                case 5:
                    return TypeConverter<T>.ConvertFrom_Cac_OrderLineReference(accessor.cac_OrderLineReference);
                    break;
                
                case 6:
                    return TypeConverter<T>.ConvertFrom_List_Cac_AllowanceCharge(accessor.cac_AllowanceCharges);
                    break;
                
                case 7:
                    return TypeConverter<T>.ConvertFrom_Cac_TaxTotal(accessor.cac_TaxTotal);
                    break;
                
                case 8:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cac_ItemUdid);
                    break;
                
                case 9:
                    return TypeConverter<T>.ConvertFrom_Cac_Price(accessor.cac_Price);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_LegalMonetaryTotal_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_LegalMonetaryTotal.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.cbc_LineExtensionAmount, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 1:
                        GenericFieldAccessor.SetField(accessor.cbc_TaxExclusiveAmount, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 2:
                        GenericFieldAccessor.SetField(accessor.cbc_TaxInclusiveAmount, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 3:
                        GenericFieldAccessor.SetField(accessor.cbc_AllowanceTotalAmount, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 4:
                        GenericFieldAccessor.SetField(accessor.cbc_ChargeTotalAmount, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 5:
                        GenericFieldAccessor.SetField(accessor.cbc_PrepaidAmount, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 6:
                        GenericFieldAccessor.SetField(accessor.cbc_PayableRoundingAmount, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 7:
                        GenericFieldAccessor.SetField(accessor.cbc_PayableAmount, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_LegalMonetaryTotal.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        Cbc_Amount conversion_result = TypeConverter<T>.ConvertTo_Cbc_Amount(value);
                        
            {
                accessor.cbc_LineExtensionAmount = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        Cbc_Amount conversion_result = TypeConverter<T>.ConvertTo_Cbc_Amount(value);
                        
            {
                accessor.cbc_TaxExclusiveAmount = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        Cbc_Amount conversion_result = TypeConverter<T>.ConvertTo_Cbc_Amount(value);
                        
            {
                accessor.cbc_TaxInclusiveAmount = conversion_result;
            }
            
                        break;
                    }
                
                case 3:
                    {
                        Cbc_Amount conversion_result = TypeConverter<T>.ConvertTo_Cbc_Amount(value);
                        
            {
                accessor.cbc_AllowanceTotalAmount = conversion_result;
            }
            
                        break;
                    }
                
                case 4:
                    {
                        Cbc_Amount conversion_result = TypeConverter<T>.ConvertTo_Cbc_Amount(value);
                        
            {
                accessor.cbc_ChargeTotalAmount = conversion_result;
            }
            
                        break;
                    }
                
                case 5:
                    {
                        Cbc_Amount conversion_result = TypeConverter<T>.ConvertTo_Cbc_Amount(value);
                        
            {
                accessor.cbc_PrepaidAmount = conversion_result;
            }
            
                        break;
                    }
                
                case 6:
                    {
                        Cbc_Amount conversion_result = TypeConverter<T>.ConvertTo_Cbc_Amount(value);
                        
            {
                accessor.cbc_PayableRoundingAmount = conversion_result;
            }
            
                        break;
                    }
                
                case 7:
                    {
                        Cbc_Amount conversion_result = TypeConverter<T>.ConvertTo_Cbc_Amount(value);
                        
            {
                accessor.cbc_PayableAmount = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_LegalMonetaryTotal_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_LegalMonetaryTotal.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.cbc_LineExtensionAmount, fieldName, field_divider_idx + 1);
                    
                    case 1:
                        return GenericFieldAccessor.GetField<T>(accessor.cbc_TaxExclusiveAmount, fieldName, field_divider_idx + 1);
                    
                    case 2:
                        return GenericFieldAccessor.GetField<T>(accessor.cbc_TaxInclusiveAmount, fieldName, field_divider_idx + 1);
                    
                    case 3:
                        return GenericFieldAccessor.GetField<T>(accessor.cbc_AllowanceTotalAmount, fieldName, field_divider_idx + 1);
                    
                    case 4:
                        return GenericFieldAccessor.GetField<T>(accessor.cbc_ChargeTotalAmount, fieldName, field_divider_idx + 1);
                    
                    case 5:
                        return GenericFieldAccessor.GetField<T>(accessor.cbc_PrepaidAmount, fieldName, field_divider_idx + 1);
                    
                    case 6:
                        return GenericFieldAccessor.GetField<T>(accessor.cbc_PayableRoundingAmount, fieldName, field_divider_idx + 1);
                    
                    case 7:
                        return GenericFieldAccessor.GetField<T>(accessor.cbc_PayableAmount, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_LegalMonetaryTotal.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_Cbc_Amount(accessor.cbc_LineExtensionAmount);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_Cbc_Amount(accessor.cbc_TaxExclusiveAmount);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_Cbc_Amount(accessor.cbc_TaxInclusiveAmount);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_Cbc_Amount(accessor.cbc_AllowanceTotalAmount);
                    break;
                
                case 4:
                    return TypeConverter<T>.ConvertFrom_Cbc_Amount(accessor.cbc_ChargeTotalAmount);
                    break;
                
                case 5:
                    return TypeConverter<T>.ConvertFrom_Cbc_Amount(accessor.cbc_PrepaidAmount);
                    break;
                
                case 6:
                    return TypeConverter<T>.ConvertFrom_Cbc_Amount(accessor.cbc_PayableRoundingAmount);
                    break;
                
                case 7:
                    return TypeConverter<T>.ConvertFrom_Cbc_Amount(accessor.cbc_PayableAmount);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_OrderLineReference_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_OrderLineReference.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_OrderLineReference.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cbc_LineID = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_OrderLineReference_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_OrderLineReference.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_OrderLineReference.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cbc_LineID);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_PartyIdentification_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_PartyIdentification.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.cbc_ID, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_PartyIdentification.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        Cbc_SchemeCode conversion_result = TypeConverter<T>.ConvertTo_Cbc_SchemeCode(value);
                        
            {
                accessor.cbc_ID = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_PartyIdentification_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_PartyIdentification.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.cbc_ID, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_PartyIdentification.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_Cbc_SchemeCode(accessor.cbc_ID);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_PartyName_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_PartyName.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_PartyName.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cbc_Name = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_PartyName_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_PartyName.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_PartyName.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cbc_Name);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_PartyTaxScheme_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_PartyTaxScheme.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.cbc_CompanyID, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 1:
                        GenericFieldAccessor.SetField(accessor.cac_TaxScheme, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_PartyTaxScheme.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        Cbc_SchemeCode conversion_result = TypeConverter<T>.ConvertTo_Cbc_SchemeCode(value);
                        
            {
                accessor.cbc_CompanyID = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        Cac_TaxScheme conversion_result = TypeConverter<T>.ConvertTo_Cac_TaxScheme(value);
                        
            {
                accessor.cac_TaxScheme = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_PartyTaxScheme_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_PartyTaxScheme.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.cbc_CompanyID, fieldName, field_divider_idx + 1);
                    
                    case 1:
                        return GenericFieldAccessor.GetField<T>(accessor.cac_TaxScheme, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_PartyTaxScheme.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_Cbc_SchemeCode(accessor.cbc_CompanyID);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_Cac_TaxScheme(accessor.cac_TaxScheme);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_Price_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_Price.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.cbc_PriceAmount, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 1:
                        GenericFieldAccessor.SetField(accessor.cbc_BaseQuantity, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 2:
                        GenericFieldAccessor.SetField(accessor.cac_AllowanceCharge, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_Price.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        Cbc_Amount conversion_result = TypeConverter<T>.ConvertTo_Cbc_Amount(value);
                        
            {
                accessor.cbc_PriceAmount = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        Cbc_Quantity conversion_result = TypeConverter<T>.ConvertTo_Cbc_Quantity(value);
                        
            {
                accessor.cbc_BaseQuantity = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        Cac_AllowanceCharge conversion_result = TypeConverter<T>.ConvertTo_Cac_AllowanceCharge(value);
                        
            {
                accessor.cac_AllowanceCharge = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_Price_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_Price.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.cbc_PriceAmount, fieldName, field_divider_idx + 1);
                    
                    case 1:
                        return GenericFieldAccessor.GetField<T>(accessor.cbc_BaseQuantity, fieldName, field_divider_idx + 1);
                    
                    case 2:
                        return GenericFieldAccessor.GetField<T>(accessor.cac_AllowanceCharge, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_Price.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_Cbc_Amount(accessor.cbc_PriceAmount);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_Cbc_Quantity(accessor.cbc_BaseQuantity);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_Cac_AllowanceCharge(accessor.cac_AllowanceCharge);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_PayeeParty_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_PayeeParty.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_PayeeParty.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cac_PartyUdid = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_PayeeParty_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_PayeeParty.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_PayeeParty.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cac_PartyUdid);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_PaymentTerms_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_PaymentTerms.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.cbc_Note, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_PaymentTerms.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        Cbc_Note conversion_result = TypeConverter<T>.ConvertTo_Cbc_Note(value);
                        
            {
                accessor.cbc_Note = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_PaymentTerms_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_PaymentTerms.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.cbc_Note, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_PaymentTerms.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_Cbc_Note(accessor.cbc_Note);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_SellersItemIdentification_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_SellersItemIdentification.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_SellersItemIdentification.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cbc_ID = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_SellersItemIdentification_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_SellersItemIdentification.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_SellersItemIdentification.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cbc_ID);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_TaxCategory_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_TaxCategory.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.cbc_ID, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 2:
                        GenericFieldAccessor.SetField(accessor.cac_TaxScheme, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_TaxCategory.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        Cbc_SchemeCode conversion_result = TypeConverter<T>.ConvertTo_Cbc_SchemeCode(value);
                        
            {
                accessor.cbc_ID = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        double conversion_result = TypeConverter<T>.ConvertTo_double(value);
                        
            {
                accessor.cbc_Percent = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        Cac_TaxScheme conversion_result = TypeConverter<T>.ConvertTo_Cac_TaxScheme(value);
                        
            {
                accessor.cac_TaxScheme = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_TaxCategory_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_TaxCategory.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.cbc_ID, fieldName, field_divider_idx + 1);
                    
                    case 2:
                        return GenericFieldAccessor.GetField<T>(accessor.cac_TaxScheme, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_TaxCategory.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_Cbc_SchemeCode(accessor.cbc_ID);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_double(accessor.cbc_Percent);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_Cac_TaxScheme(accessor.cac_TaxScheme);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_TaxScheme_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_TaxScheme.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.cbc_ID, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_TaxScheme.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        Cbc_SchemeCode conversion_result = TypeConverter<T>.ConvertTo_Cbc_SchemeCode(value);
                        
            {
                accessor.cbc_ID = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_TaxScheme_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_TaxScheme.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.cbc_ID, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_TaxScheme.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_Cbc_SchemeCode(accessor.cbc_ID);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_TaxSubtotal_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_TaxSubtotal.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.cbc_TaxableAmount, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 1:
                        GenericFieldAccessor.SetField(accessor.cbc_TaxAmount, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 2:
                        GenericFieldAccessor.SetField(accessor.cac_TaxCategory, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_TaxSubtotal.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        Cbc_Amount conversion_result = TypeConverter<T>.ConvertTo_Cbc_Amount(value);
                        
            {
                accessor.cbc_TaxableAmount = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        Cbc_Amount conversion_result = TypeConverter<T>.ConvertTo_Cbc_Amount(value);
                        
            {
                accessor.cbc_TaxAmount = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        Cac_TaxCategory conversion_result = TypeConverter<T>.ConvertTo_Cac_TaxCategory(value);
                        
            {
                accessor.cac_TaxCategory = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_TaxSubtotal_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_TaxSubtotal.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.cbc_TaxableAmount, fieldName, field_divider_idx + 1);
                    
                    case 1:
                        return GenericFieldAccessor.GetField<T>(accessor.cbc_TaxAmount, fieldName, field_divider_idx + 1);
                    
                    case 2:
                        return GenericFieldAccessor.GetField<T>(accessor.cac_TaxCategory, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_TaxSubtotal.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_Cbc_Amount(accessor.cbc_TaxableAmount);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_Cbc_Amount(accessor.cbc_TaxAmount);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_Cac_TaxCategory(accessor.cac_TaxCategory);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_TaxTotal_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_TaxTotal.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.cbc_TaxAmount, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_TaxTotal.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        Cbc_Amount conversion_result = TypeConverter<T>.ConvertTo_Cbc_Amount(value);
                        
            {
                accessor.cbc_TaxAmount = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        List<Cac_TaxSubtotal> conversion_result = TypeConverter<T>.ConvertTo_List_Cac_TaxSubtotal(value);
                        
            {
                accessor.cac_TaxSubtotals = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_TaxTotal_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_TaxTotal.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.cbc_TaxAmount, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_TaxTotal.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_Cbc_Amount(accessor.cbc_TaxAmount);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_List_Cac_TaxSubtotal(accessor.cac_TaxSubtotals);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_Item_Claims_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_Item_Claims.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 1:
                        GenericFieldAccessor.SetField(accessor.cac_SellersItemIdentification, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 2:
                        GenericFieldAccessor.SetField(accessor.cac_StandardItemIdentification, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 4:
                        GenericFieldAccessor.SetField(accessor.cac_ClassifiedTaxCategory, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_Item_Claims.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cbc_Name = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        Cac_SellersItemIdentification conversion_result = TypeConverter<T>.ConvertTo_Cac_SellersItemIdentification(value);
                        
            {
                accessor.cac_SellersItemIdentification = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        Cbc_SchemeCode conversion_result = TypeConverter<T>.ConvertTo_Cbc_SchemeCode(value);
                        
            {
                accessor.cac_StandardItemIdentification = conversion_result;
            }
            
                        break;
                    }
                
                case 3:
                    {
                        List<Cbc_ListCode> conversion_result = TypeConverter<T>.ConvertTo_List_Cbc_ListCode(value);
                        
            {
                accessor.cac_CommodityClassification = conversion_result;
            }
            
                        break;
                    }
                
                case 4:
                    {
                        Cac_ClassifiedTaxCategory conversion_result = TypeConverter<T>.ConvertTo_Cac_ClassifiedTaxCategory(value);
                        
            {
                accessor.cac_ClassifiedTaxCategory = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_Item_Claims_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_Item_Claims.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 1:
                        return GenericFieldAccessor.GetField<T>(accessor.cac_SellersItemIdentification, fieldName, field_divider_idx + 1);
                    
                    case 2:
                        return GenericFieldAccessor.GetField<T>(accessor.cac_StandardItemIdentification, fieldName, field_divider_idx + 1);
                    
                    case 4:
                        return GenericFieldAccessor.GetField<T>(accessor.cac_ClassifiedTaxCategory, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_Item_Claims.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cbc_Name);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_Cac_SellersItemIdentification(accessor.cac_SellersItemIdentification);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_Cbc_SchemeCode(accessor.cac_StandardItemIdentification);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_List_Cbc_ListCode(accessor.cac_CommodityClassification);
                    break;
                
                case 4:
                    return TypeConverter<T>.ConvertFrom_Cac_ClassifiedTaxCategory(accessor.cac_ClassifiedTaxCategory);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_Item_EnvelopeContent_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_Item_EnvelopeContent.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 3:
                        GenericFieldAccessor.SetField(accessor.claims, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 4:
                        GenericFieldAccessor.SetField(accessor.encryptedclaims, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_Item_EnvelopeContent.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.udid = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        List<string> conversion_result = TypeConverter<T>.ConvertTo_List_string(value);
                        
            {
                accessor.context = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                if (conversion_result != default(string))
                    accessor.credentialsubjectudid = conversion_result;
                else
                    accessor.Remove_credentialsubjectudid();
            }
            
                        break;
                    }
                
                case 3:
                    {
                        Cac_Item_Claims? conversion_result = TypeConverter<T>.ConvertTo_Cac_Item_Claims_nullable(value);
                        
            {
                if (conversion_result.HasValue)
                    accessor.claims = conversion_result.Value;
                else
                    accessor.Remove_claims();
            }
            
                        break;
                    }
                
                case 4:
                    {
                        TRAEncryptedClaims? conversion_result = TypeConverter<T>.ConvertTo_TRAEncryptedClaims_nullable(value);
                        
            {
                if (conversion_result.HasValue)
                    accessor.encryptedclaims = conversion_result.Value;
                else
                    accessor.Remove_encryptedclaims();
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_Item_EnvelopeContent_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_Item_EnvelopeContent.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 3:
                        return GenericFieldAccessor.GetField<T>(accessor.claims, fieldName, field_divider_idx + 1);
                    
                    case 4:
                        return GenericFieldAccessor.GetField<T>(accessor.encryptedclaims, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_Item_EnvelopeContent.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.udid);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_List_string(accessor.context);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.credentialsubjectudid);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_Cac_Item_Claims_nullable(accessor.claims);
                    break;
                
                case 4:
                    return TypeConverter<T>.ConvertFrom_TRAEncryptedClaims_nullable(accessor.encryptedclaims);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_Item_Envelope_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_Item_Envelope.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.content, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 1:
                        GenericFieldAccessor.SetField(accessor.label, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_Item_Envelope.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        Cac_Item_EnvelopeContent conversion_result = TypeConverter<T>.ConvertTo_Cac_Item_EnvelopeContent(value);
                        
            {
                accessor.content = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        TRACredential_PackingLabel conversion_result = TypeConverter<T>.ConvertTo_TRACredential_PackingLabel(value);
                        
            {
                accessor.label = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_Item_Envelope_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_Item_Envelope.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.content, fieldName, field_divider_idx + 1);
                    
                    case 1:
                        return GenericFieldAccessor.GetField<T>(accessor.label, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_Item_Envelope.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_Cac_Item_EnvelopeContent(accessor.content);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_TRACredential_PackingLabel(accessor.label);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_ExternalReference_Claims_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_ExternalReference_Claims.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 1:
                        GenericFieldAccessor.SetField(accessor.cbc_EmbeddedDocumentBinaryObject, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_ExternalReference_Claims.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                if (conversion_result != default(string))
                    accessor.cbc_URI = conversion_result;
                else
                    accessor.Remove_cbc_URI();
            }
            
                        break;
                    }
                
                case 1:
                    {
                        Cbc_EmbeddedDocumentBinaryObject? conversion_result = TypeConverter<T>.ConvertTo_Cbc_EmbeddedDocumentBinaryObject_nullable(value);
                        
            {
                if (conversion_result.HasValue)
                    accessor.cbc_EmbeddedDocumentBinaryObject = conversion_result.Value;
                else
                    accessor.Remove_cbc_EmbeddedDocumentBinaryObject();
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_ExternalReference_Claims_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_ExternalReference_Claims.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 1:
                        return GenericFieldAccessor.GetField<T>(accessor.cbc_EmbeddedDocumentBinaryObject, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_ExternalReference_Claims.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cbc_URI);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_Cbc_EmbeddedDocumentBinaryObject_nullable(accessor.cbc_EmbeddedDocumentBinaryObject);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_ExternalReference_EnvelopeContent_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_ExternalReference_EnvelopeContent.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 3:
                        GenericFieldAccessor.SetField(accessor.claims, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 4:
                        GenericFieldAccessor.SetField(accessor.encryptedclaims, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_ExternalReference_EnvelopeContent.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.udid = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        List<string> conversion_result = TypeConverter<T>.ConvertTo_List_string(value);
                        
            {
                accessor.context = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                if (conversion_result != default(string))
                    accessor.credentialsubjectudid = conversion_result;
                else
                    accessor.Remove_credentialsubjectudid();
            }
            
                        break;
                    }
                
                case 3:
                    {
                        Cac_ExternalReference_Claims? conversion_result = TypeConverter<T>.ConvertTo_Cac_ExternalReference_Claims_nullable(value);
                        
            {
                if (conversion_result.HasValue)
                    accessor.claims = conversion_result.Value;
                else
                    accessor.Remove_claims();
            }
            
                        break;
                    }
                
                case 4:
                    {
                        TRAEncryptedClaims? conversion_result = TypeConverter<T>.ConvertTo_TRAEncryptedClaims_nullable(value);
                        
            {
                if (conversion_result.HasValue)
                    accessor.encryptedclaims = conversion_result.Value;
                else
                    accessor.Remove_encryptedclaims();
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_ExternalReference_EnvelopeContent_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_ExternalReference_EnvelopeContent.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 3:
                        return GenericFieldAccessor.GetField<T>(accessor.claims, fieldName, field_divider_idx + 1);
                    
                    case 4:
                        return GenericFieldAccessor.GetField<T>(accessor.encryptedclaims, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_ExternalReference_EnvelopeContent.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.udid);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_List_string(accessor.context);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.credentialsubjectudid);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_Cac_ExternalReference_Claims_nullable(accessor.claims);
                    break;
                
                case 4:
                    return TypeConverter<T>.ConvertFrom_TRAEncryptedClaims_nullable(accessor.encryptedclaims);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_ExternalReference_Envelope_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_ExternalReference_Envelope.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.content, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 1:
                        GenericFieldAccessor.SetField(accessor.label, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_ExternalReference_Envelope.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        Cac_ExternalReference_EnvelopeContent conversion_result = TypeConverter<T>.ConvertTo_Cac_ExternalReference_EnvelopeContent(value);
                        
            {
                accessor.content = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        TRACredential_PackingLabel conversion_result = TypeConverter<T>.ConvertTo_TRACredential_PackingLabel(value);
                        
            {
                accessor.label = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_ExternalReference_Envelope_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_ExternalReference_Envelope.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.content, fieldName, field_divider_idx + 1);
                    
                    case 1:
                        return GenericFieldAccessor.GetField<T>(accessor.label, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_ExternalReference_Envelope.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_Cac_ExternalReference_EnvelopeContent(accessor.content);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_TRACredential_PackingLabel(accessor.label);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_Address_Claims_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_Address_Claims.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 8:
                        GenericFieldAccessor.SetField(accessor.cbc_Country, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_Address_Claims.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cbc_ID = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cbc_PostBox = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cbc_StreetName = conversion_result;
            }
            
                        break;
                    }
                
                case 3:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cbc_AdditionalStreetName = conversion_result;
            }
            
                        break;
                    }
                
                case 4:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cbc_BuildingNumber = conversion_result;
            }
            
                        break;
                    }
                
                case 5:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cbc_Department = conversion_result;
            }
            
                        break;
                    }
                
                case 6:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cbc_CityName = conversion_result;
            }
            
                        break;
                    }
                
                case 7:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cbc_CountrySubentityCode = conversion_result;
            }
            
                        break;
                    }
                
                case 8:
                    {
                        Cac_Country conversion_result = TypeConverter<T>.ConvertTo_Cac_Country(value);
                        
            {
                accessor.cbc_Country = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_Address_Claims_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_Address_Claims.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 8:
                        return GenericFieldAccessor.GetField<T>(accessor.cbc_Country, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_Address_Claims.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cbc_ID);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cbc_PostBox);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cbc_StreetName);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cbc_AdditionalStreetName);
                    break;
                
                case 4:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cbc_BuildingNumber);
                    break;
                
                case 5:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cbc_Department);
                    break;
                
                case 6:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cbc_CityName);
                    break;
                
                case 7:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cbc_CountrySubentityCode);
                    break;
                
                case 8:
                    return TypeConverter<T>.ConvertFrom_Cac_Country(accessor.cbc_Country);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_Address_EnvelopeContent_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_Address_EnvelopeContent.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 3:
                        GenericFieldAccessor.SetField(accessor.claims, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 4:
                        GenericFieldAccessor.SetField(accessor.encryptedclaims, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_Address_EnvelopeContent.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.udid = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        List<string> conversion_result = TypeConverter<T>.ConvertTo_List_string(value);
                        
            {
                accessor.context = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                if (conversion_result != default(string))
                    accessor.credentialsubjectudid = conversion_result;
                else
                    accessor.Remove_credentialsubjectudid();
            }
            
                        break;
                    }
                
                case 3:
                    {
                        Cac_Address_Claims? conversion_result = TypeConverter<T>.ConvertTo_Cac_Address_Claims_nullable(value);
                        
            {
                if (conversion_result.HasValue)
                    accessor.claims = conversion_result.Value;
                else
                    accessor.Remove_claims();
            }
            
                        break;
                    }
                
                case 4:
                    {
                        TRAEncryptedClaims? conversion_result = TypeConverter<T>.ConvertTo_TRAEncryptedClaims_nullable(value);
                        
            {
                if (conversion_result.HasValue)
                    accessor.encryptedclaims = conversion_result.Value;
                else
                    accessor.Remove_encryptedclaims();
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_Address_EnvelopeContent_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_Address_EnvelopeContent.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 3:
                        return GenericFieldAccessor.GetField<T>(accessor.claims, fieldName, field_divider_idx + 1);
                    
                    case 4:
                        return GenericFieldAccessor.GetField<T>(accessor.encryptedclaims, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_Address_EnvelopeContent.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.udid);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_List_string(accessor.context);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.credentialsubjectudid);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_Cac_Address_Claims_nullable(accessor.claims);
                    break;
                
                case 4:
                    return TypeConverter<T>.ConvertFrom_TRAEncryptedClaims_nullable(accessor.encryptedclaims);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_Address_Envelope_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_Address_Envelope.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.content, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 1:
                        GenericFieldAccessor.SetField(accessor.label, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_Address_Envelope.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        Cac_Address_EnvelopeContent conversion_result = TypeConverter<T>.ConvertTo_Cac_Address_EnvelopeContent(value);
                        
            {
                accessor.content = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        TRACredential_PackingLabel conversion_result = TypeConverter<T>.ConvertTo_TRACredential_PackingLabel(value);
                        
            {
                accessor.label = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_Address_Envelope_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_Address_Envelope.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.content, fieldName, field_divider_idx + 1);
                    
                    case 1:
                        return GenericFieldAccessor.GetField<T>(accessor.label, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_Address_Envelope.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_Cac_Address_EnvelopeContent(accessor.content);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_TRACredential_PackingLabel(accessor.label);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_PartyLegalEntity_Claims_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_PartyLegalEntity_Claims.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 1:
                        GenericFieldAccessor.SetField(accessor.cbc_CompanyID, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_PartyLegalEntity_Claims.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cbc_RegistrationName = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        Cbc_SchemeCode conversion_result = TypeConverter<T>.ConvertTo_Cbc_SchemeCode(value);
                        
            {
                accessor.cbc_CompanyID = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cbc_RegistrationAddressUdid = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_PartyLegalEntity_Claims_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_PartyLegalEntity_Claims.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 1:
                        return GenericFieldAccessor.GetField<T>(accessor.cbc_CompanyID, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_PartyLegalEntity_Claims.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cbc_RegistrationName);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_Cbc_SchemeCode(accessor.cbc_CompanyID);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cbc_RegistrationAddressUdid);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_PartyLegalEntity_EnvelopeContent_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_PartyLegalEntity_EnvelopeContent.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 3:
                        GenericFieldAccessor.SetField(accessor.claims, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 4:
                        GenericFieldAccessor.SetField(accessor.encryptedclaims, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_PartyLegalEntity_EnvelopeContent.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.udid = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        List<string> conversion_result = TypeConverter<T>.ConvertTo_List_string(value);
                        
            {
                accessor.context = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                if (conversion_result != default(string))
                    accessor.credentialsubjectudid = conversion_result;
                else
                    accessor.Remove_credentialsubjectudid();
            }
            
                        break;
                    }
                
                case 3:
                    {
                        Cac_PartyLegalEntity_Claims? conversion_result = TypeConverter<T>.ConvertTo_Cac_PartyLegalEntity_Claims_nullable(value);
                        
            {
                if (conversion_result.HasValue)
                    accessor.claims = conversion_result.Value;
                else
                    accessor.Remove_claims();
            }
            
                        break;
                    }
                
                case 4:
                    {
                        TRAEncryptedClaims? conversion_result = TypeConverter<T>.ConvertTo_TRAEncryptedClaims_nullable(value);
                        
            {
                if (conversion_result.HasValue)
                    accessor.encryptedclaims = conversion_result.Value;
                else
                    accessor.Remove_encryptedclaims();
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_PartyLegalEntity_EnvelopeContent_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_PartyLegalEntity_EnvelopeContent.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 3:
                        return GenericFieldAccessor.GetField<T>(accessor.claims, fieldName, field_divider_idx + 1);
                    
                    case 4:
                        return GenericFieldAccessor.GetField<T>(accessor.encryptedclaims, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_PartyLegalEntity_EnvelopeContent.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.udid);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_List_string(accessor.context);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.credentialsubjectudid);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_Cac_PartyLegalEntity_Claims_nullable(accessor.claims);
                    break;
                
                case 4:
                    return TypeConverter<T>.ConvertFrom_TRAEncryptedClaims_nullable(accessor.encryptedclaims);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_PartyLegalEntity_Envelope_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_PartyLegalEntity_Envelope.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.content, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 1:
                        GenericFieldAccessor.SetField(accessor.label, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_PartyLegalEntity_Envelope.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        Cac_PartyLegalEntity_EnvelopeContent conversion_result = TypeConverter<T>.ConvertTo_Cac_PartyLegalEntity_EnvelopeContent(value);
                        
            {
                accessor.content = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        TRACredential_PackingLabel conversion_result = TypeConverter<T>.ConvertTo_TRACredential_PackingLabel(value);
                        
            {
                accessor.label = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_PartyLegalEntity_Envelope_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_PartyLegalEntity_Envelope.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.content, fieldName, field_divider_idx + 1);
                    
                    case 1:
                        return GenericFieldAccessor.GetField<T>(accessor.label, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_PartyLegalEntity_Envelope.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_Cac_PartyLegalEntity_EnvelopeContent(accessor.content);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_TRACredential_PackingLabel(accessor.label);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_Contact_Claims_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_Contact_Claims.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_Contact_Claims.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cbc_Telephone = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cbc_Telefax = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cbc_ElectronicMail = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_Contact_Claims_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_Contact_Claims.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_Contact_Claims.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cbc_Telephone);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cbc_Telefax);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cbc_ElectronicMail);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_Contact_EnvelopeContent_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_Contact_EnvelopeContent.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 3:
                        GenericFieldAccessor.SetField(accessor.claims, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 4:
                        GenericFieldAccessor.SetField(accessor.encryptedclaims, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_Contact_EnvelopeContent.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.udid = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        List<string> conversion_result = TypeConverter<T>.ConvertTo_List_string(value);
                        
            {
                accessor.context = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                if (conversion_result != default(string))
                    accessor.credentialsubjectudid = conversion_result;
                else
                    accessor.Remove_credentialsubjectudid();
            }
            
                        break;
                    }
                
                case 3:
                    {
                        Cac_Contact_Claims? conversion_result = TypeConverter<T>.ConvertTo_Cac_Contact_Claims_nullable(value);
                        
            {
                if (conversion_result.HasValue)
                    accessor.claims = conversion_result.Value;
                else
                    accessor.Remove_claims();
            }
            
                        break;
                    }
                
                case 4:
                    {
                        TRAEncryptedClaims? conversion_result = TypeConverter<T>.ConvertTo_TRAEncryptedClaims_nullable(value);
                        
            {
                if (conversion_result.HasValue)
                    accessor.encryptedclaims = conversion_result.Value;
                else
                    accessor.Remove_encryptedclaims();
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_Contact_EnvelopeContent_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_Contact_EnvelopeContent.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 3:
                        return GenericFieldAccessor.GetField<T>(accessor.claims, fieldName, field_divider_idx + 1);
                    
                    case 4:
                        return GenericFieldAccessor.GetField<T>(accessor.encryptedclaims, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_Contact_EnvelopeContent.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.udid);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_List_string(accessor.context);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.credentialsubjectudid);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_Cac_Contact_Claims_nullable(accessor.claims);
                    break;
                
                case 4:
                    return TypeConverter<T>.ConvertFrom_TRAEncryptedClaims_nullable(accessor.encryptedclaims);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_Contact_Envelope_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_Contact_Envelope.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.content, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 1:
                        GenericFieldAccessor.SetField(accessor.label, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_Contact_Envelope.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        Cac_Contact_EnvelopeContent conversion_result = TypeConverter<T>.ConvertTo_Cac_Contact_EnvelopeContent(value);
                        
            {
                accessor.content = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        TRACredential_PackingLabel conversion_result = TypeConverter<T>.ConvertTo_TRACredential_PackingLabel(value);
                        
            {
                accessor.label = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_Contact_Envelope_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_Contact_Envelope.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.content, fieldName, field_divider_idx + 1);
                    
                    case 1:
                        return GenericFieldAccessor.GetField<T>(accessor.label, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_Contact_Envelope.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_Cac_Contact_EnvelopeContent(accessor.content);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_TRACredential_PackingLabel(accessor.label);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_Person_Claims_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_Person_Claims.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_Person_Claims.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cbc_FirstName = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cbc_MiddleName = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cbc_FamilyName = conversion_result;
            }
            
                        break;
                    }
                
                case 3:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cbc_JobTitle = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_Person_Claims_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_Person_Claims.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_Person_Claims.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cbc_FirstName);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cbc_MiddleName);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cbc_FamilyName);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cbc_JobTitle);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_Person_EnvelopeContent_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_Person_EnvelopeContent.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 3:
                        GenericFieldAccessor.SetField(accessor.claims, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 4:
                        GenericFieldAccessor.SetField(accessor.encryptedclaims, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_Person_EnvelopeContent.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.udid = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        List<string> conversion_result = TypeConverter<T>.ConvertTo_List_string(value);
                        
            {
                accessor.context = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                if (conversion_result != default(string))
                    accessor.credentialsubjectudid = conversion_result;
                else
                    accessor.Remove_credentialsubjectudid();
            }
            
                        break;
                    }
                
                case 3:
                    {
                        Cac_Person_Claims? conversion_result = TypeConverter<T>.ConvertTo_Cac_Person_Claims_nullable(value);
                        
            {
                if (conversion_result.HasValue)
                    accessor.claims = conversion_result.Value;
                else
                    accessor.Remove_claims();
            }
            
                        break;
                    }
                
                case 4:
                    {
                        TRAEncryptedClaims? conversion_result = TypeConverter<T>.ConvertTo_TRAEncryptedClaims_nullable(value);
                        
            {
                if (conversion_result.HasValue)
                    accessor.encryptedclaims = conversion_result.Value;
                else
                    accessor.Remove_encryptedclaims();
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_Person_EnvelopeContent_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_Person_EnvelopeContent.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 3:
                        return GenericFieldAccessor.GetField<T>(accessor.claims, fieldName, field_divider_idx + 1);
                    
                    case 4:
                        return GenericFieldAccessor.GetField<T>(accessor.encryptedclaims, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_Person_EnvelopeContent.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.udid);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_List_string(accessor.context);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.credentialsubjectudid);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_Cac_Person_Claims_nullable(accessor.claims);
                    break;
                
                case 4:
                    return TypeConverter<T>.ConvertFrom_TRAEncryptedClaims_nullable(accessor.encryptedclaims);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_Person_Envelope_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_Person_Envelope.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.content, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 1:
                        GenericFieldAccessor.SetField(accessor.label, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_Person_Envelope.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        Cac_Person_EnvelopeContent conversion_result = TypeConverter<T>.ConvertTo_Cac_Person_EnvelopeContent(value);
                        
            {
                accessor.content = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        TRACredential_PackingLabel conversion_result = TypeConverter<T>.ConvertTo_TRACredential_PackingLabel(value);
                        
            {
                accessor.label = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_Person_Envelope_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_Person_Envelope.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.content, fieldName, field_divider_idx + 1);
                    
                    case 1:
                        return GenericFieldAccessor.GetField<T>(accessor.label, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_Person_Envelope.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_Cac_Person_EnvelopeContent(accessor.content);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_TRACredential_PackingLabel(accessor.label);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_PaymentMeans_Claims_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_PaymentMeans_Claims.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.cbc_PaymentMeansCode, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_PaymentMeans_Claims.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        Cbc_ListCode conversion_result = TypeConverter<T>.ConvertTo_Cbc_ListCode(value);
                        
            {
                accessor.cbc_PaymentMeansCode = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        DateTime conversion_result = TypeConverter<T>.ConvertTo_DateTime(value);
                        
            {
                accessor.cbc_PaymentDueDate = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cbc_PaymentChannel = conversion_result;
            }
            
                        break;
                    }
                
                case 3:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cbc_PaymentID = conversion_result;
            }
            
                        break;
                    }
                
                case 4:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cac_PayeeFinancialAccountUdid = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_PaymentMeans_Claims_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_PaymentMeans_Claims.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.cbc_PaymentMeansCode, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_PaymentMeans_Claims.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_Cbc_ListCode(accessor.cbc_PaymentMeansCode);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_DateTime(accessor.cbc_PaymentDueDate);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cbc_PaymentChannel);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cbc_PaymentID);
                    break;
                
                case 4:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cac_PayeeFinancialAccountUdid);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_PaymentMeans_EnvelopeContent_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_PaymentMeans_EnvelopeContent.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 3:
                        GenericFieldAccessor.SetField(accessor.claims, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 4:
                        GenericFieldAccessor.SetField(accessor.encryptedclaims, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_PaymentMeans_EnvelopeContent.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.udid = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        List<string> conversion_result = TypeConverter<T>.ConvertTo_List_string(value);
                        
            {
                accessor.context = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                if (conversion_result != default(string))
                    accessor.credentialsubjectudid = conversion_result;
                else
                    accessor.Remove_credentialsubjectudid();
            }
            
                        break;
                    }
                
                case 3:
                    {
                        Cac_PaymentMeans_Claims? conversion_result = TypeConverter<T>.ConvertTo_Cac_PaymentMeans_Claims_nullable(value);
                        
            {
                if (conversion_result.HasValue)
                    accessor.claims = conversion_result.Value;
                else
                    accessor.Remove_claims();
            }
            
                        break;
                    }
                
                case 4:
                    {
                        TRAEncryptedClaims? conversion_result = TypeConverter<T>.ConvertTo_TRAEncryptedClaims_nullable(value);
                        
            {
                if (conversion_result.HasValue)
                    accessor.encryptedclaims = conversion_result.Value;
                else
                    accessor.Remove_encryptedclaims();
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_PaymentMeans_EnvelopeContent_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_PaymentMeans_EnvelopeContent.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 3:
                        return GenericFieldAccessor.GetField<T>(accessor.claims, fieldName, field_divider_idx + 1);
                    
                    case 4:
                        return GenericFieldAccessor.GetField<T>(accessor.encryptedclaims, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_PaymentMeans_EnvelopeContent.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.udid);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_List_string(accessor.context);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.credentialsubjectudid);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_Cac_PaymentMeans_Claims_nullable(accessor.claims);
                    break;
                
                case 4:
                    return TypeConverter<T>.ConvertFrom_TRAEncryptedClaims_nullable(accessor.encryptedclaims);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_PaymentMeans_Envelope_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_PaymentMeans_Envelope.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.content, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 1:
                        GenericFieldAccessor.SetField(accessor.label, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_PaymentMeans_Envelope.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        Cac_PaymentMeans_EnvelopeContent conversion_result = TypeConverter<T>.ConvertTo_Cac_PaymentMeans_EnvelopeContent(value);
                        
            {
                accessor.content = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        TRACredential_PackingLabel conversion_result = TypeConverter<T>.ConvertTo_TRACredential_PackingLabel(value);
                        
            {
                accessor.label = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_PaymentMeans_Envelope_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_PaymentMeans_Envelope.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.content, fieldName, field_divider_idx + 1);
                    
                    case 1:
                        return GenericFieldAccessor.GetField<T>(accessor.label, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_PaymentMeans_Envelope.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_Cac_PaymentMeans_EnvelopeContent(accessor.content);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_TRACredential_PackingLabel(accessor.label);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_PayeeFinancialAccount_Claims_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_PayeeFinancialAccount_Claims.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 1:
                        GenericFieldAccessor.SetField(accessor.cac_FinancialInstitutionBranch, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_PayeeFinancialAccount_Claims.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cbc_ID = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        Cac_FinancialInstitutionBranch conversion_result = TypeConverter<T>.ConvertTo_Cac_FinancialInstitutionBranch(value);
                        
            {
                accessor.cac_FinancialInstitutionBranch = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_PayeeFinancialAccount_Claims_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_PayeeFinancialAccount_Claims.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 1:
                        return GenericFieldAccessor.GetField<T>(accessor.cac_FinancialInstitutionBranch, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_PayeeFinancialAccount_Claims.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cbc_ID);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_Cac_FinancialInstitutionBranch(accessor.cac_FinancialInstitutionBranch);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_PayeeFinancialAccount_EnvelopeContent_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_PayeeFinancialAccount_EnvelopeContent.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 3:
                        GenericFieldAccessor.SetField(accessor.claims, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 4:
                        GenericFieldAccessor.SetField(accessor.encryptedclaims, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_PayeeFinancialAccount_EnvelopeContent.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.udid = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        List<string> conversion_result = TypeConverter<T>.ConvertTo_List_string(value);
                        
            {
                accessor.context = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                if (conversion_result != default(string))
                    accessor.credentialsubjectudid = conversion_result;
                else
                    accessor.Remove_credentialsubjectudid();
            }
            
                        break;
                    }
                
                case 3:
                    {
                        Cac_PayeeFinancialAccount_Claims? conversion_result = TypeConverter<T>.ConvertTo_Cac_PayeeFinancialAccount_Claims_nullable(value);
                        
            {
                if (conversion_result.HasValue)
                    accessor.claims = conversion_result.Value;
                else
                    accessor.Remove_claims();
            }
            
                        break;
                    }
                
                case 4:
                    {
                        TRAEncryptedClaims? conversion_result = TypeConverter<T>.ConvertTo_TRAEncryptedClaims_nullable(value);
                        
            {
                if (conversion_result.HasValue)
                    accessor.encryptedclaims = conversion_result.Value;
                else
                    accessor.Remove_encryptedclaims();
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_PayeeFinancialAccount_EnvelopeContent_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_PayeeFinancialAccount_EnvelopeContent.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 3:
                        return GenericFieldAccessor.GetField<T>(accessor.claims, fieldName, field_divider_idx + 1);
                    
                    case 4:
                        return GenericFieldAccessor.GetField<T>(accessor.encryptedclaims, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_PayeeFinancialAccount_EnvelopeContent.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.udid);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_List_string(accessor.context);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.credentialsubjectudid);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_Cac_PayeeFinancialAccount_Claims_nullable(accessor.claims);
                    break;
                
                case 4:
                    return TypeConverter<T>.ConvertFrom_TRAEncryptedClaims_nullable(accessor.encryptedclaims);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_PayeeFinancialAccount_Envelope_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_PayeeFinancialAccount_Envelope.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.content, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 1:
                        GenericFieldAccessor.SetField(accessor.label, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_PayeeFinancialAccount_Envelope.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        Cac_PayeeFinancialAccount_EnvelopeContent conversion_result = TypeConverter<T>.ConvertTo_Cac_PayeeFinancialAccount_EnvelopeContent(value);
                        
            {
                accessor.content = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        TRACredential_PackingLabel conversion_result = TypeConverter<T>.ConvertTo_TRACredential_PackingLabel(value);
                        
            {
                accessor.label = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_PayeeFinancialAccount_Envelope_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_PayeeFinancialAccount_Envelope.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.content, fieldName, field_divider_idx + 1);
                    
                    case 1:
                        return GenericFieldAccessor.GetField<T>(accessor.label, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_PayeeFinancialAccount_Envelope.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_Cac_PayeeFinancialAccount_EnvelopeContent(accessor.content);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_TRACredential_PackingLabel(accessor.label);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_Party_Claims_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_Party_Claims.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.cbc_EndpointID, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 1:
                        GenericFieldAccessor.SetField(accessor.cbc_PartyIdentification, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 2:
                        GenericFieldAccessor.SetField(accessor.cbc_PartyName, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 4:
                        GenericFieldAccessor.SetField(accessor.cbc_PartyTaxScheme, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_Party_Claims.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        Cbc_SchemeCode conversion_result = TypeConverter<T>.ConvertTo_Cbc_SchemeCode(value);
                        
            {
                accessor.cbc_EndpointID = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        Cac_PartyIdentification conversion_result = TypeConverter<T>.ConvertTo_Cac_PartyIdentification(value);
                        
            {
                accessor.cbc_PartyIdentification = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        Cac_PartyName conversion_result = TypeConverter<T>.ConvertTo_Cac_PartyName(value);
                        
            {
                accessor.cbc_PartyName = conversion_result;
            }
            
                        break;
                    }
                
                case 3:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cac_PostalAddressUdid = conversion_result;
            }
            
                        break;
                    }
                
                case 4:
                    {
                        Cac_PartyTaxScheme conversion_result = TypeConverter<T>.ConvertTo_Cac_PartyTaxScheme(value);
                        
            {
                accessor.cbc_PartyTaxScheme = conversion_result;
            }
            
                        break;
                    }
                
                case 5:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cac_PartyLegalEntityUdid = conversion_result;
            }
            
                        break;
                    }
                
                case 6:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cac_ContactUdid = conversion_result;
            }
            
                        break;
                    }
                
                case 7:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cac_PersonUdid = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_Party_Claims_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_Party_Claims.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.cbc_EndpointID, fieldName, field_divider_idx + 1);
                    
                    case 1:
                        return GenericFieldAccessor.GetField<T>(accessor.cbc_PartyIdentification, fieldName, field_divider_idx + 1);
                    
                    case 2:
                        return GenericFieldAccessor.GetField<T>(accessor.cbc_PartyName, fieldName, field_divider_idx + 1);
                    
                    case 4:
                        return GenericFieldAccessor.GetField<T>(accessor.cbc_PartyTaxScheme, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_Party_Claims.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_Cbc_SchemeCode(accessor.cbc_EndpointID);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_Cac_PartyIdentification(accessor.cbc_PartyIdentification);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_Cac_PartyName(accessor.cbc_PartyName);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cac_PostalAddressUdid);
                    break;
                
                case 4:
                    return TypeConverter<T>.ConvertFrom_Cac_PartyTaxScheme(accessor.cbc_PartyTaxScheme);
                    break;
                
                case 5:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cac_PartyLegalEntityUdid);
                    break;
                
                case 6:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cac_ContactUdid);
                    break;
                
                case 7:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cac_PersonUdid);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_Party_EnvelopeContent_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_Party_EnvelopeContent.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 3:
                        GenericFieldAccessor.SetField(accessor.claims, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 4:
                        GenericFieldAccessor.SetField(accessor.encryptedclaims, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_Party_EnvelopeContent.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.udid = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        List<string> conversion_result = TypeConverter<T>.ConvertTo_List_string(value);
                        
            {
                accessor.context = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                if (conversion_result != default(string))
                    accessor.credentialsubjectudid = conversion_result;
                else
                    accessor.Remove_credentialsubjectudid();
            }
            
                        break;
                    }
                
                case 3:
                    {
                        Cac_Party_Claims? conversion_result = TypeConverter<T>.ConvertTo_Cac_Party_Claims_nullable(value);
                        
            {
                if (conversion_result.HasValue)
                    accessor.claims = conversion_result.Value;
                else
                    accessor.Remove_claims();
            }
            
                        break;
                    }
                
                case 4:
                    {
                        TRAEncryptedClaims? conversion_result = TypeConverter<T>.ConvertTo_TRAEncryptedClaims_nullable(value);
                        
            {
                if (conversion_result.HasValue)
                    accessor.encryptedclaims = conversion_result.Value;
                else
                    accessor.Remove_encryptedclaims();
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_Party_EnvelopeContent_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_Party_EnvelopeContent.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 3:
                        return GenericFieldAccessor.GetField<T>(accessor.claims, fieldName, field_divider_idx + 1);
                    
                    case 4:
                        return GenericFieldAccessor.GetField<T>(accessor.encryptedclaims, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_Party_EnvelopeContent.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.udid);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_List_string(accessor.context);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.credentialsubjectudid);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_Cac_Party_Claims_nullable(accessor.claims);
                    break;
                
                case 4:
                    return TypeConverter<T>.ConvertFrom_TRAEncryptedClaims_nullable(accessor.encryptedclaims);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Cac_Party_Envelope_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_Party_Envelope.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.content, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 1:
                        GenericFieldAccessor.SetField(accessor.label, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_Party_Envelope.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        Cac_Party_EnvelopeContent conversion_result = TypeConverter<T>.ConvertTo_Cac_Party_EnvelopeContent(value);
                        
            {
                accessor.content = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        TRACredential_PackingLabel conversion_result = TypeConverter<T>.ConvertTo_TRACredential_PackingLabel(value);
                        
            {
                accessor.label = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Cac_Party_Envelope_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Cac_Party_Envelope.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.content, fieldName, field_divider_idx + 1);
                    
                    case 1:
                        return GenericFieldAccessor.GetField<T>(accessor.label, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Cac_Party_Envelope.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_Cac_Party_EnvelopeContent(accessor.content);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_TRACredential_PackingLabel(accessor.label);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(UBL21_Invoice2_Claims_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_UBL21_Invoice2_Claims.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 3:
                        GenericFieldAccessor.SetField(accessor.cbc_InvoiceTypeCode, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 4:
                        GenericFieldAccessor.SetField(accessor.cbc_Note, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 6:
                        GenericFieldAccessor.SetField(accessor.cbc_DocumentCurrencyCode, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 8:
                        GenericFieldAccessor.SetField(accessor.cbc_InvoicePeriod, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 9:
                        GenericFieldAccessor.SetField(accessor.cbc_OrderReference, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 10:
                        GenericFieldAccessor.SetField(accessor.cac_ContractDocumentReference, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 12:
                        GenericFieldAccessor.SetField(accessor.cac_AccountingSupplierParty, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 13:
                        GenericFieldAccessor.SetField(accessor.cac_AccountingCustomerParty, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 14:
                        GenericFieldAccessor.SetField(accessor.cac_PayeeParty, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 15:
                        GenericFieldAccessor.SetField(accessor.cac_Delivery, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 17:
                        GenericFieldAccessor.SetField(accessor.cac_PaymentTerms, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 19:
                        GenericFieldAccessor.SetField(accessor.cac_TaxTotal, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 20:
                        GenericFieldAccessor.SetField(accessor.cac_LegalMonetaryTotal, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_UBL21_Invoice2_Claims.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cbc_UBLVersionID = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cbc_ID = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        DateTime conversion_result = TypeConverter<T>.ConvertTo_DateTime(value);
                        
            {
                accessor.cbc_IssueDate = conversion_result;
            }
            
                        break;
                    }
                
                case 3:
                    {
                        Cbc_ListCode conversion_result = TypeConverter<T>.ConvertTo_Cbc_ListCode(value);
                        
            {
                accessor.cbc_InvoiceTypeCode = conversion_result;
            }
            
                        break;
                    }
                
                case 4:
                    {
                        Cbc_Note conversion_result = TypeConverter<T>.ConvertTo_Cbc_Note(value);
                        
            {
                accessor.cbc_Note = conversion_result;
            }
            
                        break;
                    }
                
                case 5:
                    {
                        DateTime conversion_result = TypeConverter<T>.ConvertTo_DateTime(value);
                        
            {
                accessor.cbc_TaxPointDate = conversion_result;
            }
            
                        break;
                    }
                
                case 6:
                    {
                        Cbc_ListCode conversion_result = TypeConverter<T>.ConvertTo_Cbc_ListCode(value);
                        
            {
                accessor.cbc_DocumentCurrencyCode = conversion_result;
            }
            
                        break;
                    }
                
                case 7:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cbc_AccountingCost = conversion_result;
            }
            
                        break;
                    }
                
                case 8:
                    {
                        Cbc_TimePeriod conversion_result = TypeConverter<T>.ConvertTo_Cbc_TimePeriod(value);
                        
            {
                accessor.cbc_InvoicePeriod = conversion_result;
            }
            
                        break;
                    }
                
                case 9:
                    {
                        Cbc_OrderReference conversion_result = TypeConverter<T>.ConvertTo_Cbc_OrderReference(value);
                        
            {
                accessor.cbc_OrderReference = conversion_result;
            }
            
                        break;
                    }
                
                case 10:
                    {
                        Cac_DocumentReference conversion_result = TypeConverter<T>.ConvertTo_Cac_DocumentReference(value);
                        
            {
                accessor.cac_ContractDocumentReference = conversion_result;
            }
            
                        break;
                    }
                
                case 11:
                    {
                        List<Cac_DocumentReference> conversion_result = TypeConverter<T>.ConvertTo_List_Cac_DocumentReference(value);
                        
            {
                accessor.cac_AdditionalDocumentReferences = conversion_result;
            }
            
                        break;
                    }
                
                case 12:
                    {
                        Cac_AccountingSupplierParty conversion_result = TypeConverter<T>.ConvertTo_Cac_AccountingSupplierParty(value);
                        
            {
                accessor.cac_AccountingSupplierParty = conversion_result;
            }
            
                        break;
                    }
                
                case 13:
                    {
                        Cac_AccountingCustomerParty conversion_result = TypeConverter<T>.ConvertTo_Cac_AccountingCustomerParty(value);
                        
            {
                accessor.cac_AccountingCustomerParty = conversion_result;
            }
            
                        break;
                    }
                
                case 14:
                    {
                        Cac_PayeeParty conversion_result = TypeConverter<T>.ConvertTo_Cac_PayeeParty(value);
                        
            {
                accessor.cac_PayeeParty = conversion_result;
            }
            
                        break;
                    }
                
                case 15:
                    {
                        Cac_Delivery conversion_result = TypeConverter<T>.ConvertTo_Cac_Delivery(value);
                        
            {
                accessor.cac_Delivery = conversion_result;
            }
            
                        break;
                    }
                
                case 16:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.cac_PaymentMeansUdid = conversion_result;
            }
            
                        break;
                    }
                
                case 17:
                    {
                        Cac_PaymentTerms conversion_result = TypeConverter<T>.ConvertTo_Cac_PaymentTerms(value);
                        
            {
                accessor.cac_PaymentTerms = conversion_result;
            }
            
                        break;
                    }
                
                case 18:
                    {
                        List<Cac_AllowanceCharge> conversion_result = TypeConverter<T>.ConvertTo_List_Cac_AllowanceCharge(value);
                        
            {
                accessor.cac_AllowanceCharges = conversion_result;
            }
            
                        break;
                    }
                
                case 19:
                    {
                        Cac_TaxTotal conversion_result = TypeConverter<T>.ConvertTo_Cac_TaxTotal(value);
                        
            {
                accessor.cac_TaxTotal = conversion_result;
            }
            
                        break;
                    }
                
                case 20:
                    {
                        Cac_LegalMonetaryTotal conversion_result = TypeConverter<T>.ConvertTo_Cac_LegalMonetaryTotal(value);
                        
            {
                accessor.cac_LegalMonetaryTotal = conversion_result;
            }
            
                        break;
                    }
                
                case 21:
                    {
                        List<Cac_InvoiceLine> conversion_result = TypeConverter<T>.ConvertTo_List_Cac_InvoiceLine(value);
                        
            {
                accessor.cac_InvoiceLine = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(UBL21_Invoice2_Claims_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_UBL21_Invoice2_Claims.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 3:
                        return GenericFieldAccessor.GetField<T>(accessor.cbc_InvoiceTypeCode, fieldName, field_divider_idx + 1);
                    
                    case 4:
                        return GenericFieldAccessor.GetField<T>(accessor.cbc_Note, fieldName, field_divider_idx + 1);
                    
                    case 6:
                        return GenericFieldAccessor.GetField<T>(accessor.cbc_DocumentCurrencyCode, fieldName, field_divider_idx + 1);
                    
                    case 8:
                        return GenericFieldAccessor.GetField<T>(accessor.cbc_InvoicePeriod, fieldName, field_divider_idx + 1);
                    
                    case 9:
                        return GenericFieldAccessor.GetField<T>(accessor.cbc_OrderReference, fieldName, field_divider_idx + 1);
                    
                    case 10:
                        return GenericFieldAccessor.GetField<T>(accessor.cac_ContractDocumentReference, fieldName, field_divider_idx + 1);
                    
                    case 12:
                        return GenericFieldAccessor.GetField<T>(accessor.cac_AccountingSupplierParty, fieldName, field_divider_idx + 1);
                    
                    case 13:
                        return GenericFieldAccessor.GetField<T>(accessor.cac_AccountingCustomerParty, fieldName, field_divider_idx + 1);
                    
                    case 14:
                        return GenericFieldAccessor.GetField<T>(accessor.cac_PayeeParty, fieldName, field_divider_idx + 1);
                    
                    case 15:
                        return GenericFieldAccessor.GetField<T>(accessor.cac_Delivery, fieldName, field_divider_idx + 1);
                    
                    case 17:
                        return GenericFieldAccessor.GetField<T>(accessor.cac_PaymentTerms, fieldName, field_divider_idx + 1);
                    
                    case 19:
                        return GenericFieldAccessor.GetField<T>(accessor.cac_TaxTotal, fieldName, field_divider_idx + 1);
                    
                    case 20:
                        return GenericFieldAccessor.GetField<T>(accessor.cac_LegalMonetaryTotal, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_UBL21_Invoice2_Claims.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cbc_UBLVersionID);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cbc_ID);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_DateTime(accessor.cbc_IssueDate);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_Cbc_ListCode(accessor.cbc_InvoiceTypeCode);
                    break;
                
                case 4:
                    return TypeConverter<T>.ConvertFrom_Cbc_Note(accessor.cbc_Note);
                    break;
                
                case 5:
                    return TypeConverter<T>.ConvertFrom_DateTime(accessor.cbc_TaxPointDate);
                    break;
                
                case 6:
                    return TypeConverter<T>.ConvertFrom_Cbc_ListCode(accessor.cbc_DocumentCurrencyCode);
                    break;
                
                case 7:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cbc_AccountingCost);
                    break;
                
                case 8:
                    return TypeConverter<T>.ConvertFrom_Cbc_TimePeriod(accessor.cbc_InvoicePeriod);
                    break;
                
                case 9:
                    return TypeConverter<T>.ConvertFrom_Cbc_OrderReference(accessor.cbc_OrderReference);
                    break;
                
                case 10:
                    return TypeConverter<T>.ConvertFrom_Cac_DocumentReference(accessor.cac_ContractDocumentReference);
                    break;
                
                case 11:
                    return TypeConverter<T>.ConvertFrom_List_Cac_DocumentReference(accessor.cac_AdditionalDocumentReferences);
                    break;
                
                case 12:
                    return TypeConverter<T>.ConvertFrom_Cac_AccountingSupplierParty(accessor.cac_AccountingSupplierParty);
                    break;
                
                case 13:
                    return TypeConverter<T>.ConvertFrom_Cac_AccountingCustomerParty(accessor.cac_AccountingCustomerParty);
                    break;
                
                case 14:
                    return TypeConverter<T>.ConvertFrom_Cac_PayeeParty(accessor.cac_PayeeParty);
                    break;
                
                case 15:
                    return TypeConverter<T>.ConvertFrom_Cac_Delivery(accessor.cac_Delivery);
                    break;
                
                case 16:
                    return TypeConverter<T>.ConvertFrom_string(accessor.cac_PaymentMeansUdid);
                    break;
                
                case 17:
                    return TypeConverter<T>.ConvertFrom_Cac_PaymentTerms(accessor.cac_PaymentTerms);
                    break;
                
                case 18:
                    return TypeConverter<T>.ConvertFrom_List_Cac_AllowanceCharge(accessor.cac_AllowanceCharges);
                    break;
                
                case 19:
                    return TypeConverter<T>.ConvertFrom_Cac_TaxTotal(accessor.cac_TaxTotal);
                    break;
                
                case 20:
                    return TypeConverter<T>.ConvertFrom_Cac_LegalMonetaryTotal(accessor.cac_LegalMonetaryTotal);
                    break;
                
                case 21:
                    return TypeConverter<T>.ConvertFrom_List_Cac_InvoiceLine(accessor.cac_InvoiceLine);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(UBL21_Invoice2_EnvelopeContent_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_UBL21_Invoice2_EnvelopeContent.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 3:
                        GenericFieldAccessor.SetField(accessor.claims, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 4:
                        GenericFieldAccessor.SetField(accessor.encryptedclaims, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_UBL21_Invoice2_EnvelopeContent.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.udid = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        List<string> conversion_result = TypeConverter<T>.ConvertTo_List_string(value);
                        
            {
                accessor.context = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                if (conversion_result != default(string))
                    accessor.credentialsubjectudid = conversion_result;
                else
                    accessor.Remove_credentialsubjectudid();
            }
            
                        break;
                    }
                
                case 3:
                    {
                        UBL21_Invoice2_Claims? conversion_result = TypeConverter<T>.ConvertTo_UBL21_Invoice2_Claims_nullable(value);
                        
            {
                if (conversion_result.HasValue)
                    accessor.claims = conversion_result.Value;
                else
                    accessor.Remove_claims();
            }
            
                        break;
                    }
                
                case 4:
                    {
                        TRAEncryptedClaims? conversion_result = TypeConverter<T>.ConvertTo_TRAEncryptedClaims_nullable(value);
                        
            {
                if (conversion_result.HasValue)
                    accessor.encryptedclaims = conversion_result.Value;
                else
                    accessor.Remove_encryptedclaims();
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(UBL21_Invoice2_EnvelopeContent_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_UBL21_Invoice2_EnvelopeContent.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 3:
                        return GenericFieldAccessor.GetField<T>(accessor.claims, fieldName, field_divider_idx + 1);
                    
                    case 4:
                        return GenericFieldAccessor.GetField<T>(accessor.encryptedclaims, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_UBL21_Invoice2_EnvelopeContent.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.udid);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_List_string(accessor.context);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.credentialsubjectudid);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_UBL21_Invoice2_Claims_nullable(accessor.claims);
                    break;
                
                case 4:
                    return TypeConverter<T>.ConvertFrom_TRAEncryptedClaims_nullable(accessor.encryptedclaims);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(UBL21_Invoice2_Envelope_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_UBL21_Invoice2_Envelope.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.content, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 1:
                        GenericFieldAccessor.SetField(accessor.label, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_UBL21_Invoice2_Envelope.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        UBL21_Invoice2_EnvelopeContent conversion_result = TypeConverter<T>.ConvertTo_UBL21_Invoice2_EnvelopeContent(value);
                        
            {
                accessor.content = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        TRACredential_PackingLabel conversion_result = TypeConverter<T>.ConvertTo_TRACredential_PackingLabel(value);
                        
            {
                accessor.label = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(UBL21_Invoice2_Envelope_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_UBL21_Invoice2_Envelope.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.content, fieldName, field_divider_idx + 1);
                    
                    case 1:
                        return GenericFieldAccessor.GetField<T>(accessor.label, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_UBL21_Invoice2_Envelope.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_UBL21_Invoice2_EnvelopeContent(accessor.content);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_TRACredential_PackingLabel(accessor.label);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TDWCreateTDWCredentialRequest_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWCreateTDWCredentialRequest.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWCreateTDWCredentialRequest.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        TRACredentialType conversion_result = TypeConverter<T>.ConvertTo_TRACredentialType(value);
                        
            {
                accessor.credtype = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        List<string> conversion_result = TypeConverter<T>.ConvertTo_List_string(value);
                        
            {
                accessor.context = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                if (conversion_result != default(string))
                    accessor.credentialsubjectudid = conversion_result;
                else
                    accessor.Remove_credentialsubjectudid();
            }
            
                        break;
                    }
                
                case 3:
                    {
                        List<TRAClaim> conversion_result = TypeConverter<T>.ConvertTo_List_TRAClaim(value);
                        
            {
                accessor.claims = conversion_result;
            }
            
                        break;
                    }
                
                case 4:
                    {
                        TRATrustLevel conversion_result = TypeConverter<T>.ConvertTo_TRATrustLevel(value);
                        
            {
                accessor.trustlevel = conversion_result;
            }
            
                        break;
                    }
                
                case 5:
                    {
                        TRAEncryptionFlag conversion_result = TypeConverter<T>.ConvertTo_TRAEncryptionFlag(value);
                        
            {
                accessor.encryptionFlag = conversion_result;
            }
            
                        break;
                    }
                
                case 6:
                    {
                        List<string> conversion_result = TypeConverter<T>.ConvertTo_List_string(value);
                        
            {
                if (conversion_result != default(List<string>))
                    accessor.comments = conversion_result;
                else
                    accessor.Remove_comments();
            }
            
                        break;
                    }
                
                case 7:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.keypairsalt = conversion_result;
            }
            
                        break;
                    }
                
                case 8:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.mvcaudid = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TDWCreateTDWCredentialRequest_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWCreateTDWCredentialRequest.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWCreateTDWCredentialRequest.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_TRACredentialType(accessor.credtype);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_List_string(accessor.context);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.credentialsubjectudid);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_List_TRAClaim(accessor.claims);
                    break;
                
                case 4:
                    return TypeConverter<T>.ConvertFrom_TRATrustLevel(accessor.trustlevel);
                    break;
                
                case 5:
                    return TypeConverter<T>.ConvertFrom_TRAEncryptionFlag(accessor.encryptionFlag);
                    break;
                
                case 6:
                    return TypeConverter<T>.ConvertFrom_List_string(accessor.comments);
                    break;
                
                case 7:
                    return TypeConverter<T>.ConvertFrom_string(accessor.keypairsalt);
                    break;
                
                case 8:
                    return TypeConverter<T>.ConvertFrom_string(accessor.mvcaudid);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TDWProcessCredentialRequest_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWProcessCredentialRequest.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWProcessCredentialRequest.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        long conversion_result = TypeConverter<T>.ConvertTo_long(value);
                        
            {
                accessor.id = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.mvcaudid = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TDWProcessCredentialRequest_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWProcessCredentialRequest.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWProcessCredentialRequest.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_long(accessor.id);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_string(accessor.mvcaudid);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TDWCredentialResponse_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWCredentialResponse.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWCredentialResponse.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        long conversion_result = TypeConverter<T>.ConvertTo_long(value);
                        
            {
                accessor.id = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.udid = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        long conversion_result = TypeConverter<T>.ConvertTo_long(value);
                        
            {
                accessor.rc = conversion_result;
            }
            
                        break;
                    }
                
                case 3:
                    {
                        List<string> conversion_result = TypeConverter<T>.ConvertTo_List_string(value);
                        
            {
                accessor.messages = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TDWCredentialResponse_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TDWCredentialResponse.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TDWCredentialResponse.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_long(accessor.id);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_string(accessor.udid);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_long(accessor.rc);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_List_string(accessor.messages);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
    }
}

#pragma warning restore 162,168,649,660,661,1522
