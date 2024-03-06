using MediatR;

namespace RichillCapital.UseCases;

internal interface IQuery<TResult> : IRequest<TResult>;
