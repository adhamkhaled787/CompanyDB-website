using System;
using System.Collections.Generic;

namespace CMP.Models;

public partial class Purchaseorderdetail
{
    public int OrderdetailsId { get; set; }

    public int? OrderId { get; set; }

    public int? ProductId { get; set; }

    public virtual Purchaseorder? Order { get; set; }

    public virtual Product? Product { get; set; }
}
