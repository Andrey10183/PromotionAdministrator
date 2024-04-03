using Comandante.Domain.Entities;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.Promotions.Query.GetPromotionById;

public sealed record GetPromotionByIdQuery(int Id)
    : IRequest<Result<Promotion>>;
