using FluentValidation;

namespace Comandante.Application.DomainIntents.PromotionConditions.Command.UpdatePromoCondition;
public class UpdatePromoConditionCommandValidator : AbstractValidator<UpdatePromoConditionCommand>
{
    public UpdatePromoConditionCommandValidator()
    {
        RuleFor(x => x.PromCondition.EventGroupId)
            .NotNull()
            .NotEmpty()
            .WithMessage("поле не может быть пустым")
            .MaximumLength(50)
            .WithMessage("Макс. длина  не должна превышать 50 символов");

        RuleFor(x => x.PromCondition.TypeChargeId)
            .NotNull()
            .NotEmpty()
            .WithMessage("поле не может быть пустым")
            .MaximumLength(50)
            .WithMessage("Макс. длина  не должна превышать 50 символов");

        RuleFor(x => x.PromCondition.TypeCheckId)
            .NotNull()
            .NotEmpty()
            .WithMessage("поле не может быть пустым")
            .MaximumLength(50)
            .WithMessage("Макс. длина  не должна превышать 50 символов");

        RuleFor(x => x.PromCondition.TypeChargeOffId)
            .NotNull()
            .NotEmpty()
            .WithMessage("поле не может быть пустым")
            .MaximumLength(50)
            .WithMessage("Макс. длина  не должна превышать 50 символов");

        RuleFor(x => x.PromCondition.TypeTchargeId)
            .NotNull()
            .NotEmpty()
            .WithMessage("поле не может быть пустым")
            .MaximumLength(50)
            .WithMessage("Макс. длина  не должна превышать 50 символов");
    }
}
