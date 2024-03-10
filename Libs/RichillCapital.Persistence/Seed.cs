using System.Collections.ObjectModel;
using Microsoft.Extensions.DependencyInjection;
using RichillCapital.Domain;

namespace RichillCapital.Persistence;

public static class Seed
{
    public static readonly Collection<Bot> Bots = [
        CreateBot("TV-BINANCE:ETHUSDT.P-M15-PL-0001", "Double CCI Trend following", "Double cci as primary, EMA as filter.", ["BINANCE:ETHUSDT.P", "BINANCE:BTCUSDT.P", "BINANCE:SOLUSDT.P"], "Long", "TradingView"),
    ];

    public static void Populate(IServiceProvider serviceProvider)
    {
        using var context = serviceProvider.GetRequiredService<MsSqlEfCoreDbContext>();

        context.Set<Bot>().AddRange(Bots);

        context.SaveChanges();
    }

    private static Bot CreateBot(string id, string name, string description, string[] symbols, string side, string platform) =>
        new(
            BotId.From(id).Value,
            BotName.From(name).Value,
            new BotDescription(description),
            symbols.Select(symbol => Symbol.From(symbol).Value).ToArray(),
            Side.FromName(side).Value,
            TradingPlatform.FromName(platform).Value);
}
