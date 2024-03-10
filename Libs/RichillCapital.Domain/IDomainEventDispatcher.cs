using RichillCapital.SharedKernel;

namespace RichillCapital.Domain;

public interface IDomainEventDispatcher
{
    Task DispatchAndClearDomainEvents(IEnumerable<IEntity> entities);

    Task DispatchAndClearDomainEvents(IEntity entity);
}