using MediatR;
using Microsoft.AspNetCore.Mvc;
using RichillCapital.Contracts;
using RichillCapital.Identity.Api;
using RichillCapital.UseCases.DeleteBot;

public sealed class Delete(IMediator _mediator) : AsyncEndpoint
    .WithRequest<DeleteBotRequest>
    .WithActionResult
{
    [HttpDelete(ApiRoutes.V1.Bots.Delete)]
    public override async Task<ActionResult> HandleAsync(
        [FromRoute] DeleteBotRequest request,
        CancellationToken cancellationToken = default)
    {
        var command = new DeleteBotCommand(request.Id);

        var result = await _mediator.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return HandleError(result.Error);
        }

        return NoContent();
    }
}