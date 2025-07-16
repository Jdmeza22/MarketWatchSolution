using MarketWatch.Domain.Interfaces;

namespace MarketWatch.Application.UseCases;

public class SymbolService(ISymbolRepository repository)
{

    /// <summary>
    /// Method to get public symbols from external source.
    /// </summary>
    /// <returns>Symbols list</returns>
    public Task<IEnumerable<string>> GetPublicSymbolsAsync() => repository.GetPublicSymbolsAsync();

    /// <summary>
    /// Method to get stored symbols from the database.
    /// </summary>
    public Task<IEnumerable<string>> GetStoredSymbolsAsync() => repository.GetStoredSymbolsAsync();

    /// <summary>
    /// Method to add a symbol to the database.
    /// </summary>
    public Task AddSymbolAsync(string name) => repository.AddSymbolAsync(name);
}
