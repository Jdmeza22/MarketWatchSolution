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
    /// param name="symbolName">Symbol name to add</param>
    /// </summary>
    public Task AddSymbolAsync(string symbolName) => repository.AddSymbolAsync(symbolName);

    /// <summary>
    /// Method to delete a symbol to the database.
    /// param name="symbolName">Symbol name to delete</param>
    /// </summary>
    public Task DeleteSymbolAsync(string symbolName)  => repository.DeleteSymbolAsync(symbolName);
}
