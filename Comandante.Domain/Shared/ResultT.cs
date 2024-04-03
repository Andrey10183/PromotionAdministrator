namespace Comandante.Domain.Shared;

public class Result<TValue> : Result
{
    private readonly TValue? _value;

    public Result(TValue? value, bool isSuccess, Error error)
        :base(isSuccess, error) =>
        _value = value;

    public TValue? Value => IsSuccess
        ? _value
        : default;//throw new InvalidOperationException("The value of a failure can't be accessed.");
    
    public static implicit operator Result<TValue>(TValue value) => Create(value);

    public static implicit operator Result<TValue>(Error error) => CreateError<TValue>(error);
}
