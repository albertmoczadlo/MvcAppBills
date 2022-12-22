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
        public BillsController(IBillsRepository billsRepository)
        { 
            _billsRepository = billsRepository;
        }
      
        public async Task<IActionResult> Index()
        {
            var model = await _billsRepository.GetAllBills();
            
            return View(model);
        }
     
        public async Task<IActionResult> Details(Guid id)
        {
            var bill =await _billsRepository.GetBillById(id);

            if (id == null || bill == null)
            {
                return NotFound();
            }
            return View(bill);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var bill = _billsRepository.GetBillById(id);

            return View(bill);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var bill = await _billsRepository.GetBillById(id);

            if(bill== null)
            {
                return NotFound();
            }

            _billsRepository.DeleteBill(bill);

            return RedirectToAction("Index"); 
        }

    }
}
