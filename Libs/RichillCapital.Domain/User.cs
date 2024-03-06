using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Domain;

public sealed class User : Entity<UserId>
{
    private User(
        UserId id,
        Email email, 
        Password password,
        UserName name) 
        : base(id)
    {
        Email = email;
        Password = password;
        Name = name;
    }

    public Email Email { get; private init; }

    public Password Password { get; private init; }

    public UserName Name { get; private init; }

    public static ErrorOr<User> Create(
        UserId id,
        Email email,
        Password password,
        UserName name)
    {
        return new User(id, email, password, name)
            .ToErrorOr();
    }
}
