using System;
using System.Collections.Generic;

namespace Comandante.App;

public partial class PromotionActiveList
{
    public Guid Id { get; set; }

    public bool? IsActive { get; set; }

    public Guid? PromotionKey { get; set; }
}
