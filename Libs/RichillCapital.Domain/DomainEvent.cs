using RichillCapital.SharedKernel;

namespace RichillCapital.Domain;

public abstract record class DomainEvent : IDomainEvent
{
    public DateTimeOffset OccurredTime { get; private init; } = DateTimeOffset.UtcNow;
}