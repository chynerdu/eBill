
using System.ComponentModel.DataAnnotations;
namespace eBill.Models;

public class Bill
{
    public int Id { get; set; }

   [Required]
    public string? Name { get; set; }

    [Required]
    public decimal Amount { get; set; }
    public bool Paid { get; set; }
    public DateTime? DueDate { get; set; }
    public DateTime? CreatedDate { get; set; }
    public List<Bill>? BillList { get; set; }
    
    private static List<Bill> _instances = new List<Bill>() { };

  // Create a bill item
    public static void CreateBill(Bill record)
    {
       Bill thisBill = new Bill();
       thisBill.Name = record.Name;
       thisBill.Amount = record.Amount;
       thisBill.Paid = record.Paid;
       thisBill.DueDate = record.DueDate;
       thisBill.CreatedDate = DateTime.Now;
       thisBill.Id = _instances.Count + 1;
      _instances.Add(thisBill);
     
    }

    // Get all bill
    public static List<Bill> GetAll()
    {
        return _instances;
    }

   // Clear all bill
    public static void ClearAll()
    {
      _instances.Clear();
    }
}
