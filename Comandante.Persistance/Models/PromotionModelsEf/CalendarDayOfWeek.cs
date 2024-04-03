using System;
using System.Collections.Generic;

namespace Comandante.App;

public partial class CalendarDayOfWeek
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual CalendarTimeOfDay? CalendarTimeOfDay { get; set; }
}
