using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDbContext _context;

        public CustomerController (AppDbContext context)
        {
            _context = context;
        }

        //select all
        [HttpGet]
        public IActionResult Index()
        {
            var customer = _context.Customer.ToList();
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        //select one
        [HttpGet]
        public IActionResult Details(Guid id)
        {
            var customer = _context.Customer.Find(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        //update
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var customer = _context.Customer.Find(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                 _context.Customer.Update(customer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        //insert
        [HttpGet]
        public IActionResult Create()
        { return View(); }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customer.Add(customer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        //Delete
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var customer = _context.Customer.Find(id);
            if (customer == null)
                return NotFound();
            return View(customer);
        }

        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            if(ModelState.IsValid)
            {
                _context.Customer.Remove(customer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }
    }
}
