using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.UseCases.Users.List;

public sealed record ListUsersQuery(
    int Page,
    int PageSize) :
    IQuery<ErrorOr<PagedDto<UserDto>>>;
