using FuncEg.Models;
using FuncEg.Models.Options;
using Microsoft.Extensions.Options;
using SomeLib.Simple;

namespace FuncEg.Services;

public sealed class FunctionAppHealthCheck : IHealthCheck
{
    private readonly ISimpleService _simpleService;
    private readonly FuncEgOptions _options;

    public FunctionAppHealthCheck(IOptions<FuncEgOptions> options, ISimpleService simpleService)
    {
        _simpleService = simpleService;
        ArgumentNullException.ThrowIfNull(options);
        _options = options.Value;
    }
    
    public HealthResponse CheckHealth() =>
        new()
        {
            ApplicationName = _simpleService.Process(_options.ApplicationName),
            Version = _options.Version,
            IsHealthy = true,
            HealthDescription = ""
        };
}