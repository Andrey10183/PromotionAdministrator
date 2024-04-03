using Comandante.Domain.Entities;
using Comandante.Domain.RepositoryInterfaces;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.PromotionConditions.Query.GetPromotionConditionsByPromoId;
public class GetPromotionConditionsByPromoIdQueryHandler 
    : IRequestHandler<GetPromotionConditionsByPromoIdQuery, Result<List<PromotionCondition>>>
{
    private readonly IPromotionConditionRepository _promotionConditionRepository;

    public GetPromotionConditionsByPromoIdQueryHandler(IPromotionConditionRepository promotionConditionRepository)
    {
        _promotionConditionRepository = promotionConditionRepository;
    }

    public async Task<Result<List<PromotionCondition>>> Handle(
        GetPromotionConditionsByPromoIdQuery request, 
        CancellationToken cancellationToken)
    {
        var propotionConditions = await _promotionConditionRepository
            .GetById(request.PromoId, cancellationToken);

        return propotionConditions;
    }
}
