using Elastic.Apm.NetCoreAll;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace AwesomeShop.Services.Orders.Infrastructure.Logging;
public static class ElasticsearchExtensions
{
    public static void UseElasticApm(this IApplicationBuilder app, IConfiguration configuration)
    {
        //https://www.elastic.co/guide/en/apm/agent/dotnet/current/configuration-on-asp-net-core.html
        app.UseAllElasticApm(configuration);
    }
}
