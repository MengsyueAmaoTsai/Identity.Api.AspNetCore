using RichillCapital.Domain;

namespace RichillCapital.UseCases.Bots;

internal sealed class BotCreatedDomainEventHandler() :
    IDomainEventHandler<BotCreatedDomainEvent>
{
    public Task Handle(
        BotCreatedDomainEvent domainEvent,
        CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}