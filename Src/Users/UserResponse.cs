namespace RichillCapital.Identity.Api.Endpoints.Users;

public sealed record UserResponse(
    string Id,
    string Email,
    string Name);