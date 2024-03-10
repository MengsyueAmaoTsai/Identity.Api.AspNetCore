namespace RichillCapital.Contracts;

public sealed record BotResponse(
    string Id,
    string Name,
    string Description,
    IEnumerable<string> Symbols,
    string Side,
    string Platform);