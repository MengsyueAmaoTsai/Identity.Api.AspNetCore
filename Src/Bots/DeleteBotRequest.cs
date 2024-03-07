using Microsoft.AspNetCore.Mvc;

namespace RichillCapital.Identity.Api.Endpoints.Bots;

public sealed record DeleteBotRequest
{
    [FromRoute(Name = "botId")]
    public string Id { get; init; } = string.Empty;
}