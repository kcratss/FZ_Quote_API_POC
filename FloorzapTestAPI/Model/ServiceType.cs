namespace FloorzapTestAPI.Model
{
    public class ServiceType
    {
        public string ServiceTypeID { get; set; } = string.Empty;
        public decimal Material { get; set; }
        public decimal MaterialTax { get; set; }
        public decimal Labor { get; set; }
        public decimal Expenses { get; set; }
        public decimal Freight { get; set; }
        public decimal SalesTax { get; set; }
        public decimal TotalCosts { get; set; }
        public decimal TotalSales { get; set; }
        public decimal ProfitAmount { get; set; }
        public decimal ProfitPercent { get; set; }
        public LineItem LineItem { get; set; } = new();
    }
}
