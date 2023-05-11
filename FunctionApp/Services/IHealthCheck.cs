using FuncEg.Models;

namespace FuncEg.Services;

public interface IHealthCheck
{
    HealthResponse CheckHealth();
}