namespace RichillCapital.UseCases;

internal sealed record PagedDto<T>(IEnumerable<T> Items);
