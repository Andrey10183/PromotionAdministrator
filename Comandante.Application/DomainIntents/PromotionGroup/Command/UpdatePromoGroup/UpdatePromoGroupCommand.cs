using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.PromotionGroup.Command.UpdatePromoGroup;

public sealed record UpdatePromoGroupCommand(Domain.Entities.PromotionGroup PromotionGroup)
    : IRequest<Result<Domain.Entities.PromotionGroup>>;
