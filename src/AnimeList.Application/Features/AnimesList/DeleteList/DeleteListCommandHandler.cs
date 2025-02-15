using AnimeList.Domain.Exceptions;
using AnimeList.Domain.Interface;
using MediatR;
using Serilog;

namespace AnimeList.Application.Features.AnimesList.DeleteList
{
    class DeleteListCommandHandler : IRequestHandler<DeleteListCommand, bool>
    {
        private readonly IAnimeRepository _animeRepository;
        private readonly ILogger _logger;

        public DeleteListCommandHandler(IAnimeRepository animeRepository, ILogger logger)
        {
            _animeRepository = animeRepository;
            _logger = logger;
        }

        public async Task<bool> Handle(DeleteListCommand request, CancellationToken cancellationToken)
        {
            var anime = _animeRepository.GetAnimeById(request.Id);

            if (anime is null)
            {
                _logger.Error("Anime não encontrado.");
                throw new AnimeListDomainException("Anime não encontrado.");
            }

            try
            {
                _animeRepository.DeleteAnime(anime);
                _animeRepository.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Falha ao tentar deletar o anime");
                throw new AnimeListDomainException("Não é possível deletar o anime solicitado.");
            }
        }
    }
}
