using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Domain;

public sealed class Password : SingleValueObject<string>
{
    public const int MaxLength = 100;

    private Password(string value)
        : base(value)
    {
    }

    public static Result<Password> From(string value) => value
        .ToResult()
        .Then(value => new Password(value));
}
