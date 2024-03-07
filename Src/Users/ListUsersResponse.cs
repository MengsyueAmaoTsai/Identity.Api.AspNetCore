namespace RichillCapital.Identity.Api.Endpoints.Users;

public record PagedListResponse<T>(
    IEnumerable<T> Items,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);