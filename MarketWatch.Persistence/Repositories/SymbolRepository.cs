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
    /// </summary>
    public async Task AddSymbolAsync(string name)
    {
        if (!await context.Symbols.AnyAsync(s => s.Name == name))
        {
            context.Symbols.Add(new Symbol { Name = name });
            await context.SaveChangesAsync();
        }
    }
}