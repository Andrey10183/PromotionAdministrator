using Comandante.Domain.RepositoryInterfaces;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.EventGroups.Command.Delete
{
    public class DeleteEventGroupCommandHandler : IRequestHandler<DeleteEventGroupCommand, Result<int>>
    {
        private readonly IEventGroupRepository _repository;

        public DeleteEventGroupCommandHandler(IEventGroupRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<int>> Handle(DeleteEventGroupCommand request, CancellationToken cancellationToken)
        {
            return await _repository.Delete(request.Id, cancellationToken);
        }
    }
}
