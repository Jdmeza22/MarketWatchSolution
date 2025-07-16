
namespace MarketWatch.Domain.Interfaces;

public interface ISymbolRepository
{
    Task<IEnumerable<string>> GetPublicSymbolsAsync(); 
    Task<IEnumerable<string>> GetStoredSymbolsAsync(); 
    Task AddSymbolAsync(string name);
}
