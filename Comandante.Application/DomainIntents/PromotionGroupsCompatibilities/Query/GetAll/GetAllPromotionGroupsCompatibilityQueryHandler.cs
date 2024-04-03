using Comandante.Domain.Entities;
using Comandante.Domain.Errors;
using Comandante.Domain.RepositoryInterfaces;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.PromotionGroupsCompatibilities.Query.GetAll;

public class GetAllPromotionGroupsCompatibilityQueryHandler 
    : IRequestHandler<GetAllPromotionGroupsCompatibilityQuery, Result<List<PromotionGroupsCompatibility>>>
{
    private readonly IPromotionGroupsCompatibilityRepository _repo;

    public GetAllPromotionGroupsCompatibilityQueryHandler(IPromotionGroupsCompatibilityRepository repo)
    {
        _repo = repo;
    }

    public async Task<Result<List<PromotionGroupsCompatibility>>> Handle(GetAllPromotionGroupsCompatibilityQuery request, CancellationToken cancellationToken)
    {
        return await _repo.GetAll(cancellationToken);
    }
}
