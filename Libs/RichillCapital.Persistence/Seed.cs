using System.Collections.ObjectModel;

using RichillCapital.Domain;

namespace RichillCapital.Persistence;

public static class Seed
{
    public static readonly Collection<Bot> Bots = [
        CreateBot("TV-BINANCE:ETHUSDT.P-M15-PL-0001", "Double CCI Trend following", "Double cci as primary, EMA as filter.", ["BINANCE:ETHUSDT.P", "BINANCE:BTCUSDT.P", "BINANCE:SOLUSDT.P"], "Long", "TradingView"),
    ];

    private static Bot CreateBot(string id, string name, string description, string[] symbols, string side, string platform) => 
        new Bot(
            new BotId(id),
            new BotName(name),
            new BotDescription(description),
            symbols.Select(symbol => new Symbol(symbol)).ToArray(),
            Side.FromName(side).Value,
            TradingPlatform.FromName(platform).Value);
}
