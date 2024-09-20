using System;
using System.Collections.Generic;

namespace CMP.Models;

public partial class CustomerOrder
{
    public int OrderId { get; set; }

    public int? CustomerId { get; set; }

    public DateOnly? PurchaseDate { get; set; }

    public int Totalamount { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<Orderdetail> Orderdetails { get; set; } = new List<Orderdetail>();
}
