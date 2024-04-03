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

public class PromotionGroupRepository : IPromotionGroupsRepository
{
    private readonly IDbContextFactory<PromotionContext> _dbWriteContextFactory;
    private readonly IDbContextFactory<PromotionContext> _dbReadContextFactory;

    public PromotionGroupRepository(IPromotionContextFactorySelector contextFactorySelector)
    {
        _dbWriteContextFactory = contextFactorySelector.GetFactory(false);
        _dbReadContextFactory = contextFactorySelector.GetFactory(true);
    }

    public async Task<PromotionGroup?> GetByCode(string code, CancellationToken token = default)
    {
        await using var context = await _dbReadContextFactory.CreateDbContextAsync(token);

        var promoGroupEf = await context.PromotionGroups
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Code == code, token);

        var promoGroup = promoGroupEf?.Adapt<PromotionGroup>();

        return promoGroup;
    }

    public async Task<List<PromotionGroup>> GetAll(CancellationToken token = default)
    {
        await using var context = await _dbReadContextFactory.CreateDbContextAsync(token);

        var promoGroupsEf = await context.PromotionGroups
            .AsNoTracking()
            .ToListAsync(token);

        var promoGroups = promoGroupsEf?.Adapt<List<PromotionGroup>>();

        return promoGroups ?? new();
    }

    public async Task<Result<PromotionGroup>> CreatePromotionGroup(PromotionGroup promotionGroup, CancellationToken token = default)
    {
        promotionGroup.CreateDateTime = DateTime.Now;

        await using var context = await _dbWriteContextFactory.CreateDbContextAsync(token);

        var isExist = await GetByCodeEf(promotionGroup.Code, token);

        if (isExist != null)
        {
            return PromotionGroupErrors.IdAlreadyExist;
        }

        var promoGroupEf = promotionGroup.Adapt<PromotionGroupEf>();

        context.PromotionGroups.Add(promoGroupEf);

        var affectedEntries = await context.SaveChangesAsync(token);

        var result = promoGroupEf?.Adapt<PromotionGroup>();

        return affectedEntries == 1 ?
            result : 
            PromotionGroupErrors.DatabaseError;
    }

    public async Task<Result<PromotionGroup>> UpdatePromotionGroup(PromotionGroup promotionGroup, CancellationToken token = default)
    {
        promotionGroup.ChangeDateTime = DateTime.Now;

        await using var context = await _dbWriteContextFactory.CreateDbContextAsync(token);
        
        var updatedEntity = await context.PromotionGroups
            .FirstOrDefaultAsync(x => x.Code == promotionGroup.Code, token);

        if (updatedEntity == null)
        {
            return PromotionGroupErrors.IdNotExists;
        }

        var promoGroupEf = promotionGroup.Adapt<PromotionGroupEf>();


        context.Entry(updatedEntity).CurrentValues.SetValues(promoGroupEf);

        var affectedEntries = await context.SaveChangesAsync(token);

        var result = updatedEntity?.Adapt<PromotionGroup>();

        return affectedEntries == 1 ?
            result :
            PromotionGroupErrors.DatabaseError;
    }

    public async Task<Result> DeletePromotionGroup(string code, CancellationToken token = default)
    {
        await using var context = await _dbWriteContextFactory.CreateDbContextAsync(token);

        var promoGroupEf = await GetByCodeEf(code, token);

        if (promoGroupEf is null)
        {
            return PromotionGroupErrors.IdNotExists;
        }

        context.PromotionGroups.Remove(promoGroupEf);
        
        var affectedEntries = await context.SaveChangesAsync(token);

        return affectedEntries == 1 ? Result.Success() : PromotionGroupErrors.DatabaseError;
    }

    private async Task<PromotionGroupEf?> GetByCodeEf(string code, CancellationToken token = default)
    {
        await using var context = await _dbWriteContextFactory.CreateDbContextAsync(token);

        return await context.PromotionGroups.FirstOrDefaultAsync(x => x.Code == code, token);
    }
}
