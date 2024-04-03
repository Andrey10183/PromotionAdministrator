using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.PromotionGroup.Query.GetAll;

public sealed record GetAllPromoGroupsQuery() 
    : IRequest<Result<List<Domain.Entities.PromotionGroup>>>;
