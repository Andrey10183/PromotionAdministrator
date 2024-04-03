using System;
using System.Collections.Generic;

namespace Comandante.App;

public partial class YandexMapPolygon
{
    public int Id { get; set; }

    public int? CityId { get; set; }

    public string? GeoJson { get; set; }
}
