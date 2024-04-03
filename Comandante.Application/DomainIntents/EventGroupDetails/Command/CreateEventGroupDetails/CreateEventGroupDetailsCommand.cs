using Comandante.Domain.Entities;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.EventGroupDetails.Command.CreateEventGroupDetails;

public sealed record CreateEventGroupDetailsCommand(EventGroupDetail EventGroupDetail)
    : IRequest<Result>;
