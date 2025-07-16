using MarketWatch.Domain.Entities;
using MarketWatch.Domain.Interfaces;
using MarketWatch.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketWatch.Persistence.Repositories;


public class SymbolRepository(MarketWatchDbContext context, BinanceSymbolService binance) : ISymbolRepository
{
    

    public async Task<IEnumerable<string>> GetPublicSymbolsAsync() => await binance.GetSymbolsAsync();

    public async Task<IEnumerable<string>> GetStoredSymbolsAsync() => await context.Symbols.Select(s => s.Name).ToListAsync();

    public async Task AddSymbolAsync(string name)
    {
        if (!await context.Symbols.AnyAsync(s => s.Name == name))
        {
            context.Symbols.Add(new Symbol { Name = name });
            await context.SaveChangesAsync();
        }
    }
}