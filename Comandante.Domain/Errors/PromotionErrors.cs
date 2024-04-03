using Comandante.Domain.Shared;

namespace Comandante.Domain.Errors;

public class PromotionErrors
{
    public static readonly Error DatabaseError = new(
        "Promotion.DatabaseErrorWileAddEntry",
        "Не удалось записать Акцию в базуданных");

    public static readonly Error IdNotExists = new(
        "Promotion.IdNotFound",
        "Не удалось найти указанную акцию по Id");
}
