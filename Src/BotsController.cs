using MediatR;
using Microsoft.AspNetCore.Mvc;
using RichillCapital.Contracts;
using RichillCapital.Persistence;
using RichillCapital.SharedKernel;
using RichillCapital.UseCases.CreateBot;
using RichillCapital.UseCases.DeleteBot;
using RichillCapital.UseCases.GetBotById;
using RichillCapital.UseCases.ListBots;

namespace RichillCapital.Identity.Api;

[ApiController]
public sealed class BotsController(IMediator _mediator) : ControllerBase
{
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

    [HttpPost(ApiRoutes.V1.Bots.Create)]
    public async Task<IActionResult> Create([FromBody] CreateBotRequest request, CancellationToken cancellationToken = default)
    {
        var command = new CreateBotCommand(
            request.Id,
            request.Name,
            request.Description,
            request.Symbols,
            request.Side,
            request.Platform);

        var result = await _mediator.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return HandleError(result.Error);
        }
        return CreatedAtAction(nameof(Get), new { botId = result.Value.Value }, new CreateBotResponse(result.Value.Value));
    }

    private ActionResult HandleError(Error error)
    {
        return error.Type switch
        {
            ErrorType.Validation => BadRequest(error),
            ErrorType.NotFound => NotFound(error),
            ErrorType.Conflict => Conflict(error),
            _ => BadRequest(error)
        };
    }
}
