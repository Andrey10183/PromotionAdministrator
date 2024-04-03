using Comandante.Domain.RepositoryInterfaces;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.PromotionActions.Query.GetPromotionActions;

public class GetPromotionActionsQueryHandler 
    : IRequestHandler<GetPromotionActionsQuery, Result<List<Domain.Entities.PromotionActions>>>
{
    private readonly IPromotionActionsRepository _promotionActionsRepository;

    public GetPromotionActionsQueryHandler(IPromotionActionsRepository promotionActionsRepository)
    {
        _promotionActionsRepository = promotionActionsRepository;
    }

    public async Task<Result<List<Domain.Entities.PromotionActions>>> Handle(GetPromotionActionsQuery request, CancellationToken cancellationToken)
    {
        return await _promotionActionsRepository.GetAll(cancellationToken);
    }
}
