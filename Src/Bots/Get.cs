using MediatR;
using Microsoft.AspNetCore.Mvc;
using RichillCapital.Contracts;
using RichillCapital.Identity.Api;
using RichillCapital.UseCases.GetBotById;

public sealed class Get(IMediator _mediator) : AsyncEndpoint
    .WithRequest<GetBotByIdRequest>
    .WithActionResult<BotResponse>
{
    [HttpGet(ApiRoutes.V1.Bots.Get)]
    public override async Task<ActionResult<BotResponse>> HandleAsync(
        [FromRoute] GetBotByIdRequest request,
        CancellationToken cancellationToken = default)
    {
        var query = new GetBotByIdQuery(request.Id);

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
}

