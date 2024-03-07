using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Domain;

public sealed class Bot : Entity<BotId>
{
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
