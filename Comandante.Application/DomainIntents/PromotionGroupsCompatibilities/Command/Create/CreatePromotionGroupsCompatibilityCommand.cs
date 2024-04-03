using Comandante.Domain.Entities;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.PromotionGroupsCompatibilities.Command.Create;

public sealed record CreatePromotionGroupsCompatibilityCommand(PromotionGroupsCompatibility Compatibility)
    : IRequest<Result<PromotionGroupsCompatibility>>;
