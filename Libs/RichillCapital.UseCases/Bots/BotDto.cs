namespace RichillCapital.UseCases.Bots;

internal sealed record BotDto(
    string Id,
    string Name,
    string Description,
    string Side,
    string Platform,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt);