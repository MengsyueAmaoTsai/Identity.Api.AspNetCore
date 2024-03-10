namespace RichillCapital.UseCases;

public record ListDto<T>(IEnumerable<T> Items);
