using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Domain;

public sealed class Email : SingleValueObject<string>
{
    public const int MaxLength = 100;

    private Email(string value)
        : base(value)
    {
    }

    public static Result<Email> From(string value) => value
        .ToResult()
        .Ensure(value => !string.IsNullOrWhiteSpace(value), Error.Invalid("Email should not be empty"))
        .Ensure(value => value.Length <= MaxLength, Error.Invalid($"Email should not be more than {MaxLength} characters"))
        .Ensure(value => new Email(value).Value.Contains('@'), Error.Invalid("Email should be in valid format"))
        .Then(value => new Email(value));
}
