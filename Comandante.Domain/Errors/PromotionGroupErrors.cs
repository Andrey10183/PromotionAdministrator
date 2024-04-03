using Comandante.Domain.Shared;

namespace Comandante.Domain.Errors;

public class PromotionGroupErrors
{
    public static readonly Error DatabaseError = new(
        "PromotionGroup.DatabaseErrorWileAddEntry",
        "Не удается записать группу акций в базу данных");

    public static readonly Error IdNotExists = new(
        "PromotionGroup.CodeNotFound",
        "Не удается найти запись по коду (Id)");

    public static readonly Error IdAlreadyExist = new(
        "PromotionGroup.IdAlreadyExist",
        "Запись с указанным кодом уже существует");
}
