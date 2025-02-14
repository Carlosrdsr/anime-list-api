﻿using AnimeList.Application.Dto;
using AnimeList.Domain.Interface;
using AutoMapper;
using MediatR;

namespace AnimeList.Application.Features.AnimesList.SearchList
{
    public class SearchListQueryHandler : IRequestHandler<SearchListQuery, List<AnimeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAnimeRepository _repository;

        public SearchListQueryHandler(IMapper mapper, IAnimeRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<AnimeDto>> Handle(SearchListQuery request, CancellationToken cancellationToken)
        {    
            var query =  _repository.SearchAnime(request.Id, request.Nome,
                request.Diretor, request.Page, request.Limit);

            var result = _mapper.Map<List<AnimeDto>>(query);

            return result;
        }
    }
}
