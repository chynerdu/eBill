
using System.ComponentModel.DataAnnotations;


namespace eBill.Models;

public class Bill1
{
    public int Id { get; set; }

   [Required]
    public string? Name { get; set; }

    [Required]
    public decimal Amount { get; set; }
    public bool Paid { get; set; }
    public DateTime? DueDate { get; set; }
    public DateTime? CreatedDate { get; set; }
    public List<Bill1>? BillList { get; set; }
    
    private static List<Bill1> _instances = new List<Bill1>() { };

}
