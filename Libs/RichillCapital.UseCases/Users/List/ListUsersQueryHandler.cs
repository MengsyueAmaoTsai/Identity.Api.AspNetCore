using RichillCapital.Domain;
using RichillCapital.SharedKernel.Monads;
using RichillCapital.SharedKernel.Specifications;
using RichillCapital.SharedKernel.Specifications.Builders;

namespace RichillCapital.UseCases.Users.List;

internal sealed class ListUsersQueryHandler(
    IReadOnlyRepository<User> _userRepository) :
    IQueryHandler<ListUsersQuery, ErrorOr<PagedDto<UserDto>>>
{
    public async Task<ErrorOr<PagedDto<UserDto>>> Handle(
        ListUsersQuery query,
        CancellationToken cancellationToken)
    {
        var spec = new PaginationUsersSpecification(query.Page, query.PageSize);

        var users = query.Page != default ?
            await _userRepository.ListAsync(spec, cancellationToken) :
            await _userRepository.ListAsync(cancellationToken);

        var items = MapUsers(users);

        return new PagedDto<UserDto>(items, query.Page, query.PageSize)
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


internal sealed class PaginationUsersSpecification : Specification<User>
{
    public PaginationUsersSpecification(int page, int pageSize)
    {
        Query
            .Skip((page - 1) * pageSize)
            .Take(pageSize);
    }
}