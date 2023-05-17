using RpgGame.Models;
using RpgGame.ViewModels;

namespace RpgGame.Interfaces
{
    public interface IPersonagemService
    {
        List<Personagem> ObterTodos();

        Personagem ObterPorId(long id);

        void Insercao(InsertPersonagemViewModel viewModel);

        void Atualizar(long id,UpdatePersonagemViewModel viewModel);

        void Deletar(long id);

    }
}
