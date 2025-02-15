using AnimeList.Domain.Interface;
using AnimeList.Domain.Model;
using k8s.Models;

namespace AnimeList.Test.Helper
{
    internal class AnimeRepositoryTest : IAnimeRepository
    {
        public void DeleteAnime(AnimeModel model)
        {
            throw new NotImplementedException();
        }

        public bool ExistsAnimeByNome(string nome)
        {
            return true;
        }

        public AnimeModel GetAnimeById(long id)
        {
            return new AnimeModel(null,null, null);
        }

        public void InsertAnime(AnimeModel model)
        {
            throw new NotImplementedException();
        }

        public void PutAnime(AnimeModel model)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public List<AnimeModel> SearchAnime(long? id, string? nome, string? diretor, int? page, int? limit)
        {
            if (id is not null && id > 50)
                return null;

            return new List<AnimeModel>();
        }
    }
}
