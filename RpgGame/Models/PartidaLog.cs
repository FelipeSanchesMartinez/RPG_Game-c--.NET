using RpgGame.Enums;

namespace RpgGame.Models
{
    public class PartidaLog : Entidade
    {
        public long PartidaId { get; set; }
        public long PartidaJogadorId { get; set; }
        public PartidaTurno Turno { get; set; }
        public int DadoResultado { get; set; }
        public int Resultado { get; set; }
        public int Atributo { get; set; }
        public int Agilidade { get; set; }
        public bool Defendeu { get; set; }
        public int? DanoDadoResultado { get; set; }
        public int? Dano { get; set; }
        public int DanoTotal { get; set; }


        public Partida Partida { get; set; }
        public PartidaJogador Jogador { get; set; }
    }
}
