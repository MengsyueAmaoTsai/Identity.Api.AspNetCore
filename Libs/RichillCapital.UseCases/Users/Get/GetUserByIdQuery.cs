using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.UseCases.Users.Get;

public sealed record GetUserByIdQuery(string Id) : 
    IQuery<ErrorOr<UserDto>>;
