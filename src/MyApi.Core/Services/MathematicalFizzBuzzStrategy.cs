using MyApi.Core.Constants;
using MyApi.Core.Models;

namespace MyApi.Core.Services
{
    public class MathematicalFizzBuzzStrategy : IFizzBuzzStrategy
    {
        public bool CanHandle(string? input) => 
            int.TryParse(input, out int num) && 
            (num % BusinessConstants.FirstDivisor == 0 || num % BusinessConstants.SecondDivisor == 0);

        public FizzBuzzItemResult Execute(string? input)
        {
            int.TryParse(input, out int number);
            var result = new FizzBuzzItemResult { Input = input ?? "" };

            bool isDivisibleByThree = number % BusinessConstants.FirstDivisor == 0;
            bool isDivisibleByFive = number % BusinessConstants.SecondDivisor == 0;

            if (isDivisibleByThree && isDivisibleByFive) 
                result.Output.Add(BusinessConstants.FizzBuzzResult);
            else if (isDivisibleByThree) 
                result.Output.Add(BusinessConstants.FizzResult);
            else 
                result.Output.Add(BusinessConstants.BuzzResult);

            return result;
        }
    }
}