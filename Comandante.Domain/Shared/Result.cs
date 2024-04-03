namespace Comandante.Domain.Shared;

public class Result
{
    protected Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None ||
            !isSuccess && error == Error.None)
        {
            throw new ArgumentException("Invalid error", nameof(error));
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; set; }
    public static Result Success() => new Result(true, Error.None);
    public static Result Failure(Error error) => new Result(false, error);

    public static Result<TValue> Create<TValue>(TValue? value)
    {
        return new(value, true, Error.None);
    }

    public static Result<TValue> CreateError<TValue>(Error error)
    {
        return new(default, false, error);
    }
}
