using Comandante.Domain.Shared;

namespace Comandante.Domain.Errors;

public class PromotionExecutionsErrors
{
    public static readonly Error DatabaseError = new(
        "PromotionExecution.DatabaseErrorWileAddEntry",
        "Возникла ошибка при добавлении расписания акции");

    public static readonly Error IdNotExists = new(
        "PromotionExecution.IdNotFound",
        "Невозможно найти расписание акции по данному");
}
