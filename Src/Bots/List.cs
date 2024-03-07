using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RichillCapital.Identity.Api.Endpoints.Bots;

public sealed class List(IMediator _mediator) : AsyncEndpoint
    .WithRequest<ListBotsRequest>
    .WithActionResult<ListBotsResponse>
{
    [HttpGet("/api/bots")]
    public override Task<ActionResult<ListBotsResponse>> HandleAsync(
        [FromRoute] ListBotsRequest request,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
