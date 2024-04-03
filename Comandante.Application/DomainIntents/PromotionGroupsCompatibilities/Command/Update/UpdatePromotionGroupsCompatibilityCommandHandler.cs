using Comandante.Domain.Entities;
using Comandante.Domain.RepositoryInterfaces;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.PromotionGroupsCompatibilities.Command.Update;

public class UpdatePromotionGroupsCompatibilityCommandHandler 
    : IRequestHandler<UpdatePromotionGroupsCompatibilityCommand, Result<PromotionGroupsCompatibility>>
{
    private readonly IPromotionGroupsCompatibilityRepository _repository;

    public UpdatePromotionGroupsCompatibilityCommandHandler(IPromotionGroupsCompatibilityRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<PromotionGroupsCompatibility>> Handle(UpdatePromotionGroupsCompatibilityCommand request, CancellationToken cancellationToken)
    {
        return await _repository.Update(request.Compatibility, cancellationToken);
    }
}
