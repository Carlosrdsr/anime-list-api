using AnimeList.Domain.Model;

namespace AnimeList.Domain.Interface;

public interface IAnimeRepository
{
    void InsertAnime(AnimeModel model);
    List<AnimeModel> SearchAnime(long? id, string? nome, string? diretor, int? page, int? limit);
    void PutAnime(AnimeModel model);
    public void DeleteAnime(AnimeModel model);
    bool ExistsAnimeById(long id);
    bool ExistsAnimeByNome(string nome);
    void SaveChanges();
}
