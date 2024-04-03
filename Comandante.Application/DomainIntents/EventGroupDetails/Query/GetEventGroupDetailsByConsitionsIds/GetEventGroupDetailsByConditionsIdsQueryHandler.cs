using Comandante.Domain.Entities;
using Comandante.Domain.RepositoryInterfaces;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.EventGroupDetails.Query.GetEventGroupDetailsByConsitionsIds;

public class GetEventGroupDetailsByConditionsIdsQueryHandler 
    : IRequestHandler<GetEventGroupDetailsByConditionsIdsQuery, Result<List<EventGroupDetail>>>
{
    private readonly IEventGroupDetailsRepository _eventGroupDetailsRepository;

    public GetEventGroupDetailsByConditionsIdsQueryHandler(IEventGroupDetailsRepository eventGroupDetailsRepository)
    {
        _eventGroupDetailsRepository = eventGroupDetailsRepository;
    }

    public async Task<Result<List<EventGroupDetail>>> Handle(
        GetEventGroupDetailsByConditionsIdsQuery request, 
        CancellationToken cancellationToken)
    {
        var details = await _eventGroupDetailsRepository.GetById(
            request.ConditionsId,
            cancellationToken);

        return details;
    }
}
