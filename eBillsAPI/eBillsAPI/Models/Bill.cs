using System;
using System.Collections.Generic;

namespace eBill.Models;

public partial class Bill
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Amount { get; set; }

    public bool Paid { get; set; }

    public DateTime? DueDate { get; set; }

    public DateTime? CreatedDate { get; set; }

    //public int? BillId { get; set; }

    //public virtual Bill? BillNavigation { get; set; }

    //public virtual ICollection<Bill> InverseBillNavigation { get; } = new List<Bill>();
}
