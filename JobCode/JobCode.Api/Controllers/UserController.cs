using JobCode.Application.Commands.InsertUser;
using JobCode.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobCode.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] InsertUserCommand model)
        {
            if (model == null)
            {
                return BadRequest("Invalid user data");
            }

            var result = await _mediator.Send(model);

            if (result.IsFailure)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(RegisterAsync), new { message = result.Message });
        }
    }
}
