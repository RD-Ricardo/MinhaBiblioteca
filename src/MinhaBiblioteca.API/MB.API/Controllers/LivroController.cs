using MB.Application.Commands.Livro.CadastrarLivro;
using MB.Core.Communication.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace MB.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivroController : Controller
    {
        private readonly IMediatorHandler _mediatorHandler;
        public LivroController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }
        [HttpPost("CadastrarLivro")]
        public async Task<IActionResult> Cadastrar(CadastrarLivroCommand command)
        {
            var response = await _mediatorHandler.SendCommandAsync<CadastrarLivroCommand, bool>(command);

            if (!response.Success) return BadRequest(response);

            return Ok(response);
        }
    }
}
