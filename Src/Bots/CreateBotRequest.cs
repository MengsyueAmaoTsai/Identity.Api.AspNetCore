namespace RichillCapital.Identity.Api.Endpoints.Bots;

public sealed record CreateBotRequest
{
    /// <summary>
    /// The id of the bot.
    /// </summary>
    public string Id { get; init; } = string.Empty;

    /// <summary>
    /// The name of the bot.
    /// </summary>
    public string Name { get; init; } = string.Empty;

    /// <summary>
    /// The description of the bot.
    /// </summary>
    public string Description { get; init; } = string.Empty;

    /// <summary>
    /// The side of the bot.
    /// </summary>
    public string Side { get; init; } = string.Empty;

    /// <summary>
    /// The platform of the bot.
    /// </summary>
    public string Platform { get; init; } = string.Empty;
}
