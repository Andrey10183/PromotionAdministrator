using Comandante.Domain.RepositoryInterfaces;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.PromotionExecution.Command.Delete;

public class DeletePromotionExecutionCommandHandler : IRequestHandler<DeletePromotionExecutionCommand, Result>
{
    private readonly IPromotionExecutionRepository _repository;

    public DeletePromotionExecutionCommandHandler(IPromotionExecutionRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(DeletePromotionExecutionCommand request, CancellationToken cancellationToken)
    {
        return await _repository.Delete(request.PromoExecutionId, cancellationToken);
    }
}
