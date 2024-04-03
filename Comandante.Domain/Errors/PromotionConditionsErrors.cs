using Comandante.Domain.Shared;

namespace Comandante.Domain.Errors;

public class PromotionConditionsErrors
{
    public static readonly Error DatabaseError = new(
        "PromotionConditions.DatabaseErrorWileAddEntry",
        "Не удалось добавить условие для акции");

    public static readonly Error IdNotExists = new(
        "PromotionConditions.IdNotFound",
        "Не удалось найти условие акции по Id");
}
