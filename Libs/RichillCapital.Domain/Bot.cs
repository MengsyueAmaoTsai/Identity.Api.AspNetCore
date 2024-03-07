using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Domain;

public sealed class Bot : Entity<BotId>
{
    private readonly List<Signal> _signals = new();

    private Bot(
        BotId id,
        BotName name,
        BotDescription description,
        Side side,
        TradingPlatform platform,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
        : base(id)
    {
        Name = name;
        Description = description;
        Side = side;
        Platform = platform;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public BotName Name { get; private set; }

    public BotDescription Description { get; private set; }

    public Side Side { get; private set; }

    public TradingPlatform Platform { get; private set; }

    public DateTimeOffset CreatedAt { get; private set; }

    public DateTimeOffset UpdatedAt { get; private set; }

    public IReadOnlyList<Signal> Signals => _signals.AsReadOnly();

    public static ErrorOr<Bot> Create(
        BotId id,
        BotName name,
        BotDescription description,
        Side side,
        TradingPlatform platform)
    {
        var now = DateTimeOffset.UtcNow;

        var bot = new Bot(
            id,
            name,
            description,
            side,
            platform,
            now,
            now);

        bot.RegisterDomainEvent(new BotCreatedDomainEvent(bot.Id));

        return bot
            .ToErrorOr();
    }

    public void WithName(BotName name)
    {
        throw new NotImplementedException();
    }

    public void WithDescription(BotDescription description)
    {
        throw new NotImplementedException();
    }
}

public sealed class Signal : ValueObject
{
    private Signal(
        DateTimeOffset time,
        TradeType tradeType,
        Symbol symbol,
        decimal quantity,
        decimal price)
    {
        Time = time;
        TradeType = tradeType;
        Symbol = symbol;
        Quantity = quantity;
        Price = price;
    }

    public DateTimeOffset Time { get; private init; }

    public TradeType TradeType { get; private init; }

    public Symbol Symbol { get; private init; }

    public decimal Quantity { get; private init; }

    public decimal Price { get; private init; }

    public static ErrorOr<Signal> Create(
        DateTimeOffset time,
        TradeType tradeType,
        Symbol symbol,
        decimal quantity,
        decimal price)
    {
        return new Signal(
            time,
            tradeType,
            symbol,
            quantity,
            price)
            .ToErrorOr();
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Time;
        yield return TradeType;
        yield return Symbol;
        yield return Quantity;
        yield return Price;
    }
}
