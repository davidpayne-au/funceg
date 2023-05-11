using FluentAssertions;
using SomeLib.Simple;

namespace SomeTests;

public class SimpleServiceTests
{
    [Theory]
    [InlineData("Hello", "HELLO")]
    [InlineData("", "")]
    [InlineData("HELLO", "HELLO")]
    public void ProcessTest(string param, string expected) =>
        new SimpleService().Process(param).Should().Be(expected);
}