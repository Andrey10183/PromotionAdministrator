using System.Security.AccessControl;

namespace Comandante.Domain.Entities;

public class CalcTypeModels
{
    public string Id { get; set; }

    public string Name { get; set; }
}

public class FilterType
{
    public string Id { get; set; }

    public string Name { get; set; }
}

public class CatalogParam
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string Priority { get; set; }
}

public class CatalogType
{
    public string Id { get; set; }

    public string Name { get; set; }
}

public class RemindType
{
    public string Id { get; set; }

    public string Name { get; set; }
}

public class EventsSortType
{
    public string Id { get; set; }

    public string Name { get; set; }
}

public class PaymentCompatibilityType
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class SaleChannel
{
    public int Id  { get; set; }
    public string Name { get; set; }
}

public class PromoGroupCompatibilityType
{
    public int Id { get; set; }
    public string Name { get; set; }
}
