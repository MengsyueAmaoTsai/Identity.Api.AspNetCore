using Microsoft.AspNetCore.Mvc;

namespace RichillCapital.Identity.Api.Endpoints.Bots;

public sealed class Create : AsyncEndpoint
    .WithRequest<CreateBotRequest>
    .WithActionResult<CreateBotResponse>
{
    [HttpPost("/api/bots")]
    public override Task<ActionResult<CreateBotResponse>> HandleAsync(
        [FromBody] CreateBotRequest request,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
