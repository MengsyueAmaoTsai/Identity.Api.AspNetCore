using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Domain;

public sealed class BotName : SingleValueObject<string>
{
    private BotName(string value)
        : base(value)
    {
    }

    public static Result<BotName> From(string value) => throw new NotImplementedException();
}
