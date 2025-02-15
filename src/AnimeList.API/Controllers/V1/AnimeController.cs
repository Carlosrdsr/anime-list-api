using AnimeList.Application.Dto;
using AnimeList.Application.Features.AnimesList.CreateList;
using AnimeList.Application.Features.AnimesList.DeleteList;
using AnimeList.Application.Features.AnimesList.SearchList;
using AnimeList.Application.Features.AnimesList.UpdateList;
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
    /// <param name="id">Código de identificação</param>
    /// <param name="nome">Nome do anime</param>
    /// <param name="diretor">Diretor responsável</param>
    /// <param name="page">Numero da página</param>
    /// <param name="limit">Quantidade de anime por página</param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult> Get(long? id, string? nome, string? diretor, int? page, int? limit)
    {
        var query = new SearchListQuery(id, nome, diretor, page ?? 1, limit ?? 10);

        var result = await _mediator.Send(query);

        return Ok(result);
    }

    /// <summary>
    /// Altera informações do Anime
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<ActionResult> Put([FromBody] AnimeDto model)
    {
        var anime = new UpdateListCommand()
        {
            Id = model.Id,
            Nome = model.Nome,
            Diretor = model.Diretor,
            Resumo = model.Resumo
        };

        var result = await _mediator.Send(anime);

        return Ok(result);
    }

    /// <summary>
    /// Excluir um determinado anime por Id
    /// </summary>
    /// <param name="id">Código de identificação</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var query = new DeleteListCommand() { Id = id };

        await _mediator.Send(query);

        Log.Information("Agência " + id.ToString() + " deletada.");

        return NoContent();
    }
}
