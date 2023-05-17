using FluentValidation;
using RpgGame.ViewModels;

namespace RpgGame.Validations
{
    public class InsertPersonagemViewModelValidation : AbstractValidator<InsertPersonagemViewModel>
    {
        public InsertPersonagemViewModelValidation()
        {
            RuleFor(personagem => personagem.Nome)
                .NotEmpty()
                .NotNull();

            //RuleFor(personagem => personagem.Tipo)
            // .NotEmpty()
            // .NotNull();

            RuleFor(personagem => personagem.Vida)
             .NotEmpty()
             .NotNull();

            RuleFor(personagem => personagem.Forca)
             .NotEmpty()
             .NotNull();

            RuleFor(personagem => personagem.Defesa)
             .NotEmpty()
             .NotNull();

            RuleFor(personagem => personagem.Agilidade)
             .NotEmpty()
             .NotNull();

            RuleFor(personagem => personagem.QtdDados)
              .NotEmpty()
              .NotNull();

            RuleFor(personagem => personagem.FacesDado)
              .NotEmpty()
              .NotNull();
        }
    }
}
