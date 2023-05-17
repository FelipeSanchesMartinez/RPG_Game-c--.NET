using RpgGameSite.Enums;

namespace RpgGameSite.ViewModels
{
    public class PartidaViewModel
    {
        public long Id { get; set; }
        public long PartidaJogador1Id { get; set; }
        public long PartidaJogador2Id { get; set; }
        public long PartidaJogadorTurnoId { get; set; }
        public long? PartidaJogadorVencedorId { get; set; }
        public PartidaTurno Turno { get; set; }
        public bool Finalizado { get; set; }
    }
}
