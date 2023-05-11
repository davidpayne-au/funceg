using System.Net;
using FuncEg.Models.Options;
using FuncEg.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FuncEg.Functions;

public class Health
{
    private readonly ILogger<Health> _logger;
    private readonly IHealthCheck _healthCheck;
    private readonly FuncEgOptions _options;

    public Health(ILogger<Health> logger, IOptions<FuncEgOptions> options, IHealthCheck healthCheck)
    {
        ArgumentNullException.ThrowIfNull(options);
        _logger = logger;
        _healthCheck = healthCheck;
        _options = options.Value;
    }
    
    [Function(nameof(Health))]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req,
        FunctionContext functionContext)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(functionContext);
            _logger.LogInformation("Health called for {ApplicationName}, Version: {Version}", _options.ApplicationName, _options.Version);
            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(_healthCheck.CheckHealth()).ConfigureAwait(false);
            return response;
        }
        catch (Exception e)
        {
            _logger.LogError("Exception in calling {MethodName}: {ExceptionDescription}", nameof(Health), e.Message);
            throw;
        }
    }
}