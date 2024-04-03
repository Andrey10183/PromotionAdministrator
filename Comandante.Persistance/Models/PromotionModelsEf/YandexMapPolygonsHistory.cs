using System;
using System.Collections.Generic;

namespace Comandante.App;

public partial class YandexMapPolygonsHistory
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? Text { get; set; }

    public DateTime? ActionDateTime { get; set; }
}
