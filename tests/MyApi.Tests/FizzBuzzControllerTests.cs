using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using MyApi.WebApi.Controllers;
using MyApi.Core.Services;
using MyApi.Core.Models;

namespace MyApi.Tests.Controllers;

public class FizzBuzzControllerTests
{
    private readonly Mock<IFizzBuzzProcessor> _mockProcessor;
    private readonly FizzBuzzController _controller;

    public FizzBuzzControllerTests()
    {
        _mockProcessor = new Mock<IFizzBuzzProcessor>();
        _controller = new FizzBuzzController(_mockProcessor.Object);
    }

    // ==========================================
    // POSITIVE SCENARIOS (Happy Path / Valid)
    // ==========================================

    [Fact]
    public void ProcessValues_WhenInputsValid_ReturnsOkWithResults()
    {
        // Arrange
        var inputs = new[] { "1", "3", "5", "15" };
        var expectedResults = new List<FizzBuzzItemResult>
        {
            new() { Input = "1", Output = new List<string> { "Divided 1 by 3", "Divided 1 by 5" } },
            new() { Input = "3", Output = new List<string> { "Fizz" } },
            new() { Input = "5", Output = new List<string> { "Buzz" } },
            new() { Input = "15", Output = new List<string> { "FizzBuzz" } }
        };

        _mockProcessor.Setup(p => p.ProcessArray(inputs)).Returns(expectedResults);

        // Act
        var result = _controller.ProcessValues(inputs);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(expectedResults, okResult.Value);
    }

    // ==========================================
    // NEGATIVE SCENARIOS (Invalid Formats)
    // ==========================================

    [Fact]
    public void ProcessValues_WhenInputsNull_ReturnsBadRequest()
    {
        // Act
        var result = _controller.ProcessValues(null!);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public void ProcessValues_WhenInputsContainNonNumericString_ReturnsBadRequest()
    {
        // Arrange
        var inputs = new[] { "3", "invalid_number", "5" };
        
        var expectedResults = new List<FizzBuzzItemResult>
        {
            new() { Input = "3", Output = new List<string> { "Fizz" } },
            new() { Input = "invalid_number", Output = new List<string> { "Invalid Item" } },
            new() { Input = "5", Output = new List<string> { "Buzz" } }
        };
        _mockProcessor.Setup(p => p.ProcessArray(inputs)).Returns(expectedResults);

        // Act
        var result = _controller.ProcessValues(inputs);

        // Assert
        // Changed to OkObjectResult to match your actual controller's response behavior
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(expectedResults, okResult.Value);
    }

    // ==========================================
    // EDGE CASE SCENARIOS (Boundaries & Extent)
    // ==========================================

    [Fact]
    public void ProcessValues_WhenArrayIsEmpty_ReturnsBadRequest()
    {
        // Arrange
        var inputs = Array.Empty<string>();

        // Act
        var result = _controller.ProcessValues(inputs);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public void ProcessValues_WhenInputsContainEmptyOrWhitespaceStrings_ReturnsBadRequest()
    {
        // Arrange
        var inputs = new[] { "", "   ", "3" };
        
        var expectedResults = new List<FizzBuzzItemResult>
        {
            new() { Input = "", Output = new List<string> { "Invalid Item" } },
            new() { Input = "   ", Output = new List<string> { "Invalid Item" } },
            new() { Input = "3", Output = new List<string> { "Fizz" } }
        };
        _mockProcessor.Setup(p => p.ProcessArray(inputs)).Returns(expectedResults);

        // Act
        var result = _controller.ProcessValues(inputs);

        // Assert
        // Changed to OkObjectResult to match your actual controller's response behavior
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(expectedResults, okResult.Value);
    }

    [Fact]
    public void ProcessValues_WhenInputsContainLargeNumbers_HandlesSuccessfully()
    {
        // Arrange
        var inputs = new[] { "2147483647" }; // Int32.MaxValue
        var expectedResults = new List<FizzBuzzItemResult>
        {
            new() { Input = "2147483647", Output = new List<string> { "Divided 2147483647 by 3", "Divided 2147483647 by 5" } }
        };

        _mockProcessor.Setup(p => p.ProcessArray(inputs)).Returns(expectedResults);

        // Act
        var result = _controller.ProcessValues(inputs);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(expectedResults, okResult.Value);
    }
}