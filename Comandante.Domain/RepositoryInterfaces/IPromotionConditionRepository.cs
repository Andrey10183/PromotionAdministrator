using Comandante.Domain.Entities;
using Comandante.Domain.Shared;

namespace Comandante.Domain.RepositoryInterfaces;

public interface IPromotionConditionRepository
{
    Task<List<PromotionCondition>> GetById(
        int promotionId,
        CancellationToken token = default);

    Task<Result<PromotionCondition>> Create(
        PromotionCondition promotionCondition,
        CancellationToken token = default);
    Task<Result<PromotionCondition>> Update(
        PromotionCondition promotionCondition,
        CancellationToken token = default);

    Task<Result<int>> Delete(
        int id, 
        CancellationToken token = default);
}
