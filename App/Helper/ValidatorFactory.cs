using FluentValidation;

namespace Comandante.App.Helper;

public static class ValidatorFactory
{
    public static FluentValueValidator<string> DescriptionValidator => 
        new(x => x
        .Length(0, 500).WithMessage("Не более 500 символов"));

    public static FluentValueValidator<string> NameValidator => 
        new(x => x
        .NotNull().WithMessage("Обязательное поле")
        .NotEmpty().WithMessage("Обязательное поле")
        .Length(1, 250).WithMessage("Не более 250 символов"));

    public static FluentValueValidator<string> EventGroupIdValidator =>
        new FluentValueValidator<string>(x => x
        .NotNull().WithMessage("Обязательное поле")
        .NotEmpty().WithMessage("Обязательное поле")
        .Length(1, 50).WithMessage("Не более 50 символов"));

    public static FluentValueValidator<string> GroupDetailValueValidator =>
        new FluentValueValidator<string>(x => x
        .NotEmpty().WithMessage("Обязательное поле")
        .Length(1, 250).WithMessage("Не более 250 символов"));

    public static FluentValueValidator<string> PromoGroupCodeValidator =>
        new FluentValueValidator<string>(x => x
        .NotEmpty().WithMessage("Обязательное поле")
        .Length(1, 50).WithMessage("Не более 50 символов"));

    public static FluentValueValidator<string> PromoExecutionShopCodeValidator =>
        new FluentValueValidator<string>(x => x
            .NotEmpty().WithMessage("Обязательное поле")
            .Length(1, 3000).WithMessage("Не более 3000 символов"));

    public static FluentValueValidator<string> PromoTrSpeCodeCodeValidator =>
        new FluentValueValidator<string>(x => x
            .Length(0, 50).WithMessage("Не более 50 символов"));
}
