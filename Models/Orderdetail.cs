using System;
using System.Collections.Generic;

namespace CMP.Models;

public partial class Orderdetail
{
    public int OrderDetailId { get; set; }

    public int? OrderId { get; set; }

    public int? ProductId { get; set; }

    public virtual CustomerOrder? Order { get; set; }

    public virtual Product? Product { get; set; }
}
