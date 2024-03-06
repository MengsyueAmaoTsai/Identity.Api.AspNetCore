using RichillCapital.Domain;
using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.UseCases.Users.Get;

internal sealed class GetUserByIdQueryHandler(
    IReadOnlyRepository<User> _userRepository) :
    IQueryHandler<GetUserByIdQuery, ErrorOr<UserDto>>
{
    public async Task<ErrorOr<UserDto>> Handle(
        GetUserByIdQuery query,
        CancellationToken cancellationToken)
    {
        // Validate user id 
        var userId = UserId.From(query.Id);

        if (userId.IsFailure)
        {
            return userId.Error.ToErrorOr<UserDto>();
        }

        // Act: Get user by id 
        var maybeUser = await _userRepository.GetByIdAsync(userId.Value, cancellationToken);

        if (maybeUser.IsNull)
        {
            return Error.NotFound("User with the given id was not found")
                .ToErrorOr<UserDto>();
        }

        // Map user to user dto and return.
        var user = maybeUser.Value;

        return new UserDto(user.Id.Value, user.Email.Value, user.Password.Value, user.Name.Value)
            .ToErrorOr();
    }
}
