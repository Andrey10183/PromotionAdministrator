using Comandante.Domain.Entities;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.PromotionActions.Query.GetPromotionActions;

public sealed record GetPromotionActionsQuery
    : IRequest<Result<List<Domain.Entities.PromotionActions>>>;
