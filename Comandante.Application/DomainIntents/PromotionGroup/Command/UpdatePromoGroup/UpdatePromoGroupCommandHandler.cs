using Comandante.Domain.Shared;
using MediatR;
using Comandante.Domain.Entities;
using Comandante.Domain.RepositoryInterfaces;

namespace Comandante.Application.DomainIntents.PromotionGroup.Command.UpdatePromoGroup;

public class UpdatePromoGroupCommandHandler : IRequestHandler<UpdatePromoGroupCommand, Result<Domain.Entities.PromotionGroup>>
{
    private readonly IPromotionGroupsRepository _promotionGroupsRepository;

    public UpdatePromoGroupCommandHandler(IPromotionGroupsRepository promotionGroupsRepository)
    {
        _promotionGroupsRepository = promotionGroupsRepository;
    }

    public async Task<Result<Domain.Entities.PromotionGroup>> Handle(UpdatePromoGroupCommand request, CancellationToken cancellationToken)
    {
        return await _promotionGroupsRepository.UpdatePromotionGroup(
            request.PromotionGroup, 
            cancellationToken);
    }
}
