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
    }
}
