using FloorzapTestAPI.Constants;
using FloorzapTestAPI.Interfaces;
using FloorzapTestAPI.Manager;
using FloorzapTestAPI.Model;

namespace FloorzapTestAPI.Services
{
    public class LineItemService : ILineItemService
    {
        private readonly ICompanySettingManager companySettingManager;
        private readonly ITaxManager taxManager;
        private readonly IProfitManager profitManager;
        private readonly IDiscountManager discountManager;
        private readonly ICommissionManager commissionManager;

        public LineItemService(ICompanySettingManager companySettingManager, ITaxManager taxManager, IProfitManager profitManager,
            IDiscountManager discountManager, ICommissionManager commissionManager)
        {
            this.companySettingManager = companySettingManager;
            this.taxManager = taxManager;
            this.profitManager = profitManager;
            this.discountManager = discountManager;
            this.commissionManager = commissionManager;
        }
        public async Task QuoteLineItemAdded(QuoteDTO quote)
        {
            var serviceType = quote.ServiceType;
            var lineItem = quote.ServiceType.LineItem;
            var companySetting = await companySettingManager.GetCompanySettingAsync();

            quote.QuoteTotal.SubTotal -= serviceType.TotalSales;
            quote.QuoteTotal.SalesTax -= serviceType.SalesTax;
            quote.QuoteTotal.TotalCost -= serviceType.TotalCosts;
            quote.QuoteProfit.TotalCost -= serviceType.TotalCosts;

            // Calculate Line Item Values
            lineItem.TotalCost = lineItem.UnitCost * lineItem.Quantity;
            lineItem.UnitPrice = lineItem.UnitCost / (1 - (lineItem.Margin / 100));
            lineItem.TotalPrice = lineItem.UnitPrice * lineItem.Quantity;

            // Calculate Service Type Values
            serviceType.Material += lineItem.TotalCost;
            if (!companySetting.SalesTaxAsCost)
            {
                serviceType.MaterialTax = taxManager.CalculateMaterialTax(lineItem, quote.SalesTaxRate);
            }
            serviceType.TotalSales += lineItem.TotalPrice;
            serviceType.TotalCosts += lineItem.TotalCost;
            var totalTaxableSales = serviceType.TotalSales - (lineItem.SalesTax ? 0 : lineItem.TotalPrice);
            serviceType.SalesTax = taxManager.CalculateServiceTypeTax(totalTaxableSales, quote.SalesTaxRate);
            serviceType.ProfitAmount = await profitManager.CalculateServiceProfit(serviceType.TotalSales, serviceType.TotalCosts, serviceType.SalesTax);
            serviceType.ProfitPercent = await profitManager.CalculateServiceProfitPercent(serviceType.TotalSales, serviceType.TotalCosts, serviceType.SalesTax);

            // Calculate Quote Header Values
            quote.QuoteTotal.SubTotal += serviceType.TotalSales;
            quote.QuoteTotal.SalesTax += serviceType.SalesTax;
            quote.QuoteTotal.TotalCost += serviceType.TotalCosts;
            quote.QuoteTotal.Total = quote.QuoteTotal.SubTotal + quote.QuoteTotal.SalesTax;
            await discountManager.ApplyDiscount(quote);

            quote.QuoteProfit.TotalCost += serviceType.TotalCosts;
            quote.QuoteProfit.ProfitAmount = await profitManager.CalculateQuoteProfit(quote.QuoteTotal.SubTotal, quote.QuoteTotal.TotalCost, quote.QuoteTotal.SalesTax);
            quote.QuoteProfit.ProfitPercent = await profitManager.CalculateQuoteProfitPercent(quote.QuoteTotal.SubTotal, quote.QuoteTotal.TotalCost, quote.QuoteTotal.SalesTax);
            

            var salesmanCommission = await commissionManager.GetSalesmanCommissionAsync(quote.QuoteProfit.ProfitAmount, quote.QuoteProfit.ProfitPercent);
            quote.QuoteCommission.CommissionPercent = salesmanCommission.CommissionPercent;
            quote.QuoteCommission.CommissionAmount = salesmanCommission.CommissionAmount;
        }

        public async Task QuoteLineItemRemoved(QuoteDTO quote)
        {
            var serviceType = quote.ServiceType;
            var lineItem = quote.ServiceType.LineItem;
            var companySetting = await companySettingManager.GetCompanySettingAsync();

            quote.QuoteTotal.SubTotal -= serviceType.TotalSales;
            quote.QuoteTotal.SalesTax -= serviceType.SalesTax;
            quote.QuoteTotal.TotalCost -= serviceType.TotalCosts;
            quote.QuoteProfit.TotalCost -= serviceType.TotalCosts;

            // Calculate Line Item Values
            lineItem.TotalCost = lineItem.UnitCost * lineItem.Quantity;
            lineItem.UnitPrice = lineItem.UnitCost / (1 - (lineItem.Margin / 100));
            lineItem.TotalPrice = lineItem.UnitPrice * lineItem.Quantity;

            // Calculate Service Type Values
            serviceType.Material -= lineItem.TotalCost;
            if (!companySetting.SalesTaxAsCost)
            {
                serviceType.MaterialTax -= taxManager.CalculateMaterialTax(lineItem, quote.SalesTaxRate);
            }

            serviceType.TotalSales -= lineItem.TotalPrice;
            serviceType.TotalCosts -= lineItem.TotalCost;
            serviceType.SalesTax = taxManager.CalculateServiceTypeTax(serviceType.TotalSales, quote.SalesTaxRate);
            serviceType.ProfitAmount = await profitManager.CalculateServiceProfit(serviceType.TotalSales, serviceType.TotalCosts, serviceType.SalesTax);
            serviceType.ProfitPercent = await profitManager.CalculateServiceProfitPercent(serviceType.TotalSales, serviceType.TotalCosts, serviceType.SalesTax);

            // Calculate Quote Header Values
            quote.QuoteTotal.SubTotal += serviceType.TotalSales;
            quote.QuoteTotal.SalesTax += serviceType.SalesTax;
            quote.QuoteTotal.TotalCost += serviceType.TotalCosts;
            quote.QuoteTotal.Total = quote.QuoteTotal.SubTotal + quote.QuoteTotal.SalesTax;
            await discountManager.ApplyDiscount(quote);

            quote.QuoteProfit.ProfitAmount = await profitManager.CalculateQuoteProfit(quote.QuoteTotal.SubTotal, quote.QuoteTotal.TotalCost, quote.QuoteTotal.SalesTax);
            quote.QuoteProfit.ProfitPercent = await profitManager.CalculateQuoteProfitPercent(quote.QuoteTotal.SubTotal, quote.QuoteTotal.TotalCost, quote.QuoteTotal.SalesTax);
            quote.QuoteProfit.TotalCost += serviceType.TotalCosts;

            var salesmanCommission = await commissionManager.GetSalesmanCommissionAsync(quote.QuoteProfit.ProfitAmount, quote.QuoteProfit.ProfitPercent);
            quote.QuoteCommission.CommissionPercent = salesmanCommission.CommissionPercent;
            quote.QuoteCommission.CommissionAmount = salesmanCommission.CommissionAmount;
        }

        public async Task QuoteLineItemUpdated(QuoteDTO quote)
        {
            switch (quote.ServiceType.LineItem.PropertyName)
            {
                case LineItemConstants.UnitCost:
                    await LineItemUnitCostUpdated(quote);
                    break;
                case LineItemConstants.Quantity:
                    await LineItemQuantityUpdated(quote);
                    break;
                case LineItemConstants.Margin:
                    await LineItemMarginUpdated(quote);
                    break;
                case LineItemConstants.UnitPrice:
                    await LineItemUnitPriceUpdated(quote);
                    break;
                case LineItemConstants.TotalPrice:
                    await LineItemTotalPriceUpdated(quote);
                    break;
                case LineItemConstants.SalesTax:
                    await LineItemSalesTaxUpdated(quote);
                    break;
            }
        }

        public async Task QuoteDiscountChanged(QuoteDTO quote)
        {
            await discountManager.ApplyDiscount(quote);
            quote.QuoteProfit.ProfitAmount = await profitManager.CalculateQuoteProfit(quote.QuoteTotal.SubTotal, quote.QuoteTotal.TotalCost, quote.QuoteTotal.SalesTax);
            quote.QuoteProfit.ProfitPercent = await profitManager.CalculateQuoteProfitPercent(quote.QuoteTotal.SubTotal, quote.QuoteTotal.TotalCost, quote.QuoteTotal.SalesTax);

            var salesmanCommission = await commissionManager.GetSalesmanCommissionAsync(quote.QuoteProfit.ProfitAmount, quote.QuoteProfit.ProfitPercent);
            quote.QuoteCommission.CommissionPercent = salesmanCommission.CommissionPercent;
            quote.QuoteCommission.CommissionAmount = salesmanCommission.CommissionAmount;
        }
        private async Task LineItemUnitCostUpdated(QuoteDTO quote)
        {
            await QuoteLineItemRemoved(quote);
            if (decimal.TryParse(quote.ServiceType.LineItem.PropertyValue.ToString(), out decimal unitCost))
                quote.ServiceType.LineItem.UnitCost = unitCost;

            await QuoteLineItemAdded(quote);
        }

        private async Task LineItemQuantityUpdated(QuoteDTO quote)
        {
            await QuoteLineItemRemoved(quote);
            if (decimal.TryParse(quote.ServiceType.LineItem.PropertyValue.ToString(), out decimal quantity))
                quote.ServiceType.LineItem.Quantity = quantity;

            await QuoteLineItemAdded(quote);
        }

        private async Task LineItemMarginUpdated(QuoteDTO quote)
        {
            await QuoteLineItemRemoved(quote);
            if (decimal.TryParse(quote.ServiceType.LineItem.PropertyValue.ToString(), out decimal margin))
                quote.ServiceType.LineItem.Margin = margin;

            await QuoteLineItemAdded(quote);
        }

        private async Task LineItemUnitPriceUpdated(QuoteDTO quote)
        {
            await QuoteLineItemRemoved(quote);
            if (decimal.TryParse(quote.ServiceType.LineItem.PropertyValue.ToString(), out decimal unitPrice))
            {
                decimal value = (1 - (quote.ServiceType.LineItem.UnitCost / unitPrice)) * 100;
                if (value < 0)
                    quote.ServiceType.LineItem.Margin = 0;
                else if (value >= 100)
                    quote.ServiceType.LineItem.Margin = 99.99m;
                else
                    quote.ServiceType.LineItem.Margin = value;
            }
            await QuoteLineItemAdded(quote);
        }

        private async Task LineItemTotalPriceUpdated(QuoteDTO quote)
        {
            await QuoteLineItemRemoved(quote);
            if (decimal.TryParse(quote.ServiceType.LineItem.PropertyValue.ToString(), out decimal totalPrice))
            {
                decimal unitPrice = totalPrice / quote.ServiceType.LineItem.Quantity;
                quote.ServiceType.LineItem.UnitPrice = unitPrice;

                decimal margin = (1 - (quote.ServiceType.LineItem.UnitCost / unitPrice)) * 100;
                if (margin < 0)
                    quote.ServiceType.LineItem.Margin = 0;
                else if (margin >= 100)
                    quote.ServiceType.LineItem.Margin = 99.99m;
                else
                    quote.ServiceType.LineItem.Margin = margin;
            }
            await QuoteLineItemAdded(quote);
        }

        private async Task LineItemSalesTaxUpdated(QuoteDTO quote)
        {
            await QuoteLineItemRemoved(quote);
            if (bool.TryParse(quote.ServiceType.LineItem.PropertyValue.ToString(), out bool salesTax))
                quote.ServiceType.LineItem.SalesTax = salesTax;
            await QuoteLineItemAdded(quote);
        }
    }
}
