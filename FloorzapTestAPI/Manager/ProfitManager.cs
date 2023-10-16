using FloorzapTestAPI.Interfaces;
using FloorzapTestAPI.Model;

namespace FloorzapTestAPI.Manager
{
    public class ProfitManager : IProfitManager
    {
        private readonly ICompanySettingManager companySettingManager;

        public ProfitManager(ICompanySettingManager companySettingManager)
        {
            this.companySettingManager = companySettingManager;
        }
        public async Task<decimal> CalculateServiceProfit(decimal totalSales, decimal totalCost, decimal salesTax)
        {
            var companySetting = await companySettingManager.GetCompanySettingAsync();
            if (companySetting.SalesTaxAsCost)
            {
                return totalSales - totalCost;
            }

            return totalSales + salesTax - totalCost;
        }

        public async Task<decimal> CalculateServiceProfitPercent(decimal totalSales, decimal totalCost, decimal salesTax)
        {
            var companySetting = await companySettingManager.GetCompanySettingAsync();
            if (!companySetting.SalesTaxAsCost)
            {
                totalSales += salesTax;
            }
            if((totalSales == totalCost) || (totalSales == 0))
            {
                return 0;
            }

            return (1 - (totalCost / totalSales)) * 100;
        }

        public async Task<decimal> CalculateQuoteProfit(decimal totalSale, decimal totalCost, decimal salesTax)
        {
            var companySetting = await companySettingManager.GetCompanySettingAsync();
            if (companySetting.SalesTaxAsCost)
            {
                return totalSale - totalCost;
            }
            return totalSale - totalCost + salesTax;
        }

        public async Task<decimal> CalculateQuoteProfitPercent(decimal totalSale, decimal totalCost, decimal salesTax)
        {
            var companySetting = await companySettingManager.GetCompanySettingAsync();
            if ((totalSale == totalCost) || (totalSale == 0))
            {
                return 0;
            }

            if (companySetting.SalesTaxAsCost)
            {
                return (1 - (totalCost / totalSale)) * 100;
            }
            
            return (1 - (totalCost / (totalSale + salesTax))) * 100;
        }
    }
}
