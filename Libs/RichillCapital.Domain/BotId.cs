using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Domain;

public sealed class BotId : SingleValueObject<string>
{
    public const int MaxLength = 100;

    private BotId(string value)
        : base(value)
    {
    }

    public static Result<BotId> From(string value) =>
        value
            .ToResult()
            .Ensure(
                value => value.Split('-').Length == 5,
                Error.Invalid("Bot id format is invalid."))
            .Then(value => new BotId(value));
}
