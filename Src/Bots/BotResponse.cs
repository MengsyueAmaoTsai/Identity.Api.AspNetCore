namespace RichillCapital.Identity.Api.Endpoints.Bots;

public sealed record BotResponse(
    string Id,
    string Name,
    string Description,
    string Side,
    string Platform,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt);