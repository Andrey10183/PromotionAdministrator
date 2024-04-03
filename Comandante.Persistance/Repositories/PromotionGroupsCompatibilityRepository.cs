using Comandante.App;
using Comandante.Domain.Entities;
using Comandante.Domain.Errors;
using Comandante.Domain.RepositoryInterfaces;
using Comandante.Domain.Shared;
using Comandante.Persistance.Helper;
using Comandante.Persistance.Models.PromotionModelsEf;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Comandante.Persistance.Repositories;

public class PromotionGroupsCompatibilityRepository : IPromotionGroupsCompatibilityRepository
{
    private readonly IDbContextFactory<PromotionContext> _dbWriteContextFactory;
    private readonly IDbContextFactory<PromotionContext> _dbReadContextFactory;

    public PromotionGroupsCompatibilityRepository(
        IPromotionContextFactorySelector contextFactorySelector)
    {
        _dbWriteContextFactory = contextFactorySelector.GetFactory(false);
        _dbReadContextFactory = contextFactorySelector.GetFactory(true);
    }

    public async Task<PromotionGroupsCompatibility?> GetByCode(int id, CancellationToken token = default)
    {
        await using var context = await _dbReadContextFactory.CreateDbContextAsync(token);

        var itemEf = await context.PromotionGroupsCompatibilities
            .AsNoTracking()
            .FirstOrDefaultAsync(x=> x.Id == id, token);

        var item = itemEf?.Adapt<PromotionGroupsCompatibility>();

        return item;
    }

    public async Task<List<PromotionGroupsCompatibility>> GetAll(CancellationToken token = default)
    {
        await using var context = await _dbReadContextFactory.CreateDbContextAsync(token);

        var itemsEf = await context.PromotionGroupsCompatibilities
            .AsNoTracking()
            .ToListAsync(token);

        var items = itemsEf?.Adapt<List<PromotionGroupsCompatibility>>();

        return items ?? new();
    }

    public async Task<Result<PromotionGroupsCompatibility>> Create(
        PromotionGroupsCompatibility promotionGroupsCompatibility, 
        CancellationToken token = default)
    {
        promotionGroupsCompatibility.CreateDateTime = DateTime.Now;

        await using var context = await _dbWriteContextFactory.CreateDbContextAsync(token);

        var itemEf = promotionGroupsCompatibility.Adapt<PromotionGroupsCompatibilityEf>();

        context.PromotionGroupsCompatibilities.Add(itemEf);

        var affectedEntries = await context.SaveChangesAsync(token);

        var result = itemEf?.Adapt<PromotionGroupsCompatibility>();

        return affectedEntries == 1 ? 
            result : 
            PromotionGroupsCompatibilitiesErrors.DatabaseError;
    }

    public async Task<Result<PromotionGroupsCompatibility>> Update(
        PromotionGroupsCompatibility promotionGroupsCompatibility, 
        CancellationToken token = default)
    {
        promotionGroupsCompatibility.ChangeDateTime = DateTime.Now;

        await using var context = await _dbWriteContextFactory.CreateDbContextAsync(token);
        
        var updatedEntity = await context.PromotionGroupsCompatibilities
            .FirstOrDefaultAsync(x => x.Id == promotionGroupsCompatibility.Id, token);

        if (updatedEntity == null)
        {
            return PromotionGroupsCompatibilitiesErrors.IdNotExists;
        }

        var promoGroupCompEf = promotionGroupsCompatibility.Adapt<PromotionGroupsCompatibilityEf>();


        context.Entry(updatedEntity).CurrentValues.SetValues(promoGroupCompEf);

        var affectedEntries = await context.SaveChangesAsync(token);

        var result = updatedEntity?.Adapt<PromotionGroupsCompatibility>();

        return affectedEntries == 1 ?
            result :
            PromotionGroupsCompatibilitiesErrors.DatabaseError;
    }

    public async Task<Result> Delete(int id, CancellationToken token = default)
    {
        await using var context = await _dbWriteContextFactory.CreateDbContextAsync(token);
        
        var entityToDelete = await context.PromotionGroupsCompatibilities
            .FirstOrDefaultAsync(x => x.Id == id, token);

        if (entityToDelete == null)
        {
            return PromotionGroupsCompatibilitiesErrors.IdNotExists;
        }

        context.PromotionGroupsCompatibilities.Remove(entityToDelete);
        
        var affectedEntries = await context.SaveChangesAsync(token);

        return affectedEntries == 1 ? 
            Result.Success() : 
            PromotionGroupsCompatibilitiesErrors.DatabaseError;
    }
}
