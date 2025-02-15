using MediatR;

namespace AnimeList.Application.Features.AnimesList.DeleteList;

public class DeleteListCommand : IRequest<bool>
{
    public long Id { get; set; }
}
