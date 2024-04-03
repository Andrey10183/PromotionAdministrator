using Comandante.Domain.RepositoryInterfaces;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.PromotionExecution.Query.GetPromotionExecutionByPromoId;
public class GetPromoExecutionByPromoIdQueryHandler 
    : IRequestHandler<GetPromoExecutionByPromoIdQuery, Result<List<Domain.Entities.PromotionExecution>>>
{
    private readonly IPromotionExecutionRepository _promotionExecutionRepository;

    public GetPromoExecutionByPromoIdQueryHandler(IPromotionExecutionRepository promotionExecutionRepository)
    {
        _promotionExecutionRepository = promotionExecutionRepository;
    }

    public async Task<Result<List<Domain.Entities.PromotionExecution>>> Handle(GetPromoExecutionByPromoIdQuery request, CancellationToken cancellationToken)
    {
        return await _promotionExecutionRepository.GetById(request.PromoId, cancellationToken);
    }
}
