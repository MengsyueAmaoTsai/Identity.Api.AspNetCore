using Microsoft.AspNetCore.Mvc;

namespace RichillCapital.Identity.Api.Endpoints.Users;

public sealed record GetUserByIdRequest
{
    [FromRoute(Name = "userId")]
    public string UserId { get; init; } = string.Empty;
}