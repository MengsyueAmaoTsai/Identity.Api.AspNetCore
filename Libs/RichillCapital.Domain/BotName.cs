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

    public static Result<BotName> From(string value) => throw new NotImplementedException();
}
