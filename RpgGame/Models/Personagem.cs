using RpgGame.Enums;

namespace RpgGame.Models
{
    public class Personagem : Entidade
    {
        public string Nome { get; set; }
        public PersonagemTipo Tipo { get; set; }
        public int Vida { get; set; }
        public int Forca { get; set; }
        public int Defesa { get; set; }
        public int Agilidade { get; set; }
        public int QtdDados { get; set; }
        public int FacesDado { get; set; }


        public List<PartidaJogador> PartidasJogador { get; set; }
    }
}
