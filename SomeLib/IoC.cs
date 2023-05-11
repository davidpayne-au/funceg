using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SomeLib.Simple;

namespace SomeLib;


public static class IoC
{
    public static IServiceCollection AddSomeLibServices(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);
        services.AddSingleton<ISimpleService,SimpleService>();
        return services;
    }
}