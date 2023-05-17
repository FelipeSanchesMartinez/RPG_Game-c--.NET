using AutoMapper;
using RpgGame.Models;
using RpgGame.ViewModels;

namespace RpgGame.Mappers
{
    public class ViewModelParaModel : Profile
    {
        public ViewModelParaModel()
        {
            CreateMap<InsertPersonagemViewModel, Personagem>().ReverseMap();
            CreateMap<UpdatePersonagemViewModel, Personagem>().ReverseMap();
        }
    }
}
