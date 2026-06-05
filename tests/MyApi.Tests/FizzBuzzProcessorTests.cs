using Xunit;
using MyApi.Core.Services;

namespace MyApi.Tests.Services; 

public class FizzBuzzProcessorTests
{
    private readonly FizzBuzzProcessor _processor;

    public FizzBuzzProcessorTests()
    {
        var strategies = new List<IFizzBuzzStrategy>
        {
            new InvalidInputStrategy(),
            new MathematicalFizzBuzzStrategy(),
            new DivisionStepStrategy()
        };
        var factory = new FizzBuzzStrategyFactory(strategies);
        _processor = new FizzBuzzProcessor(factory);
    }

    [Theory]
    [InlineData("3", "Fizz")]
    [InlineData("5", "Buzz")]
    [InlineData("15", "FizzBuzz")]
    public void ProcessArray_WhenMultiples_ReturnsCorrectKeyword(string input, string expectedOutput)
    {
        var result = _processor.ProcessArray(new[] { input });

        Assert.Single(result[0].Output);
        Assert.Equal(expectedOutput, result[0].Output[0]);
    }

    [Fact]
    public void ProcessArray_WhenNotDivisibleByThreeOrFive_ReturnsDivisionSteps()
    {
        var result = _processor.ProcessArray(new[] { "7" });

        Assert.Equal(2, result[0].Output.Count);
        Assert.Equal("Divided 7 by 3", result[0].Output[0]);
        Assert.Equal("Divided 7 by 5", result[0].Output[1]);
    }

    [Theory]
    [InlineData("", "Invalid Item")]
    [InlineData("abc", "Invalid Item")]
    [InlineData("12.34", "Invalid Item")] // Decimals are non-integers
    public void ProcessArray_WhenInvalidInput_ReturnsInvalidItem(string input, string expectedOutput)
    {
        var result = _processor.ProcessArray(new[] { input });

        Assert.Single(result);
        Assert.Contains(expectedOutput, result[0].Output);
    }

    [Fact]
    public void ProcessArray_WhenArrayIsEmpty_ReturnsEmptyResultList()
    {
        var result = _processor.ProcessArray(Array.Empty<string>());

        Assert.Empty(result);
    }

    [Fact]
    public void ProcessArray_WhenInputIsMixedArray_EvaluatesEachElementIndependently()
    {
        var inputs = new[] { "3", "abc", "7" };

        var result = _processor.ProcessArray(inputs);

        Assert.Equal(3, result.Count);
        Assert.Equal("Fizz", result[0].Output[0]);
        Assert.Contains("Invalid Item", result[1].Output);
        Assert.Equal("Divided 7 by 3", result[2].Output[0]);
    }

    [Theory]
    [InlineData("0", "FizzBuzz")] // 0 is mathematically divisible by everything
    [InlineData("-15", "FizzBuzz")] // Negative integers
    [InlineData("2147483647", "Divided 2147483647 by 3")] // Max Int32 boundary
    public void ProcessArray_BoundaryValues_EvaluatesCorrectly(string input, string expectedOutputSubstring)
    {
        var result = _processor.ProcessArray(new[] { input });

        Assert.NotEmpty(result[0].Output);
        Assert.Contains(expectedOutputSubstring, result[0].Output[0]);
    }
}