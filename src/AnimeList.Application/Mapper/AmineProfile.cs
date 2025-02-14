using AnimeList.Application.Dto;
using AnimeList.Domain.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Mapper
{
    public class AmineProfile: Profile
    {
        public AmineProfile()
        {
            CreateMap<AnimeModel, AnimeDto>();
        }
    }
}
