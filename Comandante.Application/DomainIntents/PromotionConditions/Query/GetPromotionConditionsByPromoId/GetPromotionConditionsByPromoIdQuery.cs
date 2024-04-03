using Comandante.Domain.Entities;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.PromotionConditions.Query.GetPromotionConditionsByPromoId
{
    public sealed record GetPromotionConditionsByPromoIdQuery(int PromoId) 
        : IRequest<Result<List<PromotionCondition>>>;
}
