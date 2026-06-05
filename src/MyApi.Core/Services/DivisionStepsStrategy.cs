using MyApi.Core.Constants;
using MyApi.Core.Models;

namespace MyApi.Core.Services
{
    public class DivisionStepStrategy : IFizzBuzzStrategy
    {
        public bool CanHandle(string? input) => 
            int.TryParse(input, out int num) && 
            num % BusinessConstants.FirstDivisor != 0 && 
            num % BusinessConstants.SecondDivisor != 0;

        public FizzBuzzItemResult Execute(string? input)
        {
            int.TryParse(input, out int number);
            return new()
            {
                Input = input ?? "",
                Output = new() 
                { 
                    $"Divided {number} by {BusinessConstants.FirstDivisor}", 
                    $"Divided {number} by {BusinessConstants.SecondDivisor}" 
                }
            };
        }
    }
}