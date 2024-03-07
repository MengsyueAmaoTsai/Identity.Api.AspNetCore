namespace RichillCapital.Identity.Api.Endpoints.Users;

public sealed record ListUsersResponse(IEnumerable<UserResponse> Users);