using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.EventGroupDetails.Command.Delete;

public sealed record DeleteEventGroupDetailsCommand(int EventGroupDetailId) 
    : IRequest<Result>;
