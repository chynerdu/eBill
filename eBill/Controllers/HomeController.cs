using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using eBill.Models;


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
       record.BillList = Bill.GetAll().ToList();
       
        return View(record);
    }


    [HttpPost]
    public ActionResult Create(Bill model)
    {
     if (!ModelState.IsValid)
     {
       return RedirectToAction("Index");
     }
      // create a new Bill
       Bill.CreateBill(model);
       return RedirectToAction("AllBills");
    }


    [HttpPost("/index/delete")]
    public ActionResult DeleteAll()
    {
      // Bonus feature to Clear all Bill item
      Bill.ClearAll();
      return RedirectToAction("AllBills");
    }

     
       public ActionResult AllBills()
    {
        Bill record = new Bill();

     // Get list of Bill
       record.BillList = Bill.GetAll().ToList();
       
        return View(record);
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
