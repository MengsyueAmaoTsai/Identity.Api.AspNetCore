using MediatR;
using Microsoft.AspNetCore.Mvc;
using RichillCapital.SharedKernel.Monads;
using RichillCapital.UseCases.Users.Get;

namespace RichillCapital.Identity.Api.Users;

public sealed class Get(IMediator _mediator) : AsyncEndpoint
    .WithRequest<GetUserByIdRequest>
    .WithActionResult<UserResponse>
{
    [HttpGet("/api/users/{userId}")]
    public override async Task<ActionResult<UserResponse>> HandleAsync(
        [FromRoute] GetUserByIdRequest request, 
        CancellationToken cancellationToken = default)
    {
        // 1. Map request to query
        var query = new GetUserByIdQuery(request.UserId);

        // 2. Execute use case
        var errorOr = await _mediator.Send(query, cancellationToken);

        // 3. Convert result to response.
        var user = errorOr.Value;

        var response = new UserResponse(user.Id, user.Email, user.Name).ToErrorOr();

        return response.Match(HandleError, Ok);
    }
}
