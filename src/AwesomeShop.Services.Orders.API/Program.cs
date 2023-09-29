using AwesomeShop.Services.Orders.API.Extensions;
using AwesomeShop.Services.Orders.Application;
using AwesomeShop.Services.Orders.Infrastructure;
using AwesomeShop.Services.Orders.Infrastructure.Logging;
using Elastic.Apm.Api;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.AddSerilog(builder.Configuration, "API Orders");
    Log.Information("Getting the motors running...");

    builder.Configuration.AddEnvironmentVariables();

    builder.Services.AddInfrastructure();
    builder.Services.AddMassTransitExtension(builder.Configuration);
    builder.Services.AddApplication();
    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddHttpContextAccessor();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseSerilog();

    app.UseHttpsRedirection();
    app.UseAuthorization();

    app.MapControllers();

    await app.RunAsync();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.Information("Server Shutting down...");
    Log.CloseAndFlush();
}
