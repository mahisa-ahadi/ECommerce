using Microsoft.AspNetCore.Mvc;
using ECommerce.Models;

namespace ECommerce.Controllers
{
    public class AdminsController : Controller
    {
        private readonly AppDbContext _context;
        public AdminsController(AppDbContext context)
        {
            _context = context;
        }

        //select * 
        [HttpGet]
        public IActionResult Index()
        {
            var admins = _context.Admins
                                 .Where(a => a.IsActive)
                                 .ToList();

            return View(admins);
        }

        //select one 
        [HttpGet]
        public IActionResult Details(Guid id)
        {
            var admins = _context.Admins.FirstOrDefault(a => a.userID == id);
            if (admins == null)
                return NotFound();
            return View(admins);
        }

        //insert
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Admins admins)
        {
            if (ModelState.IsValid)
            {  
                _context.Admins.Add(admins);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admins);
        }

        //soft delete

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var admin = _context.Admins.Find(id);

            if (admin == null)
                return NotFound();

            return View(admin);
        }

        [HttpPost]
        public IActionResult Delete(Admins admins)
        {
            var admin=_context.Admins.Find(admins.userID);
            if(admin == null)
                return NotFound();
            admin.IsActive = false;
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
