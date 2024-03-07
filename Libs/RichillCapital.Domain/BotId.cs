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

    public static Result<BotId> From(string value) => throw new NotImplementedException();
}