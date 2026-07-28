using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _context;

        public CartController(AppDbContext context)
        {
            _context = context;
        }



        //select *
        [HttpGet]
        public IActionResult Index()
        {
            var Carts = _context.carts.ToList();
            return View(Carts);
        }

        //select one 
        [HttpGet]
        public IActionResult Details(Guid id)
        {
            var cart = _context.carts.FirstOrDefault(x => x.cartID == id);
            if (cart == null) 
                return NotFound();
            return View(cart);
        }

        //insert
        [HttpGet]
        public IActionResult create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult create(cart carts)
        {
            if(ModelState.IsValid)
            {   
                _context.carts.Add(carts);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //update
        [HttpGet]
        public IActionResult Edit(Guid id) 
        {
            var cart = _context.carts.Find(id);
            return View(cart);
        }

        [HttpPost]
        public IActionResult Edit(cart carts)
        {
            if (ModelState.IsValid)
            {
                _context.carts.Update(carts);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carts);
        }

        //Delete
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var cart = _context.carts.Find(id);
            return View(cart);
        }

        [HttpPost]
        public IActionResult Delete(cart carts)
        {
            _context.carts.Remove(carts);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
