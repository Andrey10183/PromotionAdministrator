using Comandante.Application.DomainIntents.EventGroups.Command.Update;
using Comandante.Application.ValidationRules;
using Comandante.Domain.Shared;
using FluentValidation;
using MediatR;

namespace Comandante.Application.DomainIntents.EventGroups.Command.Create;

public class CreateEventGroupCommandValidator : AbstractValidator<CreateEventGroupCommand>
{
    public CreateEventGroupCommandValidator()
    {
        RuleFor(x => x.EventGroup.Id)
            .NotEmpty()
            .WithMessage("Id группы событий не может быть пустым")
            .MaximumLength(50)
            .WithMessage("Макс. длина Id группы событий не должна превышать 50 символов");

        RuleFor(x => x.EventGroup.Name)
            .NotEmpty()
            .WithMessage("Имя группы событий не может быть пустым")
            .MaximumLength(250)
            .WithMessage("Макс. длина имени группы событий не должна превышать 250 символов");
    }
}
