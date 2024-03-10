using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Domain;

public sealed class BotName : SingleValueObject<string>
{
    public const int MaxLength = 100;

    private BotName(string value)
        : base(value)
    {
    }

    public static Result<BotName> From(string value) =>
        value
            .ToResult()
            .Ensure(v => !string.IsNullOrWhiteSpace(v), Error.Invalid("Bot name is required."))
            .Ensure(v => v.Length <= MaxLength, Error.Invalid($"Bot name must be {MaxLength} characters or less."))
            .Then(v => new BotName(v));
}