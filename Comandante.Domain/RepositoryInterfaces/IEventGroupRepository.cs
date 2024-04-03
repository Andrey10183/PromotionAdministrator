using Comandante.Domain.Entities;
using Comandante.Domain.Shared;

namespace Comandante.Domain.RepositoryInterfaces;

public interface IEventGroupRepository
{
    Task<EventGroup?> GetById(string id, CancellationToken token = default);
    Task<List<EventGroup>> GetAll(CancellationToken token = default);
    Task<Result<EventGroup>> Create(EventGroup eventGroup, CancellationToken token = default);
    Task<Result<EventGroup>> Update(EventGroup eventGroup, CancellationToken token = default);
    Task<Result<int>> Delete(string id, CancellationToken token = default);
}
