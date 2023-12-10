
using System.ComponentModel.DataAnnotations;
using eBill.Data;

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
    public static async void CreateBill(Bill record, AppDbContext appDbContext)
    {
       Bill thisBill = new Bill();
       thisBill.Name = record.Name;
       thisBill.Amount = record.Amount;
       thisBill.Paid = record.Paid;
       thisBill.DueDate = record.DueDate;
       thisBill.CreatedDate = DateTime.Now;

        appDbContext.bill.Add(thisBill);
        await appDbContext.SaveChangesAsync();
      //  return Ok(thisBill);
      //_instances.Add(thisBill);
     
    }

    // Get all bill
    public static async Task<List<Bill>> GetAll(AppDbContext appDbContext)
    {
        var bills =  appDbContext.bill.ToList();
        return bills;
    }

   // Clear all bill
    public static void ClearAll()
    {
      _instances.Clear();
    }
}
