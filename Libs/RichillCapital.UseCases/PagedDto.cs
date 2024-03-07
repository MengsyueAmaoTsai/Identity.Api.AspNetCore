namespace RichillCapital.UseCases;

public sealed record class PagedDto<T>
{
    private readonly List<T> _items;

    public PagedDto(IEnumerable<T> items, int page, int pageSize)
    {
        _items = items.ToList();
        Page = page;
        PageSize = pageSize;
    }

    public IReadOnlyList<T> Items => _items.AsReadOnly();

    public int Page { get; private init; }

    public int PageSize { get; private init; }

    public int TotalCount => _items.Count();

    public bool HasNextPage => Page * PageSize < TotalCount;

    public bool HasPreviousPage => PageSize > 1;
}

