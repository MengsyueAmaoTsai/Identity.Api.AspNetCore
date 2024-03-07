using MediatR;
using Microsoft.AspNetCore.Mvc;
using RichillCapital.Domain;
using RichillCapital.SharedKernel.Monads;
using RichillCapital.UseCases.Bots.Create;

namespace RichillCapital.Identity.Api.Endpoints.Bots;

public sealed class Create(IMediator _mediator) : AsyncEndpoint
    .WithRequest<CreateBotRequest>
    .WithActionResult<CreateBotResponse>
{
    [HttpPost("/api/bots")]
    public override async Task<ActionResult<CreateBotResponse>> HandleAsync(
        [FromBody] CreateBotRequest request,
        CancellationToken cancellationToken = default) =>
        await request
            .ToErrorOr()
            .Then(MapToCommand)
            .Then(command => _mediator.Send(command, cancellationToken))
            .Then(MapToResponse)
            .Match(HandleError, Ok);

    private static CreateBotCommand MapToCommand(CreateBotRequest request) =>
        new(request.Id, request.Name, request.Description, request.Side, request.Platform);

    private static CreateBotResponse MapToResponse(BotId id) =>
        new(id.Value);
}
