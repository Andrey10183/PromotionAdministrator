using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.PromotionGroup.Command.CreatePromoGroup;

public sealed record CreatePromoGroupCommand(Domain.Entities.PromotionGroup PromotionGroup)
    : IRequest<Result<Domain.Entities.PromotionGroup>>;
