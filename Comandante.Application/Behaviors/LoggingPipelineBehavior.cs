using Comandante.Domain.Shared;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Comandante.Application.Behaviors;

public class LoggingPipelineBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Result
{
    private readonly ILogger<LoggingPipelineBehavior<TRequest, TResponse>> _logger;
    //private readonly AuthenticationService _authenticationService;

    public LoggingPipelineBehavior(ILogger<LoggingPipelineBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "Starting request {RequestName} {@Request}",
            typeof(TRequest).Name,
            request);

        var result = await next();
        
        if (result.IsFailure)
        {
            _logger.LogError("{@Code}.{@Description}", result.Error.Code, result.Error.Description);

            if (result is IValidationResult validationResult)
            {
                foreach(var item in validationResult.Errors)
                    _logger.LogError("{item}", item);
            }
        }
        
        _logger.LogInformation(
            "Completed request {RequestName}",
            typeof(TRequest).Name);

        return result;
    }
}
