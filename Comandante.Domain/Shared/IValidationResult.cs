namespace Comandante.Domain.Shared;

public interface IValidationResult
{
    public static readonly Error ValidationError = new(
        "ValidationError",
        "Произошла ошибка валидации.");

    Error[] Errors { get; }
}
