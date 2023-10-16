using FloorzapTestAPI.Model;
using FloorzapTestAPI.Quotes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FloorzapTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private readonly IQuoteManager quoteManager;

        public QuoteController(IQuoteManager quoteManager)
        {
            this.quoteManager = quoteManager;
        }

        [HttpPost]
        public async Task<IActionResult> Calculate([FromBody] QuoteDTO quote)
        {
            var result = await quoteManager.Calculate(quote);
            return Ok(result);
        }
    }
}
