namespace FloorzapTestAPI.Interfaces
{
    public interface IProfitManager
    {
        Task<decimal> CalculateServiceProfit(decimal totalSales, decimal totalCost, decimal salesTax);
        Task<decimal> CalculateServiceProfitPercent(decimal totalSales, decimal totalCost, decimal salesTax);
        Task<decimal> CalculateQuoteProfit(decimal totalSale, decimal totalCost, decimal salesTax);
        Task<decimal> CalculateQuoteProfitPercent(decimal totalSale, decimal totalCost, decimal salesTax);
    }
}