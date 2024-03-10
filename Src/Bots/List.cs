
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RichillCapital.Contracts;
using RichillCapital.Identity.Api;
using RichillCapital.UseCases.ListBots;

public sealed class List(IMediator _mediator) : AsyncEndpoint
    .WithRequest<ListBotsRequest>
    .WithActionResult<ListResponse<BotResponse>>
{
    [HttpGet(ApiRoutes.V1.Bots.List)]
    public override async Task<ActionResult<ListResponse<BotResponse>>> HandleAsync(
        [FromQuery] ListBotsRequest request,
        CancellationToken cancellationToken = default)
    {
        var query = new ListBotsQuery();

        var result = await _mediator.Send(query, cancellationToken);

        if (result.IsFailure)
        {
            return HandleError(result.Error);
        }

        var bots = result.Value.Items.Select(bot => new BotResponse(
            bot.Id,
            bot.Name,
            bot.Description,
            bot.Symbols,
            bot.Side,
            bot.Platform)).ToList();

        var listBotsResponse = new ListBotsResponse(bots);

        return Ok(listBotsResponse);
    }
}
