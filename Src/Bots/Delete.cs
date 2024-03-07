using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RichillCapital.Identity.Api.Endpoints.Bots;

public sealed class Delete(IMediator _mediator) : AsyncEndpoint
    .WithRequest<DeleteBotRequest>
    .WithActionResult
{
    [HttpDelete("/api/bots/{botId}")]
    public override Task<ActionResult> HandleAsync(
        [FromRoute] DeleteBotRequest request,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
