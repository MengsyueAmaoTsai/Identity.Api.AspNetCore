using MediatR;

using Microsoft.AspNetCore.Mvc;

using RichillCapital.UseCases.Users.List;

namespace RichillCapital.Identity.Api.Endpoints.Users;

public sealed class List(IMediator _mediator) : AsyncEndpoint
    .WithRequest<ListUsersRequest>
    .WithActionResult<PagedListResponse<UserResponse>>
{
    [HttpGet("/api/users")]
    public override async Task<ActionResult<PagedListResponse<UserResponse>>> HandleAsync(
        [FromQuery] ListUsersRequest request,
        CancellationToken cancellationToken = default)
    {
        var query = new ListUsersQuery(request.Page, request.PageSize);

        var errorOr = await _mediator.Send(query, cancellationToken);

        var result = errorOr.Value;
        var items = result.Items.Select(item => new UserResponse(item.Id, item.Email, item.Name));

        return new PagedListResponse<UserResponse>(
            items,
            result.Page,
            result.PageSize,
            result.TotalCount,
            result.HasNextPage,
            result.HasPreviousPage);
    }

}
