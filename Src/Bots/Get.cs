using MediatR;
using Microsoft.AspNetCore.Mvc;
using RichillCapital.SharedKernel.Monads;
using RichillCapital.UseCases.Bots;
using RichillCapital.UseCases.Bots.Get;

namespace RichillCapital.Identity.Api.Endpoints.Bots;

public sealed class Get(IMediator _mediator) : AsyncEndpoint
    .WithRequest<GetBotByIdRequest>
    .WithActionResult<BotResponse>
{
    [HttpGet("/api/bots/{botId}")]
    public override async Task<ActionResult<BotResponse>> HandleAsync(
        [FromRoute] GetBotByIdRequest request,
        CancellationToken cancellationToken = default) =>
        await request
            .ToErrorOr()
            .Then(MapToQuery)
            .Then(query => _mediator.Send(query, cancellationToken))
            .Then(MapToResponse)
            .Match(HandleError, Ok);


    private static GetBotByIdQuery MapToQuery(GetBotByIdRequest request) =>
        new(request.Id);

    private static BotResponse MapToResponse(BotDto bot) =>
        new(
            bot.Id,
            bot.Name,
            bot.Description,
            bot.Side,
            bot.Platform,
            bot.CreatedAt,
            bot.UpdatedAt);
}
