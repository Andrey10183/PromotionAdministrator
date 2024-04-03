using Comandante.Domain.Entities;
using Comandante.Domain.RepositoryInterfaces;
using Comandante.Domain.Shared;
using MediatR;

namespace Comandante.Application.DomainIntents.Promotions.Command.Duplicate;

public class DuplicatePromotionCommandHandler : IRequestHandler<DuplicatePromotionCommand, Result<Promotion>>
{
    private readonly IPromotionRepository _repository;

    public DuplicatePromotionCommandHandler(IPromotionRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Promotion>> Handle(DuplicatePromotionCommand request, CancellationToken cancellationToken)
    {
        return await _repository.Duplicate(
            request.PromoId, 
            request.DuplicateProperty, 
            cancellationToken);
    }
}