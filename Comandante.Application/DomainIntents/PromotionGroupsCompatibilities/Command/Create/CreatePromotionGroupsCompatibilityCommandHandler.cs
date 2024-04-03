using Comandante.Domain.Entities;
using Comandante.Domain.RepositoryInterfaces;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.PromotionGroupsCompatibilities.Command.Create;

public class CreatePromotionGroupsCompatibilityCommandHandler
    : IRequestHandler<CreatePromotionGroupsCompatibilityCommand, Result<PromotionGroupsCompatibility>>
{
    private readonly IPromotionGroupsCompatibilityRepository _repository;

    public CreatePromotionGroupsCompatibilityCommandHandler(IPromotionGroupsCompatibilityRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<PromotionGroupsCompatibility>> Handle(CreatePromotionGroupsCompatibilityCommand request, CancellationToken cancellationToken)
    {
        return await _repository.Create(request.Compatibility, cancellationToken);
    }
}
