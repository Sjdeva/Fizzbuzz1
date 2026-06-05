using Moq;
using Xunit;
using System.Collections.Generic;
using MyApi.Core.Models;
using MyApi.Core.Services;

namespace MyApi.Tests.Services
{
    public class FizzBuzzProcessorTests
    {
        [Fact]
        public void ProcessArray_Should_ReturnEmptyList_WhenInputIsEmpty()
        {
            // Arrange
            var mockFactory = new Mock<IFizzBuzzStrategyFactory>();
            var processor = new FizzBuzzProcessor(mockFactory.Object);

            // Act
            var result = processor.ProcessArray(System.Array.Empty<string>());

            // Assert
            Assert.Empty(result);
        }
    }
}