using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HouseBills;
using HouseBills.Domain.Models;
using HouseBills.Infrastructure;



namespace HouseBills.WebMvc.Controllers
{
    public class BillsController : Controller
    {
        private readonly IBillsRepository _billsRepository;
        private readonly HouseBillsWebMvcDbContext _dbContext;

        public BillsController(IBillsRepository billsRepository, HouseBillsWebMvcDbContext dbContext)
        {
            _dbContext= dbContext;
            _billsRepository = billsRepository;
        }

      
        public async Task<IActionResult> Index()
        {
            var model = await _billsRepository.GetAllBills();
            
            return View(model);
        }
     
        public async Task<IActionResult> Details(string? id)
        {
            var bill =  _billsRepository.GetBillById(id);

            if (id == null || bill == null)
            {
                return NotFound();
            }
            return View(bill);
        }

        // GET: Bills/Create
        public IActionResult Create()
        {
          ViewData["UsersId"] = new SelectList(_dbContext.Set<UserApp>(), "Id", "Id");
            return View();
        }

        // POST: Bills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Bill bill)
        {
            Bill billOne = new Bill
            {
                Name = bill.Name,
            };

            //ViewData["UserAppId"] = new SelectList(_dbContext.Set<UserApp>(), "Id", "Id", bill.UserId);

            await _dbContext.Bills.AddAsync(billOne);

            await _dbContext.SaveChangesAsync();

            return View(billOne);
        }

        //// GET: Bills/Edit/5
        //public async Task<IActionResult> Edit(Guid? id)
        //{
        //    if (id == null || _context.Bills == null)
        //    {
        //        return NotFound();
        //    }

        //    var bill = await _context.Bills.FindAsync(id);
        //    if (bill == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["UserAppId"] = new SelectList(_context.Set<UserApp>(), "Id", "Id", bill.UserId);
        //    return View(bill);
        //}

        //// POST: Bills/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,DateTimePay,Sum,BlockEnergy,Heating,ColdWater,HeatingWater,RenovationFund,UserAppId")] Bill bill)
        //{
        //    if (id != bill.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(bill);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!BillExists(bill.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["UserAppId"] = new SelectList(_context.Set<UserApp>(), "Id", "Id", bill.UserId);
        //    return View(bill);
        //}

        //// GET: Bills/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null || _context.Bills == null)
        //    {
        //        return NotFound();
        //    }

        //    var bill = await _context.Bills
        //        .Include(b => b.UserApps)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (bill == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(bill);
        //}

        //// POST: Bills/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    if (_context.Bills == null)
        //    {
        //        return Problem("Entity set 'WebMvcDbHouseBillsWebMvcContext.Bill'  is null.");
        //    }
        //    var bill = await _context.Bills.FindAsync(id);
        //    if (bill != null)
        //    {
        //        _context.Bills.Remove(bill);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool BillExists(Guid id)
        //{
        //  return _context.Bills.Any(e => e.Id == id);
        //}
    }
}
