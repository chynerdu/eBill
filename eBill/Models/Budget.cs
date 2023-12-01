using System.ComponentModel.DataAnnotations;
namespace eBill.Models;

public class Budget
{
    public int Id { get; }

    [Required]
    public decimal Amount { get; set; }
}
