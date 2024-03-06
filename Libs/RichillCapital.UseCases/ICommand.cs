using MediatR;

namespace RichillCapital.UseCases;

internal interface ICommand<TResult> : IRequest<TResult>;