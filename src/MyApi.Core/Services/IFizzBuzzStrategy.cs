using MyApi.Core.Models;

namespace MyApi.Core.Services
{
    public interface IFizzBuzzStrategy
    {
        bool CanHandle(string? input);
        FizzBuzzItemResult Execute(string? input);
    }
}