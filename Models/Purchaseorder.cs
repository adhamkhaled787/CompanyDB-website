using System;
using System.Collections.Generic;

namespace CMP.Models;

public partial class Purchaseorder
{
    public int OrderId { get; set; }

    public int? VendorId { get; set; }

    public DateOnly? PurchaseDate { get; set; }

    public int? Totalamount { get; set; }

    public virtual ICollection<Purchaseorderdetail> Purchaseorderdetails { get; set; } = new List<Purchaseorderdetail>();

    public virtual Vendor? Vendor { get; set; }
}
