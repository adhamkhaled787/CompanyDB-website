using System;
using System.Collections.Generic;

namespace CMP.Models;

public partial class WarehouseController
{
    public int? ProductId { get; set; }

    public int? Whnumber { get; set; }

    public int? Quantity { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Warehouse? WhnumberNavigation { get; set; }
}
