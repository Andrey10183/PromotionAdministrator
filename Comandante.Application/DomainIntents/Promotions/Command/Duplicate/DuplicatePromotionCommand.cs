using Comandante.Domain.Entities;
using Comandante.Domain.Enums;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.Promotions.Command.Duplicate;

public sealed record DuplicatePromotionCommand(
        PromotionDuplicateProperty DuplicateProperty, 
        int PromoId) 
    : IRequest<Result<Promotion>>;