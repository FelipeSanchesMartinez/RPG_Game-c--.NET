using RpgGame.Models;

namespace RpgGame.Services
{
    public interface IPartidaService
    {
        Partida CalcularDano(long partidaId);
        Partida NovaPartida(string nomeJogador1, long personagem1Id, string nomeJogador2, long personagem2Id);
        List<PartidaLog> ObterLogsPorPartidaId(long partidaId);
        Partida ObterPorId(long id);
        List<Partida> ObterTodos();
        Partida TurnoAtaque(long partidaId);
        Partida TurnoDefesa(long partidaId);
    }
}