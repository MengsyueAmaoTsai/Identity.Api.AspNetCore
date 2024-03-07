using MediatR;
using Microsoft.AspNetCore.Mvc;
using RichillCapital.UseCases.Bots.List;

namespace RichillCapital.Identity.Api.Endpoints.Bots;

public sealed class List(IMediator _mediator) : AsyncEndpoint
    .WithRequest<ListBotsRequest>
    .WithActionResult<ListBotsResponse>
{
    [HttpGet("/api/bots")]
    public override async Task<ActionResult<ListBotsResponse>> HandleAsync(
        [FromRoute] ListBotsRequest request,
        CancellationToken cancellationToken = default)
    {
        var query = new ListBotsQuery();

        var result = await _mediator.Send(query, cancellationToken);

        return Ok();
    }
}
