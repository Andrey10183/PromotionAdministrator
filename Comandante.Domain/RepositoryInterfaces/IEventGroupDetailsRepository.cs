using Comandante.Domain.Entities;
using Comandante.Domain.Shared;

namespace Comandante.Domain.RepositoryInterfaces;

public interface IEventGroupDetailsRepository
{
    Task<List<EventGroupDetail>> GetById(
        string promoConditionId,
        CancellationToken token = default);

    Task<Result> Create(EventGroupDetail eventGroupDetail, CancellationToken token);
    Task<Result> Update(EventGroupDetail eventGroupDetail, CancellationToken token);

    Task<Result> Delete(int id, CancellationToken token = default);
}
