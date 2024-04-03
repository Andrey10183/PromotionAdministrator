using Comandante.Domain.Shared;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Comandante.Application.Behaviors;

public class ExceptionPipelineBehavior<TRequest, TResponse, TException> 
    : IRequestExceptionHandler<TRequest, TResponse, TException>
    where TRequest : IRequest<TResponse>
    where TResponse : Result
    where TException : Exception
{
    private readonly ILogger<ExceptionPipelineBehavior<TRequest, TResponse, TException>> _logger;

    public ExceptionPipelineBehavior(ILogger<ExceptionPipelineBehavior<TRequest, TResponse, TException>> logger)
    {
        _logger = logger;
    }

    public Task Handle(
        TRequest request, 
        TException exception, 
        RequestExceptionHandlerState<TResponse> state,
        CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "Exception arise while handling request of type {@requestType}", typeof(TRequest));
        
        var response = CreateValidationResult<TResponse>(exception);

        state.SetHandled(response);
        return Task.CompletedTask;
    }

    private static TResult CreateValidationResult<TResult>(Exception exception)
        where TResult : Result
    {
        if (typeof(TResult) == typeof(Result))
        {
            return (ExceptionResult.WithErrors(exception) as TResult)!;
        }

        object validationResult = typeof(ExceptionResult<>)
            .GetGenericTypeDefinition()
            .MakeGenericType(typeof(TResult).GenericTypeArguments[0])
            .GetMethod(nameof(ExceptionResult.WithErrors))!
            .Invoke(null, new object?[] { exception })!;

        return (TResult)validationResult;
    }
}
