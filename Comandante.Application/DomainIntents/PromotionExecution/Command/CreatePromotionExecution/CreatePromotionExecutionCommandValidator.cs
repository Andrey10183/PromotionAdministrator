using FluentValidation;

namespace Comandante.Application.DomainIntents.PromotionExecution.Command.CreatePromotionExecution;

public class CreatePromotionExecutionCommandValidator : AbstractValidator<CreatePromotionExecutionCommand>
{
    public CreatePromotionExecutionCommandValidator()
    {
        RuleFor(x => x.PromotionExecution.ShopCode)
            .NotNull()
            .NotEmpty()
            .WithMessage("поле не может быть пустым")
            .MaximumLength(3000)
            .WithMessage("Макс. длина не должна превышать 3000 символов");
    }
}
