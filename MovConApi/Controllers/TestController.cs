using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MovConApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [SwaggerOperation(
            Summary = "Teste",
            Description = "Teste.",
            Tags = new[] { "Test" }
        )]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Test()
        {
            return Ok("Test OK");
        }
    }
}
