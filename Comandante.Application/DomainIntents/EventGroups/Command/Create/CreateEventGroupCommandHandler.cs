using Comandante.Domain.Entities;
using Comandante.Domain.RepositoryInterfaces;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.EventGroups.Command.Create;

public class CreateEventGroupCommandHandler : IRequestHandler<CreateEventGroupCommand, Result<EventGroup>>
{
    private readonly IEventGroupRepository _repository;

    public CreateEventGroupCommandHandler(IEventGroupRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<EventGroup>> Handle(CreateEventGroupCommand request, CancellationToken cancellationToken)
    {
        return await _repository.Create(request.EventGroup, cancellationToken);
    }
}
