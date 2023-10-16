using FloorzapTestAPI.Model;

namespace FloorzapTestAPI.Interfaces
{
    public interface ITaxManager
    {
        decimal CalculateMaterialTax(LineItem lineItem, decimal salesTax);
        decimal CalculateServiceTypeTax(decimal totalSales, decimal salesTax);
    }
}