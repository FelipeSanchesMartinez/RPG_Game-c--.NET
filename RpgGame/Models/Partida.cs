using RpgGame.Enums;

namespace RpgGame.Models
{
    public class Partida : Entidade
    {
        public long PartidaJogador1Id { get; set; }
        public long PartidaJogador2Id { get; set; }
        public long PartidaJogadorTurnoId { get; set; }
        public long? PartidaJogadorVencedorId { get; set; }
        public PartidaTurno Turno { get; set; }
        public bool Finalizado { get; set; }


        public PartidaJogador Jogador1 { get; set; }
        public PartidaJogador Jogador2 { get; set; }
        public PartidaJogador JogadorTurno { get; set; }
        public PartidaJogador JogadorVencedor { get; set; }
        public List<PartidaLog> Logs { get; set; }


    }
}
