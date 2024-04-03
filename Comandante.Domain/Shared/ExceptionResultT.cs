namespace Comandante.Domain.Shared;

public class ExceptionResult<TValue> : Result<TValue>, IExceptionResult
{
    private ExceptionResult(Exception exception)
        :base(default,false, IExceptionResult.ExceptionError) =>
        Exception = exception;

    public Exception Exception { get; }
    public static ExceptionResult<TValue> WithErrors(Exception exception) => new(exception);
    
}
