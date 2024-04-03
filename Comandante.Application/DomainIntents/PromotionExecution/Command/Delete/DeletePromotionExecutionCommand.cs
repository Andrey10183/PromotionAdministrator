using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.PromotionExecution.Command.Delete;

public sealed record DeletePromotionExecutionCommand(int PromoExecutionId) : IRequest<Result>;
