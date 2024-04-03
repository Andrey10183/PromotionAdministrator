using FluentValidation;

namespace Comandante.Application.DomainIntents.PromotionGroup.Command.UpdatePromoGroup;

internal class UpdatePromoGroupCommandValidator : AbstractValidator<UpdatePromoGroupCommand>
{
    public UpdatePromoGroupCommandValidator()
    {
        RuleFor(x => x.PromotionGroup.Code)
            .NotNull()
            .NotEmpty()
            .WithMessage("поле не может быть пустым")
            .MaximumLength(50)
            .WithMessage("Макс. длина не должна превышать 50 символов");

        RuleFor(x => x.PromotionGroup.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage("поле не может быть пустым")
            .MaximumLength(250)
            .WithMessage("Макс. длина не должна превышать 250 символов");
    }
}
