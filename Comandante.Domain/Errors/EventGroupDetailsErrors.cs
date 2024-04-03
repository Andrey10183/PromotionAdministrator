using Comandante.Domain.Shared;

namespace Comandante.Domain.Errors;
public class EventGroupDetailsErrors
{
    public static readonly Error DatabaseError = new(
        "EventGroupDetails.DatabaseErrorWileAddEntry",
        "Возникла ошибка при добавлении условий акции");

    public static readonly Error IdNotExists = new(
        "EventGroupDetails.IdNotFound",
        "Id условий акции не найден");
}
