using Comandante.Application.DomainIntents.EventGroupDetails.Command.CreateEventGroupDetails;
using Comandante.Application.DomainIntents.PromotionConditions.Command.CreatePromoCondition;
using Comandante.Application.DomainIntents.PromotionExecution.Command.CreatePromotionExecution;
using Comandante.Application.DomainIntents.Promotions.Command.CreatePromotion;
using Comandante.Application.DomainIntents.Promotions.Command.Duplicate;
using Comandante.Application.DomainIntents.Promotions.Query.GetPromotionsByStatus;
using Comandante.Domain.Entities;
using Comandante.Domain.Enums;
using Comandante.Domain.Errors;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Application.IntegrationTests;

public class PromotionTests : BaseIntegrationTest
{
    //For running this tests be shure that Docker is Up and running
    //Test database deploy and up in test container

    //private readonly static Promotion _promoWithEmptyName = PromoHelper.GetPromotionWithEmptyName();
    public PromotionTests(IntegrationTestWebAppFactory factory) 
        : base(factory){}

    [Fact]
    public async Task Create_ShouldAdd_NewPromotionToDatabase()
    {
        //Arrange
        var command = new CreatePromotionCommand(new Promotion()
        {
            SortType = "Price",
            Priority = 100,
            Name = "test promo 1",
            Description = "test promo 1",
            PromotionGroup = "100",
            IsRepeated = false,
            PaymentCompatibility = 0,
            RemindTypeId = "Propose",
            OrderNumber = "Order 1",
            IsActive = true
        });

        //Act
        var result = await Sender.Send(command);

        //Assert
        Assert.True(result.IsSuccess);

        var promotion = DbContext.Promotions
            .FirstOrDefault(x => x.PromotionId == result.Value.PromotionId);

        Assert.NotNull(result.Value);
        Assert.NotNull(promotion);
        Assert.Equal(command.Promotion.Description, promotion.Description);
        Assert.Equal(command.Promotion.Name, promotion.Name);
        Assert.Equal(command.Promotion.OrderNumber, promotion.OrderNumber);
        Assert.Equal(command.Promotion.Priority, promotion.Priority);
        Assert.Equal(command.Promotion.PaymentCompatibility, promotion.PaymentCompatibility);
        Assert.Equal(command.Promotion.IsActive, promotion.IsActive > 0);
        Assert.Equal(command.Promotion.IsDeleted, promotion.IsDeleted > 0);
        Assert.Equal(command.Promotion.IsLinked, promotion.IsLinked > 0);
        Assert.Equal(command.Promotion.UniqueKey, promotion.UniqueKey);
        Assert.Equal(command.Promotion.IsOnCash, promotion.IsOnCash > 0);
        Assert.Equal(command.Promotion.IsTest, promotion.IsTest > 0);
        Assert.Equal(command.Promotion.TrCode, promotion.TrCode);
        Assert.Equal(command.Promotion.SpeCode, promotion.SpeCode);
        Assert.Equal(command.Promotion.LastUserId, promotion.LastUserId);
        Assert.Equal(command.Promotion.SortType, promotion.SortType);
        Assert.Equal(command.Promotion.NextPromotion, promotion.NextPromotion);
        Assert.Equal(command.Promotion.PromotionGroup, promotion.PromotionGroup);
        Assert.Equal(command.Promotion.RemindTypeId, promotion.RemindTypeId);
        Assert.Equal(command.Promotion.SeparateBySeller, promotion.SeparateBySeller > 0);
    }

    [Theory, ClassData(typeof(PromotionData))]
    public async Task Create_ShouldFailed_ReturnValidationError(Promotion promotion)
    {
        //Arrange
        var command = new CreatePromotionCommand(promotion);

        //Act
        var result = await Sender.Send(command);

        //Assert
        Assert.True(result.IsFailure);
        Assert.Equal("ValidationError", result.Error.Code);
    }

    [Fact]
    public async Task Update_ShouldUpdate_UpdatedPromotionInDatabase()
    {
        //Arrange
        var command = new CreatePromotionCommand(new Promotion()
        {
            SortType = "Price",
            Priority = 100,
            Name = "test promo edit name",
            Description = "test promo edit description",
            PromotionGroup = "100",
            IsRepeated = false,
            PaymentCompatibility = 0,
            RemindTypeId = "Propose edit",
            OrderNumber = "Order edit",
            IsActive = true,
            IsDeleted = false,
            IsLinked = false,
            IsOnCash = false,
            IsTest = false,
            TrCode = "TrCode edit",
            SpeCode = "SpeCode edit",
            LastUserId = 0,
            NextPromotion = 1,
            SeparateBySeller = true 
        });
        var createdPromotion = await Sender.Send(command);

        //Act
        command = new CreatePromotionCommand(new Promotion()
        {
            SortType = "PriceUpdated",
            Priority = 101,
            Name = "test promo edit name updated",
            Description = "test promo edit description updated",
            PromotionGroup = "101",
            IsRepeated = true,
            PaymentCompatibility = 1,
            RemindTypeId = "Propose edit updated",
            OrderNumber = "Order edit updated",
            IsActive = false,
            IsDeleted = true,
            IsLinked = true,
            IsOnCash = true,
            IsTest = true,
            TrCode = "TrCode edit updated",
            SpeCode = "SpeCode edit updated",
            LastUserId = 1,
            NextPromotion = 2,
            SeparateBySeller = false 
        });
        var result = await Sender.Send(command);

        //Assert
        Assert.True(result.IsSuccess);

        var promotion = DbContext.Promotions
            .FirstOrDefault(x => x.PromotionId == result.Value.PromotionId);

        Assert.NotNull(createdPromotion.Value);
        Assert.NotNull(result.Value);
        Assert.NotNull(promotion);
        Assert.Equal(command.Promotion.Description, promotion.Description);
        Assert.Equal(command.Promotion.Name, promotion.Name);
        Assert.Equal(command.Promotion.OrderNumber, promotion.OrderNumber);
        Assert.Equal(command.Promotion.Priority, promotion.Priority);
        Assert.Equal(command.Promotion.PaymentCompatibility, promotion.PaymentCompatibility);
        Assert.Equal(command.Promotion.IsActive, promotion.IsActive > 0);
        Assert.Equal(command.Promotion.IsDeleted, promotion.IsDeleted > 0);
        Assert.Equal(command.Promotion.IsLinked, promotion.IsLinked > 0);
        Assert.Equal(command.Promotion.UniqueKey, promotion.UniqueKey);
        Assert.Equal(command.Promotion.IsOnCash, promotion.IsOnCash > 0);
        Assert.Equal(command.Promotion.IsTest, promotion.IsTest > 0);
        Assert.Equal(command.Promotion.TrCode, promotion.TrCode);
        Assert.Equal(command.Promotion.SpeCode, promotion.SpeCode);
        Assert.Equal(command.Promotion.LastUserId, promotion.LastUserId);
        Assert.Equal(command.Promotion.SortType, promotion.SortType);
        Assert.Equal(command.Promotion.NextPromotion, promotion.NextPromotion);
        Assert.Equal(command.Promotion.PromotionGroup, promotion.PromotionGroup);
        Assert.Equal(command.Promotion.RemindTypeId, promotion.RemindTypeId);
        Assert.Equal(command.Promotion.SeparateBySeller, promotion.SeparateBySeller > 0);
    }

    [Fact]
    public async Task GetByStatus_ShouldReturn_ExistedPromotions()
    {
        //Arrange
        var command = new CreatePromotionCommand(new Promotion()
        {
            SortType = "Price",
            Priority = 100,
            Name = "test promo 1",
            Description = "test promo 1",
            PromotionGroup = "100",
            IsRepeated = false,
            PaymentCompatibility = 0,
            RemindTypeId = "Propose",
            OrderNumber = "Order 1",
            IsActive = true
        });

        var promotion = await Sender.Send(command);

        var createExecutionCommand = new CreatePromotionExecutionCommand(new PromotionExecution()
        {
            ShopCode = "0",
            BeginDate = DateTime.Now.AddDays(-1),
            BeginTime = DateTime.Now,
            EndDate = DateTime.Now.AddDays(1),
            EndTime = DateTime.Now,
            IsActive = true,
            PromotionId = promotion.Value.PromotionId
        });

        var promotionExecutions = await Sender.Send(createExecutionCommand);

        //Act
        var query = new GetPromotionByStatusQuery(PromotionsTypes.WorkingNowPromotions);

        var promotionsResult = await Sender.Send(query);


        //Assert
        var promotions = promotionsResult.Value;

        Assert.True(promotionsResult.IsSuccess);
        Assert.True(promotionsResult.Value.Count > 0);
        Assert.NotNull(promotions.FirstOrDefault(x => x.PromotionId == promotion.Value.PromotionId));
    }

    [Fact]
    public async Task Duplicate_ShouldFail_ReturnIdNotExistError()
    {
        //Act
        var duplicateCommand =
            new DuplicatePromotionCommand(PromotionDuplicateProperty.DuplicateWithExistedDetails, 123456);
        var duplicatedPromotion = await Sender.Send(duplicateCommand);

        //Assert
        Assert.True(duplicatedPromotion.IsFailure);
        Assert.Equal(PromotionErrors.IdNotExists.Code, duplicatedPromotion.Error.Code);
    }

    [Fact]
    public async Task Duplicate_ShouldReturn_InsertDuplicatedEntriesInDatabase()
    {
        //Arrange
        var createPromotionCommand = new CreatePromotionCommand(new Promotion()
        {
            SortType = "Price",
            Priority = 100,
            Name = "test promo 1",
            Description = "test promo 1",
            PromotionGroup = "100",
            IsRepeated = false,
            PaymentCompatibility = 0,
            RemindTypeId = "Propose",
            OrderNumber = "Order 1",
            IsActive = true
        });
        var createdPromotion = await Sender.Send(createPromotionCommand);

        var createConditionCommand = new CreatePromoConditionCommand(new PromotionCondition()
        {
            ActionId = 0,
            PromotionId = createdPromotion.Value.PromotionId,
            EventGroupId = "test_event_1",
            TypeChargeId = "TypeChargeId",
            TypeCheckId = "TypeCheckId",
            TypeTchargeId = "TypeTchargeId",
            TypeChargeOffId = "TypeChargeOffId",
            IsActive = true
        });
        var createdCondition = await Sender.Send(createConditionCommand);

        var createEventGroupDetailCommand = new CreateEventGroupDetailsCommand(new EventGroupDetail()
        {
            EventGroupId = createdCondition.Value.EventGroupId,
            CatalogParamTypeId = "CatalogParamType",
            CatalogTypeId = "CatalogTypeId",
            FilterTypeId = "FilterTypeId",
            Value = "Value",
            IsActive = true
        });
        var createdEventGroupDetail = await Sender.Send(createEventGroupDetailCommand);

        //Act
        var duplicateCommand =
            new DuplicatePromotionCommand(
                PromotionDuplicateProperty.DuplicateWithExistedDetails, 
                createdPromotion.Value.PromotionId);
        var duplicatedPromotion = await Sender.Send(duplicateCommand);

        //Assert
        var promotion = await DbContext.Promotions
            .FirstOrDefaultAsync(x => x.PromotionId == duplicatedPromotion.Value.PromotionId);

        var conditions = await DbContext.PromotionConditions
            .Where(x => x.PromotionId == duplicatedPromotion.Value.PromotionId)
            .ToListAsync();

        var eventGroupId = conditions.FirstOrDefault()?.EventGroupId;

        var eventDetails = await DbContext.EventGroupDetails
            .Where(x => x.EventGroupId == eventGroupId)
            .ToListAsync();

        Assert.True(duplicatedPromotion.IsSuccess);
        Assert.NotNull(duplicatedPromotion.Value);
        Assert.Equal(1, conditions.Count);
        Assert.Equal(1, eventDetails.Count);
        Assert.Equal(createdCondition.Value.EventGroupId, conditions[0].EventGroupId);
    }
}

public class PromotionData : IEnumerable<object[]>
{
    private readonly List<object[]> _data = new List<object[]>
    {
        new object[] { GetPromotionWithEmptyName() },
        new object[] { GetPromotionWithNameMoreThen100Symbols() },
        new object[] { GetPromotionWithEmptyPromotionGroup() },
        new object[] { GetPromotionWithPromoGroupMoreThen50Symbols() },
    };
 
    public IEnumerator<object[]> GetEnumerator()
    { return _data.GetEnumerator(); }
 
    IEnumerator IEnumerable.GetEnumerator()
    { return GetEnumerator(); }


    private static readonly string EmptyName = "";
    private static readonly string NameMoreThen100Symbols = "01234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890";

    private static readonly string EmptyPromoGroup = "";
    private static readonly string PromoGroupMoreThen50Symbols = "012345678901234567890123456789012345678901234567890";

    private static readonly Promotion Promotion = new Promotion()
    {
        SortType = "Price",
        Priority = 100,
        Name = "Test1",
        Description = "test promo 1",
        PromotionGroup = "100",
        IsRepeated = false,
        PaymentCompatibility = 0,
        RemindTypeId = "Propose",
        OrderNumber = "Приказ № 1",
        IsActive = true
    };

    public static Promotion GetPromotionWithEmptyName()
    {
        var result = Promotion.Adapt<Promotion>();
        result.Name = EmptyName;
        return result;
    }

    public static Promotion GetPromotionWithNameMoreThen100Symbols()
    {
        var result = Promotion.Adapt<Promotion>();
        result.Name = NameMoreThen100Symbols;
        return result;
    }

    public static Promotion GetPromotionWithEmptyPromotionGroup()
    {
        var result = Promotion.Adapt<Promotion>();
        result.PromotionGroup = EmptyPromoGroup;
        return result;
    }

    public static Promotion GetPromotionWithPromoGroupMoreThen50Symbols()
    {
        var result = Promotion.Adapt<Promotion>();
        result.PromotionGroup = PromoGroupMoreThen50Symbols;
        return result;
    }
}
