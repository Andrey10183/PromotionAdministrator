using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.PromotionGroup.Command.DeletePromoGroup;

public sealed record DeletePromoGroupCommand(string Code) : IRequest<Result>;
