using Comandante.Domain.Entities;
using Comandante.Domain.RepositoryInterfaces;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.Promotions.Command.UpdatePromotion;

public class UpdatePromotionCommandHandler : IRequestHandler<UpdatePromotionCommand, Result<Promotion>>
{
    private readonly IPromotionRepository _promotionRepository;

    public UpdatePromotionCommandHandler(IPromotionRepository promotionRepository)
    {
        _promotionRepository = promotionRepository;
    }

    public async Task<Result<Promotion>> Handle(UpdatePromotionCommand request, CancellationToken cancellationToken)
    {
        return await _promotionRepository.Update(request.Promotion, cancellationToken);
    }
}
