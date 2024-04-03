using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.PromotionGroupsCompatibilities.Command.Delete;

public sealed record DeletePromotionGroupsCompatibilityCommand(int Id) 
    : IRequest<Result>;
