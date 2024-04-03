using System;
using System.Collections.Generic;

namespace Comandante.App;

public partial class PromotionReportTransaction
{
    public long Id { get; set; }

    public int? ReportDetailId { get; set; }

    public string? Value { get; set; }

    public int? PromotionTransactionType { get; set; }

    public string? PromotionTransactionName { get; set; }

    public int? BasketNumber { get; set; }

    public int? CascadeNumber { get; set; }

    public double? Cparam { get; set; }

    public double? Param { get; set; }

    public int? EventId { get; set; }

    public int? EventParentId { get; set; }

    public string? Description { get; set; }

    public int? PromotionId { get; set; }

    public string? PromotionName { get; set; }

    public int? ConditionId { get; set; }

    public string? CalcType { get; set; }
}
