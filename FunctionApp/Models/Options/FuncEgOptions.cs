namespace FuncEg.Models.Options;

public record FuncEgOptions
{
    public const string OptionsKey = nameof(FuncEgOptions);
    public string Version { get; set; } = "";
    public string ApplicationName { get; set; } = "";
}