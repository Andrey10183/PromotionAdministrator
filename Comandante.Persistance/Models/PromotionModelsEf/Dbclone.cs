using System;
using System.Collections.Generic;

namespace Comandante.App;

public partial class Dbclone
{
    public Guid? Id { get; set; }

    public string? ShopCode { get; set; }

    public DateTime? ReportDate { get; set; }

    public int? CurrentNumber { get; set; }

    public string? DbIdent { get; set; }
}
