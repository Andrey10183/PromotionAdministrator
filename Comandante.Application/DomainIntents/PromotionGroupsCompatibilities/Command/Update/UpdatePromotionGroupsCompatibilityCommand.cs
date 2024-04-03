using Comandante.Domain.Entities;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.PromotionGroupsCompatibilities.Command.Update;

public sealed record UpdatePromotionGroupsCompatibilityCommand(PromotionGroupsCompatibility Compatibility)
    : IRequest<Result<PromotionGroupsCompatibility>>;
