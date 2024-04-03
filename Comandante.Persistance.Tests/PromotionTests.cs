using Comandante.App;
using Comandante.App.Configuration;
using Comandante.App.Pages;
using Comandante.Domain.Entities;
using Comandante.Domain.RepositoryInterfaces;
using Comandante.Persistance.Models.PromotionModelsEf;
using Comandante.Persistance.Repositories;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Moq;

namespace Comandante.Persistance.Tests;

public class PromotionTests
{
    private DbContextOptions<PromotionContext> _options;
    private IDbContextFactory<PromotionContext> _dbContextFactory;
    public PromotionTests()
    {
        AddMapsterConfig();
    }

    private void AddMapsterConfig()
    {
        var assembly = typeof(MappingProfile).Assembly;
        TypeAdapterConfig.GlobalSettings.Scan(assembly);
    }

    private IPromotionRepository CreateSut()
    {
        return new PromotionRepository(new TestDbContextFactory(Guid.NewGuid().ToString()));
    }

    [Fact]
    public async Task DeletePromotion_ShouldNotDelete_LinkedEventGroupDetails()
    {
        var sut = CreateSut();

        var result = await sut.Delete(1);
        //var result = await sut.GetById(1);

        Assert.True(result.IsSuccess);
        Assert.Equal(result.Value, 2);
    }
}

public class TestDbContextFactory : IDbContextFactory<PromotionContext>
{
    private DbContextOptions<PromotionContext> _options;

    public TestDbContextFactory(string databaseName = "InMemoryTest")
    {
        _options = new DbContextOptionsBuilder<PromotionContext>()
            .UseInMemoryDatabase(databaseName)
            .Options;
    }

    public PromotionContext CreateDbContext()
    {
        var dbContext = new PromotionContext(_options);

        dbContext.Promotions.AddRange(Promotions);
        dbContext.PromotionConditions.AddRange(PromotionConditions);
        dbContext.EventGroupDetails.AddRange(EventGroupDetails);

        dbContext.SaveChanges();
        return dbContext;
    }

    private static List<PromotionEf> Promotions => new()
    {
        new PromotionEf()
        {
            PromotionId = 1,
            SortType = "Price",
            Priority = 100,
            Name = "test promo 1",
            Description = "test promo 1",
            PromotionGroup = "100",
            IsRepeated = 0,
            PaymentCompatibility = 0,
            RemindTypeId = "Propose",
            OrderNumber = "Приказ № 1",
            IsActive = 1
        },
        new PromotionEf()
        {
            PromotionId = 2,
            SortType = "Price",
            Priority = 100,
            Name = "test promo 2",
            Description = "test promo 2",
            PromotionGroup = "100",
            IsRepeated = 0,
            PaymentCompatibility = 0,
            RemindTypeId = "Propose",
            OrderNumber = "Приказ № 1",
            IsActive = 1
        }
    };

    private static List<PromotionConditionEf> PromotionConditions => new()
    {
        new PromotionConditionEf()
        {
            Id = 1,
            PromotionId = 1,
            EventGroupId = "event_1",
            TypeChargeId = "C",
            TypeCheckId = "C",
            TypeChargeOffId = "C",
            TypeTchargeId = "N"

        },
        new PromotionConditionEf()
        {
            Id = 2,
            PromotionId = 1,
            EventGroupId = "event_2",
            TypeChargeId = "C",
            TypeCheckId = "C",
            TypeChargeOffId = "C",
            TypeTchargeId = "N"

        },
        new PromotionConditionEf()
        {
            Id = 3,
            PromotionId = 2,
            EventGroupId = "event_1",
            TypeChargeId = "C",
            TypeCheckId = "C",
            TypeChargeOffId = "C",
            TypeTchargeId = "N"
        },
        new PromotionConditionEf()
        {
            Id = 4,
            PromotionId = 2,
            EventGroupId = "event_3",
            TypeChargeId = "C",
            TypeCheckId = "C",
            TypeChargeOffId = "C",
            TypeTchargeId = "N"
        }
    };

    private static List<EventGroupDetailEf> EventGroupDetails => new()
    {
        new EventGroupDetailEf()
        {
            Id = 1,
            EventGroupId = "event_1",
            CatalogTypeId = "GOODS",
            CatalogParamTypeId = "ARTICLE",
            Value = "10",
            FilterTypeId = "I"
        },
        new EventGroupDetailEf()
        {
            Id = 2,
            EventGroupId = "event_1",
            CatalogTypeId = "GOODS",
            CatalogParamTypeId = "ARTICLE",
            Value = "10",
            FilterTypeId = "I"
        },
        new EventGroupDetailEf()
        {
            Id = 3,
            EventGroupId = "event_1",
            CatalogTypeId = "GOODS",
            CatalogParamTypeId = "ARTICLE",
            Value = "10",
            FilterTypeId = "I"
        },
        new EventGroupDetailEf()
        {
            Id = 4,
            EventGroupId = "event_2",
            CatalogTypeId = "GOODS",
            CatalogParamTypeId = "ARTICLE",
            Value = "10",
            FilterTypeId = "I"
        },
        new EventGroupDetailEf()
        {
            Id = 5,
            EventGroupId = "event_2",
            CatalogTypeId = "GOODS",
            CatalogParamTypeId = "ARTICLE",
            Value = "10",
            FilterTypeId = "I"
        },
        new EventGroupDetailEf()
        {
            Id = 6,
            EventGroupId = "event_2",
            CatalogTypeId = "GOODS",
            CatalogParamTypeId = "ARTICLE",
            Value = "10",
            FilterTypeId = "I"
        },
        new EventGroupDetailEf()
        {
            Id = 7,
            EventGroupId = "event_3",
            CatalogTypeId = "GOODS",
            CatalogParamTypeId = "ARTICLE",
            Value = "10",
            FilterTypeId = "I"
        },
        new EventGroupDetailEf()
        {
            Id = 8,
            EventGroupId = "event_3",
            CatalogTypeId = "GOODS",
            CatalogParamTypeId = "ARTICLE",
            Value = "10",
            FilterTypeId = "I"
        },
        new EventGroupDetailEf()
        {
            Id = 9,
            EventGroupId = "event_3",
            CatalogTypeId = "GOODS",
            CatalogParamTypeId = "ARTICLE",
            Value = "10",
            FilterTypeId = "I"
        },
    };
}
