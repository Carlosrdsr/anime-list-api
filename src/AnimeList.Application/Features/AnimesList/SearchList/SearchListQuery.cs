using AnimeList.Application.Dto;
using MediatR;

namespace AnimeList.Application.Features.AnimesList.SearchList;

public class SearchListQuery : IRequest<List<AnimeDto>>
{
    public long? Id { get; private set; }
    public string? Nome { get; private set; }
    public string? Diretor { get; private set; }
    public int Page { get; private set; }
    public int Limit { get; private set; }

    public SearchListQuery(long? id, string? nome, string? diretor, int page = 1, int limit = 10)
    {
        Id = id;
        Nome = nome;
        Diretor = diretor;
        Page = page;
        Limit = limit;
    }
}
