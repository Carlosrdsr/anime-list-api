using AnimeList.Application.Dto;
using AnimeList.Domain.Model;
using AutoMapper;

namespace AnimeList.Application.Mapper
{
    public class AmineProfile : Profile
    {
        public AmineProfile()
        {
            CreateMap<AnimeModel, AnimeDto>();
        }
    }
}
