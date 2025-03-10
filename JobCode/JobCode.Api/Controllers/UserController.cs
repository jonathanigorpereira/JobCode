﻿using JobCode.Application.Commands.InsertUser;
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
            try
            {
                var result = await _mediator.Send(model);

                if(result.IsFailure)
                   return BadRequest(StatusCode(StatusCodes.Status406NotAcceptable, result.Message));

                return Ok(StatusCode(StatusCodes.Status201Created, result.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao registrar usuário: {ex.Message}");
            }
        }
    }
}
