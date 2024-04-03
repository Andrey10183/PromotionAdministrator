using Comandante.Domain.Entities;
using Comandante.Domain.Enums;
using Comandante.Domain.Shared;

namespace Comandante.Domain.RepositoryInterfaces;

public interface IPromotionRepository
{
    Task<Promotion?> GetById(int id, CancellationToken token = default);
    Task<List<Promotion>> GetPastPromotions(CancellationToken token = default);
    Task<List<Promotion>> GetCurrentPromotions(CancellationToken token = default);
    Task<List<Promotion>> GetFuturePromotions(CancellationToken token = default);
    Task<List<Promotion>> GetTestPromotions(CancellationToken token = default);
    Task<List<Promotion>> GetDisabledPromotions(CancellationToken token = default);
    Task<Result<Promotion>> Create(Promotion promotion, CancellationToken token);
    Task<Result<Promotion>> Update(Promotion promotion, CancellationToken token = default);
    Task<Result<int>> Delete(int id, CancellationToken token = default);
    Task<Result<Promotion>> Duplicate(
        int promotionId,
        PromotionDuplicateProperty duplicateProperty,
        CancellationToken token = default);
}
