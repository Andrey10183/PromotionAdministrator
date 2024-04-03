using Comandante.Domain.RepositoryInterfaces;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.PromotionGroupsCompatibilities.Command.Delete;

public class DeletePromotionGroupsCompatibilityCommandHandler
    : IRequestHandler<DeletePromotionGroupsCompatibilityCommand, Result>
{
    private readonly IPromotionGroupsCompatibilityRepository _repository;

    public DeletePromotionGroupsCompatibilityCommandHandler(IPromotionGroupsCompatibilityRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(DeletePromotionGroupsCompatibilityCommand request, CancellationToken cancellationToken)
    {
        return await _repository.Delete(request.Id, cancellationToken);
    }
}
