using Comandante.Domain.Entities;
using Comandante.Domain.RepositoryInterfaces;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.EventGroups.Command.Update
{
    public class UpdateEventGroupCommandHandler : IRequestHandler<UpdateEventGroupCommand, Result<EventGroup>>
    {
        private readonly IEventGroupRepository _repository;

        public UpdateEventGroupCommandHandler(IEventGroupRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<EventGroup>> Handle(UpdateEventGroupCommand request, CancellationToken cancellationToken)
        {
            return await _repository.Update(request.EventGroup, cancellationToken);
        }
    }
}
