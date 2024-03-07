using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RichillCapital.Identity.Api.Endpoints.Bots;

public sealed class Get(IMediator _medaitor) : AsyncEndpoint
    .WithRequest<GetBotByIdRequest>
    .WithActionResult<BotResponse>
{
    [HttpGet("/api/bots/{botId}")]
    public override Task<ActionResult<BotResponse>> HandleAsync(
        [FromRoute] GetBotByIdRequest request,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
