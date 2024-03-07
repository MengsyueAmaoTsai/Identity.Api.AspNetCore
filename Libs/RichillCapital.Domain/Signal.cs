using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Domain;

public sealed class Signal : ValueObject
{
    private Signal(
        DateTimeOffset time,
        TradeType tradeType,
        Symbol symbol,
        decimal quantity,
        decimal price,
        BotId botId)
    {
        Time = time;
        TradeType = tradeType;
        Symbol = symbol;
        Quantity = quantity;
        Price = price;
        BotId = botId;
    }

    public DateTimeOffset Time { get; private init; }

    public TradeType TradeType { get; private init; }

    public Symbol Symbol { get; private init; }

    public decimal Quantity { get; private init; }

    public decimal Price { get; private init; }

    public BotId BotId { get; private init; }

    public static ErrorOr<Signal> Create(
        DateTimeOffset time,
        TradeType tradeType,
        Symbol symbol,
        decimal quantity,
        decimal price,
        BotId botId)
    {
        return new Signal(
            time,
            tradeType,
            symbol,
            quantity,
            price,
            botId)
            .ToErrorOr();
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Time;
        yield return TradeType;
        yield return Symbol;
        yield return Quantity;
        yield return Price;
        yield return BotId;
    }
}
