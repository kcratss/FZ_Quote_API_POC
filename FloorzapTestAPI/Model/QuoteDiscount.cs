using FloorzapTestAPI.Enum;

namespace FloorzapTestAPI.Model
{
    public class QuoteDiscount
    {
        public decimal DiscountAmount { get; set; }
        public decimal DiscountSalesTaxAmount { get; set; }
        public decimal DiscountValue { get; set; }
        public DiscountType DiscountType { get; set; } = DiscountType.Dollar;
        public string Notes { get; set; } = string.Empty;
    }
}
