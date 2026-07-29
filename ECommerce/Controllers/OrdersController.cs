using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class OrdersController : Controller
    {
        private readonly AppDbContext _context;
        public OrdersController (AppDbContext context)
        {
            _context = context;
        }

        //select all
        [HttpGet]
        public IActionResult Index()
        {
            var orders = _context.Orders.ToList();
            if(orders==null)
                return NotFound();
            return View(orders);
        }

        //select one
        [HttpGet]
        public IActionResult Details(Guid id)
        {
            var order=_context.Orders.Find(id);
            if(order==null)
                return NotFound();
            return View(order);
        }

        //insert
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Orders orders)
        {
            if (ModelState.IsValid)
            {
                _context.Orders.Add(orders);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orders);
        }

        //update
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var order= _context.Orders.Find(id);
            if (order==null)
                return NotFound();
            return View(order);
        }

        [HttpPost]
        public IActionResult Edit(Orders orders)
        {
            if (ModelState.IsValid)
            {
                _context.Orders.Update(orders);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orders);
        }

        //Delete
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var order = _context.Orders.Find(id);
            if (order == null)
                return NotFound();
            return View(order);
        }

        [HttpPost]
        public IActionResult Delete(Orders orders)
        {
            _context.Orders.Remove(orders);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
