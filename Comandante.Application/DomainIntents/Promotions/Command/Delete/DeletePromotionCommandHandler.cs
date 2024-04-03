using Comandante.Domain.RepositoryInterfaces;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.Promotions.Command.Delete;

public class DeletePromotionCommandHandler : IRequestHandler<DeletePromotionCommand, Result<int>>
{
    private readonly IPromotionRepository _repository;

    public DeletePromotionCommandHandler(IPromotionRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<int>> Handle(DeletePromotionCommand request, CancellationToken cancellationToken)
    {
        return await _repository.Delete(request.PromoId, cancellationToken);
    }
}
