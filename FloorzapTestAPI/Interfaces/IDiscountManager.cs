using FloorzapTestAPI.Enum;
using FloorzapTestAPI.Model;

namespace FloorzapTestAPI.Interfaces
{
    public interface IDiscountManager
    {
        Task<Discount> GetDiscountAmount(decimal total, decimal salesTax, decimal discountValue, DiscountType discountType, decimal salesTaxRate);
        Task ApplyDiscount(QuoteDTO quote);
    }
}