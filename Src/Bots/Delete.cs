using MediatR;
using Microsoft.AspNetCore.Mvc;
using RichillCapital.SharedKernel.Monads;
using RichillCapital.UseCases.Bots.Delete;

namespace RichillCapital.Identity.Api.Endpoints.Bots;

public sealed class Delete(IMediator _mediator) : AsyncEndpoint
    .WithRequest<DeleteBotRequest>
    .WithActionResult
{
    [HttpDelete("/api/bots/{botId}")]
    public override Task<ActionResult> HandleAsync(
        [FromRoute] DeleteBotRequest request,
        CancellationToken cancellationToken = default) =>
        request
            .ToResult()
            .Then(MapToCommand)
            .Then(command => _mediator.Send(command, cancellationToken))
            .Match(_ => NoContent(), HandleError);

    private static DeleteBotCommand MapToCommand(DeleteBotRequest request) =>
        new(request.Id);
}
