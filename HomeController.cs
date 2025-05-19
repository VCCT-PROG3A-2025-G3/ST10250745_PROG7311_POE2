using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROG7311POE2.Data;
using PROG7311POE2.Models;

namespace PROG7311POE2.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult EmployeePage()
    {
        ViewBag.Email = HttpContext.Session.GetString("UserEmail");
        return View();
    }

    public IActionResult FarmerPage()
    {
        ViewBag.Email = HttpContext.Session.GetString("UserEmail");
        ViewBag.FullName = HttpContext.Session.GetString("UserFullName");
        ViewBag.Id = HttpContext.Session.GetString("UserId");
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [Authorize(Roles = "Employee")]
    public IActionResult FarmersList()
    {
        var farmers = _context.Farmers.ToList();
        return View(farmers); // Display a list of farmers
    }

    [Authorize(Roles = "Employee")]
    public IActionResult ProductsForFarmer(int farmerId)
    {
        var farmer = _context.Farmers.Include(f => f.Products)
                                      .FirstOrDefault(f => f.Id == farmerId);

        if (farmer == null)
        {
            return NotFound();
        }

        return View(farmer.Products); // Pass products to the view
    }
}
