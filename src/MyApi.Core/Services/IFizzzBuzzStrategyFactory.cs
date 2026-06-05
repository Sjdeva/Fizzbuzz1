using System.Collections.Generic;

namespace MyApi.Core.Services
{
    public interface IFizzBuzzStrategyFactory 
    { 
        IFizzBuzzStrategy GetStrategy(string? input); 
    }

    public class FizzBuzzStrategyFactory : IFizzBuzzStrategyFactory
    {
        private readonly IEnumerable<IFizzBuzzStrategy> _strategies;
        public FizzBuzzStrategyFactory(IEnumerable<IFizzBuzzStrategy> strategies) => _strategies = strategies;

        public IFizzBuzzStrategy GetStrategy(string? input)
        {
            foreach (var strategy in _strategies)
            {
                if (strategy.CanHandle(input)) return strategy;
            }
            return new InvalidInputStrategy();
        }
    }
}