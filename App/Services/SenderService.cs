using Comandante.Application.DomainIntents.EventGroupDetails.Query.GetEventGroupDetailsByConsitionsIds;
using Comandante.Application.DomainIntents.EventGroups.Query.GetAll;
using Comandante.Application.DomainIntents.PromotionActions.Query.GetPromotionActions;
using Comandante.Application.DomainIntents.PromotionConditions.Query.GetPromotionConditionsByPromoId;
using Comandante.Application.DomainIntents.PromotionExecution.Query.GetPromotionExecutionByPromoId;
using Comandante.Application.DomainIntents.PromotionGroup.Query.GetAll;
using Comandante.Application.DomainIntents.PromotionGroupsCompatibilities.Query.GetAll;
using Comandante.Application.DomainIntents.Promotions.Query.GetPromotionsByStatus;
using Comandante.Domain.Entities;
using Comandante.Domain.Enums;
using Comandante.Domain.Shared;
using MediatR;
using MudBlazor;

namespace Comandante.App.Services;

public class SenderService
{
    private readonly ISender _sender;
    private readonly IDialogService _dialogService;
    private readonly SnackBarService _barService;

    public SenderService(
        ISender sender, 
        IDialogService dialogService, 
        SnackBarService barService)
    {
        _sender = sender;
        _dialogService = dialogService;
        _barService = barService;
    }

    public async Task<List<Promotion>> GetPromotions(PromotionsTypes promotionsTypes)
    {
        var getPromotionsQuery = new GetPromotionByStatusQuery(promotionsTypes);
        var result = await _sender.Send(getPromotionsQuery);

        CheckResult(result);

        if (result.Value == null ||
            !result.Value.Any())
            return new();

        var promotions = result.Value.OrderBy(x => x.Name).ToList();

        return promotions;
    }

    public async Task<List<PromotionCondition>> GetPromoConditions(int promoId)
    {
        var query = new GetPromotionConditionsByPromoIdQuery(promoId);
        var result = await _sender.Send(query);

        CheckResult(result);

        if (result.Value == null ||
            !result.Value.Any())
            return new();

        var conditions = result.Value.OrderBy(x => x.Priority).ToList();

        return result?.Value ?? new();
    }

    public async Task<List<EventGroup>> GetEventGroups()
    {
        var query = new GetAllEventGroupQuery();
        var result = await _sender.Send(query);

        CheckResult(result);

        return result.Value ?? new();
    }

    public async Task<List<PromotionActions>> GetPromotionActions()
    {
        var command = new GetPromotionActionsQuery();
        var result = await _sender.Send(command);

        CheckResult(result);

        return result.Value ?? new();
    }
    
    public async Task<List<EventGroupDetail>> GetEventGroupDetails(string eventGroupId)
    {
        var query = new GetEventGroupDetailsByConditionsIdsQuery(eventGroupId);
        var result = await _sender.Send(query);

        CheckResult(result);

        return result.Value ?? new();
    }

    public async Task<List<PromotionGroup>> GetPromotionsGroups()
    {
        var promoGroupQuery = new GetAllPromoGroupsQuery();
        var result = await _sender.Send(promoGroupQuery);

        CheckResult(result);
        
        return result?.Value ?? new();
    }

    public async Task<List<PromotionGroupsCompatibility>> GetCompatibilitiesGroups()
    {
        var query = new GetAllPromotionGroupsCompatibilityQuery();
        var result = await _sender.Send(query);

        CheckResult(result);

        return result?.Value ?? new();
    }

    public async Task<List<PromotionExecution>> GetPromotionExecutions(int promoId)
    {
        var query = new GetPromoExecutionByPromoIdQuery(promoId);
        var result = await _sender.Send(query);

        CheckResult(result);

        return result?.Value ?? new();
    }

    private void CheckResult<T>(T result)
        where T : Result
    {
        if (result.IsFailure)
        {
            _barService.ShowMessage(
            Severity.Error, 
                result?.Error?.Description ?? "Ошибка получения данных совместимости групп");
        }
    }
}
