using Comandante.Domain.Entities;

namespace Comandante.Domain.RepositoryInterfaces;

public interface IPromotionActionsRepository
{
    Task<List<PromotionActions>> GetAll(CancellationToken token = default);
}
