using AwesomeShop.Services.Orders.Domain.Events;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace AwesomeShop.Services.Orders.Application.Subscribers;

public class PaymentAcceptedSubscriber : IConsumer<OrderCreated>
{
    private readonly ILogger<PaymentAcceptedSubscriber> _logger;

    public PaymentAcceptedSubscriber(ILogger<PaymentAcceptedSubscriber> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<OrderCreated> context)
    {
        _logger.LogInformation($"Email successfully sent: {context.Message.Email}");
    }

    public class PaymentAcceptedSubscriberDefinition : ConsumerDefinition<PaymentAcceptedSubscriber>
    {
        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<PaymentAcceptedSubscriber> consumerConfigurator)
        {
            consumerConfigurator.UseMessageRetry(retry => retry.Interval(3, TimeSpan.FromSeconds(3)));
        }
    }
}
