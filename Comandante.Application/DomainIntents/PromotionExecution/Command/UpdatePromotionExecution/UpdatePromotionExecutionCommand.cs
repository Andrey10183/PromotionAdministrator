using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.PromotionExecution.Command.UpdatePromotionExecution;

public sealed record UpdatePromotionExecutionCommand(Domain.Entities.PromotionExecution PromotionExecution) 
    : IRequest<Result>;
