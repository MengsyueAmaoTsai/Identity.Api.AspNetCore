using RichillCapital.SharedKernel;

namespace RichillCapital.Domain;

public sealed class Symbol : SingleValueObject<string>
{
    public Symbol(string value) 
        : base(value)
    {
    }
}
