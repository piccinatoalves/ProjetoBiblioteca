using AutoMapper;
using ProjBiblioteca.Application.ViewModels;
using ProjBiblioteca.Domain.Entities;

namespace ProjBiblioteca.Application.InputModels.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Autor, AutorViewModel>()
            .ForMember(a => a.Id,
                        opt => opt.MapFrom(src => src.AutorID))
            .ReverseMap();

            CreateMap<Livro, LivroInputModel>()
                .ForMember(dest => dest.Id, 
                           opt => opt.MapFrom(src => src.LivroID))
                .ReverseMap();
        }
    }
}