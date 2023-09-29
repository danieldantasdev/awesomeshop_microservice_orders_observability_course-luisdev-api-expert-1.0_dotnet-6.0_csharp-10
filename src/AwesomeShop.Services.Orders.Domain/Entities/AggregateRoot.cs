using AwesomeShop.Services.Orders.Domain.Events;

namespace AwesomeShop.Services.Orders.Domain.Entities;

public abstract class AggregateRoot : IEntityBase
{
    private readonly List<object> _events = new List<object>();
    public Guid Id { get; protected set; }
    public IEnumerable<object> Events => _events;

    protected void AddEvent(object @event) {
        _events.Add(@event);
    }
}