using System.Collections.Generic;
using MyApi.Core.Models;

namespace MyApi.Core.Services
{
    public interface IFizzBuzzProcessor 
    { 
        List<FizzBuzzItemResult> ProcessArray(string[] inputs); 
    }

    public class FizzBuzzProcessor : IFizzBuzzProcessor
    {
        private readonly IFizzBuzzStrategyFactory _factory;
        public FizzBuzzProcessor(IFizzBuzzStrategyFactory factory) => _factory = factory;

        public List<FizzBuzzItemResult> ProcessArray(string[] inputs)
        {
            var results = new List<FizzBuzzItemResult>();
            if (inputs == null || inputs.Length == 0) return results;

            foreach (var input in inputs)
            {
                results.Add(_factory.GetStrategy(input).Execute(input));
            }
            return results;
        }
    }
}