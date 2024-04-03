using Comandante.Domain.Entities;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.EventGroupDetails.Query.GetEventGroupDetailsByConsitionsIds;

public sealed record GetEventGroupDetailsByConditionsIdsQuery(string ConditionsId)
    : IRequest<Result<List<EventGroupDetail>>>;
