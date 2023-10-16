using FloorzapTestAPI.Enum;
using System.Diagnostics.Metrics;

namespace FloorzapTestAPI.Model
{
    public class CompanySetting
    {
        public int CompanySettingID { get; set; }

        /// <summary>
        /// Gets or sets the SalesTax value.
        /// </summary>
        public decimal SalesTax { get; set; }

        /// <summary>
        /// Gets or sets the CountryID value.
        /// </summary>
        public int CountryID { get; set; }

        /// <summary>
        /// Gets or sets the TimeZone value.
        /// </summary>
        public string TimeZone { get; set; }

        public string Layout { get; set; }

        /// <summary>
        /// Gets or sets the MinCommission value.
        /// </summary>
        public decimal MinCommission { get; set; }

        /// <summary>
        /// Gets or sets the MaxCommission value.
        /// </summary>
        public decimal MaxCommission { get; set; }

        /// <summary>
        /// Gets or sets the RepairCommission value.
        /// </summary>
        public decimal RepairCommission { get; set; }


        public int InvoiceStartNumber { get; set; }

        public decimal DefaultJobDownPayment { get; set; }

        public decimal CustomerRefAmount { get; set; }

        public decimal EmployeeRefAmount { get; set; }

        public decimal OrgSalesmanSplitAmount { get; set; }

        public int CompanyID { get; set; }


        public int AvailableTextMessages { get; set; }

        public int POStartNumber { get; set; }

        public bool SalesmanTextMessageEnabled { get; set; }

        public bool ShowPaymentMethodInPaymentNotification { get; set; }

        public bool ShowPaymentMethodInViewInvoice { get; set; }

        public bool ShowInStorePaymentMethodViewInvoice { get; set; }


        public bool ShowPaymentMethodInCompletionCertificate { get; set; }


        public int GridItemsPerPage { get; set; }




        public int CalculateMarginPercentBasedOn { get; set; }
        public bool? ShowUnitPriceInCustomerQuote { get; set; }
        public bool? ShowQuantityInCustomerQuote { get; set; }
        public bool? ShowQuantityUOM { get; set; }
        public bool? ShowPaymentMethod { get; set; }

        public bool? ShowSummaryTotals { get; set; }
        /// <summary>
        /// Gets or sets the Country value.
        /// </summary>
        public Country Country { get; set; }
        public bool? SendCustomerReminders { get; set; }
        public bool? SendContractorReminders { get; set; }
        public bool? AutomaticEmailToNewUsers { get; set; }

        public int? DefaultJobCompletionChecklistID { get; set; }
        public string DefaultJobCompletionChecklistTitle { get; set; }

        public bool? SendInvoiceEmailToCustomerOnQuoteApproved { get; set; }
        public bool? SendInvoiceTextMessageToCustomerOnQuoteApproved { get; set; }
        public bool? LockInvoiceWorkOrder { get; set; }


        #region quote_default_options_start
        public bool ShowQuantityInQuote { get; set; }
        public bool ShowItemNameInQuote { get; set; }
        public bool ShowAmountInQuote { get; set; }
        public bool ShowUnitPriceInQuote { get; set; }
        public bool ShowUOMInQuote { get; set; }
        public bool ShowUOMInInvoice { get; set; }
        public bool ShowServiceTypeInQuote { get; set; }
        public bool ShowSubtotalEachServiceTypeInQuote { get; set; }
        #endregion

        #region invoice_default_options_start
        public bool ShowQuantityInInvoice { get; set; }
        public bool ShowItemNameInInvoice { get; set; }
        public bool ShowAmountInInvoice { get; set; }
        public bool ShowUnitPriceInInvoice { get; set; }
        public bool ShowPaymentMethodInInvoice { get; set; }
        public bool ShowServiceTypeInInvoice { get; set; }
        #endregion

        #region Tax
        public int TaxType { get; set; }
        public bool SalesTaxAsCost { get; set; }
        #endregion
        public string DefaultTaxText { get; set; }
        public bool ShowLaborFeesInJobDetails { get; set; }
        public decimal FloatBag { get; set; }
        public bool UseSalesmanEmail { get; set; }
        public string ETransferEmailPhone { get; set; }
        public bool ShowLaborUnitCostInJobDetails { get; set; }

        /// <summary>
        /// Gets or sets the SetLaborTax value.
        /// </summary>
        public bool SetLaborTax { get; set; }
        public bool SetAutoTax { get; set; }
        public bool ChargeCardFeesInViewInvoice { get; set; }

        public string SalesRepLabel { get; set; }
        public string CustomerLabel { get; set; }
        public string ServiceSiteLable { get; set; }
        public string QuoteLabel { get; set; }

        public string InvoiceLabel { get; set; }
        public string CustomReplyToEmail { get; set; }
        public bool TaxCalculationAfterDiscount { get; set; }
        public bool? ShowContractInQuote { get; set; }

        public bool ShowCreditCardPaymentMethodViewInvoice { get; set; }
        public bool ShowCashPaymentMethodViewInvoice { get; set; }
        public bool ShowCheckPaymentMethodViewInvoice { get; set; }

        public bool AddExpensesToQISummarySection { get; set; }

        public int ShowProductsByCategory { get; set; }
        public short QuoteExpirationDays { get; set; }
        public bool RightToRecission { get; set; }
        public bool ShowVendorName { get; set; }

        public decimal? MaterialOverheadPercentage { get; set; }
        public bool ApplyMaterialOverheadToSellPrice { get; set; }

        public decimal? LaborOverheadPercentage { get; set; }
        public bool ApplyLaborOverheadToSellPrice { get; set; }
        public string GSTNo { get; set; }
        public string ProductIncomeAccount { get; set; }
        public string ProductExpenseAccount { get; set; }
        public bool ShowOutOfStock { get; set; }
        public bool RestrictInvoiceReset { get; set; }
        public string GSTTaxRateName { get; set; }
        public string ExemptTaxRateName { get; set; }
        public int PaymentTermID { get; set; }
        public string DefaultMessageForQuote { get; set; }
        public string DefaultMessageForInvoice { get; set; }
        public bool ShowSqYdInQuoteInvoice { get; set; }
        public bool DisplayPaymentTermInViewInvoice { get; set; }
        public bool DisplaySalesmanNameInViewInvoice { get; set; }
        public bool DisplaySalesmanPhoneInViewInvoice { get; set; }
        public bool DisplayInvoiceDateInViewInvoice { get; set; }
        public bool DisplayColumnHiddenTotalPriceInViewInvoice { get; set; }
        public bool DisplaySalesmanEmailInViewInvoice { get; set; }
        public string DiscountAccount { get; set; }
        public string ShippingCostAccount { get; set; }
        public string ContractorPaymentExpenseAccount { get; set; }
        public string VendorBillPaymentExpenseAccount { get; set; }
        public string LaborServiceExpenseAccount { get; set; }
        public string VendorBillPaymentRebateAccount { get; set; }
        public string LaborServiceIncomeAccount { get; set; }
        public string VendorBillExpenseAccount { get; set; }
        public string ReferralExpenseAccount { get; set; }
        public string VendorCreditAccount { get; set; }
        public string SalesmanPaymentExpenseAccount { get; set; }
        public string TaxesAndLicensesAccount { get; set; }
        public string OtherExpenseAccount { get; set; }

        public string CreditCardFeesExpenseAccount { get; set; }
        public string CreditCardFeesIncomeAccount { get; set; }
        public string CustomerRefundAdjustmentServiceIncomeAccount { get; set; }
        public string CustomerRefundAdjustmentServiceExpenseAccount { get; set; }
        public int ViewInvoiceDisplayDate { get; set; }
        public int OrderConfirmationDisplayDate { get; set; }

        public string RemitNoteForCash { get; set; }
        public string RemitNoteForCreditCard { get; set; }

        public bool ShiftChildSchedules { get; set; }
        //public str
        public string PickListNote { get; set; }
        public bool MeasurementByDecimal { get; set; }
        public string ChargeCardFeesLableInViewInvoice { get; set; }

        public ReplyToEmailType ReplyToEmail { get; set; }

        public bool ShowStatusInPickList { get; set; }
        public bool ShowOrderNumberInPickList { get; set; }
        public bool ShowVendorInPickList { get; set; }
        public bool ShowProductInPickList { get; set; }
        public bool ShowDescription { get; set; }
        public bool ShowStyleInPickList { get; set; }
        public bool ShowColorInPickList { get; set; }
        public bool ShowQuantityInPickList { get; set; }
        public bool ShowUOMInPickList { get; set; }
        public bool ShowPickedUpQuantityInPickList { get; set; }
        public bool ShowPickUpLocationInPickList { get; set; }
        public bool ShowItemLocationInPickList { get; set; }
        public bool ShowCustomerInformationInPickList { get; set; }
        public bool ShowMaterialOrder { get; set; }
        public bool ShowMaterialVendor { get; set; }
        public bool ShowMaterialProduct { get; set; }
        public bool ShowMaterialDescrption { get; set; }
        public bool ShowMaterialStyle { get; set; }
        public bool ShowMaterialColor { get; set; }
        public bool ShowMaterialQuantity { get; set; }
        public bool ShowMaterialUOM { get; set; }
        public bool ShowMaterialPickupLocation { get; set; }
        public bool ShowLaborDescription { get; set; }
        public bool ShowLaborUnitCost { get; set; }
        public bool ShowLaborName { get; set; }
        public bool ShowLaborQuantity { get; set; }
        public bool ShowLaborLaborCost { get; set; }
        public bool ShowLaborLaborTax { get; set; }
        public bool ShowCustomerInformation { get; set; }
        public bool IncludeFreightCostInProductUnitCost { get; set; }
        public bool EnablePrettyPrice { get; set; }
        public bool ApplyAchFees { get; set; }
        public decimal AchFees { get; set; }
        public bool MakeClassMandatory { get; set; }

        public bool OrderInformationShowVendorInformation { get; set; }
        public bool OrderInformationShowJobDetails { get; set; }
        public bool OrderInformationShowShippingDetails { get; set; }
        public bool OrderInformationShowItemName { get; set; }
        public bool OrderInformationShowDescription { get; set; }
        public bool OrderInformationShowStyle { get; set; }
        public bool OrderInformationShowColor { get; set; }
        public bool OrderInformationShowUnitCost { get; set; }
        public bool OrderInformationShowQuantity { get; set; }
        public bool OrderInformationShowTotal { get; set; }
        public bool CheckDefaultAssociatedProduct { get; set; }
        public bool DefaultSalesTaxCheckbox { get; set; }
        public string DefaultPSTText { get; set; }
        public bool MatQITaxAsCost { get; set; }
        public bool MatWOTaxAsCost { get; set; }
        public bool ShowServiceSiteInPackingSlip { get; set; }
        public bool ShowShippingInPackingSlip { get; set; }
        public bool ShowProductInPackingSlip { get; set; }
        public bool ShowStyleInPackingSlip { get; set; }
        public bool ShowColorInPackingSlip { get; set; }
        public bool ShowUOMInPackingSlip { get; set; }
        public bool ShowQuantityInPackingSlip { get; set; }
        public bool ShowDescriptionInPackingSlip { get; set; }
        public bool ShowItemNotesInPackingSlip { get; set; }
        public bool ShowSKUsInPackingSlip { get; set; }
        public bool LaborWOTaxAsCost { get; set; }
        public bool ShowACHPaymentMethodViewInvoice { get; set; }

        public string PSTTaxRateName { get; set; }

        public bool ManufacturerName { get; set; }
        public bool OrderNumber { get; set; }
        public bool Style { get; set; }
        public bool Color { get; set; }
        public bool WareHouse { get; set; }

        public string GSTPSTTaxCodeName { get; set; }
        public bool ApplyPSTTax { get; set; }

        public bool ShowMaterialSection { get; set; }
        public bool ShowLaborsSection { get; set; }

        public bool ShowCustomerInformationForContractor { get; set; }
        public bool ShowMaterialSectionForContractor { get; set; }
        public bool ShowMaterialOrderForContractor { get; set; }
        public bool ShowMaterialVendorForContractor { get; set; }
        public bool ShowMaterialProductForContractor { get; set; }
        public bool ShowMaterialDescrptionForContractor { get; set; }
        public bool ShowMaterialStyleForContractor { get; set; }
        public bool ShowMaterialColorForContractor { get; set; }
        public bool ShowMaterialQuantityForContractor { get; set; }
        public bool ShowMaterialUOMForContractor { get; set; }
        public bool ShowMaterialPickupLocationForContractor { get; set; }
        public bool ShowLaborsSectionForContractor { get; set; }
        public bool ShowLaborNameForContractor { get; set; }
        public bool ShowLaborDescriptionForContractor { get; set; }
        public bool ShowLaborUnitCostForContractor { get; set; }
        public bool ShowLaborQuantityForContractor { get; set; }
        public bool ShowLaborLaborCostForContractor { get; set; }
        public bool ShowLaborLaborTaxForContractor { get; set; }
        public string VendorDiscountAccount { get; set; }
        public string VendorBillFreightAccount { get; set; }
        public string VendorBillFreightIncomeAccount { get; set; }
        public bool IsBritishColumbiaPST { get; set; }
        public bool ShowContractorNotes { get; set; }
        public bool ShowScheduleSpecialInstruction { get; set; }
        public bool ShowContractorNotesForContractor { get; set; }
        public bool ShowScheduleSpecialInstructionForContractor { get; set; }
        public bool ShowCreditCardPaymentMethodCompletionCertificate { get; set; }
        public bool ShowCashPaymentMethodCompletionCertificate { get; set; }
        public bool ShowCheckPaymentMethodCompletionCertificate { get; set; }
        public bool ShowACHPaymentMethodCompletionCertificate { get; set; }
        public bool DisplayFloorInformationInViewInvoice { get; set; }
        public bool ShowFloorInformation { get; set; }
        public bool ShowFloorInformationForContractor { get; set; }
        public bool AddPSTInTotalInViewInvoice { get; set; }
        public bool LockInvoiceWithFinalInvoiceSent { get; set; }
        public bool AllowChangeInSignedInvoice { get; set; }
        public string DefaultDiscountTextInQuoteInvoice { get; set; }
        public bool AllowChangeInWOEvenIfInvoiceSigned { get; set; }
        public bool ShowNotesFromWOItemsInPickList { get; set; }
        public bool CompleteWorkOrderWithoutLineItemOrdered { get; set; }
        public bool UseWarehouseOrderingForInventoryAllocation { get; set; }
        public bool DefaultMarkMaterialReadyToOrder { get; set; }
        public bool ShowImportFromStackMeasurement { get; set; }
        public string PSTVendorName { get; set; }
        public string PSTTaxAccount { get; set; }

        public bool ConsiderBasePriceForInventoryProuctForQuotesInvoices { get; set; }

        public bool CalculateUseTax { get; set; }

        public string VendorBillAdjustment { get; set; }

        public bool ShowAmountColumn { get; set; }
        public int CurrentMaxQuoteNumber { get; set; }
    }
}
