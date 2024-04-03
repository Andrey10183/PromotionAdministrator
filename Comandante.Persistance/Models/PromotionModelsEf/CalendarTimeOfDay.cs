using System;
using System.Collections.Generic;

namespace Comandante.App;

public partial class CalendarTimeOfDay
{
    public int Id { get; set; }

    public TimeSpan TimeStart { get; set; }

    public TimeSpan TimeEnd { get; set; }

    public int DayOfWeekId { get; set; }

    public int? PromotionCalendarId { get; set; }

    public virtual CalendarDayOfWeek DayOfWeek { get; set; } = null!;

    public virtual PromotionCalendar? PromotionCalendar { get; set; }
}
