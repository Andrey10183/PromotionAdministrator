using FluentValidation;

namespace Comandante.Application.DomainIntents.Promotions.Command.CreatePromotion;

public class CreatePromotionCommandValidator : AbstractValidator<CreatePromotionCommand>
{
    public CreatePromotionCommandValidator()
    {
        RuleFor(x => x.Promotion.SortType)
            .NotEmpty()
            .WithMessage("поле не может быть пустым")
            .MaximumLength(50)
            .WithMessage("Макс. длина не должна превышать 50 символов");

        RuleFor(x => x.Promotion.Name)
            .NotEmpty()
            .WithMessage("поле не может быть пустым")
            .MaximumLength(100)
            .WithMessage("Макс. длина не должна превышать 100 символов");

        RuleFor(x => x.Promotion.Description)
            .MaximumLength(250)
            .WithMessage("Макс. длина не должна превышать 250 символов");

        RuleFor(x => x.Promotion.PromotionGroup)
            .NotEmpty()
            .WithMessage("поле не может быть пустым")
            .MaximumLength(50)
            .WithMessage("Макс. длина не должна превышать 50 символов");

        RuleFor(x => x.Promotion.RemindTypeId)
            .NotEmpty()
            .WithMessage("поле не может быть пустым")
            .MaximumLength(50)
            .WithMessage("Макс. длина не должна превышать 50 символов");

        RuleFor(x => x.Promotion.OrderNumber)
            .NotEmpty()
            .WithMessage("поле не может быть пустым")
            .MaximumLength(50)
            .WithMessage("Макс. длина не должна превышать 50 символов");

        RuleFor(x => x.Promotion.TrCode)
            .MaximumLength(50)
            .WithMessage("Макс. длина не должна превышать 50 символов");

        RuleFor(x => x.Promotion.SpeCode)
            .MaximumLength(50)
            .WithMessage("Макс. длина не должна превышать 50 символов");
    }
}
