namespace RichillCapital.Contracts;

public sealed record CreateBotRequest
{
    public string Id { get; init; } = string.Empty;

    public string Name { get; init; } = string.Empty;

    public string Description { get; init; } = string.Empty;

    public string[] Symbols { get; init; } = [];

    public string Side { get; init; } = string.Empty;

    public string Platform { get; init; } = string.Empty;
}