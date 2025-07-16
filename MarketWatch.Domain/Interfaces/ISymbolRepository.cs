
namespace MarketWatch.Domain.Interfaces;

public interface ISymbolRepository
{
    /// <summary>
    /// Method to get public symbols from Binance API.
    /// </summary>
    /// <returns>Symbols list</returns>
    Task<IEnumerable<string>> GetPublicSymbolsAsync();

    /// <summary>
    /// Method to get stored symbols from the database.
    /// </summary>
    Task<IEnumerable<string>> GetStoredSymbolsAsync();

    /// <summary>
    /// Method to add a symbol to the database.
    /// param name="symbolName">Symbol name to add</param>
    /// </summary>
    Task AddSymbolAsync(string symbolName);

    /// <summary>
    /// Method to delete a symbol to the database.
    /// param name="symbolName">Symbol name to delete</param>
    /// </summary>
    Task DeleteSymbolAsync(string symbolName);
}
