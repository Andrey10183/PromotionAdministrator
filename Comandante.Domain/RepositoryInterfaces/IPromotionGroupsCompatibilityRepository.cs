using Comandante.Domain.Entities;
using Comandante.Domain.Shared;

namespace Comandante.Domain.RepositoryInterfaces;

public interface IPromotionGroupsCompatibilityRepository
{
    Task<PromotionGroupsCompatibility?> GetByCode(int id, CancellationToken token = default);
    Task<List<PromotionGroupsCompatibility>> GetAll(CancellationToken token = default);
    Task<Result<PromotionGroupsCompatibility>> Create(PromotionGroupsCompatibility promotionGroup, CancellationToken token = default);
    Task<Result<PromotionGroupsCompatibility>> Update(PromotionGroupsCompatibility promotionGroup, CancellationToken token = default);
    Task<Result> Delete(int id, CancellationToken token = default);
}
