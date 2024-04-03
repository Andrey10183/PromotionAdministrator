using Comandante.Domain.Shared;

namespace Comandante.Domain.Errors;

public class EventGroupErrors
{
    public static readonly Error DatabaseError = new(
        "EventGroup.DatabaseErrorWileAddEntry",
        "Возникла ошибка при добавлении группы событий");

    public static readonly Error IdNotExists = new(
        "EventGroup.IdNotFound",
        "Id группы событий не найден");

    public static readonly Error IdAlreadyExist = new(
        "EventGroup.IdAlreadyExist",
        "Запись с указанным кодом уже существует");
}
