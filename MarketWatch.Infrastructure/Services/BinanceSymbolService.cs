using System.Net.Http.Json;

namespace MarketWatch.Infrastructure.Models;

public class BinanceSymbolService(HttpClient http)
{
    public async Task<IEnumerable<string>> GetSymbolsAsync()
    {
        //TODO Jmeza : Implement facade pattern to handle multiple exchanges
        BinanceExchangeInfo result = await http.GetFromJsonAsync<BinanceExchangeInfo>("https://api.binance.com/api/v3/exchangeInfo");
        return result?.symbols?.Select(s => s.symbol) ?? Enumerable.Empty<string>();
    }

}
