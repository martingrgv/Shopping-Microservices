namespace Ordering.Domain.Abstractions;

public interface IAggregate<TId> : IAggregate, IEntity<TId>
{
}

public interface IAggregate
{
    IReadOnlyList<IDomainEvent> DomainEvents { get; }
    IDomainEvent[] ClearDomainEvents();
}