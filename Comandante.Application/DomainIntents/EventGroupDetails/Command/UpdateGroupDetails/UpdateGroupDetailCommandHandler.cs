using Comandante.Domain.RepositoryInterfaces;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.EventGroupDetails.Command.UpdateGroupDetails;

public class UpdateGroupDetailCommandHandler : IRequestHandler<UpdateGroupDetailCommand, Result>
{
    private readonly IEventGroupDetailsRepository _eventGroupDetailsRepository;

    public UpdateGroupDetailCommandHandler(IEventGroupDetailsRepository eventGroupDetailsRepository)
    {
        _eventGroupDetailsRepository = eventGroupDetailsRepository;
    }

    public async Task<Result> Handle(UpdateGroupDetailCommand request, CancellationToken cancellationToken)
    {
        return await _eventGroupDetailsRepository.Update(request.EventGroupDetail, cancellationToken);
    }
}
