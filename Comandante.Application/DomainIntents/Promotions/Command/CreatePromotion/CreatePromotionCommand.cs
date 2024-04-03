using Comandante.Domain.Entities;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.Promotions.Command.CreatePromotion;

public sealed record CreatePromotionCommand(Promotion Promotion) 
    : IRequest<Result<Promotion>>;
