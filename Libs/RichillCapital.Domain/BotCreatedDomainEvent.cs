namespace RichillCapital.Domain;

internal sealed record class BotCreatedDomainEvent(BotId BotId) : DomainEvent;