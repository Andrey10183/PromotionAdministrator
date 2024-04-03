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
public class PromotionExecutionRepository : IPromotionExecutionRepository
{
    private readonly IDbContextFactory<PromotionContext> _dbWriteContextFactory;
    private readonly IDbContextFactory<PromotionContext> _dbReadContextFactory;

    public PromotionExecutionRepository(IPromotionContextFactorySelector contextFactorySelector)
    {
        _dbWriteContextFactory = contextFactorySelector.GetFactory(false);
        _dbReadContextFactory = contextFactorySelector.GetFactory(true);
    }

    public async Task<List<PromotionExecution>> GetById(int id, CancellationToken token = default)
    {
        await using var context = await _dbReadContextFactory.CreateDbContextAsync(token);

        var promotionExecutionEf = await context.PromotionExecutions
            .AsNoTracking()
            .Where(x => x.PromotionId == id)
            .ToListAsync(token);
        
        var promotionExecution = promotionExecutionEf?.Adapt<List<PromotionExecution>>();

        return promotionExecution ?? new();
    }

    public async Task<Result> Create(PromotionExecution promotionExecution, CancellationToken token = default)
    {
        await using var context = await _dbWriteContextFactory.CreateDbContextAsync(token);

        promotionExecution.CreateDateTime = DateTime.Now;

        var promotionExecutionEf = promotionExecution.Adapt<PromotionExecutionEf>();
        
        context.PromotionExecutions.Add(promotionExecutionEf);

        var affectedEntries = await context.SaveChangesAsync(token);

        return affectedEntries == 1 ? 
            Result.Success() : 
            PromotionExecutionsErrors.DatabaseError;
    }

    public async Task<Result> Update(PromotionExecution promotionExecution, CancellationToken token = default)
    {
        await using var context = await _dbWriteContextFactory.CreateDbContextAsync(token);

        var entryToUpdate = await context.PromotionExecutions
            .FirstOrDefaultAsync(x =>
                x.Id == promotionExecution.Id, token);

        if (entryToUpdate is null)
        {
            return PromotionExecutionsErrors.IdNotExists;
        }

        var promotionExecutionEf = promotionExecution.Adapt<PromotionExecutionEf>();
        entryToUpdate.BeginDate = promotionExecutionEf.BeginDate;
        entryToUpdate.EndDate = promotionExecutionEf.EndDate;
        entryToUpdate.BeginTime = promotionExecutionEf.BeginTime;
        entryToUpdate.EndTime = promotionExecutionEf.EndTime;
        entryToUpdate.ChangeDateTime = DateTime.Now;
        entryToUpdate.DwMonday = promotionExecutionEf.DwMonday;
        entryToUpdate.DwTuesday = promotionExecutionEf.DwTuesday;
        entryToUpdate.DwWednesday = promotionExecutionEf.DwWednesday;
        entryToUpdate.DwThursday = promotionExecutionEf.DwThursday;
        entryToUpdate.DwFriday = promotionExecutionEf.DwFriday;
        entryToUpdate.DwSaturday = promotionExecutionEf.DwSaturday;
        entryToUpdate.DwSunday = promotionExecutionEf.DwSunday;
        entryToUpdate.IsActive = promotionExecutionEf.IsActive;
        entryToUpdate.SalesChannelId = promotionExecutionEf.SalesChannelId;
        entryToUpdate.ShopCode = promotionExecutionEf.ShopCode;
        
        var affectedEntries = await context.SaveChangesAsync(token);

        return affectedEntries == 1 ? 
            Result.Success() : 
            PromotionErrors.DatabaseError;
    }

    public async Task<Result> Delete(int id, CancellationToken token = default)
    {
        await using var context = await _dbWriteContextFactory.CreateDbContextAsync(token);
        
        var entityToDelete = await context.PromotionExecutions
            .FirstOrDefaultAsync(x => x.Id == id, token);

        if (entityToDelete == null)
        {
            return PromotionExecutionsErrors.IdNotExists;
        }

        context.PromotionExecutions.Remove(entityToDelete);
        
        var affectedEntries = await context.SaveChangesAsync(token);

        return affectedEntries == 1 ? 
            Result.Success() : 
            EventGroupErrors.DatabaseError;
    }
}
