using MyApi.Core.Constants;
using MyApi.Core.Models;

namespace MyApi.Core.Services
{
    public class InvalidInputStrategy : IFizzBuzzStrategy
    {
        public bool CanHandle(string? input) => 
            string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out _);

        public FizzBuzzItemResult Execute(string? input) => new()
        {
            Input = string.IsNullOrEmpty(input) ? BusinessConstants.EmptyInputPlaceholder : input,
            Output = new() { BusinessConstants.InvalidInputResult }
        };
    }
}