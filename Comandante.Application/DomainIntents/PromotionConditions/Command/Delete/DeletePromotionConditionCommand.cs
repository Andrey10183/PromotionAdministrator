using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.PromotionConditions.Command.Delete;

public sealed record DeletePromotionConditionCommand(int PromoConditionId) : IRequest<Result<int>>;
