using RichillCapital.Domain;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.UseCases.Users.List;

internal sealed class ListUsersQueryHandler(
    IReadOnlyRepository<User> _userRepository) :
    IQueryHandler<ListUsersQuery, ErrorOr<PagedDto<UserDto>>>
{
    public async Task<ErrorOr<PagedDto<UserDto>>> Handle(
        ListUsersQuery query,
        CancellationToken cancellationToken)
    {
        var users = await _userRepository.ListAsync(cancellationToken);

        var items = MapUsers(users);

        return new PagedDto<UserDto>(items)
            .ToErrorOr();
    }

    private static IEnumerable<UserDto> MapUsers(IEnumerable<User> users) =>
        users.Select(MapUser);

    private static UserDto MapUser(User user) => new(
        user.Id.Value,
        user.Email.Value,
        user.Password.Value,
        user.Name.Value);
}
