using MarketWatch.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace MarketWatch.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SymbolsController(SymbolService service) : ControllerBase
    {
        /// <summary>
        /// Method to get public symbols from external source.
        /// </summary>
        /// <returns>Symbol list</returns>
        [HttpGet("public-symbols")]
        public async Task<IActionResult> GetPublicSymbols()
        {
            var symbols = await service.GetPublicSymbolsAsync();
            return Ok(new { symbols });
        }

        /// <summary>
        /// Method to get a symbol from database.
        /// </summary>
        [HttpGet("market-watch")]
        public async Task<IActionResult> GetStoredSymbols()
        {
            var symbols = await service.GetStoredSymbolsAsync();
            return Ok(new { symbols });
        }

        /// <summary>
        /// Method to add a symbol to the market watch list.
        /// </summary>
        /// <param name="name">Symbol to add</param>
        [HttpPost("market-watch")]
        public async Task<IActionResult> AddSymbol([FromBody] string name)
        {
            await service.AddSymbolAsync(name);
            return Ok();
        }
    }

}
