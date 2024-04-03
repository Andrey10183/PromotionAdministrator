using Comandante.Domain.Entities;
using Comandante.Domain.RepositoryInterfaces;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.Users.Query.GetUserByEmail;

public class UserByEmailQueryHandler : IRequestHandler<UserByEmailQuery, Result<User>>
{
    private readonly IUserRepository _repository;

    public UserByEmailQueryHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<User>> Handle(UserByEmailQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetUserByEmail(request.Email, cancellationToken);
    }
}