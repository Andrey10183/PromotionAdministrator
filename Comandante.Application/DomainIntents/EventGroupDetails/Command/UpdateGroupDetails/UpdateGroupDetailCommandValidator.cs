using Comandante.Application.DomainIntents.EventGroupDetails.Command.CreateEventGroupDetails;
using FluentValidation;

namespace Comandante.Application.DomainIntents.EventGroupDetails.Command.UpdateGroupDetails;

public class UpdateGroupDetailCommandValidator : AbstractValidator<UpdateGroupDetailCommand>
{
    public UpdateGroupDetailCommandValidator()
    {
        RuleFor(x => x.EventGroupDetail.EventGroupId)
            .NotNull()
            .NotEmpty()
            .WithMessage("поле не может быть пустым")
            .MaximumLength(50)
            .WithMessage("Макс. длина не должна превышать 50 символов");

        RuleFor(x => x.EventGroupDetail.CatalogTypeId)
            .NotEmpty()
            .NotNull()
            .WithMessage("поле не может быть пустым")
            .MaximumLength(50)
            .WithMessage("Макс. длина не должна превышать 50 символов");

        RuleFor(x => x.EventGroupDetail.CatalogParamTypeId)
            .NotNull()
            .NotEmpty()
            .WithMessage("поле не может быть пустым")
            .MaximumLength(50)
            .WithMessage("Макс. длина не должна превышать 50 символов");

        RuleFor(x => x.EventGroupDetail.Value)
            .NotNull()
            .NotEmpty()
            .WithMessage("поле не может быть пустым")
            .MaximumLength(250)
            .WithMessage("Макс. длина не должна превышать 250 символов");

        RuleFor(x => x.EventGroupDetail.FilterTypeId)
            .NotNull()
            .NotEmpty()
            .WithMessage("поле не может быть пустым")
            .MaximumLength(50)
            .WithMessage("Макс. длина не должна превышать 50 символов");

        RuleFor(x => x.EventGroupDetail.Description)
            .MaximumLength(500)
            .WithMessage("Макс. длина не должна превышать 500 символов");
    }
}
