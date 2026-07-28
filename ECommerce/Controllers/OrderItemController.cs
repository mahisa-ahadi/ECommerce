using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class OrderItemController : Controller
    {
        private readonly AppDbContext _context;
        public OrderItemController(AppDbContext context)
        {  _context = context; }

        //select all
        [HttpGet]
        public IActionResult Index()
        {
            var orderItem = _context.OrderItem.ToList();
            if (orderItem == null) {return NotFound();} 
            return View(orderItem);
        }

        //select one
        [HttpGet]
        public IActionResult Details(Guid id)
        {
            var orderItem = _context.OrderItem.Find(id);
            if (orderItem == null) { return NotFound(); }
            return View(orderItem);
        }

        //insert
        [HttpPost]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(OrderItem orderItem)
        {
            if (ModelState.IsValid)
            {
                _context.OrderItem.Add(orderItem);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderItem);
        }

        //update
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var orderItem =_context.OrderItem.Find(id);
            if (orderItem == null) { return NotFound();}
            return View(orderItem);
        }
        [HttpPost]
        public IActionResult Edit(OrderItem orderItem)
        {
            if (ModelState.IsValid)
            {
                _context.OrderItem.Remove(orderItem);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderItem);
        }
        //Delete
    }
}
