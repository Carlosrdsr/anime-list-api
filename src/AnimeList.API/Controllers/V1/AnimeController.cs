using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace AnimeList.API.Controllers.V1;

[Route("api/v1/animes")]
[OpenApiTag("Animes")]
[ApiController]
public class AnimeController : ControllerBase
{
    private readonly IMediator _mediator;

    public AnimeController(IMediator mediator)
    {
        _mediator = mediator;
    }


}
