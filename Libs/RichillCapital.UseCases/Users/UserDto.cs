namespace RichillCapital.UseCases.Users;

public sealed record UserDto(
    string Id,
    string Email,
    string Password,
    string Name);
