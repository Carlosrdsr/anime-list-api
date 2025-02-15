using AnimeList.Application.Dto;
using AnimeList.Domain.Exceptions;
using AnimeList.Domain.Interface;
using AnimeList.Domain.Model;
using AutoMapper;
using MediatR;
using Serilog;

namespace AnimeList.Application.Features.AnimesList.CreateList
{
    public class CreateListCommandHandler : IRequestHandler<CreateListCommand, AnimeDto>
    {

        private readonly IAnimeRepository _animeRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public CreateListCommandHandler(IAnimeRepository repository, ILogger logger, IMapper mapper)
        {
            _animeRepository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<AnimeDto> Handle(CreateListCommand request, CancellationToken cancellationToken)
        {
            if (_animeRepository.ExistsAnimeByNome(request.Nome))
            {
                _logger.Error("Anime já cadastrado.");
                throw new AnimeListDomainException("Anime já cadastrado!");
            }

            var anime = new AnimeModel(request.Nome, request.Diretor, request.Resumo);

            _animeRepository.InsertAnime(anime);

            _animeRepository.SaveChanges();

            _logger.Information($"Anime {anime.Nome} cadastrado.");
            return _mapper.Map<AnimeDto>(anime);
        }
    }
}
