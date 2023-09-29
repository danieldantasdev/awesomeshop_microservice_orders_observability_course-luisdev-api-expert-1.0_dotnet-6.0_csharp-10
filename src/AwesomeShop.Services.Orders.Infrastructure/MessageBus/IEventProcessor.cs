using AwesomeShop.Services.Orders.Domain.Events;

namespace AwesomeShop.Services.Orders.Infrastructure.MessageBus;

public interface IEventProcessor
{
    Task Process(IEnumerable<object> events);
}