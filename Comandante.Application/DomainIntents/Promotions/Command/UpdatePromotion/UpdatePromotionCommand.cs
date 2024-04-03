using Comandante.Domain.Entities;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.Promotions.Command.UpdatePromotion;

public sealed record UpdatePromotionCommand(Promotion Promotion)
    : IRequest<Result<Promotion>>;
