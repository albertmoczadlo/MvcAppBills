using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HouseBills.Infrastructure;
using HouseBills.Domain.Models;

namespace HouseBills.WebMvc.Controllers
{
    public class UserAppController : Controller
    {

        private readonly HouseBillsWebMvcDbContext _dbContext;
        

        public UserAppController(HouseBillsWebMvcDbContext dbContext)
        {
            _dbContext = dbContext;
             
        }

        public async Task<IActionResult> Index()
        {
            var db = _dbContext.Users;
            return View(await db.ToListAsync());
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _dbContext.Users == null)
            {
                return NotFound();
            }

            var user = await _dbContext.Users
                .FirstOrDefaultAsync(m => m.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_dbContext.Users == null)
            {
                return Problem("Entity set 'WebMvcDbHouseBillsWebMvcContext.Bill'  is null.");
            }
            var user = await _dbContext.Users.FindAsync(id);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
            }

            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Bills/Delete/5



    }
}
