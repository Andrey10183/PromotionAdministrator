using Comandante.Persistance.Models.PromotionModelsEf;

namespace Comandante.App;

public partial class PromotionCalendar
{
    public int Id { get; set; }

    public int PromotionId { get; set; }

    public DateTime DateStart { get; set; }

    public DateTime DateEnd { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<CalendarTimeOfDay> CalendarTimeOfDays { get; set; } = new List<CalendarTimeOfDay>();

    public virtual PromotionEf Promotion { get; set; } = null!;
}
