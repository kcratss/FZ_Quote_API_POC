using Microsoft.AspNetCore.Components;
using FloorzapTestAPI.Model;
using FloorzapTestAPI.Enum;
using Microsoft.EntityFrameworkCore.Query.Internal;
using FloorzapTestAPI.Interfaces;
using FloorzapTestAPI.Constants;
using FloorzapTestAPI.Manager;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Runtime.CompilerServices;
using System;
using FloorzapTestAPI.Services;

namespace FloorzapTestAPI.Quotes
{
    public class QuoteManager : IQuoteManager
    {
        private readonly ILineItemService lineItemService;

        public QuoteManager(ILineItemService lineItemService)
        {
            this.lineItemService = lineItemService;
        }

        public async Task<QuoteDTO> Calculate(QuoteDTO quote)
        {
            switch (quote.Action)
            {
                case QuoteAction.LineItemAdded:
                    await lineItemService.QuoteLineItemAdded(quote);
                    break;
                case QuoteAction.LineItemRemoved:
                    await lineItemService.QuoteLineItemRemoved(quote);
                    break;
                case QuoteAction.LineItemUpdated:
                    await lineItemService.QuoteLineItemUpdated(quote);
                    break;
                case QuoteAction.DiscountChanged:
                    await lineItemService.QuoteDiscountChanged(quote);
                    break;
            }

            return quote;
        }

    }
}
