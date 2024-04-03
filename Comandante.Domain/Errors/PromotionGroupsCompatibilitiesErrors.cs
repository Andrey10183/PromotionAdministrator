using Comandante.Domain.Shared;

namespace Comandante.Domain.Errors;

public class PromotionGroupsCompatibilitiesErrors
{
    public static readonly Error DatabaseError = new(
        "PromotionGroupsCompatibilities.DatabaseErrorWileAddEntry",
        "Не удается записать совместимость группы акций в базу данных");

    public static readonly Error IdNotExists = new(
        "PromotionGroupsCompatibilities.IdNotFound",
        "Не удается найти совместимость группы акций по Id");
}
