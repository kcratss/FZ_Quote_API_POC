namespace FloorzapTestAPI.Model
{
    public class QuoteTotal
    {
        public decimal SubTotal { get; set; }
        public decimal SalesTax { get; set; }
        public decimal SalesTaxPercent { get; set; }
        public decimal Total { get; set; }
        public decimal TotalCost { get; set; }
    }
}
