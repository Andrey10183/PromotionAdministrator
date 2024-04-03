using Comandante.Domain.Entities;
using Comandante.Domain.Enums;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.Promotions.Query.GetPromotionsByStatus;

public sealed record GetPromotionByStatusQuery(PromotionsTypes PromotionsTypes) 
    : IRequest<Result<List<Promotion>>>;
