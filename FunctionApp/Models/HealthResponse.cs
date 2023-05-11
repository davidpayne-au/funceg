namespace FuncEg.Models;

public sealed record HealthResponse
{
    public string ApplicationName { get; set; } = "";
    public string Version { get; set; } = "";
    public bool IsHealthy { get; set; }
    public string HealthDescription { get; set; } = "";
}