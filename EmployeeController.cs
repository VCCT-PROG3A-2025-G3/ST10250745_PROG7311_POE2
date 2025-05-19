using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PROG7311POE2.Data;
using PROG7311POE2.Models;

namespace PROG7311POE2.Controllers
{
    [Authorize(Roles = "Employee")]  // Ensure only employees can access this
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employee/CreateFarmer
        public IActionResult CreateFarmer()
        {
            return View();
        }

        // POST: Employee/CreateFarmer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFarmer(Farmer farmer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(farmer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));  // Redirect to a list or dashboard
            }
            return View(farmer);  // If the model is not valid, return to the same page
        }
    }
}
