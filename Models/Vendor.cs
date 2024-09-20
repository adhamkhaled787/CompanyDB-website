using System;
using System.Collections.Generic;

namespace CMP.Models;

public partial class Vendor
{
    public int VendorId { get; set; }

    public string Location { get; set; } = null!;

    public virtual ICollection<Purchaseorder> Purchaseorders { get; set; } = new List<Purchaseorder>();
}
