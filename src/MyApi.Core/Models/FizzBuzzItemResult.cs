using System.Collections.Generic;

namespace MyApi.Core.Models
{
    public class FizzBuzzItemResult
    {
        public string Input { get; set; } = string.Empty;
        public List<string> Output { get; set; } = new();
    }
}