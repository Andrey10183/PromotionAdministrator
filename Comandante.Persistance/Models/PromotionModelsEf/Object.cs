using System;
using System.Collections.Generic;

namespace Comandante.App;

public partial class Object
{
    public Guid ObjectId { get; set; }

    public Guid? ObjectParentId { get; set; }

    public string ObjectName { get; set; } = null!;

    public string ObjectValue { get; set; } = null!;
}
