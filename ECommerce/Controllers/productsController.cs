using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class productsController : Controller
    {
        private readonly AppDbContext _context;
        public productsController(AppDbContext context)
        {
            _context = context;
        }

        //show all products
        public IActionResult Index()
        {
            var products = _context.products
                                  .Where(p => p.IsActive)
                                  .ToList();

            return View(products);
        }

        //show one product
        public IActionResult Details(Guid id)
        {
            var product = _context.products.FirstOrDefault(p => p.productID == id);
            if (product == null)
                return NotFound();
            return View(product);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(products product)
        {
            if (ModelState.IsValid)
            {
                _context.products.Add(product);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var product = _context.products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(products product)
        {
            if (ModelState.IsValid)
            {
                _context.products.Update(product);

                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(Guid ProductID)
        {
            var product = _context.products.Find(ProductID);

            if (product == null)
            {
                return NotFound();
            }

            product.IsActive = false;

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
