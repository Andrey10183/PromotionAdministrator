using Comandante.Domain.Entities;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.PromotionConditions.Command.CreatePromoCondition;

public sealed record CreatePromoConditionCommand(PromotionCondition PromCondition)
    : IRequest<Result<PromotionCondition>>;
