using AnimeList.Domain.Interface;
using AnimeList.Domain.Model;
using AnimeList.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AnimeList.Infrastructure.Repositories
{
    public class AnimeRepository : IAnimeRepository
    {
        private readonly AnimeDbContext _animeDbContext;

        public AnimeRepository(AnimeDbContext animeDbContext)
        {
            _animeDbContext = animeDbContext;
        }

        public void InsertAnime(AnimeModel model)
        {
            _animeDbContext.Animes.Add(model);
        }

        public List<AnimeModel> SearchAnime(long? id, string? nome, string? diretor, int? page, int? limit)
        {
            var query = _animeDbContext.Animes.AsQueryable();

            if (id is not null)
                query = query.Where(s => s.Id == id);

            if (!string.IsNullOrEmpty(nome))
                query = query.Where(s => s.Nome == nome);

            if (!string.IsNullOrEmpty(diretor))
                query = query.Where(s => s.Diretor == diretor);

            if (page.HasValue && limit.HasValue)
            {
                query = query
                    .Skip((page.Value - 1) * limit.Value)
                    .Take(limit.Value);
            }

            var result = query
                .OrderBy(s => s.Nome)
                .ToList();

            return result;
        }

        public void PutAnime(AnimeModel model)
        {
            _animeDbContext.Animes.Update(model);
        }

        public void DeleteAnime(AnimeModel model)
        {
            _animeDbContext.Animes.Remove(model);
        }

        public bool ExistsAnimeById(long id)
        {
            var query = _animeDbContext.Animes
                        .AsNoTracking()
                        .Where(s => s.Id == id);

            if (query.Count() > 0)
                return true;

            return false;
        }

        public bool ExistsAnimeByNome(string nome)
        {
            var query = _animeDbContext.Animes
                        .AsNoTracking()
                        .Where(s => s.Nome == nome);

            if (query.Count() > 0)
                return true;

            return false;
        }

        public void SaveChanges()
        {
            _animeDbContext.SaveChanges();
        }
    }
}
