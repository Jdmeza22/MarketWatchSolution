using MarketWatch.Domain.Entities;
using MarketWatch.Domain.Interfaces;
using MarketWatch.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketWatch.Persistence.Repositories;


public class SymbolRepository(MarketWatchDbContext context, BinanceSymbolService binance) : ISymbolRepository
{
    
    /// <summary>
    /// Method to get public symbols from Binance API.
    /// </summary>
    /// <returns>Symbols list</returns>
    public async Task<IEnumerable<string>> GetPublicSymbolsAsync() => await binance.GetSymbolsAsync();

    /// <summary>
    /// Method to get stored symbols from the database.
    /// </summary>
    public async Task<IEnumerable<string>> GetStoredSymbolsAsync() => await context.Symbols.Select(s => s.Name).ToListAsync();

    /// <summary>
    /// Method to add a symbol to the database.
    /// param name="symbolName">Symbol name to add</param>
    /// </summary>
    public async Task AddSymbolAsync(string symbolName)
    {
        if (!await context.Symbols.AnyAsync(s => s.Name == symbolName))
        {
            context.Symbols.Add(new Symbol { Name = symbolName });
            await context.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Method to delete a symbol to the database.
    /// param name="symbolName">Symbol name to add</param>
    /// </summary>
    public async Task DeleteSymbolAsync(string symbolName)
    {
        var symbol = await context.Symbols.FirstOrDefaultAsync(s => s.Name == symbolName);
        if (symbol != null)
        {
            context.Symbols.Remove(symbol);
            await context.SaveChangesAsync();
        }
    }

}