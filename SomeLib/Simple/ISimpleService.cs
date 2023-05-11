namespace SomeLib.Simple;

public interface ISimpleService
{
    /// <summary>
    /// Just toUpper a string and return
    /// </summary>
    /// <param name="param">The string to upper case</param>
    /// <returns>an upper case of the string</returns>
    string Process(string param);
}