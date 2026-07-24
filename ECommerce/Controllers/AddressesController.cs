using Microsoft.AspNetCore.Mvc;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{
    public class AddressesController : Controller
    {
        private readonly AppDbContext _context;
        public AddressesController(AppDbContext context)
        {
            _context = context;
        }

        // Select * Addresses
        [HttpGet]
        public IActionResult Index()
        {
            if(_context.Addresses == null)
                return NotFound();
            var addresses = _context.Addresses.ToList();
            return View(addresses);
        }


        // Select one Address
        public IActionResult Details(Guid id)

        {
            var addresses = _context.Addresses.FirstOrDefault(a => a.AddressID == id);
            if(addresses == null)
                return NotFound();

            return View(addresses);
        }


        //insert
        [HttpGet]
        public IActionResult create() { return View(); }

        [HttpPost]
        public IActionResult create(Addresses addresses) 
        { 
            if(ModelState.IsValid)
            {
                _context.Addresses.Add(addresses);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(addresses);
        }


        //update
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var addresses = _context.Addresses.Find(id);
            if (addresses == null)
                return NotFound();
            return View(addresses);
        }

        [HttpPost]
        public IActionResult Edit(Addresses addresses)
        {
            if (ModelState.IsValid)
            {
                _context.Addresses.Update(addresses);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(addresses);
        }


        // delete
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }

      

        [HttpPost]
        public IActionResult Delete(Guid AddressID)
        {
            var addresses = _context.Addresses.Find(AddressID);

            if (addresses == null)
            {
                return NotFound();
            }

            _context.Remove(addresses);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
