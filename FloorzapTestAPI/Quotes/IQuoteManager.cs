using FloorzapTestAPI.Model;

namespace FloorzapTestAPI.Quotes
{
    public interface IQuoteManager
    {
        Task<QuoteDTO> Calculate(QuoteDTO quote);
    }
}
