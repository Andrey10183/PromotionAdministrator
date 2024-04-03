using System;
using System.Collections.Generic;

namespace Comandante.App;

public partial class PromotionReportApplPromo
{
    public long Id { get; set; }

    public int? ReportDetailId { get; set; }

    public byte? PromotionMechanismType { get; set; }

    public string? PromotionDescription { get; set; }

    public string? PromotionValue { get; set; }

    public Guid? Ident { get; set; }
}
