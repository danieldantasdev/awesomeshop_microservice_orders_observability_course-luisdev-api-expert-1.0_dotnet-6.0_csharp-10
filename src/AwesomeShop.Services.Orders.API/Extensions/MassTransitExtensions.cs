using AwesomeShop.Services.Orders.Application.Subscribers;
using MassTransit;

namespace AwesomeShop.Services.Orders.API.Extensions;
public static class MassTransitExtensions
{
    public static void AddMassTransitExtension(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<PaymentAcceptedSubscriber>(typeof(PaymentAcceptedSubscriber.PaymentAcceptedSubscriberDefinition));

            x.SetKebabCaseEndpointNameFormatter();

            x.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host(configuration.GetConnectionString("RabbitMq"));

                cfg.ServiceInstance(instance =>
                {
                    instance.ConfigureEndpoints(ctx, new KebabCaseEndpointNameFormatter("dev", false));
                });
            });
        });
    }
}
