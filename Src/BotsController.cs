using MediatR;
using Microsoft.AspNetCore.Mvc;
using RichillCapital.Contracts;
using RichillCapital.Persistence;
using RichillCapital.SharedKernel;
using RichillCapital.UseCases.DeleteBot;
using RichillCapital.UseCases.GetBotById;
using RichillCapital.UseCases.ListBots;

namespace RichillCapital.Identity.Api;

[ApiController]
public sealed class BotsController(IMediator _mediator) : ControllerBase
{
    [HttpGet(ApiRoutes.V1.Bots.List)]
    public async Task<IActionResult> List(CancellationToken cancellationToken = default)
    {
        var query = new ListBotsQuery();

        var result = await _mediator.Send(query, cancellationToken);

        var bots = Seed.Bots
            .Select(bot => new BotResponse(
                bot.Id.Value,
                bot.Name.Value,
                bot.Description.Value,
                bot.Symbols.Select(symbol => symbol.Value).ToArray(),
                bot.Side.Name,
                bot.Platform.Name));

        var listBotsResponse = new ListBotsResponse(bots);

        return Ok(listBotsResponse);
    }

    [HttpGet(ApiRoutes.V1.Bots.Get)]
    public async Task<IActionResult> Get(
        [FromRoute(Name = "botId")] string botId, CancellationToken cancellationToken = default)
    {
        var query = new GetBotByIdQuery(botId);

        var result = await _mediator.Send(query, cancellationToken);

        if (result.IsFailure)
        {
            return HandleError(result.Error);
        }

        var botResponse = new BotResponse(
            result.Value.Id,
            result.Value.Name,
            result.Value.Description,
            result.Value.Symbols,
            result.Value.Side,
            result.Value.Platform);

        return Ok(botResponse);
    }

    [HttpDelete(ApiRoutes.V1.Bots.Delete)]
    public async Task<IActionResult> Delete(
        [FromRoute(Name = "botId")] string botId, CancellationToken cancellationToken = default)
    {
        var command = new DeleteBotCommand(botId);

        var result = await _mediator.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return HandleError(result.Error);
        }

        return NoContent();
    }

    private ActionResult HandleError(Error error)
    {
        return error.Type switch
        {
            ErrorType.Validation => BadRequest(error),
            ErrorType.NotFound => NotFound(error),
            _ => BadRequest(error)
        };
    }
}
