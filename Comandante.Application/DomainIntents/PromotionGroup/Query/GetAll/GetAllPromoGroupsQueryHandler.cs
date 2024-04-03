using Comandante.Domain.RepositoryInterfaces;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.PromotionGroup.Query.GetAll;

public class GetAllPromoGroupsQueryHandler : IRequestHandler<GetAllPromoGroupsQuery, Result<List<Domain.Entities.PromotionGroup>>>
{
    private readonly IPromotionGroupsRepository _promotionGroupsRepository;

    public GetAllPromoGroupsQueryHandler(IPromotionGroupsRepository promotionGroupsRepository)
    {
        _promotionGroupsRepository = promotionGroupsRepository;
    }

    public async Task<Result<List<Domain.Entities.PromotionGroup>>> Handle(GetAllPromoGroupsQuery request, CancellationToken cancellationToken)
    {
        return await _promotionGroupsRepository.GetAll(cancellationToken);
    }
}
