using Microsoft.AspNetCore.Mvc;

namespace RichillCapital.Contracts;

public sealed record GetBotByIdRequest
{
    [FromRoute(Name = "botId")]
    public string Id { get; init; } = string.Empty;
}