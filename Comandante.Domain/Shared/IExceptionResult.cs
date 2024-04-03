namespace Comandante.Domain.Shared;

public interface IExceptionResult
{
    public static readonly Error ExceptionError = new(
        "Exception occur",
        "При выполнении операции возникло исключение.");

    Exception Exception { get; }
}
