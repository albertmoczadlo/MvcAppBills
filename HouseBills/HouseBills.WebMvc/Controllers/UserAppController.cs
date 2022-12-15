using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HouseBills.Infrastructure;
using HouseBills.Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using SendGrid.Helpers.Mail;
using HouseBills.Infrastructure.Repository;
using HouseBills.Domain.Interfaces;

namespace HouseBills.WebMvc.Controllers
{
    public class UserAppController : Controller
    {

        private readonly IUserRepository _userRepository;

        public UserAppController(IUserRepository userRepository)
        {
                _userRepository= userRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(_userRepository.GetAllUsers());
        }

        //public async Task<IActionResult> Delete(string id)
        //{
        //    if (id == null || _dbContext.Users == null)
        //    {
        //        return NotFound();
        //    }

        //    var user = await _dbContext.Users
        //        .FirstOrDefaultAsync(m => m.Id.ToString() == id);

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(user);
        //}

        //public async Task<IActionResult> DeleteConfirmed(string id)
        //{
        //    if (_dbContext.Users == null)
        //    {
        //        return Problem("Entity set 'WebMvcDbHouseBillsWebMvcContext.Bill'  is null.");
        //    }
        //    var user = await _dbContext.Users.FindAsync(id);
        //    if (user != null)
        //    {
        //        _dbContext.Users.Remove(user);
        //    }

        //    await _dbContext.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}


        //public async Task<IActionResult> Edit(string? id)
        //{
        //    if (id == null || _dbContext.Users == null)
        //    {
        //        return NotFound();
        //    }

        //    var user = await _dbContext.Users.FindAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["UserAppId"] = new SelectList(_dbContext.Set<UserApp>(), "Id", "Id", user.Id);
        //    return View(user);
        //}

        //// POST: Bills/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(string id, [Bind("Id,FirstName,LastName")] UserApp user)
        //{
        //    if (id != user.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _dbContext.Update(user);//pobrac uzyt o id, 
        //            await _dbContext.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!UserExists(user.Id.ToString()))
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
        //    return View(user);
        //}

        //private bool UserExists(string id)
        //{
        //    return _dbContext.Bills.Any(e => e.Id.ToString() == id);
        //}
        // POST: Bills/Delete/5



    }
}
