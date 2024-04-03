using System;
using System.Collections.Generic;

namespace Comandante.App;

public partial class TerminalUpdate
{
    public int Id { get; set; }

    public string? DivisionCode { get; set; }

    public string? TermIp { get; set; }

    public string? FileName { get; set; }

    public Guid? UpdateGuid { get; set; }

    public DateTime? UpdateDateTime { get; set; }
}
