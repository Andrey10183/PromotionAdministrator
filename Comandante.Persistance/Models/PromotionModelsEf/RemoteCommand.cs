using System;
using System.Collections.Generic;

namespace Comandante.App;

public partial class RemoteCommand
{
    public int Id { get; set; }

    public string? CommandName { get; set; }

    public string? CommandText { get; set; }

    public DateTime? ChangeDateTime { get; set; }
}
