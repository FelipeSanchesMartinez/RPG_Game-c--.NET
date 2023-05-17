using RpgGame.Enums;
using System.ComponentModel.DataAnnotations;

namespace RpgGame.ViewModels
{
    public class InsertPersonagemViewModel
    {

        public string Nome { get; set; }

        public PersonagemTipo Tipo { get; set; }
   
        public int Vida { get; set; }
    
        public int Forca { get; set; }
    
        public int Defesa { get; set; }
   
        public int Agilidade { get; set; }
       
        public int QtdDados { get; set; }
      
        public int FacesDado { get; set; }
    }
}
