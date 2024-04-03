using FluentValidation;

namespace Comandante.Application.ValidationRules;

public static class ValidationRules
{
    public static IRuleBuilderOptions<T, string> ValidateEventGroupId<T>(this IRuleBuilderInitial<T, string> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty()
            .WithMessage("Id группы событий не может быть пустым")
            .MaximumLength(50)
            .WithMessage("Макс. длина Id группы событий не должна превышать 50 символов");
    }

    public static IRuleBuilderOptions<T, string> ValidateEventGroupName<T>(this IRuleBuilderInitial<T, string> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty()
            .WithMessage("Имя группы событий не может быть пустым")
            .MaximumLength(250)
            .WithMessage("Макс. длина имени группы событий не должна превышать 250 символов");
    }

    public static IRuleBuilderOptions<T, string> ValidateEventGroupDetailValue<T>(this IRuleBuilderInitial<T, string> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty()
            .WithMessage("значение параметра элемента группы события не может быть пустым")
            .MaximumLength(250)
            .WithMessage("Макс. длина параметра элемента группы события группы событий не должна превышать 250 символов");
    }

    public static IRuleBuilderOptions<T, string> ValidateDescription<T>(this IRuleBuilderInitial<T, string> ruleBuilder)
    {
        return ruleBuilder
            .MaximumLength(500)
            .WithMessage("Макс. длина описания не должна превышать 500 символов");
    }
}
