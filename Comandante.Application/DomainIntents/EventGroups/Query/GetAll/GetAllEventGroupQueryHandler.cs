using Comandante.Domain.Entities;
using Comandante.Domain.RepositoryInterfaces;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.EventGroups.Query.GetAll;

public class GetAllEventGroupQueryHandler : IRequestHandler<GetAllEventGroupQuery, Result<List<EventGroup>>>
{
    private readonly IEventGroupRepository _repository;

    public GetAllEventGroupQueryHandler(IEventGroupRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<List<EventGroup>>> Handle(GetAllEventGroupQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAll(cancellationToken);
    }
}
