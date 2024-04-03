using DotNet.Testcontainers.Containers;

namespace Application.IntegrationTests;

public class MigrationHelper
{
    public static async Task CreateMigration(IDatabaseContainer databaseContainer, string database)
    {
        var _dbConnectionFactory = new DbConnectionFactory(databaseContainer, database);

        await using var connection = _dbConnectionFactory.MasterDbConnection;

        await using var command = connection.CreateCommand();

        await connection.OpenAsync()
            .ConfigureAwait(false);
        
        command.CommandText = @"
            CREATE TABLE master.dbo.Promotions (
	            PromotionId int IDENTITY,
	            SortType varchar(50) COLLATE Cyrillic_General_CI_AS NULL,
	            Priority int NULL,
	            Name varchar(100) COLLATE Cyrillic_General_CI_AS NULL,
	            Description varchar(250) COLLATE Cyrillic_General_CI_AS NULL,
	            IsLinked tinyint NULL,
	            PromotionGroup varchar(50) COLLATE Cyrillic_General_CI_AS NULL,
	            IsRepeated tinyint NULL,
	            RemindTypeId varchar(50) COLLATE Cyrillic_General_CI_AS NULL,
	            IsOnCash tinyint NULL,
	            OrderNumber varchar(50) COLLATE Cyrillic_General_CI_AS NULL,
	            NextPromotion int NULL,
	            IsTest tinyint NULL,
	            CreateDateTime datetime NULL,
	            ChangeDateTime datetime NULL,
	            UniqueKey uniqueidentifier NULL,
	            IsActive tinyint NULL,
	            IsDeleted tinyint NULL,
	            LastUserId int NULL,
	            TrCode nvarchar(50) COLLATE Cyrillic_General_CI_AS NULL,
	            SpeCode nvarchar(50) COLLATE Cyrillic_General_CI_AS NULL,
	            SeparateBySeller tinyint NULL,
	            PaymentCompatibility int DEFAULT 0 NOT NULL,
	            CONSTRAINT PK_Promotions2 PRIMARY KEY (PromotionId)
            );";

        await command.ExecuteNonQueryAsync()
            .ConfigureAwait(false);

        command.CommandText = @"
            CREATE TABLE master.dbo.PromotionExecutions (
	            Id int IDENTITY(1,1) NOT NULL,
	            PromotionId int NOT NULL,
	            SalesChannelId int NOT NULL,
	            ShopCode varchar(3000) COLLATE Cyrillic_General_CI_AS NOT NULL,
	            BeginDate datetime NOT NULL,
	            EndDate datetime NOT NULL,
	            BeginTime datetime NOT NULL,
	            EndTime datetime NOT NULL,
	            CreateDateTime datetime NULL,
	            ChangeDateTime datetime NULL,
	            UniqueKey uniqueidentifier NULL,
	            IsActive tinyint NULL,
	            IsDeleted tinyint NULL,
	            LastUserId int NULL,
	            dwMonday bit NOT NULL,
	            dwTuesday bit NOT NULL,
	            dwWednesday bit NOT NULL,
	            dwThursday bit NOT NULL,
	            dwFriday bit NOT NULL,
	            dwSaturday bit NOT NULL,
	            dwSunday bit NOT NULL,
	            CONSTRAINT PK__Promotio__3214EC075070F446 PRIMARY KEY (Id)
            );
             CREATE NONCLUSTERED INDEX PromotionExecutions_PromotionId_indx ON dbo.PromotionExecutions (  PromotionId ASC  )  
	             WITH (  PAD_INDEX = OFF ,FILLFACTOR = 90   ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	             ON [PRIMARY ] ;


            -- Promotion.dbo.PromotionExecutions foreign keys

            ALTER TABLE master.dbo.PromotionExecutions ADD CONSTRAINT FK_PromotionExecutions_Promotions FOREIGN KEY (PromotionId) REFERENCES master.dbo.Promotions(PromotionId);";

        await command.ExecuteNonQueryAsync()
            .ConfigureAwait(false);

        command.CommandText = @"
            CREATE TABLE master.dbo.PromotionConditions (
	            Id int IDENTITY(2,1) NOT NULL,
	            PromotionId int NOT NULL,
	            EventGroupId varchar(50) COLLATE Cyrillic_General_CI_AS NOT NULL,
	            ConditionLineNumber int NOT NULL,
	            Priority int NOT NULL,
	            TypeChargeId varchar(50) COLLATE Cyrillic_General_CI_AS NOT NULL,
	            ChargeParam numeric(20,4) NOT NULL,
	            IsAccumulation tinyint NOT NULL,
	            CascadeNumber int NOT NULL,
	            TypeCheckId varchar(50) COLLATE Cyrillic_General_CI_AS NOT NULL,
	            ChargeCParam numeric(20,4) NOT NULL,
	            TypeChargeOffId varchar(50) COLLATE Cyrillic_General_CI_AS NOT NULL,
	            ParamChargeOff numeric(20,4) NOT NULL,
	            TypeTChargeId varchar(50) COLLATE Cyrillic_General_CI_AS NOT NULL,
	            ChargeRParam numeric(20,4) NOT NULL,
	            ActionId int NOT NULL,
	            CreateDateTime datetime NULL,
	            ChangeDateTime datetime NULL,
	            UniqueKey uniqueidentifier NULL,
	            IsActive tinyint NULL,
	            IsDeleted tinyint NULL,
	            LastUserId int NULL,
	            CONSTRAINT PK_PromotionConditions PRIMARY KEY (Id)
            );
             CREATE NONCLUSTERED INDEX PromotionConditions_EventGroupId_indx ON dbo.PromotionConditions (  EventGroupId ASC  )  
	             INCLUDE ( PromotionId ) 
	             WITH (  PAD_INDEX = OFF ,FILLFACTOR = 90   ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	             ON [PRIMARY ] ;
             CREATE NONCLUSTERED INDEX PromotionConditions_PromoId_Prior_indx ON dbo.PromotionConditions (  PromotionId ASC  , Priority ASC  )  
	             INCLUDE ( ChargeRParam , EventGroupId ) 
	             WITH (  PAD_INDEX = OFF ,FILLFACTOR = 90   ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	             ON [PRIMARY ] ;";

        await command.ExecuteNonQueryAsync()
            .ConfigureAwait(false);

        command.CommandText = @"
            CREATE TABLE master.dbo.EventGroupDetails (
	            Id int IDENTITY(1,1) NOT NULL,
	            EventGroupId varchar(50) COLLATE Cyrillic_General_CI_AS NOT NULL,
	            CatalogTypeId varchar(50) COLLATE Cyrillic_General_CI_AS NOT NULL,
	            CatalogParamTypeId varchar(50) COLLATE Cyrillic_General_CI_AS NOT NULL,
	            Value varchar(250) COLLATE Cyrillic_General_CI_AS NULL,
	            Priority int NULL,
	            FilterTypeId varchar(50) COLLATE Cyrillic_General_CI_AS NULL,
	            Description varchar(500) COLLATE Cyrillic_General_CI_AS NULL,
	            CreateDateTime datetime NULL,
	            ChangeDateTime datetime NULL,
	            UniqueKey uniqueidentifier NULL,
	            IsActive tinyint NULL,
	            IsDeleted tinyint NULL,
	            LastUserId int NULL,
	            CONSTRAINT PK_EventGroupDetails PRIMARY KEY (Id)
            );";

        await command.ExecuteNonQueryAsync()
            .ConfigureAwait(false);

        await connection.CloseAsync();
    }
}