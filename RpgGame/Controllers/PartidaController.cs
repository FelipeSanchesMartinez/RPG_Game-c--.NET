using Microsoft.AspNetCore.Mvc;
using RpgGame.Models;
using RpgGame.Services;

namespace RpgGame.Controllers
{
    [ApiController]
    [Route("/partida")]
    public class PartidaController : ControllerBase
    {
        private readonly IPartidaService _partidaService;

        public PartidaController(IPartidaService partidaService)
        {
            _partidaService = partidaService;
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            List<Partida> dados = _partidaService.ObterTodos();
            return Ok(dados);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(long id)
        {
            Partida dado = _partidaService.ObterPorId(id);
            return Ok(dado);
        }

        [HttpGet("{id}/logs")]
        public IActionResult ObterLogsPorPartidaId(long id)
        {
            List<PartidaLog> dados = _partidaService.ObterLogsPorPartidaId(id);
            return Ok(dados);
        }


        [HttpPost("novo-jogo")]
        public IActionResult NovoJogo(string jogador1Nome, long personagem1Id, string jogador2Nome, long personagem2Id)
        {

            var partida = _partidaService.NovaPartida(jogador1Nome, personagem1Id, jogador2Nome, personagem2Id);
            return Ok(partida);
        }

        [HttpPost("{partidaId}/turno-ataque")]
        public IActionResult TurnoAtaque(long partidaId)
        {

            var partida = _partidaService.TurnoAtaque(partidaId);
            return Ok(partida);
        }

        [HttpPost("{partidaId}/turno-defesa")]
        public IActionResult TurnoDefesa(long partidaId)
        {

            var partida = _partidaService.TurnoDefesa(partidaId);
            return Ok(partida);
        }

        [HttpPost("{partidaId}/calc-dano")]
        public IActionResult CalcularDano(long partidaId)
        {

            var partida = _partidaService.CalcularDano(partidaId);
            return Ok(partida);
        }
    }
}
