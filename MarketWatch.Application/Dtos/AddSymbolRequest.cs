
namespace MarketWatch.Application.Dtos;

public class AddSymbolRequest
{
    public string SymbolName { get; set; } = string.Empty;
    public double? price { get; set; }
}
