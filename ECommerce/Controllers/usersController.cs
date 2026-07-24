using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class usersController : Controller
    {
        private readonly AppDbContext _context;
        public usersController(AppDbContext context)
        {
            _context = context;
        }

        //select * from users
        [HttpGet]
        public IActionResult Index()
        {
            var users=_context.users.Where(u =>u.IsActive).ToList();
            return View(users);
        }

        //select one from users
        [HttpGet]
        public IActionResult Details(Guid id)
        {
            var user = _context.users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        //insert
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(users user)
        {
            if (ModelState.IsValid)
            {
                _context.users.Add(user);
                _context.SaveChanges();

                return RedirectToAction("Index");

            }

            return View(user);
        }


        //update
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var user = _context.users.Find(id);
            if (user == null)
                return NotFound();
            return View(user);
        }


        [HttpPost]
        public IActionResult Edit(users user)
        {
            if (ModelState.IsValid)
            {
                _context.users.Update(user);
                _context.SaveChanges();

                return RedirectToAction("Index");

            }
            return View(user);
        }

    }
}
