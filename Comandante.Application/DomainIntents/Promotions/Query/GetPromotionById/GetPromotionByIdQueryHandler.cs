using Comandante.Domain.Entities;
using Comandante.Domain.Errors;
using Comandante.Domain.RepositoryInterfaces;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.Promotions.Query.GetPromotionById;

public class GetPromotionByIdQueryHandler : IRequestHandler<GetPromotionByIdQuery, Result<Promotion>>
{
    private readonly IPromotionRepository _promotionRepository;

    public GetPromotionByIdQueryHandler(IPromotionRepository promotionRepository)
    {
        _promotionRepository = promotionRepository;
    }

    public async Task<Result<Promotion>> Handle(GetPromotionByIdQuery request, CancellationToken cancellationToken)
    {
        var promotion = await _promotionRepository.GetById(request.Id, cancellationToken);

        if (promotion is null)
        {
            return PromotionErrors.IdNotExists;
        }

        return promotion;
    }
}
