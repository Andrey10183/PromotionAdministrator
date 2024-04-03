using Comandante.Domain.Shared;

namespace Comandante.Domain.Errors;

public class UserErrors
{
    public static readonly Error EmailNotExists = new(
        "User.EmailNotFound",
        "Пользователь с указанным email не найден");
}
