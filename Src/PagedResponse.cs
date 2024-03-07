namespace RichillCapital.Identity.Api;

public sealed record PagedResponse<T>(IEnumerable<T> Items);