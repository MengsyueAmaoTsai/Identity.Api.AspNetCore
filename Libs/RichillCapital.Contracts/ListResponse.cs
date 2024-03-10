namespace RichillCapital.Contracts;

public sealed record ListResponse<T>(
    IEnumerable<T> Items);