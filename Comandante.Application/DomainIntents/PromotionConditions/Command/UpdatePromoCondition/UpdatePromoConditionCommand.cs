using Comandante.Domain.Entities;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.PromotionConditions.Command.UpdatePromoCondition;

public sealed record UpdatePromoConditionCommand(PromotionCondition PromCondition)
    : IRequest<Result<PromotionCondition>>;
