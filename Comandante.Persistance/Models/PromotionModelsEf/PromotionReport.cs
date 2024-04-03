using System;
using System.Collections.Generic;

namespace Comandante.App;

public partial class PromotionReport
{
    public int Id { get; set; }

    public string? Status { get; set; }

    public DateTime? ReportDate { get; set; }

    public Guid? Ident { get; set; }
}
