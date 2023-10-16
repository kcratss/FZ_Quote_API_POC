using FloorzapTestAPI.Interfaces;
using FloorzapTestAPI.Model;

namespace FloorzapTestAPI.Manager
{
    public class TaxManager : ITaxManager
    {
        public decimal CalculateMaterialTax(LineItem lineItem, decimal salesTax)
        {
            return lineItem.TotalCost * (salesTax / 100);
        }

        public decimal CalculateServiceTypeTax(decimal totalSales, decimal salesTax)
        {
            return totalSales * (salesTax / 100);
        }
    }
}
