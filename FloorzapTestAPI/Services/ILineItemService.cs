using FloorzapTestAPI.Model;

namespace FloorzapTestAPI.Services
{
    public interface ILineItemService
    {
        Task QuoteLineItemAdded(QuoteDTO quote);
        Task QuoteLineItemRemoved(QuoteDTO quote);
        Task QuoteLineItemUpdated(QuoteDTO quote);
        Task QuoteDiscountChanged(QuoteDTO quote);
    }
}