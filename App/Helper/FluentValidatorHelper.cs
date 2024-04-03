using FluentValidation;
using static MudBlazor.CategoryTypes;

namespace Comandante.App.Helper;
public class FluentValueValidator<T> : AbstractValidator<T>
{
    public FluentValueValidator(Action<IRuleBuilderInitial<T, T>> rule)
    {
        rule(RuleFor(x => x));
    }

    private IEnumerable<string> ValidateValue(T arg)
    {
        try
        {
            var result = Validate(arg);
            if (result.IsValid)
                return new string[0];
            return result.Errors.Select(e => e.ErrorMessage);
        }
        catch (Exception e)
        {
            return Enumerable.Empty<string>();
        }
    }

    public Func<T, IEnumerable<string>> Validation => ValidateValue;
}
