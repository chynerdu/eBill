using System;
using eBill.Data;
using eBill.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eBillsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class eBillController : ControllerBase
    {
        private readonly eBillContext _context;
        

        public eBillController(eBillContext context
           )
        {
            _context = context;
           
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bill>>> GetBills()
        {
            return await _context.bill.ToListAsync();
        }

        
        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bill>> PostBills(Bill item)
        {
            System.Console.WriteLine(item);
            _context.bill.Add(item);
            await _context.SaveChangesAsync();

            System.Console.WriteLine(item);

            return CreatedAtAction("GetBills",  item);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.bill.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.bill.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //private bool ProductExists(int id)
        //{
        //    return _context.bill.Any(e => e.BillId == id);
        //}

       
       
    }
}

