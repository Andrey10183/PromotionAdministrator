namespace Comandante.Domain.Shared;

public class ExceptionResult : Result, IExceptionResult
{
    private ExceptionResult(Exception exception)
        :base(false, IExceptionResult.ExceptionError) =>
        Exception = exception;

    public static ExceptionResult WithErrors(Exception exception) => new(exception);
    public Exception Exception { get; }
}
