using Comandante.Domain.Entities;
using Comandante.Domain.Enums;
using Comandante.Domain.RepositoryInterfaces;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.Promotions.Query.GetPromotionsByStatus;

public class GetPromotionByStatusQueryHandler : IRequestHandler<GetPromotionByStatusQuery, Result<List<Promotion>>>
{
    private readonly IPromotionRepository _promotionRepository;

    public GetPromotionByStatusQueryHandler(IPromotionRepository promotionRepository)
    {
        _promotionRepository = promotionRepository;
    }

    public async Task<Result<List<Promotion>>> Handle(GetPromotionByStatusQuery request, CancellationToken cancellationToken)
    {
        return request.PromotionsTypes switch
        {
            PromotionsTypes.WorkingNowPromotions => await _promotionRepository.GetCurrentPromotions(cancellationToken),
            PromotionsTypes.PastPromotions => await _promotionRepository.GetPastPromotions(cancellationToken),
            PromotionsTypes.FuturePromotions => await _promotionRepository.GetFuturePromotions(cancellationToken),
            PromotionsTypes.TestPromotions => await _promotionRepository.GetTestPromotions(cancellationToken),
            PromotionsTypes.NotActivePromotions => await _promotionRepository.GetDisabledPromotions(cancellationToken),
            _ => new()
        };
    }
}
