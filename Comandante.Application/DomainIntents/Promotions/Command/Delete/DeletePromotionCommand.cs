using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.Promotions.Command.Delete;

public sealed record DeletePromotionCommand(int PromoId) : IRequest<Result<int>>;
