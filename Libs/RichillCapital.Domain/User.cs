using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Domain;

public sealed class User : Entity<UserId>
{
    private User(UserId id) 
        : base(id)
    {
    }

    public static ErrorOr<User> Create(UserId id)
    {
        return new User(id)
            .ToErrorOr();
    }
}
