using Comandante.App;
using Comandante.Domain.Entities;
using Comandante.Domain.RepositoryInterfaces;
using Comandante.Persistance.Helper;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Comandante.Persistance.Repositories;

public class PromotionActionsRepository :IPromotionActionsRepository
{
    private readonly IDbContextFactory<PromotionContext> _dbReadContextFactory;

    public PromotionActionsRepository(
        IPromotionContextFactorySelector contextFactorySelector)
    {
        _dbReadContextFactory = contextFactorySelector.GetFactory(true);
    }

    public async Task<List<PromotionActions>> GetAll(CancellationToken token = default)
    {
        await using var context = await _dbReadContextFactory.CreateDbContextAsync(token);

        var promoActionsEf = await context.PromotionActions
            .AsNoTracking()
            .ToListAsync(token);

        var promoActions = promoActionsEf?.Adapt<List<PromotionActions>>();

        return promoActions ?? new();
    }
}
