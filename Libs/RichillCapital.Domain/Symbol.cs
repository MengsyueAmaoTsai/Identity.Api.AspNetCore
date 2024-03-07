using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Domain;

public sealed class Symbol : SingleValueObject<string>
{
    private Symbol(string value)
        : base(value)
    {
    }

    public static ErrorOr<Symbol> From(string value) =>
        throw new NotImplementedException();
}