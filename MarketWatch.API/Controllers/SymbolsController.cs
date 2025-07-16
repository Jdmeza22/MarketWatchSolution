using MarketWatch.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace MarketWatch.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SymbolsController : ControllerBase
    {
        private readonly SymbolService _service;

        public SymbolsController(SymbolService service) => _service = service;

        [HttpGet("public-symbols")]
        public async Task<IActionResult> GetPublicSymbols()
        {
            var symbols = await _service.GetPublicSymbolsAsync();
            return Ok(new { symbols });
        }

        [HttpGet("market-watch")]
        public async Task<IActionResult> GetStoredSymbols()
        {
            var symbols = await _service.GetStoredSymbolsAsync();
            return Ok(new { symbols });
        }

        [HttpPost("market-watch")]
        public async Task<IActionResult> AddSymbol([FromBody] string name)
        {
            await _service.AddSymbolAsync(name);
            return Ok();
        }
    }

}
