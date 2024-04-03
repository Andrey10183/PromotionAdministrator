using Comandante.Domain.RepositoryInterfaces;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.PromotionGroup.Command.CreatePromoGroup;

public class CreatePromoGroupCommandHandler : IRequestHandler<CreatePromoGroupCommand, Result<Domain.Entities.PromotionGroup>>
{
    private readonly IPromotionGroupsRepository _promotionGroupsRepository;

    public CreatePromoGroupCommandHandler(IPromotionGroupsRepository promotionGroupsRepository)
    {
        _promotionGroupsRepository = promotionGroupsRepository;
    }

    public async Task<Result<Domain.Entities.PromotionGroup>> Handle(CreatePromoGroupCommand request, CancellationToken cancellationToken)
    {
        return await _promotionGroupsRepository.CreatePromotionGroup(
            request.PromotionGroup, 
            cancellationToken);
    }
}
