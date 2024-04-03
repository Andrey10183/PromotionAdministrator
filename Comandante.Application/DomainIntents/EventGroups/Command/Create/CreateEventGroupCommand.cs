using Comandante.Domain.Entities;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.EventGroups.Command.Create;

public record CreateEventGroupCommand(EventGroup EventGroup)
    : IRequest<Result<EventGroup>>;

//public class CreateEventGroupCommand : IRequest<Result<EventGroup>>, IEventGroupCommand
//{
//    public EventGroup EventGroup { get; set; }
//}

//public interface IEventGroupCommand
//{
//    public EventGroup EventGroup { get; set; }
//}
