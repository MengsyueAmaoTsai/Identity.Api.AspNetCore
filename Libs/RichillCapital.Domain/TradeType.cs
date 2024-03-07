using RichillCapital.SharedKernel;

namespace RichillCapital.Domain;

public sealed class TradeType : Enumeration<TradeType>
{
    public static readonly TradeType Buy = new(nameof(Buy), 1);
    public static readonly TradeType Sell = new(nameof(Sell), -1);

    private TradeType(string name, int value)
        : base(name, value)
    {
    }
}