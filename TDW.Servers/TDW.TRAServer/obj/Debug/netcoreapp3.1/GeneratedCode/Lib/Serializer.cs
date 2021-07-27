#pragma warning disable 162,168,649,660,661,1522

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Trinity;
using Trinity.TSL;
using Trinity.TSL.Lib;
namespace TDW.TRAServer
{
    /// <summary>
    /// Provides facilities for serializing data to Json strings.
    /// </summary>
    public class Serializer
    {
        [ThreadStatic]
        static StringBuilder s_stringBuilder;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void s_ensure_string_builder()
        {
            if (s_stringBuilder == null)
                s_stringBuilder = new StringBuilder();
            else
                s_stringBuilder.Clear();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a bool object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(bool value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a long object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(long value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a double object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(double value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a DateTime object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(DateTime value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a string object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(string value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a List<string> object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(List<string> value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a List<Cac_AllowanceCharge> object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(List<Cac_AllowanceCharge> value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a List<Cac_DocumentReference> object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(List<Cac_DocumentReference> value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a List<Cac_InvoiceLine> object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(List<Cac_InvoiceLine> value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a List<Cac_TaxSubtotal> object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(List<Cac_TaxSubtotal> value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a List<Cbc_ListCode> object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(List<Cbc_ListCode> value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a List<TRAClaim> object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(List<TRAClaim> value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a List<TRAKeyValuePair> object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(List<TRAKeyValuePair> value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_AccountingCustomerParty object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_AccountingCustomerParty value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_AccountingSupplierParty object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_AccountingSupplierParty value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_Address_Claims object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_Address_Claims value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_Address_Envelope object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_Address_Envelope value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_Address_EnvelopeContent object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_Address_EnvelopeContent value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_AllowanceCharge object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_AllowanceCharge value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_Attachment object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_Attachment value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_ClassifiedTaxCategory object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_ClassifiedTaxCategory value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_Contact_Claims object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_Contact_Claims value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_Contact_Envelope object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_Contact_Envelope value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_Contact_EnvelopeContent object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_Contact_EnvelopeContent value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_Country object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_Country value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_Delivery object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_Delivery value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_DeliveryLocation object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_DeliveryLocation value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_DocumentReference object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_DocumentReference value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_ExternalReference_Claims object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_ExternalReference_Claims value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_ExternalReference_Envelope object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_ExternalReference_Envelope value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_ExternalReference_EnvelopeContent object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_ExternalReference_EnvelopeContent value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_FinancialInstitution object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_FinancialInstitution value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_FinancialInstitutionBranch object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_FinancialInstitutionBranch value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_InvoiceLine object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_InvoiceLine value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_Item_Claims object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_Item_Claims value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_Item_Envelope object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_Item_Envelope value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_Item_EnvelopeContent object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_Item_EnvelopeContent value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_LegalMonetaryTotal object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_LegalMonetaryTotal value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_OrderLineReference object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_OrderLineReference value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_PartyIdentification object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_PartyIdentification value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_PartyLegalEntity_Claims object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_PartyLegalEntity_Claims value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_PartyLegalEntity_Envelope object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_PartyLegalEntity_Envelope value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_PartyLegalEntity_EnvelopeContent object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_PartyLegalEntity_EnvelopeContent value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_PartyName object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_PartyName value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_PartyTaxScheme object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_PartyTaxScheme value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_Party_Claims object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_Party_Claims value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_Party_Envelope object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_Party_Envelope value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_Party_EnvelopeContent object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_Party_EnvelopeContent value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_PayeeFinancialAccount_Claims object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_PayeeFinancialAccount_Claims value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_PayeeFinancialAccount_Envelope object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_PayeeFinancialAccount_Envelope value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_PayeeFinancialAccount_EnvelopeContent object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_PayeeFinancialAccount_EnvelopeContent value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_PayeeParty object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_PayeeParty value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_PaymentMeans_Claims object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_PaymentMeans_Claims value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_PaymentMeans_Envelope object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_PaymentMeans_Envelope value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_PaymentMeans_EnvelopeContent object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_PaymentMeans_EnvelopeContent value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_PaymentTerms object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_PaymentTerms value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_Person_Claims object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_Person_Claims value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_Person_Envelope object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_Person_Envelope value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_Person_EnvelopeContent object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_Person_EnvelopeContent value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_Price object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_Price value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_SellersItemIdentification object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_SellersItemIdentification value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_TaxCategory object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_TaxCategory value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_TaxScheme object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_TaxScheme value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_TaxSubtotal object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_TaxSubtotal value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_TaxTotal object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_TaxTotal value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cbc_Amount object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cbc_Amount value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cbc_EmbeddedDocumentBinaryObject object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cbc_EmbeddedDocumentBinaryObject value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cbc_ListCode object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cbc_ListCode value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cbc_Note object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cbc_Note value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cbc_OrderReference object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cbc_OrderReference value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cbc_Quantity object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cbc_Quantity value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cbc_SchemeCode object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cbc_SchemeCode value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cbc_TimePeriod object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cbc_TimePeriod value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a TDWCreateTDWCredentialRequest object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(TDWCreateTDWCredentialRequest value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a TDWCredentialResponse object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(TDWCredentialResponse value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a TDWProcessCredentialRequest object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(TDWProcessCredentialRequest value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a TRAClaim object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(TRAClaim value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a TRACredential_Envelope object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(TRACredential_Envelope value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a TRACredential_EnvelopeContent object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(TRACredential_EnvelopeContent value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a TRACredential_EnvelopeLabel object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(TRACredential_EnvelopeLabel value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a TRACredential_EnvelopeSeal object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(TRACredential_EnvelopeSeal value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a TRAEncryptedClaims object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(TRAEncryptedClaims value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a TRAGeoLocation_Claims object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(TRAGeoLocation_Claims value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a TRAGeoLocation_Envelope object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(TRAGeoLocation_Envelope value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a TRAGeoLocation_EnvelopeContent object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(TRAGeoLocation_EnvelopeContent value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a TRAKeyValuePair object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(TRAKeyValuePair value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a TRAPostalAddress_Claims object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(TRAPostalAddress_Claims value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a TRAPostalAddress_Envelope object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(TRAPostalAddress_Envelope value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a TRAPostalAddress_EnvelopeContent object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(TRAPostalAddress_EnvelopeContent value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a TRATimestamp_Claims object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(TRATimestamp_Claims value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a TRATimestamp_Envelope object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(TRATimestamp_Envelope value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a TRATimestamp_EnvelopeContent object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(TRATimestamp_EnvelopeContent value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a UBL21_Invoice2_Claims object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(UBL21_Invoice2_Claims value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a UBL21_Invoice2_Envelope object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(UBL21_Invoice2_Envelope value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a UBL21_Invoice2_EnvelopeContent object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(UBL21_Invoice2_EnvelopeContent value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a ISO639_1_LanguageCodes object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(ISO639_1_LanguageCodes value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a TRACredentialType object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(TRACredentialType value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a TRAEncryptionFlag object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(TRAEncryptionFlag value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a TRATrustLevel object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(TRATrustLevel value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a List<List<TRAKeyValuePair>> object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(List<List<TRAKeyValuePair>> value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_Address_Claims? object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_Address_Claims? value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_Attachment? object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_Attachment? value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_Contact_Claims? object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_Contact_Claims? value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_ExternalReference_Claims? object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_ExternalReference_Claims? value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_Item_Claims? object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_Item_Claims? value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_PartyLegalEntity_Claims? object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_PartyLegalEntity_Claims? value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_Party_Claims? object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_Party_Claims? value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_PayeeFinancialAccount_Claims? object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_PayeeFinancialAccount_Claims? value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_PaymentMeans_Claims? object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_PaymentMeans_Claims? value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cac_Person_Claims? object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_Person_Claims? value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Cbc_EmbeddedDocumentBinaryObject? object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cbc_EmbeddedDocumentBinaryObject? value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a TRAEncryptedClaims? object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(TRAEncryptedClaims? value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a TRAGeoLocation_Claims? object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(TRAGeoLocation_Claims? value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a TRAGeoLocation_EnvelopeContent? object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(TRAGeoLocation_EnvelopeContent? value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a TRAPostalAddress_Claims? object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(TRAPostalAddress_Claims? value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a TRAPostalAddress_EnvelopeContent? object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(TRAPostalAddress_EnvelopeContent? value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a TRATimestamp_Claims? object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(TRATimestamp_Claims? value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a UBL21_Invoice2_Claims? object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(UBL21_Invoice2_Claims? value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        /// <summary>
        /// Serializes a TRACredential_Cell object to Json string.
        /// </summary>
        /// <param name="value">The target cell object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(TRACredential_Cell cell)
        {
            s_ensure_string_builder();
            s_stringBuilder.Append('{');
            s_stringBuilder.AppendFormat("\"CellId\":{0}", cell.CellId);
            
            {
                
                    s_stringBuilder.Append(',');
                    s_stringBuilder.Append("\"envelope\":");
                    ToString_impl(cell.envelope, s_stringBuilder, in_json: true);
                    
            }
            
            {
                
                    s_stringBuilder.Append(',');
                    s_stringBuilder.Append("\"envelopeseal\":");
                    ToString_impl(cell.envelopeseal, s_stringBuilder, in_json: true);
                    
            }
            
            s_stringBuilder.Append('}');
            return s_stringBuilder.ToString();
        }
        
        /// <summary>
        /// Serializes a TRATimestamp_Cell object to Json string.
        /// </summary>
        /// <param name="value">The target cell object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(TRATimestamp_Cell cell)
        {
            s_ensure_string_builder();
            s_stringBuilder.Append('{');
            s_stringBuilder.AppendFormat("\"CellId\":{0}", cell.CellId);
            
            {
                
                    s_stringBuilder.Append(',');
                    s_stringBuilder.Append("\"envelope\":");
                    ToString_impl(cell.envelope, s_stringBuilder, in_json: true);
                    
            }
            
            {
                
                    s_stringBuilder.Append(',');
                    s_stringBuilder.Append("\"envelopeseal\":");
                    ToString_impl(cell.envelopeseal, s_stringBuilder, in_json: true);
                    
            }
            
            s_stringBuilder.Append('}');
            return s_stringBuilder.ToString();
        }
        
        /// <summary>
        /// Serializes a TDWGeoLocation_Cell object to Json string.
        /// </summary>
        /// <param name="value">The target cell object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(TDWGeoLocation_Cell cell)
        {
            s_ensure_string_builder();
            s_stringBuilder.Append('{');
            s_stringBuilder.AppendFormat("\"CellId\":{0}", cell.CellId);
            
            {
                
                    s_stringBuilder.Append(',');
                    s_stringBuilder.Append("\"envelope\":");
                    ToString_impl(cell.envelope, s_stringBuilder, in_json: true);
                    
            }
            
            {
                
                    s_stringBuilder.Append(',');
                    s_stringBuilder.Append("\"envelopeseal\":");
                    ToString_impl(cell.envelopeseal, s_stringBuilder, in_json: true);
                    
            }
            
            s_stringBuilder.Append('}');
            return s_stringBuilder.ToString();
        }
        
        /// <summary>
        /// Serializes a TRAPostalAddress_Cell object to Json string.
        /// </summary>
        /// <param name="value">The target cell object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(TRAPostalAddress_Cell cell)
        {
            s_ensure_string_builder();
            s_stringBuilder.Append('{');
            s_stringBuilder.AppendFormat("\"CellId\":{0}", cell.CellId);
            
            {
                
                    s_stringBuilder.Append(',');
                    s_stringBuilder.Append("\"envelope\":");
                    ToString_impl(cell.envelope, s_stringBuilder, in_json: true);
                    
            }
            
            {
                
                    s_stringBuilder.Append(',');
                    s_stringBuilder.Append("\"envelopeseal\":");
                    ToString_impl(cell.envelopeseal, s_stringBuilder, in_json: true);
                    
            }
            
            s_stringBuilder.Append('}');
            return s_stringBuilder.ToString();
        }
        
        /// <summary>
        /// Serializes a Cac_Item_Cell object to Json string.
        /// </summary>
        /// <param name="value">The target cell object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_Item_Cell cell)
        {
            s_ensure_string_builder();
            s_stringBuilder.Append('{');
            s_stringBuilder.AppendFormat("\"CellId\":{0}", cell.CellId);
            
            {
                
                    s_stringBuilder.Append(',');
                    s_stringBuilder.Append("\"envelope\":");
                    ToString_impl(cell.envelope, s_stringBuilder, in_json: true);
                    
            }
            
            {
                
                    s_stringBuilder.Append(',');
                    s_stringBuilder.Append("\"envelopeseal\":");
                    ToString_impl(cell.envelopeseal, s_stringBuilder, in_json: true);
                    
            }
            
            s_stringBuilder.Append('}');
            return s_stringBuilder.ToString();
        }
        
        /// <summary>
        /// Serializes a Cac_ExternalReference_Cell object to Json string.
        /// </summary>
        /// <param name="value">The target cell object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_ExternalReference_Cell cell)
        {
            s_ensure_string_builder();
            s_stringBuilder.Append('{');
            s_stringBuilder.AppendFormat("\"CellId\":{0}", cell.CellId);
            
            {
                
                    s_stringBuilder.Append(',');
                    s_stringBuilder.Append("\"envelope\":");
                    ToString_impl(cell.envelope, s_stringBuilder, in_json: true);
                    
            }
            
            {
                
                    s_stringBuilder.Append(',');
                    s_stringBuilder.Append("\"envelopeseal\":");
                    ToString_impl(cell.envelopeseal, s_stringBuilder, in_json: true);
                    
            }
            
            s_stringBuilder.Append('}');
            return s_stringBuilder.ToString();
        }
        
        /// <summary>
        /// Serializes a Cac_Address_Cell object to Json string.
        /// </summary>
        /// <param name="value">The target cell object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_Address_Cell cell)
        {
            s_ensure_string_builder();
            s_stringBuilder.Append('{');
            s_stringBuilder.AppendFormat("\"CellId\":{0}", cell.CellId);
            
            {
                
                    s_stringBuilder.Append(',');
                    s_stringBuilder.Append("\"envelope\":");
                    ToString_impl(cell.envelope, s_stringBuilder, in_json: true);
                    
            }
            
            {
                
                    s_stringBuilder.Append(',');
                    s_stringBuilder.Append("\"envelopeseal\":");
                    ToString_impl(cell.envelopeseal, s_stringBuilder, in_json: true);
                    
            }
            
            s_stringBuilder.Append('}');
            return s_stringBuilder.ToString();
        }
        
        /// <summary>
        /// Serializes a Cac_PostalAddress_Cell object to Json string.
        /// </summary>
        /// <param name="value">The target cell object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_PostalAddress_Cell cell)
        {
            s_ensure_string_builder();
            s_stringBuilder.Append('{');
            s_stringBuilder.AppendFormat("\"CellId\":{0}", cell.CellId);
            
            {
                
                    s_stringBuilder.Append(',');
                    s_stringBuilder.Append("\"envelope\":");
                    ToString_impl(cell.envelope, s_stringBuilder, in_json: true);
                    
            }
            
            {
                
                    s_stringBuilder.Append(',');
                    s_stringBuilder.Append("\"envelopeseal\":");
                    ToString_impl(cell.envelopeseal, s_stringBuilder, in_json: true);
                    
            }
            
            s_stringBuilder.Append('}');
            return s_stringBuilder.ToString();
        }
        
        /// <summary>
        /// Serializes a Cac_PartyLegalEntity_Cell object to Json string.
        /// </summary>
        /// <param name="value">The target cell object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_PartyLegalEntity_Cell cell)
        {
            s_ensure_string_builder();
            s_stringBuilder.Append('{');
            s_stringBuilder.AppendFormat("\"CellId\":{0}", cell.CellId);
            
            {
                
                    s_stringBuilder.Append(',');
                    s_stringBuilder.Append("\"envelope\":");
                    ToString_impl(cell.envelope, s_stringBuilder, in_json: true);
                    
            }
            
            {
                
                    s_stringBuilder.Append(',');
                    s_stringBuilder.Append("\"envelopeseal\":");
                    ToString_impl(cell.envelopeseal, s_stringBuilder, in_json: true);
                    
            }
            
            s_stringBuilder.Append('}');
            return s_stringBuilder.ToString();
        }
        
        /// <summary>
        /// Serializes a Cac_Contact_Cell object to Json string.
        /// </summary>
        /// <param name="value">The target cell object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_Contact_Cell cell)
        {
            s_ensure_string_builder();
            s_stringBuilder.Append('{');
            s_stringBuilder.AppendFormat("\"CellId\":{0}", cell.CellId);
            
            {
                
                    s_stringBuilder.Append(',');
                    s_stringBuilder.Append("\"envelope\":");
                    ToString_impl(cell.envelope, s_stringBuilder, in_json: true);
                    
            }
            
            {
                
                    s_stringBuilder.Append(',');
                    s_stringBuilder.Append("\"envelopeseal\":");
                    ToString_impl(cell.envelopeseal, s_stringBuilder, in_json: true);
                    
            }
            
            s_stringBuilder.Append('}');
            return s_stringBuilder.ToString();
        }
        
        /// <summary>
        /// Serializes a Cac_Person_Cell object to Json string.
        /// </summary>
        /// <param name="value">The target cell object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_Person_Cell cell)
        {
            s_ensure_string_builder();
            s_stringBuilder.Append('{');
            s_stringBuilder.AppendFormat("\"CellId\":{0}", cell.CellId);
            
            {
                
                    s_stringBuilder.Append(',');
                    s_stringBuilder.Append("\"envelope\":");
                    ToString_impl(cell.envelope, s_stringBuilder, in_json: true);
                    
            }
            
            {
                
                    s_stringBuilder.Append(',');
                    s_stringBuilder.Append("\"envelopeseal\":");
                    ToString_impl(cell.envelopeseal, s_stringBuilder, in_json: true);
                    
            }
            
            s_stringBuilder.Append('}');
            return s_stringBuilder.ToString();
        }
        
        /// <summary>
        /// Serializes a Cac_PaymentMeans_Cell object to Json string.
        /// </summary>
        /// <param name="value">The target cell object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_PaymentMeans_Cell cell)
        {
            s_ensure_string_builder();
            s_stringBuilder.Append('{');
            s_stringBuilder.AppendFormat("\"CellId\":{0}", cell.CellId);
            
            {
                
                    s_stringBuilder.Append(',');
                    s_stringBuilder.Append("\"envelope\":");
                    ToString_impl(cell.envelope, s_stringBuilder, in_json: true);
                    
            }
            
            {
                
                    s_stringBuilder.Append(',');
                    s_stringBuilder.Append("\"envelopeseal\":");
                    ToString_impl(cell.envelopeseal, s_stringBuilder, in_json: true);
                    
            }
            
            s_stringBuilder.Append('}');
            return s_stringBuilder.ToString();
        }
        
        /// <summary>
        /// Serializes a Cac_PayeeFinancialAccount_Cell object to Json string.
        /// </summary>
        /// <param name="value">The target cell object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_PayeeFinancialAccount_Cell cell)
        {
            s_ensure_string_builder();
            s_stringBuilder.Append('{');
            s_stringBuilder.AppendFormat("\"CellId\":{0}", cell.CellId);
            
            {
                
                    s_stringBuilder.Append(',');
                    s_stringBuilder.Append("\"envelope\":");
                    ToString_impl(cell.envelope, s_stringBuilder, in_json: true);
                    
            }
            
            {
                
                    s_stringBuilder.Append(',');
                    s_stringBuilder.Append("\"envelopeseal\":");
                    ToString_impl(cell.envelopeseal, s_stringBuilder, in_json: true);
                    
            }
            
            s_stringBuilder.Append('}');
            return s_stringBuilder.ToString();
        }
        
        /// <summary>
        /// Serializes a Cac_Party_Cell object to Json string.
        /// </summary>
        /// <param name="value">The target cell object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Cac_Party_Cell cell)
        {
            s_ensure_string_builder();
            s_stringBuilder.Append('{');
            s_stringBuilder.AppendFormat("\"CellId\":{0}", cell.CellId);
            
            {
                
                    s_stringBuilder.Append(',');
                    s_stringBuilder.Append("\"envelope\":");
                    ToString_impl(cell.envelope, s_stringBuilder, in_json: true);
                    
            }
            
            {
                
                    s_stringBuilder.Append(',');
                    s_stringBuilder.Append("\"envelopeseal\":");
                    ToString_impl(cell.envelopeseal, s_stringBuilder, in_json: true);
                    
            }
            
            s_stringBuilder.Append('}');
            return s_stringBuilder.ToString();
        }
        
        /// <summary>
        /// Serializes a UBL21_Invoice2_Cell object to Json string.
        /// </summary>
        /// <param name="value">The target cell object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(UBL21_Invoice2_Cell cell)
        {
            s_ensure_string_builder();
            s_stringBuilder.Append('{');
            s_stringBuilder.AppendFormat("\"CellId\":{0}", cell.CellId);
            
            {
                
                    s_stringBuilder.Append(',');
                    s_stringBuilder.Append("\"envelope\":");
                    ToString_impl(cell.envelope, s_stringBuilder, in_json: true);
                    
            }
            
            {
                
                    s_stringBuilder.Append(',');
                    s_stringBuilder.Append("\"envelopeseal\":");
                    ToString_impl(cell.envelopeseal, s_stringBuilder, in_json: true);
                    
            }
            
            s_stringBuilder.Append('}');
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(bool value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                {
                    str_builder.Append(value.ToString().ToLowerInvariant());
                }
                
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(long value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                {
                    str_builder.Append(value);
                }
                
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(double value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                {
                    str_builder.Append(value);
                }
                
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(DateTime value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                if(in_json)
                    str_builder.Append('"');
                
                {
                    
                    {
                        str_builder.Append(value.ToString("o", CultureInfo.InvariantCulture));
                    }
                    
                }
                
                if(in_json)
                    str_builder.Append('"');
                
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(string value, StringBuilder str_builder, bool in_json)
        {
            
            if (in_json)
            {
                str_builder.Append(JsonStringProcessor.escape(value));
            }
            else
            {
                str_builder.Append(value);
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(List<string> value, StringBuilder str_builder, bool in_json)
        {
            
            {
                str_builder.Append('[');
                bool first = true;
                foreach (var element in value)
                {
                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        str_builder.Append(',');
                    }
                    ToString_impl(element, str_builder, in_json:true);
                }
                str_builder.Append(']');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(List<Cac_AllowanceCharge> value, StringBuilder str_builder, bool in_json)
        {
            
            {
                str_builder.Append('[');
                bool first = true;
                foreach (var element in value)
                {
                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        str_builder.Append(',');
                    }
                    ToString_impl(element, str_builder, in_json:true);
                }
                str_builder.Append(']');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(List<Cac_DocumentReference> value, StringBuilder str_builder, bool in_json)
        {
            
            {
                str_builder.Append('[');
                bool first = true;
                foreach (var element in value)
                {
                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        str_builder.Append(',');
                    }
                    ToString_impl(element, str_builder, in_json:true);
                }
                str_builder.Append(']');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(List<Cac_InvoiceLine> value, StringBuilder str_builder, bool in_json)
        {
            
            {
                str_builder.Append('[');
                bool first = true;
                foreach (var element in value)
                {
                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        str_builder.Append(',');
                    }
                    ToString_impl(element, str_builder, in_json:true);
                }
                str_builder.Append(']');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(List<Cac_TaxSubtotal> value, StringBuilder str_builder, bool in_json)
        {
            
            {
                str_builder.Append('[');
                bool first = true;
                foreach (var element in value)
                {
                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        str_builder.Append(',');
                    }
                    ToString_impl(element, str_builder, in_json:true);
                }
                str_builder.Append(']');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(List<Cbc_ListCode> value, StringBuilder str_builder, bool in_json)
        {
            
            {
                str_builder.Append('[');
                bool first = true;
                foreach (var element in value)
                {
                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        str_builder.Append(',');
                    }
                    ToString_impl(element, str_builder, in_json:true);
                }
                str_builder.Append(']');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(List<TRAClaim> value, StringBuilder str_builder, bool in_json)
        {
            
            {
                str_builder.Append('[');
                bool first = true;
                foreach (var element in value)
                {
                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        str_builder.Append(',');
                    }
                    ToString_impl(element, str_builder, in_json:true);
                }
                str_builder.Append(']');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(List<TRAKeyValuePair> value, StringBuilder str_builder, bool in_json)
        {
            
            {
                str_builder.Append('[');
                bool first = true;
                foreach (var element in value)
                {
                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        str_builder.Append(',');
                    }
                    ToString_impl(element, str_builder, in_json:true);
                }
                str_builder.Append(']');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_AccountingCustomerParty value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.cac_PartyUdid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_PartyUdid\":");
                        
                        ToString_impl(value.cac_PartyUdid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_AccountingSupplierParty value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.cac_PartyUdid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_PartyUdid\":");
                        
                        ToString_impl(value.cac_PartyUdid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_Address_Claims value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.cbc_ID != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_ID\":");
                        
                        ToString_impl(value.cbc_ID, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.cbc_PostBox != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_PostBox\":");
                        
                        ToString_impl(value.cbc_PostBox, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.cbc_StreetName != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_StreetName\":");
                        
                        ToString_impl(value.cbc_StreetName, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.cbc_AdditionalStreetName != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_AdditionalStreetName\":");
                        
                        ToString_impl(value.cbc_AdditionalStreetName, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.cbc_BuildingNumber != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_BuildingNumber\":");
                        
                        ToString_impl(value.cbc_BuildingNumber, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.cbc_Department != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_Department\":");
                        
                        ToString_impl(value.cbc_Department, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.cbc_CityName != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_CityName\":");
                        
                        ToString_impl(value.cbc_CityName, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.cbc_CountrySubentityCode != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_CountrySubentityCode\":");
                        
                        ToString_impl(value.cbc_CountrySubentityCode, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_Country\":");
                        
                        ToString_impl(value.cbc_Country, str_builder, in_json: true);
                        
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_Address_Envelope value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"content\":");
                        
                        ToString_impl(value.content, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"label\":");
                        
                        ToString_impl(value.label, str_builder, in_json: true);
                        
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_Address_EnvelopeContent value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.udid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"udid\":");
                        
                        ToString_impl(value.udid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.context != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"context\":");
                        
                        ToString_impl(value.context, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.credentialsubjectudid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"credentialsubjectudid\":");
                        
                        ToString_impl(value.credentialsubjectudid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.claims != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"claims\":");
                        
                        ToString_impl(value.claims, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.encryptedclaims != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"encryptedclaims\":");
                        
                        ToString_impl(value.encryptedclaims, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_AllowanceCharge value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_ChargeIndicator\":");
                        
                        ToString_impl(value.cbc_ChargeIndicator, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.cbc_AllowanceChargeReason != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_AllowanceChargeReason\":");
                        
                        ToString_impl(value.cbc_AllowanceChargeReason, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_Amount\":");
                        
                        ToString_impl(value.cbc_Amount, str_builder, in_json: true);
                        
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_Attachment value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.cac_ExternalReferenceUdid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_ExternalReferenceUdid\":");
                        
                        ToString_impl(value.cac_ExternalReferenceUdid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_ClassifiedTaxCategory value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_ID\":");
                        
                        ToString_impl(value.cbc_ID, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_Percent\":");
                        
                        ToString_impl(value.cbc_Percent, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_TaxScheme\":");
                        
                        ToString_impl(value.cac_TaxScheme, str_builder, in_json: true);
                        
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_Contact_Claims value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.cbc_Telephone != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_Telephone\":");
                        
                        ToString_impl(value.cbc_Telephone, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.cbc_Telefax != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_Telefax\":");
                        
                        ToString_impl(value.cbc_Telefax, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.cbc_ElectronicMail != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_ElectronicMail\":");
                        
                        ToString_impl(value.cbc_ElectronicMail, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_Contact_Envelope value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"content\":");
                        
                        ToString_impl(value.content, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"label\":");
                        
                        ToString_impl(value.label, str_builder, in_json: true);
                        
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_Contact_EnvelopeContent value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.udid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"udid\":");
                        
                        ToString_impl(value.udid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.context != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"context\":");
                        
                        ToString_impl(value.context, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.credentialsubjectudid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"credentialsubjectudid\":");
                        
                        ToString_impl(value.credentialsubjectudid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.claims != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"claims\":");
                        
                        ToString_impl(value.claims, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.encryptedclaims != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"encryptedclaims\":");
                        
                        ToString_impl(value.encryptedclaims, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_Country value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_IdentificationCode\":");
                        
                        ToString_impl(value.cbc_IdentificationCode, str_builder, in_json: true);
                        
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_Delivery value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_ActualDeliveryDate\":");
                        
                        ToString_impl(value.cbc_ActualDeliveryDate, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_DeliveryLocation\":");
                        
                        ToString_impl(value.cac_DeliveryLocation, str_builder, in_json: true);
                        
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_DeliveryLocation value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_ID\":");
                        
                        ToString_impl(value.cbc_ID, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.cac_AddressUdid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_AddressUdid\":");
                        
                        ToString_impl(value.cac_AddressUdid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_DocumentReference value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.ID != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"ID\":");
                        
                        ToString_impl(value.ID, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.DocumentType != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"DocumentType\":");
                        
                        ToString_impl(value.DocumentType, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.cac_Attachment != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_Attachment\":");
                        
                        ToString_impl(value.cac_Attachment, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_ExternalReference_Claims value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.cbc_URI != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_URI\":");
                        
                        ToString_impl(value.cbc_URI, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.cbc_EmbeddedDocumentBinaryObject != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_EmbeddedDocumentBinaryObject\":");
                        
                        ToString_impl(value.cbc_EmbeddedDocumentBinaryObject, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_ExternalReference_Envelope value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"content\":");
                        
                        ToString_impl(value.content, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"label\":");
                        
                        ToString_impl(value.label, str_builder, in_json: true);
                        
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_ExternalReference_EnvelopeContent value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.udid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"udid\":");
                        
                        ToString_impl(value.udid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.context != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"context\":");
                        
                        ToString_impl(value.context, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.credentialsubjectudid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"credentialsubjectudid\":");
                        
                        ToString_impl(value.credentialsubjectudid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.claims != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"claims\":");
                        
                        ToString_impl(value.claims, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.encryptedclaims != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"encryptedclaims\":");
                        
                        ToString_impl(value.encryptedclaims, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_FinancialInstitution value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.cbc_ID != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_ID\":");
                        
                        ToString_impl(value.cbc_ID, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_FinancialInstitutionBranch value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_FinancialInstitution\":");
                        
                        ToString_impl(value.cac_FinancialInstitution, str_builder, in_json: true);
                        
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_InvoiceLine value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.cbc_ID != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_ID\":");
                        
                        ToString_impl(value.cbc_ID, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_Note\":");
                        
                        ToString_impl(value.cbc_Note, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_InvoicedQuantity\":");
                        
                        ToString_impl(value.cbc_InvoicedQuantity, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_LineExtensionAmount\":");
                        
                        ToString_impl(value.cbc_LineExtensionAmount, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.cbc_AccountingCost != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_AccountingCost\":");
                        
                        ToString_impl(value.cbc_AccountingCost, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_OrderLineReference\":");
                        
                        ToString_impl(value.cac_OrderLineReference, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.cac_AllowanceCharges != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_AllowanceCharges\":");
                        
                        ToString_impl(value.cac_AllowanceCharges, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_TaxTotal\":");
                        
                        ToString_impl(value.cac_TaxTotal, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.cac_ItemUdid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_ItemUdid\":");
                        
                        ToString_impl(value.cac_ItemUdid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_Price\":");
                        
                        ToString_impl(value.cac_Price, str_builder, in_json: true);
                        
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_Item_Claims value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.cbc_Name != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_Name\":");
                        
                        ToString_impl(value.cbc_Name, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_SellersItemIdentification\":");
                        
                        ToString_impl(value.cac_SellersItemIdentification, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_StandardItemIdentification\":");
                        
                        ToString_impl(value.cac_StandardItemIdentification, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.cac_CommodityClassification != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_CommodityClassification\":");
                        
                        ToString_impl(value.cac_CommodityClassification, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_ClassifiedTaxCategory\":");
                        
                        ToString_impl(value.cac_ClassifiedTaxCategory, str_builder, in_json: true);
                        
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_Item_Envelope value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"content\":");
                        
                        ToString_impl(value.content, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"label\":");
                        
                        ToString_impl(value.label, str_builder, in_json: true);
                        
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_Item_EnvelopeContent value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.udid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"udid\":");
                        
                        ToString_impl(value.udid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.context != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"context\":");
                        
                        ToString_impl(value.context, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.credentialsubjectudid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"credentialsubjectudid\":");
                        
                        ToString_impl(value.credentialsubjectudid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.claims != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"claims\":");
                        
                        ToString_impl(value.claims, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.encryptedclaims != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"encryptedclaims\":");
                        
                        ToString_impl(value.encryptedclaims, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_LegalMonetaryTotal value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_LineExtensionAmount\":");
                        
                        ToString_impl(value.cbc_LineExtensionAmount, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_TaxExclusiveAmount\":");
                        
                        ToString_impl(value.cbc_TaxExclusiveAmount, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_TaxInclusiveAmount\":");
                        
                        ToString_impl(value.cbc_TaxInclusiveAmount, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_AllowanceTotalAmount\":");
                        
                        ToString_impl(value.cbc_AllowanceTotalAmount, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_ChargeTotalAmount\":");
                        
                        ToString_impl(value.cbc_ChargeTotalAmount, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_PrepaidAmount\":");
                        
                        ToString_impl(value.cbc_PrepaidAmount, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_PayableRoundingAmount\":");
                        
                        ToString_impl(value.cbc_PayableRoundingAmount, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_PayableAmount\":");
                        
                        ToString_impl(value.cbc_PayableAmount, str_builder, in_json: true);
                        
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_OrderLineReference value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.cbc_LineID != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_LineID\":");
                        
                        ToString_impl(value.cbc_LineID, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_PartyIdentification value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_ID\":");
                        
                        ToString_impl(value.cbc_ID, str_builder, in_json: true);
                        
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_PartyLegalEntity_Claims value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.cbc_RegistrationName != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_RegistrationName\":");
                        
                        ToString_impl(value.cbc_RegistrationName, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_CompanyID\":");
                        
                        ToString_impl(value.cbc_CompanyID, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.cbc_RegistrationAddressUdid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_RegistrationAddressUdid\":");
                        
                        ToString_impl(value.cbc_RegistrationAddressUdid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_PartyLegalEntity_Envelope value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"content\":");
                        
                        ToString_impl(value.content, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"label\":");
                        
                        ToString_impl(value.label, str_builder, in_json: true);
                        
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_PartyLegalEntity_EnvelopeContent value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.udid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"udid\":");
                        
                        ToString_impl(value.udid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.context != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"context\":");
                        
                        ToString_impl(value.context, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.credentialsubjectudid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"credentialsubjectudid\":");
                        
                        ToString_impl(value.credentialsubjectudid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.claims != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"claims\":");
                        
                        ToString_impl(value.claims, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.encryptedclaims != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"encryptedclaims\":");
                        
                        ToString_impl(value.encryptedclaims, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_PartyName value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.cbc_Name != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_Name\":");
                        
                        ToString_impl(value.cbc_Name, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_PartyTaxScheme value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_CompanyID\":");
                        
                        ToString_impl(value.cbc_CompanyID, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_TaxScheme\":");
                        
                        ToString_impl(value.cac_TaxScheme, str_builder, in_json: true);
                        
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_Party_Claims value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_EndpointID\":");
                        
                        ToString_impl(value.cbc_EndpointID, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_PartyIdentification\":");
                        
                        ToString_impl(value.cbc_PartyIdentification, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_PartyName\":");
                        
                        ToString_impl(value.cbc_PartyName, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.cac_PostalAddressUdid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_PostalAddressUdid\":");
                        
                        ToString_impl(value.cac_PostalAddressUdid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_PartyTaxScheme\":");
                        
                        ToString_impl(value.cbc_PartyTaxScheme, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.cac_PartyLegalEntityUdid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_PartyLegalEntityUdid\":");
                        
                        ToString_impl(value.cac_PartyLegalEntityUdid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.cac_ContactUdid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_ContactUdid\":");
                        
                        ToString_impl(value.cac_ContactUdid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.cac_PersonUdid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_PersonUdid\":");
                        
                        ToString_impl(value.cac_PersonUdid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_Party_Envelope value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"content\":");
                        
                        ToString_impl(value.content, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"label\":");
                        
                        ToString_impl(value.label, str_builder, in_json: true);
                        
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_Party_EnvelopeContent value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.udid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"udid\":");
                        
                        ToString_impl(value.udid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.context != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"context\":");
                        
                        ToString_impl(value.context, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.credentialsubjectudid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"credentialsubjectudid\":");
                        
                        ToString_impl(value.credentialsubjectudid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.claims != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"claims\":");
                        
                        ToString_impl(value.claims, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.encryptedclaims != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"encryptedclaims\":");
                        
                        ToString_impl(value.encryptedclaims, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_PayeeFinancialAccount_Claims value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.cbc_ID != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_ID\":");
                        
                        ToString_impl(value.cbc_ID, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_FinancialInstitutionBranch\":");
                        
                        ToString_impl(value.cac_FinancialInstitutionBranch, str_builder, in_json: true);
                        
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_PayeeFinancialAccount_Envelope value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"content\":");
                        
                        ToString_impl(value.content, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"label\":");
                        
                        ToString_impl(value.label, str_builder, in_json: true);
                        
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_PayeeFinancialAccount_EnvelopeContent value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.udid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"udid\":");
                        
                        ToString_impl(value.udid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.context != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"context\":");
                        
                        ToString_impl(value.context, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.credentialsubjectudid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"credentialsubjectudid\":");
                        
                        ToString_impl(value.credentialsubjectudid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.claims != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"claims\":");
                        
                        ToString_impl(value.claims, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.encryptedclaims != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"encryptedclaims\":");
                        
                        ToString_impl(value.encryptedclaims, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_PayeeParty value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.cac_PartyUdid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_PartyUdid\":");
                        
                        ToString_impl(value.cac_PartyUdid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_PaymentMeans_Claims value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_PaymentMeansCode\":");
                        
                        ToString_impl(value.cbc_PaymentMeansCode, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_PaymentDueDate\":");
                        
                        ToString_impl(value.cbc_PaymentDueDate, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.cbc_PaymentChannel != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_PaymentChannel\":");
                        
                        ToString_impl(value.cbc_PaymentChannel, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.cbc_PaymentID != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_PaymentID\":");
                        
                        ToString_impl(value.cbc_PaymentID, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.cac_PayeeFinancialAccountUdid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_PayeeFinancialAccountUdid\":");
                        
                        ToString_impl(value.cac_PayeeFinancialAccountUdid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_PaymentMeans_Envelope value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"content\":");
                        
                        ToString_impl(value.content, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"label\":");
                        
                        ToString_impl(value.label, str_builder, in_json: true);
                        
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_PaymentMeans_EnvelopeContent value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.udid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"udid\":");
                        
                        ToString_impl(value.udid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.context != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"context\":");
                        
                        ToString_impl(value.context, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.credentialsubjectudid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"credentialsubjectudid\":");
                        
                        ToString_impl(value.credentialsubjectudid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.claims != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"claims\":");
                        
                        ToString_impl(value.claims, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.encryptedclaims != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"encryptedclaims\":");
                        
                        ToString_impl(value.encryptedclaims, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_PaymentTerms value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_Note\":");
                        
                        ToString_impl(value.cbc_Note, str_builder, in_json: true);
                        
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_Person_Claims value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.cbc_FirstName != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_FirstName\":");
                        
                        ToString_impl(value.cbc_FirstName, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.cbc_MiddleName != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_MiddleName\":");
                        
                        ToString_impl(value.cbc_MiddleName, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.cbc_FamilyName != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_FamilyName\":");
                        
                        ToString_impl(value.cbc_FamilyName, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.cbc_JobTitle != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_JobTitle\":");
                        
                        ToString_impl(value.cbc_JobTitle, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_Person_Envelope value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"content\":");
                        
                        ToString_impl(value.content, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"label\":");
                        
                        ToString_impl(value.label, str_builder, in_json: true);
                        
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_Person_EnvelopeContent value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.udid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"udid\":");
                        
                        ToString_impl(value.udid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.context != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"context\":");
                        
                        ToString_impl(value.context, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.credentialsubjectudid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"credentialsubjectudid\":");
                        
                        ToString_impl(value.credentialsubjectudid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.claims != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"claims\":");
                        
                        ToString_impl(value.claims, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.encryptedclaims != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"encryptedclaims\":");
                        
                        ToString_impl(value.encryptedclaims, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_Price value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_PriceAmount\":");
                        
                        ToString_impl(value.cbc_PriceAmount, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_BaseQuantity\":");
                        
                        ToString_impl(value.cbc_BaseQuantity, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_AllowanceCharge\":");
                        
                        ToString_impl(value.cac_AllowanceCharge, str_builder, in_json: true);
                        
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_SellersItemIdentification value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.cbc_ID != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_ID\":");
                        
                        ToString_impl(value.cbc_ID, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_TaxCategory value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_ID\":");
                        
                        ToString_impl(value.cbc_ID, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_Percent\":");
                        
                        ToString_impl(value.cbc_Percent, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_TaxScheme\":");
                        
                        ToString_impl(value.cac_TaxScheme, str_builder, in_json: true);
                        
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_TaxScheme value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_ID\":");
                        
                        ToString_impl(value.cbc_ID, str_builder, in_json: true);
                        
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_TaxSubtotal value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_TaxableAmount\":");
                        
                        ToString_impl(value.cbc_TaxableAmount, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_TaxAmount\":");
                        
                        ToString_impl(value.cbc_TaxAmount, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_TaxCategory\":");
                        
                        ToString_impl(value.cac_TaxCategory, str_builder, in_json: true);
                        
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_TaxTotal value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_TaxAmount\":");
                        
                        ToString_impl(value.cbc_TaxAmount, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.cac_TaxSubtotals != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_TaxSubtotals\":");
                        
                        ToString_impl(value.cac_TaxSubtotals, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cbc_Amount value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value._CurrencyID != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"_CurrencyID\":");
                        
                        ToString_impl(value._CurrencyID, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"amount\":");
                        
                        ToString_impl(value.amount, str_builder, in_json: true);
                        
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cbc_EmbeddedDocumentBinaryObject value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value._mimeCode != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"_mimeCode\":");
                        
                        ToString_impl(value._mimeCode, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.binary16 != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"binary16\":");
                        
                        ToString_impl(value.binary16, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cbc_ListCode value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value._listID != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"_listID\":");
                        
                        ToString_impl(value._listID, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value._listAgencyID != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"_listAgencyID\":");
                        
                        ToString_impl(value._listAgencyID, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.code != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"code\":");
                        
                        ToString_impl(value.code, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cbc_Note value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"_languageID\":");
                        
                        ToString_impl(value._languageID, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.note != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"note\":");
                        
                        ToString_impl(value.note, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cbc_OrderReference value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.cbc_ID != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_ID\":");
                        
                        ToString_impl(value.cbc_ID, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cbc_Quantity value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value._unitCode != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"_unitCode\":");
                        
                        ToString_impl(value._unitCode, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"quantity\":");
                        
                        ToString_impl(value.quantity, str_builder, in_json: true);
                        
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cbc_SchemeCode value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value._schemeID != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"_schemeID\":");
                        
                        ToString_impl(value._schemeID, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value._schemeAgencyID != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"_schemeAgencyID\":");
                        
                        ToString_impl(value._schemeAgencyID, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.code != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"code\":");
                        
                        ToString_impl(value.code, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cbc_TimePeriod value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_StartDate\":");
                        
                        ToString_impl(value.cbc_StartDate, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_EndDate\":");
                        
                        ToString_impl(value.cbc_EndDate, str_builder, in_json: true);
                        
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(TDWCreateTDWCredentialRequest value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"credtype\":");
                        
                        ToString_impl(value.credtype, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.context != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"context\":");
                        
                        ToString_impl(value.context, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.credentialsubjectudid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"credentialsubjectudid\":");
                        
                        ToString_impl(value.credentialsubjectudid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.claims != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"claims\":");
                        
                        ToString_impl(value.claims, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"trustlevel\":");
                        
                        ToString_impl(value.trustlevel, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"encryptionFlag\":");
                        
                        ToString_impl(value.encryptionFlag, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.comments != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"comments\":");
                        
                        ToString_impl(value.comments, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.keypairsalt != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"keypairsalt\":");
                        
                        ToString_impl(value.keypairsalt, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.mvcaudid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"mvcaudid\":");
                        
                        ToString_impl(value.mvcaudid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(TDWCredentialResponse value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"id\":");
                        
                        ToString_impl(value.id, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.udid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"udid\":");
                        
                        ToString_impl(value.udid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"rc\":");
                        
                        ToString_impl(value.rc, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.messages != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"messages\":");
                        
                        ToString_impl(value.messages, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(TDWProcessCredentialRequest value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"id\":");
                        
                        ToString_impl(value.id, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.mvcaudid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"mvcaudid\":");
                        
                        ToString_impl(value.mvcaudid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(TRAClaim value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.key != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"key\":");
                        
                        ToString_impl(value.key, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.value != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"value\":");
                        
                        ToString_impl(value.value, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.attribute != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"attribute\":");
                        
                        ToString_impl(value.attribute, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.attributes != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"attributes\":");
                        
                        ToString_impl(value.attributes, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(TRACredential_Envelope value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"content\":");
                        
                        ToString_impl(value.content, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"label\":");
                        
                        ToString_impl(value.label, str_builder, in_json: true);
                        
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(TRACredential_EnvelopeContent value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.udid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"udid\":");
                        
                        ToString_impl(value.udid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.context != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"context\":");
                        
                        ToString_impl(value.context, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.credentialsubjectudid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"credentialsubjectudid\":");
                        
                        ToString_impl(value.credentialsubjectudid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.claims != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"claims\":");
                        
                        ToString_impl(value.claims, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.encryptedclaims != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"encryptedclaims\":");
                        
                        ToString_impl(value.encryptedclaims, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(TRACredential_EnvelopeLabel value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"credtype\":");
                        
                        ToString_impl(value.credtype, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"version\":");
                        
                        ToString_impl(value.version, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"trustLevel\":");
                        
                        ToString_impl(value.trustLevel, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"encryptionFlag\":");
                        
                        ToString_impl(value.encryptionFlag, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.notaryudid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"notaryudid\":");
                        
                        ToString_impl(value.notaryudid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.name != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"name\":");
                        
                        ToString_impl(value.name, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.comment != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"comment\":");
                        
                        ToString_impl(value.comment, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(TRACredential_EnvelopeSeal value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.hashedThumbprint64 != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"hashedThumbprint64\":");
                        
                        ToString_impl(value.hashedThumbprint64, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.signedHashSignature64 != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"signedHashSignature64\":");
                        
                        ToString_impl(value.signedHashSignature64, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.notaryStamp != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"notaryStamp\":");
                        
                        ToString_impl(value.notaryStamp, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.comments != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"comments\":");
                        
                        ToString_impl(value.comments, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(TRAEncryptedClaims value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.ciphertext16 != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"ciphertext16\":");
                        
                        ToString_impl(value.ciphertext16, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.alg != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"alg\":");
                        
                        ToString_impl(value.alg, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.key != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"key\":");
                        
                        ToString_impl(value.key, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(TRAGeoLocation_Claims value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"latitude\":");
                        
                        ToString_impl(value.latitude, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"longitude\":");
                        
                        ToString_impl(value.longitude, str_builder, in_json: true);
                        
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(TRAGeoLocation_Envelope value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.content != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"content\":");
                        
                        ToString_impl(value.content, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"label\":");
                        
                        ToString_impl(value.label, str_builder, in_json: true);
                        
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(TRAGeoLocation_EnvelopeContent value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.udid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"udid\":");
                        
                        ToString_impl(value.udid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.context != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"context\":");
                        
                        ToString_impl(value.context, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.credentialsubjectudid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"credentialsubjectudid\":");
                        
                        ToString_impl(value.credentialsubjectudid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.claims != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"claims\":");
                        
                        ToString_impl(value.claims, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.encryptedclaims != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"encryptedclaims\":");
                        
                        ToString_impl(value.encryptedclaims, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(TRAKeyValuePair value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.key != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"key\":");
                        
                        ToString_impl(value.key, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.value != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"value\":");
                        
                        ToString_impl(value.value, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(TRAPostalAddress_Claims value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.streetAddress != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"streetAddress\":");
                        
                        ToString_impl(value.streetAddress, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.postOfficeBoxNumber != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"postOfficeBoxNumber\":");
                        
                        ToString_impl(value.postOfficeBoxNumber, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.addressLocality != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"addressLocality\":");
                        
                        ToString_impl(value.addressLocality, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.addressRegion != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"addressRegion\":");
                        
                        ToString_impl(value.addressRegion, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.addressCountry != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"addressCountry\":");
                        
                        ToString_impl(value.addressCountry, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.postalCode != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"postalCode\":");
                        
                        ToString_impl(value.postalCode, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(TRAPostalAddress_Envelope value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.content != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"content\":");
                        
                        ToString_impl(value.content, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"label\":");
                        
                        ToString_impl(value.label, str_builder, in_json: true);
                        
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(TRAPostalAddress_EnvelopeContent value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.udid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"udid\":");
                        
                        ToString_impl(value.udid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.context != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"context\":");
                        
                        ToString_impl(value.context, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.credentialsubjectudid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"credentialsubjectudid\":");
                        
                        ToString_impl(value.credentialsubjectudid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.claims != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"claims\":");
                        
                        ToString_impl(value.claims, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.encryptedclaims != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"encryptedclaims\":");
                        
                        ToString_impl(value.encryptedclaims, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(TRATimestamp_Claims value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"ticks\":");
                        
                        ToString_impl(value.ticks, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"datetime\":");
                        
                        ToString_impl(value.datetime, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.timestamp != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"timestamp\":");
                        
                        ToString_impl(value.timestamp, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(TRATimestamp_Envelope value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"content\":");
                        
                        ToString_impl(value.content, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"label\":");
                        
                        ToString_impl(value.label, str_builder, in_json: true);
                        
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(TRATimestamp_EnvelopeContent value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.udid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"udid\":");
                        
                        ToString_impl(value.udid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.context != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"context\":");
                        
                        ToString_impl(value.context, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.credentialsubjectudid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"credentialsubjectudid\":");
                        
                        ToString_impl(value.credentialsubjectudid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.claims != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"claims\":");
                        
                        ToString_impl(value.claims, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.encryptedclaims != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"encryptedclaims\":");
                        
                        ToString_impl(value.encryptedclaims, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(UBL21_Invoice2_Claims value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.cbc_UBLVersionID != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_UBLVersionID\":");
                        
                        ToString_impl(value.cbc_UBLVersionID, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.cbc_ID != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_ID\":");
                        
                        ToString_impl(value.cbc_ID, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_IssueDate\":");
                        
                        ToString_impl(value.cbc_IssueDate, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_InvoiceTypeCode\":");
                        
                        ToString_impl(value.cbc_InvoiceTypeCode, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_Note\":");
                        
                        ToString_impl(value.cbc_Note, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_TaxPointDate\":");
                        
                        ToString_impl(value.cbc_TaxPointDate, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_DocumentCurrencyCode\":");
                        
                        ToString_impl(value.cbc_DocumentCurrencyCode, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.cbc_AccountingCost != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_AccountingCost\":");
                        
                        ToString_impl(value.cbc_AccountingCost, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_InvoicePeriod\":");
                        
                        ToString_impl(value.cbc_InvoicePeriod, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_OrderReference\":");
                        
                        ToString_impl(value.cbc_OrderReference, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_ContractDocumentReference\":");
                        
                        ToString_impl(value.cac_ContractDocumentReference, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.cac_AdditionalDocumentReferences != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_AdditionalDocumentReferences\":");
                        
                        ToString_impl(value.cac_AdditionalDocumentReferences, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_AccountingSupplierParty\":");
                        
                        ToString_impl(value.cac_AccountingSupplierParty, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_AccountingCustomerParty\":");
                        
                        ToString_impl(value.cac_AccountingCustomerParty, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_PayeeParty\":");
                        
                        ToString_impl(value.cac_PayeeParty, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_Delivery\":");
                        
                        ToString_impl(value.cac_Delivery, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.cac_PaymentMeansUdid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_PaymentMeansUdid\":");
                        
                        ToString_impl(value.cac_PaymentMeansUdid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_PaymentTerms\":");
                        
                        ToString_impl(value.cac_PaymentTerms, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.cac_AllowanceCharges != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_AllowanceCharges\":");
                        
                        ToString_impl(value.cac_AllowanceCharges, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_TaxTotal\":");
                        
                        ToString_impl(value.cac_TaxTotal, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_LegalMonetaryTotal\":");
                        
                        ToString_impl(value.cac_LegalMonetaryTotal, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.cac_InvoiceLine != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_InvoiceLine\":");
                        
                        ToString_impl(value.cac_InvoiceLine, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(UBL21_Invoice2_Envelope value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"content\":");
                        
                        ToString_impl(value.content, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"label\":");
                        
                        ToString_impl(value.label, str_builder, in_json: true);
                        
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(UBL21_Invoice2_EnvelopeContent value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.udid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"udid\":");
                        
                        ToString_impl(value.udid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.context != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"context\":");
                        
                        ToString_impl(value.context, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.credentialsubjectudid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"credentialsubjectudid\":");
                        
                        ToString_impl(value.credentialsubjectudid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.claims != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"claims\":");
                        
                        ToString_impl(value.claims, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.encryptedclaims != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"encryptedclaims\":");
                        
                        ToString_impl(value.encryptedclaims, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(ISO639_1_LanguageCodes value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                if(in_json)
                    str_builder.Append('"');
                
                {
                    str_builder.Append(value);
                }
                
                if(in_json)
                    str_builder.Append('"');
                
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(TRACredentialType value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                if(in_json)
                    str_builder.Append('"');
                
                {
                    str_builder.Append(value);
                }
                
                if(in_json)
                    str_builder.Append('"');
                
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(TRAEncryptionFlag value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                if(in_json)
                    str_builder.Append('"');
                
                {
                    str_builder.Append(value);
                }
                
                if(in_json)
                    str_builder.Append('"');
                
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(TRATrustLevel value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                if(in_json)
                    str_builder.Append('"');
                
                {
                    str_builder.Append(value);
                }
                
                if(in_json)
                    str_builder.Append('"');
                
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(List<List<TRAKeyValuePair>> value, StringBuilder str_builder, bool in_json)
        {
            
            {
                str_builder.Append('[');
                bool first = true;
                foreach (var element in value)
                {
                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        str_builder.Append(',');
                    }
                    ToString_impl(element, str_builder, in_json:true);
                }
                str_builder.Append(']');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_Address_Claims? value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                if (value == null)
                    return;
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.Value.cbc_ID != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_ID\":");
                        
                        ToString_impl(value.Value.cbc_ID, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.Value.cbc_PostBox != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_PostBox\":");
                        
                        ToString_impl(value.Value.cbc_PostBox, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.Value.cbc_StreetName != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_StreetName\":");
                        
                        ToString_impl(value.Value.cbc_StreetName, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.Value.cbc_AdditionalStreetName != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_AdditionalStreetName\":");
                        
                        ToString_impl(value.Value.cbc_AdditionalStreetName, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.Value.cbc_BuildingNumber != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_BuildingNumber\":");
                        
                        ToString_impl(value.Value.cbc_BuildingNumber, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.Value.cbc_Department != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_Department\":");
                        
                        ToString_impl(value.Value.cbc_Department, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.Value.cbc_CityName != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_CityName\":");
                        
                        ToString_impl(value.Value.cbc_CityName, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.Value.cbc_CountrySubentityCode != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_CountrySubentityCode\":");
                        
                        ToString_impl(value.Value.cbc_CountrySubentityCode, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_Country\":");
                        
                        ToString_impl(value.Value.cbc_Country, str_builder, in_json: true);
                        
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_Attachment? value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                if (value == null)
                    return;
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.Value.cac_ExternalReferenceUdid != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_ExternalReferenceUdid\":");
                        
                        ToString_impl(value.Value.cac_ExternalReferenceUdid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_Contact_Claims? value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                if (value == null)
                    return;
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.Value.cbc_Telephone != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_Telephone\":");
                        
                        ToString_impl(value.Value.cbc_Telephone, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.Value.cbc_Telefax != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_Telefax\":");
                        
                        ToString_impl(value.Value.cbc_Telefax, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.Value.cbc_ElectronicMail != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_ElectronicMail\":");
                        
                        ToString_impl(value.Value.cbc_ElectronicMail, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_ExternalReference_Claims? value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                if (value == null)
                    return;
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.Value.cbc_URI != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_URI\":");
                        
                        ToString_impl(value.Value.cbc_URI, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.Value.cbc_EmbeddedDocumentBinaryObject != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_EmbeddedDocumentBinaryObject\":");
                        
                        ToString_impl(value.Value.cbc_EmbeddedDocumentBinaryObject, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_Item_Claims? value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                if (value == null)
                    return;
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.Value.cbc_Name != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_Name\":");
                        
                        ToString_impl(value.Value.cbc_Name, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_SellersItemIdentification\":");
                        
                        ToString_impl(value.Value.cac_SellersItemIdentification, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_StandardItemIdentification\":");
                        
                        ToString_impl(value.Value.cac_StandardItemIdentification, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.Value.cac_CommodityClassification != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_CommodityClassification\":");
                        
                        ToString_impl(value.Value.cac_CommodityClassification, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_ClassifiedTaxCategory\":");
                        
                        ToString_impl(value.Value.cac_ClassifiedTaxCategory, str_builder, in_json: true);
                        
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_PartyLegalEntity_Claims? value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                if (value == null)
                    return;
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.Value.cbc_RegistrationName != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_RegistrationName\":");
                        
                        ToString_impl(value.Value.cbc_RegistrationName, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_CompanyID\":");
                        
                        ToString_impl(value.Value.cbc_CompanyID, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.Value.cbc_RegistrationAddressUdid != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_RegistrationAddressUdid\":");
                        
                        ToString_impl(value.Value.cbc_RegistrationAddressUdid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_Party_Claims? value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                if (value == null)
                    return;
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_EndpointID\":");
                        
                        ToString_impl(value.Value.cbc_EndpointID, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_PartyIdentification\":");
                        
                        ToString_impl(value.Value.cbc_PartyIdentification, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_PartyName\":");
                        
                        ToString_impl(value.Value.cbc_PartyName, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.Value.cac_PostalAddressUdid != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_PostalAddressUdid\":");
                        
                        ToString_impl(value.Value.cac_PostalAddressUdid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_PartyTaxScheme\":");
                        
                        ToString_impl(value.Value.cbc_PartyTaxScheme, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.Value.cac_PartyLegalEntityUdid != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_PartyLegalEntityUdid\":");
                        
                        ToString_impl(value.Value.cac_PartyLegalEntityUdid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.Value.cac_ContactUdid != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_ContactUdid\":");
                        
                        ToString_impl(value.Value.cac_ContactUdid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.Value.cac_PersonUdid != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_PersonUdid\":");
                        
                        ToString_impl(value.Value.cac_PersonUdid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_PayeeFinancialAccount_Claims? value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                if (value == null)
                    return;
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.Value.cbc_ID != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_ID\":");
                        
                        ToString_impl(value.Value.cbc_ID, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_FinancialInstitutionBranch\":");
                        
                        ToString_impl(value.Value.cac_FinancialInstitutionBranch, str_builder, in_json: true);
                        
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_PaymentMeans_Claims? value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                if (value == null)
                    return;
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_PaymentMeansCode\":");
                        
                        ToString_impl(value.Value.cbc_PaymentMeansCode, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_PaymentDueDate\":");
                        
                        ToString_impl(value.Value.cbc_PaymentDueDate, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.Value.cbc_PaymentChannel != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_PaymentChannel\":");
                        
                        ToString_impl(value.Value.cbc_PaymentChannel, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.Value.cbc_PaymentID != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_PaymentID\":");
                        
                        ToString_impl(value.Value.cbc_PaymentID, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.Value.cac_PayeeFinancialAccountUdid != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_PayeeFinancialAccountUdid\":");
                        
                        ToString_impl(value.Value.cac_PayeeFinancialAccountUdid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cac_Person_Claims? value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                if (value == null)
                    return;
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.Value.cbc_FirstName != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_FirstName\":");
                        
                        ToString_impl(value.Value.cbc_FirstName, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.Value.cbc_MiddleName != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_MiddleName\":");
                        
                        ToString_impl(value.Value.cbc_MiddleName, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.Value.cbc_FamilyName != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_FamilyName\":");
                        
                        ToString_impl(value.Value.cbc_FamilyName, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.Value.cbc_JobTitle != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_JobTitle\":");
                        
                        ToString_impl(value.Value.cbc_JobTitle, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Cbc_EmbeddedDocumentBinaryObject? value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                if (value == null)
                    return;
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.Value._mimeCode != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"_mimeCode\":");
                        
                        ToString_impl(value.Value._mimeCode, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.Value.binary16 != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"binary16\":");
                        
                        ToString_impl(value.Value.binary16, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(TRAEncryptedClaims? value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                if (value == null)
                    return;
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.Value.ciphertext16 != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"ciphertext16\":");
                        
                        ToString_impl(value.Value.ciphertext16, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.Value.alg != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"alg\":");
                        
                        ToString_impl(value.Value.alg, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.Value.key != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"key\":");
                        
                        ToString_impl(value.Value.key, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(TRAGeoLocation_Claims? value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                if (value == null)
                    return;
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"latitude\":");
                        
                        ToString_impl(value.Value.latitude, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"longitude\":");
                        
                        ToString_impl(value.Value.longitude, str_builder, in_json: true);
                        
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(TRAGeoLocation_EnvelopeContent? value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                if (value == null)
                    return;
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.Value.udid != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"udid\":");
                        
                        ToString_impl(value.Value.udid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.Value.context != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"context\":");
                        
                        ToString_impl(value.Value.context, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.Value.credentialsubjectudid != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"credentialsubjectudid\":");
                        
                        ToString_impl(value.Value.credentialsubjectudid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.Value.claims != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"claims\":");
                        
                        ToString_impl(value.Value.claims, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.Value.encryptedclaims != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"encryptedclaims\":");
                        
                        ToString_impl(value.Value.encryptedclaims, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(TRAPostalAddress_Claims? value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                if (value == null)
                    return;
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.Value.streetAddress != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"streetAddress\":");
                        
                        ToString_impl(value.Value.streetAddress, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.Value.postOfficeBoxNumber != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"postOfficeBoxNumber\":");
                        
                        ToString_impl(value.Value.postOfficeBoxNumber, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.Value.addressLocality != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"addressLocality\":");
                        
                        ToString_impl(value.Value.addressLocality, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.Value.addressRegion != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"addressRegion\":");
                        
                        ToString_impl(value.Value.addressRegion, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.Value.addressCountry != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"addressCountry\":");
                        
                        ToString_impl(value.Value.addressCountry, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.Value.postalCode != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"postalCode\":");
                        
                        ToString_impl(value.Value.postalCode, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(TRAPostalAddress_EnvelopeContent? value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                if (value == null)
                    return;
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.Value.udid != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"udid\":");
                        
                        ToString_impl(value.Value.udid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.Value.context != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"context\":");
                        
                        ToString_impl(value.Value.context, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.Value.credentialsubjectudid != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"credentialsubjectudid\":");
                        
                        ToString_impl(value.Value.credentialsubjectudid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.Value.claims != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"claims\":");
                        
                        ToString_impl(value.Value.claims, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.Value.encryptedclaims != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"encryptedclaims\":");
                        
                        ToString_impl(value.Value.encryptedclaims, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(TRATimestamp_Claims? value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                if (value == null)
                    return;
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"ticks\":");
                        
                        ToString_impl(value.Value.ticks, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"datetime\":");
                        
                        ToString_impl(value.Value.datetime, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.Value.timestamp != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"timestamp\":");
                        
                        ToString_impl(value.Value.timestamp, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(UBL21_Invoice2_Claims? value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                if (value == null)
                    return;
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.Value.cbc_UBLVersionID != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_UBLVersionID\":");
                        
                        ToString_impl(value.Value.cbc_UBLVersionID, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.Value.cbc_ID != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_ID\":");
                        
                        ToString_impl(value.Value.cbc_ID, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_IssueDate\":");
                        
                        ToString_impl(value.Value.cbc_IssueDate, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_InvoiceTypeCode\":");
                        
                        ToString_impl(value.Value.cbc_InvoiceTypeCode, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_Note\":");
                        
                        ToString_impl(value.Value.cbc_Note, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_TaxPointDate\":");
                        
                        ToString_impl(value.Value.cbc_TaxPointDate, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_DocumentCurrencyCode\":");
                        
                        ToString_impl(value.Value.cbc_DocumentCurrencyCode, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.Value.cbc_AccountingCost != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_AccountingCost\":");
                        
                        ToString_impl(value.Value.cbc_AccountingCost, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_InvoicePeriod\":");
                        
                        ToString_impl(value.Value.cbc_InvoicePeriod, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cbc_OrderReference\":");
                        
                        ToString_impl(value.Value.cbc_OrderReference, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_ContractDocumentReference\":");
                        
                        ToString_impl(value.Value.cac_ContractDocumentReference, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.Value.cac_AdditionalDocumentReferences != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_AdditionalDocumentReferences\":");
                        
                        ToString_impl(value.Value.cac_AdditionalDocumentReferences, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_AccountingSupplierParty\":");
                        
                        ToString_impl(value.Value.cac_AccountingSupplierParty, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_AccountingCustomerParty\":");
                        
                        ToString_impl(value.Value.cac_AccountingCustomerParty, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_PayeeParty\":");
                        
                        ToString_impl(value.Value.cac_PayeeParty, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_Delivery\":");
                        
                        ToString_impl(value.Value.cac_Delivery, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.Value.cac_PaymentMeansUdid != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_PaymentMeansUdid\":");
                        
                        ToString_impl(value.Value.cac_PaymentMeansUdid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_PaymentTerms\":");
                        
                        ToString_impl(value.Value.cac_PaymentTerms, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.Value.cac_AllowanceCharges != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_AllowanceCharges\":");
                        
                        ToString_impl(value.Value.cac_AllowanceCharges, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_TaxTotal\":");
                        
                        ToString_impl(value.Value.cac_TaxTotal, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_LegalMonetaryTotal\":");
                        
                        ToString_impl(value.Value.cac_LegalMonetaryTotal, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.Value.cac_InvoiceLine != null)
                        
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"cac_InvoiceLine\":");
                        
                        ToString_impl(value.Value.cac_InvoiceLine, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        #region mute
        
        #endregion
    }
}

#pragma warning restore 162,168,649,660,661,1522
