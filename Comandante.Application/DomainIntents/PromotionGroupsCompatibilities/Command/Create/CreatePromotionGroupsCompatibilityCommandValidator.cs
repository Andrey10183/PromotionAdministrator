using FluentValidation;

namespace Comandante.Application.DomainIntents.PromotionGroupsCompatibilities.Command.Create;

public class CreatePromotionGroupsCompatibilityCommandValidator 
    : AbstractValidator<CreatePromotionGroupsCompatibilityCommand>
{
    public CreatePromotionGroupsCompatibilityCommandValidator()
    {
        RuleFor(x => x.Compatibility.PromotionGroupX)
            .NotNull()
            .NotEmpty()
            .WithMessage("поле не может быть пустым")
            .MaximumLength(50)
            .WithMessage("Макс. длина не должна превышать 50 символов");

        RuleFor(x => x.Compatibility.PromotionGroupY)
            .NotNull()
            .NotEmpty()
            .WithMessage("поле не может быть пустым")
            .MaximumLength(50)
            .WithMessage("Макс. длина не должна превышать 50 символов");
    }
}
