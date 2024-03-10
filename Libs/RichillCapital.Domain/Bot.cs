using RichillCapital.SharedKernel;

namespace RichillCapital.Domain;

public sealed class Bot : Entity<BotId>
{
    public Bot(
        BotId id, 
        BotName name, 
        BotDescription description, 
        Symbol[] symbols, 
        Side side, 
        TradingPlatform platform) 
        : base(id)
    {
        Name = name;
        Description = description;
        Symbols = symbols;
        Side = side;
        Platform = platform;
    }

    public BotName Name { get; private set; }

    public BotDescription Description { get; private set; }

    public Symbol[] Symbols { get; private set; }

    public Side Side { get; private set; }

    public TradingPlatform Platform { get; private set; }
}
