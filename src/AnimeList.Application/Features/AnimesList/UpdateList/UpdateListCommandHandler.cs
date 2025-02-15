using AnimeList.Application.Dto;
using AnimeList.Domain.Exceptions;
using AnimeList.Domain.Interface;
using AutoMapper;
using MediatR;
using Serilog;

namespace AnimeList.Application.Features.AnimesList.UpdateList;

public class UpdateListCommandHandler : IRequestHandler<UpdateListCommand, AnimeDto>
{
    private readonly IMapper _mapper;
    private readonly IAnimeRepository _animeRepository;
    private readonly ILogger _logger;

    public UpdateListCommandHandler(IMapper mapper, IAnimeRepository animeRepository, ILogger logger)
    {
        _mapper = mapper;
        _animeRepository = animeRepository;
        _logger = logger;
    }

    public async Task<AnimeDto> Handle(UpdateListCommand request, CancellationToken cancellationToken)
    {
        var anime = _animeRepository.GetAnimeById(request.Id);

        if (anime is null)
        {
            _logger.Error("Anime não encontrado.");
            throw new AnimeListDomainException("Anime não encontrado.");
        }

        try
        {
            anime.Update(request.Nome, request.Diretor, request.Resumo);

            _animeRepository.PutAnime(anime);

            _animeRepository.SaveChanges();

            return _mapper.Map<AnimeDto>(anime);
        }
        catch (System.Exception ex)
        {
            _logger.Error(ex, "Falha ao tentar salvar o anime.");
            throw new AnimeListDomainException("Não foi possível alterar o anime.");
        }
    }
}
