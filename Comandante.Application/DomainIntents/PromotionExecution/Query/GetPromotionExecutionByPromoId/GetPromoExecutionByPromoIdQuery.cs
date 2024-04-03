using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.PromotionExecution.Query.GetPromotionExecutionByPromoId;

public sealed record GetPromoExecutionByPromoIdQuery(int PromoId)
    : IRequest<Result<List<Domain.Entities.PromotionExecution>>>;
