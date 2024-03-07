namespace RichillCapital.Persistence;

public sealed record class PersistenceOptions
{
    public MsSqlOptions MsSqlOptions { get; init; } = new(string.Empty);
}

public sealed record MsSqlOptions(string ConnectionString);