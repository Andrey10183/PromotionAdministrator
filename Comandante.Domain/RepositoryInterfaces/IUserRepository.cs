using Comandante.Domain.Entities;
using Comandante.Domain.Shared;

namespace Comandante.Domain.RepositoryInterfaces;

public interface IUserRepository
{
    Task<Result<User>> GetUserByEmail(string email, CancellationToken token = default);
}
