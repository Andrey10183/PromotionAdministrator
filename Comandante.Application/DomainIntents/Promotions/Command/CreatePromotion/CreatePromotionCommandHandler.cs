using Comandante.Domain.Entities;
using Comandante.Domain.RepositoryInterfaces;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.Promotions.Command.CreatePromotion;

public class CreatePromotionCommandHandler : IRequestHandler<CreatePromotionCommand, Result<Promotion>>
{
    private readonly IPromotionRepository _promotionRepository;
    
    public CreatePromotionCommandHandler(
        IPromotionRepository promotionRepository)
    {
        _promotionRepository = promotionRepository;
    }

    public async Task<Result<Promotion>> Handle(CreatePromotionCommand request, CancellationToken cancellationToken)
    {
        return await _promotionRepository.Create(request.Promotion, cancellationToken);
    }
}
