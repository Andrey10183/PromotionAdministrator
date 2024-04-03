using Comandante.Domain.Entities;
using Comandante.Domain.RepositoryInterfaces;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.PromotionConditions.Command.CreatePromoCondition;

public class CreatePromoConditionCommandHandler : IRequestHandler<CreatePromoConditionCommand, Result<PromotionCondition>>
{
    private readonly IPromotionConditionRepository _promotionConditionRepository;

    public CreatePromoConditionCommandHandler(IPromotionConditionRepository promotionConditionRepository)
    {
        _promotionConditionRepository = promotionConditionRepository;
    }

    public async Task<Result<PromotionCondition>> Handle(CreatePromoConditionCommand request, CancellationToken cancellationToken)
    {
        return await _promotionConditionRepository.Create(
            request.PromCondition, 
            cancellationToken);
    }
}
