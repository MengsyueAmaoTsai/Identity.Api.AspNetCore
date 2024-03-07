using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Domain;

public sealed class UserName : SingleValueObject<string>
{
    public const int MaxLength = 50;

    private UserName(string value)
        : base(value)
    {
    }

    public static Result<UserName> From(string value) => value
        .ToResult()
        .Ensure(value => !string.IsNullOrWhiteSpace(value), Error.Invalid("User name should not be empty"))
        .Ensure(value => value.Length <= MaxLength, Error.Invalid($"User name should not be more than {MaxLength} characters"))
        .Then(value => new UserName(value));
}