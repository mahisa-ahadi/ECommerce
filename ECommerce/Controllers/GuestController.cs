using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class GuestController : Controller
    {
        private readonly AppDbContext _context;
        public GuestController (AppDbContext context)
        {  _context = context; }

        //select all
        [HttpGet]
        public IActionResult Index()
        {
            var guest = _context.Guest.ToList();
            if (guest == null) { return NotFound(); }
            return View(guest);
        }

        //select on
        [HttpGet]
        public IActionResult Details(Guid id)
        {
            var guest = _context.Guest.Find(id);
            if (guest == null)
            {
                return NotFound();
            }
            return View(guest);
        }

        //update
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var guest = _context.Guest.Find(id);
            if (guest == null)
            {
                return NotFound();
            } return View(guest);
        }

        //insert
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Guest guest)
        {
            if (ModelState.IsValid)
            {
                _context.Guest.Add
                        (guest);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(guest);
        }
        //delete
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var guest = _context.Guest.Find(id);
            if (guest == null)
            {
                return NotFound();
            }
            return View(guest);
        }

        [HttpPost]
        public IActionResult Delete(Guest guest)
        {
            if (ModelState.IsValid)
            {
                _context.Guest.Remove(guest);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(guest);

        }
    }
}
