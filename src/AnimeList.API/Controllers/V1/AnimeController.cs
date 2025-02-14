using AnimeList.Application.Dto;
using AnimeList.Application.Features.AnimesList.CreateList;
using AnimeList.Application.Features.AnimesList.SearchList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Serilog;

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

    /// <summary>
    /// Adiciona anime no catálogo
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] AddAnimeDto model)
    {
        var anime = new CreateListCommand(model.Nome, model.Diretor, model.Resumo);

        var result = await _mediator.Send(anime);

        Log.Information($"Anime {model.Nome} cadastrado!");

        return Ok(result);
    }

    /// <summary>
    /// Pesquisa paginada por Id, Nome ou Diretor
    /// </summary>
    /// <param name="id"></param>
    /// <param name="nome"></param>
    /// <param name="diretor"></param>
    /// <param name="page"></param>
    /// <param name="limit"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult> Get(long? id, string? nome, string? diretor, int? page, int? limit)
    {
        var query = new SearchListQuery(id, nome, diretor, page ?? 1, limit ?? 10);

        var result = await _mediator.Send(query);

        return Ok(result);
    }
}
