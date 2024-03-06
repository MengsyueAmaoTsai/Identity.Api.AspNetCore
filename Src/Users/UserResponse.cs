namespace RichillCapital.Identity.Api.Users;

public sealed record UserResponse(
    string Id, 
    string Email, 
    string Name);