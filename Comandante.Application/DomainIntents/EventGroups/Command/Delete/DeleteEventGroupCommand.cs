using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.EventGroups.Command.Delete;

public sealed record DeleteEventGroupCommand(string Id) 
    : IRequest<Result<int>>;
