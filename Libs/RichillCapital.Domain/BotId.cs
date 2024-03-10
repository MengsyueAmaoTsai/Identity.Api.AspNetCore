using RichillCapital.SharedKernel;

namespace RichillCapital.Domain;

public sealed class BotId : SingleValueObject<string>
{
    public BotId(string value) 
        : base(value)
    {
    }
}
