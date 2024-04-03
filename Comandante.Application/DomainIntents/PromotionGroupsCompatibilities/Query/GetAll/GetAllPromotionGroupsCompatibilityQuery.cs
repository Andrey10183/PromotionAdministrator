using Comandante.Domain.Entities;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.PromotionGroupsCompatibilities.Query.GetAll;

public sealed record GetAllPromotionGroupsCompatibilityQuery 
    : IRequest<Result<List<PromotionGroupsCompatibility>>>;
