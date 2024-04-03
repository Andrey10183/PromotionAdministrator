using Comandante.Domain.Entities;
using Comandante.Domain.RepositoryInterfaces;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.PromotionConditions.Command.UpdatePromoCondition;

public class UpdatePromoConditionCommandHandler : IRequestHandler<UpdatePromoConditionCommand, Result<PromotionCondition>>
{
    private readonly IPromotionConditionRepository _promotionConditionRepository;

    public UpdatePromoConditionCommandHandler(IPromotionConditionRepository promotionConditionRepository)
    {
        _promotionConditionRepository = promotionConditionRepository;
    }

    public async Task<Result<PromotionCondition>> Handle(UpdatePromoConditionCommand request, CancellationToken cancellationToken)
    {
        return await _promotionConditionRepository.Update(
            request.PromCondition, 
            cancellationToken);
    }
}
