using FloorzapTestAPI.Model;

namespace FloorzapTestAPI.Interfaces
{
    public interface ICommissionManager
    {
        Task<SalesmanCommission> GetSalesmanCommissionAsync(decimal amount, decimal profitPercent);
        Task<IEnumerable<Commission>> GetCommissionsAsync();
    }
}
