namespace RichillCapital.Identity.Api.Users;

public sealed record ListUsersResponse(IEnumerable<UserResponse> Users);