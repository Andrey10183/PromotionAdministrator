using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Comandante.App.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "CalendarDayOfWeek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Calendar__3214EC0736B12243", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DBClone",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShopCode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ReportDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CurrentNumber = table.Column<int>(type: "int", nullable: true),
                    DbIdent = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "EventGroupDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventGroupId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CatalogTypeId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CatalogParamTypeId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Value = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: true),
                    FilterTypeId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangeDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    UniqueKey = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<byte>(type: "tinyint", nullable: true),
                    IsDeleted = table.Column<byte>(type: "tinyint", nullable: true),
                    LastUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventGroupDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventGroups",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangeDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    UniqueKey = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<byte>(type: "tinyint", nullable: true),
                    IsDeleted = table.Column<byte>(type: "tinyint", nullable: true),
                    LastUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Objects",
                columns: table => new
                {
                    ObjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ObjectParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ObjectName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ObjectValue = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objects", x => x.ObjectId);
                });

            migrationBuilder.CreateTable(
                name: "Params",
                columns: table => new
                {
                    ParamKey = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ParamValue = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Params", x => x.ParamKey);
                });

            migrationBuilder.CreateTable(
                name: "PromotionActions",
                columns: table => new
                {
                    PromotionActionId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    _Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionActions", x => x.PromotionActionId);
                });

            migrationBuilder.CreateTable(
                name: "PromotionActiveList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    PromotionKey = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionActiveList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PromotionConditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PromotionId = table.Column<int>(type: "int", nullable: false),
                    EventGroupId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ConditionLineNumber = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    TypeChargeId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ChargeParam = table.Column<decimal>(type: "numeric(20,4)", nullable: false),
                    IsAccumulation = table.Column<byte>(type: "tinyint", nullable: false),
                    CascadeNumber = table.Column<int>(type: "int", nullable: false),
                    TypeCheckId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ChargeCParam = table.Column<decimal>(type: "numeric(20,4)", nullable: false),
                    TypeChargeOffId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ParamChargeOff = table.Column<decimal>(type: "numeric(20,4)", nullable: false),
                    TypeTChargeId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ChargeRParam = table.Column<decimal>(type: "numeric(20,4)", nullable: false),
                    ActionId = table.Column<int>(type: "int", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangeDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    UniqueKey = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<byte>(type: "tinyint", nullable: true),
                    IsDeleted = table.Column<byte>(type: "tinyint", nullable: true),
                    LastUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionConditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PromotionGroups",
                columns: table => new
                {
                    Code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangeDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    UniqueKey = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<byte>(type: "tinyint", nullable: true),
                    IsDeleted = table.Column<byte>(type: "tinyint", nullable: true),
                    LastUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionGroups", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "PromotionGroupsCompatibilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PromotionGroupX = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    PromotionGroupY = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CompatibilityType = table.Column<int>(type: "int", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangeDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    UniqueKey = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<byte>(type: "tinyint", nullable: true),
                    IsDeleted = table.Column<byte>(type: "tinyint", nullable: true),
                    LastUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionGroupsCompatibilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PromotionReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReportDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ident = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionReport", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PromotionReportApplPromos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportDetailId = table.Column<int>(type: "int", nullable: true),
                    PromotionMechanismType = table.Column<byte>(type: "tinyint", nullable: true),
                    PromotionDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    PromotionValue = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Ident = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionReportApplPromos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PromotionReportDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PromotionReportId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NewPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BonusAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NewBonusAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Ident = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GoodId = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ParentGoodId = table.Column<int>(type: "int", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionReportDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PromotionReportTransaction",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportDetailId = table.Column<int>(type: "int", nullable: true),
                    Value = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    PromotionTransactionType = table.Column<int>(type: "int", nullable: true),
                    PromotionTransactionName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    BasketNumber = table.Column<int>(type: "int", nullable: true),
                    CascadeNumber = table.Column<int>(type: "int", nullable: true),
                    CParam = table.Column<double>(type: "float", nullable: true),
                    Param = table.Column<double>(type: "float", nullable: true),
                    EventId = table.Column<int>(type: "int", nullable: true),
                    EventParentId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    PromotionId = table.Column<int>(type: "int", nullable: true),
                    PromotionName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    ConditionId = table.Column<int>(type: "int", nullable: true),
                    CalcType = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    PromotionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SortType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    IsLinked = table.Column<byte>(type: "tinyint", nullable: true),
                    PromotionGroup = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    IsRepeated = table.Column<byte>(type: "tinyint", nullable: true),
                    RemindTypeId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    IsOnCash = table.Column<byte>(type: "tinyint", nullable: true),
                    OrderNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    NextPromotion = table.Column<int>(type: "int", nullable: true),
                    IsTest = table.Column<byte>(type: "tinyint", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangeDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    UniqueKey = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<byte>(type: "tinyint", nullable: true),
                    IsDeleted = table.Column<byte>(type: "tinyint", nullable: true),
                    LastUserId = table.Column<int>(type: "int", nullable: true),
                    TrCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SpeCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SeparateBySeller = table.Column<byte>(type: "tinyint", nullable: true),
                    PaymentCompatibility = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions2", x => x.PromotionId);
                });

            migrationBuilder.CreateTable(
                name: "PromotionTimer2",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ServerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionTimer2", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RemoteCommands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommandName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CommandText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChangeDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemoteCommands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TerminalUpdates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DivisionCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TermIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdateGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerminalUpdates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "YandexMapPolygons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    GeoJSON = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__YandexMa__3214EC07509E2FD7", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "YandexMapPolygons_History",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Text = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    ActionDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__YandexMa__3214EC070679C465", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PromotionCalendar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PromotionId = table.Column<int>(type: "int", nullable: false),
                    DateStart = table.Column<DateTime>(type: "date", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "date", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Calendar__3214EC071DE57479", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalendarDayOfWeek_Promotions",
                        column: x => x.PromotionId,
                        principalTable: "Promotions",
                        principalColumn: "PromotionId");
                });

            migrationBuilder.CreateTable(
                name: "PromotionExecutions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PromotionId = table.Column<int>(type: "int", nullable: false),
                    SalesChannelId = table.Column<int>(type: "int", nullable: false),
                    ShopCode = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: false),
                    BeginDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    BeginTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangeDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    UniqueKey = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<byte>(type: "tinyint", nullable: true),
                    IsDeleted = table.Column<byte>(type: "tinyint", nullable: true),
                    LastUserId = table.Column<int>(type: "int", nullable: true),
                    dwMonday = table.Column<bool>(type: "bit", nullable: false),
                    dwTuesday = table.Column<bool>(type: "bit", nullable: false),
                    dwWednesday = table.Column<bool>(type: "bit", nullable: false),
                    dwThursday = table.Column<bool>(type: "bit", nullable: false),
                    dwFriday = table.Column<bool>(type: "bit", nullable: false),
                    dwSaturday = table.Column<bool>(type: "bit", nullable: false),
                    dwSunday = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Promotio__3214EC075070F446", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PromotionExecutions_Promotions",
                        column: x => x.PromotionId,
                        principalTable: "Promotions",
                        principalColumn: "PromotionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CalendarTimeOfDay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStart = table.Column<TimeSpan>(type: "time", nullable: false),
                    TimeEnd = table.Column<TimeSpan>(type: "time", nullable: false),
                    DayOfWeekId = table.Column<int>(type: "int", nullable: false),
                    PromotionCalendarId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarTimeOfDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalendarTimeOfDay_CalendarDayOfWeek",
                        column: x => x.DayOfWeekId,
                        principalTable: "CalendarDayOfWeek",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CalendarTimeOfDay_PromotionCalendar",
                        column: x => x.PromotionCalendarId,
                        principalTable: "PromotionCalendar",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalendarTimeOfDay",
                table: "CalendarTimeOfDay",
                column: "DayOfWeekId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CalendarTimeOfDay_PromotionCalendarId",
                table: "CalendarTimeOfDay",
                column: "PromotionCalendarId");

            migrationBuilder.CreateIndex(
                name: "EveGproup",
                table: "EventGroupDetails",
                columns: new[] { "CatalogTypeId", "CatalogParamTypeId", "Value" })
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "EventGroupDetails_cat_indx",
                table: "EventGroupDetails",
                columns: new[] { "CatalogTypeId", "CatalogParamTypeId" })
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "EventGroupDetails_CatParamId",
                table: "EventGroupDetails",
                columns: new[] { "EventGroupId", "CatalogTypeId", "CatalogParamTypeId" });

            migrationBuilder.CreateIndex(
                name: "EventGroupDetails_Id_indx",
                table: "EventGroupDetails",
                column: "Id")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "EventGroupDetails_indx",
                table: "EventGroupDetails",
                column: "EventGroupId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "EventGroupDetails_indx1",
                table: "EventGroupDetails",
                columns: new[] { "EventGroupId", "CatalogTypeId", "CatalogParamTypeId" })
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "NonClusteredIndex-20200719-153341",
                table: "EventGroupDetails",
                column: "EventGroupId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_CalendarDayOfWeek",
                table: "PromotionCalendar",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "PromotionConditions_EventGroupId_indx",
                table: "PromotionConditions",
                column: "EventGroupId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "PromotionConditions_PromoId_Prior_indx",
                table: "PromotionConditions",
                columns: new[] { "PromotionId", "Priority" })
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "PromotionExecutions_PromotionId_indx",
                table: "PromotionExecutions",
                column: "PromotionId")
                .Annotation("SqlServer:FillFactor", 90);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "CalendarTimeOfDay");

            migrationBuilder.DropTable(
                name: "DBClone");

            migrationBuilder.DropTable(
                name: "EventGroupDetails");

            migrationBuilder.DropTable(
                name: "EventGroups");

            migrationBuilder.DropTable(
                name: "Objects");

            migrationBuilder.DropTable(
                name: "Params");

            migrationBuilder.DropTable(
                name: "PromotionActions");

            migrationBuilder.DropTable(
                name: "PromotionActiveList");

            migrationBuilder.DropTable(
                name: "PromotionConditions");

            migrationBuilder.DropTable(
                name: "PromotionExecutions");

            migrationBuilder.DropTable(
                name: "PromotionGroups");

            migrationBuilder.DropTable(
                name: "PromotionGroupsCompatibilities");

            migrationBuilder.DropTable(
                name: "PromotionReport");

            migrationBuilder.DropTable(
                name: "PromotionReportApplPromos");

            migrationBuilder.DropTable(
                name: "PromotionReportDetails");

            migrationBuilder.DropTable(
                name: "PromotionReportTransaction");

            migrationBuilder.DropTable(
                name: "PromotionTimer2");

            migrationBuilder.DropTable(
                name: "RemoteCommands");

            migrationBuilder.DropTable(
                name: "TerminalUpdates");

            migrationBuilder.DropTable(
                name: "YandexMapPolygons");

            migrationBuilder.DropTable(
                name: "YandexMapPolygons_History");

            migrationBuilder.DropTable(
                name: "CalendarDayOfWeek");

            migrationBuilder.DropTable(
                name: "PromotionCalendar");

            migrationBuilder.DropTable(
                name: "Promotions");
        }
    }
}
