using MarketWatch.Domain.Interfaces;

namespace MarketWatch.Application.UseCases;

public class SymbolService 
{
    private readonly ISymbolRepository _repository;

    public SymbolService(ISymbolRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<string>> GetPublicSymbolsAsync() => _repository.GetPublicSymbolsAsync();

    public Task<IEnumerable<string>> GetStoredSymbolsAsync() => _repository.GetStoredSymbolsAsync();

    public Task AddSymbolAsync(string name) => _repository.AddSymbolAsync(name);
}
