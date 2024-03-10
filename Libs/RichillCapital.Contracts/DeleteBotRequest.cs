using Microsoft.AspNetCore.Mvc;

namespace RichillCapital.Contracts;

public sealed record DeleteBotRequest
{
    [FromRoute(Name = "botId")]
    public string Id { get; init; } = string.Empty;
}