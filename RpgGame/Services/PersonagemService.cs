using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RpgGame.Data;
using RpgGame.Interfaces;
using RpgGame.Models;
using RpgGame.ViewModels;

namespace RpgGame.Services
{
    public class PersonagemService : IPersonagemService
    {
        private readonly SQLContext _sqlContext;
        private readonly IMapper _mapper;

        public PersonagemService(SQLContext sqlContext, IMapper mapper)
        {
            _sqlContext = sqlContext;
            _mapper = mapper;
        }

        public void Atualizar(long id, UpdatePersonagemViewModel viewModel)
        {
            var personagemBancoDeDados = _sqlContext.Personagem
                .AsNoTracking()
                .FirstOrDefault(personagem => personagem.Id == id);

            if (personagemBancoDeDados == null) return;

           Personagem personagem = _mapper.Map<Personagem>(viewModel);

            _sqlContext.Personagem.Update(personagem);

            _sqlContext.SaveChanges();
        }

        public void Deletar(long id)
        {
            var personagemBancoDeDados = _sqlContext.Personagem
                .AsNoTracking()
                .FirstOrDefault(personagem => personagem.Id == id);

            if (personagemBancoDeDados == null) return;

            personagemBancoDeDados.Deletado = true;
            _sqlContext.Personagem.Update(personagemBancoDeDados);
            _sqlContext.SaveChanges();

        }

        public void Insercao(InsertPersonagemViewModel viewModel)
        {
            var personagem = _mapper.Map<Personagem>(viewModel);

            personagem.CriadoEm = DateTime.Now;
            _sqlContext.Personagem.Add(personagem);
            _sqlContext.SaveChanges();
        }

        public Personagem ObterPorId(long id)
        {
            var personagemBancoDeDados = _sqlContext.Personagem
                .AsNoTracking()
                .FirstOrDefault(personagem => personagem.Id == id);

            return personagemBancoDeDados;
        }

        public List<Personagem> ObterTodos()
        {
            return _sqlContext.Personagem.AsNoTracking().Where(personagem => personagem.Deletado == false).ToList();
        }
    }
}
