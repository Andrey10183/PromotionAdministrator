using Comandante.Persistance.Models.PromotionModelsEf;
using Microsoft.EntityFrameworkCore;

namespace Comandante.App;

public partial class PromotionContext : DbContext
{
    public PromotionContext()
    {
    }

    public PromotionContext(DbContextOptions<PromotionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bank> Banks { get; set; }

    public virtual DbSet<CalendarDayOfWeek> CalendarDayOfWeeks { get; set; }

    public virtual DbSet<CalendarTimeOfDay> CalendarTimeOfDays { get; set; }

    public virtual DbSet<Dbclone> Dbclones { get; set; }

    public virtual DbSet<EventGroupEf> EventGroups { get; set; }

    public virtual DbSet<EventGroupDetailEf> EventGroupDetails { get; set; }

    public virtual DbSet<Object> Objects { get; set; }

    public virtual DbSet<Param> Params { get; set; }

    public virtual DbSet<PromotionEf> Promotions { get; set; }

    public virtual DbSet<PromotionActionEf> PromotionActions { get; set; }

    public virtual DbSet<PromotionActiveList> PromotionActiveLists { get; set; }

    public virtual DbSet<PromotionCalendar> PromotionCalendars { get; set; }

    public virtual DbSet<PromotionConditionEf> PromotionConditions { get; set; }

    public virtual DbSet<PromotionExecutionEf> PromotionExecutions { get; set; }

    public virtual DbSet<PromotionGroupEf> PromotionGroups { get; set; }

    public virtual DbSet<PromotionGroupsCompatibilityEf> PromotionGroupsCompatibilities { get; set; }

    public virtual DbSet<PromotionReport> PromotionReports { get; set; }

    public virtual DbSet<PromotionReportApplPromo> PromotionReportApplPromos { get; set; }

    public virtual DbSet<PromotionReportDetail> PromotionReportDetails { get; set; }

    public virtual DbSet<PromotionReportTransaction> PromotionReportTransactions { get; set; }

    public virtual DbSet<PromotionTimer2> PromotionTimer2s { get; set; }

    public virtual DbSet<RemoteCommand> RemoteCommands { get; set; }

    public virtual DbSet<TerminalUpdate> TerminalUpdates { get; set; }

    public virtual DbSet<YandexMapPolygon> YandexMapPolygons { get; set; }

    public virtual DbSet<YandexMapPolygonsHistory> YandexMapPolygonsHistories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bank>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<CalendarDayOfWeek>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Calendar__3214EC0736B12243");

            entity.ToTable("CalendarDayOfWeek");

            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CalendarTimeOfDay>(entity =>
        {
            entity.ToTable("CalendarTimeOfDay");

            entity.HasIndex(e => e.DayOfWeekId, "IX_CalendarTimeOfDay").IsUnique();

            entity.HasOne(d => d.DayOfWeek).WithOne(p => p.CalendarTimeOfDay)
                .HasForeignKey<CalendarTimeOfDay>(d => d.DayOfWeekId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CalendarTimeOfDay_CalendarDayOfWeek");

            entity.HasOne(d => d.PromotionCalendar).WithMany(p => p.CalendarTimeOfDays)
                .HasForeignKey(d => d.PromotionCalendarId)
                .HasConstraintName("FK_CalendarTimeOfDay_PromotionCalendar");
        });

        modelBuilder.Entity<Dbclone>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DBClone");

            entity.Property(e => e.DbIdent)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ReportDate).HasColumnType("datetime");
            entity.Property(e => e.ShopCode)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EventGroupEf>(entity =>
        {
            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ChangeDateTime).HasColumnType("datetime");
            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EventGroupDetailEf>(entity =>
        {
            entity.HasIndex(e => new { e.CatalogTypeId, e.CatalogParamTypeId, e.Value }, "EveGproup").HasFillFactor(90);

            entity.HasIndex(e => new { e.EventGroupId, e.CatalogTypeId, e.CatalogParamTypeId }, "EventGroupDetails_CatParamId");

            entity.HasIndex(e => e.Id, "EventGroupDetails_Id_indx").HasFillFactor(90);

            entity.HasIndex(e => new { e.CatalogTypeId, e.CatalogParamTypeId }, "EventGroupDetails_cat_indx").HasFillFactor(90);

            entity.HasIndex(e => e.EventGroupId, "EventGroupDetails_indx").HasFillFactor(90);

            entity.HasIndex(e => new { e.EventGroupId, e.CatalogTypeId, e.CatalogParamTypeId }, "EventGroupDetails_indx1").HasFillFactor(90);

            entity.HasIndex(e => e.EventGroupId, "NonClusteredIndex-20200719-153341").HasFillFactor(90);

            entity.Property(e => e.CatalogParamTypeId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CatalogTypeId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ChangeDateTime).HasColumnType("datetime");
            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.EventGroupId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FilterTypeId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Value)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Object>(entity =>
        {
            entity.Property(e => e.ObjectId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ObjectName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ObjectValue)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Param>(entity =>
        {
            entity.HasKey(e => e.ParamKey);

            entity.Property(e => e.ParamKey)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ParamValue)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PromotionEf>(entity =>
        {
            entity.HasKey(e => e.PromotionId).HasName("PK_Promotions2");

            entity
                .HasMany(p => p.PromotionExecutions)
                .WithOne(pe => pe.Promotion)
                .HasForeignKey(pe => pe.PromotionId);
                //.OnDelete(DeleteBehavior.Cascade);

            entity.Property(e => e.ChangeDateTime).HasColumnType("datetime");
            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.OrderNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PromotionGroup)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RemindTypeId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SortType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SpeCode).HasMaxLength(50);
            entity.Property(e => e.TrCode).HasMaxLength(50);
        });

        modelBuilder.Entity<PromotionActionEf>(entity =>
        {
            entity.HasKey(e => e.PromotionActionId);

            entity.Property(e => e.PromotionActionId).ValueGeneratedNever();
            entity.Property(e => e.Description).HasColumnName("_Description");
            entity.Property(e => e.Name).HasMaxLength(500);
        });

        modelBuilder.Entity<PromotionActiveList>(entity =>
        {
            entity.ToTable("PromotionActiveList");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<PromotionCalendar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Calendar__3214EC071DE57479");

            entity.ToTable("PromotionCalendar");

            entity.HasIndex(e => e.PromotionId, "IX_CalendarDayOfWeek");

            entity.Property(e => e.DateEnd).HasColumnType("date");
            entity.Property(e => e.DateStart).HasColumnType("date");

            entity.HasOne(d => d.Promotion).WithMany(p => p.PromotionCalendars)
                .HasForeignKey(d => d.PromotionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CalendarDayOfWeek_Promotions");
        });

        modelBuilder.Entity<PromotionConditionEf>(entity =>
        {
            entity.HasIndex(e => e.EventGroupId, "PromotionConditions_EventGroupId_indx").HasFillFactor(90);

            entity.HasIndex(e => new { e.PromotionId, e.Priority }, "PromotionConditions_PromoId_Prior_indx").HasFillFactor(90);

            entity.Property(e => e.ChangeDateTime).HasColumnType("datetime");
            entity.Property(e => e.ChargeCparam)
                .HasColumnType("numeric(20, 4)")
                .HasColumnName("ChargeCParam");
            entity.Property(e => e.ChargeParam).HasColumnType("numeric(20, 4)");
            entity.Property(e => e.ChargeRparam)
                .HasColumnType("numeric(20, 4)")
                .HasColumnName("ChargeRParam");
            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
            entity.Property(e => e.EventGroupId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ParamChargeOff).HasColumnType("numeric(20, 4)");
            entity.Property(e => e.TypeChargeId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TypeChargeOffId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TypeCheckId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TypeTchargeId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TypeTChargeId");
        });

        modelBuilder.Entity<PromotionExecutionEf>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Promotio__3214EC075070F446");

            entity.HasIndex(e => e.PromotionId, "PromotionExecutions_PromotionId_indx").HasFillFactor(90);

            entity.Property(e => e.BeginDate).HasColumnType("datetime");
            entity.Property(e => e.BeginTime).HasColumnType("datetime");
            entity.Property(e => e.ChangeDateTime).HasColumnType("datetime");
            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
            entity.Property(e => e.DwFriday).HasColumnName("dwFriday");
            entity.Property(e => e.DwMonday).HasColumnName("dwMonday");
            entity.Property(e => e.DwSaturday).HasColumnName("dwSaturday");
            entity.Property(e => e.DwSunday).HasColumnName("dwSunday");
            entity.Property(e => e.DwThursday).HasColumnName("dwThursday");
            entity.Property(e => e.DwTuesday).HasColumnName("dwTuesday");
            entity.Property(e => e.DwWednesday).HasColumnName("dwWednesday");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.ShopCode)
                .HasMaxLength(3000)
                .IsUnicode(false);

            entity.HasOne(d => d.Promotion).WithMany(p => p.PromotionExecutions)
                .HasForeignKey(d => d.PromotionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_PromotionExecutions_Promotions");
        });

        modelBuilder.Entity<PromotionGroupEf>(entity =>
        {
            entity.HasKey(e => e.Code);

            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ChangeDateTime).HasColumnType("datetime");
            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PromotionGroupsCompatibilityEf>(entity =>
        {
            entity.Property(e => e.ChangeDateTime).HasColumnType("datetime");
            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
            entity.Property(e => e.PromotionGroupX)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PromotionGroupY)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PromotionReport>(entity =>
        {
            entity.ToTable("PromotionReport");

            entity.Property(e => e.ReportDate).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<PromotionReportApplPromo>(entity =>
        {
            entity.Property(e => e.PromotionDescription).HasMaxLength(150);
            entity.Property(e => e.PromotionValue).HasMaxLength(50);
        });

        modelBuilder.Entity<PromotionReportDetail>(entity =>
        {
            entity.Property(e => e.BonusAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NewBonusAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NewPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<PromotionReportTransaction>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PromotionReportTransaction");

            entity.Property(e => e.CalcType)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Cparam).HasColumnName("CParam");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.PromotionName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PromotionTransactionName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Value)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PromotionTimer2>(entity =>
        {
            entity.ToTable("PromotionTimer2");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ServerName).HasMaxLength(50);
            entity.Property(e => e.Time).HasMaxLength(50);
        });

        modelBuilder.Entity<RemoteCommand>(entity =>
        {
            entity.ToTable(tb =>
                {
                    tb.HasTrigger("RemoteCommandsAfterUpdate");
                    tb.HasTrigger("RemoteCommandsForInsert");
                });

            entity.Property(e => e.ChangeDateTime).HasColumnType("datetime");
            entity.Property(e => e.CommandName).HasMaxLength(50);
        });

        modelBuilder.Entity<TerminalUpdate>(entity =>
        {
            entity.Property(e => e.DivisionCode).HasMaxLength(50);
            entity.Property(e => e.FileName).HasMaxLength(50);
            entity.Property(e => e.TermIp)
                .HasMaxLength(50)
                .HasColumnName("TermIP");
            entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<YandexMapPolygon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__YandexMa__3214EC07509E2FD7");

            entity.Property(e => e.GeoJson)
                .IsUnicode(false)
                .HasColumnName("GeoJSON");
        });

        modelBuilder.Entity<YandexMapPolygonsHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__YandexMa__3214EC070679C465");

            entity.ToTable("YandexMapPolygons_History");

            entity.Property(e => e.ActionDateTime).HasColumnType("datetime");
            entity.Property(e => e.Text).IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
