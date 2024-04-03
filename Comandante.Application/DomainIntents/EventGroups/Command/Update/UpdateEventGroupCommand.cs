using Comandante.Domain.Entities;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.EventGroups.Command.Update;
public sealed record UpdateEventGroupCommand(EventGroup EventGroup) 
    : IRequest<Result<EventGroup>>;
