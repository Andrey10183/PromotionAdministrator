using Comandante.Domain.RepositoryInterfaces;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.PromotionExecution.Command.CreatePromotionExecution;

public class CreatePromotionExecutionCommandHandler 
    : IRequestHandler<CreatePromotionExecutionCommand, Result>
{
    private readonly IPromotionExecutionRepository _promotionExecutionRepository;

    public CreatePromotionExecutionCommandHandler(IPromotionExecutionRepository promotionExecutionRepository)
    {
        _promotionExecutionRepository = promotionExecutionRepository;
    }

    public async Task<Result> Handle(CreatePromotionExecutionCommand request, CancellationToken cancellationToken)
    {
        return await _promotionExecutionRepository.Create(
            request.PromotionExecution, 
            cancellationToken);
    }
}
