using Comandante.Domain.Entities;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.Users.Query.GetUserByEmail;

public sealed record UserByEmailQuery(string Email) : IRequest<Result<User>>;
