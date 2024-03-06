namespace RichillCapital.UseCases;

public sealed record PagedDto<T>(IEnumerable<T> Items);
