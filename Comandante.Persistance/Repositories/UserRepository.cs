using Comandante.Domain.Entities;
using Comandante.Domain.Errors;
using Comandante.Domain.RepositoryInterfaces;
using Comandante.Domain.Shared;

namespace Comandante.Persistance.Repositories;

public class UserRepository : IUserRepository
{
    public async Task<Result<User>> GetUserByEmail(string email, CancellationToken token = default)
    {
        var user = UsersDataStorage.Users.FirstOrDefault(x => x.Email == email);

        return user is null ? 
            UserErrors.EmailNotExists : 
            user;
    }
}
