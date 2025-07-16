using MarketWatch.Domain.Entities;
using MarketWatch.Domain.Interfaces;
using MarketWatch.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketWatch.Persistence.Repositories;


public class SymbolRepository : ISymbolRepository
{
    private readonly MarketWatchDbContext _context;
    private readonly BinanceSymbolService _binance;

    public SymbolRepository(MarketWatchDbContext context, BinanceSymbolService binance)
    {
        _context = context;
        _binance = binance;
    }

    public async Task<IEnumerable<string>> GetPublicSymbolsAsync() => await _binance.GetSymbolsAsync();

    public async Task<IEnumerable<string>> GetStoredSymbolsAsync() => await _context.Symbols.Select(s => s.Name).ToListAsync();

    public async Task AddSymbolAsync(string name)
    {
        if (!await _context.Symbols.AnyAsync(s => s.Name == name))
        {
            _context.Symbols.Add(new Symbol { Name = name });
            await _context.SaveChangesAsync();
        }
    }
}