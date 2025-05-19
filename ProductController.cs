using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROG7311POE2.Data;
using PROG7311POE2.Models;

namespace PROG7311POE2.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            var role = HttpContext.Session.GetString("UserRole");
            if (role != "Farmer") return Unauthorized();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProduct(AddProductViewModel model)
        {
            var userId = HttpContext.Session.GetString("UserId");
            var role = HttpContext.Session.GetString("UserRole");

            if (userId == null || role != "Farmer") return Unauthorized();

            if (!ModelState.IsValid) return View(model);

            var product = new Product
            {
                Name = model.Name,
                Category = model.Category,
                ProductionDate = model.ProductionDate,
                FarmerId = int.Parse(userId)
            };

            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("MyProducts");
        }


        public IActionResult MyProducts()
        {
            var userId = HttpContext.Session.GetString("UserId");
            if (userId == null || HttpContext.Session.GetString("UserRole") != "Farmer")
                return Unauthorized();

            var products = _context.Products
                .Where(p => p.FarmerId == int.Parse(userId))
                .ToList();

            return View(products);
        }

        public IActionResult AllProducts(string category, DateTime? fromDate, DateTime? toDate)
        {
            var query = _context.Products.Include(p => p.Farmer).AsQueryable();

            if (!string.IsNullOrWhiteSpace(category))
            {
                var trimmedCategory = category.Trim().ToLower();
                query = query.Where(p => p.Category.ToLower().Contains(trimmedCategory));
            }

            if (fromDate.HasValue)
            {
                query = query.Where(p => p.ProductionDate >= fromDate.Value);
            }

            if (toDate.HasValue)
            {
                query = query.Where(p => p.ProductionDate <= toDate.Value);
            }

            var model = new ProductFilterViewModel
            {
                Category = category,
                FromDate = fromDate,
                ToDate = toDate,
                FilteredProducts = query.ToList()
            };

            return View(model);
        }
    }
}
