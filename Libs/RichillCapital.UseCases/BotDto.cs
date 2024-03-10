using RichillCapital.Domain;

namespace RichillCapital.UseCases;

public sealed record BotDto(
    string Id,
    string Name,
    string Description,
    string[] Symbols,
    string Side,
    string Platform)
{
    public static BotDto FromDomain(Bot bot) =>
        new BotDto(
            bot.Id.Value,
            bot.Name.Value,
            bot.Description.Value,
            bot.Symbols
                .Select(symbol => symbol.Value)
                .ToArray(),
            bot.Side.Name,
            bot.Platform.Name);
}
