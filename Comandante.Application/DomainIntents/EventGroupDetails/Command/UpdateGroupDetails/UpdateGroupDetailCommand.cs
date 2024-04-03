using Comandante.Domain.Entities;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.EventGroupDetails.Command.UpdateGroupDetails;

public sealed record UpdateGroupDetailCommand(EventGroupDetail EventGroupDetail)
    : IRequest<Result>;
