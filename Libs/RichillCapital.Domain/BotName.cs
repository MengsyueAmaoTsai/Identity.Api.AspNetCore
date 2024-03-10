using RichillCapital.SharedKernel;

namespace RichillCapital.Domain;

public sealed class BotName : SingleValueObject<string>
{
    public BotName(string value) 
        : base(value)
    {
    }
}