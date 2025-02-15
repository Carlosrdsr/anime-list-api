namespace AnimeList.Domain.Model;

public class AnimeModel
{
    public long Id { get; private set; }
    public string Nome { get; private set; }
    public string Diretor { get; private set; }
    public string Resumo { get; private set; }

    protected AnimeModel() { }

    public AnimeModel(long id, string nome, string diretor, string resumo)
    {
        Id = id;
        Nome = nome;
        Diretor = diretor;
        Resumo = resumo;
    }

    public AnimeModel(string nome, string diretor, string resumo)
    {
        Nome = nome;
        Diretor = diretor;
        Resumo = resumo;
    }

    public void Update(string nome, string diretor, string resumo)
    {
        Nome = nome ?? Nome;
        Diretor = diretor ?? Diretor;
        Resumo = resumo ?? Resumo;
    }
}
