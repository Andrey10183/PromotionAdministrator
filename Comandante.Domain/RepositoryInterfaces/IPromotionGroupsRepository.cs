using Comandante.Domain.Entities;
using Comandante.Domain.Shared;

namespace Comandante.Domain.RepositoryInterfaces;

public interface IPromotionGroupsRepository
{
    Task<PromotionGroup?> GetByCode(string code, CancellationToken token = default);
    Task<List<PromotionGroup>> GetAll(CancellationToken token = default);
    Task<Result<PromotionGroup>> CreatePromotionGroup(PromotionGroup promotionGroup, CancellationToken token = default);
    Task<Result<PromotionGroup>> UpdatePromotionGroup(PromotionGroup promotionGroup, CancellationToken token = default);
    Task<Result> DeletePromotionGroup(string code, CancellationToken token = default);
}
