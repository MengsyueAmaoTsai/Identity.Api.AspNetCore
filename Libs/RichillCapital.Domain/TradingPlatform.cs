using RichillCapital.SharedKernel;

namespace RichillCapital.Domain;

public sealed class TradingPlatform : Enumeration<TradingPlatform>
{
    public static readonly TradingPlatform TradingView = new(nameof(TradingView), 1);

    private TradingPlatform(string name, int value) 
        : base(name, value)
    {
    }
}
