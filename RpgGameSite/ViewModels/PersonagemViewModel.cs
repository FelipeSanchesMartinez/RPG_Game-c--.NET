using RpgGameSite.Enums;

namespace RpgGameSite.ViewModels
{
    public class PersonagemViewModel : ICloneable
    {
        public long Id { get; set; }
        public string Nome { get; set; }

        public PersonagemTipo Tipo { get; set; }

        public int Vida { get; set; }

        public int Forca { get; set; }

        public int Defesa { get; set; }

        public int Agilidade { get; set; }

        public int QtdDados { get; set; }

        public int FacesDado { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
