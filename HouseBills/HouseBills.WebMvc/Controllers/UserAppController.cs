using HouseBills.WebMvc.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    }
}
