using System;
using System.Collections.Generic;

namespace Comandante.App;

public partial class PromotionReportDetail
{
    public int Id { get; set; }

    public int? PromotionReportId { get; set; }

    public decimal? Price { get; set; }

    public decimal? NewPrice { get; set; }

    public decimal? BonusAmount { get; set; }

    public decimal? NewBonusAmount { get; set; }

    public Guid? Ident { get; set; }

    public int? GoodId { get; set; }

    public string? Code { get; set; }

    public int? ParentGoodId { get; set; }

    public int? OrderId { get; set; }
}
