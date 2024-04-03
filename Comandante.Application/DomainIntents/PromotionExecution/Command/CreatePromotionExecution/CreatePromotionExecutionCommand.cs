using Comandante.Domain.Shared;
using Comandante.Domain.Entities;
using MediatR;

namespace Comandante.Application.DomainIntents.PromotionExecution.Command.CreatePromotionExecution;

public sealed record CreatePromotionExecutionCommand(Domain.Entities.PromotionExecution PromotionExecution)
    : IRequest<Result>;
