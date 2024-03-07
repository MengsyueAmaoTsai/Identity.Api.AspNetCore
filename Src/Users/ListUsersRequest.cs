using Microsoft.AspNetCore.Mvc;

namespace RichillCapital.Identity.Api.Endpoints.Users;
public sealed record ListUsersRequest
{
    [FromQuery(Name = "page")]
    public int Page { get; init; } = default;

    [FromQuery(Name = "pageSize")]
    public int PageSize { get; init; } = default;
}