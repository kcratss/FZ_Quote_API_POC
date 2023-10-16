using FloorzapTestAPI.Enum;
using FloorzapTestAPI.Interfaces;
using FloorzapTestAPI.Model;

namespace FloorzapTestAPI.Manager
{
    public class DiscountManager : IDiscountManager
    {
        private readonly ICompanySettingManager companySettingManager;

        public DiscountManager(ICompanySettingManager companySettingManager) {
            this.companySettingManager = companySettingManager;
        }

        public async Task<Discount> GetDiscountAmount(decimal total, decimal salesTax, decimal discountValue, DiscountType discountType, decimal salesTaxRate)
        {
            Discount discount = new();
            var companySetting = await companySettingManager.GetCompanySettingAsync();
            if (discountValue == 0)
            {
                return discount;
            }
            if (discountType == DiscountType.Dollar)
            {
                 total -= discountValue;
                if (companySetting.SalesTaxAsCost)
                {
                    salesTax -= discountValue * (salesTaxRate / 100);
                }
            }
            else
            {
                total -= (discountValue / 100) * total;
                if (companySetting.SalesTaxAsCost)
                {
                    salesTax -= discountValue * (salesTaxRate / 100);
                }
            }
            discount.SubTotalDiscount = total;
            discount.SalesTaxDiscount = salesTax;

            return discount;
        }

        public async Task ApplyDiscount(QuoteDTO quote)
        {
            var companySetting = await companySettingManager.GetCompanySettingAsync();
            quote.QuoteTotal.SubTotal += quote.QuoteDiscount.DiscountAmount;
            quote.QuoteTotal.SalesTax += quote.QuoteDiscount.DiscountSalesTaxAmount;
            if (quote.QuoteDiscount.DiscountValue == 0)
            {                
                quote.QuoteDiscount.DiscountAmount = 0;
                quote.QuoteDiscount.DiscountSalesTaxAmount = 0;
                quote.QuoteTotal.Total = quote.QuoteTotal.SubTotal + quote.QuoteTotal.SalesTax;
                return;
            }
            if (quote.QuoteDiscount.DiscountType == DiscountType.Dollar)
            {
                quote.QuoteDiscount.DiscountAmount = quote.QuoteDiscount.DiscountValue;
                quote.QuoteTotal.SubTotal -= quote.QuoteDiscount.DiscountAmount;
                if (companySetting.SalesTaxAsCost)
                {
                    quote.QuoteDiscount.DiscountSalesTaxAmount = quote.QuoteDiscount.DiscountValue * (quote.SalesTaxRate / 100);
                    quote.QuoteTotal.SalesTax -= quote.QuoteDiscount.DiscountSalesTaxAmount;
                }
            }
            else
            {
                quote.QuoteDiscount.DiscountAmount = (quote.QuoteDiscount.DiscountValue / 100) * quote.QuoteTotal.SubTotal;
                quote.QuoteTotal.SubTotal -= quote.QuoteDiscount.DiscountAmount;
                if (companySetting.SalesTaxAsCost)
                {
                    quote.QuoteDiscount.DiscountSalesTaxAmount = (quote.QuoteDiscount.DiscountValue * quote.QuoteTotal.SalesTax) / 100;
                    quote.QuoteTotal.SalesTax -= quote.QuoteDiscount.DiscountSalesTaxAmount;
                }
            }

            quote.QuoteTotal.Total = quote.QuoteTotal.SubTotal + quote.QuoteTotal.SalesTax;
        }
    }
}
