using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.UseCases.Users.List;

public sealed record ListUsersQuery() :
    IQuery<ErrorOr<PagedDto<UserDto>>>;
