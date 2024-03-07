using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Domain;

public sealed class Symbol : SingleValueObject<string>
{
    public const int MaxLength = 100;

    private Symbol(string value)
        : base(value)
    {
    }

    public static ErrorOr<Symbol> From(string value) =>
        throw new NotImplementedException();
}