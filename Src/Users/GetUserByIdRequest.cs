using Microsoft.AspNetCore.Mvc;

namespace RichillCapital.Identity.Api.Users;

public sealed record GetUserByIdRequest
{
    [FromRoute(Name = "userId")]
    public string UserId { get; init; } = string.Empty;
}