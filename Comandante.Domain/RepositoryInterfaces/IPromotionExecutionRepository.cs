using Comandante.Domain.Entities;
using Comandante.Domain.Shared;

namespace Comandante.Domain.RepositoryInterfaces;

public interface IPromotionExecutionRepository
{
    Task<List<PromotionExecution>> GetById(int id, CancellationToken token = default);
    Task<Result> Create(PromotionExecution promotionExecution, CancellationToken token = default);
    Task<Result> Update(PromotionExecution promotionExecution, CancellationToken token = default);
    Task<Result> Delete(int id, CancellationToken token = default);
}
