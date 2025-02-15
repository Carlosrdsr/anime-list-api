using AnimeList.Domain.Exceptions;
using AnimeList.Domain.Interface;
using AnimeList.Domain.Model;
using MediatR;
using Serilog;

namespace AnimeList.Application.Features.AnimesList.CreateList
{
    public class CreateListCommandHandler : IRequestHandler<CreateListCommand, Unit>
    {

        private readonly IAnimeRepository _animeRepository;
        private readonly ILogger _logger;

        public CreateListCommandHandler(IAnimeRepository repository, ILogger logger)
        {
            _animeRepository = repository;
            _logger = logger;
        }

        public async Task<Unit> Handle(CreateListCommand request, CancellationToken cancellationToken)
        {
            if (_animeRepository.ExistsAnimeByNome(request.Nome))
            {
                _logger.Error("Anime já cadastrado.");
                throw new AnimeListDomainException("Anime já cadastrado!");
            }

            var model = new AnimeModel(request.Nome, request.Diretor, request.Resumo);

            _animeRepository.InsertAnime(model);

            _animeRepository.SaveChanges();

            _logger.Information("Anime cadastrado.");

            return Unit.Value;
        }
    }
}
