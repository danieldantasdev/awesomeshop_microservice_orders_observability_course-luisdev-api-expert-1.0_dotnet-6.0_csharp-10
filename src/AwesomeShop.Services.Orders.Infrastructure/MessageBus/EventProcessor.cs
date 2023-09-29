using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwesomeShop.Services.Orders.Domain.Events;
using MassTransit;

namespace AwesomeShop.Services.Orders.Infrastructure.MessageBus;

public class EventProcessor : IEventProcessor
{
    private readonly IPublishEndpoint _publisher;
    public EventProcessor(IPublishEndpoint publisher)
    {
        _publisher = publisher;
    }
        
    public async Task Process(IEnumerable<object> events)
    {
        foreach (var @event in events) {
            await _publisher.Publish(@event);
        }
    }

    public string ToDashCase(string input) {
        var sb = new StringBuilder();
        for (var i = 0; i < input.Length; i++)
            if (i != 0 && char.IsUpper(input[i]))
                sb.Append($"-{input[i]}");
            else
                sb.Append(input[i]);

        return sb.ToString().ToLower();
    }

}