using JobCode.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobCode.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public IActionResult Register([FromBody] UserModel user)
        {
            if (user == null)
                return BadRequest("O objeto de usuário é obrigatório.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Validação do tipo de usuário e propriedades
           

            // Hash da senha antes de salvar

            try
            {
                //_context.Users.Add(user);
                //_context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status201Created, new
                {
                   Message = "Usuário registrado com sucesso!"
                });
            }
            catch (Exception ex)
            {
                // Log do erro (use um logger como ILogger em produção)
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao registrar usuário: {ex.Message}");
            }
        }
    }
}
