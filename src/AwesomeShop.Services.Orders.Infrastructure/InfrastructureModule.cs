using AwesomeShop.Services.Orders.Domain.Repositories;
using AwesomeShop.Services.Orders.Infrastructure.MessageBus;
using AwesomeShop.Services.Orders.Infrastructure.Persistence;
using AwesomeShop.Services.Orders.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;
using RabbitMQ.Client;

namespace AwesomeShop.Services.Orders.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services
            .AddMongo()
            .AddRepositories();

        services.AddTransient<IEventProcessor, EventProcessor>();

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services) {
        services.AddScoped<IOrderRepository, OrderRepository>();

        return services;
    }

    private static IServiceCollection AddMongo(this IServiceCollection services) {
        services.AddSingleton(sp => {
            var configuration = sp.GetService<IConfiguration>();
            var options = new MongoDbOptions();

            configuration.GetSection("Mongo").Bind(options);

            return options;
        });

        services.AddSingleton<IMongoClient>(sp => {
            var options = sp.GetService<MongoDbOptions>();
            return new MongoClient(options.ConnectionString);
        });

        services.AddTransient(sp => {
            BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;
                
            var options = sp.GetService<MongoDbOptions>();
            var mongoClient = sp.GetService<IMongoClient>();

            return mongoClient.GetDatabase(options.Database);
        });

        return services;
    }
}