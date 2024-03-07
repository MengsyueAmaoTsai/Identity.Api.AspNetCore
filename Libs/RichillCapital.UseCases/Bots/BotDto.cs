using RichillCapital.Domain;

namespace RichillCapital.UseCases.Bots;

internal sealed record BotDto(
    string Id,
    string Name,
    string Description,
    string Side,
    string Platform,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt)
{
    public static BotDto From(Bot bot) =>
        new(
            bot.Id.Value,
            bot.Name.Value,
            bot.Description.Value,
            bot.Side.Name,
            bot.Platform.Name,
            bot.CreatedAt,
            bot.UpdatedAt);
}