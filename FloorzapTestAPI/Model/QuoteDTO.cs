using FloorzapTestAPI.Enum;

namespace FloorzapTestAPI.Model
{
    public class QuoteDTO
    {
        public QuoteDTO()
        {
            QuoteTotal = new();
            QuotesPayments = new();
            QuoteProfit = new();
            QuoteDiscount = new();
            QuoteCommission = new();
        }

        public int QuoteID { get; set; }
        public decimal SalesTaxRate { get; set; }
        public QuoteTotal QuoteTotal { get; set; }
        public QuotesPayments QuotesPayments { get; set; }
        public QuoteProfit QuoteProfit { get; set; }
        public QuoteDiscount QuoteDiscount { get; set; }
        public QuoteCommission QuoteCommission { get; set; } 
        public ServiceType ServiceType { get; set; } = new();
        public QuoteAction Action { get; set; }
    }
}
