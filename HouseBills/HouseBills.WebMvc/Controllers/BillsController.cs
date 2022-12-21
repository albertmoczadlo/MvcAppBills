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
     
        public async Task<IActionResult> Details(string? id)
        {
            var bill =await _billsRepository.GetBillById(id);

            if (id == null || bill == null)
            {
                return NotFound();
            }
            return View(bill);
        }
        
    }
}
