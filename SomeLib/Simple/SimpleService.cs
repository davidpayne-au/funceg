namespace SomeLib.Simple;

public sealed class SimpleService : ISimpleService
{
    public string Process(string param) => param.ToUpper();
}