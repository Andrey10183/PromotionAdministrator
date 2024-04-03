using Comandante.Domain.RepositoryInterfaces;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.EventGroupDetails.Command.Delete;

public class DeleteEventGroupDetailsCommandHandler : IRequestHandler<DeleteEventGroupDetailsCommand, Result>
{
    private readonly IEventGroupDetailsRepository _repository;

    public DeleteEventGroupDetailsCommandHandler(IEventGroupDetailsRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(DeleteEventGroupDetailsCommand request, CancellationToken cancellationToken)
    {
        return await _repository.Delete(request.EventGroupDetailId, cancellationToken);
    }
}
