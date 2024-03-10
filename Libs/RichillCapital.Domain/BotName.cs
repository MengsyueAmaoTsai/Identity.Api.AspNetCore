using RichillCapital.SharedKernel;

namespace RichillCapital.Domain;

public sealed class BotName : SingleValueObject<string>
{
    public const int MaxLength = 100;

    public BotName(string value)
        : base(value)
    {
    }
}