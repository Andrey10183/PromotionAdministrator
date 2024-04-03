using Comandante.Domain.RepositoryInterfaces;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.PromotionConditions.Command.Delete;

public class DeletePromotionConditionCommandHandler : IRequestHandler<DeletePromotionConditionCommand, Result<int>>
{
    private readonly IPromotionConditionRepository _repository;

    public DeletePromotionConditionCommandHandler(IPromotionConditionRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<int>> Handle(DeletePromotionConditionCommand request, CancellationToken cancellationToken)
    {
        return await _repository.Delete(request.PromoConditionId, cancellationToken);
    }
}