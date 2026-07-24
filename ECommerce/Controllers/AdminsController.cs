using Microsoft.AspNetCore.Mvc;
using ECommerce.Models;
using ECommerce.Models.ViewModels;

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
        public IActionResult Create(AdminCreateViewModel model)
        {
            // Create User first
            if (!ModelState.IsValid)
                return View(model);

            var admin = new Admins
            {
                userID = Guid.NewGuid(),

                // User properties
                name = model.name,
                phone = model.phone,
                passwordHash = model.passwordHash,
                Role = role.Admin,
                IsActive = true,

                // Admin properties
                HireDate = model.HireDate,
                department = model.department,
                AccessLevel = model.AccessLevel,
                CanManageUsers = model.CanManageUsers,
                CanManageProducts = model.CanManageProducts
            };

            _context.Admins.Add(admin);
            _context.SaveChanges();


            return RedirectToAction(nameof(Index));
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

        //update
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var admin = _context.Admins.Find(id);
            if( admin == null)
                return NotFound();
            return View(admin);
        }

        [HttpPost]
        public IActionResult Edit(AdminEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var admin = _context.Admins.Find(model.userID);

            if (admin == null)
                return NotFound();

            admin.name = model.name;
            admin.phone = model.phone;
            admin.HireDate = model.HireDate;
            admin.department = model.department;
            admin.AccessLevel = model.AccessLevel;
            admin.CanManageUsers = model.CanManageUsers;
            admin.CanManageProducts = model.CanManageProducts;

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
