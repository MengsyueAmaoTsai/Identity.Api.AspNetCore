using MediatR;
using Microsoft.AspNetCore.Mvc;
using RichillCapital.SharedKernel.Monads;
using RichillCapital.UseCases;
using RichillCapital.UseCases.Bots;
using RichillCapital.UseCases.Bots.List;

namespace RichillCapital.Identity.Api.Endpoints.Bots;

public sealed class List(IMediator _mediator) : AsyncEndpoint
    .WithRequest<ListBotsRequest>
    .WithActionResult<ListBotsResponse>
{
    [HttpGet("/api/bots")]
    public override async Task<ActionResult<ListBotsResponse>> HandleAsync(
        [FromRoute] ListBotsRequest request,
        CancellationToken cancellationToken = default) =>
        await request
            .ToErrorOr()
            .Then(MapToQuery)
            .Then(query => _mediator.Send(query, cancellationToken))
            .Then(MapToResponse)
            .Match(HandleError, Ok);

    private static ListBotsQuery MapToQuery(ListBotsRequest request) =>
        new();

    private static ListBotsResponse MapToResponse(PagedDto<BotDto> pagedDto)
    {
        var bots = pagedDto.Items
            .Select(item => new BotResponse(
                item.Id,
                item.Name,
                item.Description,
                item.Side,
                item.Platform,
                item.CreatedAt,
                item.UpdatedAt));

        return new ListBotsResponse(bots);
    }
}
