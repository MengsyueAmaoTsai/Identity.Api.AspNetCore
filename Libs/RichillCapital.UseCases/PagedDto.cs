namespace RichillCapital.UseCases;

public sealed record class PagedDto<T>(IEnumerable<T> Items);
