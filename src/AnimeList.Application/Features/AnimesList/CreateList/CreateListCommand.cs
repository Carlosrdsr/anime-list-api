using AnimeList.Application.Dto;
using MediatR;

namespace AnimeList.Application.Features.AnimesList.CreateList;

public class CreateListCommand : IRequest<Unit>
{
    public string Nome { get; private set; }
    public string Diretor { get; private set; }
    public string Resumo { get; private set; }

    public CreateListCommand(string nome, string diretor, string resumo)
    {
        Nome = nome;
        Diretor = diretor;
        Resumo = resumo;
    }
}
