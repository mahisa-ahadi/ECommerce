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
            var carts = _context.Cart.ToList();
            return View(carts);
        }

        //select one 
        [HttpGet]
        public IActionResult Details(Guid id)
        {
            var cart = _context.Cart.FirstOrDefault(x => x.CartID == id);
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
        public IActionResult create(Cart cart)
        {
            if(ModelState.IsValid)
            {   
                _context.Cart.Add(cart);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //update
        [HttpGet]
        public IActionResult Edit(Guid id) 
        {
            var cart = _context.Cart.Find(id);
            return View(cart);
        }

        [HttpPost]
        public IActionResult Edit(Cart cart)
        {
            if (ModelState.IsValid)
            {
                _context.Cart.Update(cart);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cart);
        }

        //Delete
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var cart = _context.Cart.Find(id);
            return View(cart);
        }

        [HttpPost]
        public IActionResult Delete(Cart cart)
        {
            _context.Cart.Remove(cart);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
