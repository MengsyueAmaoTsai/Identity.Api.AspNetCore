using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Domain;

public sealed class Bot : Entity<BotId>
{
    private Bot(
        BotId id,
        BotName name,
        BotDescription description,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
        : base(id)
    {
        Name = name;
        Description = description;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public BotName Name { get; private set; }

    public BotDescription Description { get; private set; }

    public DateTimeOffset CreatedAt { get; private set; }

    public DateTimeOffset UpdatedAt { get; private set; }

    public static ErrorOr<Bot> Create(
        BotId id,
        BotName name,
        BotDescription description)
    {
        var now = DateTimeOffset.UtcNow;

        return new Bot(id, name, description, now, now)
            .ToErrorOr();
    }
}
