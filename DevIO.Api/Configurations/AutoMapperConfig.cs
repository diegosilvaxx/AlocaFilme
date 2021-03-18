using AutoMapper;
using DevIO.Api.DTO;
using DevIO.Business.Models;

namespace DevIO.Api.Configurations
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Genero, GeneroDto>().ReverseMap();
            CreateMap<Locacao, LocacaoDto>().ReverseMap();
            CreateMap<Locacao, LocacaoDto>();
            CreateMap<LocacaoDto,Locacao >();
            CreateMap<FilmeDto, Filme>();
            CreateMap<Filme, FilmeDto>();
        }
    }
}
