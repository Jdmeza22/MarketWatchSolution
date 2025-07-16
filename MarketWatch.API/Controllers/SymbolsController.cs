using MarketWatch.Application.UseCases;
using MarketWatch.Domain.Entities;
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
            try
            {
                var symbols = await service.GetPublicSymbolsAsync();
                return Ok(new { symbols });
            }
            catch (Exception ex)
            {
                // TODO: log the exception
                return StatusCode(500, new { message = "An error occurred while retrieving public symbols.", detail = ex.Message });
            }
        }

        /// <summary>
        /// Method to get a symbol from database.
        /// </summary>
        [HttpGet("market-watch")]
        public async Task<IActionResult> GetStoredSymbols()
        {
            try
            {
                var symbols = await service.GetStoredSymbolsAsync();
                return Ok(new { symbols });
            }
            catch (Exception ex)
            {
                // TODO: log the exception
                return StatusCode(500, new { message = "An error occurred while retrieving stored symbols.", detail = ex.Message });
            }
        }

        /// <summary>
        /// Method to add a symbol to the market watch list.
        /// </summary>
        /// <param name="symbolName">Symbol to add</param>
        [HttpPost("market-watch")]
        public async Task<IActionResult> AddSymbol([FromBody] string symbolName)
        {
            try
            {
                await service.AddSymbolAsync(symbolName);
                return Ok();
            }
            catch (Exception ex)
            {
                // TODO: log the exception
                return StatusCode(500, new { message = "An error occurred while adding the symbol.", detail = ex.Message });
            }
        }

        /// <summary>
        /// Method to delete a symbol from the market watch list.
        /// </summary>
        /// <param name = "symbolName" > Symbol to delete</param>
        [HttpDelete("market-watch")]
        public async Task<IActionResult> DeleteSymbol([FromBody] string symbolName)
        {
            try
            {
                await service.DeleteSymbolAsync(symbolName);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while deleting the symbol.", detail = ex.Message });
            }
        }


    }

}
