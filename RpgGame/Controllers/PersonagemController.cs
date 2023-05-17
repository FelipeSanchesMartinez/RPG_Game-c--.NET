using Microsoft.AspNetCore.Mvc;
using RpgGame.Interfaces;
using RpgGame.Models;
using RpgGame.Validations;
using RpgGame.ViewModels;

namespace RpgGame.Controllers
{
    [ApiController]
    [Route("/personagem")]
    public class PersonagemController : ControllerBase
    {
        private readonly IPersonagemService _personagemService;

        public PersonagemController(IPersonagemService personagemService)
        {
            _personagemService = personagemService;
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            List<Personagem> dados = _personagemService.ObterTodos();
            return Ok(dados);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(long id)
        {
            Personagem dado = _personagemService.ObterPorId(id);
            return Ok(dado);
        }

        [HttpPost()]
        public IActionResult Insercao([FromBody] InsertPersonagemViewModel viewModel)
        {

            InsertPersonagemViewModelValidation validation = new InsertPersonagemViewModelValidation();
            var result = validation.Validate(viewModel);

            if (result.IsValid == false)
            {
                var erros = result.Errors.Select(erro => erro.ErrorMessage);
                return BadRequest(erros);
            }


            _personagemService.Insercao(viewModel);
            return Ok(viewModel);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(long id, [FromBody] UpdatePersonagemViewModel viewModel)
        {
            _personagemService.Atualizar(id, viewModel);
            return Ok(viewModel);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(long id)
        {
            _personagemService.Deletar(id);
            return Ok();
        }
    }
}
