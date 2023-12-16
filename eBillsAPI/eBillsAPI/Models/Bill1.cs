using System;
using System.Collections.Generic;

namespace eBill.Models;

public partial class Bill1
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Amount { get; set; }
    public bool Paid { get; set; }

    public DateTime? DueDate { get; set; }

    public DateTime? CreatedDate { get; set; }
}
