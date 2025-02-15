using AnimeList.Application.Dto;
using MediatR;

namespace AnimeList.Application.Features.AnimesList.UpdateList;

public class UpdateListCommand : IRequest<AnimeDto>
{
    public long Id { get; set; }
    public string Nome { get; set; }
    public string Diretor { get; set; }
    public string Resumo { get; set; }
}
