using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using eBill.Models;
using Newtonsoft.Json;
using System.Text;
using ClassLibrary.Model;

namespace eBill.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

   

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
      
    }



    public ActionResult Index()
    {

        Bill record = new Bill();

        // Get list of Bill

        return View(record);
    }

    public async Task<IActionResult> AllBills()
    {       
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync("https://localhost:7082/api/eBill"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                //System.Console.WriteLine(apiResponse);
                List<Bill> billList = new List<Bill>();
                Bill billItem = new Bill();
               
                List<Bill> newList = JsonConvert.DeserializeObject<List<Bill>>(apiResponse);
                foreach (var result in newList)
                {

                    //Console.WriteLine(result);
                    Bill thisBill = new Bill();
                    thisBill.Name = result.Name;
                    thisBill.Amount = result.Amount;
                    thisBill.Paid = result.Paid;
                    thisBill.DueDate = result.DueDate;
                    thisBill.CreatedDate = result.CreatedDate;

                    billList.Add(thisBill);
                    System.Console.WriteLine(thisBill.Name);
                }
                billItem.BillList = billList;
                System.Console.WriteLine(billItem.BillList.Count);
                return View(billItem);
            }
        }
        
    }


    [HttpPost]
    public async Task<ActionResult> Create(Bill model)
    {
     if (!ModelState.IsValid)
     {
       return RedirectToAction("Index");
     }
        // create a new BillBill thisBill = new Bill();
        Bill thisBill = new Bill();
        thisBill.Name = model.Name;
        thisBill.Amount = model.Amount;
        thisBill.Paid = model.Paid;
        thisBill.DueDate = model.DueDate;
        thisBill.CreatedDate = DateTime.Now;

        using (var httpClient = new HttpClient())
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(thisBill), Encoding.UTF8, "application/json");

            using (var response = await httpClient.PostAsync("https://localhost:7082/api/eBill", content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
              
            }
        }
       
        return RedirectToAction("AllBills");
    }


    [HttpPost("/index/delete")]
    public ActionResult DeleteAll()
    {
      // Bonus feature to Clear all Bill item
     
      return RedirectToAction("AllBills");
    }

     

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
