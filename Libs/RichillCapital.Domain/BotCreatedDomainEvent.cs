namespace RichillCapital.Domain;

public sealed record class BotCreatedDomainEvent(BotId BotId) : DomainEvent;