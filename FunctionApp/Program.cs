using FuncEg;
using Microsoft.Extensions.Hosting;
using SomeLib;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices((context, services) =>
    {
        services.AddSomeLibServices(context.Configuration);
        services.AddServices(context.Configuration);
    })
    .Build();

host.Run();
