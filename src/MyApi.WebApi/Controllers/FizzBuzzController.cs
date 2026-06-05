using Microsoft.AspNetCore.Mvc;
using MyApi.Core.Services;

namespace MyApi.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FizzBuzzController : ControllerBase
    {
        private readonly IFizzBuzzProcessor _processor;
        public FizzBuzzController(IFizzBuzzProcessor processor) => _processor = processor;

        [HttpPost("process")]
        public IActionResult ProcessValues([FromBody] string[] inputs)
        {
            if (inputs == null || inputs.Length == 0) 
                return BadRequest("Input array cannot be empty.");

            return Ok(_processor.ProcessArray(inputs));
        }
    }
}