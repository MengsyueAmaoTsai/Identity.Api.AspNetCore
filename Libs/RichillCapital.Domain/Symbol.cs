using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Domain;

public sealed class Symbol : SingleValueObject<string>
{
    private Symbol(string value)
        : base(value)
    {
    }

    public static Result<Symbol> From(string value) =>
        value
            .ToResult()
            .Ensure(value => !string.IsNullOrWhiteSpace(value), Error.Invalid("Symbol is required."))
            .Then(value => new Symbol(value));
}
