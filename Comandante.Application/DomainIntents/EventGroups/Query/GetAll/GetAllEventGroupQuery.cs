using Comandante.Domain.Entities;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.EventGroups.Query.GetAll;

public sealed record GetAllEventGroupQuery() 
    : IRequest<Result<List<EventGroup>>>;
