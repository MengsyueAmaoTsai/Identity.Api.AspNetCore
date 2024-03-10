using MediatR;
using Microsoft.AspNetCore.Mvc;
using RichillCapital.Contracts;
using RichillCapital.Identity.Api;
using RichillCapital.UseCases.CreateBot;

public sealed class Create(IMediator _mediator) : AsyncEndpoint
    .WithRequest<CreateBotRequest>
    .WithActionResult<CreateBotResponse>
{
    [HttpPost(ApiRoutes.V1.Bots.Create)]
    public override async Task<ActionResult<CreateBotResponse>> HandleAsync(
        [FromBody] CreateBotRequest request,
        CancellationToken cancellationToken = default)
    {
        var command = new CreateBotCommand(
              request.Id,
              request.Name,
              request.Description,
              request.Symbols,
              request.Side,
              request.Platform);

        var result = await _mediator.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return HandleError(result.Error);
        }

        var response = new CreateBotResponse(result.Value.Value);
        return Ok(response);
    }
}