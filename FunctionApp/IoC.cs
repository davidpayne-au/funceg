using FuncEg.Models.Options;
using FuncEg.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FuncEg;

public static class IoC
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);
        services.Configure<FuncEgOptions>(configuration.GetSection(FuncEgOptions.OptionsKey));
        services.AddTransient<IHealthCheck, FunctionAppHealthCheck>();
        return services;
    }
}