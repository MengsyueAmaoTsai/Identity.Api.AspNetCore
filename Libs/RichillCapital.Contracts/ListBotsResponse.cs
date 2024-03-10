namespace RichillCapital.Contracts;

public sealed record ListBotsResponse(
    IEnumerable<BotResponse> Items);
