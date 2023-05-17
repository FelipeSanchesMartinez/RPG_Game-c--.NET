namespace RpgGame.Models
{
    public class PartidaJogador : Entidade
    {
        public string Nome { get; set; }
        public long PersonagemId { get; set; }
        public int Vida { get; set; }
        public bool PrimeiroTurno { get; set; }
        public int ResultadoDadoPrimeiroTurno { get; set; }


        public Personagem Personagem { get; set; }
        public Partida Partida1 { get; set; }
        public Partida Partida2 { get; set; }
        public Partida PartidaTurno { get; set; }
        public Partida PartidaVencedor { get; set; }
        public List<PartidaLog> Logs { get; set; }
    }
}
