using Comandante.Domain.RepositoryInterfaces;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.PromotionGroup.Command.DeletePromoGroup;

public class DeletePromoGroupCommandHandler : IRequestHandler<DeletePromoGroupCommand, Result>
{
    private readonly IPromotionGroupsRepository _promotionGroupsRepository;

    public DeletePromoGroupCommandHandler(IPromotionGroupsRepository promotionGroupsRepository)
    {
        _promotionGroupsRepository = promotionGroupsRepository;
    }

    public async Task<Result> Handle(DeletePromoGroupCommand request, CancellationToken cancellationToken)
    {
        return await _promotionGroupsRepository.DeletePromotionGroup(request.Code, cancellationToken);
    }
}
