using Comandante.Domain.RepositoryInterfaces;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.PromotionExecution.Command.UpdatePromotionExecution
{
    public class UpdatePromotionExecutionCommandHandler : IRequestHandler<UpdatePromotionExecutionCommand, Result>
    {
        private readonly IPromotionExecutionRepository _promotionExecutionRepository;

        public UpdatePromotionExecutionCommandHandler(IPromotionExecutionRepository promotionExecutionRepository)
        {
            _promotionExecutionRepository = promotionExecutionRepository;
        }

        public async Task<Result> Handle(UpdatePromotionExecutionCommand request, CancellationToken cancellationToken)
        {
            return await _promotionExecutionRepository.Update(
                request.PromotionExecution,
                cancellationToken);
        }
    }
}
