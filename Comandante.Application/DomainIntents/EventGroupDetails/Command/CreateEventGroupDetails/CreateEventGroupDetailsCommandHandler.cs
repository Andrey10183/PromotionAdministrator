using Comandante.Domain.RepositoryInterfaces;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.EventGroupDetails.Command.CreateEventGroupDetails;

public class CreateEventGroupDetailsCommandHandler 
    : IRequestHandler<CreateEventGroupDetailsCommand, Result>
{
    private readonly IEventGroupDetailsRepository _eventGroupDetailsRepository;

    public CreateEventGroupDetailsCommandHandler(IEventGroupDetailsRepository eventGroupDetailsRepository)
    {
        _eventGroupDetailsRepository = eventGroupDetailsRepository;
    }

    public async Task<Result> Handle(CreateEventGroupDetailsCommand request, CancellationToken cancellationToken)
    {
        return await _eventGroupDetailsRepository.Create(
            request.EventGroupDetail, 
            cancellationToken);
    }
}
