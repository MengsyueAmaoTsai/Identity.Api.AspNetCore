
using MediatR;
using RichillCapital.Domain;
using RichillCapital.SharedKernel;

public sealed class MediatorDomainEventDispatcher(IPublisher _publisher) :
    IDomainEventDispatcher
{
    public async Task DispatchAndClearDomainEvents(IEnumerable<IEntity> entities)
    {
        foreach (var entity in entities)
        {
            await DispatchAndClearDomainEvents(entity);
        }
    }

    public async Task DispatchAndClearDomainEvents(IEntity entity)
    {
        var events = entity
            .GetDomainEvents()
            .ToArray();

        entity.ClearDomainEvents();

        foreach (var domainEvent in events)
        {
            await _publisher
                .Publish(domainEvent)
                .ConfigureAwait(false);
        }
    }
}